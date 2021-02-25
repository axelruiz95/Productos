package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.presentadores.IVista;

public interface ICapturaMovSinInventario extends IVista
{
	void setHuboCambios(boolean cambio);

	void refrescarProductos(String TransProdId);

	//void mostrarUnidades(ISetDatos unidades);
	//void seleccionarProducto(String ProductoClave, String TipoUnidad);
	public void setFolio(String folio);

	public void setFecha(String fecha);
    public void setTipoMotivo(Short tipoMotivo);
    public Short getTipoMotivo();
    public void guardar(String sNombre, String sNombreArchivo);
	//public void setLimpiarMotivo();

}
