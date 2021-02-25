package com.amesol.routelite.actividades;

import android.annotation.SuppressLint;
import android.app.SearchManager;
import android.net.ParseException;

import com.amesol.routelite.datos.ABNDetalle;
import com.amesol.routelite.datos.AbdDep;
import com.amesol.routelite.datos.CamionVendedor;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Descuento;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Impuesto;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.PLBPLE;
import com.amesol.routelite.datos.Precio;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.SaldoDeposito;
import com.amesol.routelite.datos.Solicitud;
import com.amesol.routelite.datos.TPDDatosExtra;
import com.amesol.routelite.datos.TPDDesProntoPago;
import com.amesol.routelite.datos.TPDDesVendedor;
import com.amesol.routelite.datos.TPDImpuesto;
import com.amesol.routelite.datos.TRPDescCalculadora;
import com.amesol.routelite.datos.TpdDes;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.TrpPrp;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.*;
import com.amesol.routelite.presentadores.Enumeradores.TipoPedido;
import com.amesol.routelite.presentadores.Enumeradores.TiposFasesDocto;
import com.amesol.routelite.presentadores.Enumeradores.TiposModulos;
import com.amesol.routelite.presentadores.Enumeradores.TiposMovimientos;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.ListIterator;
import java.util.concurrent.atomic.AtomicReference;

public class Transacciones
{

	public static TransProd generarTransaccion(com.amesol.routelite.datos.ModuloMovDetalle moduloMovDetalle, final StringBuilder byRefMensaje) throws ControlError, Exception
	{

		String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
		String sClienteClave = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave;
		String sDiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
		String sVisitaClave = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave;

		TransProd transProd = new TransProd();

		transProd.TransProdID = KeyGen.getId();
		transProd.VisitaClave = sVisitaClave;
		transProd.DiaClave = sDiaClave;
		transProd.ClienteClave = sClienteClave; 

		HashMap<Integer,Precio> listasPrecios= ListaPrecio.Determinar(sClienteClave, moduloMovDetalle);
		transProd.setListaPrecios(listasPrecios);
		transProd.PCEPrecioClave = listasPrecios.get(0).PrecioClave ;

		transProd.PCEModuloMovDetClave = moduloMovDetalle.ModuloMovDetalleClave;

		transProd.Folio = Folios.Obtener(moduloMovDetalle.ModuloMovDetalleClave, byRefMensaje);

		transProd.Tipo = moduloMovDetalle.TipoTransProd; //moduloMovDetalle.TipoMovimiento;
		transProd.TipoPedido = moduloMovDetalle.TipoPedido;
		transProd.TipoMovimiento = moduloMovDetalle.TipoMovimiento;
		transProd.TipoFase = 1;
		transProd.FechaHoraAlta = Generales.getFechaHoraActual();
		transProd.FechaCaptura = Generales.getFechaActual();
		transProd.Total = 0;
		/*
		 * transProd.FechaEntrega = I0257 transProd.FechaFacturacion =
		 * transProd.FechaSurtido = transProd.FechaCancelacion =
		 */
		transProd.MFechaHora = Generales.getFechaHoraActual();
		transProd.MUsuarioID = sUsuarioID;

		return transProd;

	}

    public static TransProd generarTransaccionSinPrecio(com.amesol.routelite.datos.ModuloMovDetalle moduloMovDetalle, final StringBuilder byRefMensaje) throws ControlError, Exception
    {

        String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
        String sClienteClave = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave;
        String sDiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
        String sVisitaClave = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave;

        TransProd transProd = new TransProd();

        transProd.TransProdID = KeyGen.getId();
        transProd.VisitaClave = sVisitaClave;
        transProd.DiaClave = sDiaClave;
        transProd.ClienteClave = sClienteClave;

        transProd.PCEModuloMovDetClave = moduloMovDetalle.ModuloMovDetalleClave;
        transProd.Folio = Folios.Obtener(moduloMovDetalle.ModuloMovDetalleClave, byRefMensaje);

        transProd.Tipo = moduloMovDetalle.TipoTransProd; //moduloMovDetalle.TipoMovimiento;
        transProd.TipoPedido = moduloMovDetalle.TipoPedido;
        transProd.TipoMovimiento = moduloMovDetalle.TipoMovimiento;
        transProd.TipoFase = 1;
        transProd.FechaHoraAlta = Generales.getFechaHoraActual();
        transProd.FechaCaptura = Generales.getFechaActual();
        transProd.Total = 0;
		/*
		 * transProd.FechaEntrega = I0257 transProd.FechaFacturacion =
		 * transProd.FechaSurtido = transProd.FechaCancelacion =
		 */
        transProd.MFechaHora = Generales.getFechaHoraActual();
        transProd.MUsuarioID = sUsuarioID;

        return transProd;

    }

	public static TransProd obtenerTransaccion(String TransProdId) throws Exception
	{
		TransProd transprod = new TransProd();
		transprod.TransProdID = TransProdId;
		BDVend.recuperar(transprod);
		return transprod;
	}

	public static void calcularTotalesTransaccion(TransProd oTransProd) throws Exception
	{
			//TransProd oTrp = ObtenerPedido(TransProdId);
			ISetDatos totales = Consultas.ConsultasTransProdDetalle.obtenerTotalesDetalle(oTransProd.TransProdID);
			while (totales.moveToNext()) {
				oTransProd.Subtotal = totales.getFloat("SubTDetalle");
				oTransProd.Impuesto = totales.getFloat("Impuesto");
				oTransProd.Total = totales.getFloat("Total");
			}
			totales.close();
	}

	public static void EliminarTransaccion(String TransProdId) throws Exception
	{
		TransProd oTRP = obtenerTransaccion(TransProdId);
		BDVend.eliminar(oTRP);
	}

	public static boolean verificarRecoleccionAutomaticaEnvase() throws Exception
	{
		if (((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("RecAutoEnvVenta").equals("1")) {
			ISetDatos datos = Consultas.ConsultasTransProd.obtenerPedidosConDevolucionEnvasePendiente();
			if (datos != null) {
				BDVend.setOrigenLog("Se encontraron documentos sin recoleccion");
				while (datos.moveToNext()) {
					TransProd oTrp = new TransProd();
					oTrp.TransProdID = datos.getString(0);
					BDVend.recuperar(oTrp);
					recolectarEnvasesAutomaticamente(oTrp, Consultas.ConsultasTransProd.obtenerEnvaseRecAutomatica(oTrp.TransProdID),true);
					//Grabar el DevolucionID
					BDVend.guardarInsertar(oTrp);
				}
			}
			datos.close();
			BDVend.commit();
			datos = Consultas.ConsultasTransProd.obtenerPedidosConDevolucionEnvasePendiente();
			if (datos != null && datos.getCount()>0) {
				return false;
			}
		}
		return true;
	}

	public static void recolectarEnvasesAutomaticamente(TransProd oTransProd, ISetDatos productos , Boolean recuperarVisitaPedido) throws Exception{
		String folio = null;
		if (productos == null)
			productos = Consultas.ConsultasTransProd.obtenerEnvaseRecAutomatica(oTransProd.TransProdID);

		if (oTransProd.DevolucionID == null || oTransProd.DevolucionID == ""){
			Usuario oUsuario = (Usuario) Sesion.get(Campo.UsuarioActual);
			Dia oDia = (Dia) Sesion.get(Campo.DiaActual);
			Vendedor oVendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
			Cliente oCliente = (Cliente) Sesion.get(Campo.ClienteActual);
			com.amesol.routelite.actividades.ModuloMovDetalle oMMD = Consultas.ConsultasModuloMovDetalle.obtenerModuloMovDetallePorIndice(13);
			StringBuilder byRefMensaje = new StringBuilder();
			folio = Folios.Obtener(oMMD.getModuloMovDetalleClave(), byRefMensaje);
			
			//crear dev cliente
			TransProd transProdDev = new TransProd();
			transProdDev.TransProdID = KeyGen.getId();
			Visita oVisita;
			if (recuperarVisitaPedido){
				if (oTransProd.VisitaClave1 != null && oTransProd.DiaClave1 !=null){
					oVisita = new Visita();
					oVisita.VisitaClave = oTransProd.VisitaClave1;
					oVisita.DiaClave = oTransProd.DiaClave1;
				}else{
					oVisita = new Visita();
					oVisita.VisitaClave = oTransProd.VisitaClave;
					oVisita.DiaClave = oTransProd.DiaClave;
				}
				BDVend.recuperar(oVisita);
				if(oDia == null){
					oDia = new Dia();
					oDia.DiaClave = oVisita.DiaClave;
					BDVend.recuperar(oDia);

				}
				if(oCliente == null){
					oCliente = new Cliente();
					oCliente.ClienteClave = oVisita.ClienteClave;
					BDVend.recuperar(oCliente);
				}

			}else{
				oVisita = ((Visita)Sesion.get(Campo.VisitaActual));
			}

			transProdDev.VisitaClave = oVisita.VisitaClave;
			transProdDev.DiaClave = oVisita.DiaClave;
			transProdDev.DiaClave = oDia.DiaClave;
			transProdDev.PCEModuloMovDetClave = oTransProd.PCEModuloMovDetClave;
			transProdDev.Folio = folio;
			transProdDev.Tipo = (short) oMMD.getTipoTransprod();
			transProdDev.TipoFase = TiposFasesDocto.CAPTURA;
			transProdDev.TipoMovimiento = (short) oMMD.getTipoMovimiento();
			transProdDev.FechaHoraAlta = Generales.getFechaHoraActual();
			transProdDev.FechaCaptura = oDia.FechaCaptura;
			ISetDatos vrRecoleccion = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("TRPMOT", "'Recolección'", "", false);
			ISetDatos vrRecoleccionNV = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("TRPMOT", "'Recolección No Venta'", "", false);
			if (vrRecoleccion.getCount() > 0 || vrRecoleccionNV.getCount() > 0){
				if(vrRecoleccion.moveToNext()){
					transProdDev.TipoMotivo = vrRecoleccion.getShort(SearchManager.SUGGEST_COLUMN_INTENT_DATA);
				}else if(vrRecoleccionNV.moveToNext()){
					transProdDev.TipoMotivo = vrRecoleccionNV.getShort(SearchManager.SUGGEST_COLUMN_INTENT_DATA);
				}
			}else{
				transProdDev.TipoMotivo = 0;
			}
			transProdDev.Total = 0;
			transProdDev.Enviado = false;
			transProdDev.MFechaHora = Generales.getFechaHoraActual();
			transProdDev.MUsuarioID = oUsuario.USUId;
			BDVend.guardarInsertar(transProdDev);
			
			//actualizar venta
			String grupoMotivo = null;
			oTransProd.DevolucionID = transProdDev.TransProdID;
			if(vrRecoleccion.getCount() > 0)
				grupoMotivo = "Venta";
			else if(vrRecoleccionNV.getCount() > 0)
				grupoMotivo = "No Venta";
			else
				grupoMotivo = "No Venta";

            productos.moveToFirst();
			do{
                if(productos.getFloat("Recolectar") > 0){
                    //generar los detalles
                    TransProdDetalle transProdDetalle = TransaccionesDetalle.DevolucionesCliente.GenerarDetalleDevolucionEnvase(transProdDev.TransProdID,productos.getString("ProductoDetClave"),productos.getShort("TipoUnidad"),productos.getFloat("Recolectar"),transProdDev.TipoMotivo);
					BDVend.guardarInsertar(transProdDetalle);
                    com.amesol.routelite.actividades.Inventario.ActualizarInventario(transProdDetalle.ProductoClave,transProdDetalle.TipoUnidad,transProdDetalle.Cantidad,(int) transProdDev.Tipo,(int) transProdDev.TipoMovimiento,oVendedor.AlmacenID,grupoMotivo,false);
					if(oCliente.Prestamo){
						Producto producto = new Producto();
						producto.ProductoClave = transProdDetalle.ProductoClave;
						BDVend.recuperar(producto);
						ManejoEnvase.manejoEnvase(producto,transProdDetalle.TipoUnidad,transProdDetalle.Cantidad,transProdDetalle,transProdDev);
					}
                    BDVend.guardarInsertar(transProdDetalle);
                }
            }while(productos.moveToNext());
			
			vrRecoleccion.close();
			vrRecoleccionNV.close();

            Folios.confirmar(oMMD.getModuloMovDetalleClave());
		}
	}


    public static class DevolucionesCliente {
        public static TransProd ActualizarGenerarDevolucion(HashMap<String, TransProd> transacciones, String subEmpresaId, ModuloMovDetalle moduloMovDetalle, final StringBuilder byRefMensaje) throws ControlError, Exception
        {

            TransProd transprod = null;
            if (transacciones.size() == 1)
            {
                transprod = (TransProd) transacciones.values().toArray()[0];
                if (transprod.SubEmpresaId == null || transprod.SubEmpresaId.equals(""))
                {
                    transacciones.clear();
                    transprod.SubEmpresaId = subEmpresaId;

                    transacciones.put(subEmpresaId, transprod);
                }
                else if (!transprod.SubEmpresaId.equals(subEmpresaId))
                {
                    TransProd trp = generarTransaccion(moduloMovDetalle, byRefMensaje);
                    trp.SubEmpresaId = subEmpresaId;
                    transprod = trp;
                }
                HashMap<Integer,Precio> oPrecio = ListaPrecio.Determinar(((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave , moduloMovDetalle);
                transprod.setListaPrecios(oPrecio);

            }
            else
            {
                if (transacciones.containsKey(subEmpresaId))
                {
                    transprod = transacciones.get(subEmpresaId);
                }
                else
                {
                    TransProd trp = generarTransaccion(moduloMovDetalle, byRefMensaje);
                    trp.SubEmpresaId = subEmpresaId;
                    transprod = trp;
                }
            }

            return transprod;
        }

    }
	
	public static class Pedidos
	{

		public static TransProd generarPedido(com.amesol.routelite.datos.ModuloMovDetalle moduloMovDetalle, final StringBuilder byRefMensaje) throws ControlError, Exception
		{

			String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			String sClienteClave = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave;
			String sDiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
			String sVisitaClave = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave;

			TransProd transProd = new TransProd();

			transProd.TransProdID = KeyGen.getId();
			transProd.VisitaClave = sVisitaClave;
			transProd.DiaClave = sDiaClave;
			transProd.ClienteClave = sClienteClave;

			HashMap<Integer,Precio> listasPrecios= ListaPrecio.Determinar(sClienteClave, moduloMovDetalle);
			if (moduloMovDetalle.TipoTransProd == com.amesol.routelite.presentadores.Enumeradores.TiposTransProd.PEDIDO || moduloMovDetalle.TipoTransProd == com.amesol.routelite.presentadores.Enumeradores.TiposTransProd.MOV_SIN_INV_EV){
				if (((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("PrecioSegunCFVTipo").equals("1")){
					transProd.CFVTipo =Consultas.ConsultasCliFormaVenta.obtenerFormaVentaInicial(sClienteClave);
				}
			}
			transProd.setListaPrecios(listasPrecios);
			transProd.PCEPrecioClave = listasPrecios.get(0).PrecioClave;

			transProd.PCEModuloMovDetClave = moduloMovDetalle.ModuloMovDetalleClave;
			transProd.Folio = Folios.Obtener(moduloMovDetalle.ModuloMovDetalleClave, byRefMensaje);

			transProd.Tipo = moduloMovDetalle.TipoTransProd;
			//transProd.TipoPedido = moduloMovDetalle.TipoPedido;
			if(transProd.Tipo == TiposTransProd.PEDIDO){
				if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.PREVENTA){
					transProd.TipoPedido = TipoPedido.POSFECHADO;
				}else if (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == TiposModulos.REPARTO){
					transProd.TipoPedido = TipoPedido.NORMAL;
				}
			}
			else if(transProd.Tipo == TiposTransProd.VENTA_CONSIGNACION){
				transProd.TipoPedido = moduloMovDetalle.TipoPedido;
			}else if(transProd.Tipo == TiposTransProd.MOV_SIN_INV_EV)
				if(((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("MSIEVPreventa").equals("1"))
					transProd.TipoPedido = TipoPedido.POSFECHADO;
				else
					transProd.TipoPedido = TipoPedido.NORMAL;
			else{
				transProd.TipoPedido = TipoPedido.NORMAL;
			}
			transProd.TipoMovimiento = moduloMovDetalle.TipoMovimiento;
			transProd.TipoFase = (short)(transProd.Tipo == TiposTransProd.VENTA_CONSIGNACION ? 2:1);
			transProd.TipoTurno = 0;
			transProd.FechaHoraAlta = Generales.getFechaHoraActual();
			transProd.FechaCaptura = Generales.getFechaActual();
			transProd.Total = 0;
			/*
			 * transProd.FechaEntrega = I0257 transProd.FechaFacturacion =
			 * transProd.FechaSurtido = transProd.FechaCancelacion =
			 */
			transProd.MFechaHora = Generales.getFechaHoraActual();
			transProd.MUsuarioID = sUsuarioID;

			return transProd;

		}

		public static TransProd ActualizarGenerarPedido(HashMap<String, TransProd> transacciones, String subEmpresaId, ModuloMovDetalle moduloMovDetalle, boolean bModificandoPedido, final StringBuilder byRefMensaje) throws ControlError, Exception
		{

			TransProd transprod = null;
			if (transacciones.size() == 1)
			{
				transprod = (TransProd) transacciones.values().toArray()[0];
				if (transprod.SubEmpresaId == null || transprod.SubEmpresaId.equals(""))
				{
					transacciones.clear();
					transprod.SubEmpresaId = subEmpresaId;

					transacciones.put(subEmpresaId, transprod);
				}
				else if (!transprod.SubEmpresaId.equals(subEmpresaId))
				{
					if (bModificandoPedido){
						throw new Exception(Mensajes.get("E0765"));
					}else {
						TransProd trp = generarPedido(moduloMovDetalle, byRefMensaje);
						trp.SubEmpresaId = subEmpresaId;
						transprod = trp;
					}
				}
				HashMap<Integer,Precio> oPrecio;
				if (((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("PrecioSegunCFVTipo").equals("1") && (moduloMovDetalle.TipoTransProd == com.amesol.routelite.presentadores.Enumeradores.TiposTransProd.PEDIDO || moduloMovDetalle.TipoTransProd == com.amesol.routelite.presentadores.Enumeradores.TiposTransProd.MOV_SIN_INV_EV)){
					oPrecio = ListaPrecio.Determinar(((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave , moduloMovDetalle,transprod.CFVTipo);
				}else{
					oPrecio = ListaPrecio.Determinar(((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave , moduloMovDetalle);
				}

				transprod.setListaPrecios(oPrecio);

			}
			else
			{
				if (transacciones.containsKey(subEmpresaId))
				{
					transprod = transacciones.get(subEmpresaId);
				}
				else
				{
					TransProd trp = generarPedido(moduloMovDetalle, byRefMensaje);
					trp.SubEmpresaId = subEmpresaId;
					transprod = trp;
				}
			}

			return transprod;
		}

		public static TransProd ActualizarMovimientoInventario(String TransProdID, ModuloMovDetalle moduloMovDetalle, String byRefMensaje, int Motivo, TransProd transProdGeneral) throws ControlError, Exception
		{

			String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			String sDiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
			TransProd transProd = new TransProd();
			transProd.TransProdID = TransProdID;
			BDVend.recuperar(transProd);
			if (transProd.PCEPrecioClave != null && transProd.PCEPrecioClave.length()>0){
				transProd.CadenaListasPrecios = "'" + transProd.PCEPrecioClave +"'";
			}
			transProd.PCEModuloMovDetClave = moduloMovDetalle.ModuloMovDetalleClave;
			transProd.DiaClave = sDiaClave;
			transProd.Tipo = transProdGeneral.Tipo;
			transProd.TipoMovimiento = transProdGeneral.TipoMovimiento;
			transProd.TipoFase = transProdGeneral.TipoFase;
			transProd.Folio = transProdGeneral.Folio;
			transProd.FechaHoraAlta = Generales.getFechaHoraActual();
			transProd.FechaCaptura = Generales.getFechaActual();
			transProd.Total = 0;
			transProd.Saldo = 0;
			transProd.Enviado = false;
			if (Motivo != 0)
			{
				transProd.TipoMotivo = (short) Motivo;
			}
			transProd.MFechaHora = Generales.getFechaHoraActual();
			transProd.MUsuarioID = sUsuarioID;

			return transProd;
		}

		public static TransProd ActualizarGenerarMovSinInv(String TransProdID, ModuloMovDetalle moduloMovDetalle,final StringBuilder byRefMensaje, Short Motivo) throws ControlError, Exception
		{

			String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			String sDiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
			TransProd transProd = new TransProd();
			transProd.TransProdID = TransProdID;
			BDVend.recuperar(transProd);
			if (transProd.PCEPrecioClave != null && transProd.PCEPrecioClave.length()>0){
				transProd.CadenaListasPrecios = "'" + transProd.PCEPrecioClave +"'";
			}
			transProd.PCEModuloMovDetClave = moduloMovDetalle.ModuloMovDetalleClave;
			transProd.DiaClave = sDiaClave;
			transProd.Tipo = 19;
			transProd.TipoFase = 1;
			transProd.Folio = Folios.Obtener(moduloMovDetalle.ModuloMovDetalleClave, byRefMensaje);
			transProd.FechaHoraAlta = Generales.getFechaHoraActual();
			transProd.FechaCaptura = Generales.getFechaActual();
			transProd.Total = 0;
			transProd.Saldo = 0;
			if (Motivo != null){
				transProd.TipoMotivo = Motivo;	
			}
			
			transProd.MFechaHora = Generales.getFechaActual();
			transProd.MUsuarioID = sUsuarioID;

			return transProd;
		}

		public static TransProd ObtenerPedido(String TransProdId) throws Exception
		{
			TransProd transprod = new TransProd();
			transprod.TransProdID = TransProdId;
			BDVend.recuperar(transprod);
			return transprod;
		}

		public static boolean EliminarSiNoHayDetalle(String TransProdId) throws Exception
		{
			boolean eliminar = false;
			ISetDatos transprod = Consultas.ConsultasTransProdDetalle.obtenerDetalle("'" + TransProdId + "'");
			if (transprod.getCount() <= 0)
			{
				eliminar = true;
			}
			transprod.close();
			return eliminar;
		}

/*		public static void EliminarPedido(String TransProdId) throws Exception
		{
			Consultas.ConsultasTPDImpuesto.eliminarImpuestos(TransProdId);
			Consultas.ConsultasTrpPrp.eliminarPorTransProd(TransProdId);
			Consultas.ConsultasDescuentos.eliminarDescuentos(TransProdId);
			Consultas.ConsultasTPDDesVendedor.eliminarPorTransProd(TransProdId);
            Consultas.ConsultasTPDDatosExtra.eliminarPorTransProd(TransProdId);

			float nPuntos = Consultas.ConsultasTpdPun.obtenerPuntos(TransProdId);
			if (nPuntos > 0)
			{
				nPuntos = Math.round(nPuntos);
				Consultas.ConsultasTpdPun.actualizarSaldo(nPuntos);
			}
			Consultas.ConsultasTpdPun.eliminar(TransProdId);

			Consultas.ConsultasTransProdDetalle.eliminarDetalle(TransProdId);
			TransProd oTRP = ObtenerPedido(TransProdId);
			//BDVend.eliminar(oTRP);
		}*/

		public static void cancelarPedidoInconsistente(TransProd pedido) throws Exception
		{
							
				if(pedido.Tipo != com.amesol.routelite.presentadores.Enumeradores.TiposTransProd.MOV_SIN_INV_EV && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == com.amesol.routelite.presentadores.Enumeradores.TiposModulos.REPARTO){
					
					Consultas.ConsultasTPDDesVendedor.eliminarPorTransProd(pedido.TransProdID); 
					//solo se deja este escenario porque es el inconsistente
					//pedido creado en visita
					//actualizar inventario, entrada
					BDVend.recuperar(pedido, TransProdDetalle.class);
					Iterator<TransProdDetalle> it = pedido.TransProdDetalle.iterator();
					while (it.hasNext())
					{
						TransProdDetalle oTpd = it.next();
						com.amesol.routelite.actividades.Inventario.ActualizarInventario(oTpd.ProductoClave, oTpd.TipoUnidad, oTpd.Cantidad, pedido.Tipo, TiposMovimientos.ENTRADA, ((Vendedor)Sesion.get(Campo.VendedorActual)).AlmacenID, true, TiposFasesDocto.SURTIDO);
					}
				}

				pedido.TipoFase = 0;
				//pedido.TipoMotivo = mVista.getTipoMotivo();
				pedido.FechaCancelacion = Generales.getFechaHoraActual();
				pedido.Notas = "Cancelado por inconsistencias - Android";
				pedido.MFechaHora = Generales.getFechaHoraActual();
				pedido.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
				BDVend.guardarInsertar(pedido);

				BDVend.commit();
		}

		public static void CalcularTotalesPedido(TransProd oTransProd) throws Exception
		{
			//TransProd oTrp = ObtenerPedido(TransProdId);
			ISetDatos totales = Consultas.ConsultasTransProdDetalle.obtenerTotalesDetalle(oTransProd.TransProdID);
			while (totales.moveToNext())
			{
				oTransProd.SubTDetalle = totales.getFloat("SubTDetalle");
				oTransProd.Impuesto = totales.getFloat("Impuesto");
				oTransProd.Total = totales.getFloat("Total");
			}
			totales.close();
		}

		public static void ActualizarSaldoCliente(String ClienteClave, float Total) throws Exception
		{
			Consultas.ConsultasCliente.actualizarSaldo(ClienteClave, Total);
		}

		public static void ActualizarSaldo(String transProdId, float importe) throws Exception
		{
			String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

			TransProd oTRP = new TransProd();
			oTRP.TransProdID = transProdId;
			BDVend.recuperar(oTRP);
			oTRP.Saldo = Generales.getRound((oTRP.Saldo + importe), 2);
			oTRP.MFechaHora = Generales.getFechaHoraActual();
			oTRP.MUsuarioID = sUsuarioID;
			oTRP.Enviado = false;

			BDVend.guardarInsertar(oTRP);
		}

		/*
		 * public static boolean GenerarPedidoSugerido(TransProd
		 * transProdGeneral, HashMap<String, TransProd> transacciones,
		 * ArrayList<Integer> tipoPedido, ModuloMovDetalle moduloMovDetalle){
		 * try{ //boolean bSoloPrioritario = false; boolean bHayPedido = false;
		 * //No hay pedido sugerido String sClienteClave =
		 * ((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave; short
		 * nFrecuenciaDia = ((Dia)Sesion.get(Campo.DiaActual)).Frecuencia;
		 * ISetDatos dtProductos =
		 * Consultas.ConsultasTransProd.obtenerPedidoSugerido(sClienteClave,
		 * nFrecuenciaDia, tipoPedido); if (dtProductos.getCount() > 0){
		 *
		 * while(dtProductos.moveToNext()){ if (GenerarDetalle(moduloMovDetalle,
		 * transProdGeneral, transacciones,
		 * dtProductos.getString("ProductoClave"),
		 * dtProductos.getInt("PRUTipoUnidad"),
		 * dtProductos.getFloat("Cantidad"), dtProductos.getFloat("Cantidad")))
		 * bHayPedido = true; };
		 *
		 * dtProductos.close(); return bHayPedido; }else{ dtProductos.close();
		 * return false; }
		 *
		 * }catch(Exception e){ e.printStackTrace(); return false; } }
		 */

		public static String getTransaccionesIds(ArrayList<String> transacciones)
		{
			return transacciones.toString().replace("[", "'").replace("]", "'").replace(", ", "','");
		}

		public static void cambiarListaPrecios(ArrayList<TransProd> transacciones) throws Exception{
				//Recuperar productos que otorgaron una promocion
				for (TransProd oTransProd : transacciones) {
					ListIterator<TransProdDetalle> oDetalles = oTransProd.TransProdDetalle.listIterator();
					Descuento oDescuento = new Descuento();
					Impuesto[] oImpuestos;
					ArrayList<TransProdDetalle> tpdEliminados = new ArrayList<TransProdDetalle>();
					while (oDetalles.hasNext()) {
						TransProdDetalle oTPD = oDetalles.next();
						if (oTPD.Promocion == null || oTPD.Promocion == 0 ) {
							//No se recaptura el TPDDatosExtra ya que no cambia la lista de Precios aplicada
							StringBuilder sPrecioClave = new StringBuilder();
							float nPrecio = ListaPrecio.BuscarPrecio(oTPD.ProductoClave, (short) oTPD.TipoUnidad, oTransProd.CadenaListasPrecios, sPrecioClave, oTPD.Cantidad);
							if (nPrecio >= 0) {
								boolean bHuboCambioPrecio = false;
								if (nPrecio != oTPD.Precio) {//solo si cambia el precio se recalcula
									oTPD.Precio = nPrecio;

									oImpuestos = Impuestos.Buscar(oTPD.ProductoClave, ((Cliente) Sesion.get(Campo.ClienteActual)).TipoImpuesto);
									oDescuento = Descuentos.BuscarDescuentosProductos(oTPD.ProductoClave);

									oTPD.DescuentoImp = Descuentos.CalcularDescuentosProducto(oDescuento, oTPD.Cantidad * oTPD.Precio, oTPD.Cantidad);
									oTPD.DescuentoPor = oTPD.DescuentoImp;
									oTPD.setSubTotal(((oTPD.Cantidad * oTPD.Precio) - oTPD.DescuentoImp) < 0 ? 0 : (oTPD.Cantidad * oTPD.Precio) - oTPD.DescuentoImp);
									oTPD.Impuesto = Impuestos.Calcular(oImpuestos, oTPD.getSubTotal(), oTPD.Precio, oTPD.Cantidad);
									oTPD.Total = oTPD.getSubTotal() + oTPD.Impuesto;
									Impuestos.GuardarDetalle(oTPD, oImpuestos);
									bHuboCambioPrecio = true;
								}
								if ( oTPD.TPDDatosExtra == null || oTPD.TPDDatosExtra.size()<=0) {
									BDVend.recuperar(oTPD, TPDDatosExtra.class);
								}

								if (oTPD.TPDDatosExtra != null && oTPD.TPDDatosExtra.size()>0) {
									bHuboCambioPrecio = true;
									oTPD.TPDDatosExtra.get(0).PrecioClave = sPrecioClave.toString();
								}else{
									TPDDatosExtra tde = new TPDDatosExtra();
									bHuboCambioPrecio = true;
									tde.TransProdID = oTPD.TransProdID;
									tde.TransProdDetalleID = oTPD.TransProdDetalleID;
									tde.PrecioClave = sPrecioClave.toString();
									tde.MUsuarioID = oTPD.MUsuarioID;
									tde.MFechaHora = Generales.getFechaHoraActual();
									tde.Enviado = false;
									oTPD.TPDDatosExtra.add(tde);
								}
								if (bHuboCambioPrecio)
									BDVend.guardarInsertar(oTPD);
							}else{
									Consultas.ConsultasTPDImpuesto.eliminarImpuestosPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
									Consultas.ConsultasDescuentos.eliminarDescuentosPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
									Consultas.ConsultasTPDDesVendedor.eliminarDescuentoPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
									Consultas.ConsultasTrpPrp.eliminarPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
									Consultas.ConsultasTPDDatosExtra.eliminarPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
									Consultas.ConsultasTPDDesProntoPago.eliminarDescuentoPorDetalle(oTPD.TransProdID, oTPD.TransProdDetalleID);
									//if eliminarcero then
									//BDVend.eliminar(oTPD);
									//else
									oTPD.DescuentoClave = null;
									oTPD.Promocion = 0;
									oTPD.Cantidad = 0;
									oTPD.DescuentoPor = (float) 0;
									oTPD.DescuentoImp = (float) 0;
									oTPD.Impuesto = (float) 0;
									oTPD.Subtotal = 0;
									oTPD.Total = 0;
									oTPD.Enviado = false;
									oTPD.MFechaHora = Generales.getFechaActual();
									oTPD.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;

							}
						}
					}
				}
			}

	}//Fin Pedidos

	public static class Inventario
	{

		public static TransProd generarMovSinVista(ModuloMovDetalle moduloMovDetalle, final StringBuilder byRefMensaje) throws ControlError, Exception
		{
			String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			String sDiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
			TransProd transProd = new TransProd();
			transProd.TransProdID = KeyGen.getId();
			transProd.PCEModuloMovDetClave = moduloMovDetalle.ModuloMovDetalleClave;
			transProd.DiaClave = sDiaClave;
			transProd.Folio = Folios.Obtener(moduloMovDetalle.ModuloMovDetalleClave, byRefMensaje);
			transProd.Tipo = 19;
			transProd.TipoFase = 1;
			transProd.FechaHoraAlta = Generales.getFechaHoraActual();
			transProd.FechaCaptura = Generales.getFechaActual();
			transProd.Total = 0;
			transProd.Saldo = 0;
			transProd.MFechaHora = Generales.getFechaHoraActual();
			transProd.MUsuarioID = sUsuarioID;

			return transProd;

		}

		public static TransProd generarMovConInventario(ModuloMovDetalle moduloMovDetalle, int Tipo, int TipoMovimiento, final StringBuilder byRefMensaje) throws ControlError, Exception
		{
			String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			String sDiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
			TransProd transProd = new TransProd();
			transProd.TransProdID = KeyGen.getId();
			transProd.PCEModuloMovDetClave = moduloMovDetalle.ModuloMovDetalleClave;
			transProd.DiaClave = sDiaClave;
			transProd.Folio = Folios.Obtener(moduloMovDetalle.ModuloMovDetalleClave, byRefMensaje);
			transProd.Tipo = (short) Tipo;
			transProd.TipoMovimiento = (short) TipoMovimiento;
			transProd.TipoFase = 1;
			transProd.FechaHoraAlta = Generales.getFechaHoraActual();
			transProd.FechaCaptura = Generales.getFechaActual();
			transProd.Total = 0;
			transProd.Enviado = false;
			transProd.Saldo = 0;
			transProd.Notas = "";
			transProd.Escritorio = false;
			transProd.MFechaHora = Generales.getFechaHoraActual();
			transProd.MUsuarioID = sUsuarioID;

			return transProd;

		}
	}

	public static class Preliquidacion
	{

		public static PLBPLE generarPreliquidacion(String PLIId) throws ControlError, Exception
		{
			PLBPLE mPLBPLE = new PLBPLE();
			mPLBPLE.PLIId = PLIId;

			return mPLBPLE;

		}

		public static PLBPLE ActualizarPreliquidacionEfectivo(String TipoEfectivo, String PBEId, float Total, PLBPLE PLBPLEGeneral) throws ControlError, Exception
		{

			PLBPLE mPLBPLE = new PLBPLE();
			mPLBPLE.PLIId = PLBPLEGeneral.PLIId;
			mPLBPLE.PBEId = (PBEId.equals("")) ? KeyGen.getId() : PBEId;
			mPLBPLE.TipoBanco = null;
			mPLBPLE.FechaDeposito = null;
			mPLBPLE.Total = Total;
			mPLBPLE.Referencia = null;
			mPLBPLE.Ficha = null;
			mPLBPLE.TipoEfectivo = TipoEfectivo;
			mPLBPLE.MFechaHora = Generales.getFechaHoraActual();
			mPLBPLE.Enviado = false;
			return mPLBPLE;
		}

		@SuppressLint("SimpleDateFormat")
		public static PLBPLE ActualizarPreliquidacionDeposito(String mFecha, String PBEId, String TipoBanco, String referencia, String totalDep, String ficha, PLBPLE PLBPLEGeneral) throws ControlError, Exception
		{
			try
			{
				PLBPLE mPLBPLE = new PLBPLE();
				mPLBPLE.PLIId = PLBPLEGeneral.PLIId;
				mPLBPLE.PBEId = (PBEId.equals("")) ? KeyGen.getId() : PBEId;
				mPLBPLE.TipoBanco = TipoBanco;
				SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy");
				mPLBPLE.FechaDeposito = format.parse(mFecha);
				mPLBPLE.Total = Float.parseFloat(totalDep);
				mPLBPLE.Referencia = referencia;
				mPLBPLE.Ficha = ficha;
				mPLBPLE.TipoEfectivo = null;
				mPLBPLE.MFechaHora = Generales.getFechaHoraActual();
				mPLBPLE.Enviado = false;

				return mPLBPLE;
			}
			catch (ParseException e)
			{
				e.printStackTrace();
				return null;
			}
		}
	}

	public static class Deposito
	{

		public static com.amesol.routelite.datos.Deposito GenerarDeposito(int TipoBanco, String Cuenta, String Ficha, float Deposito, ArrayList<ABNDetalle> aAbd) throws ControlError, Exception
		{
			com.amesol.routelite.datos.Deposito mDeposito = GenerarDeposito(TipoBanco, Ficha, Deposito);
			if(mDeposito != null){
				if (Cuenta.length() >0) {
					mDeposito.Cuenta = Cuenta;
				}
				if(aAbd.size()>0){
					for(int x=0;x<aAbd.size();x++) {
						AbdDep abd = new AbdDep();
						abd.DEPId =	mDeposito.DEPId;
						abd.ABNId = aAbd.get(x).ABNId;
						abd.ABDId = aAbd.get(x).ABDId;
						abd.Importe =  aAbd.get(x).Importe; //Se deposita el importe completo del abono
						abd.Enviado = false;
						abd.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
						abd.MFechaHora = Generales.getFechaHoraActual();
						mDeposito.AbdDep.add(abd);
						//modificar el Saldo Deposito del abono
						BDVend.recuperar(aAbd.get(x)); //Se recuperan los datos originales del abono
						aAbd.get(x).SaldoDeposito=0;
						aAbd.get(x).MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
						aAbd.get(x).MFechaHora = Generales.getFechaHoraActual();
						aAbd.get(x).Enviado = false;
					}
				}
			}
			return mDeposito;
		}

		public static com.amesol.routelite.datos.Deposito GenerarDeposito(int TipoBanco, String Ficha, float Deposito) throws ControlError, Exception
		{

			com.amesol.routelite.datos.Deposito mDeposito = new com.amesol.routelite.datos.Deposito();
			mDeposito.DEPId = KeyGen.getId();
			mDeposito.DiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
			mDeposito.TipoBanco = (short) TipoBanco;
			mDeposito.FechaCreacion = Consultas.ConsultaDeposito.obtenerDiaCreacion(mDeposito.DiaClave);
			mDeposito.FechaDeposito = Generales.getFechaHoraActual();
			mDeposito.Ficha = Ficha;
			mDeposito.Total = Deposito;
			mDeposito.MFechaHora = Generales.getFechaHoraActual();
			mDeposito.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
			mDeposito.Enviado = false;
			return mDeposito;
		}

        public static SaldoDeposito GenerarSaldoDeposito(String DepositoCapturaId, float Saldo, String DiaClave) throws ControlError, Exception{
            SaldoDeposito saldoDeposito = new SaldoDeposito();
            saldoDeposito.SaldoDepositoID = KeyGen.getId();
            saldoDeposito.DiaClave = DiaClave;
            saldoDeposito.VendedorID = ((Vendedor)Sesion.get(Campo.VendedorActual)).VendedorId;
            if (DepositoCapturaId != null) {
                saldoDeposito.DepositoCapturaID = DepositoCapturaId;
                saldoDeposito.Saldo = Saldo * -1;
            }
            else
                saldoDeposito.Saldo = Saldo;
            saldoDeposito.Aplicado = 0;
            saldoDeposito.MFechaHora = Generales.getFechaHoraActual();
            saldoDeposito.MUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
            saldoDeposito.Enviado = false;

            return saldoDeposito;
        }
	}

	public static class Kilometraje
	{
		public static CamionVendedor GenerarCamionVendedor(String Placa, float KMInicial)
		{
			CamionVendedor mCamionVendedor = new CamionVendedor();
			mCamionVendedor.CAMVENId = KeyGen.getId();
			mCamionVendedor.Placa = Placa;
			mCamionVendedor.FechaHoraInicial = Generales.getFechaHoraActual();
			mCamionVendedor.KmInicial = KMInicial;
			mCamionVendedor.MFechaHora = Generales.getFechaHoraActual();
			mCamionVendedor.Enviado = false;

			return mCamionVendedor;

		}

		public static CamionVendedor GenerarCamionVendedorFinal(CamionVendedor mCamionVendedor, float KMFinal, float LitrosGasolina, float ImporteGasolina)
		{
			mCamionVendedor.FechaHoraFinal = Generales.getFechaHoraActual();
			mCamionVendedor.KmFinal = KMFinal;
			mCamionVendedor.LitrosGasolina = LitrosGasolina;
			mCamionVendedor.ImporteGasolina = ImporteGasolina;
			mCamionVendedor.MFechaHora = Generales.getFechaHoraActual();
			mCamionVendedor.Enviado = false;

			return mCamionVendedor;

		}

	}
	
	public static final class Factura{

		public static Float obtenerSubtotal(String sClienteClave, String pedidosFacturados) throws Exception
		{
			float subtotal = 0f;
			ISetDatos cursor = Consultas.ConsultasTransProdDetalle.obtenerSubtotalParaFactura(sClienteClave, pedidosFacturados);
			if(cursor.moveToNext()){
				subtotal = cursor.getFloat("Subtotal");
			}
			cursor.close();
			return subtotal;
		}
		
		public static Float obtenerImpuesto(String sClienteClave, String pedidosFacturados) throws Exception
		{
			float impuesto = 0f;
			ISetDatos cursor = Consultas.ConsultasTransProdDetalle.obtenerImpuestoParaFactura(sClienteClave, pedidosFacturados);
			if(cursor.moveToNext()){
				impuesto = cursor.getFloat("Impuesto");
			}
			cursor.close();
			return impuesto;
		}
	}

    public static final class Solicitudes {

        public static Solicitud generarSolicitud(ModuloMovDetalle moduloMovDetalle, final StringBuilder byRefMensaje) throws ControlError, Exception
        {
            String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
            String sDiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
            String sVisitaClave = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave;

            Solicitud oSolicitud = new Solicitud();
            oSolicitud.SOLId = KeyGen.getId();
            oSolicitud.Folio = Folios.Obtener(moduloMovDetalle.ModuloMovDetalleClave, byRefMensaje);
            oSolicitud.VisitaClave = sVisitaClave;
            oSolicitud.DiaClave = sDiaClave;
            oSolicitud.TipoEstado = 1;
            oSolicitud.FechaHora = Generales.getFechaHoraActual();
            oSolicitud.MFechaHora = Generales.getFechaHoraActual();
            oSolicitud.MUsuarioID = sUsuarioID;
            oSolicitud.Enviado = false;

            return oSolicitud;
        }

        public static void eliminarSolicitud(String sSOLId){
            try {
                Solicitud oSolicitud = new Solicitud();
                oSolicitud.SOLId = sSOLId;
                BDVend.recuperar(oSolicitud);
                //oSolicitud.TipoEstado = 0;
                //BDVend.guardarInsertar(oSolicitud);
                BDVend.eliminar(oSolicitud);
                BDVend.commit();
            }catch(Exception e){
                e.printStackTrace();
            }
        }

        public static boolean validarEnviado(String sSOLId){
            try {
                Solicitud oSolicitud = new Solicitud();
                oSolicitud.SOLId = sSOLId;
                BDVend.recuperar(oSolicitud);
                return oSolicitud.Enviado;
            }catch(Exception e){
                return false;
            }
        }
    }

	public static TransProd generarConsignaDePedido(TransProd pedido, final StringBuilder byRefMensaje) throws ControlError, Exception
	{
		String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
		String sClienteClave = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave;
		String sDiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
		String sVisitaClave = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave;

		com.amesol.routelite.actividades.ModuloMovDetalle mmd = Consultas.ConsultasModuloMovDetalle.obtenerModuloMovDetallePorIndice(26);
		ModuloMovDetalle mmdDatos = new ModuloMovDetalle();
		mmdDatos.ModuloMovDetalleClave = mmd.getModuloMovDetalleClave();
		BDVend.recuperar(mmdDatos);

		TransProd transProd = new TransProd();
		transProd.Folio = Folios.Obtener(mmdDatos.ModuloMovDetalleClave, byRefMensaje);
		transProd.TransProdID = KeyGen.getId();
		transProd.VisitaClave = sVisitaClave;
		transProd.DiaClave = sDiaClave;
		transProd.PCEPrecioClave = pedido.PCEPrecioClave;
		transProd.PCEModuloMovDetClave = pedido.PCEModuloMovDetClave;
		transProd.SubEmpresaId = pedido.SubEmpresaId;
		transProd.ClienteClave = sClienteClave;
		transProd.Tipo = mmdDatos.TipoTransProd; //moduloMovDetalle.TipoMovimiento;
		transProd.TipoPedido = mmdDatos.TipoPedido;
		transProd.TipoMovimiento = mmdDatos.TipoMovimiento;
		transProd.TipoFase = 2;
		transProd.FechaHoraAlta = Generales.getFechaHoraActual();
		transProd.FechaCaptura = Generales.getFechaActual();
		transProd.FechaEntrega = Generales.getFechaActual();
		transProd.TipoMotivo = 12;
		transProd.SubTDetalle = pedido.SubTDetalle;
		transProd.DescVendPor = pedido.DescVendPor;
		transProd.DescuentoVendedor = pedido.DescuentoVendedor;
		transProd.DescuentoImp = pedido.DescuentoImp;
		transProd.Subtotal = pedido.Subtotal;
		transProd.Impuesto = pedido.Impuesto;
		transProd.Total = pedido.Total;
		transProd.Saldo = pedido.Saldo;
		transProd.Promocion = pedido.Promocion;
		transProd.Descuento = pedido.Descuento;
		transProd.MFechaHora = Generales.getFechaHoraActual();
		transProd.MUsuarioID = sUsuarioID;
		transProd.Enviado = false;

		pedido.VisitaClave1 = sVisitaClave;
		pedido.DiaClave1 = sDiaClave;
		pedido.FacturaID = transProd.TransProdID;
		pedido.TipoFase = 0;
		pedido.FechaCancelacion = Generales.getFechaHoraActual();
		pedido.TipoMotivo = 17;
		pedido.MFechaHora = Generales.getFechaHoraActual();
		pedido.MUsuarioID = sUsuarioID;
		pedido.Enviado = false;

		BDVend.guardarInsertar(transProd);
		BDVend.guardarInsertar(pedido);

		return transProd;

	}

	public static TransProd generarConsignaDePedidoParcial(TransProd pedido, short diasCredito, final StringBuilder byRefMensaje) throws ControlError, Exception
	{
		String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
		String sClienteClave = ((Cliente) Sesion.get(Campo.ClienteActual)).ClienteClave;
		String sDiaClave = ((Dia) Sesion.get(Campo.DiaActual)).DiaClave;
		String sVisitaClave = ((Visita) Sesion.get(Campo.VisitaActual)).VisitaClave;

		com.amesol.routelite.actividades.ModuloMovDetalle mmd = Consultas.ConsultasModuloMovDetalle.obtenerModuloMovDetallePorIndice(26);
		ModuloMovDetalle mmdDatos = new ModuloMovDetalle();
		mmdDatos.ModuloMovDetalleClave = mmd.getModuloMovDetalleClave();
		BDVend.recuperar(mmdDatos);

		TransProd transProd = new TransProd();
		transProd.Folio = Folios.Obtener(mmdDatos.ModuloMovDetalleClave, byRefMensaje);
		transProd.TransProdID = KeyGen.getId();
		transProd.VisitaClave = sVisitaClave;
		transProd.DiaClave = sDiaClave;
		transProd.PCEPrecioClave = pedido.PCEPrecioClave;
		transProd.PCEModuloMovDetClave = pedido.PCEModuloMovDetClave;
		transProd.SubEmpresaId = pedido.SubEmpresaId;
		transProd.ClienteClave = sClienteClave;
		transProd.Tipo = mmdDatos.TipoTransProd; //moduloMovDetalle.TipoMovimiento;
		transProd.TipoPedido = mmdDatos.TipoPedido;
		transProd.TipoMovimiento = mmdDatos.TipoMovimiento;
		transProd.TipoFase = 2;
		transProd.FechaHoraAlta = Generales.getFechaHoraActual();
		transProd.FechaCaptura = Generales.getFechaActual();
		transProd.FechaEntrega = Generales.getFechaActual();
		transProd.TipoMotivo = 12;
		transProd.DiasCredito = diasCredito;
		transProd.MFechaHora = Generales.getFechaHoraActual();
		transProd.MUsuarioID = sUsuarioID;
		transProd.Enviado = false;

		BDVend.guardarInsertar(transProd);

		return transProd;
	}

	public static void copiarDetalleDePedido(TransProd pedido, TransProd consigna) throws ControlError, Exception
	{
		String sUsuarioID = ((Usuario) Sesion.get(Campo.UsuarioActual)).USUId;
		ArrayList<TPDDesVendedor> oTPDDesVend = new ArrayList<>();
		Iterator<TransProdDetalle> oTpd = pedido.getTransProdDetalle().iterator();
		while(oTpd.hasNext()){
			TransProdDetalle tpd = oTpd.next();
			TransProdDetalle tpdCons = new TransProdDetalle();
			tpdCons.TransProdID = consigna.TransProdID;
			tpdCons.TransProdDetalleID = KeyGen.getId();
			tpdCons.ProductoClave = tpd.ProductoClave;
			tpdCons.TipoUnidad = tpd.TipoUnidad;
			tpdCons.Partida = tpd.Partida;
			tpdCons.Cantidad = tpd.Cantidad;
			tpdCons.Precio = tpd.Precio;
			tpdCons.DescuentoPor = tpd.DescuentoPor;
			tpdCons.DescuentoImp = tpd.DescuentoImp;
			tpdCons.Subtotal = tpd.Subtotal;
			tpdCons.Impuesto = tpd.Impuesto;
			tpdCons.Total = tpd.Total;
			tpdCons.Promocion = tpd.Promocion;
			tpdCons.MFechaHora = Generales.getFechaHoraActual();
			tpdCons.MUsuarioID = sUsuarioID;
			tpdCons.Enviado = false;

			Iterator<TPDImpuesto> oTdi = tpd.TPDImpuesto.iterator();
			while(oTdi.hasNext()){
				TPDImpuesto tdi = oTdi.next();
				TPDImpuesto tdiCons = new TPDImpuesto();
				tdiCons.TransProdID = consigna.TransProdID;
				tdiCons.TransProdDetalleID = tpdCons.TransProdDetalleID;
				tdiCons.TPDImpuestoID = KeyGen.getId();
				tdiCons.ImpuestoClave = tdi.ImpuestoClave;
				tdiCons.ImpuestoPor = tdi.ImpuestoPor;
				tdiCons.ImpuestoImp = tdi.ImpuestoImp;
				tdiCons.ImpuestoPU = tdi.ImpuestoPU;
				tdiCons.ImpDesGlb = tdi.ImpDesGlb;
				tdiCons.MFechaHora = Generales.getFechaHoraActual();
				tdiCons.MUsuarioID = sUsuarioID;
				tdiCons.Enviado = false;
				tpdCons.TPDImpuesto.add(tdiCons);
			}

			Iterator<TpdDes> oTdd = tpd.TpdDes.iterator();
			while(oTdd.hasNext()) {
				TpdDes tdd = oTdd.next();
				TpdDes tddCons = new TpdDes();
				tddCons.TransProdID = consigna.TransProdID;
				tddCons.TransProdDetalleID = tpdCons.TransProdDetalleID;
				tddCons.DescuentoClave = tdd.DescuentoClave;
				tddCons.DesPor = tdd.DesPor;
				tddCons.DesImporte = tdd.DesImporte;
				tddCons.DesImpuesto = tdd.DesImpuesto;
				tddCons.Jerarquia = tdd.Jerarquia;
				tddCons.TipoCascada = tdd.TipoCascada;
				tddCons.MFechaHora = Generales.getFechaHoraActual();
				tddCons.MUsuarioID = sUsuarioID;
				tddCons.Enviado = false;
				tpdCons.TpdDes.add(tddCons);
			}

			Iterator<TrpPrp> oTpp = tpd.TrpPrp.iterator();
			while(oTpp.hasNext()) {
				TrpPrp tpp = oTpp.next();
				TrpPrp tppCons = new TrpPrp();
				tppCons.TransProdID = consigna.TransProdID;
				tppCons.TransProdDetalleID = tpdCons.TransProdDetalleID;
				tppCons.PromocionClave = tpp.PromocionClave;
				tppCons.PromocionReglaID = tpp.PromocionReglaID;
				tppCons.PromocionImp = tpp.PromocionImp;
				tppCons.MFechaHora = Generales.getFechaHoraActual();
				tppCons.MUsuarioID = sUsuarioID;
				tppCons.Enviado = false;
				tpdCons.TrpPrp.add(tppCons);
			}

			ISetDatos dtTDV = Consultas.ConsultasTPDDesVendedor.obtenerTPDDesVendedor(tpd.TransProdID, tpd.TransProdDetalleID);

			if (dtTDV.getCount() > 0){

				while (dtTDV.moveToNext()){
					TPDDesVendedor tdvCons = new TPDDesVendedor();
					tdvCons.TransProdID = consigna.TransProdID;
					tdvCons.TransProdDetalleID = tpdCons.TransProdDetalleID;
					tdvCons.DesPor = dtTDV.getFloat("DesPor");
					tdvCons.DesImporte = dtTDV.getFloat("DesImporte");
					tdvCons.DesImpuesto = dtTDV.getFloat("DesImpuesto");
					tdvCons.MFechaHora = Generales.getFechaHoraActual();
					tdvCons.MUsuarioID = sUsuarioID;
					tdvCons.Enviado = false;
					oTPDDesVend.add(tdvCons);
				}
			}

			Iterator<TPDDatosExtra> oTde = tpd.TPDDatosExtra.iterator();
			while(oTde.hasNext()) {
				TPDDatosExtra tde = oTde.next();
				TPDDatosExtra tdeCons = new TPDDatosExtra();
				tdeCons.TransProdID = tde.TransProdID;
				tdeCons.TransProdDetalleID = tde.TransProdDetalleID;
				tdeCons.PrecioClave = tde.PrecioClave;
				tdeCons.MFechaHora = Generales.getFechaHoraActual();
				tdeCons.MUsuarioID = sUsuarioID;
				tdeCons.Enviado = false;
				tpdCons.TPDDatosExtra.add(tdeCons);
			}

			consigna.TransProdDetalle.add(tpdCons);
		}

		BDVend.guardarInsertar(consigna);

		for (TPDDesVendedor tdv : oTPDDesVend)  {
			BDVend.guardarInsertar(tdv);
		}
	}

}
