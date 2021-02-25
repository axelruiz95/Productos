package com.amesol.routelite.vistas;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.HashMap;

import android.app.Activity;
import android.app.SearchManager;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.AdapterView.AdapterContextMenuInfo;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.BaseAdapter;
import android.widget.CursorAdapter;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.ArrayAdapter;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ModuloMovDetalle;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.controles.TextBoxScanner;
import com.amesol.routelite.controles.TextBoxScanner.OnCodigoIngresadoListener;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.TipoEnvioInfo;
import com.amesol.routelite.presentadores.act.AtenderClientes;
import com.amesol.routelite.presentadores.act.SeleccionarActividadesVisita;
import com.amesol.routelite.presentadores.interfaces.IAtencionClientes;
import com.amesol.routelite.presentadores.interfaces.IAutorizaMovimiento;
import com.amesol.routelite.presentadores.interfaces.IConsultaIndicadores;
import com.amesol.routelite.presentadores.interfaces.IRegistroTiemposMuertos;
import com.amesol.routelite.presentadores.interfaces.IRevisionPendientes;
import com.amesol.routelite.presentadores.interfaces.IServidorComunicaciones;
import com.amesol.routelite.presentadores.parcelables.DatosGPS;
import com.amesol.routelite.utilerias.Generales;

public class AtencionClientes extends Vista implements IAtencionClientes
{

	AtenderClientes mPresenta;
	String sClienteClave;
	int tipoVista;
	boolean iniciarActividad;
	Class<?> actvdd;
	TextBoxScanner txtScanner;
	Vendedor oVendedor;
	CONHist oCONHist;
	Boolean optionsFlag = false;
	Boolean optionPlusFlag = false;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.atencion_clientes);
		deshabilitarBarra(true);

		getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);
		lblTitle.setText(Mensajes.get("XSeleccionar", Mensajes.get("XCliente")));

		// Get the intent, verify the action and get the query
		Intent intent = getIntent();
		String filtro = null;
		if (intent.getAction() != null && Intent.ACTION_SEARCH.equals(intent.getAction()))
		{
			filtro = intent.getStringExtra(SearchManager.USER_QUERY);
			mPresenta = new AtenderClientes(this, Intent.ACTION_SEARCH, Enumeradores.VistaClientes.VISTA_CLIENTES_NO_VISITADOS, filtro);
		}
		else
			mPresenta = new AtenderClientes(this, null, 0, null);

		ListView lista_1 = (ListView) findViewById(R.id.lstAgenda);
		registerForContextMenu(lista_1);

		txtScanner = (TextBoxScanner) findViewById(R.id.textBoxScanner);

		txtScanner.setOnCodigoIngresado(mCodigoBarras);

		mPresenta.validarTextCodigoBarra();
		HabilitarPantalla(true);

		iniciarActividad = false;
		oVendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
		oCONHist = (CONHist) Sesion.get(Campo.CONHist);
		mPresenta.iniciar();

		TextView lblDia = (TextView) findViewById(R.id.txtDia);
		TextView lblRuta = (TextView) findViewById(R.id.txtRuta);

		lblDia.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Campo.DiaActual)).DiaClave);
		lblRuta.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Campo.RutaActual)).Descripcion);
	}

	public void habilitaDeshabilitaCodigoBarras(boolean habilitado)
	{
		txtScanner.setEnabled(habilitado);
	}

	public void iniciar()
	{

	}

	public void reiniciarPantalla()
	{
		txtScanner.BorrarTexto();
	}

	private OnCodigoIngresadoListener mCodigoBarras = new OnCodigoIngresadoListener()
	{

		public void OnCodigoIngresado(String Codigo, int codigoLeido)
		{
			if (Codigo.length() == 0)
				return;

			HabilitarPantalla(false);
			sClienteClave = Codigo;
			mPresenta.seleccionarCodigoBarras(codigoLeido);

			HabilitarPantalla(true);
		}

	};

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if (requestCode == Enumeradores.Solicitudes.SOLICITUD_GPS)
		{

			if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
			{
				DatosGPS datosGps;
				datosGps = (DatosGPS) data.getExtras().getParcelable("Objeto");

				mPresenta.ValidarDatosGPS(datosGps);

			}
			else
			{
				mPresenta.SeleccionVisita();
			}
		}
		else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_AUTORIZARMOVIMIENTO)
		{
			if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
			{
				if (oVendedor.GPS && !(Boolean) mPresenta.obtenerParametros().get("bVisitado") && mPresenta.iniciarGPS())
					mPresenta.IniciarGPS();
				else
					mPresenta.SeleccionVisita();
			}
		}
		else if (requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES)
		{
			if (resultCode == Enumeradores.Resultados.RESULTADO_MAL)
			{
				if (data != null)
				{
					String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
					if (mensajeError != null)
					{
						finalizar();
						iniciarActividad(IAtencionClientes.class, mensajeError);
					}
				}
			}
		}
		/*
		 * else if(requestCode==
		 * Enumeradores.Solicitudes.SOLICITUD_AUTORIZARMOVIMIENTO) {
		 * if(resultCode== Enumeradores.Resultados.RESULTADO_BIEN) {
		 * if(oVendedor.GPS &&
		 * !(Boolean)mPresenta.obtenerParametros().get("bVisitado")) {
		 * mPresenta.IniciarGPS(); } else { mPresenta.SeleccionVisita(); } }
		 * else {
		 * 
		 * } }
		 */
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		mPresenta.validarTextCodigoBarra();
		if (respuesta.equals(RespuestaMsg.OK) && iniciarActividad) // iniciar
																	// visita o
																	// autorizacion
		{
			if (actvdd == IAutorizaMovimiento.class)
			{
				iniciarActividadConResultado(IAutorizaMovimiento.class, Enumeradores.Solicitudes.SOLICITUD_AUTORIZARMOVIMIENTO, Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA);
			}
			else
			{
				if ((oVendedor.GPS) && !(Boolean) mPresenta.obtenerParametros().get("bVisitado"))
				{
					mPresenta.IniciarGPS();
					return;
				}

				mPresenta.SeleccionVisita();
				// iniciarActividad(ISeleccionVisita.class,
				// Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA, null,
				// false);
			}

		}
		else if (tipoMensaje == 1)
		{
			if (respuesta.equals(RespuestaMsg.Si))
			{
				mPresenta.IniciarGPS();
				return;
			}
			else if (respuesta.equals(RespuestaMsg.No))
			{
				mPresenta.SeleccionVisita();
				// iniciarActividad(ISeleccionVisita.class,
				// Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA, null,
				// false);
			}
		}

		// iniciarActividad(IAutorizaMovimiento.class,
		// Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA, null, false);
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				mPresenta.toActividadesVed();
				this.finish();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{
		try
		{
			ValorReferencia[] mCliente = ValoresReferencia.getValores("ACTMAC");
			Arrays.sort(mCliente, new Comparator<ValorReferencia>()
			{
				@Override
				public int compare(ValorReferencia object1, ValorReferencia object2)
				{
					return Integer.valueOf(object1.getVavclave()).compareTo(Integer.valueOf(object2.getVavclave()));
				}
			});

			MenuInflater inflater = getMenuInflater();
			inflater.inflate(R.menu.menu_atencion_clientes, menu);

			for (int a = 0; a < mCliente.length; a++)
			{
				menu.getItem(a).setTitle(mCliente[a].getDescripcion());
			}

			if (!oVendedor.TiemposMuertos)
				menu.getItem(4).setVisible(false);

			if (oCONHist.get("EnvioParcial").equals("0"))
				menu.getItem(3).setVisible(false);

		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}

		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item)
	{
		switch (item.getItemId())
		{
			case R.id.menu1:
				ListView lista_2 = (ListView) findViewById(R.id.lstAgenda);
				optionPlusFlag = true;
				registerForContextMenu(lista_2);
				openContextMenu(lista_2);
				return true;
			case R.id.menu2:
				startSearch(null, false, null, false);
				// onSearchRequested();
				return true;
			case R.id.menu3:
				iniciarActividad(IConsultaIndicadores.class, false);
				return true;
			case R.id.menu4:
				HashMap<String, String> oParametros = new HashMap<String, String>();
				oParametros.put("TipoEnvioInfo", String.valueOf(TipoEnvioInfo.ENVIO_PARCIAL));
				iniciarActividadConResultado(IServidorComunicaciones.class, Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES, Enumeradores.Acciones.ACCION_ENVIAR_BD_VENDEDOR, oParametros);
				return true;
			case R.id.menu5:
				iniciarActividad(IRegistroTiemposMuertos.class, false);
				return true;
			case R.id.menu6:
				finalizar();
				iniciarActividad(IRevisionPendientes.class, false);
				return true;
			case R.id.menu7:
				mPresenta.crearCliente();
				return true;

			default:
				optionPlusFlag = true;
				return super.onOptionsItemSelected(item);
		}
	}

	@Override
	public void onNewIntent(final Intent newIntent)
	{
		super.onNewIntent(newIntent);

		final String queryAction = newIntent.getAction();
		if (Intent.ACTION_SEARCH.equals(queryAction))
		{
			if (newIntent.getData() != null)
			{
				sClienteClave = newIntent.getData().toString();
				mPresenta.seleccionar();
			}
			else
			{
				//				String s = newIntent.getStringExtra(SearchManager.QUERY);
			}
		}
	}

	//	private boolean mTakeEvent = false;
	//	private CountDownTimer mCountdownTillNextEvent;
	//	private boolean mTimerRunning = false;
	//	private int mPositionHolder = -1;
	//	private boolean mTakeSecond = false;

	private OnItemClickListener mSeleccion = new OnItemClickListener()
	{

		public void onItemClick(AdapterView<?> parent, View v, int position, long id)
		{
			// CODIGO PARA EL DOBLE CLICK
			/*
			 * if(!mTakeEvent) { mPositionHolder=position; //this will hold the
			 * position variable of the first event mTakeEvent=true; }
			 * if(mCountdownTillNextEvent==null && !mTimerRunning) {
			 * mTimerRunning=true; //signaling that timer is running
			 * mCountdownTillNextEvent = new
			 * CountDownTimer(ViewConfiguration.getDoubleTapTimeout(), 1)
			 * //default time in milliseconds between single and double tap
			 * (see: ViewConfiguration.getDoubleTapTimeout();) {
			 * 
			 * @Override public void onTick(long millisUntilFinished) {
			 * //Log.i("onTick", "Entry: "+ millisUntilFinished); }
			 * 
			 * @Override public void onFinish() { //when time expires reverting
			 * to non-clicked state mTakeEvent=false;
			 * mCountdownTillNextEvent=null; mTimerRunning=false;
			 * mPositionHolder=-1; //after this point, means that single tap
			 * occured. Do something } }; mCountdownTillNextEvent.start();
			 * //firing the countdown }else{ if(mCountdownTillNextEvent!=null &&
			 * mTimerRunning && mPositionHolder == position) { mTakeEvent=false;
			 * //reverting when to non clicked state when double tap on the
			 * listview item occurred mCountdownTillNextEvent=null;
			 * mTimerRunning=false; mTakeSecond=true; mPositionHolder =
			 * position; //do the processing here... HabilitarPantalla(false);
			 * Cursor cliente = (Cursor)parent.getItemAtPosition(position);
			 * cliente.moveToPosition(position); sClienteClave =
			 * cliente.getString(1);
			 * 
			 * mPresenta.seleccionar(); HabilitarPantalla(true); } }
			 */

			HabilitarPantalla(false);
			MOTConfiguracion oConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
			String clientesPedido = oConf.get("ClientesPedido").toString();
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && clientesPedido.equals("1")){
				ClientesVistaReparto cliente = (ClientesVistaReparto) parent.getItemAtPosition(position);
				sClienteClave = cliente.get_clienteClave();
			}else{
				Cursor cliente = (Cursor) parent.getItemAtPosition(position);
				cliente.moveToPosition(position);
				sClienteClave = cliente.getString(1);	
			}
			mPresenta.seleccionar();
			HabilitarPantalla(true);
		}
	};

	@Override
	public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo)
	{
		super.onCreateContextMenu(menu, v, menuInfo);
		MenuInflater inflater = getMenuInflater();

		if (optionPlusFlag)
			optionsFlag = true;
		else
			optionsFlag = false;

		if (v instanceof ListView && !optionsFlag)
		{
			inflater.inflate(R.menu.context_atencion_clientes, menu);

			menu.getItem(0).setTitle(Mensajes.get("XConsultar"));
			if (tipoVista == Enumeradores.VistaClientes.VISTA_CLIENTES_FUERA_FRECUENCIA || tipoVista == Enumeradores.VistaClientes.VISTA_CLIENTES_IMPRODUCTIVOS || tipoVista == Enumeradores.VistaClientes.VISTA_CLIENTES_NUEVOS)
				menu.getItem(1).setVisible(false);
			else
			{
				menu.getItem(1).setVisible(true);
				menu.getItem(1).setTitle(Mensajes.get("XNoVisitar"));
			}
		}
		else
		{
			inflater.inflate(R.menu.context_vistas, menu);
			menu.setHeaderTitle("Vistas");
			menu.getItem(0).setTitle(Mensajes.get("XClientesVisitados"));
			menu.getItem(1).setTitle(Mensajes.get("XClientesNoVisitados"));
			menu.getItem(2).setTitle(Mensajes.get("XClientesFueraFrecuencia"));
			menu.getItem(3).setTitle(Mensajes.get("MDB0125"));
			menu.getItem(4).setTitle(Mensajes.get("XClientesConMensajes"));
			menu.getItem(5).setTitle(Mensajes.get("XClientesConCobranza"));
			menu.getItem(6).setTitle(Mensajes.get("XClientesImproductivos"));
			menu.getItem(7).setTitle(Mensajes.get("XClientesNuevos"));
			menu.getItem(8).setTitle(Mensajes.get("XPorSurtir"));
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.REPARTO)
				menu.getItem(8).setVisible(false);	
			if (menu.size() > 9)
			{
				for (int i = 9; i < menu.size(); i++)
					menu.getItem(i).setVisible(false);
			}
			optionPlusFlag = false;
		}
	}

	@Override
	public boolean onContextItemSelected(MenuItem item)
	{
		AdapterContextMenuInfo info = null;
		Cursor cliente = null;
		if (item.getMenuInfo() != null)
		{
			info = (AdapterContextMenuInfo) item.getMenuInfo();
			ListView lista_3 = (ListView) findViewById(R.id.lstAgenda);
			
			MOTConfiguracion oConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
			String clientesPedido = oConf.get("ClientesPedido").toString();
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && clientesPedido.equals("1")){
				ClientesVistaReparto cli = (ClientesVistaReparto) lista_3.getItemAtPosition((int) info.position);
				sClienteClave = cli.get_clienteClave();
			}else{
				cliente = (Cursor) lista_3.getItemAtPosition((int) info.position);
				sClienteClave = cliente.getString(1);
			}
		}

		switch (item.getItemId())
		{
			case R.id.consultar:
				mPresenta.consultarCliente();
				return true;
			case R.id.novisitar:
				mPresenta.mostrarImproductividadCliente();
				return true;

				// ********************** vistas
				// **********************************
			case R.id.visitados:
				mPresenta.mostrarClientes(Enumeradores.VistaClientes.VISTA_CLIENTES_VISITADOS, null);

				return true;
			case R.id.novisitados:

				mPresenta.mostrarClientes(Enumeradores.VistaClientes.VISTA_CLIENTES_NO_VISITADOS, null);

				return true;
			case R.id.fuerafrecuencia:
				mPresenta.mostrarClientes(Enumeradores.VistaClientes.VISTA_CLIENTES_FUERA_FRECUENCIA, null);
				return true;
			case R.id.todos:
				mPresenta.mostrarClientes(Enumeradores.VistaClientes.VISTA_CLIENTES_TODOS, null);
				return true;
			case R.id.conmensaje:
				mPresenta.mostrarClientes(Enumeradores.VistaClientes.VISTA_CLIENTES_CON_MENSAJE, null);
				return true;
			case R.id.concobranza:
				mPresenta.mostrarClientes(Enumeradores.VistaClientes.VISTA_CLIENTES_CON_COBRANZA, null);
				return true;
			case R.id.improductivos:
				mPresenta.mostrarClientes(Enumeradores.VistaClientes.VISTA_CLIENTES_IMPRODUCTIVOS, null);
				return true;
			case R.id.nuevos:
				mPresenta.mostrarClientes(Enumeradores.VistaClientes.VISTA_CLIENTES_NUEVOS, null);
				return true;
			case R.id.porsusrtir:
				mPresenta.mostrarClientes(Enumeradores.VistaClientes.VISTA_CLIENTES_POR_SURTIR, null);
				return true;

			default:
				return super.onOptionsItemSelected(item);
		}

	}

	@SuppressWarnings("deprecation")
	public void mostrarClientes(ISetDatos clientes, int vista)
	{
		TextView lblTitulo = (TextView) findViewById(R.id.txtTitulo);

		switch (vista)
		{
			case Enumeradores.VistaClientes.VISTA_CLIENTES_NO_VISITADOS:
				lblTitulo.setText(Mensajes.get("XClientesNoVisitados") + ": " + clientes.getCount());
				break;
			case Enumeradores.VistaClientes.VISTA_CLIENTES_VISITADOS:
				lblTitulo.setText(Mensajes.get("XClientesVisitados") + ": " + clientes.getCount());
				break;
			case Enumeradores.VistaClientes.VISTA_CLIENTES_FUERA_FRECUENCIA:
				lblTitulo.setText(Mensajes.get("XClientesFueraFrecuencia") + ": " + clientes.getCount());
				break;
			case Enumeradores.VistaClientes.VISTA_CLIENTES_TODOS:
				lblTitulo.setText(Mensajes.get("MDB0125") + ": " + clientes.getCount());
				break;
			case Enumeradores.VistaClientes.VISTA_CLIENTES_CON_MENSAJE:
				lblTitulo.setText(Mensajes.get("XClientesConMensajes") + ": " + clientes.getCount());
				break;
			case Enumeradores.VistaClientes.VISTA_CLIENTES_CON_COBRANZA:
				lblTitulo.setText(Mensajes.get("XClientesConCobranza") + ": " + clientes.getCount());
				break;
			case Enumeradores.VistaClientes.VISTA_CLIENTES_IMPRODUCTIVOS:
				lblTitulo.setText(Mensajes.get("XClientesImproductivos") + ": " + clientes.getCount());
				break;
			case Enumeradores.VistaClientes.VISTA_CLIENTES_NUEVOS:
				lblTitulo.setText(Mensajes.get("XClientesNuevos") + ": " + clientes.getCount());
				break;
			case Enumeradores.VistaClientes.VISTA_CLIENTES_POR_SURTIR:
				lblTitulo.setText(Mensajes.get("XPorSurtir") + ": " + clientes.getCount());
				break;
			default:
				break;
		}

		tipoVista = vista;

		ListView lista_4 = (ListView) findViewById(R.id.lstAgenda);

		Cursor cClientes = (Cursor) clientes.getOriginal();
		startManagingCursor(cClientes);
		try
		{
			MOTConfiguracion oConf = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
			String clientesPedido = oConf.get("ClientesPedido").toString();
			if(Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && clientesPedido.equals("1")){
				//si es reparto y esta habilitado el parametro clientes pedido, cambiar el adapter para mostrar con fondo gris los clientes con pedidos
				if(cClientes.getCount() != 0){
					ArrayList<ClientesVistaReparto> cli = new ArrayList<AtencionClientes.ClientesVistaReparto>();
					while(cClientes.moveToNext()){
						ClientesVistaReparto nuevo = new ClientesVistaReparto(cClientes.getString(cClientes.getColumnIndex(SearchManager.SUGGEST_COLUMN_TEXT_1)), cClientes.getString(cClientes.getColumnIndex("Contacto")), cClientes.getString(cClientes.getColumnIndex(SearchManager.SUGGEST_COLUMN_TEXT_2)), cClientes.getInt(cClientes.getColumnIndex("PedidosXSurtir")), cClientes.getString(cClientes.getColumnIndex(SearchManager.SUGGEST_COLUMN_INTENT_DATA)));
						cli.add(nuevo);
					}
					ClientesVistaReparto[] clientesReparto = cli.toArray(new ClientesVistaReparto[cli.size()]);
					
					ClientesAdapter adpt = new ClientesAdapter(this, R.layout.lista_simple3, clientesReparto);
					lista_4.setAdapter(adpt);	
				}else{
					lista_4.setAdapter(null);
				}
			}else{
				SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple3, cClientes, new String[]
						{ SearchManager.SUGGEST_COLUMN_TEXT_1, "Contacto", SearchManager.SUGGEST_COLUMN_TEXT_2 }, new int[]
						{ R.id.texto1, R.id.texto2, R.id.texto3 });
				lista_4.setAdapter(adapter);
			}
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}
		lista_4.setOnItemClickListener(mSeleccion);

	}

	public String getCliente()
	{
		// TODO Auto-generated method stub
		return sClienteClave;
	}

	public void HabilitarPantalla(Boolean Habilitado)
	{
		ListView lista_5 = (ListView) findViewById(R.id.lstAgenda);
		lista_5.setClickable(Habilitado);
		txtScanner.setClickable(Habilitado);
		lista_5.setEnabled(Habilitado);
		txtScanner.setEnabled(Habilitado);
		this.doevents();

	}

	public void mostrarMensajeEiniciarActividad(String mensaje, Class<?> actividad)
	{
		iniciarActividad = true;
		actvdd = actividad;
		mostrarAdvertencia(mensaje);
	}

	//	private void ocultarTeclado()
	//	{
	//		InputMethodManager imm = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
	//		TextView texto = (TextView) findViewById(R.id.txtScanner);
	//		imm.hideSoftInputFromWindow(texto.getWindowToken(), 0);
	//	}
	
	
	//*********************************** adapter y vista para cambiar el fondo a color gris, solo se usa en reparto
	
	private static class ClientesVistaReparto{
		private String _clienteClave;
		private String _texto1;
		private String _texto2;
		private String _texto3;
		private int _pedidosXsurtir;
		
		public ClientesVistaReparto(String texto1, String texto2, String texto3, int pedidoXsurtir, String clienteClave){
			_texto1 = texto1;
			_texto2 = texto2;
			_texto3 = texto3;
			_pedidosXsurtir = pedidoXsurtir;
			_clienteClave = clienteClave;
		}

		public String get_texto1()
		{
			return _texto1;
		}

		public String get_texto2()
		{
			return _texto2;
		}

		public String get_texto3()
		{
			return _texto3;
		}

		public int get_pedidosXsurtir()
		{
			return _pedidosXsurtir;
		}
		
		public String get_clienteClave()
		{
			return _clienteClave;
		}
	}
	
	private class ClientesAdapter extends ArrayAdapter<ClientesVistaReparto>{
		
		int textViewResourceId;
		Context context;
		ClientesVistaReparto[] clientes;
		
		public ClientesAdapter(Context context, int textViewResourceId, ClientesVistaReparto[] objects){
			super(context,textViewResourceId,objects);
			this.context = context;
			this.textViewResourceId = textViewResourceId;
			this.clientes = objects;
		}

		@Override
		public int getViewTypeCount()
		{
			return clientes.length;
		}

		@Override
		public int getItemViewType(int position)
		{
			return position;
		}

		@Override
		public View getView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			if(convertView == null){
				LayoutInflater inflater = ((Activity) context).getLayoutInflater();
				view = inflater.inflate(textViewResourceId, null);
			}
			
			ClientesVistaReparto cli = clientes[position];
			
			TextView texto1 = (TextView) view.findViewById(R.id.texto1);
			texto1.setText(cli.get_texto1());
			
			TextView texto2 = (TextView) view.findViewById(R.id.texto2);
			texto2.setText(cli.get_texto2());
			
			TextView texto3 = (TextView) view.findViewById(R.id.texto3);
			texto3.setText(cli.get_texto3());
			
			if(cli.get_pedidosXsurtir() != 0){
				view.setBackgroundColor(getResources().getColor(R.color.lightGray));
			}
			
			return view;
		}
		
	}
}