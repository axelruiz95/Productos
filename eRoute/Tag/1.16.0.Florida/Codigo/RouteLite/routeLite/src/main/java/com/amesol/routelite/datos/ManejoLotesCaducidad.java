package com.amesol.routelite.datos;
import java.util.Date;
import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.LlaveForanea;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;

@TablaDef(orden=11)
public class ManejoLotesCaducidad extends Entidad
{
    @Llave
    public String TransProdID;

    @Llave
    public String TransProdDetalleID;

    @Campo
    public String Lote;

    @Campo
    public Date Caducidad;

    @Campo
    public Date MFechaHora;

    @Campo
    public String MUsuarioID;

    @Campo
    public boolean Enviado;
}