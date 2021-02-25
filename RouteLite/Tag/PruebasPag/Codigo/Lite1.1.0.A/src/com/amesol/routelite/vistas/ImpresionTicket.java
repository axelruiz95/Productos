package com.amesol.routelite.vistas;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.util.Log;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.ImprimirTicket;
import com.amesol.routelite.presentadores.interfaces.IImpresionTicket;
import com.amesol.routelite.utilerias.ControlError;

public class ImpresionTicket extends Vista implements IImpresionTicket
{

	ImprimirTicket mPresenta;
	String accion;
	String error;

	public static final int PREGUNTA_REINTENTAR_IMPRESION = 99;
	List<Map<String, String>> mDocumentosSeleccionados;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);

		accion = getIntent().getAction();
		setContentView(R.layout.seleccion_transaccion);
		deshabilitarBarra(true);

		setTitulo(Mensajes.get("XImpresion"));
		if (!accion.equals(Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_CON_VISITA))
		{
			TextView lblCliente = (TextView) findViewById(R.id.lblCliente);
			lblCliente.setVisibility(View.GONE);
			TextView lblRuta = (TextView) findViewById(R.id.lblRuta);
			lblRuta.setVisibility(View.GONE);
			TextView lblDia = (TextView) findViewById(R.id.lblDia);
			lblDia.setVisibility(View.GONE);
		}

		Button boton = (Button) findViewById(R.id.btnContinuar);
		boton.setText(Mensajes.get("BtContinuar"));
		boton.setOnClickListener(mContinuar);
		setTitulo(Mensajes.get("MDB0212"));

		mPresenta = new ImprimirTicket(this, accion);
		mPresenta.iniciar();
	}

	@Override
	public void onResume()
	{
		super.onResume();

	}

	@Override
	public void onWindowFocusChanged(boolean hasFocus)
	{
		super.onWindowFocusChanged(hasFocus);
		if (error != null)
		{
			mostrarError(error);
			error = null;
		}
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{

		//		String accion = getIntent().getAction();
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.menu_solo_salir, menu);
		menu.getItem(0).setTitle(Mensajes.get("BTSalir"));
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item)
	{

		switch (item.getItemId())
		{
			case R.id.salir:
				finish();
				return false;
			default:
				return super.onOptionsItemSelected(item);
		}
	}

	private OnClickListener mContinuar = new OnClickListener()
	{

		public void onClick(View v)
		{
			mDocumentosSeleccionados = getDocumentosSeleccionados();
			if (mDocumentosSeleccionados.size() > 0)
			{
				try
				{
					if (!bluetoothEncendido())
					{
						encenderBluetooth();
					}
					else
					{
						imprimirRecibos();
					}
					//getVista().mostrarAdvertencia("Recibos generados");
				}
				catch (ControlError e)
				{
					e.Mostrar(getVista());
				}
				catch (Exception e)
				{
					getVista().mostrarError(e.getMessage());
				}
			}
			else
			{
				mostrarAdvertencia(Mensajes.get("E0161", Mensajes.get("XMovimiento")));
			}
		}
	};

	private Vista getVista()
	{
		return this;
	}

	private void imprimirRecibos() throws Exception
	{
		Recibos recibos = new Recibos();
		recibos.imprimirRecibos(mDocumentosSeleccionados, false, mPresenta.getIVista());
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES) && (resultCode == Enumeradores.Resultados.RESULTADO_MAL))
		{
			if (data != null)
			{
				String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
				if (mensajeError != null)
				{
					error = mensajeError;
					return;
				}
			}
			finish();
		}
		else if (requestCode == REQUEST_ENABLE_BT)
		{
			if (resultCode == RESULT_OK)
			{
				try
				{
					imprimirRecibos();
				}
				catch (ControlError e)
				{
					e.Mostrar(getVista());
				}
				catch (Exception e)
				{
					getVista().mostrarError(e.getMessage());
				}

			}
			else
			{
				mostrarError("No se pudo encender el BT");
			}
			return;
		}
		else
		{
			finish();
		}

	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				this.finish();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	/*
	 * private OnItemClickListener mSeleccionarItem = new OnItemClickListener()
	 * { public void onItemClick(AdapterView<?> parent, View v, int position,
	 * long id) { ValorReferenciaAdapter adapter = (ValorReferenciaAdapter)
	 * parent.getAdapter(); adapter.setChecked(v,position);
	 * 
	 * } };
	 */
	public void iniciar()
	{
		// TODO Auto-generated method stub

	}

	public void presentarDocumentos(String accion, Cursor datosDocumentos) throws Exception
	{
		try
		{
			List<Map<String, String>> tabla = new ArrayList<Map<String, String>>();
			Map<String, String> registro;

			String descValor = "";
			while (datosDocumentos.moveToNext())
			{
				registro = new HashMap<String, String>();
				for (int i = 0; i < datosDocumentos.getColumnCount(); i++)
				{
					registro.put(datosDocumentos.getColumnName(i), datosDocumentos.getString(i));
				}
				NumberFormat numberFormat = new DecimalFormat("$#,##0.00");
				registro.put("Total", numberFormat.format(datosDocumentos.getDouble(datosDocumentos.getColumnIndex("Total"))));
				descValor = ValoresReferencia.getDescripcion(datosDocumentos.getString(datosDocumentos.getColumnIndex("VARCodigo")), datosDocumentos.getString(datosDocumentos.getColumnIndex("Tipo")));
				registro.put("DescTipo", descValor);
				registro.put("TipoRecibo", mPresenta.obtenerTipoRecibo(registro));
				tabla.add(registro);
			}

			ListView lista = (ListView) findViewById(R.id.lstTransaccion);

			ListAdapter adapter = new SimpleAdapter(this, tabla, R.layout.lista_impresion,
					new String[]
					{ "DescTipo", "Folio", "Fecha", "Total" },
					new int[]
					{ R.id.lbTipo, R.id.lbFolio, R.id.lbFecha, R.id.lbTotal });

			lista.setAdapter(adapter);
		}
		catch (Exception ex)
		{
			throw new Exception(ex);
		}
	}

	@SuppressWarnings("unchecked")
	public List<Map<String, String>> getDocumentosSeleccionados()
	{
		ListView lista = (ListView) findViewById(R.id.lstTransaccion);
		ListAdapter adapter = lista.getAdapter();

		List<Map<String, String>> tabla = new ArrayList<Map<String, String>>();
		for (int i = 0; i < lista.getChildCount(); i++)
		{
			CheckBox chbItem = (CheckBox) lista.getChildAt(i).findViewById(R.id.chkSeleccion);

			if (chbItem.isChecked())
			{
				tabla.add((Map<String, String>) adapter.getItem(i));
			}
		}

		return tabla;
	}

	@Override
	public void setCliente(String cliente)
	{
		if (accion.equals(Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_CON_VISITA))
		{
			TextView texto = (TextView) findViewById(R.id.lblCliente);
			texto.setText(cliente);
		}
	}

	@Override
	public void setRuta(String ruta)
	{
		if (accion.equals(Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_CON_VISITA))
		{
			TextView texto = (TextView) findViewById(R.id.lblRuta);
			texto.setText(Mensajes.get("XRuta") + ": " + ruta);
		}
	}

	@Override
	public void setDia(String dia)
	{
		if (accion.equals(Enumeradores.Acciones.ACCION_IMPRIMIR_TICKET_CON_VISITA))
		{
			TextView texto = (TextView) findViewById(R.id.lblDia);
			texto.setText(Mensajes.get("XDiaTrabajo") + ": " + dia);
		}
	}
	
	@Override
	public void impresionFinalizada(boolean impresionExitosa,String mensajeError)
	{
		/* Al finalizar la impresion no salimos */
		Log.i("IMPRESION_TICKETS", "Impresion finalizada: "+impresionExitosa);
		quitarProgreso();
	}

}