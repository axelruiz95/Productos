package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=17)
public class CucCcu extends Entidad{

	@Llave
	@LlaveForanea(nombreCampoForaneo = "CUOClave", tablaPadre = Cuota.class)
	public String CUOClave;
	
	@Llave
	@LlaveForanea(nombreCampoForaneo = "", tablaPadre = Vendedor.class)
	public String VendedorId;
	
	@Llave
	@LlaveForanea(nombreCampoForaneo = "ClienteClave", tablaPadre = Cliente.class)
	public String ClienteClave;
	
	@Campo
	public float Cantidad;
	
	@Campo
	public Date MFechaHora;
	
	@Campo
	public String MUsuarioID;
	
	@Campo
	public boolean Enviado;
	
}
