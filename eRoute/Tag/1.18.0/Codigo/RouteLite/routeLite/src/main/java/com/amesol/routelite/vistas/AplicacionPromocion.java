package com.amesol.routelite.vistas;

import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.actividades.ListaPrecio;
import com.amesol.routelite.actividades.ManejoEnvase;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.PromocionDetalle;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.Promocion;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.TiposModuloMovDetalle;
import com.amesol.routelite.presentadores.act.AplicarPromocion;
import com.amesol.routelite.presentadores.interfaces.IAplicacionPromocion;
import com.amesol.routelite.vistas.generico.AplicaPromoDetalleAdapter;
import com.amesol.routelite.vistas.generico.AplicaPromoDetalleAdapter.onCambioCantidadListener;

import java.util.ArrayList;
import java.util.HashMap;

public class AplicacionPromocion extends Vista implements IAplicacionPromocion
{

	AplicarPromocion mPresenta;
	String mAccion;
	Integer cantidadGrupo;
	Integer cantidadMax;
	Promocion oPromocion;
    String cadenaListasPrecios;
    String productoDisparador;
	boolean bIniciando = false;
	boolean bValidarExistencia = false;
	int tipoValidarExistencia = TiposValidacionInventario.NoValidar;
	HashMap<String, TransProdDetalle> seleccionRegalos = new HashMap<String, TransProdDetalle>();
	boolean errorInventario = false;
    boolean bEsVisible = false;

	final class TipoRespuestaMensaje{
		public static final int PENDIENTE_ENTREGA = 1;
	}


    PromocionDetalle promocionDetalle[];

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();
			setContentView(R.layout.aplicar_promociones);
			deshabilitarBarra(true);

			setTitulo(Mensajes.get("XPromociones"));

			//windowSoftInputMode
			mPresenta = new AplicarPromocion(this, mAccion);

			HashMap<String, Object> oParametros = null;
			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
				oPromocion = new Promocion();
				oPromocion.PromocionClave = (String) oParametros.get("PromocionClave");
                oPromocion.PromocionReglaIdApp=(String) oParametros.get("PromocionReglaID");
				BDVend.recuperar(oPromocion);
				
				cantidadGrupo = (Integer) oParametros.get("CantidadGrupo");
				cantidadMax =(Integer) oParametros.get("CantidadMax");
				tipoValidarExistencia = (Integer) oParametros.get("TipoValidarExistencia");
                if (oParametros.containsKey("ProductoDisparador")) {
                    productoDisparador = (String) oParametros.get("ProductoDisparador");
                }
                if (oParametros.containsKey("CadenaListasPrecio")) {
                    cadenaListasPrecios = (String) oParametros.get("CadenaListasPrecio");
                }
				mPresenta.setParametros(oParametros);
			}

            if (oPromocion.TipoAplicacion == com.amesol.routelite.actividades.Enumeradores.Promocion.TipoAplicacion.Canje){
				String productosDisparadores ="";
				if (oPromocion.Tipo == com.amesol.routelite.actividades.Enumeradores.Promocion.Tipo.ProductoAcumulado || (oPromocion.Tipo == com.amesol.routelite.actividades.Enumeradores.Promocion.Tipo.EsquemaProducto && !oPromocion.AplicaReglaPorProducto)){
					productosDisparadores = oPromocion.ListadoProductosAcumulados;
				}else{
					productosDisparadores = "'" + productoDisparador + "' ";
				}

                promocionDetalle = Consultas.ConsultasPromocion.obtenerVistaDetalle(oPromocion, cantidadGrupo, productosDisparadores);
                if (promocionDetalle != null ) {
                    String productoSinPrecio = "";
                    ArrayList<PromocionDetalle> detalleConPrecio = new ArrayList<PromocionDetalle>();
                    for (PromocionDetalle promoDet: promocionDetalle){
                        StringBuilder sPrecioClave = new StringBuilder();
                        float nPrecio = ListaPrecio.BuscarPrecio(promoDet.getProductoClave(), (short) promoDet.getPRUTipoUnidad(), cadenaListasPrecios, sPrecioClave, promoDet.getCantidad());
                        if (nPrecio >= 0) {
                            detalleConPrecio.add(promoDet);
                            promoDet.setPrecio(nPrecio);
                            promoDet.setPrecioClave(sPrecioClave.toString());
                        }else{
                            productoSinPrecio = promoDet.getProductoClave() + ", ";
                        }
                    }
                    if (detalleConPrecio.size() <=0 ){
                        setResultado(Enumeradores.Resultados.RESULTADO_MAL,"SinPrecio" + oPromocion.PromocionClave);
                        finalizar();
                        return;
                    }
                    if (productoSinPrecio.length() >0){
                        productoSinPrecio = productoSinPrecio.substring(0, productoSinPrecio.length() -2);
                        mostrarError(Mensajes.get("I0301", productoSinPrecio, oPromocion.PromocionClave));
                    }
                    if (detalleConPrecio.size() < promocionDetalle.length){
                        promocionDetalle = detalleConPrecio.toArray(new PromocionDetalle[detalleConPrecio.size()]);
                    }
                }
            }
            TextView texto = (TextView) findViewById(R.id.lblPrmDescripcion);
			texto.setText(oPromocion.Nombre);

			boolean inventarioPorLotes = false;
			try {
				inventarioPorLotes = (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("InventarioPorLotes") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("InventarioPorLotes").equals("1"));
			}catch(Exception e){}

			if(inventarioPorLotes)
				oPromocion.SeleccionProducto = true;

			if (oPromocion.SeleccionProducto){
				texto = (TextView) findViewById(R.id.lblTotal);
				texto.setText(Mensajes.get("XTotal"));
			}else{
				texto = (TextView) findViewById(R.id.lblTotal);
				texto.setVisibility(View.GONE);
			}
			
			if (oPromocion.CapturaCantidad){
				texto = (TextView) findViewById(R.id.lblMaximo);
				texto.setText(Mensajes.get("PMRMaximo"));
				
				texto = (TextView) findViewById(R.id.txtMaximo);
				texto.setText(String.valueOf(cantidadMax * cantidadGrupo));
			}else{
				texto = (TextView) findViewById(R.id.lblMaximo);
				texto.setVisibility(View.GONE);
				texto = (TextView) findViewById(R.id.txtMaximo);
				texto.setVisibility(View.GONE);
			}
        
            if ((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA && ((Ruta)Sesion.get(Campo.RutaActual)).Inventario ) || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA && Integer.parseInt(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString()) != TiposModuloMovDetalle.MOV_SIN_INV_CON_VISITA) || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO  && Integer.parseInt(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString()) == TiposModuloMovDetalle.PEDIDO)) {
            	bValidarExistencia = true;
            }
			
			Button btn = (Button) findViewById(R.id.btnContinuar);
			btn.setText(Mensajes.get("BtContinuar"));
			btn.setOnClickListener(mContinuar);

			mPresenta.iniciar();
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}
	}

    @Override
    public void onWindowFocusChanged(boolean hasFocus)
    {

        super.onWindowFocusChanged(hasFocus);

        if (hasFocus)
            if (!bEsVisible)
            {
                ListView listaPromo = (ListView) findViewById(R.id.lstPromo);
                listaPromo.requestFocusFromTouch();
                listaPromo.setSelection(0);
                listaPromo.clearFocus();
                if(listaPromo.getAdapter() != null) {
                    ((AplicaPromoDetalleAdapter) listaPromo.getAdapter()).seleccionarPrimero();
                    //getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);
                }
                //if(!bBusquedaSimple) {
                //eCantidades.get(0).requestFocus();
                //}
                bEsVisible = true;
            }
    }

	public void mostrarProductosPromocion()
	{
		ListView listaPromo = (ListView) findViewById(R.id.lstPromo);
		listaPromo.setDescendantFocusability(ViewGroup.FOCUS_BEFORE_DESCENDANTS);
		listaPromo.setChoiceMode(1);
		listaPromo.setClickable(false);
		//Esta linea afecta la seleccion del edit text en versiones superiores a 7.1 de android
		//getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);

		try
		{
			bIniciando = true;
			AplicaPromoDetalleAdapter adapter;
            if (promocionDetalle == null) { //En las promos de Canje se obtiene, por eso se busca
				String productosDisparadores ="";
				if (oPromocion.Tipo == com.amesol.routelite.actividades.Enumeradores.Promocion.Tipo.ProductoAcumulado || (oPromocion.Tipo == com.amesol.routelite.actividades.Enumeradores.Promocion.Tipo.EsquemaProducto && !oPromocion.AplicaReglaPorProducto)){
					productosDisparadores = oPromocion.ListadoProductosAcumulados;
				}else{
					productosDisparadores = "'" + productoDisparador + "' ";
				}
                promocionDetalle = Consultas.ConsultasPromocion.obtenerVistaDetalle(oPromocion, cantidadGrupo, productosDisparadores);
            }
            if (promocionDetalle == null) return;
			adapter = new AplicaPromoDetalleAdapter(this, R.layout.elemento_promocion_detalle, promocionDetalle,tipoValidarExistencia);

			listaPromo.setAdapter(adapter);

			bIniciando = false;
			
			adapter.setOnCambioCantidadListener(new onCambioCantidadListener()
			{
				
				@Override
				public void onCambioCantidad()
				{
					ListView listaPromo = (ListView) findViewById(R.id.lstPromo);								
					setTotalCantidades(((AplicaPromoDetalleAdapter)listaPromo.getAdapter()).getDetalles());		
				}
			});
			
			setTotalCantidades(promocionDetalle);

            listaPromo.requestFocusFromTouch();
            listaPromo.setSelection(0);
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}
	}


	
	private void setTotalCantidades(PromocionDetalle promocionDetalle[]){
		if (bIniciando) return;
		int total = 0;
		for (int i = 0;  i < promocionDetalle.length; i++ ){
			if (promocionDetalle[i].isChecked()){
				total += promocionDetalle[i].getCantidad() * promocionDetalle[i].getFactor();
			}
		}
		TextView texto = (TextView) findViewById(R.id.txtTotal);
		texto.setText(String.valueOf(total));
	}
	
	public void setFolioRazonSocial(Cliente oCliente, TransProd oTRP)
	{
		TextView texto = (TextView) findViewById(R.id.lblFolioCliente);
		texto.setText(oTRP.Folio + " - " + oCliente.RazonSocial);
	}

	public void setErrorInventario(boolean ErrorInventario)
	{
		errorInventario = ErrorInventario;
	}
	
	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{

		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
                //No se puede regresar de una promocion de regalo
				/*try
				{
					mPresenta.getPromociones().Preparar(); //eliminar las promociones
				}
				catch (Exception ex)
				{
					mostrarError(ex.getMessage());
				}
				setResultado(Enumeradores.Resultados.RESULTADO_MAL);
				finalizar();
				return true;*/
		}
		return super.onKeyDown(keyCode, event);
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{

	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if (tipoMensaje == TipoRespuestaMensaje.PENDIENTE_ENTREGA){
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}
	}

	@Override
	public void iniciar()
	{

	}

	private OnClickListener mContinuar = new OnClickListener()
	{

		@Override
		public void onClick(View v)
		{
            Button btn = (Button) findViewById(R.id.btnContinuar);
            btn.setEnabled(false);
			if (oPromocion.CapturaCantidad){
				ListView listaPromo = (ListView) findViewById(R.id.lstPromo);
				listaPromo.clearFocus();
				TextView txtTotal = (TextView) findViewById(R.id.txtTotal);
				TextView txtMaximo = (TextView) findViewById(R.id.txtMaximo);				
				if(Float.parseFloat(txtTotal.getText().toString()) > Float.parseFloat(txtMaximo.getText().toString())){
					mostrarAdvertencia(Mensajes.get("E0503",oPromocion.Nombre));
                    btn.setEnabled(true);
					return;
				}
			}
            if(oPromocion.NoDisminuirProducto){
                ListView listaPromo = (ListView) findViewById(R.id.lstPromo);
                listaPromo.clearFocus();
                TextView txtTotal = (TextView) findViewById(R.id.txtTotal);
                TextView txtMaximo = (TextView) findViewById(R.id.txtMaximo);
                if(Float.parseFloat(txtTotal.getText().toString()) < Float.parseFloat(txtMaximo.getText().toString())){
                    mostrarAdvertencia(Mensajes.get("E0902", "Total de productos que se entregarán en la promoción", "a la cantidad Máxima a regalar").replace(" o igual",""));
                    btn.setEnabled(true);
                    return;
                }
            }

            //Si hay error de inventario y no hay backorder se supone que quedan las cantidades en 0
			/*if (errorInventario ) {
				errorInventario = false;
				return;
			}*/
			boolean bAlMenosUnRegalo = false;
			ListView listaPromo = (ListView) findViewById(R.id.lstPromo);
			AplicaPromoDetalleAdapter adapter;
			adapter = (AplicaPromoDetalleAdapter) listaPromo.getAdapter();
			listaPromo.clearFocus();
			try
			{
				for (int i = 0; i < adapter.getCount(); i++)
				{
					PromocionDetalle promocionDetalle = (PromocionDetalle) adapter.getItem(i);
					if (!promocionDetalle.isSeleccionProducto())
					{
                        TransProdDetalle tpd = null;
                        tpd= TransaccionesDetalle.Pedidos.GuardarDetalleRegaladosYCanjes(mPresenta.getTransProd(), promocionDetalle.getProductoClave(), promocionDetalle.getPRUTipoUnidad(), promocionDetalle.getCantidad(), promocionDetalle.getPromocionClave(), tipoValidarExistencia, oPromocion.PendienteEntrega, productoDisparador, promocionDetalle.getPrecio(), promocionDetalle.getPrecioClave(), promocionDetalle.getLote());
                        if (tpd!= null) {
                            mPresenta.getTransProd().TransProdDetalle.add(tpd);
                            //manejo envase
                            Cliente cli = ((Cliente)Sesion.get(Campo.ClienteActual));
                            if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == com.amesol.routelite.presentadores.Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == com.amesol.routelite.presentadores.Enumeradores.TiposModulos.REPARTO) &&
                                    cli.Prestamo && (mPresenta.getTransProd().Tipo == com.amesol.routelite.presentadores.Enumeradores.TiposTransProd.PEDIDO || mPresenta.getTransProd().Tipo == com.amesol.routelite.presentadores.Enumeradores.TiposTransProd.VENTA_CONSIGNACION)){
                                Producto producto = new Producto();
                                producto.ProductoClave = tpd.ProductoClave;
                                BDVend.recuperar(producto);
                                ManejoEnvase.manejoEnvase(producto, tpd.TipoUnidad, tpd.Cantidad, tpd, mPresenta.getTransProd());
                            }
                        }
						bAlMenosUnRegalo = true;
					}
					else
					{
						if (promocionDetalle.isChecked())
						{
							if (promocionDetalle.getCantidad()>0){
								TransProdDetalle tpd = TransaccionesDetalle.Pedidos.GuardarDetalleRegaladosYCanjes(mPresenta.getTransProd(), promocionDetalle.getProductoClave(), promocionDetalle.getPRUTipoUnidad(), promocionDetalle.getCantidad(), promocionDetalle.getPromocionClave(), tipoValidarExistencia, oPromocion.PendienteEntrega, productoDisparador, promocionDetalle.getPrecio(), promocionDetalle.getPrecioClave(), promocionDetalle.getLote());
                                if (tpd != null){
								    mPresenta.getTransProd().TransProdDetalle.add(tpd);
                                    //manejo envase
                                    Cliente cli = ((Cliente)Sesion.get(Campo.ClienteActual));
                                    if((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == com.amesol.routelite.presentadores.Enumeradores.TiposModulos.VENTA || Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == com.amesol.routelite.presentadores.Enumeradores.TiposModulos.REPARTO) &&
                                            cli.Prestamo && (mPresenta.getTransProd().Tipo == com.amesol.routelite.presentadores.Enumeradores.TiposTransProd.PEDIDO || mPresenta.getTransProd().Tipo == com.amesol.routelite.presentadores.Enumeradores.TiposTransProd.VENTA_CONSIGNACION)){
                                        Producto producto = new Producto();
                                        producto.ProductoClave = tpd.ProductoClave;
                                        BDVend.recuperar(producto);
                                        ManejoEnvase.manejoEnvase(producto, tpd.TipoUnidad, tpd.Cantidad, tpd, mPresenta.getTransProd());
                                    }
                                }
								bAlMenosUnRegalo = true;		
							}else {
								mostrarError(Mensajes.get("E0012"));
								btn.setEnabled(true);
								return;
							}
						}
					}
				}

				String pendienteEntrega = Consultas.ConsultasProductoNegado.obtenerProductoNegadoXPromocion(mPresenta.getTransProd().TransProdID, oPromocion.PromocionClave);
				if (pendienteEntrega != ""){
					Sesion.set(Campo.ResultadoActividad, bAlMenosUnRegalo);
					mostrarMensaje(Mensajes.get("I0354").replace("$0$", "\n" + pendienteEntrega), 0, TipoRespuestaMensaje.PENDIENTE_ENTREGA);
					return;
				}
			}
			catch (Exception ex)
			{
				mostrarError(ex.getMessage());
                btn.setEnabled(true);
				setResultado(Enumeradores.Resultados.RESULTADO_MAL);
			}
			Sesion.set(Campo.ResultadoActividad, bAlMenosUnRegalo);
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}
	};
}