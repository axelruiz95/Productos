package com.amesol.routelite.presentadores.act;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

import android.R;
import android.text.method.DateTimeKeyListener;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.CFVHist;
import com.amesol.routelite.datos.CLIFormaVenta;
import com.amesol.routelite.datos.CenCli;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ClienteDomicilio;
import com.amesol.routelite.datos.ClienteEsquema;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Secuencia;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.INuevoCliente;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;
import com.amesol.routelite.utilerias.ParametroMSG;
import com.amesol.routelite.vistas.generico.DialogoAlerta;

public class CrearCliente extends Presentador
{

	INuevoCliente mVista;
	Cliente oCliente;
	ClienteEsquema oCteEsquema;
	ClienteDomicilio oCteDomicilio;
	CLIFormaVenta oCLIFormaVenta;
	CFVHist oCFVHist;
	CenCli oCenCli;
	String clave;
	Cliente oClienteModelo;
	boolean bErrPuntoEntrega = true;

	public CrearCliente(INuevoCliente vista)
	{
		mVista = vista;
	}

	public boolean getErrPuntoEntrega()
	{
		return bErrPuntoEntrega;
	}

	@Override
	public void iniciar()
	{			try{
					String sRUTClave = ((Ruta)Sesion.get(Campo.RutaActual)).RUTClave;
					Vendedor oVendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
					Integer logClaveNumerica = 4;
					try {
						if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("LongitudClaveNumericaCteNvo")) {
							logClaveNumerica = Integer.parseInt(((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("LongitudClaveNumericaCteNvo"));
						}
					}catch(Exception ex){
						if (ex !=null && ex.getMessage() != null){
							mVista.mostrarError(ex.getMessage());
						}else{
							mVista.mostrarError("Error al obtener parámetro LongitudClaveNumericaCteNvo");
						}
					}
		//String.format("%010s",1234567);
					clave = sRUTClave + String.format("%0" + logClaveNumerica + "d", (short) (Consultas.ConsultasRuta.getFolioClteNvo() + 1));
					if (oVendedor.ClienteModelo != null && !oVendedor.ClienteModelo.equals("")){
						oClienteModelo = new Cliente();
						oClienteModelo.ClienteClave = oVendedor.ClienteModelo;
						BDVend.recuperar(oClienteModelo);
						if (!oClienteModelo.isRecuperado()){
							throw new Exception(Mensajes.get("E0259", "Cliente Modelo: " + oClienteModelo.ClienteClave));
						}
					}
			}catch(Exception ex){
				mVista.mostrarError(ex.getMessage());
			}
			
			mVista.setClave(clave);
	}

	public void GuardarCliente() throws ControlError
	{
		// try{
		Usuario usuario = (Usuario) Sesion.get(Campo.UsuarioActual);
		Date fechaActual = Generales.getFechaActual();
		String sClienteDomicilioIDVisita = "";
		// Datos generales
		oCliente = new Cliente();
		oCliente.ClienteClave = KeyGen.getId();
		oCliente.Clave = clave;
		oCliente.IdElectronico = mVista.getCodigoBarras();
		oCliente.IdFiscal = (mVista.getRFC() != null ? mVista.getRFC().toUpperCase() : null);
		oCliente.RazonSocial = (mVista.getRazonSocial() != null ? mVista.getRazonSocial().toUpperCase() : null);
		oCliente.NombreContacto = (mVista.getContacto() != null ? mVista.getContacto().toUpperCase() : null);
		oCliente.TelefonoContacto = mVista.getTelefono();
		oCliente.DatosExtra = mVista.getDatosExtra();
		oCliente.FechaRegistroSistema = mVista.getFechaRegistro();
		oCliente.FechaNacimiento = mVista.getFechaNacimiento();
		if(mVista.getNombre() != null) {
			oCliente.NombreCorto = (mVista.getNombre() != null ? mVista.getNombre().toUpperCase() : null);
		}else {
			oCliente.NombreCorto = (mVista.getRazonSocial() != null ? (mVista.getRazonSocial().toUpperCase().length()>32 ? mVista.getRazonSocial().toUpperCase().substring(0,31): mVista.getRazonSocial().toUpperCase()) : null);
		}
		oCliente.TipoEstado = 1;
		oCliente.Prestamo = mVista.getPrestamoEnvase();
		oCliente.Exclusividad = mVista.getExclusividad();
		oCliente.VigExclusividad = mVista.getVigExclusividad();
		oCliente.FechaFactura = fechaActual;
		oCliente.DesgloseImpuesto = mVista.getDesglosaImpuestos();
		oCliente.ExigirOrdenCompra = mVista.getExigirOrdenCompra();
		oCliente.MFechaHora = Generales.getFechaHoraActual();
		oCliente.MUsuarioID = usuario.Clave;
		oCliente.Enviado = false;

		if (oClienteModelo != null && oClienteModelo.isRecuperado()){
			oCliente.TipoFiscal = oClienteModelo.TipoFiscal;
			oCliente.TipoImpuesto = oClienteModelo.TipoImpuesto;

			oCliente.ActualizaSaldoCheque = oClienteModelo.ActualizaSaldoCheque;
			oCliente.VencimientoVenta = oClienteModelo.VencimientoVenta;
			oCliente.ExigirTomaInvMer = oClienteModelo.ExigirTomaInvMer;
			oCliente.LimiteEnvase = oClienteModelo.LimiteEnvase;
			oCliente.ValidarLimEnvase = oClienteModelo.ValidarLimEnvase;
			oCliente.ValidaFolNeg = oClienteModelo.ValidaFolNeg;
		}else {
			oCliente.TipoFiscal = 1;
			oCliente.TipoImpuesto = 1;
			oCliente.ActualizaSaldoCheque = false;
			oCliente.VencimientoVenta = false;
			oCliente.ExigirTomaInvMer = false;
			oCliente.LimiteEnvase = 0;
			oCliente.ValidarLimEnvase = false;
			oCliente.ValidaFolNeg = false;
		}
		oCliente.validar();

		if (oClienteModelo != null && oClienteModelo.isRecuperado()){
			try {
				BDVend.recuperar(oClienteModelo, ClienteEsquema.class);
				if(oClienteModelo.ClienteEsquema !=null){
					for(ClienteEsquema oCteEsquemaMod : oClienteModelo.ClienteEsquema){
						oCteEsquema = new ClienteEsquema();
						oCteEsquema.ClienteClave = oCliente.ClienteClave;
						oCteEsquema.EsquemaId = oCteEsquemaMod.EsquemaId;
						oCteEsquema.Baja = false;
						oCteEsquema.Enviado = false;
						oCteEsquema.MFechaHora = Generales.getFechaHoraActual();
						oCteEsquema.MUsuarioID = usuario.Clave;
						oCliente.ClienteEsquema.add(oCteEsquema);
						oCteEsquema.validar();
					}
				}
			}catch (Exception ex){
				if (ex!=null && ex.getMessage()!=null){
					mVista.mostrarError("Error al recuperar los esquemas de cliente: " + ex.getMessage());
				}else{
					mVista.mostrarError("Error al recuperar los esquemas de cliente. ");
				}
			}
		}else {
			// Esquema de clientes nuevos
			oCteEsquema = new ClienteEsquema();
			oCteEsquema.ClienteClave = oCliente.ClienteClave;
			oCteEsquema.EsquemaId = Consultas.ConsultasEsquema.obtenerIdEsquemaCteNuevo();
			oCteEsquema.Baja = false;
			oCteEsquema.Enviado = false;
			oCteEsquema.MFechaHora = Generales.getFechaHoraActual();
			oCteEsquema.MUsuarioID = usuario.Clave;
			oCliente.ClienteEsquema.add(oCteEsquema);
			oCteEsquema.validar();
		}

		// Punto de Entrega
		if (mVista.getCapturoPuntoEntrega())
		{
			oCteDomicilio = new ClienteDomicilio();
			oCteDomicilio.ClienteClave = oCliente.ClienteClave;
			oCteDomicilio.ClienteDomicilioId = KeyGen.getId();
			oCteDomicilio.Tipo = 2;
			oCteDomicilio.Calle = (mVista.getCallePE() != null ? mVista.getCallePE().toUpperCase() : null);
			oCteDomicilio.Numero = mVista.getNumeroExtPE();
			oCteDomicilio.NumInt = mVista.getNumeroIntPE();
			oCteDomicilio.CodigoPostal = mVista.getCodigoPostalPE();
			oCteDomicilio.ReferenciaDom = (mVista.getReferenciaPE() != null ? mVista.getReferenciaPE().toUpperCase() : null);
			oCteDomicilio.Colonia = (mVista.getColoniaPE() != null ? mVista.getColoniaPE().toUpperCase() : null);
			oCteDomicilio.Localidad = (mVista.getMunicipioPE() != null ? mVista.getMunicipioPE().toUpperCase() : null);
			oCteDomicilio.Poblacion = (mVista.getMunicipioPE() != null ? mVista.getMunicipioPE().toUpperCase() : null);
			oCteDomicilio.Entidad = (mVista.getEntidadPE() != null ? mVista.getEntidadPE().toUpperCase() : null);
			oCteDomicilio.Pais = (mVista.getPaisPE() != null ? mVista.getPaisPE().toUpperCase() : null);
			oCteDomicilio.Enviado = false;
			oCteDomicilio.MFechaHora = Generales.getFechaHoraActual();
			oCteDomicilio.MUsuarioID = usuario.Clave;
			oCliente.ClienteDomicilio.add(oCteDomicilio);
			bErrPuntoEntrega = true;
			oCteDomicilio.validar();
			sClienteDomicilioIDVisita = oCteDomicilio.ClienteDomicilioId;
		}
		else
		{
			ArrayList<ParametroMSG> params = new ArrayList<ParametroMSG>();
			params.add(new ParametroMSG("XVisita", true));
			throw new ControlError("E0018", params);
		}

		if (mVista.getCapturoDomFiscal())
		{
			// Domicilio Fiscal
			oCteDomicilio = new ClienteDomicilio();
			oCteDomicilio.ClienteClave = oCliente.ClienteClave;
			oCteDomicilio.ClienteDomicilioId = KeyGen.getId();
			oCteDomicilio.Tipo = 1;
			oCteDomicilio.Calle = (mVista.getCalleDF() != null ? mVista.getCalleDF().toUpperCase() : null);
			oCteDomicilio.Numero = mVista.getNumeroExtDF();
			oCteDomicilio.NumInt = mVista.getNumeroIntDF();
			oCteDomicilio.CodigoPostal = mVista.getCodigoPostalDF();
			oCteDomicilio.ReferenciaDom = (mVista.getReferenciaDF() != null ? mVista.getReferenciaDF().toUpperCase() : null);
			oCteDomicilio.Colonia = (mVista.getColoniaDF() != null ? mVista.getColoniaDF().toUpperCase() : null);
			oCteDomicilio.Localidad = (mVista.getMunicipioDF() != null ? mVista.getMunicipioDF().toUpperCase() : null);
			oCteDomicilio.Poblacion = (mVista.getMunicipioDF() != null ? mVista.getMunicipioDF().toUpperCase() : null);
			oCteDomicilio.Entidad = (mVista.getEntidadDF() != null ? mVista.getEntidadDF().toUpperCase() : null);
			oCteDomicilio.Pais = (mVista.getPaisDF() != null ? mVista.getPaisDF().toUpperCase() : null);
			oCteDomicilio.Enviado = false;
			oCteDomicilio.MFechaHora = Generales.getFechaHoraActual();
			oCteDomicilio.MUsuarioID = usuario.Clave;
			oCliente.ClienteDomicilio.add(oCteDomicilio);
			bErrPuntoEntrega = false;
			oCteDomicilio.RequeridosFiscal = oCliente.DesgloseImpuesto;
			oCteDomicilio.validar();
		}
		else if (oCliente.DesgloseImpuesto)
		{
			ArrayList<ParametroMSG> params = new ArrayList<ParametroMSG>();
			params.add(new ParametroMSG("XFiscal", true));
			throw new ControlError("E0018", params);
		}

		// Forma de venta Efectivo
		if (oClienteModelo != null && oClienteModelo.isRecuperado()){
			try {
				BDVend.recuperar(oClienteModelo, CLIFormaVenta.class);
				if(oClienteModelo.CLIFormaVenta !=null){
					for(CLIFormaVenta oCFVModelo : oClienteModelo.CLIFormaVenta){
						oCLIFormaVenta = new CLIFormaVenta();
						oCLIFormaVenta.ClienteClave = oCliente.ClienteClave;
						oCLIFormaVenta.CFVTipo = oCFVModelo.CFVTipo;
						oCLIFormaVenta.LimiteCredito = oCFVModelo.LimiteCredito;
						oCLIFormaVenta.DiasCredito = oCFVModelo.DiasCredito;
						oCLIFormaVenta.Inicial = oCFVModelo.Inicial;
						oCLIFormaVenta.CapturaDias = oCFVModelo.CapturaDias;
						oCLIFormaVenta.ValidaLimite = oCFVModelo.ValidaLimite;
						oCLIFormaVenta.ValidaPago = oCFVModelo.ValidaPago;
						oCLIFormaVenta.Estado = oCFVModelo.Estado;
						oCLIFormaVenta.Enviado = false;
						oCLIFormaVenta.MFechaHora = Generales.getFechaHoraActual();
						oCLIFormaVenta.MUsuarioID = usuario.Clave;
						oCLIFormaVenta.validar();

						oCFVHist = new CFVHist();
						oCFVHist.ClienteClave = oCliente.ClienteClave;
						oCFVHist.CFVTipo = oCFVModelo.CFVTipo;
						oCFVHist.CFHFechaInicio = Generales.getFechaHoraActual();
						oCFVHist.LimiteCredito = oCFVModelo.LimiteCredito;
						oCFVHist.DiasCredito = oCFVModelo.DiasCredito;
						oCFVHist.CapturaDias = oCFVModelo.CapturaDias;
						oCFVHist.ValidaLimite = oCFVModelo.ValidaLimite;
						oCFVHist.ValidaPago = oCFVModelo.ValidaPago;
						oCFVHist.Enviado = false;
						oCFVHist.MFechaHora = Generales.getFechaHoraActual();
						oCFVHist.MUsuarioID = usuario.Clave;
						oCFVHist.validar();

						oCLIFormaVenta.CFVHist.add(oCFVHist);
						oCliente.CLIFormaVenta.add(oCLIFormaVenta);
					}
				}
			}catch (Exception ex){
				if (ex!=null && ex.getMessage()!=null){
					mVista.mostrarError("Error al recuperar los esquemas de cliente: " + ex.getMessage());
				}else{
					mVista.mostrarError("Error al recuperar los esquemas de cliente. ");
				}
			}
		}else {
			oCLIFormaVenta = new CLIFormaVenta();
			oCLIFormaVenta.ClienteClave = oCliente.ClienteClave;
			oCLIFormaVenta.CFVTipo = 1;
			oCLIFormaVenta.LimiteCredito = 0;
			oCLIFormaVenta.DiasCredito = 0;
			oCLIFormaVenta.Inicial = true;
			oCLIFormaVenta.CapturaDias = false;
			oCLIFormaVenta.ValidaLimite = false;
			oCLIFormaVenta.ValidaPago = false;
			oCLIFormaVenta.Estado = 1;
			oCLIFormaVenta.Enviado = false;
			oCLIFormaVenta.MFechaHora = Generales.getFechaHoraActual();
			oCLIFormaVenta.MUsuarioID = usuario.Clave;
			oCLIFormaVenta.validar();

			// Historico de forma de venta
			oCFVHist = new CFVHist();
			oCFVHist.ClienteClave = oCliente.ClienteClave;
			oCFVHist.CFVTipo = 1;
			oCFVHist.CFHFechaInicio = Generales.getFechaHoraActual();
			oCFVHist.LimiteCredito = 0;
			oCFVHist.DiasCredito = 0;
			oCFVHist.CapturaDias = false;
			oCFVHist.ValidaLimite = false;
			oCFVHist.ValidaPago = false;
			oCFVHist.Enviado = false;
			oCFVHist.MFechaHora = Generales.getFechaHoraActual();
			oCFVHist.MUsuarioID = usuario.Clave;
			oCFVHist.validar();

			oCLIFormaVenta.CFVHist.add(oCFVHist);
			oCliente.CLIFormaVenta.add(oCLIFormaVenta);
		}

		List<String> lstFrecuencias = mVista.getFrecuenciasSeleccionadas();
		if (lstFrecuencias.size()>0){
			HashMap<String, Integer> hmSecOrden = mVista.getSecuenciaOrden();
			try {
				for (String frecuenciaClave : lstFrecuencias) {
					Secuencia oSEC = new Secuencia();
					oSEC.SECId = KeyGen.getId();
					oSEC.ClienteClave = oCliente.ClienteClave;
					oSEC.ClienteDomicilioID = sClienteDomicilioIDVisita;
					oSEC.RUTClave = ((Ruta) Sesion.get(Campo.RutaActual)).RUTClave;
					oSEC.FrecuenciaClave = frecuenciaClave;
					if (hmSecOrden.containsKey(frecuenciaClave)) {
						oSEC.Orden = hmSecOrden.get(frecuenciaClave);
					} else {
						oSEC.Orden = 1;
					}
					oSEC.Enviado = false;
					oSEC.MFechaHora = Generales.getFechaHoraActual();
					oSEC.MUsuarioID = usuario.Clave;
					BDVend.guardarInsertar(oSEC);
				}
			}catch(Exception ex){
				if (ex!=null && ex.getMessage()!=null) {
					throw new ControlError(ex.getMessage());
				}else{
					throw new ControlError("Error al guardar la secuencia");
				}
			}
		}else{
			ArrayList<ParametroMSG> params = new ArrayList<ParametroMSG>();
			params.add(new ParametroMSG("XDiaVisita", true));
			throw new ControlError("E0215", params);
		}

		ISetDatos dtEncuestas = null;
		if (oClienteModelo != null && oClienteModelo.isRecuperado()){
			try
			{
				dtEncuestas = Consultas.ConsultasEncuesta.obtenerEncuestasCte(oClienteModelo.ClienteClave);
			}
			catch (Exception e)
			{
				e.printStackTrace();
			}
		}else{
			try
			{
				dtEncuestas = Consultas.ConsultasEncuesta.obtenerEncuestasCteNuevo();
			}
			catch (Exception e)
			{
				e.printStackTrace();
			}
		}
		if (dtEncuestas != null)
		{
			while (dtEncuestas.moveToNext())
			{
				oCenCli = new CenCli();
				oCenCli.CENClave = dtEncuestas.getString(0);
				oCenCli.ClienteClave = oCliente.ClienteClave;
				oCenCli.Puntos = dtEncuestas.getShort(1);
				oCenCli.IniAplicacion = dtEncuestas.getDate(2);
				oCenCli.FinAplicacion = dtEncuestas.getDate(3);
				oCenCli.Enviado = false;
				oCenCli.MFechaHora = Generales.getFechaHoraActual();
				oCenCli.MUsuarioID = usuario.Clave;
				oCliente.CenCli.add(oCenCli);
				oCenCli.validar();
			}
			dtEncuestas.close();
		}

		try
		{
			BDVend.guardarInsertar(oCliente);
			Consultas.ConsultasRuta.setNewFolioClienteNvo(((Ruta) Sesion.get(Campo.RutaActual)).RUTClave, (short) (Consultas.ConsultasRuta.getFolioClteNvo() + 1));
			BDVend.commit();
			mVista.finalizar();
			// return true;
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
			try
			{
				BDVend.rollback();
			}
			catch (Exception ex)
			{
				e.printStackTrace();
				mVista.mostrarError(ex.getMessage());
			}
			// return false;
		}
	}

}
