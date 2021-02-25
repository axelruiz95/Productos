package com.amesol.routelite.providers;

import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.VistaClientes;

import android.content.ContentProvider;
import android.content.ContentValues;
import android.content.Intent;
import android.database.Cursor;
import android.net.Uri;

public class ClienteProvider extends ContentProvider {
	
	//IAtencionClientes mVista;
	//AtenderClientes mPresenta;

	@Override
	public int delete(Uri arg0, String arg1, String[] arg2) {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public String getType(Uri arg0) {
		// TODO Auto-generated method stub 
		return null;
	}

	@Override
	public Uri insert(Uri arg0, ContentValues arg1) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public boolean onCreate() {
		// TODO Auto-generated method stub
		//mPresenta = new AtenderClientes(mVista, Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_CLIENTE);
		return true;
	}

	@Override
	public Cursor query(Uri arg0, String[] arg1, String arg2, String[] arg3,
			String arg4) {
		// TODO Auto-generated method stub
		String filtro = null;
		if (arg0.getPathSegments().size() > 1)
			filtro = arg0.getLastPathSegment();
		if((filtro!=null)&&(filtro.length()> 2))
		{
			try
			{
				//ISetDatos dsCli = Consultas.ConsultasCliente.obtenerNoVisitados((Dia)Sesion.get(Campo.DiaActual), (Ruta)Sesion.get(Campo.RutaActual), filtro);
				ISetDatos dsCli = buscarClientes(Integer.parseInt(Sesion.get(Campo.VistaAtualClientes).toString()), filtro);
				return (Cursor)dsCli.getOriginal();
			}
			catch (Exception e)
			{
				e.printStackTrace();
				return null;
			}
		}
		return null;
	}

	@Override
	public int update(Uri arg0, ContentValues arg1, String arg2, String[] arg3) {
		// TODO Auto-generated method stub
		return 0;
	}
	
	public ISetDatos buscarClientes(int vista, String filtro) throws Exception
	{
		switch (vista)
		{
			case Enumeradores.VistaClientes.VISTA_CLIENTES_NO_VISITADOS:
				return Consultas.ConsultasCliente.obtenerNoVisitados((Dia) Sesion.get(Campo.DiaActual), (Ruta) Sesion.get(Campo.RutaActual), filtro);
			case Enumeradores.VistaClientes.VISTA_CLIENTES_VISITADOS:
				return Consultas.ConsultasCliente.obtenerVisitados((Dia) Sesion.get(Campo.DiaActual), (Ruta) Sesion.get(Campo.RutaActual), filtro);
			case Enumeradores.VistaClientes.VISTA_CLIENTES_FUERA_FRECUENCIA:
				return Consultas.ConsultasCliente.obtenerFueraFrecuencia((Dia) Sesion.get(Campo.DiaActual), (Ruta) Sesion.get(Campo.RutaActual), filtro);
			case Enumeradores.VistaClientes.VISTA_CLIENTES_TODOS:
				return Consultas.ConsultasCliente.obtenerTodos((Dia) Sesion.get(Campo.DiaActual), (Ruta) Sesion.get(Campo.RutaActual), filtro);
			case Enumeradores.VistaClientes.VISTA_CLIENTES_CON_MENSAJE:
				return Consultas.ConsultasCliente.obtenerConMensaje(filtro);
			case Enumeradores.VistaClientes.VISTA_CLIENTES_CON_COBRANZA:
				return Consultas.ConsultasCliente.obtenerConCobranza((Dia) Sesion.get(Campo.DiaActual), (Ruta) Sesion.get(Campo.RutaActual), filtro);
			case Enumeradores.VistaClientes.VISTA_CLIENTES_IMPRODUCTIVOS:
				return Consultas.ConsultasCliente.obtenerImproductivos((Dia) Sesion.get(Campo.DiaActual), (Ruta) Sesion.get(Campo.RutaActual), filtro);
			case Enumeradores.VistaClientes.VISTA_CLIENTES_NUEVOS:
				return Consultas.ConsultasCliente.obtenerNuevos(filtro);
			case Enumeradores.VistaClientes.VISTA_CLIENTES_POR_SURTIR:
				return Consultas.ConsultasCliente.obtenerPorSurtir((Dia) Sesion.get(Campo.DiaActual), (Ruta) Sesion.get(Campo.RutaActual), filtro);
			case VistaClientes.VISTA_CLIENTES_NO_VISITADOS_REC:
				return Consultas.ConsultasCliente.obtenerNoVisitadosRec((Dia) Sesion.get(Campo.DiaActual), (Ruta) Sesion.get(Campo.RutaActual), filtro);
		}
		return null;
	}

}