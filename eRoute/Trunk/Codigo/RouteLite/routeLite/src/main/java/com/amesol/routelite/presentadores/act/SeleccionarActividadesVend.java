package com.amesol.routelite.presentadores.act;

import android.app.AlertDialog;
import android.content.DialogInterface;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.CamionVendedor;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.VendedorJornada;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.ACTROL;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaInicioFinJornada;
import com.amesol.routelite.presentadores.interfaces.ICapturaKilometraje;
import com.amesol.routelite.presentadores.interfaces.ICapturaPreLiquidacion;
import com.amesol.routelite.presentadores.interfaces.IConsultaIndicadores;
import com.amesol.routelite.presentadores.interfaces.IConsultaInvenario;
import com.amesol.routelite.presentadores.interfaces.IConsultaReporte;
import com.amesol.routelite.presentadores.interfaces.IRecepcionInformacion;
import com.amesol.routelite.presentadores.interfaces.IRevisionPendientes;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActividadesVend;
import com.amesol.routelite.presentadores.interfaces.ISeleccionAgenda;
import com.amesol.routelite.presentadores.interfaces.ISeleccionConteoInventario;
import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;
import com.amesol.routelite.presentadores.interfaces.ISolicitudAgendaVendedor;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class SeleccionarActividadesVend extends Presentador
{
	ISeleccionActividadesVend mVista;

	public SeleccionarActividadesVend(ISeleccionActividadesVend vista)
	{
		mVista = vista;
	}

	@Override
	public void iniciar()
	{
		mVista.mostrarActividades(ValoresReferencia.getValores("ACTROL", "Principales"), "Principales");
	}

	public void seleccionar(ValorReferencia valorReferencia)
	{
		if (valorReferencia.getVavclave().equals("1")) {
            Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita, false);
            mVista.mostrarActividades(ValoresReferencia.getValores("ACTROL", "Actualizar"), "Actualizar");
        }
		else if (valorReferencia.getVavclave().equals("3"))
		{
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio RevisionPendientes"); ;
			mVista.finalizar();
			mVista.iniciarActividad(IRevisionPendientes.class, false);
		}
		else if (valorReferencia.getVavclave().equals("5")) {
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio SolicitudAgenda");
			mVista.iniciarActividadConResultado(ISolicitudAgendaVendedor.class, Enumeradores.Solicitudes.SOLICITUD_AGENDA, Enumeradores.Acciones.ACCION_AGENDA_VENDEDOR);
		}else if (valorReferencia.getVavclave().equals("6"))
		{
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio EnvioDeInformacion"); ;
			final AlertDialog.Builder alert = new AlertDialog.Builder(mVista.getContext());
			alert.setTitle(Mensajes.get("P0243", valorReferencia.getDescripcion().toString())).setPositiveButton(Mensajes.get("XSi"), new DialogInterface.OnClickListener()
			{
				public void onClick(DialogInterface dialog, int whichButton)
				{
					mVista.iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_ENVIAR_BD_VENDEDOR);
				}
			}).setNegativeButton(Mensajes.get("XNo"), new DialogInterface.OnClickListener()
			{
				public void onClick(DialogInterface dialog, int whichButton)
				{

				}
			});
			alert.show();
		}
		else if (valorReferencia.getVavclave().equals("7")) {
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio Recepcion de InfoVendedor");
			mVista.iniciarActividadConResultado(IRecepcionInformacion.class, Enumeradores.Solicitudes.SOLICITUD_RECIBIR, Enumeradores.Acciones.ACCION_RECIBIR_INFO_VENDEDOR);
		}else if (valorReferencia.getVavclave().equals("2"))
		{
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio AtenderClientes");
			mVista.finalizar();
			mVista.iniciarActividadConResultado(ISeleccionAgenda.class, Enumeradores.Solicitudes.SOLICITUD_ATENDER_CLIENTES, Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_DIA);
			// here is the try-comment at the end of this method
		}
		else if (valorReferencia.getVavclave().equals("4")) {
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio ConsultaIndicadores");
			mVista.iniciarActividad(IConsultaIndicadores.class, false);
		}else if (valorReferencia.getVavclave().equals("13"))
			mVista.mostrarActividades(ValoresReferencia.getValores("ACTROL", "Inventario"), "Inventario");
		else if (valorReferencia.getVavclave().equals("14")) {
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio EnvioDeInformacion"); ;
			mVista.iniciarActividad(IConsultaInvenario.class, false);
		}else if (valorReferencia.getVavclave().equals(String.valueOf(ACTROL.MOV_SIN_INV_SIN_VISITA))) {
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio MovSinInvSinvisita");
			mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO, null, false);
		}else if (valorReferencia.getVavclave().equals(String.valueOf(ACTROL.AJUSTES))) {
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio Ajustes");
			mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES, null, false);
		}else if (valorReferencia.getVavclave().equals(String.valueOf(ACTROL.DESCARGAS))) {
			/*Descargas*/
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio Descarga"); ;
			//Folio CAI 5869 Se valida que si el transprod tiene productos con envase se haya generado su contraparte de tipo devolucion, si no es el caso, se repite el proceso
			if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("RecAutoEnvVenta").equals("1")) {
				try {
					if (!Transacciones.verificarRecoleccionAutomaticaEnvase()) {
						mVista.mostrarError("No puede continuar debido a que se encontraron descuadres en envase.");
						return;
					}
				} catch (Exception ex) {
					mVista.mostrarError(ex.getMessage());
				}
			}
			//Folio CAI 5869
			mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA, null, false);
		}else if (valorReferencia.getVavclave().equals("22")) {
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio Preliquidacion");
			mVista.iniciarActividad(ICapturaPreLiquidacion.class, false);
		}else if (valorReferencia.getVavclave().equals("21")) {
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio ConteoInventario");
			mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_SELECCIONAR_CONTEO_INVENTARIO, null, false);
		}else if (valorReferencia.getVavclave().equals("23")) {
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio Depositarse");
			mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO, null, false);
		}else if (valorReferencia.getVavclave().equals(String.valueOf(ACTROL.DEVOLUCIONESALMACEN))) {
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio Devolucion"); ;
			/*Devoluciones al almacén*/
			mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION, null, false);
		}else if (valorReferencia.getVavclave().equals(String.valueOf(ACTROL.CARGAS))) {
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio Cargas"); ;
			mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS, null, false);
		}else if(valorReferencia.getVavclave().equals("26")) {
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio CapturaTraspaso");
			mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO, null, false);
		}else if (valorReferencia.getVavclave().equals("27")) {
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio CapturaKilometraje");
			if (validarEntrarKilometraje()) {
				mVista.iniciarActividad(ICapturaKilometraje.class, null, null, false);
			}
		}else if (valorReferencia.getVavclave().equals("28")) {
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio InicioJornada");
			if (validarFinalInicioJornada()) {
				mVista.iniciarActividad(ICapturaInicioFinJornada.class, null, null, false);
			}
		}else if (valorReferencia.getVavclave().equals("29")) {
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio Reportes");
            Sesion.set(Campo.FiltroTiposReportes, "'','NO DEFINIDO'");
            mVista.iniciarActividad(IConsultaReporte.class, null, null, false);
        }
        else if (valorReferencia.getVavclave().equals("31")) {
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio EnvioParcial");
            mVista.mostrarActividades(ValoresReferencia.getValores("ACTROL", "Envío Parcial"), "Envío Parcial");
        }
        else if (valorReferencia.getVavclave().equals("32"))
        {
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio Envio Agenda");
            final AlertDialog.Builder alert = new AlertDialog.Builder(mVista.getContext());
            alert.setTitle(Mensajes.get("P0243", "Enviar "+valorReferencia.getDescripcion().toString())).setPositiveButton(Mensajes.get("XSi"), new DialogInterface.OnClickListener()
            {
                public void onClick(DialogInterface dialog, int whichButton)
                {
                    Sesion.set(Campo.Envio_Mov_Sin_Inv_Sin_Visita,true);
                    mVista.iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_ENVIAR_MOV_SIN_INV_SIN_VISITA);
                }
            }).setNegativeButton(Mensajes.get("XNo"), new DialogInterface.OnClickListener()
            {
                public void onClick(DialogInterface dialog, int whichButton)
                {

                }
            });
            alert.show();
        }else if (valorReferencia.getVavclave().equals("33")) {
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio DepositoVinculado");
			mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO_VINCULADO, null, false);
		}else if (valorReferencia.getVavclave().equals("34")){
			BDVend.setOrigenLog("SeleccionActividadesVend:Inicio Gastos");
			mVista.iniciarActividad(ISeleccionAgenda.class, Enumeradores.Acciones.ACCION_MOSTRAR_GASTOS, null, false);
		}
	}

	/*public void obtenerInventarioEnLinea()
	{
		HashMap<String, String> parametros = new HashMap<String, String>();
		String tablasActualizar = "''Inventario''";
		parametros.put("Tablas", tablasActualizar);
		mVista.iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_RECIBIR_INFO_INVENTARIO, parametros);
	}*/

	/*
	 * // mVista.iniciarActividad(IImpresionTicket.class, //
	 * Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_CON_VISITA, null, // false);
	 * try { // here is the comment at the end of this class String valor =
	 * Envio.getDatosEnviar
	 * ("paroDataSet",Enumeradores.Acciones.ACCION_ENVIAR_BD_VENDEDOR
	 * ,Cliente.class); Envio.enviarTodo(valor); } catch (Exception e) { // TODO
	 * Auto-generated catch block e.printStackTrace(); }
	 */
	public void atras(String grupo)
	{
		if (grupo.equals("Principales"))
		{
			mVista.finalizar();
		}
		else if (grupo.equals("Actualizar"))
		{
			mVista.mostrarActividades(ValoresReferencia.getValores("ACTROL", "Principales"), "Principales");
		}
		else if (grupo.equals("Inventario"))
			mVista.mostrarActividades(ValoresReferencia.getValores("ACTROL", "Principales"), "Principales");
        else if (grupo.equals("Envío Parcial"))
            mVista.mostrarActividades(ValoresReferencia.getValores("ACTROL", "Actualizar"), "Actualizar");
	}

	public void mostrarMensaje(String mensaje)
	{
		mVista.mostrarError(Mensajes.get(mensaje));
	}

	public boolean validarEntrarKilometraje(){
		/*Este metodo sirve para validar si puede entrar al kilometraje siempre y cuando el inicio y fin de jornada este activo y se haya registrado el inicio jornada*/
		Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);

		if(vendedor.JornadaTrabajo){
			try {
				/*Dia dia = (Dia) Sesion.get(Campo.DiaActual);
				if(dia != null){
					VendedorJornada vendedorJornada = Consultas.ConsultasVendedorJornada.obtenerJornada(vendedor, dia);
					if (vendedorJornada != null){
						if (vendedorJornada.VEJFechaInicial != null) {
							return true;
						}
					}else{
						mVista.mostrarAdvertencia(Mensajes.get("E0984"));
						return false;
					}
				}else{*/
				VendedorJornada vendedorJornada = Consultas.ConsultasVendedorJornada.obtenerJornadaActual(vendedor);
				if (vendedorJornada != null){
					if (vendedorJornada.VEJFechaInicial != null) {
						return true;
					}
				}else{
					mVista.mostrarAdvertencia(Mensajes.get("E0984"));
					return false;
				}
				//}

			}
			catch (Exception e)
			{
				e.printStackTrace();
				mVista.mostrarError(e.getMessage());
				return false;
			}
		}

		return true;
	}

	public boolean validarFinalInicioJornada(){
		Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);

		if (vendedor.Kilometraje){
			try{
				VendedorJornada vendedorJornada = Consultas.ConsultasVendedorJornada.obtenerJornadaActual(vendedor);
				if (vendedorJornada == null) {
					return true;
				}

				CamionVendedor mCamionVendedor = Consultas.ConsultasKilometraje.obtenerCamionVendedor();
				if(mCamionVendedor == null || mCamionVendedor.KmInicial == 0.0){
					mVista.mostrarError(Mensajes.get("E0985"));
					return false;
				}else if(mCamionVendedor.KmFinal == 0.0){
					mVista.mostrarError(Mensajes.get("E0985"));
					return false;
				}

				return true;
			}catch(Exception ex){
				mVista.mostrarError(ex.getMessage());
				return false;
			}

		}

		return true;
	}
}
