package com.amesol.routelite.presentadores.act;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.concurrent.atomic.AtomicReference;

import android.util.Log;
import android.view.View;
import android.widget.LinearLayout;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Clientes;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Inventario;
import com.amesol.routelite.actividades.InventarioDobleUnidad;
import com.amesol.routelite.actividades.InventarioLotes;
import com.amesol.routelite.actividades.ManejoEnvase;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.ABNDetalle;
import com.amesol.routelite.datos.AbnTrp;
import com.amesol.routelite.datos.Abono;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.PreLiquidacion;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.Punto;
import com.amesol.routelite.datos.TPDDatosExtra;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TiposFasesDocto;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICancelaPedido;
import com.amesol.routelite.utilerias.Generales;

public class CancelarPedido extends Presentador
{

	ICancelaPedido mVista;
	String mAccion;
	short trueType;

	public CancelarPedido(ICancelaPedido vista, String accion)
	{
		mVista = vista;
		mAccion = accion;
	}

	@Override
	public void iniciar()
	{

		mVista.iniciar(); 
	}

	public int cancelarPedido(TransProd transaccion)
	{
		int validarPreliquidacion = 0;
        boolean surtirPedido = false;
		try
		{
        boolean inventarioPorLotes = false;
            try {
                inventarioPorLotes = (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("InventarioPorLotes") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("InventarioPorLotes").equals("1"));
            }catch(Exception e){}


			// TODO: falta el manejo de los pedidos agrupados con subempres
			// TODO: falta el manejo de las devoluciones automaticas de envase
			// TODO: falta el manejo correcto de las cuotas y puntos
		    CONHist conhist = (CONHist) Sesion.get(Campo.CONHist);
			ArrayList<TransProd> grupoTransacciones = new ArrayList<TransProd>();

			//obtener las transacciones del grupo en caso de estar habilitado el parametro
			if( ( (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && transaccion.TipoFase == TiposFasesDocto.SURTIDO) || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
					&& (transaccion.Tipo == TiposTransProd.PEDIDO || transaccion.Tipo == TiposTransProd.MOV_SIN_INV_EV)
					&& ((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("AgruparTransacciones").toString().equals("1")){
					//agrupar transacciones
					ArrayList<String> transacciones = Consultas.ConsultasTransProd.agruparTransacciones(transaccion.TransProdID);
					for(String transprodId : transacciones){
						TransProd oTrp = Transacciones.Pedidos.ObtenerPedido(transprodId);
						grupoTransacciones.add(oTrp);
					}
			}else{
				grupoTransacciones.add(transaccion);
			}

			//recorrer las transacciones para cancelarlas
			for(TransProd pedido : grupoTransacciones){

                //Restar los puntos obtenidos por promociones
                float nPuntos = Consultas.ConsultasTpdPun.obtenerPuntos(pedido.TransProdID);
                if (nPuntos > 0) {
                    Punto oPunto = new Punto();
                    oPunto.ClienteClave = ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave;
                    BDVend.recuperar(oPunto);
                    if (oPunto.isRecuperado()){
                        oPunto.Otorgados -= nPuntos;
                        oPunto.MFechaHora = Generales.getFechaHoraActual();
                        oPunto.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
                        oPunto.Enviado = false;
                        BDVend.guardarInsertar(oPunto);
                    }
                }

				if( ( (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && pedido.TipoFase == TiposFasesDocto.SURTIDO) || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA)
						&& pedido.Tipo == TiposTransProd.PEDIDO && pedido.DevolucionID != null && pedido.DevolucionID != ""){
					//cuadre de envase y Recolección automatica en Venta
					Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);
					String devId = "";
					if( (oCliente.Prestamo && ((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("CuadreDeEnvase").toString().equals("1")) || ((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("RecAutoEnvVenta").toString().equals("1")){
						boolean noHayExistencia = false;
						TransProd oTrp = pedido;
						//if(oTrp.DevolucionID != null && oTrp.DevolucionID != ""){
							Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
							TransProd dev = Transacciones.Pedidos.ObtenerPedido(oTrp.DevolucionID);
							BDVend.recuperar(dev,TransProdDetalle.class);
							String grupoMotivo = null;
							for(TransProdDetalle tpd : dev.getTransProdDetalle()){
								AtomicReference<Float> existencia = new AtomicReference<>();
								StringBuilder error = new StringBuilder();
								for(ValorReferencia v : ValoresReferencia.getValores("TRPMOT", "Recolección")){
									if(dev.TipoMotivo == Short.parseShort(v.getVavclave())){
										grupoMotivo = "Venta";
									}
								}
								if(grupoMotivo == null)
									grupoMotivo = "No Venta";

                                boolean ok = Inventario.ValidarExistencia(tpd.getProductoClave(),tpd.TipoUnidad,tpd.Cantidad,dev.Tipo,grupoMotivo,existencia,error);

								if(!ok){
									noHayExistencia = true;
								}else{
									Producto prod = new Producto();
									prod.ProductoClave = tpd.ProductoClave;
									BDVend.recuperar(prod);
									tpd.producto = prod;
								}
							}

							if(!noHayExistencia){
								for(TransProdDetalle tpd : dev.getTransProdDetalle()){
                                    Inventario.ActualizarInventario(tpd.ProductoClave, tpd.TipoUnidad, tpd.Cantidad, dev.Tipo, dev.TipoMovimiento, vendedor.AlmacenID, grupoMotivo, true);
                                    if (oCliente.Prestamo)
									    ManejoEnvase.manejoEnvaseEliminar(tpd.producto, tpd.TipoUnidad, tpd.Cantidad, tpd, dev);
								}
								TransaccionesDetalle.EliminarDetalle(dev.TransProdID);
								oTrp.DevolucionID = null;
								Transacciones.EliminarTransaccion(dev.TransProdID);
							}else{
								return 0;
							}
						//}
					}
				}

				//Dar reversa al inventario
                //TODO: Falta el manejo de envase en inventario

                if (pedido.Tipo != Enumeradores.TiposTransProd.MOV_SIN_INV_EV && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.REPARTO )
                {
                    BDVend.recuperar(pedido, TransProdDetalle.class);
                    Iterator<TransProdDetalle> it = pedido.TransProdDetalle.iterator();
                    while (it.hasNext())
                    {
                        TransProdDetalle oTpd = it.next();
                        if (inventarioPorLotes){
                            BDVend.recuperar(oTpd,TPDDatosExtra.class);
                            InventarioLotes.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.TPDDatosExtra.get(0).Lote, oTpd.Cantidad, pedido.Tipo, pedido.TipoMovimiento, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID, true);
                        }else {
                            Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, pedido.Tipo, pedido.TipoMovimiento, ((Vendedor) Sesion.get(Campo.VendedorActual)).AlmacenID, true);
                        }

                        Cliente cli = ((Cliente)Sesion.get(Campo.ClienteActual));
                        if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) && cli.Prestamo && pedido.Tipo == TiposTransProd.PEDIDO){
                            Producto producto = new Producto();
                            producto.ProductoClave = oTpd.ProductoClave;
                            BDVend.recuperar(producto);
                            ManejoEnvase.manejoEnvaseEliminar(producto, oTpd.TipoUnidad, oTpd.Cantidad, oTpd, pedido);
                        }
                    }

                }else if(pedido.Tipo != Enumeradores.TiposTransProd.MOV_SIN_INV_EV && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
                    /*if (conhist.get("Preliquidacion").equals("1")){
                        PreLiquidacion Pli = new PreLiquidacion();
                        Pli.PLIId = pedido.PLIId;
                        BDVend.recuperar(Pli);

                        if(Pli.isRecuperado()){
                            if(pedido.Total > Pli.MontoTotal){
                                mVista.mostrarError(Mensajes.get("E0590"));
                                return;
                            }else{
                                Pli.MontoTotal -= pedido.Total;

                                if(Pli.MontoTotal == 0){
                                    //TODO: validar relacion con movimientos y/o depositos y eliminar fisicamente
                                    pedido.PLIId = "";
                                    BDVend.eliminar(Pli);
                                }else
                                    BDVend.guardarInsertar(Pli);
                            }
                        }
                    }*/

                    Consultas.ConsultasTPDDesVendedor.eliminarPorTransProd(pedido.TransProdID);

                    //if(!pedido.VisitaClave1.equals(((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave) && !pedido.DiaClave1.equals(((Dia) Sesion.get(Campo.DiaActual)).DiaClave)){
                    if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && (pedido.TipoFase == TiposFasesDocto.CAPTURA || pedido.TipoFase == TiposFasesDocto.CAPTURA_ESCRITORIO)){
                            //pedido subido para repartir
                            //actualizar inventario, restar apartado y pedido
                            surtirPedido = true;
                            BDVend.recuperar(pedido, TransProdDetalle.class);
                            Iterator<TransProdDetalle> it = pedido.TransProdDetalle.iterator();
                            while (it.hasNext())
                            {
                                TransProdDetalle oTpd = it.next();
                                //Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, pedido.Tipo, TiposMovimientos.NO_DEFINIDO, ((Vendedor)Sesion.get(Campo.VendedorActual)).AlmacenID, true);
                                Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, pedido.Tipo, TiposMovimientos.ENTRADA, ((Vendedor)Sesion.get(Campo.VendedorActual)).AlmacenID, true);
                            } Log.i(null, "Pasa 5");
                    }else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && pedido.TipoFase == TiposFasesDocto.SURTIDO){
                        //pedido creado en visita
                        //actualizar inventario, entrada
                        BDVend.recuperar(pedido, TransProdDetalle.class);
                        Iterator<TransProdDetalle> it = pedido.TransProdDetalle.iterator();
                        while (it.hasNext())
                        {
                            TransProdDetalle oTpd = it.next();
                            if (oTpd.PrestamoVendido == null)
                                oTpd.PrestamoVendido = (float)0;
                            Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, pedido.Tipo, TiposMovimientos.ENTRADA, ((Vendedor)Sesion.get(Campo.VendedorActual)).AlmacenID, true, pedido.TipoFase, oTpd.PrestamoVendido);

                            Cliente cli = ((Cliente)Sesion.get(Campo.ClienteActual));
                            if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO) && cli.Prestamo && pedido.Tipo == TiposTransProd.PEDIDO){
                                Producto producto = new Producto();
                                producto.ProductoClave = oTpd.ProductoClave;
                                BDVend.recuperar(producto);
                                ManejoEnvase.manejoEnvaseEliminar(producto, oTpd.TipoUnidad, oTpd.Cantidad, oTpd, pedido);
                            }
                        }
                    }
                }else if(pedido.Tipo == TiposTransProd.MOV_SIN_INV_EV){
                    Consultas.ConsultasTPDDesVendedor.eliminarPorTransProd(pedido.TransProdID);
                    if(pedido.VisitaClave == ((Visita)Sesion.get(Campo.VisitaActual)).VisitaClave){
                        //TODO: CUOTAS AL CANCELAR MSIEV
                        //Cuotas.RestarCuotasXProducto(oTransProd)
                        //Cuotas.CalcularCuotasxEfectivo(oTransProd, True)
                    }
                }

                // forma venta contado, forma pago efectivo, cobranza sobre ventas y
                // pago automatico
                if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 2)
                    trueType = Consultas.ConsultasTransProd.getTipoFiscalCliente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
                else
                    trueType = (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza"));

                if (pedido.Tipo == Enumeradores.TiposTransProd.PEDIDO && (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && pedido.TipoFase == TiposFasesDocto.SURTIDO && pedido.VisitaClave == ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave))){
                    if (!EliminarPagoAutomatico(pedido)){
                        validarPreliquidacion = 2;
                        BDVend.rollback();
                    }
                }

                //Si es venta directa en reparto
                if (pedido.Tipo == Enumeradores.TiposTransProd.PEDIDO && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && pedido.TipoFase == TiposFasesDocto.SURTIDO && pedido.DiaClave1 == null){
                    if (!EliminarPagoAutomatico(pedido)){
                        validarPreliquidacion = 2;
                        BDVend.rollback();
                    }
                }

                if (validarPreliquidacion == 0) {

                    if (trueType == 1 && pedido.TipoFase != TiposFasesDocto.CAPTURA && pedido.TipoFase != TiposFasesDocto.CAPTURA_ESCRITORIO) {
                        // restar el total al saldo del cliente
                        Transacciones.Pedidos.ActualizarSaldoCliente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave, pedido.Total * -1);
                        ((Cliente) Sesion.get(Campo.ClienteActual)).SaldoEfectivo = Consultas.ConsultasCliente.obtenerSaldoEfectivo(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
                    }

                    if (pedido.TipoMovimiento == Enumeradores.TiposTransProd.MOV_SIN_INV_EV) { // y asignacion de puntos (3)
                        // TODO: administrar puntos
                        // calcular puntos
                        // eliminar tpddesvendedor
                        // Consultas.ConsultasTPDDesVendedor.eliminarPorTransProd(pedido.TransProdID);
                    }

                    if (pedido.Tipo != Enumeradores.TiposTransProd.MOV_SIN_INV_EV && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && pedido.TipoFase == 1) {
                        //solo se marcan los pedidos que se suben para reparto, las ventas no se marcan
                        pedido.DiaClave1 = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
                        pedido.VisitaClave1 = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave;
                    }


                    pedido.TipoFase = 0;
                    pedido.TipoMotivo = mVista.getTipoMotivo();
                    pedido.FechaCancelacion = Generales.getFechaHoraActual();
                    pedido.MFechaHora = Generales.getFechaHoraActual();
                    pedido.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
                    pedido.Enviado = false;
                    //BDVend.guardarInsertar(pedido);

                    //Eliminar preloquidacion ldelatorre
                    //int preLiquidacion = Consultas.ConsultasValidacionPreliquidacion.getCONHist();

                    String idTransProd = pedido.TransProdID;

                    int tipoModulo = Integer.parseInt((Sesion.get(Campo.TipoModulo).toString()));
                    int tipoIndice = Consultas.ConsultasValidacionPreliquidacion.getModuloMovDetalleTipoIndice((String) Sesion.get(Campo.ModuloMovDetalleClave));
                    int CFVTipo = Consultas.ConsultasValidacionPreliquidacion.getTransProdCFVTipo(idTransProd);
                    int clientePagoID = Consultas.ConsultasValidacionPreliquidacion.getTransProdClientePago(idTransProd);
                    int preLiquidacion = (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("Preliquidacion"));

                    boolean tieneAbonos = Consultas.ConsultasValidacionPreliquidacion.validarTieneAbonos(idTransProd);

                    if (preLiquidacion == 1) {// tiene que estar activado la opcion de PreLiquidacion
                        if (!tieneAbonos) {
                            validarPreliquidacion = 1;
                            BDVend.guardarInsertar(pedido);
                            BDVend.commit();
                        } else {
                            if ((Enumeradores.TiposModulos.VENTA == tipoModulo || Enumeradores.TiposModulos.REPARTO == tipoModulo) && Enumeradores.TiposModuloMovDetalle.PEDIDO == tipoIndice) {
                                if (Enumeradores.FormasDeVenta.CONTADO == CFVTipo && Enumeradores.FormasDePago.EFECTIVO == clientePagoID) {
                                    if (Consultas.ConsultasValidacionPreliquidacion.validarTotal(idTransProd)) {
                                        validarPreliquidacion = 1;

                                        pedido.PLIId = Consultas.ConsultasValidacionPreliquidacion.obtienePliId();
                                        BDVend.guardarInsertar(pedido);
                                        BDVend.commit();
                                    } else {
                                        validarPreliquidacion = 2;

                                        mVista.mostrarError(Mensajes.get("E0590"));
                                        BDVend.rollback();
                                    }
                                } else {
                                    validarPreliquidacion = 1;

                                    pedido.PLIId = Consultas.ConsultasValidacionPreliquidacion.obtienePliId();
                                    BDVend.guardarInsertar(pedido);
                                    BDVend.commit();
                                }
                            } else {
                                validarPreliquidacion = 1;

                                pedido.PLIId = Consultas.ConsultasValidacionPreliquidacion.obtienePliId();
                                BDVend.guardarInsertar(pedido);
                                BDVend.commit();
                            }
                        }
                    } else {
                        validarPreliquidacion = 3;

                        pedido.PLIId = Consultas.ConsultasValidacionPreliquidacion.obtienePliId();
                        BDVend.guardarInsertar(pedido);
                        BDVend.commit();
                    }
                }

			} //fin transacciones
			
			//return validarPreliquidacion;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
		return validarPreliquidacion;
	}

	public int cancelarPedidoDobleUnidad(TransProd transaccion)
	{
		int validarPreliquidacion = 0;
		try
		{

			// TODO: falta el manejo de los pedidos agrupados con subempres
			// TODO: falta el manejo de las devoluciones automaticas de envase
			// TODO: falta el manejo correcto de las cuotas y puntos
			CONHist conhist = (CONHist) Sesion.get(Campo.CONHist);
			ArrayList<TransProd> grupoTransacciones = new ArrayList<TransProd>();

			//obtener las transacciones del grupo en caso de estar habilitado el parametro
			if( ( (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && transaccion.TipoFase == TiposFasesDocto.SURTIDO) || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
					&& (transaccion.Tipo == TiposTransProd.PEDIDO || transaccion.Tipo == TiposTransProd.MOV_SIN_INV_EV)
					&& ((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("AgruparTransacciones").toString().equals("1")){
				//agrupar transacciones
				ArrayList<String> transacciones = Consultas.ConsultasTransProd.agruparTransacciones(transaccion.TransProdID);
				for(String transprodId : transacciones){
					TransProd oTrp = Transacciones.Pedidos.ObtenerPedido(transprodId);
					grupoTransacciones.add(oTrp);
				}
			}else{
				grupoTransacciones.add(transaccion);
			}

			//recorrer las transacciones para cancelarlas
			for(TransProd pedido : grupoTransacciones){
				//No se implementa prestamo de envase, se quita el if

				//Dar reversa al inventario

				if (pedido.Tipo != Enumeradores.TiposTransProd.MOV_SIN_INV_EV && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.REPARTO )
				{
					BDVend.recuperar(pedido, TransProdDetalle.class);
					Iterator<TransProdDetalle> it = pedido.TransProdDetalle.iterator();
					while (it.hasNext())
					{
						TransProdDetalle oTpd = it.next();
						BDVend.recuperar(oTpd, TPDDatosExtra.class);
						HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades = new HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad>();
						hmDetalleUnidades.put(Short.parseShort(String.valueOf(oTpd.TipoUnidad)), new InventarioDobleUnidad.DetalleProductoDobleUnidad(Short.parseShort(String.valueOf(oTpd.TipoUnidad)), null,oTpd.Cantidad, null, null,null,null));
						if(oTpd.TPDDatosExtra.size() >0 && oTpd.TPDDatosExtra.get(0).UnidadAlterna != null && oTpd.TPDDatosExtra.get(0).UnidadAlterna>0){
							hmDetalleUnidades.put(oTpd.TPDDatosExtra.get(0).UnidadAlterna, new InventarioDobleUnidad.DetalleProductoDobleUnidad(oTpd.TPDDatosExtra.get(0).UnidadAlterna,null,oTpd.TPDDatosExtra.get(0).CantidadAlterna, null,null,null,null ));
						}

						InventarioDobleUnidad.ActualizarInventario(oTpd.ProductoClave,hmDetalleUnidades, pedido.Tipo, pedido.TipoMovimiento,  true);

						//No hay manejo de envase en doble unidad
					}

				}else if(pedido.Tipo != Enumeradores.TiposTransProd.MOV_SIN_INV_EV && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){

					Consultas.ConsultasTPDDesVendedor.eliminarPorTransProd(pedido.TransProdID);

					//if(!pedido.VisitaClave1.equals(((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave) && !pedido.DiaClave1.equals(((Dia) Sesion.get(Campo.DiaActual)).DiaClave)){
					if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && (pedido.TipoFase == TiposFasesDocto.CAPTURA || pedido.TipoFase == TiposFasesDocto.CAPTURA_ESCRITORIO)){
						//pedido subido para repartir
						//actualizar inventario, restar apartado y pedido
						BDVend.recuperar(pedido, TransProdDetalle.class);
						Iterator<TransProdDetalle> it = pedido.TransProdDetalle.iterator();
						while (it.hasNext())
						{
							TransProdDetalle oTpd = it.next();
							BDVend.recuperar(oTpd, TPDDatosExtra.class);
							HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades = new HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad>();
							hmDetalleUnidades.put(Short.parseShort(String.valueOf(oTpd.TipoUnidad)), new InventarioDobleUnidad.DetalleProductoDobleUnidad(Short.parseShort(String.valueOf(oTpd.TipoUnidad)), null,oTpd.Cantidad, null, null,null,null));
							if(oTpd.TPDDatosExtra.size() >0 && oTpd.TPDDatosExtra.get(0).UnidadAlterna != null && oTpd.TPDDatosExtra.get(0).UnidadAlterna>0){
								hmDetalleUnidades.put(oTpd.TPDDatosExtra.get(0).UnidadAlterna, new InventarioDobleUnidad.DetalleProductoDobleUnidad(oTpd.TPDDatosExtra.get(0).UnidadAlterna,null,oTpd.TPDDatosExtra.get(0).CantidadAlterna, null,null,null,null ));
							}
							InventarioDobleUnidad.ActualizarInventario(oTpd.ProductoClave, hmDetalleUnidades, pedido.Tipo, TiposMovimientos.ENTRADA, true);
						} Log.i(null, "Pasa 5");
					}else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && pedido.TipoFase == TiposFasesDocto.SURTIDO){
						//pedido creado en visita
						//actualizar inventario, entrada
						BDVend.recuperar(pedido, TransProdDetalle.class);

						Iterator<TransProdDetalle> it = pedido.TransProdDetalle.iterator();
						while (it.hasNext())
						{
							TransProdDetalle oTpd = it.next();
							BDVend.recuperar(oTpd, TPDDatosExtra.class);
							HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades = new HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad>();
							hmDetalleUnidades.put(Short.parseShort(String.valueOf(oTpd.TipoUnidad)), new InventarioDobleUnidad.DetalleProductoDobleUnidad(Short.parseShort(String.valueOf(oTpd.TipoUnidad)), null,oTpd.Cantidad, null, null,null,null));
							if(oTpd.TPDDatosExtra.size() >0 && oTpd.TPDDatosExtra.get(0).UnidadAlterna != null && oTpd.TPDDatosExtra.get(0).UnidadAlterna>0){
								hmDetalleUnidades.put(oTpd.TPDDatosExtra.get(0).UnidadAlterna, new InventarioDobleUnidad.DetalleProductoDobleUnidad(oTpd.TPDDatosExtra.get(0).UnidadAlterna,null,oTpd.TPDDatosExtra.get(0).CantidadAlterna, null,null,null,null ));
							}
							InventarioDobleUnidad.ActualizarInventario(oTpd.ProductoClave, hmDetalleUnidades , pedido.Tipo, TiposMovimientos.ENTRADA,true, pedido.TipoFase);

							//No se maneja envase
						}
					}
				}else if(pedido.Tipo == TiposTransProd.MOV_SIN_INV_EV){
					Consultas.ConsultasTPDDesVendedor.eliminarPorTransProd(pedido.TransProdID);
					if(pedido.VisitaClave == ((Visita)Sesion.get(Campo.VisitaActual)).VisitaClave){
						//TODO: CUOTAS AL CANCELAR MSIEV
						//Cuotas.RestarCuotasXProducto(oTransProd)
						//Cuotas.CalcularCuotasxEfectivo(oTransProd, True)
					}
				}

				// forma venta contado, forma pago efectivo, cobranza sobre ventas y
				// pago automatico
				if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 2)
					trueType = Consultas.ConsultasTransProd.getTipoFiscalCliente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
				else
					trueType = (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza"));

				if (pedido.Tipo == Enumeradores.TiposTransProd.PEDIDO && (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && pedido.TipoFase == TiposFasesDocto.SURTIDO && pedido.VisitaClave == ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave))){
                    if (!EliminarPagoAutomatico(pedido)){
                        validarPreliquidacion = 2;
                        BDVend.rollback();
                    }
				}

				//Si es venta directa en reparto
				if (pedido.Tipo == Enumeradores.TiposTransProd.PEDIDO && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && pedido.TipoFase == TiposFasesDocto.SURTIDO && pedido.DiaClave1 == null){
                    if (!EliminarPagoAutomatico(pedido)){
                        validarPreliquidacion = 2;
                        BDVend.rollback();
                    }
				}

                if (validarPreliquidacion == 0) {

                    if (trueType == 1 && pedido.TipoFase != TiposFasesDocto.CAPTURA && pedido.TipoFase != TiposFasesDocto.CAPTURA_ESCRITORIO) {
                        // restar el total al saldo del cliente
                        Transacciones.Pedidos.ActualizarSaldoCliente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave, pedido.Total * -1);
                        ((Cliente) Sesion.get(Campo.ClienteActual)).SaldoEfectivo = Consultas.ConsultasCliente.obtenerSaldoEfectivo(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
                    }

                    if (pedido.TipoMovimiento == Enumeradores.TiposTransProd.MOV_SIN_INV_EV) { // y asignacion de puntos (3)
                        // TODO: administrar puntos
                        // calcular puntos
                        // eliminar tpddesvendedor
                        // Consultas.ConsultasTPDDesVendedor.eliminarPorTransProd(pedido.TransProdID);
                    }

                    if (pedido.Tipo != Enumeradores.TiposTransProd.MOV_SIN_INV_EV && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && pedido.TipoFase == 1) {
                        //solo se marcan los pedidos que se suben para reparto, las ventas no se marcan
                        pedido.DiaClave1 = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
                        pedido.VisitaClave1 = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave;
                    }


                    pedido.TipoFase = 0;
                    pedido.TipoMotivo = mVista.getTipoMotivo();
                    pedido.FechaCancelacion = Generales.getFechaHoraActual();
                    pedido.MFechaHora = Generales.getFechaHoraActual();
                    pedido.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
                    pedido.Enviado = false;
                    BDVend.guardarInsertar(pedido);

                    //Eliminar preloquidacion ldelatorre
                    //int preLiquidacion = Consultas.ConsultasValidacionPreliquidacion.getCONHist();

                    String idTransProd = pedido.TransProdID;


                    int tipoModulo = Integer.parseInt((Sesion.get(Campo.TipoModulo).toString()));
                    int tipoIndice = Consultas.ConsultasValidacionPreliquidacion.getModuloMovDetalleTipoIndice((String) Sesion.get(Campo.ModuloMovDetalleClave));
                    int CFVTipo = Consultas.ConsultasValidacionPreliquidacion.getTransProdCFVTipo(idTransProd);
                    int clientePagoID = Consultas.ConsultasValidacionPreliquidacion.getTransProdClientePago(idTransProd);
                    int preLiquidacion = (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("Preliquidacion"));

                    boolean tieneAbonos = Consultas.ConsultasValidacionPreliquidacion.validarTieneAbonos(idTransProd);

                    //	Log.i(null, "Pre: " + preLiquidacion + " Modulo: " + tipoModulo + " Tipo Indice: " + tipoIndice + " CFVTipo: " + CFVTipo + " ClientePagoID: " + clientePagoID);

                    if (preLiquidacion == 1)// tiene que estar activado la opcion de PreLiquidacion
                    {
                        if (!tieneAbonos) {
                            validarPreliquidacion = 1;
                            BDVend.commit();
                        } else {
                            if ((Enumeradores.TiposModulos.VENTA == tipoModulo || Enumeradores.TiposModulos.REPARTO == tipoModulo) && Enumeradores.TiposModuloMovDetalle.PEDIDO == tipoIndice) {
                                if (Enumeradores.FormasDeVenta.CONTADO == CFVTipo && Enumeradores.FormasDePago.EFECTIVO == clientePagoID) {
                                    if (Consultas.ConsultasValidacionPreliquidacion.validarTotal(idTransProd)) {

                                        //Log.i(null, "Es mayor");
                                        validarPreliquidacion = 1;
                                        BDVend.commit();

                                    } else {
                                        //mVista.mostrarError(Mensajes.get("E0590"));
                                        //Log.i(null, Mensajes.get("E0590"));
                                        validarPreliquidacion = 2;
                                        mVista.mostrarError(Mensajes.get("E0590"));
                                        BDVend.rollback();
                                    }
                                } else {
                                    validarPreliquidacion = 1;
                                    BDVend.commit();
                                }
                            } else {
                                validarPreliquidacion = 1;
                                BDVend.commit();
                            }
                        }
                    } else {
                        BDVend.commit();
                        validarPreliquidacion = 3;
                    }
                }

			} //fin transacciones

			//return validarPreliquidacion;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
		return validarPreliquidacion;
	}

	private boolean EliminarPagoAutomatico(TransProd oTransProd) throws Exception{
		if(oTransProd.CFVTipo == Enumeradores.FormasDeVenta.CONTADO && Integer.parseInt(oTransProd.ClientePagoId) == Enumeradores.FormasDePago.EFECTIVO){
			if ((short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza")) == 2)
				trueType = Consultas.ConsultasTransProd.getTipoFiscalCliente(((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave);
			else
				trueType = (short) Integer.parseInt((String) ((CONHist) Sesion.get(Campo.CONHist)).get("TipoCobranza"));

			if (trueType == 1 && ((CONHist) Sesion.get(Campo.CONHist)).get("PagoAutomatico").equals("1"))
			{
				ISetDatos abonos = Consultas.ConsultasAbnTrp.obtenerAbonos(oTransProd.TransProdID);
				if (abonos.getCount() > 0){
					abonos.moveToFirst(); 
					Abono oAbn = new Abono();
					oAbn.ABNId = abonos.getString("ABNId");
					BDVend.recuperar(oAbn);
					BDVend.recuperar(oAbn, ABNDetalle.class);
					BDVend.recuperar(oAbn, AbnTrp.class);
					
					Cobranza.generarHistorico(oAbn);
					
					Iterator<ABNDetalle> itABD = oAbn.ABNDetalle.iterator();
					while (itABD.hasNext())
					{
						BDVend.eliminar(itABD.next());
					}

					Iterator<AbnTrp> itABT = oAbn.AbnTrp.iterator();
					while (itABT.hasNext())
					{
						BDVend.eliminar(itABT.next());
					}

					BDVend.eliminar(oAbn);	
					Clientes.actualizarSaldoCteActual((oTransProd.Total));
				}
				abonos.close();

                if (((CONHist) Sesion.get(Campo.CONHist)).get("Preliquidacion").equals("1"))
                    return actualizarPreliquidacion(oTransProd);
			}
		}

        return true;
	}

    private boolean actualizarPreliquidacion(TransProd pedido) throws Exception {

        if (pedido.PLIId != null) {
            PreLiquidacion pli = new PreLiquidacion();
            pli.PLIId = pedido.PLIId;
            BDVend.recuperar(pli);

            if (pli.isRecuperado()) {
                if (pedido.Total > pli.MontoTotal) {
                    return false;
                } else {
                    pli.MontoTotal -= pedido.Total;
                    if (pli.MontoTotal == 0) {
                        pedido.PLIId = null;
                        BDVend.eliminar(pli);
                    } else {
                        pedido.PLIId = null;
                        BDVend.guardarInsertar(pli);
                    }
                }
            }
        }

        return true;
    }
}