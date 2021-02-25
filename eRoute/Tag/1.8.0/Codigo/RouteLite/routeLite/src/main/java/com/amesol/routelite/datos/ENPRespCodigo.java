package com.amesol.routelite.datos;

import java.util.Date;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=1)
public class ENPRespCodigo extends Entidad
{
  @Llave	
  @Campo
  public String ENCId;
  
  @Llave	
  @Campo
  public String ENPId;
  
  @Llave	
  @Campo
  public String ERCId;
  
  @Campo 
  public String Codigo;
  
  @Campo 
  public Date MFechaHora;
  
  @Campo
  public String MUsuarioId;

    @Campo
    public boolean Enviado;
}