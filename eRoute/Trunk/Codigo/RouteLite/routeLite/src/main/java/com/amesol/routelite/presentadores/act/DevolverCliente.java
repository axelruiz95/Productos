package com.amesol.routelite.presentadores.act;

import android.database.Cursor;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.InventarioDobleUnidad;
import com.amesol.routelite.actividades.ListaPrecio;
import com.amesol.routelite.actividades.ManejoEnvase;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ManejoLotesCaducidad;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.Precio;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.TPDDatosExtra;
import com.amesol.routelite.datos.TRPVtaAcreditada;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.LoteCaducidad;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasCantidad;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaFirma;
import com.amesol.routelite.presentadores.interfaces.IDevolucionCliente;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;

import org.apache.commons.lang3.time.DateParser;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.concurrent.atomic.AtomicReference;

public class DevolverCliente extends Presentador
{

	IDevolucionCliente mVista;
	String mAccion;
	TransProd transProdGeneral;
	ModuloMovDetalle moduloMovDetalle;
	CONHist oConHist;
	String sClienteClave;
	HashMap<String, TransProd> transacciones = new HashMap<String, TransProd>();
    /*Inicio Codigo Luis de la torre*/
    //ManejoLotesCaducidad manejoLoteCaducidad;
	LoteCaducidad loteCaducidad;
    TRPVtaAcreditada trpvtaAcreditada;
    ConfigParametro configParametro;
	/*Fin Codigo Luis de la torre*/
    String  sGrupoTipoMotivo = "";
    boolean bDevolucionParaRecoleccion = false;
    boolean bManejarInventario = true;
    boolean bRecolectando = false;
    boolean bConsultando = false;
    boolean bSoloLectura = false;

	public DevolverCliente(IDevolucionCliente vista, String accion)
	{
		mVista = vista;
		mAccion = accion;
		sClienteClave = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave;
		String sModuloMovDetalleClave = (String) Sesion.get(Campo.ModuloMovDetalleClave);
		moduloMovDetalle = new ModuloMovDetalle();
		moduloMovDetalle.ModuloMovDetalleClave = sModuloMovDetalleClave;
		try
		{
			BDVend.recuperar(moduloMovDetalle);
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
		oConHist = (CONHist) Sesion.get(Campo.CONHist);
	}

	@Override
	public void iniciar()
	{
		if (transProdGeneral != null)
		{
			mVista.setFolio(transProdGeneral.Folio);
			mVista.setFecha(new SimpleDateFormat("dd/MM/yyyy").format(transProdGeneral.FechaCaptura));
			mVista.setListaPrecio(transProdGeneral.getListaPrecios().get(0).Nombre);
			if (!mVista.getEsNuevo())
            {
                if (mVista.getbValidarFactura()){
                    mVista.setFactura(obtenerFolioFactura());
                    mVista.setComentarios(transProdGeneral.Notas);
                    mVista.setbCargandoComentarios(false);
                }else{
                    mVista.setFactura(transProdGeneral.Notas);
                }
                if (bDevolucionParaRecoleccion){
                    if (!bRecolectando) {
                        if (!bConsultando) {
                            if (Consultas.ConsultasDevolucionCliente.obtenerProgramadaParaRecoleccion(transProdGeneral.TransProdID)) {
                                mVista.setRecoleccion(true);
                                mVista.setFechaRecoleccion(transProdGeneral.FechaEntrega);
                                bManejarInventario = false;
                            } else {
                                mVista.ocultarRecoleccion();
                            }
                        }else{
                            mVista.setFechaRecoleccion(transProdGeneral.FechaSurtido);
                            mVista.ocultarRecoleccion();
                        }
                    }else{
                        mVista.setFechaRecoleccion(transProdGeneral.FechaEntrega);
                        mVista.ocultarRecoleccion();
                        if (!bSoloLectura)
                            recolectar();
                    }
                }
                //mostramos el telefono luis de la torre
                try
                {
                    configParametro = new ConfigParametro();
                    if(configParametro.get("CapturaPRecoleccion").equals("1"))
                    {
                        traerTelefono();
                        traerDomicilio();
                    }
                }
                catch (Exception e)
                {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }
            }
		}
	}

    public void setDevolucionParaRecoleccion(boolean recoleccion){
        bDevolucionParaRecoleccion = recoleccion;
    }

    public void setRecolectando(boolean recolectando){
        bRecolectando = recolectando;
    }

    public void setConsultando(boolean consultando){
        bConsultando = consultando;
    }

    public void setbSoloLectura(boolean soloLectura){
        bSoloLectura = soloLectura;
    }

    public void setManejarInventario(boolean inventario){
        bManejarInventario = inventario;
    }

	public void guardarNotas(String notas)
	{
		try
		{
			transProdGeneral.Notas = notas;
			BDVend.guardarInsertar(transProdGeneral);
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public void guardarFacturaId(String transProdIDFAC)
	{
		try
		{
			transProdGeneral.FacturaID = transProdIDFAC;
			BDVend.guardarInsertar(transProdGeneral);
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public void crearTransProd() throws ControlError, Exception
	{
			StringBuilder byRefMensaje = new StringBuilder();
			transProdGeneral = Transacciones.generarTransaccion(moduloMovDetalle, byRefMensaje);
			if (byRefMensaje.length()>0){
				mVista.mostrarAdvertencia(byRefMensaje.toString());
			}
			byRefMensaje = null;
			transProdGeneral.CFVTipo = (Short) null;
			transProdGeneral.ClienteClave = null;

			transProdGeneral.TipoPedido = (Short) null;
			transProdGeneral.SubTDetalle = (Float) null;
			transProdGeneral.DescVendPor = (Float) null;
			transProdGeneral.DescuentoVendedor = (Float) null;
			transProdGeneral.DescuentoImp = (Float) null;
			transProdGeneral.Subtotal = (Float) null;
			transProdGeneral.Impuesto = (Float) null;
			transProdGeneral.Promocion = (Boolean) null;
			transProdGeneral.Descuento = (Boolean) null;
			transProdGeneral.TipoTurno = (Short) null;
			transProdGeneral.DiasCredito = (Short) null;

			/*
			 * Calendar cal = Calendar.getInstance();
			 * cal.setTime(Generales.getFechaActual()); cal.add(Calendar.DATE,
			 * Integer.parseInt(oConHist.get("DiasSurtido").toString()));
			 */
			transProdGeneral.FechaEntrega = null;

			transProdGeneral.FechaCobranza = null;
			transProdGeneral.FechaFacturacion = null;
			transProdGeneral.FechaSurtido = null;
			transProdGeneral.FechaCancelacion = null;

			BDVend.recuperar(transProdGeneral, TransProdDetalle.class);
			transacciones.put(transProdGeneral.SubEmpresaId, transProdGeneral);
			mVista.setParametrosCaptura(transProdGeneral.CadenaListasPrecios, getTransaccionesIds());
			BDVend.guardarInsertar(transProdGeneral);
	}

	public void recuperarTransProd(String transProdID)
	{
		try
		{
			HashMap<Integer,Precio> listasPrecios= ListaPrecio.Determinar(sClienteClave, moduloMovDetalle);
			transProdGeneral = new TransProd();
			transProdGeneral.TransProdID = transProdID;
			BDVend.recuperar(transProdGeneral);
			transProdGeneral.setListaPrecios(listasPrecios);
			transProdGeneral.PCEPrecioClave = listasPrecios.get(0).PrecioClave ;
			BDVend.recuperar(transProdGeneral, TransProdDetalle.class);

			for (TransProdDetalle tpd : transProdGeneral.TransProdDetalle)
			{
				Producto pro = new Producto();
				pro.ProductoClave = tpd.ProductoClave;
				BDVend.recuperar(pro);
				tpd.producto = pro;
				tpd.recienAgregado = false;
				tpd.cantidadModificada = false;

				if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").toString().equals("1")) {
					BDVend.recuperar(tpd, TPDDatosExtra.class);
				}
			}
			/*
			 * }else if(mAccion.equals(Enumeradores.Acciones.
			 * ACCION_CAMBIAR_PRODUCTO_SALIDA)){ //obtener el transprod de
			 * sesion ArrayList<TransProd> otrp = (ArrayList<TransProd>)
			 * Sesion.get(Campo.ArrayTransProd); transProdGeneral = otrp.get(0);
			 * }
			 */

			transacciones.put(transProdGeneral.SubEmpresaId, transProdGeneral);
			mVista.setParametrosCaptura(transProdGeneral.CadenaListasPrecios, getTransaccionesIds());
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

    public String obtenerFolioFactura(){
        try{
            String transprodID = transProdGeneral.FacturaID;
            String folioFactura = Consultas.ConsultasDevolucionCliente.obtenerFolioFactura(transprodID);

            return folioFactura;
        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
        }
        return "";
    }

	public TransProd getTransProd()
	{
		return transProdGeneral;
	}

    public List<TransProdDetalle> getDetalles(){
        List<TransProdDetalle> detalles = new ArrayList<>();
        for (final Object transProd : transacciones.values().toArray())
        {
            detalles.addAll(((TransProd) transProd).TransProdDetalle);
        }
        return detalles;
    }

	public String getTransaccionesIds()
	{
		String Ids = "";
		for (final Object transProd : transacciones.values().toArray())
		{
			Ids = Ids + "'" + (((TransProd) transProd).TransProdID) + "',";
		}
		if (Ids.length() > 0)
		{
			Ids = Ids.substring(0, Ids.length() - 1);
		}
		return Ids;
	}

	public TransProdDetalle existe(Producto producto, int tipoUnidad)
	{
		for (TransProdDetalle trp : transProdGeneral.TransProdDetalle)
		{
			if (trp.ProductoClave.equals(producto.ProductoClave) && trp.TipoUnidad == tipoUnidad)
				return trp;
		}
		return null;
	}

	public void obtenerTotales(String TransProdID)
	{
		try
		{
			//String res = "0";
			ISetDatos setDatos = Consultas.ConsultasTransProdDetalle.obtenerTotales(TransProdID);
			if (setDatos.moveToNext())
			{
				//res = setDatos.getString(1);
				mVista.setTotal(setDatos.getString(1) == null ? "0" : setDatos.getString(1));
				mVista.setProductosDev(setDatos.getString(0));
                /*Incio codigo luis de la torre*/
                mVista.setVolumen(setDatos.getString(4) == null ? "0" : setDatos.getString(4));
				/*Fin codigo luis de la torre*/
			}
			//mVista.startManagingCursor((Cursor) setDatos.getOriginal());
			setDatos.close();

			//return res == null ? "0" : res;
		}
		catch (Exception e)
		{
			//return "0";
		}
	}

	public boolean validarProductoContenido(Producto producto) throws Exception
	{
		if (producto.Contenido && !producto.Venta)
		{
			throw new ControlError("E0725");
		}
		return true;
	}

	/*private void validarExistencia(String productoClave, Float cantidad, int tipoUnidad) throws Exception
	{
		//TODO: validar existencia
		Log.d("CambiosProducto", "Validar existencia, Producto: " + productoClave + ", Cantidad: " + cantidad);
		//si no hay existencia suficiente mostrar mensaje E0029 y asignar cantidad disponible
		AtomicReference<Float> existencia = null;
		StringBuilder error = null;
		boolean validar = Inventario.ValidarExistencia(productoClave, tipoUnidad, cantidad, Float.valueOf(0), transProdGeneral.TipoMovimiento, moduloMovDetalle.TipoTransProd, false, existencia, error);

	}*/

	public void actualizarCantidad(TransProdDetalle tpd, Float cantidad)
	{
		try
		{
			/*if (!tpd.recienAgregado)
			{
				validarExistencia(tpd.ProductoClave, tpd.Cantidad, tpd.TipoUnidad);
			}*/

			//cancelar inventario actual
			TransProdDetalle res;
			res = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd, tpd.TipoMotivo, moduloMovDetalle.TipoTransProd, cantidad, true, bManejarInventario);
			if (res == null) return;

			if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO ||
					Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA) &&
					((Cliente) Sesion.get(Campo.ClienteActual)).Prestamo &&
					((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("RecoleccionEnvase").toString().equalsIgnoreCase("1") ){
				ManejoEnvase.manejoEnvaseEliminar(tpd.producto, tpd.TipoUnidad, tpd.Cantidad, tpd, transProdGeneral);
				ManejoEnvase.manejoEnvase(tpd.producto, tpd.TipoUnidad, cantidad, tpd, transProdGeneral);
			}

			tpd.Cantidad = cantidad;
			tpd = TransaccionesDetalle.DevolucionesCliente.calcularTotales(tpd, transProdGeneral.CadenaListasPrecios);
			//entrada
			TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd, tpd.TipoMotivo, moduloMovDetalle.TipoTransProd,cantidad, false, bManejarInventario);

			BDVend.guardarInsertar(tpd);
			mVista.setHuboCambios(true);
			mVista.refrescarProductos(getTransaccionesIds());
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public void actualizarCantidadDobleUnidad(TransProdDetalle tpd, HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades)
	{
		try
		{
			//cancelar inventario actual
			TransProdDetalle res;
				res = TransaccionesDetalle.ActualizarTipoMotivoTransaccionDobleUnidad(tpd, tpd.TipoMotivo, moduloMovDetalle.TipoTransProd, hmDetalleUnidades, true);
			if (res == null) return;

			//No se maneja envase con la doble unidad
			/*if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO ||
					Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA) &&
					((Cliente) Sesion.get(Campo.ClienteActual)).Prestamo &&
					((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("RecoleccionEnvase").toString().equalsIgnoreCase("1") ){
				ManejoEnvase.manejoEnvaseEliminar(tpd.producto, tpd.TipoUnidad, tpd.Cantidad, tpd, transProdGeneral);
				ManejoEnvase.manejoEnvase(tpd.producto, tpd.TipoUnidad, cantidad, tpd, transProdGeneral);
			}*/

			tpd.Cantidad = hmDetalleUnidades.get(Short.parseShort(String.valueOf(tpd.TipoUnidad))).Cantidad;
			if (tpd.TPDDatosExtra!= null && tpd.TPDDatosExtra.size()>0 && tpd.TPDDatosExtra.get(0).UnidadAlterna != null && tpd.TPDDatosExtra.get(0).UnidadAlterna >0){
				tpd.TPDDatosExtra.get(0).CantidadAlterna = hmDetalleUnidades.get(tpd.TPDDatosExtra.get(0).UnidadAlterna).Cantidad;
			}
			tpd = TransaccionesDetalle.DevolucionesCliente.calcularTotales(tpd, transProdGeneral.CadenaListasPrecios);
			//entrada
			TransaccionesDetalle.ActualizarTipoMotivoTransaccionDobleUnidad(tpd, tpd.TipoMotivo, moduloMovDetalle.TipoTransProd,hmDetalleUnidades, false);

			BDVend.guardarInsertar(tpd);
			mVista.setHuboCambios(true);
			mVista.refrescarProductos(getTransaccionesIds());
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}
	public boolean actualizarMotivo(TransProdDetalle tpd, short motivo)
	{
		try {
            //Recorrer los detalles para asignar valor al grupoTipoMotivo si todos estan como no definido
            if (oConHist.get("HabilitaInventario").equals("1")) {
                boolean bActualizar = true;
                for (TransProdDetalle tpd1 : getTransProd().TransProdDetalle) {
                    if(!tpd1.TransProdDetalleID.equals(tpd.TransProdDetalleID)) {
                        if (tpd1.TipoMotivo != 0) {
                            bActualizar = false;
                            break;
                        }
                    }
                }
                if (bActualizar) {
                    setGrupoTipoMotivo(String.valueOf(motivo));
                    mVista.setMotivos(getGrupoTipoMotivo());
                }
            }

			/*if (!tpd.recienAgregado)
			{
				validarExistencia(tpd.ProductoClave, tpd.Cantidad, tpd.TipoUnidad);
			}*/
			TransProdDetalle res;
			res = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd, tpd.TipoMotivo, moduloMovDetalle.TipoTransProd, Float.valueOf(0), true, bManejarInventario); //salida
			if (res == null) return false ;
			
			tpd = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd, motivo, moduloMovDetalle.TipoTransProd, tpd.Cantidad, false, bManejarInventario); //entrada
			
			
			boolean refrescar = false;
			//recorrer todos los detalle para actualizar los que tengan motivo no definido
			for (TransProdDetalle tpd1 : getTransProd().TransProdDetalle)
			{
				if (tpd1.TipoMotivo == 0)
				{
					// cancelar el inventario del motivo actual 
					TransProdDetalle otpd = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd1, tpd1.TipoMotivo, moduloMovDetalle.TipoTransProd, Float.valueOf(0), true, bManejarInventario); //salida
					// actualizar inventario con motivo nuevo
					otpd = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd1, motivo, moduloMovDetalle.TipoTransProd, tpd1.Cantidad,false, bManejarInventario);
					BDVend.guardarInsertar(otpd);
					refrescar = true;
				}
			}
			if (refrescar)
				mVista.refrescarProductos(getTransaccionesIds());

			mVista.setHuboCambios(true);
			mVista.setTipoMotivo(motivo);
			return true;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
		return false;
	}

	public boolean actualizarMotivoDobleUnidad(TransProdDetalle tpd, short motivo)
	{
		try
		{
            //Recorrer los detalles para asignar valor al grupoTipoMotivo si todos estan como no definido
            if (oConHist.get("HabilitaInventario").equals("1")) {
                boolean bActualizar = true;
                for (TransProdDetalle tpd1 : getTransProd().TransProdDetalle) {
                    if(!tpd1.TransProdDetalleID.equals(tpd.TransProdDetalleID)) {
                        if (tpd1.TipoMotivo != 0) {
                            bActualizar = false;
                            break;
                        }
                    }
                }
                if (bActualizar) {
                    setGrupoTipoMotivo(String.valueOf(motivo));
                    mVista.setMotivos(getGrupoTipoMotivo());
                }
            }

			TransProdDetalle res;
			boolean blnCantidadAlterna  = false;
			HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades = new HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad>();
			hmDetalleUnidades.put(Short.parseShort(String.valueOf(tpd.TipoUnidad)), new InventarioDobleUnidad.DetalleProductoDobleUnidad(Short.parseShort(String.valueOf(tpd.TipoUnidad)), null,0f, null, null,null,null));
			if(tpd.TPDDatosExtra != null && tpd.TPDDatosExtra.size() >0 && tpd.TPDDatosExtra.get(0).UnidadAlterna != null && tpd.TPDDatosExtra.get(0).UnidadAlterna>0){
				blnCantidadAlterna = true;
				hmDetalleUnidades.put(tpd.TPDDatosExtra.get(0).UnidadAlterna, new InventarioDobleUnidad.DetalleProductoDobleUnidad(tpd.TPDDatosExtra.get(0).UnidadAlterna,null,0f, null,null,null,null ));
			}
			//Actualizar en 0 le motivo actual
			res = TransaccionesDetalle.ActualizarTipoMotivoTransaccionDobleUnidad(tpd, tpd.TipoMotivo, moduloMovDetalle.TipoTransProd, hmDetalleUnidades, true); //salida
			if (res == null) return false ;

			//Actualizar la cantidad del nuevo motivo
			hmDetalleUnidades.get(Short.parseShort(String.valueOf(tpd.TipoUnidad))).Cantidad = tpd.Cantidad;
			if (blnCantidadAlterna){
				hmDetalleUnidades.get(tpd.TPDDatosExtra.get(0).UnidadAlterna).Cantidad = tpd.TPDDatosExtra.get(0).CantidadAlterna;
			}
			tpd = TransaccionesDetalle.ActualizarTipoMotivoTransaccionDobleUnidad(tpd, motivo, moduloMovDetalle.TipoTransProd, hmDetalleUnidades, false); //entrada


			boolean refrescar = false;
			//recorrer todos los detalle para actualizar los que tengan motivo no definido
			for (TransProdDetalle tpd1 : getTransProd().TransProdDetalle)
			{
				blnCantidadAlterna  = false;
				if (tpd1.TipoMotivo == 0)
				{
					// cancelar el inventario del motivo actual
					hmDetalleUnidades = new HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad>();
					hmDetalleUnidades.put(Short.parseShort(String.valueOf(tpd1.TipoUnidad)), new InventarioDobleUnidad.DetalleProductoDobleUnidad(Short.parseShort(String.valueOf(tpd1.TipoUnidad)), null,0f, null, null,null,null));
					if(tpd1.TPDDatosExtra != null && tpd1.TPDDatosExtra.size() >0 && tpd1.TPDDatosExtra.get(0).UnidadAlterna != null && tpd1.TPDDatosExtra.get(0).UnidadAlterna>0){
						blnCantidadAlterna = true;
						hmDetalleUnidades.put(tpd1.TPDDatosExtra.get(0).UnidadAlterna, new InventarioDobleUnidad.DetalleProductoDobleUnidad(tpd1.TPDDatosExtra.get(0).UnidadAlterna,null,0f, null,null,null,null ));
					}
					TransProdDetalle otpd = TransaccionesDetalle.ActualizarTipoMotivoTransaccionDobleUnidad(tpd1, tpd1.TipoMotivo, moduloMovDetalle.TipoTransProd, hmDetalleUnidades, true); //salida

					// actualizar inventario con motivo nuevo
					//Actualizar la cantidad del nuevo motivo
					hmDetalleUnidades.get(Short.parseShort(String.valueOf(tpd1.TipoUnidad))).Cantidad = tpd1.Cantidad;
					if (blnCantidadAlterna){
						hmDetalleUnidades.get(tpd1.TPDDatosExtra.get(0).UnidadAlterna).Cantidad = tpd1.TPDDatosExtra.get(0).CantidadAlterna;
					}

					otpd = TransaccionesDetalle.ActualizarTipoMotivoTransaccionDobleUnidad(tpd1, motivo, moduloMovDetalle.TipoTransProd, hmDetalleUnidades,false);
					BDVend.guardarInsertar(otpd);
					refrescar = true;
				}
			}
			if (refrescar)
				mVista.refrescarProductos(getTransaccionesIds());

			mVista.setHuboCambios(true);
			mVista.setTipoMotivo(motivo);
			return true;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
		return false;
	}

    public void guardaTipoMotivo()
    {
        if (oConHist.get("HabilitaInventario").equals("1")) {
            try
            {
                transProdGeneral.TipoMotivo = getTransProd().TransProdDetalle.get(0).TipoMotivo;;
                BDVend.guardarInsertar(transProdGeneral);
            }
            catch (Exception e)
            {
                mVista.mostrarError(e.getMessage());
            }
        }
    }

    public void actualizarMotivos(){
        if (oConHist.get("HabilitaInventario").equals("1")) {
            setGrupoTipoMotivo(String.valueOf(transProdGeneral.TipoMotivo));
            mVista.setMotivos(getGrupoTipoMotivo());
        }
    }

	public TransProdDetalle agregarProductoUnidad(Producto producto, int TipoUnidad, Float Cantidad, short TipoMotivo)
	{
		try
		{
			TransProdDetalle oTpd = null;
			oTpd = generarDetalle(producto, TipoUnidad, Cantidad, TipoMotivo);
			if (oTpd != null)
			{
				oTpd = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(oTpd, TipoMotivo,  moduloMovDetalle.TipoTransProd, oTpd.Cantidad, false, bManejarInventario); //entrada

				if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO ||
						Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA) &&
						((Cliente) Sesion.get(Campo.ClienteActual)).Prestamo &&
						((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("RecoleccionEnvase").toString().equalsIgnoreCase("1") ){
					ManejoEnvase.manejoEnvase(producto, TipoUnidad, Cantidad, oTpd, transProdGeneral);
				}

				BDVend.guardarInsertar(oTpd);
				mVista.setHuboCambios(true);
				mVista.refrescarProductos(getTransaccionesIds());
			}
			return oTpd;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
			return null;
		}
	}

	public TransProdDetalle agregarProductoDobleUnidad(Producto producto, HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidad, short TipoMotivo)
	{
		try
		{
			TransProdDetalle oTpd = null;
			oTpd = generarDetalleDobleUnidad(producto, hmDetalleUnidad, TipoMotivo);
			if (oTpd != null)
			{
				oTpd = TransaccionesDetalle.ActualizarTipoMotivoTransaccionDobleUnidad(oTpd, TipoMotivo,  moduloMovDetalle.TipoTransProd, hmDetalleUnidad, false); //entrada

				BDVend.guardarInsertar(oTpd);
				mVista.setHuboCambios(true);
				mVista.refrescarProductos(getTransaccionesIds());
			}
			return oTpd;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
			return null;
		}
	}
	public void agregarProductoUnidad(Producto producto, TransProdDetalle transProdDetalle, short tipoMotivo)
	{
		agregarProductoUnidad(producto, transProdDetalle.TipoUnidad, transProdDetalle.Cantidad, tipoMotivo);
	}

	public void eliminarDetalle(TransProdDetalle tpd)
	{
		try
		{
			//cancelar inventario del detalle
			TransProdDetalle res;
			//Actualizar la cantidad del nuevo motivo
			mVista.setHuboCambios(true);
			res = TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd, tpd.TipoMotivo, moduloMovDetalle.TipoTransProd, Float.valueOf(0), true, bManejarInventario);

			if (res == null) return;
			Consultas.ConsultasTPDImpuesto.eliminarImpuestosPorDetalle(tpd.TransProdID, tpd.TransProdDetalleID);

			if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO ||
					Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA) &&
					((Cliente) Sesion.get(Campo.ClienteActual)).Prestamo &&
					((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("RecoleccionEnvase").toString().equalsIgnoreCase("1") ){
				ManejoEnvase.manejoEnvaseEliminar(tpd.producto, tpd.TipoUnidad, tpd.Cantidad, tpd, transProdGeneral);
			}

            //validar si ya no hay detalles para eliminar del arreglo de transacciones y encabezado
            String subEmpresaId = tpd.producto.SubEmpresaId;
            transacciones.get(subEmpresaId).TransProdDetalle.remove(tpd);
            if(transacciones.get(tpd.producto.SubEmpresaId).TransProdDetalle.size() == 0){
                BDVend.eliminar(transacciones.get(subEmpresaId));
                if (transacciones.containsKey(subEmpresaId))
                    transacciones.remove(subEmpresaId);
            }

			if(((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()) && ((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()).equals("1"))
			{
				TPDDatosExtra tpdExtra = new TPDDatosExtra();
				tpdExtra.TransProdID = tpd.TransProdID;
				tpdExtra.TransProdDetalleID = tpd.TransProdDetalleID;
				BDVend.recuperar(tpdExtra);

				if(tpdExtra.isRecuperado())
				{
					LoteCaducidad lote = new LoteCaducidad();
					lote.Lote = tpdExtra.Lote;
					BDVend.recuperar(lote);
					BDVend.eliminar(tpdExtra);
					if(lote.isRecuperado())
						BDVend.eliminar(lote);

				}
			}

			//transProdGeneral.TransProdDetalle.remove(tpd);
			BDVend.eliminar(tpd);
			mVista.refrescarProductos(getTransaccionesIds());
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public void eliminarDetalleDobleUnidad(TransProdDetalle tpd)
	{
		try
		{
			mVista.setHuboCambios(true);
			//cancelar inventario del detalle
			TransProdDetalle res;
			//Actualizar la cantidad del nuevo motivo
			HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades = new HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad>();
			hmDetalleUnidades.put(Short.parseShort(String.valueOf(tpd.TipoUnidad)), new InventarioDobleUnidad.DetalleProductoDobleUnidad(Short.parseShort(String.valueOf(tpd.TipoUnidad)), null,0f, null, null,null,null));
			if(tpd.TPDDatosExtra != null && tpd.TPDDatosExtra.size() >0 && tpd.TPDDatosExtra.get(0).UnidadAlterna != null && tpd.TPDDatosExtra.get(0).UnidadAlterna>0){
				hmDetalleUnidades.put(tpd.TPDDatosExtra.get(0).UnidadAlterna, new InventarioDobleUnidad.DetalleProductoDobleUnidad(tpd.TPDDatosExtra.get(0).UnidadAlterna,null,0f, null,null,null,null ));
			}

			res = TransaccionesDetalle.ActualizarTipoMotivoTransaccionDobleUnidad(tpd, tpd.TipoMotivo, moduloMovDetalle.TipoTransProd, hmDetalleUnidades, true);

			if (res == null) return;
			Consultas.ConsultasTPDImpuesto.eliminarImpuestosPorDetalle(tpd.TransProdID, tpd.TransProdDetalleID);

			//No se maneja envase
			/*if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO ||
					Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA) &&
					((Cliente) Sesion.get(Campo.ClienteActual)).Prestamo &&
					((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("RecoleccionEnvase").toString().equalsIgnoreCase("1") ){
				ManejoEnvase.manejoEnvaseEliminar(tpd.producto, tpd.TipoUnidad, tpd.Cantidad, tpd, transProdGeneral);
			}*/

			//validar si ya no hay detalles para eliminar del arreglo de transacciones y encabezado
			String subEmpresaId = tpd.producto.SubEmpresaId;
			transacciones.get(subEmpresaId).TransProdDetalle.remove(tpd);
			if(transacciones.get(tpd.producto.SubEmpresaId).TransProdDetalle.size() == 0){
				BDVend.eliminar(transacciones.get(subEmpresaId));
				if (transacciones.containsKey(subEmpresaId))
					transacciones.remove(subEmpresaId);
			}

			//transProdGeneral.TransProdDetalle.remove(tpd);
			BDVend.eliminar(tpd);

			mVista.refrescarProductos(getTransaccionesIds());
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	private TransProdDetalle generarDetalle(Producto producto, int TipoUnidad, Float Cantidad, short TipoMotivo)
	{
		try
		{
            //separar por subempresa
            String subEmpresaId = producto.SubEmpresaId;
            StringBuilder byRefMensaje = new StringBuilder();
            transProdGeneral = Transacciones.DevolucionesCliente.ActualizarGenerarDevolucion(transacciones, subEmpresaId, moduloMovDetalle, byRefMensaje);
            if (byRefMensaje.length()>0){
                mVista.mostrarAdvertencia(byRefMensaje.toString());
            }
            byRefMensaje = null;

            //validar si se genero un nuevo encabezado para agregar al array
            if (!transacciones.containsKey(subEmpresaId)) {
                transacciones.put(subEmpresaId, transProdGeneral);
            }
            BDVend.guardarInsertar(transProdGeneral);

			TransProdDetalle transProdDetalle = TransaccionesDetalle.DevolucionesCliente.GenerarDetalleDevolucion(transProdGeneral.TransProdID, producto.ProductoClave, TipoUnidad, Cantidad, 0, transProdGeneral.CadenaListasPrecios, !(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA));
			if (transProdDetalle == null)
				throw new ControlError("MDB042302");

			transProdDetalle.producto = producto;
			transProdDetalle.recienAgregado = true;
			transProdDetalle.TipoMotivo = TipoMotivo;
			transProdGeneral.TransProdDetalle.add(transProdDetalle);

			return transProdDetalle;

		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
			return null;
		}
	}

	private TransProdDetalle generarDetalleDobleUnidad(Producto producto, HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades, short TipoMotivo)
	{
		try
		{
			//separar por subempresa
			String subEmpresaId = producto.SubEmpresaId;
			StringBuilder byRefMensaje = new StringBuilder();
			transProdGeneral = Transacciones.DevolucionesCliente.ActualizarGenerarDevolucion(transacciones, subEmpresaId, moduloMovDetalle, byRefMensaje);
			if (byRefMensaje.length()>0){
				mVista.mostrarAdvertencia(byRefMensaje.toString());
			}
			byRefMensaje = null;

			//validar si se genero un nuevo encabezado para agregar al array
			if (!transacciones.containsKey(subEmpresaId)) {
				transacciones.put(subEmpresaId, transProdGeneral);
			}
			BDVend.guardarInsertar(transProdGeneral);

			TransProdDetalle transProdDetalle = TransaccionesDetalle.DevolucionesCliente.GenerarDetalleDevolucionDobleUnidad(transProdGeneral.TransProdID, producto.ProductoClave, hmDetalleUnidades, 0, transProdGeneral.CadenaListasPrecios, !(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA));
			if (transProdDetalle == null)
				throw new ControlError("MDB042302");

			transProdDetalle.producto = producto;
			transProdDetalle.recienAgregado = true;
			transProdDetalle.TipoMotivo = TipoMotivo;
			transProdGeneral.TransProdDetalle.add(transProdDetalle);

			return transProdDetalle;

		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage() == null ? ex.getCause().getMessage() : ex.getMessage());
			return null;
		}
	}

    public HashMap<String, TransProd> getTransacciones(){
        return transacciones;
    }

    public boolean cancelarMovimiento(){
        try{
            transProdGeneral.TipoFase = 0;
            transProdGeneral.VisitaClave1 = ((Visita)Sesion.get(Campo.VisitaActual)).VisitaClave;
            transProdGeneral.DiaClave1 = ((Visita)Sesion.get(Campo.VisitaActual)).DiaClave;
            transProdGeneral.FechaCancelacion = Generales.getFechaHoraActual();
            transProdGeneral.TipoMotivo = mVista.getTipoMotivoCancelacion();
            transProdGeneral.Enviado = false;
            transProdGeneral.MFechaHora = Generales.getFechaHoraActual();
            transProdGeneral.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
            BDVend.guardarInsertar(transProdGeneral);
            return true;
        }
        catch (Exception e){
            mVista.mostrarError(e.getMessage());
            return false;
        }
    }

	public boolean eliminarMovimiento()
	{
		try
		{
			for (TransProdDetalle tpd : transProdGeneral.TransProdDetalle)
			{
                //Codigo Luis de la torre
                //Consultas.ConsultasDevolucionCliente.eliminarLoteCaducidad(transProdGeneral.TransProdID, tpd.TransProdDetalleID);
				if(((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()) && ((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()).equals("1"))
				{
					TPDDatosExtra TPDExtra = new TPDDatosExtra();
					TPDExtra.TransProdID = transProdGeneral.TransProdID;
					TPDExtra.TransProdDetalleID = tpd.TransProdDetalleID;
					BDVend.recuperar(TPDExtra);

					if(TPDExtra.isRecuperado())
					{
						LoteCaducidad lote = new LoteCaducidad();
						lote.Lote = TPDExtra.Lote;
						BDVend.recuperar(lote);
						BDVend.eliminar(TPDExtra);
						if(lote.isRecuperado())
							BDVend.eliminar(lote);
					}
				}

				//Consultas2.ConsultasReportesDEL.eliminarLoteCaducidad(lc.Lote);
				// cancelar inventario				
				if (TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd, tpd.TipoMotivo, moduloMovDetalle.TipoTransProd, Float.valueOf(0), true, bManejarInventario) == null){
					return false;
				}
				if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO ||
						Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA) &&
						((Cliente) Sesion.get(Campo.ClienteActual)).Prestamo &&
						((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("RecoleccionEnvase").toString().equalsIgnoreCase("1") ){
					ManejoEnvase.manejoEnvaseEliminar(tpd.producto, tpd.TipoUnidad, tpd.Cantidad, tpd, transProdGeneral);
				}
			}

            //Codigo Luis de la torre
            Consultas.ConsultasDevolucionCliente.obtenerTelefonoTRPVtaAcreditada(transProdGeneral.TransProdID);

			Consultas.ConsultasTPDImpuesto.eliminarImpuestos(transProdGeneral.TransProdID);
			TransaccionesDetalle.EliminarDetalle(transProdGeneral.TransProdID);
			BDVend.eliminar(transProdGeneral);
			return true;

		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
			return false;
		}
	}

	public boolean eliminarMovimientoDobleUnidad()
	{
		try
		{
			for (TransProdDetalle tpd : transProdGeneral.TransProdDetalle)
			{
				//Codigo Luis de la torre
				//Consultas.ConsultasDevolucionCliente.eliminarLoteCaducidad(transProdGeneral.TransProdID, tpd.TransProdDetalleID);
				if(((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()) && ((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()).equals("1"))
				{
					TPDDatosExtra TPDExtra = new TPDDatosExtra();
					TPDExtra.TransProdID = transProdGeneral.TransProdID;
					TPDExtra.TransProdDetalleID = tpd.TransProdDetalleID;
					BDVend.recuperar(TPDExtra);

					if(TPDExtra.isRecuperado())
					{
						LoteCaducidad lote = new LoteCaducidad();
						lote.Lote = TPDExtra.Lote;
						BDVend.recuperar(lote);
						BDVend.eliminar(TPDExtra);
						if(lote.isRecuperado())
							BDVend.eliminar(lote);
					}
				}

				// cancelar inventario
				HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades = new HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad>();
				hmDetalleUnidades.put(Short.parseShort(String.valueOf(tpd.TipoUnidad)), new InventarioDobleUnidad.DetalleProductoDobleUnidad(Short.parseShort(String.valueOf(tpd.TipoUnidad)), null,0f, null, null,null,null));
				if(tpd.TPDDatosExtra != null && tpd.TPDDatosExtra.size() >0 && tpd.TPDDatosExtra.get(0).UnidadAlterna != null && tpd.TPDDatosExtra.get(0).UnidadAlterna>0){
					hmDetalleUnidades.put(tpd.TPDDatosExtra.get(0).UnidadAlterna, new InventarioDobleUnidad.DetalleProductoDobleUnidad(tpd.TPDDatosExtra.get(0).UnidadAlterna,null,0f, null,null,null,null ));
				}
				if (TransaccionesDetalle.ActualizarTipoMotivoTransaccionDobleUnidad(tpd, tpd.TipoMotivo, moduloMovDetalle.TipoTransProd, hmDetalleUnidades, true) == null){
					return false;
				}
				//No se maneja doble Unidad
				/*if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO ||
						Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA) &&
						((Cliente) Sesion.get(Campo.ClienteActual)).Prestamo &&
						((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("RecoleccionEnvase").toString().equalsIgnoreCase("1") ){
					ManejoEnvase.manejoEnvaseEliminar(tpd.producto, tpd.TipoUnidad, tpd.Cantidad, tpd, transProdGeneral);
				}*/
			}

			//Codigo Luis de la torre
			Consultas.ConsultasDevolucionCliente.obtenerTelefonoTRPVtaAcreditada(transProdGeneral.TransProdID);

			Consultas.ConsultasTPDImpuesto.eliminarImpuestos(transProdGeneral.TransProdID);
			TransaccionesDetalle.EliminarDetalle(transProdGeneral.TransProdID);
			BDVend.eliminar(transProdGeneral);
			return true;

		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
			return false;
		}
	}

	public void imprimirTicket()
	{
		try
		{
			Recibos recibo = new Recibos();
            short numImpresiones = 0;
            try {
                if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString())) {
                    numImpresiones = Short.parseShort (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("NumImpresiones", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString()).toString());
                }
            }catch (Exception ex){
                mVista.mostrarError("Error al recuperar el parámetro NumImpresiones");
                numImpresiones = 0;
            }
			recibo.imprimirRecibos(generarDocsAImprimir(), false, mVista, numImpresiones);
		}
		catch (ControlError e)
		{
			mVista.mostrarError(e.getMessage());
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	private List<Map<String, String>> generarDocsAImprimir()
	{
		//String lstTrpTipo = ValoresReferencia.getStringVAVClave("TRPTIPO", "Visita");

		/*ISetDatos datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimir(lstTrpTipo,
				Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()),
				((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave,
				((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave,
				((Visita) Sesion.get(Campo.VisitaActual)).DiaClave,
				//transacciones.toString().replace("[", "'").replace("]", "'").replace(", ", "','"));
				"'" + transProdGeneral.TransProdID + "'");*/
		ISetDatos datos = Consultas.ConsultasTransProd.obtenerTransProdAImprimir("'" + transProdGeneral.TransProdID + "'");
		
		Cursor c = (Cursor) datos.getOriginal();

		List<Map<String, String>> tabla = new ArrayList<Map<String, String>>();
		Map<String, String> registro;
		String descValor = "";
		while (c.moveToNext())
		{
			registro = new HashMap<String, String>();
			for (int i = 0; i < c.getColumnCount(); i++)
			{
				registro.put(c.getColumnName(i), c.getString(i));
			}
			NumberFormat numberFormat = new DecimalFormat("$#,##0.00");
			registro.put("Total", numberFormat.format(c.getDouble(c.getColumnIndex("Total"))));
			descValor = ValoresReferencia.getDescripcion(c.getString(c.getColumnIndex("VARCodigo")), c.getString(c.getColumnIndex("Tipo")));
			registro.put("DescTipo", descValor);
			registro.put("TipoRecibo", obtenerTipoRecibo(registro));
			tabla.add(registro);
		}

		datos.close();

		//aTransProdIds.toString().replace("[", "'").replace("]", "'").replace(", ", "','")
		return tabla;
	}

	private String obtenerTipoRecibo(Map<String, String> registro)
	{
		String tipoRecibo = "0";

		int tipo = Integer.parseInt(registro.get("Tipo"));
		if (registro.get("TipoRecibo").equals("TRP"))
		{
			if ((tipo == 3 && !registro.get("TipoFase").equals(3)) || (tipo != 3))
			{
				switch (tipo)
				{
					case 8:
						if (registro.get("FacElec").equals(1))
						{
							return "24"; // Facturacion Electronica
						}
						else
						{
							return "8"; // Facturacion
						}
					case 24:
						if (registro.get("TipoFase").equals(6))
						{
							return "26"; //Liquidacion
						}
						else
						{
							return "25"; //Consignación
						}
					case 1:
						if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA)
						{
							return "1";
						}
						else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
						{
							return "27";
						}
						else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO)
						{
							return "28";
						}
					default:
						return registro.get("Tipo");
				}
			}
		}
		else if (registro.get("TipoRecibo").equals("ABN"))
		{
			return "10"; // Recibo de cobranza
		}
		return tipoRecibo;
	}

	public String consultarUnidadProductoExistente(String TransProdID, String ProductoClave)
	{
		String Cantidad = "0";
		String[] transProdID = TransProdID.split(",");
		try
		{
			for (int a = 0; a < transProdID.length; a++)
			{
				ISetDatos mManejo = ConsultasCantidad.OptenerCantidad(transProdID[a], ProductoClave);
				if (mManejo.getCount() != 0)
				{
					mManejo.moveToFirst();
					Cantidad = mManejo.getString(0);
				}
			}

		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return Cantidad;
	}

    public Cursor obtenerSaldoEnvase() throws Exception{
        ISetDatos saldo = Consultas.ConsultasProductoPrestamoCli.obtenerSaldoEnvase(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
        return (Cursor) saldo.getOriginal();
    }

	public void validarLimitePrestamoEnvase() throws Exception{
		if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO ||
				Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA)){
			AtomicReference<String> mensaje = new AtomicReference<>();
			ManejoEnvase.validarLimitePrestamoEnvase(mensaje, "", false );
			if(mensaje.get() != null){
				mVista.setMensajeLimiteEnvase(true);
				mVista.mostrarError(mensaje.get());
			}
		}
	}

    /*Inicio Codigo Luis de la torre*/
    public String[] obtenerDomicilio(String clienteClave)
    {
        String[] domicilios = null;
        try
        {
            ISetDatos sdDomicilio = Consultas.ConsultasDevolucionCliente.obtenerClienteDomicilioDevolucion(clienteClave);
            if(sdDomicilio != null && sdDomicilio.getCount() > 0)
            {
                domicilios = new String[sdDomicilio.getCount()];

                for (int i = 0; i < sdDomicilio.getCount(); i++)
                {
                    sdDomicilio.moveToNext();
                    //Log.d("PASA EL ARREGLO",sdDomicilio.getString("Domicilio"));
                    domicilios[i] = sdDomicilio.getString("Domicilio");
                }

                sdDomicilio.close();

            }
        }
        catch (Exception e)
        {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }

        return domicilios;
    }

    public void guardarLoteCaducidad(String TransprodDetalleID, String lote, Date caducidad)
    {

        try
        {
            //Log.e("PASA", "Modifica");
			loteCaducidad = new LoteCaducidad();
           // manejoLoteCaducidad = new ManejoLotesCaducidad();
            String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			TPDDatosExtra tpd = new TPDDatosExtra();


			TransProdDetalle TransPD = new TransProdDetalle();
			TransPD.TransProdID = transProdGeneral.TransProdID;
			TransPD.TransProdDetalleID = TransprodDetalleID;
			BDVend.recuperar(TransPD);
			loteCaducidad.ProductoClave = TransPD.ProductoClave;


			tpd.TransProdID = transProdGeneral.TransProdID;
			tpd.TransProdDetalleID = TransprodDetalleID;
			BDVend.recuperar(tpd);

			if(tpd.isRecuperado() && tpd.Lote != null)
				Consultas2.ConsultasReportesDEL.actualizarLoteCaducidad(tpd.TransProdID, tpd.TransProdDetalleID, tpd.Lote);

			if(!lote.contains(TransPD.ProductoClave))
				lote = lote + TransPD.ProductoClave;
			tpd.Lote = lote;
			tpd.MFechaHora = Generales.getFechaHoraActual();
			tpd.MUsuarioID = sUsuarioID;

			//Consultas2.ConsultasInventarioLotes.guardarTPDDatosExtra(tpd, nuevo);
			loteCaducidad.Lote = lote;
			BDVend.recuperar(loteCaducidad);
			loteCaducidad.MUsuarioID = sUsuarioID;
			loteCaducidad.MFechaHora = Generales.getFechaHoraActual();
			loteCaducidad.Caducidad = new SimpleDateFormat("yyyy-MM-dd").parse(Generales.getFormatoFecha(caducidad, "yyyy-MM-dd"));



            BDVend.guardarInsertar(loteCaducidad);
			BDVend.guardarInsertar(tpd);
			mVista.setHuboCambios(true);

        }
        catch (Exception e)
        {
            // TODO Auto-generated catch block
            mVista.mostrarError(e.getMessage());
            e.printStackTrace();
        }

    }

    public void guardarTRPVtaAcreditada(String telefono, String recoleccion){
        try
        {
            //Log.e("PASA", "Modifica");
            trpvtaAcreditada = new TRPVtaAcreditada();
            String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
            trpvtaAcreditada.TransProdID = transProdGeneral.TransProdID;
            BDVend.recuperar(trpvtaAcreditada);
            if (recoleccion.length() > 0)
                trpvtaAcreditada.Observaciones = recoleccion;
            if (telefono.length() > 0)
                trpvtaAcreditada.Observaciones2 = telefono;
            trpvtaAcreditada.MFechaHora = new Date();
            trpvtaAcreditada.MUsuarioID = sUsuarioID;
            BDVend.guardarInsertar(trpvtaAcreditada);

        }
        catch (Exception e)
        {
            // TODO: handle exception
            mVista.mostrarError(e.getMessage());
        }
    }

    public void guardarFechaRecoleccion(Date fechaRecoleccion){
        try {
            transProdGeneral.FechaEntrega = fechaRecoleccion;
            BDVend.guardarInsertar(transProdGeneral);
        }catch(Exception e){
            mVista.mostrarError(e.getMessage());
        }
    }

    public void guardarDatosRecoleccion(){
        try {
            transProdGeneral.FechaSurtido = new Date();
            transProdGeneral.VisitaClave1 = ((Visita)Sesion.get(Campo.VisitaActual)).VisitaClave;
            transProdGeneral.DiaClave1 = ((Visita)Sesion.get(Campo.VisitaActual)).DiaClave;
            transProdGeneral.Enviado = false;
            transProdGeneral.MFechaHora = Generales.getFechaHoraActual();
            transProdGeneral.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
            BDVend.guardarInsertar(transProdGeneral);
        }catch(Exception e){
            mVista.mostrarError(e.getMessage());
        }
    }

    public void guardarTelefono(String telefono)
    {
        try
        {
            //Log.e("PASA", "Modifica");
            trpvtaAcreditada = new TRPVtaAcreditada();
            String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
            trpvtaAcreditada.TransProdID = transProdGeneral.TransProdID;
            BDVend.recuperar(trpvtaAcreditada);
            trpvtaAcreditada.Observaciones2 = telefono;
            trpvtaAcreditada.MFechaHora = new Date();
            trpvtaAcreditada.MUsuarioID = sUsuarioID;
            BDVend.guardarInsertar(trpvtaAcreditada);

        }
        catch (Exception e)
        {
            // TODO: handle exception
            mVista.mostrarError(e.getMessage());
        }
    }

    public void guardarDomicilioPE(String idDomicilioPE)
    {
        try
        {
            //Log.e("PASA", "Modifica");
            transProdGeneral.ClienteDomicilioIdPE = idDomicilioPE;
            BDVend.guardarInsertar(transProdGeneral);
        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
        }
    }

    public void traerTelefono()
    {
        try
        {
            String transId = transProdGeneral.TransProdID;
            String telefono = Consultas.ConsultasDevolucionCliente.obtenerTelefonoTRPVtaAcreditada(transId);
            mVista.setTelefono(telefono);
        }
        catch (Exception e)
        {
            // TODO Auto-generated catch block
            mVista.mostrarError(e.getMessage());
        }
    }

    public void traerDomicilio()
    {
        String idDomicilio = transProdGeneral.ClienteDomicilioIdPE;
        mVista.setDireccion(idDomicilio);
    }

	public LoteCaducidad obtenerLotesCaducidad(String transProdDetalleId){
		LoteCaducidad lc = new LoteCaducidad();
		try
		{
			TPDDatosExtra tpd = new TPDDatosExtra();
			tpd.TransProdDetalleID = transProdDetalleId;
			tpd.TransProdID = transProdGeneral.TransProdID;
			BDVend.recuperar(tpd);
			if(tpd.isRecuperado()){
				//lc = new LoteCaducidad();
				lc.Lote = tpd.Lote;
				BDVend.recuperar(lc);
			}
		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
			//mVista.mostrarError(e.getMessage());
		}
		return lc;
	}

//    public ManejoLotesCaducidad traerLotesCaducidad(String transProdDetalleId)
//    {
//
//        ManejoLotesCaducidad mlc = null;
//        try
//        {
//            mlc = new ManejoLotesCaducidad();
//            mlc.TransProdID = transProdGeneral.TransProdID;
//            mlc.TransProdDetalleID = transProdDetalleId;
//            BDVend.recuperar(mlc);
//
//        }
//        catch (Exception e)
//        {
//            // TODO Auto-generated catch block
//            e.printStackTrace();
//            //mVista.mostrarError(e.getMessage());
//        }
//
//        return mlc;
//
//    }

	/*Fin Codigo Luis de la torre*/

    public void solicitarFirma()
    {
        if (Consultas2.ConsultasPerfil.validarPermisoFirma(moduloMovDetalle.TipoIndice)) {
            HashMap<String, Object> oParametros = new HashMap<String, Object>();
            oParametros.put("TransProdID", transProdGeneral.TransProdID);
            mVista.iniciarActividadConResultado(ICapturaFirma.class, Enumeradores.Solicitudes.SOLICITUD_CAPTURAR_FIRMA, Enumeradores.Acciones.ACCION_CAPTURAR_FIRMA, oParametros);
        }else{
            mVista.guardar("", "");
        }
    }


    public void setGrupoTipoMotivo(String sTipoMotivo){
        try {
            if (sTipoMotivo.equals("0"))
                sGrupoTipoMotivo = "";
            else
                sGrupoTipoMotivo = Consultas.ConsultasValorReferencia.obtenerGrupo("TRPMOT", sTipoMotivo);
        }catch(Exception e){}
    }

    public String getGrupoTipoMotivo(){
        return sGrupoTipoMotivo;
    }

    public void recolectar(){
        try {
            List<TransProdDetalle> detalles = getDetalles();
            if (detalles.size() > 0) {
                for (TransProdDetalle tpd : detalles) {
                    tpd.CantidadOriginal = tpd.Cantidad;
                    TransaccionesDetalle.ActualizarTipoMotivoTransaccion(tpd, tpd.TipoMotivo, moduloMovDetalle.TipoTransProd, tpd.getCantidad(), false, bManejarInventario);
                    tpd.Enviado = false;
                    tpd.MFechaHora = Generales.getFechaHoraActual();
                    tpd.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
                }
            }
        }catch (Exception e){}
    }

}
