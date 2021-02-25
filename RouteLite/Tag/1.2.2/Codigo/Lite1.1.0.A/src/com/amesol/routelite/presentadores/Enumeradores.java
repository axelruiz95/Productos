package com.amesol.routelite.presentadores;

public final class Enumeradores
{

	public final class Resultados
	{
		public final static int RESULTADO_MAL = 0;
		public final static int RESULTADO_BIEN = 1;
		public final static int RESULTADO_TERMINAR = 2;
	}

	public final class TipoBD
	{
		public final static int BD_TERMINAL = 0;
		public final static int BD_VENDEDOR = 1;
	}

	public final class TipoEnvioInfo
	{
		public final static int ENVIO_JORNADA = 0;
		public final static int ENVIO_PARCIAL = 1;
		public final static int ENVIO_PENDIENTES_VENDEDOR=2;
	}
	public final class Solicitudes
	{
		public final static int SOLICITUD_SERVIDOR_COMUNICACIONES = 0;
		public final static int SOLICITUD_CONFIGURACION = 1;
		public final static int SOLICITUD_AGENDA = 2;
		public static final int SOLICITUD_RECIBIR = 3;
		public static final int SOLICITUD_ATENDER_CLIENTES = 4;
		public static final int SOLICITUD_GPS = 5;
		public static final int SOLICITUD_AUTORIZARMOVIMIENTO = 6;
		public static final int SOLICITUD_BUSQUEDA_PRODUCTOS = 7;
		public static final int SOLICITUD_MOSTRAR_PROMOCIONES_APLICADAS = 8;
		public static final int SOLICITUD_MOSTRAR_TOTALES = 9;
		public static final int SOLICITUD_MOSTRAR_CAPTURA_PEDIDO = 10;
		public static final int SOLICITUD_MOSTRAR_CANCELAR_PEDIDO = 11;
		public static final int SOLICITUD_ABONO_DETALLE = 12;
		public static final int SOLICITUD_CAMBIOS_PRODUCTO_ENTRADA = 13;
		public static final int SOLICITUD_CAMBIAR_PRODUCTO_SALIDA = 14;
		public static final int SOLICITUD_MOSTRAR_PEDIDO_SUGERIDO = 15;
		public final static int SOLICITUD_SERVIDOR_COMUNICACIONES_ENVIO_PARCIAL = 16;
		public static final int SOLICITUD_ELIMINAR_AJUSTE_INV = 17;
		public static final int SOLICITUD_ELIMINAR_DESCARGA_INV = 18;
		public static final int SOLICITUD_ELIMINAR_DEV_ALMACEN = 19;
		public static final int SOLICITUD_MOSTRAR_TOTALES_CONSIGNACION = 20;
		public static final int SOLICITUD_LIQUIDAR_CONSIGNACION = 21;
	}

	public final class Acciones
	{
		public final static String ACCION_AGENDA_VENDEDOR = "AGVEN";
		public final static String ACCION_CONFIGURAR_PUERTOS = "CONFPUER";
		public final static String ACCION_OBTENER_BD_TERMINAL = "OBDT";
		public final static String ACCION_OBTENER_BD_VENDEDOR = "OBDV";
		public static final String ACCION_ENVIAR_BD_VENDEDOR = "EBDV";
		public final static String ACCION_RECIBIR_INFO_TERMINAL = "REINFTE";
		public final static String ACCION_RECIBIR_INFO_VENDEDOR = "REINFVE";
		public final static String ACCION_RECIBIR_INFO_INVENTARIO = "REINFIN";
		public final static String ACCION_ATENDER_CLIENTES_DIA = "ACDIA";
		public final static String ACCION_ATENDER_CLIENTES_RUTA = "ACRUTA";
		public final static String ACCION_ATENDER_CLIENTES_CLIENTE = "ACCLI";
		public final static String ACCION_CONSULTAR_CLIENTE = "CONCLI";
		public final static String ACCION_IMPRIMIR_TICKET_CON_VISITA = "ITCV";
		public final static String ACCION_IMPRIMIR_TICKET_SIN_VISITA = "ITSV";
		public final static String ACCION_VISITAR_CLIENTE_CLIENTE = "VISCLI";
		public final static String ACCION_VISITAR_CLIENTE_VISITA = "VCVIS";
		public final static String ACCION_AUTORIZAR_MOVIMIENTO = "AUMOV";
		public final static String ACCION_NO_VISITAR_CLIENTE = "NOVISCLI";
		public final static String ACCION_NO_VENTA = "NOVISI";
		public final static String ACCION_OBTENER_GPS = "OBTGPS";
		public final static String ACCION_OBTENER_PRODUCTOS_SELECCIONADOS = "OBTPRO";
		public final static String ACCION_APLICAR_PROMOCIONES = "APLPRO";
		public final static String ACCION_APLICAR_TOTALES = "APLTOT";
		public final static String ACCION_MOSTRAR_SOLO_LECTURA = "MOSSOL";
		public final static String ACCION_CANCELAR_PEDIDO = "CANPED";
		public final static String ACCION_SELECCIONAR_COBRANZA = "SELCOB";
		public final static String ACCION_CONSULTAR_COBRANZA = "CONCOB";
		public final static String ACCION_GENERAR_COBRANZA = "GENCOB";
		public final static String ACCION_CANCELAR_COBRANZA = "CANCOB";
		public final static String ACCION_RECIBIR_PENDIENTES = "REINFPE";
		public final static String ACCION_MOSTRAR_PEDIDOS = "MOSPED";
		public final static String ACCION_MOSTRAR_CAMBIOS = "MOSCAM";
		public final static String ACCION_MOSTRAR_DEVOLUCIONES = "MOSDEV";
		public final static String ACCION_CAMBIOS_PRODUCTO_ENTRADA = "CAMENT";
		public final static String ACCION_CAMBIAR_PRODUCTO_SALIDA = "CAMSAL";
		public final static String ACCION_CAPTURAR_SUGERIDO = "CAPSUG";
		public final static String ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO = "CAPMSI";
		public final static String ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO_RUTA = "CAPMSIR";
		public final static String ACCION_CAPTURAR_AJUSTES = "CAI";
		public final static String ACCION_CAPTURAR_AJUSTES_RUTA = "CAIR";
		public final static String ACCION_CAPTURAR_DESCARGA = "CDI";
		public final static String ACCION_CAPTURAR_DESCARGA_RUTA = "CDIR";
		public final static String ACCION_CAPTURAR_DEPOSITO = "CDE";
		public final static String ACCION_CAPTURAR_DEPOSITO_RUTA = "CDER";
		public final static String ACCION_CAPTURAR_DEVOLUCION = "CDEV";
		public final static String ACCION_CAPTURAR_DEVOLUCION_RUTA = "CDEVR";
		public final static String ACCION_CAPTURAR_CARGAS = "CCAD";
		public final static String ACCION_CAPTURAR_CARGAS_RUTA = "CCAR";
		public final static String ACCION_CAPTURAR_CARGAS_NO_MODIFICAR = "CCADN";
		public final static String ACCION_CAPTURAR_CARGAS_ELIMINAR = "CCADE";
		public final static String ACCION_MOSTRAR_PEDIDOS_POR_SURTIR = "MOSPEDPS";
		public final static String ACCION_CAPTURAR_MOV_SIN_INV_EN_VISITA = "CAPMSIVIS";
		public final static String ACCION_MOSTRAR_MOV_SIN_INV_EN_VISITA = "MOSMSIVIS";
		public final static String ACCION_MOSTRAR_CONSIGNACIONES = "MOSCON";
		public final static String ACCION_CAPTURAR_CONSIGNACIONES = "CAPCONSIG";
		public static final String ACCION_ELIMINAR_CONSIGNACIONES = "ELIMCONS";
		public static final String ACCION_LIQUIDAR_CONSIGNACION = "LIQCONS";
	}

	public enum RespuestaMsg
	{
		Si, No, OK
	}

	public final class VistaClientes
	{
		public final static int VISTA_CLIENTES_VISITADOS = 0;
		public final static int VISTA_CLIENTES_NO_VISITADOS = 1;
		public final static int VISTA_CLIENTES_FUERA_FRECUENCIA = 2;
		public final static int VISTA_CLIENTES_TODOS = 3;
		public final static int VISTA_CLIENTES_CON_MENSAJE = 4;
		public final static int VISTA_CLIENTES_CON_COBRANZA = 5;
		public final static int VISTA_CLIENTES_IMPRODUCTIVOS = 6;
		public final static int VISTA_CLIENTES_NUEVOS = 7;
		public final static int VISTA_CLIENTES_POR_SURTIR = 8;
		public final static int VISTA_CLIENTES_NO_VISITADOS_REC = 9;
	}

	public final class TiposModulos
	{
		public final static int NO_DEFINIDO = 0;
		public final static int VENTA = 1;
		public final static int PREVENTA = 2;
		public final static int REPARTO = 3;
	}

	public final class TiposTransProd
	{
		public final static int PEDIDO = 1;
		public final static int CARGAS = 2;
		public final static int DEVOLUCIONES_CLIENTE = 3;
		public final static int DEVOLUCIONES_MANUALES = 4;
		public final static int AJUSTES = 6;
		public final static int DESCARGAS = 7;
		public final static int CAMBIOS = 9;
		public final static int FONDO_CRISTAL = 18;
		public final static int MOV_SIN_INV_SV = 19;
		public final static int MOV_SIN_INV_EV = 21;
		public final static int INVENTARIO_A_BORDO = 23;
		public final static int VENTA_CONSIGNACION = 24;
	}

	/*
	 * Cancelado
	 * 
	 * '''<comentarios/> Captura
	 * 
	 * '''<comentarios/> Surtido
	 * 
	 * '''<comentarios/> Facturado
	 * 
	 * '''<comentarios/> Impreso
	 * 
	 * '''<comentarios/> Transferir
	 * 
	 * '''<comentarios/> Liquidado
	 * 
	 * '''<comentarios/> CapturaEscritorio
	 * 
	 * '''<comentarios/> CaneladaLiquidacion
	 */
	public final class TiposFasesDocto
	{
		public final static int CANCELADO = 0;
		public final static int CAPTURA = 1;
		public final static int SURTIDO = 2;
		public final static int FACTURADO = 3;
		public final static int IMPRESO = 4;
		public final static int TRANSFERIR = 5;
		public final static int LIQUIDADO = 6;
		public final static int CAPTURA_ESCRITORIO = 7;
		public final static int CANCELADA_LIQUIDACION = 8;
	}

	public final class TiposModuloMovDetalle
	{
		public final static int NO_DEFINIDO = 0;
		public final static int NO_VENTA = 1;
		public final static int PAGOS = 6;
		public final static int DEVOLUCIONMANUALES = 8;
		public final static int PEDIDO = 9;
		public final static int CARGAS = 10;
		public final static int AJUSTES = 11;
		public final static int DESCARGAS = 15;
		public final static int DEVOLUCIONCLIENTES = 13;
		public final static int CAMBIOS = 14;
		public final static int MOV_SIN_INV_CON_VISITA = 22;
		public final static int MOV_SIN_INV_SIN_VISITA = 23;
		public final static int IMPRESION = 28;
		public final static int COBRANZAMULTIPLE = 30;
		public final static int CONSIGNACION = 26;

		// public final static int NO_DEFINIDO = 0;
		// public final static int PEDIDO = 9;
		// public final static int DEVOLUCIONCLIENTES = 13;
		// public final static int CAMBIOS = 14;
		// public final static int IMPRESION = 0;
		// public final static int COBRANZAMULTIPLE = 30;
	}

	public final class TiposMovimientos
	{
		public final static int NO_DEFINIDO = 0;
		public final static int ENTRADA = 1;
		public final static int SALIDA = 2;
		public final static int PEDIDO = 3;
	}

	public final class FormasDeVenta
	{
		public final static int CONTADO = 1;
		public final static int CREDITO = 2;
	}

	public final class FormasDePago
	{
		public final static int EFECTIVO = 1;
		public final static int CHEQUE = 2;
		public final static int OTRO = 3;
		public final static int NO_IDENTIFICADO = 4;
	}

	public final class ACTROL
	{	
		public final static int MOV_SIN_INV_SIN_VISITA = 15;
		public final static int AJUSTES = 16;
		public final static int DESCARGAS = 17;
		public final static int RECARGAS = 18;
		public final static int DEVOLUCIONESALMACEN = 24;
		public final static int CARGAS = 25;
	}
	
	public final class TipoFecha{
		public final static int DIA_EXACTO = 1;
		public final static int DIA_DE_LA_SEMANA = 2;
		public final static int DIA_MES = 3;
	}
	
	public final class TipoPedido{
		public final static int NO_DEFINIDO = 0;
		public final static int NORMAL = 1;
		public final static int POSFECHADO = 2;
		public final static int ESTIMADO = 3;
		public final static int CONSIGNACION = 4;
	}
}