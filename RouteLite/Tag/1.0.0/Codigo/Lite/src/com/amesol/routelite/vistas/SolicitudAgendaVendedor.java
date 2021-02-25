package com.amesol.routelite.vistas;

import java.util.Date;

import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.SolicitarAgendaVendedor;
import com.amesol.routelite.presentadores.interfaces.ISolicitudAgendaVendedor;

public class SolicitudAgendaVendedor extends Vista implements ISolicitudAgendaVendedor
{

	SolicitarAgendaVendedor mPresenta;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.solicitud_agenda_vendedor);
		deshabilitarBarra(true);
		TextView texto = (TextView) findViewById(R.id.lblFechaInicial);
		texto.setText(Mensajes.get("PRMFechaInicial"));
		texto = (TextView) findViewById(R.id.lblFechaFinal);
		texto.setText(Mensajes.get("PRMFechaFinal"));
		Button boton = (Button) findViewById(R.id.btnContinuar2);
		boton.setText(Mensajes.get("BtContinuar"));
		boton.setOnClickListener(mContinuar);
		setTitulo(Mensajes.get("XSolicitarAgenda"));

		mPresenta = new SolicitarAgendaVendedor(this);
		mPresenta.iniciar();
	}

	private OnClickListener mContinuar = new OnClickListener()
	{

		public void onClick(View v)
		{
			DatePicker dp = (DatePicker) findViewById(R.id.dpFechaInicial);

			dp.requestFocus();
			mPresenta.solicitarAgenda();
		}
	};

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
					iniciarActividad(ISolicitudAgendaVendedor.class, mensajeError);
					return;
				}
			}
			iniciarActividad(ISolicitudAgendaVendedor.class);

		}
		else
		{
			this.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finish();
			// Sesion.set(Campo.CONHist, new CONHist());
			// iniciarActividad(ISeleccionActividadesVend.class);
		}
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		// TODO Auto-generated method stub

	}

	public void iniciar()
	{
		// TODO Auto-generated method stub

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

	@SuppressWarnings("deprecation")
	public Date getFechaInicial()
	{
		DatePicker fecha = (DatePicker) findViewById(R.id.dpFechaInicial);
		return new Date(fecha.getYear() - 1900, fecha.getMonth(), fecha.getDayOfMonth());
	}

	@SuppressWarnings("deprecation")
	public Date getFechaFinal()
	{
		DatePicker fecha = (DatePicker) findViewById(R.id.dpFechaFinal);
		return new Date(fecha.getYear() - 1900, fecha.getMonth(), fecha.getDayOfMonth());
	}

	@SuppressWarnings("deprecation")
	public void setFechaInicial(Date fecha)
	{
		DatePicker control = (DatePicker) findViewById(R.id.dpFechaInicial);
		control.updateDate(fecha.getYear(), fecha.getMonth(), fecha.getDay());
	}

	@SuppressWarnings("deprecation")
	public void setFechaFinal(Date fecha)
	{
		DatePicker control = (DatePicker) findViewById(R.id.dpFechaFinal);
		control.updateDate(fecha.getYear(), fecha.getMonth(), fecha.getDay());
	}

}