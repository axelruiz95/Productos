package com.duxstar.dacza.presentadores.interfaces;

import android.database.Cursor;

//import com.duxstar.dacza.actividades.Productos;
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.presentadores.IVista;

public interface IBuscaCliente extends IVista{
    void mostrarClientes(ISetDatos clientes);
    String getCliente();
    void HabilitarPantalla(Boolean Habilitado);
    void mostrarMensajeEiniciarActividad(String mensaje, Class <?> actividad);
    void reiniciarPantalla();
    void habilitaDeshabilitaCodigoBarras(boolean habilitado);
}