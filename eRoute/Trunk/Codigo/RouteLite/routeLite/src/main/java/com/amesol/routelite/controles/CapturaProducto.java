package com.amesol.routelite.controles;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.concurrent.atomic.AtomicReference;
import java.util.List;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.Dialog;
import android.app.LoaderManager;
import android.content.Context;
import android.content.CursorLoader;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Color;
import android.os.Bundle;
import android.text.Html;
import android.text.InputType;
import android.util.AttributeSet;
import android.util.Log;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.RelativeLayout;
import android.widget.SimpleCursorAdapter;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.actividades.InventarioDobleUnidad;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.controles.TextBoxScanner.OnCodigoIngresadoListener;
import com.amesol.routelite.controles.TextBoxScanner.OnTextChangedListener;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.interfaces.IBuscaProducto;
import com.amesol.routelite.presentadores.interfaces.ISeleccionEsquemaProducto;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.Vista;
import com.amesol.routelite.vistas.generico.DialogoAlerta;


import org.apache.commons.lang3.StringUtils;

public class CapturaProducto extends LinearLayout {


    // controles
    TextBoxScanner txtScanner;
    //LinearLayout btnBuscar;
    ImageButton btnBuscar;
    Spinner cboUnidad;
    EditText txtCantidad;
	EditText txtCantidad1;
	EditText txtCantidad2;
    ImageButton btnAgregar;
    TextView lblProDescripcion;
    TextView lblProExistencia;
    LinearLayout laySaldoEnvase;
    TextView lblSaldoEnvase;

    // variables
    Producto oProducto = null;
	//graba el factor que se leyo por codigo de barras en el productoActual
	float factorLeidoProductoActual=0;

	Vista mVista = null;

    // parametros para la busquedaoParametros
    //String PCEPrecioClave = null;
    String CadenaListasPrecios = "";
    String TransProdIds = null;
    String moduloEsquemas = "";
    String nombreModulo = "";
	int tipoValidacionExistencia = TiposValidacionInventario.NoValidar;
	short tipoMovimiento;
	short tipoTransProd;
	//ModuloMovDetalle moduloMovDetalle = null;
	boolean mDevolucionesManuales = false;
	Context context;

	boolean bClaveManual = false;
	boolean bMostrandoBusqueda = false;
	boolean bAdvertencia = false;
	String error = "";
	
	int ubicacionExistencia; //variable para los traspasos de inventario (diponible o no disponible)
	boolean TraspasoInventario = false;
	boolean origenDestinoOk = false;
	boolean tipoMotivoOK = false;
    boolean surtir = false;

    String sMsgValidaEnvase="";//Envase Devolucion Cliente
    boolean bSoloEnvase= false;//Envase Devolucion Cliente
    boolean excluirCanjes = false; //Excluir productos tipo Canje de la busqueda
    boolean manejoDobleUnidad = false;
    int DigitoClaveProd=0;
	boolean capturarCantidadCero = false;
	boolean excluirMensajePrecio = false;

	boolean validarClaveProducto = false;
	boolean capturaCadLote = false;
	boolean Regexp = false;

	// ************************************************ constructores
	// ************************************************
	public CapturaProducto(Context context, AttributeSet attrs)
	{
		super(context, attrs);
		inicializar();
	}

	public CapturaProducto(Context context)
	{
		super(context);
		inicializar();
	}

	// ***************************************************************************************************************

	// ****************************************** funciones generales
	// ************************************************
	private void inicializar()
	{
		// Utilizamos el layout como interfaz del control
		String infService = Context.LAYOUT_INFLATER_SERVICE;
		LayoutInflater li = (LayoutInflater) getContext().getSystemService(infService);
		li.inflate(R.layout.captura_producto, this, true);

		if (this.isInEditMode()) // para que no truene cuando se agrega al
									// layout en vista de diseño
			return;

		/*try {

			capturaCadLote = (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()) && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("CapturaCadLote", Sesion.get(Campo.ModuloMovDetalleClave).toString()).equals("1"));
		}catch(Exception e){}*/

        if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").toString().equals("1"))
        {
			manejoDobleUnidad = true;
            LinearLayout lay = (LinearLayout) findViewById(R.id.layUnidadCantidad);
            lay.setVisibility(View.GONE);
        }

		// Obtenemos las referencias a los distintos controles
		txtScanner = (TextBoxScanner) findViewById(R.id.textBoxScanner);

        if(((CONHist) Sesion.get(Campo.CONHist)).get("TipoClaveProducto").toString().equals("2")){
            txtScanner.setTecladoNumerico();
            DigitoClaveProd = Integer.parseInt(((CONHist) Sesion.get(Campo.CONHist)).get("DigitoClaveProd").toString());
        }


		txtScanner.setOnCodigoIngresado(mCodigoBarras);
		txtScanner.setOnTextChanged(new OnTextChangedListener()
		{
			@Override
			public void OnTextChanged(CharSequence s)
			{
				if (bClaveManual)
					return;
				if (cboUnidad.getAdapter() != null)
				{
					((SimpleCursorAdapter) cboUnidad.getAdapter()).getCursor().close();
				}
				txtCantidad.setText("");
				lblProDescripcion.setText("");
				lblProExistencia.setText("");

				oProducto = null;
                if(manejoDobleUnidad){
                    LinearLayout lay = (LinearLayout) findViewById(R.id.layDobleUnidad);
                    lay.setVisibility(View.GONE);
					txtCantidad1.setText("");
					txtCantidad2.setText("");
                }
			}
		});

		//btnBuscar = (LinearLayout) findViewById(R.id.btnBuscarProducto); //se cambio el id al ImageButton en el layout (captura_producto.xml), con el LinearLayout daba problemas al darle click
		btnBuscar = (ImageButton) findViewById(R.id.btnBuscarProducto);
		btnBuscar.setEnabled(true);
		btnBuscar.setOnClickListener(mBuscarProducto);
		try{
			if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("OcultarIconoBusqueda")) {
				if (!((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("OcultarIconoBusqueda").toString().equals("0")) {
					String[] Actividades = {};
					int tipoModulo = Consultas.ConsultasValidacionPreliquidacion.getModuloMovDetalleTipoIndice((String) Sesion.get(Campo.ModuloMovDetalleClave));
					Actividades = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("OcultarIconoBusqueda").toString().trim().split("\\|");
					if(Arrays.asList(Actividades).contains(String.valueOf(tipoModulo))) {
						btnBuscar.setEnabled(false);
					}
				}
			}
		}
		catch(Exception ex){

		}

		cboUnidad = (Spinner) findViewById(R.id.cboUnidad);
		cboUnidad.setOnItemSelectedListener(mTipoUnidad);
		txtCantidad = (EditText) findViewById(R.id.txtCantidad);
		txtCantidad.selectAll();
		txtCantidad.setSelectAllOnFocus(true);

		lblProDescripcion = (TextView) findViewById(R.id.lblProDescripcion);
		lblProExistencia = (TextView) findViewById(R.id.lblProExistencia);
        laySaldoEnvase = (LinearLayout) findViewById(R.id.laySaldoEnvase);
        lblSaldoEnvase = (TextView) findViewById(R.id.lblSaldoEnvase);
		// final InputMethodManager imm = (InputMethodManager)
		// context.getSystemService(Context.INPUT_METHOD_SERVICE);

		txtCantidad.setOnKeyListener(new OnKeyListener()
		{

			@Override
			public boolean onKey(View v, int keyCode, KeyEvent event)
			{
				if (event.getAction() == KeyEvent.ACTION_UP)
				{
					// check if the right key was pressed
					if (keyCode == KeyEvent.KEYCODE_ENTER)
					{
						btnAgregar.performClick();
						return true;
					}
				}
				return false;
			}
		});

		btnAgregar = (ImageButton) findViewById(R.id.btnAgregar);
		btnAgregar.setOnClickListener(mAgregarProducto);

		if (manejoDobleUnidad){
			btnAgregar  = (ImageButton) findViewById(R.id.btnAgregarDobleUnidad);
			btnAgregar.setOnClickListener(mAgregarProductoDobleUnidad);

			txtCantidad2 = (EditText) findViewById(R.id.txtCantidad2);
			txtCantidad2.selectAll();
			txtCantidad2.setSelectAllOnFocus(true);
			txtCantidad2.setOnKeyListener(new OnKeyListener()
			{

				@Override
				public boolean onKey(View v, int keyCode, KeyEvent event)
				{
					if (event.getAction() == KeyEvent.ACTION_UP)
					{
						// check if the right key was pressed
						if (keyCode == KeyEvent.KEYCODE_ENTER)
						{
							btnAgregar.performClick();
							return true;
						}
					}
					return false;
				}
			});

			txtCantidad1 = (EditText) findViewById(R.id.txtCantidad1);
			txtCantidad1.selectAll();
			txtCantidad1.setSelectAllOnFocus(true);
			txtCantidad1.setOnKeyListener(new OnKeyListener()
			{

				@Override
				public boolean onKey(View v, int keyCode, KeyEvent event)
				{
			if (event.getAction() == KeyEvent.ACTION_UP)
					{
						// check if the right key was pressed
						if (keyCode == KeyEvent.KEYCODE_ENTER )
						{
							if (txtCantidad2.isShown() && txtCantidad1.getText().toString().length()>0) {
									if (((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).KgLts != null && ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).KgLts >0 ) {
											Float equivalencia = Float.parseFloat(txtCantidad1.getText().toString()) * ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).KgLts;
											txtCantidad2.setText(Generales.getFormatoDecimal(Generales.getRound(equivalencia, ((InventarioDobleUnidad.DetalleProductoDobleUnidad) txtCantidad2.getTag()).DecimalProducto), "#######0.#####"));
									}
								if (txtCantidad2.isEnabled()) {
									txtCantidad2.requestFocus();
								}else{
									btnAgregar.performClick();
								}

							}else{
								btnAgregar.performClick();
							}
							return true;
						}
					}
					return false;
				}
			});

			txtCantidad1.setOnFocusChangeListener(new OnFocusChangeListener() {
				@Override
				public void onFocusChange(View view, boolean b) {
					if (!b){
						if (txtCantidad2.isShown() && txtCantidad1.getText().toString().length()>0) {
								if (((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).KgLts != null && ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).KgLts >0 ) {
									Float equivalencia = Float.parseFloat(txtCantidad1.getText().toString()) * ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).KgLts;
									txtCantidad2.setText(Generales.getFormatoDecimal(Generales.getRound(equivalencia, ((InventarioDobleUnidad.DetalleProductoDobleUnidad) txtCantidad2.getTag()).DecimalProducto), "#######0.#####"));
								}
						}
					}
				}
			});
		}

        try {
            String moduloMovDetalleClave = (String) Sesion.get(Campo.ModuloMovDetalleClave);
            ModuloMovDetalle mmd = new ModuloMovDetalle();
            mmd.ModuloMovDetalleClave = moduloMovDetalleClave;
            BDVend.recuperar(mmd);
            nombreModulo = mmd.Nombre;
            mmd = null;
        }catch(Exception ex){
            nombreModulo = "Error al recuperar el módulo";
        }

		Activity act = (Activity) li.getContext();
		mVista = (Vista) act;

		try {
			if (nombreModulo.equals("Descargas")) {
				if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("CapturarCantidadCero", "ModuloMovDetalle")) {
					capturarCantidadCero = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("CapturarCantidadCero", "ModuloMovDetalle").toString().equals("1");
				}
			}
		}catch(Exception ex){
			//nombreModulo = "Error al recuperar el parametro";
			mVista.mostrarError(ex.getMessage());
		}
	}

	public void limpiarProducto()
	{
		try
		{
			txtScanner.BorrarTexto();
			if (cboUnidad.getAdapter() != null)
			{
				((SimpleCursorAdapter) cboUnidad.getAdapter()).getCursor().close();
			}
			cboUnidad.setEnabled(false);
			txtCantidad.setText("");
			lblProDescripcion.setText("");
			lblProExistencia.setText("");
            laySaldoEnvase.setVisibility(GONE);
            lblSaldoEnvase.setText("");
			oProducto = null;
			factorLeidoProductoActual = 0;
			txtScanner.requestFocus();
            if (manejoDobleUnidad){
                LinearLayout lay = (LinearLayout) findViewById(R.id.layDobleUnidad);
                lay.setVisibility(View.GONE);
            }
		}
		catch (Exception e)
		{
			Log.e("", "" + e);

		}

	}

	public void llenarProductoUnidad(Producto producto, int tipoUnidad, Float cantidad)
	{

		txtScanner.setTexto(producto.ProductoClave);
		oProducto = producto;
		try
		{
			if (oProducto.isRecuperado() == false){
				BDVend.recuperar(producto);
			}
			
			obtenerDetallesProducto(oProducto);
			if (!capturaCadLote) {
				Generales.SelectSpinnerItemByValue(cboUnidad, tipoUnidad);

				txtCantidad.setText(Generales.getFormatoDecimal(cantidad, producto.DecimalProducto));
				if (cboUnidad.getCount() > 1) {
					cboUnidad.requestFocus();
				} else {
					cboUnidad.setEnabled(false);
					txtCantidad.requestFocus();
					txtCantidad.selectAll();
					txtCantidad.setSelectAllOnFocus(true);
				}

				if (oProducto.DecimalProducto == 0) {
					txtCantidad.setInputType(InputType.TYPE_CLASS_NUMBER);
				} else {
					txtCantidad.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL | InputType.TYPE_CLASS_NUMBER);
				}
			}
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	public void llenarProductoDobleUnidad(Producto producto, HashMap<Short, Float> hmUnidades)
	{

		txtScanner.setTexto(producto.ProductoClave);
		oProducto = producto;
		try
		{
			if (oProducto.isRecuperado() == false){
				BDVend.recuperar(producto);
			}

			obtenerDetallesProducto(oProducto);

			InventarioDobleUnidad.DetalleProductoDobleUnidad Unidad1 =(InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag();
			txtCantidad1.setText(Generales.getFormatoDecimal(hmUnidades.get(Unidad1.PRUTipoUnidad),Unidad1.DecimalProducto));

			if (txtCantidad2.isShown()) {
				InventarioDobleUnidad.DetalleProductoDobleUnidad Unidad2 = (InventarioDobleUnidad.DetalleProductoDobleUnidad) txtCantidad2.getTag();
				if (hmUnidades.containsKey(Unidad2.PRUTipoUnidad)) {
					txtCantidad2.setText(Generales.getFormatoDecimal(hmUnidades.get(Unidad2.PRUTipoUnidad), Unidad2.DecimalProducto));
				}
			}

			txtCantidad1.requestFocus();
			txtCantidad1.selectAll();
			txtCantidad1.setSelectAllOnFocus(true);

			if (Unidad1.DecimalProducto == 0){
				txtCantidad1.setInputType(InputType.TYPE_CLASS_NUMBER);
			}else{
				txtCantidad1.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL|InputType.TYPE_CLASS_NUMBER);
			}
			txtCantidad1.requestFocus();

		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

	// ***************************************************************************************************************

	// ****************************** setters para los parametros de la busqueda
	// *************************************
	public void setCadenaListasPrecios(String listasPrecios)
	{
		CadenaListasPrecios = listasPrecios;
	}
	public void setTransProdIds(String transProdIds)
	{
		TransProdIds = transProdIds;
	}

	public void setModuloEsquemas(String pModuloEsquemas)
	{
		moduloEsquemas = pModuloEsquemas;
	}
	public void setTipoValidacionExistencia(int tipoValidaExistencia)
	{
		tipoValidacionExistencia = tipoValidaExistencia;
	}

	public void setTipoMovimiento(short pTipoMovimiento)
	{
		tipoMovimiento = pTipoMovimiento;
	}

	public void setTipoTransProd(short pTipoTransProd)
	{
		tipoTransProd = pTipoTransProd;
	}

	public void setDevolucionesManuales(boolean Devolucion)
	{
		mDevolucionesManuales = Devolucion;
	}
	
	public void setTraspasoInventario(boolean Traspaso)
	{
		TraspasoInventario = Traspaso;
	}

	public void setCapturaCadLote(boolean CapturaCadLote)
	{
		capturaCadLote = CapturaCadLote;
		if (capturaCadLote)
		{

			LinearLayout lay = (LinearLayout) findViewById(R.id.layUnidadCantidad);
			lay.setVisibility(View.GONE);
			LinearLayout layDP = (LinearLayout) findViewById(R.id.layDatosProducto);
			layDP.setVisibility(View.GONE);

		}
	}
	public void setOrigenDestinoOk(boolean ok){
		origenDestinoOk = ok;
	}
	
	public void setTipoMotivoOk(boolean ok){
		tipoMotivoOK = ok;
	}
	
	public void setUbicacionExistencia(short ubicacionExistencia)
	{
		this.ubicacionExistencia = ubicacionExistencia;
	}

    public void setSurtir(boolean bSurtir){
        surtir = bSurtir;
    }

    public void setExcluirCanjes(boolean bExcluirCanjes){
        excluirCanjes = bExcluirCanjes;
    }

	public void setExcluirMensajePrecio(boolean bExcluirMsgPrecio){excluirMensajePrecio = bExcluirMsgPrecio; }

	// *******Asignación de valores a las
	// propiedades************************************************
	public void setCantidad(Float cantidad)
	{
		txtCantidad.setText(cantidad.toString());
	}

	public void setCantidad(Float cantidad, Short TipoUnidad)
	{
		if(!manejoDobleUnidad) return;
		if (((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).PRUTipoUnidad == TipoUnidad){
			txtCantidad1.setText(cantidad.toString());
		}else if (((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad2.getTag()).PRUTipoUnidad == TipoUnidad){
			txtCantidad2.setText(cantidad.toString());
		}
	}

	public void setFactorLeidoProductoActual(Float factor)
	{
		factorLeidoProductoActual = factor;
	}

	public void setError(String Error)
	{
		error = Error;
	}

	public void setAdvertencia(String Advertencia)
	{
		bAdvertencia = true;
		error = Advertencia;
	}

	// *************************************************************************************************
	public void setEnabled(boolean habilitar)
	{
		txtScanner.setEnabled(habilitar);
		btnBuscar.setEnabled(habilitar);
		cboUnidad.setEnabled(habilitar);
		txtCantidad.setEnabled(habilitar);
		btnAgregar.setEnabled(habilitar);
		txtScanner.habilitarBotonScanner(habilitar);
		/*
		 * if (!habiliar){
		 * 
		 * }
		 */
	}

    public Spinner getSpinnerUnidad(){
        return cboUnidad;
    }

	public void onActivityResult(int requestCode, int resultCode, Intent intent)
	{
		// pasar a la vista el manejo
		mVista.resultadoActividad(requestCode, resultCode, intent);
	}

	public void setFinBusqueda()
	{
		limpiarProducto();
		bMostrandoBusqueda = false;
	}

	private android.view.View.OnClickListener mBuscarProducto = new android.view.View.OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			String Codigo = obtenerCodigoValido(txtScanner.getTexto().toString());
			Regexp = true;
            if(Codigo.length() != 0 && ((CONHist) Sesion.get(Campo.CONHist)).get("TipoClaveProducto").toString().equals("2")){

                txtScanner.setTexto(StringUtils.leftPad(Codigo,DigitoClaveProd,"0"));
                buscarProducto(StringUtils.leftPad(Codigo,DigitoClaveProd,"0"), false,0);
            }else {
                buscarProducto(Codigo, false,0);
            }
		}
	};

	private OnCodigoIngresadoListener mCodigoBarras = new OnCodigoIngresadoListener()
	{
		public void OnCodigoIngresado(String Codigo, int codigoLeido)
		{
			if (bClaveManual)
				return;
			if (Codigo.length() == 0)
				return;
			String codigoOriginalLeido = Codigo;
			Regexp = true;
			Codigo = obtenerCodigoValido(Codigo);
			float factorEnCodigo=0;
			try{
				//5614: Leer en código barras del producto la cantidad de piezas
				if(tipoTransProd == Enumeradores.TiposTransProd.CARGAS ) {
					if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("LeerPzasEnCodigoBarras") && ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("LeerPzasEnCodigoBarras").equals("1")) {
						if (codigoOriginalLeido.length()>=31) {
							factorEnCodigo = Float.parseFloat(codigoOriginalLeido.substring(28,32));
						}
					}
				}
			}catch (Exception ex){
				if(ex != null && ex.getMessage()!=null) {
					mVista.mostrarError("Error LeerPzasEnCodigoBarras" + ex.getMessage());
				}else{
					mVista.mostrarError("Error LeerPzasEnCodigoBarras");
				}
			}
            if(((CONHist) Sesion.get(Campo.CONHist)).get("TipoClaveProducto").toString().equals("2")){
                txtScanner.setTexto(StringUtils.leftPad(Codigo.replace("\n",""),DigitoClaveProd,"0"));
                buscarProducto(StringUtils.leftPad(Codigo,DigitoClaveProd,"0"), false,factorEnCodigo);
            }else {
                buscarProducto(Codigo, codigoLeido == 1 ? true : false,factorEnCodigo);
            }
		}
	};

    private void mostrarCodigosRepetidos(String codigo, Cursor unidades){
        LayoutInflater inflater = (LayoutInflater) mVista
                .getSystemService(Context.LAYOUT_INFLATER_SERVICE);

        View dialogView = inflater.inflate(R.layout.dialogo_grid, null);

        AlertDialog.Builder builder = new AlertDialog.Builder(mVista);
        builder.setView(dialogView);
        final Dialog dialog = builder.create();

        TextView txt = (TextView) dialogView.findViewById(R.id.txtCol1);
        txt.setText(Mensajes.get("XCodigodeBarras") + ": " + codigo);
        txt = (TextView) dialogView.findViewById(R.id.txtCol2);
        txt.setVisibility(View.GONE);
        txt = (TextView) dialogView.findViewById(R.id.txtCol3);
        txt.setVisibility(View.GONE);
        txt = (TextView) dialogView.findViewById(R.id.txtCol4);
        txt.setVisibility(View.GONE);
        txt = (TextView) dialogView.findViewById(R.id.txtCol5);
        txt.setVisibility(View.GONE);

        ListView lstUnidades = (ListView) dialogView.findViewById(R.id.lstGrid);
        mVista.startManagingCursor(unidades);

        final MySimpleCursorAdapter adapter = new MySimpleCursorAdapter(mVista.getBaseContext(), R.layout.lista_seleccion_codigo, unidades,
                new String[]{ "PRUTipoUnidad", "ProductoClave", "NombreLargo","Existencia" },
                new int[] { R.id.txtUnidad, R.id.txtClave, R.id.txtDescripcion, R.id.txtExistencia }, dialog);
        adapter.setViewBinder(new vistaCodigoRepetido());

        lstUnidades.setAdapter(adapter);

        /*dialog.setOnDismissListener(new DialogInterface.OnDismissListener() {

            @Override
            public void onDismiss(DialogInterface dialog) {
                // TODO Auto-generated method stub

                mostrarProducto();
            }
        });*/


        /*builder.setPositiveButton("Aceptar", new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int id) {
                dialog.dismiss();
            }
        });*/
        dialog.show();
    }

    private void mostrarProducto(String ProductoClave) {
        try{
            bClaveManual = true;
            txtScanner.txtScanner.setText(ProductoClave);
            txtCantidad.requestFocus();
            bClaveManual = false;
            oProducto = Consultas.ConsultasProducto.obtenerProducto(ProductoClave);
            if (oProducto != null) {
                if (moduloEsquemas.length() > 0) {
                    if (!Consultas.ConsultasProductoEsquema.productoEsquemaValido(oProducto.ProductoClave, moduloEsquemas)) {
                        mVista.mostrarError(Mensajes.get("E0923", nombreModulo));
                        oProducto = null;
                        return;
                    }
                } else if (excluirCanjes && oProducto.Tipo == Enumeradores.PROTipo.CANJE) {
                    mVista.mostrarError(Mensajes.get("E0773", "Linea, Linea/Canje"));
                    oProducto = null;
                    return;
                }
                if (tipoTransProd == Enumeradores.TiposTransProd.CANJES) {
                    if (oProducto.Tipo != Enumeradores.PROTipo.CANJE && oProducto.Tipo != Enumeradores.PROTipo.LINEA_CANJE) {
                        mVista.mostrarError(Mensajes.get("E0773", "Canje, Linea/Canje"));
                        oProducto = null;
                        return;
                    }
                }

                sMsgValidaEnvase = ValidarSoloEnvase(oProducto);//Envase Devolucion Cliente
                if (sMsgValidaEnvase.length() > 0) {//Envase Devolucion Cliente
                    if (sMsgValidaEnvase == "E0773")
                        mVista.mostrarError(Mensajes.get(sMsgValidaEnvase).replace("$0$", "Envase"));//Envase Devolucion Cliente
                    else
                        mVista.mostrarError(Mensajes.get(sMsgValidaEnvase));//Envase Devolucion Cliente
                    oProducto = null;//Envase Devolucion Cliente
                    sMsgValidaEnvase = "";//Envase Devolucion Cliente
                    return;//Envase Devolucion Cliente
                }//Envase Devolucion Cliente
                obtenerDetallesProducto(oProducto);
                //mostrarUnidades(unidades);
                cboUnidad.setEnabled(false);
                mVista.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE);
                return;
            }
        }
        catch (Exception ex)
        {
            mVista.mostrarError(ex.getMessage());
        }
    }

	private void buscarProducto(String cadenaBusqueda, boolean codigoLeido, float factor)
	{

		try
		{
			factorLeidoProductoActual = factor;

			if (bClaveManual)
				return;

            //Este tipo de validaciones no deberian estar en esta parte de código
            //ya que teoricamente este control es general
            //Se podrian usar mas bien los eventos para realizarlas en la clase que corresponda.
            if(TraspasoInventario){
				if(!origenDestinoOk){
					mVista.mostrarAdvertencia(Mensajes.get("E0926"));
					return;
				}
				if(!tipoMotivoOK){
					mVista.mostrarAdvertencia(Mensajes.get("E0161").replace("$0$", Mensajes.get("XMotivo")));
					return;
				}
			}
			//WEHRE
			boolean calcularKardexUnidad = false;
			if (tipoTransProd == Enumeradores.TiposTransProd.DESCARGAS)
				if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("CalcularKardexUnidad") && ((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("CalcularKardexUnidad").toString().equals("1"))
					calcularKardexUnidad = true;

			if (cadenaBusqueda.equals(""))
			{
				if (bMostrandoBusqueda)
					return;
				if (buscarListener != null)
				{
					buscarListener.onProductoNoEncontrado();
				}

					final HashMap<String, Object> parametros = new HashMap<String, Object>();
					parametros.put("Esquema", "Todos");
					parametros.put("Cadena", cadenaBusqueda);
					parametros.put("ListaPrecios", CadenaListasPrecios);
					parametros.put("TransProd", TransProdIds);
					parametros.put("TipoValidarExistencia", tipoValidacionExistencia);
					parametros.put("TipoMovimiento", tipoMovimiento);
					parametros.put("TipoTransProd", tipoTransProd);
					parametros.put("ModuloEsquemas", moduloEsquemas);
					parametros.put("UbicacionExistencia", ubicacionExistencia);
                    parametros.put("SoloEnvase", bSoloEnvase);//Envase Devolucion Cliente
                    parametros.put("ExcluirCanjes", excluirCanjes);
					parametros.put("ExcluirMensajePrecio", excluirMensajePrecio );

                bMostrandoBusqueda = true;
                if (!manejoDobleUnidad){
					if (calcularKardexUnidad)
						mVista.iniciarActividadConResultado(IBuscaProducto.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS, Enumeradores.Acciones.ACCION_OBTENER_BUSQUEDA_SIMPLE, parametros);
					else
						mVista.iniciarActividadConResultado(IBuscaProducto.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS, Enumeradores.Acciones.ACCION_OBTENER_PRODUCTOS_SELECCIONADOS, parametros);
                }else{
                    mVista.iniciarActividadConResultado(IBuscaProducto.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS, Enumeradores.Acciones.ACCION_OBTENER_BUSQUEDA_SIMPLE, parametros);
                }
				//}
			}
			else
			{
				oProducto = null;
				if (!codigoLeido)
				{
					String[] Busqueda = {};
					String[] Actividades = {};
					String[] Campos = {};
					String Patron = "";
					String filtroProducto = "";
					Boolean BusquedaEsp = false;
					if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).existeParametro("ConfiguracionCapturaProducto")){
						if(!((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ConfiguracionCapturaProducto").toString().equals("0")){
							Busqueda = ((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ConfiguracionCapturaProducto").toString().trim().split("\\|");
							Actividades = Busqueda[0].split(",");
							Campos = Busqueda[1].split(",");
							Patron = Busqueda[2];
							BusquedaEsp = true;
						}
					}
					if(Regexp && BusquedaEsp){
						int tipoModulo = Consultas.ConsultasValidacionPreliquidacion.getModuloMovDetalleTipoIndice((String) Sesion.get(Campo.ModuloMovDetalleClave));
						if(Arrays.asList(Actividades).contains(String.valueOf(tipoModulo))){
							boolean AlInicio = false;
							boolean AlFinal = false;
							int AlMedio = 0;
							int CantidadPatron = 0;
							String Expresion = "";
							for(int i=0; i < Patron.length(); i++ ){
								if(Patron.charAt(i) == 'X'){
									CantidadPatron += 1;
								}
							}
							if( Patron.charAt(0)== 'X'){
								AlInicio = true;
							}
							else if( Patron.charAt(Patron.length()-(1+0))== 'X'){
								AlFinal = true;
							}
							else{
								for(int i=0; i < Patron.length(); i++ ){
									if(Patron.charAt(i) == 'X'){
										break;
									}
									AlMedio += 1;
								}

							}

							int leng = cadenaBusqueda.length();
							if(AlInicio)
								Expresion = "^["+cadenaBusqueda.substring(0,CantidadPatron).toUpperCase()+"]";
							else if (AlFinal)
								Expresion = "["+cadenaBusqueda.substring(cadenaBusqueda.length()-CantidadPatron).toUpperCase()+"]$";
							else{
								for(int i=0; i < AlMedio; i++ ){
									Expresion += ".";
								}
								Expresion = "^["+Expresion+cadenaBusqueda.substring(0,AlMedio).toUpperCase()+"]";
							}

							int CampoActual = 0;
							if (!cadenaBusqueda.equals("")){
								filtroProducto = "( ";
								if(Arrays.asList(Campos).contains("a")){
									if(CampoActual>0)
										filtroProducto += " or ";
									filtroProducto += " upper(PRO.Id) regexp '" + Expresion + "'";
									CampoActual += 1;
								}
								if(Arrays.asList(Campos).contains("b")){
									if(CampoActual>0)
										filtroProducto += " or ";
									filtroProducto += " upper(PRO.ProductoClave) regexp '" + Expresion + "'";
									CampoActual += 1;
								}
								if(Arrays.asList(Campos).contains("c")){
									if(CampoActual>0)
										filtroProducto += " or ";
									filtroProducto += " upper(PRO.Nombre) regexp '" + Expresion + "'";
									CampoActual += 1;
								}
								if(Arrays.asList(Campos).contains("d")){
									if(CampoActual>0)
										filtroProducto += " or ";
									filtroProducto += " upper(PRO.NombreLargo) regexp '" + Expresion + "'";
									CampoActual += 1;
								}
								if(Arrays.asList(Campos).contains("e")){
									if(CampoActual>0)
										filtroProducto += " or ";
									filtroProducto += " upper(PRO.id) regexp '" + Expresion + "'";
									CampoActual += 1;
								}
								filtroProducto += " )";
								oProducto = Consultas.ConsultasProducto.obtenerProductoIdentico(Expresion, filtroProducto);
							}
						}
						else
							oProducto = Consultas.ConsultasProducto.obtenerProductoIdentico(cadenaBusqueda);
					}
					else
						oProducto = Consultas.ConsultasProducto.obtenerProductoIdentico(cadenaBusqueda);
					if (oProducto == null)
					{
						// Buscar codigo barras
						ISetDatos unidades = Consultas.ConsultasProducto.buscarCodigoBarras(cadenaBusqueda, CadenaListasPrecios,tipoTransProd);
						if (unidades != null && unidades.getCount() > 0)
						{
								if (!capturaCadLote && unidades.getCount() > 1){
									mostrarCodigosRepetidos(cadenaBusqueda, (Cursor) unidades.getOriginal());
								}else {
									if (unidades.moveToFirst()) {
										bClaveManual = true;
										txtScanner.txtScanner.setText(unidades.getString("ProductoClave"));
										txtCantidad.requestFocus();
										bClaveManual = false;
										oProducto = Consultas.ConsultasProducto.obtenerProducto(unidades.getString("ProductoClave"));
										if (oProducto != null) {
											if (moduloEsquemas.length() > 0) {
												if (!Consultas.ConsultasProductoEsquema.productoEsquemaValido(oProducto.ProductoClave, moduloEsquemas)) {
													mVista.mostrarError(Mensajes.get("E0923", nombreModulo));
													oProducto = null;
													unidades.close();
													return;
												}
											} else if (excluirCanjes && oProducto.Tipo == Enumeradores.PROTipo.CANJE) {
												mVista.mostrarError(Mensajes.get("E0773", "Linea, Linea/Canje"));
												unidades.close();
												oProducto = null;
												return;
											}
											if (tipoTransProd == Enumeradores.TiposTransProd.CANJES) {
												if (oProducto.Tipo != Enumeradores.PROTipo.CANJE && oProducto.Tipo != Enumeradores.PROTipo.LINEA_CANJE) {
													mVista.mostrarError(Mensajes.get("E0773", "Canje, Linea/Canje"));
													unidades.close();
													oProducto = null;
													return;
												}
											}

											sMsgValidaEnvase = ValidarSoloEnvase(oProducto);//Envase Devolucion Cliente
											if (sMsgValidaEnvase.length() > 0) {//Envase Devolucion Cliente
												if (sMsgValidaEnvase == "E0773")
													mVista.mostrarError(Mensajes.get(sMsgValidaEnvase).replace("$0$", "Envase"));//Envase Devolucion Cliente
												else
													mVista.mostrarError(Mensajes.get(sMsgValidaEnvase));//Envase Devolucion Cliente
												oProducto = null;//Envase Devolucion Cliente
												unidades.close();//Envase Devolucion Cliente
												sMsgValidaEnvase = "";//Envase Devolucion Cliente
												return;//Envase Devolucion Cliente
											}//Envase Devolucion Cliente
											//Validado Con y sin lote
											obtenerDetallesProducto(oProducto);
											//mostrarUnidades(unidades);
											cboUnidad.setEnabled(false);
											mVista.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE);
											unidades.close();
											return;
										}
									}
								}
						}
						else
						{
							if (bMostrandoBusqueda)
								return;
							if (buscarListener != null)
							{
								buscarListener.onProductoNoEncontrado();
							}
							final HashMap<String, Object> parametros = new HashMap<String, Object>();
							parametros.put("Esquema", "Todos");
							parametros.put("Cadena", cadenaBusqueda);
							parametros.put("ListaPrecios", CadenaListasPrecios);
							parametros.put("TransProd", TransProdIds);
							parametros.put("TipoValidarExistencia", tipoValidacionExistencia);
							parametros.put("TipoMovimiento", tipoMovimiento);
							parametros.put("TipoTransProd", tipoTransProd);
							parametros.put("ModuloEsquemas", moduloEsquemas);
							parametros.put("UbicacionExistencia", ubicacionExistencia);
                            parametros.put("SoloEnvase", bSoloEnvase);//Envase Devolucion Cliente
                            parametros.put("ExcluirCanjes",excluirCanjes);
							parametros.put("ExcluirMensajePrecio", excluirMensajePrecio );
							bMostrandoBusqueda = true;
                            if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").toString().equals("0")){
								if (calcularKardexUnidad)
									mVista.iniciarActividadConResultado(IBuscaProducto.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS, Enumeradores.Acciones.ACCION_OBTENER_BUSQUEDA_SIMPLE, parametros);
								else
                                	mVista.iniciarActividadConResultado(IBuscaProducto.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS, Enumeradores.Acciones.ACCION_OBTENER_PRODUCTOS_SELECCIONADOS, parametros);
                            }else{
                                mVista.iniciarActividadConResultado(IBuscaProducto.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS, Enumeradores.Acciones.ACCION_OBTENER_BUSQUEDA_SIMPLE, parametros);
                            }
						}
					}
					else
					{
						/*
						 * Se encontró el producto, buscar que pertenezca a los esquemas válidos
						 * para el módulo actual
						 */
						if (moduloEsquemas.length()>0){
							if (!Consultas.ConsultasProductoEsquema.productoEsquemaValido(oProducto.ProductoClave, moduloEsquemas)){
                                mVista.mostrarError(Mensajes.get("E0923", nombreModulo));
								oProducto = null;
								return;
							}
						}else if(excluirCanjes && oProducto.Tipo == Enumeradores.PROTipo.CANJE ){
                            mVista.mostrarError(Mensajes.get("E0773","Linea, Linea/Canje"));
                            oProducto = null;
                            return;
                        }

                        if (tipoTransProd == Enumeradores.TiposTransProd.CANJES){
                            if (oProducto.Tipo != Enumeradores.PROTipo.CANJE && oProducto.Tipo != Enumeradores.PROTipo.LINEA_CANJE){
                                mVista.mostrarError(Mensajes.get("E0773", "Canje, Linea/Canje"));
                                oProducto = null;
                                return;
                            }
                        }
                        sMsgValidaEnvase=ValidarSoloEnvase(oProducto);//Envase Devolucion Cliente
                        if (sMsgValidaEnvase.length()>0){//Envase Devolucion Cliente
                            if(sMsgValidaEnvase == "E0773")
                                mVista.mostrarError(Mensajes.get(sMsgValidaEnvase).replace("$0$","Envase"));//Envase Devolucion Cliente
                            else
                                mVista.mostrarError(Mensajes.get(sMsgValidaEnvase));//Envase Devolucion Cliente
                            oProducto = null;//Envase Devolucion Cliente
                            sMsgValidaEnvase="";//Envase Devolucion Cliente
                            return;//Envase Devolucion Cliente
                        }//Envase Devolucion Cliente
						//Validado COn y sin Lote
						obtenerDetallesProducto(oProducto);
					}
				}
				else
				{
					ISetDatos unidades = Consultas.ConsultasProducto.buscarCodigoBarras(cadenaBusqueda, CadenaListasPrecios,tipoTransProd);
					if (unidades != null)
					{
						if (unidades.moveToFirst())
						{
							bClaveManual = true;
							txtScanner.txtScanner.setText(unidades.getString("ProductoClave"));
							txtCantidad.requestFocus();
							bClaveManual = false;
							oProducto = Consultas.ConsultasProducto.obtenerProducto(unidades.getString("ProductoClave"));
							if (oProducto != null)
							{
								if (moduloEsquemas.length()>0){
									if (!Consultas.ConsultasProductoEsquema.productoEsquemaValido(oProducto.ProductoClave, moduloEsquemas)){
										mVista.mostrarError(Mensajes.get("E0923", nombreModulo));
										oProducto = null;
										unidades.close();
										return;
									}
								}else if(excluirCanjes && oProducto.Tipo == Enumeradores.PROTipo.CANJE ){
                                    mVista.mostrarError(Mensajes.get("E0773","Linea, Linea/Canje"));
                                    unidades.close();
                                    oProducto = null;
                                    return;
                                }
                                if (tipoTransProd == Enumeradores.TiposTransProd.CANJES){
                                    if (oProducto.Tipo != Enumeradores.PROTipo.CANJE && oProducto.Tipo != Enumeradores.PROTipo.LINEA_CANJE){
                                        mVista.mostrarError(Mensajes.get("E0773","Canje, Linea/Canje"));
                                        unidades.close();
                                        oProducto = null;
                                        return;
                                    }
                                }
                                sMsgValidaEnvase=ValidarSoloEnvase(oProducto);//Envase Devolucion Cliente
                                if (sMsgValidaEnvase.length()>0){//Envase Devolucion Cliente
                                    if(sMsgValidaEnvase == "E0773")
                                        mVista.mostrarError(Mensajes.get(sMsgValidaEnvase).replace("$0$","Envase"));//Envase Devolucion Cliente
                                    else
                                        mVista.mostrarError(Mensajes.get(sMsgValidaEnvase));//Envase Devolucion Cliente
                                    oProducto = null;//Envase Devolucion Cliente
                                    unidades.close();//Envase Devolucion Cliente
                                    sMsgValidaEnvase="";//Envase Devolucion Cliente
                                    return;//Envase Devolucion Cliente
                                }//Envase Devolucion Cliente
								//Validado Con y sin Lote
								obtenerDetallesProducto(oProducto);
								//mostrarUnidades(unidades);
								cboUnidad.setEnabled(false);							
								mVista.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE );
								unidades.close();
								return;
							}
						}
					}
					mVista.mostrarError(Mensajes.get("E0863"));
					txtScanner.BorrarTexto();

				}
			}
		}
		catch (Exception ex)
		{
			mVista.mostrarError(ex.getMessage());
		}
	}

	public void obtenerDetallesProducto(Producto producto)
	{
		if (capturaCadLote){
			if (tipoTransProd == Enumeradores.TiposTransProd.PEDIDO && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA){
				mostrarCapturarLotes(producto);
				return;
			}
		}
			try
			{
				boolean calcularKardexUnidad = false;
				if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("CalcularKardexUnidad") )
					if(((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("CalcularKardexUnidad").toString().equals("1"))
						calcularKardexUnidad = true;

				validarProductoContenido(producto);
				lblProDescripcion.setText(producto.Nombre);

				if (manejoDobleUnidad){
					lblProExistencia.setVisibility(View.GONE);
					laySaldoEnvase.setVisibility(View.GONE);
				}else {
					if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar) {
						if (TraspasoInventario) {
							//traspaso de inventario
							lblProExistencia.setText(Mensajes.get("XExist") + ": " + Generales.getFormatoDecimal(Consultas.ConsultasInventario.obtenerExistencia(producto.ProductoClave, ubicacionExistencia), producto.DecimalProducto));
						} else if (!(tipoTransProd == Enumeradores.TiposTransProd.DESCARGAS && calcularKardexUnidad)) {
							if (tipoTransProd == Enumeradores.TiposTransProd.DESCARGAS && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO)
								lblProExistencia.setText(Mensajes.get("XExist") + ": " + Generales.getFormatoDecimal(Consultas.ConsultasInventario.obtenerExistenciaDifNoDisponible(producto.ProductoClave, CadenaListasPrecios), producto.DecimalProducto));
							else
								lblProExistencia.setText(Mensajes.get("XExist") + ": " + Generales.getFormatoDecimal(Consultas.ConsultasInventario.obtenerExistencia(producto.ProductoClave, CadenaListasPrecios, mDevolucionesManuales), producto.DecimalProducto));
						}
					} else {
						lblProExistencia.setVisibility(View.GONE);
					}

					//Si es envase que permite venta
					if ((tipoTransProd == Enumeradores.TiposTransProd.PEDIDO || tipoTransProd == Enumeradores.TiposTransProd.VENTA_CONSIGNACION) && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) != Enumeradores.TiposModulos.PREVENTA) {
						if (producto.Contenido && producto.Venta) {
							laySaldoEnvase.setVisibility(View.VISIBLE);
							lblSaldoEnvase.setText(Mensajes.get("XSaldoEnvase") + ": " + Generales.getFormatoDecimal(Consultas2.ConsultasProductoPrestamoCli.obtenerSaldoEnvase(((Cliente)Sesion.get(Campo.ClienteActual)).ClienteClave, producto.ProductoClave), producto.DecimalProducto));
						} else
							laySaldoEnvase.setVisibility(View.GONE);
					}
				}
				boolean capturaContenedor = false;
				if (tipoTransProd == Enumeradores.TiposTransProd.CARGAS && ((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("CapturarUnidadesConContenedor")) {
					if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("CapturarUnidadesConContenedor").equals("1")){
						capturaContenedor =true;
					}
				}

				ISetDatos unidades = Consultas.ConsultasProducto.obtenerUnidadesProducto(producto.ProductoClave, CadenaListasPrecios, manejoDobleUnidad, (tipoTransProd == Enumeradores.TiposTransProd.CANJES), capturaContenedor);
				if (unidades.getCount() <= 0) {
					unidades.close();
					if (tipoTransProd == Enumeradores.TiposTransProd.CANJES)
						mVista.mostrarError(Mensajes.get("E0981"));
					else
						mVista.mostrarError("El producto no tiene unidades definidas");
				} else {
					if (manejoDobleUnidad){
						mostrarDobleUnidad(unidades);
					}else {
						mostrarUnidades(unidades);
					}
				}

				if (manejoDobleUnidad) {
					Short decimales = 0;
					if (txtCantidad1.getTag() != null){
						decimales = ((InventarioDobleUnidad.DetalleProductoDobleUnidad) txtCantidad1.getTag()).DecimalProducto;
					}
					if(txtCantidad1 == null)
					{
						txtCantidad1 = (EditText) findViewById(R.id.txtCantidad1);
					}
					if (decimales == 0) {
						txtCantidad1.setInputType(InputType.TYPE_CLASS_NUMBER);
					} else {
						txtCantidad1.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL | InputType.TYPE_CLASS_NUMBER);
					}
				}

			}
			catch (Exception ex)
			{
				mVista.mostrarError(ex.getMessage().equals("") ? ex.getCause().getMessage() : ex.getMessage());
			}
	}

	@SuppressWarnings("deprecation")
	public void mostrarUnidades(ISetDatos unidades)
	{
		try
		{
			Cursor unidad = (Cursor) unidades.getOriginal();
			mVista.startManagingCursor(unidad);
			SimpleCursorAdapter adapter = new SimpleCursorAdapter(mVista, android.R.layout.simple_spinner_item, unidad, new String[]
			{ "PRUTipoUnidad" }, new int[]
			{ android.R.id.text1 });
			adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
			adapter.setViewBinder(new vista());
			cboUnidad.setAdapter(adapter);
			if (cboUnidad.getCount() > 0)
			{
				cboUnidad.setSelection(0);
				cboUnidad.setEnabled(factorLeidoProductoActual<=0);
				txtCantidad.requestFocus();
			}
            mVista.stopManagingCursor(unidad);
		}
		catch (Exception e)
		{
			mVista.mostrarError(e.getMessage());
		}
	}

    public void mostrarDobleUnidad(ISetDatos unidades)
    {
        try
        {
            LinearLayout lay = (LinearLayout) findViewById(R.id.layDobleUnidad);
            lay.setVisibility(View.VISIBLE);
            //LinearLayout layUnidad2 = (LinearLayout) findViewById(R.id.layUnidad2);
            TextView lblUnidad1 = (TextView) findViewById(R.id.lblUnidad1);
            EditText txtCantidad1 = (EditText) findViewById(R.id.txtCantidad1);
            TextView lblUnidad2 = (TextView) findViewById(R.id.lblUnidad2);
            EditText txtCantidad2 = (EditText) findViewById(R.id.txtCantidad2);

            if (unidades.getCount()==1){
                if (unidades.moveToFirst()) {
                    lblUnidad2.setVisibility(View.GONE);
                    txtCantidad2.setVisibility(View.GONE);
					Float existencia = 0f;
					if (tipoTransProd == Enumeradores.TiposTransProd.DEVOLUCIONES_MANUALES){
						existencia= Consultas.ConsultasInventario.obtenerExistenciaDobleUnidad(oProducto.ProductoClave, unidades.getShort("PRUTipoUnidad"),  InventarioDobleUnidad.TiposInventario.NODISPONIBLE );
					}else{
						existencia =Consultas.ConsultasInventario.obtenerExistenciaDobleUnidad(oProducto.ProductoClave, unidades.getShort("PRUTipoUnidad"),  InventarioDobleUnidad.TiposInventario.DISPONIBLE );
					}
					if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar) {
						lblUnidad1.setText(ValoresReferencia.getDescripcion("UNIDADV", unidades.getString("PRUTipoUnidad")) + "(" + Generales.getFormatoDecimal(existencia, "#,##0.#####") + ")");
					}else {
						lblUnidad1.setText(ValoresReferencia.getDescripcion("UNIDADV", unidades.getString("PRUTipoUnidad")));
					}
					txtCantidad1.setTag(new InventarioDobleUnidad.DetalleProductoDobleUnidad(unidades.getShort("PRUTipoUnidad"),unidades.getFloat("KgLts"),null, null, unidades.getShort("TipoEstado"), unidades.getShort("DecimalProducto"), unidades.getFloat("PorcentajeVariacion")));
                    //txtCantidad1.setTag(  + "|" +  + "|" +  + "|" +   );
					if (unidades.getShort("DecimalProducto") == 0){
						txtCantidad1.setInputType(InputType.TYPE_CLASS_NUMBER);
					}else{
						txtCantidad1.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL|InputType.TYPE_CLASS_NUMBER);
					}
					txtCantidad1.requestFocus();
                }
            }else if (unidades.getCount()>1){
                if (unidades.moveToFirst()) {
                    lblUnidad2.setVisibility(View.VISIBLE);
                    txtCantidad2.setVisibility(View.VISIBLE);
					Float existencia = 0f;
					if (tipoTransProd == Enumeradores.TiposTransProd.DEVOLUCIONES_MANUALES){
						existencia = Consultas.ConsultasInventario.obtenerExistenciaDobleUnidad(oProducto.ProductoClave, unidades.getShort("PRUTipoUnidad"),  InventarioDobleUnidad.TiposInventario.NODISPONIBLE );
					}else{
						existencia =  Consultas.ConsultasInventario.obtenerExistenciaDobleUnidad(oProducto.ProductoClave, unidades.getShort("PRUTipoUnidad"),  InventarioDobleUnidad.TiposInventario.DISPONIBLE );
					}
					if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar) {
						lblUnidad1.setText(ValoresReferencia.getDescripcion("UNIDADV", unidades.getString("PRUTipoUnidad")) + "(" + Generales.getFormatoDecimal(existencia,"#,##0.#####") + ")");
					}else{
						lblUnidad1.setText(ValoresReferencia.getDescripcion("UNIDADV", unidades.getString("PRUTipoUnidad")));
					}
					txtCantidad1.setTag(new InventarioDobleUnidad.DetalleProductoDobleUnidad(unidades.getShort("PRUTipoUnidad"),unidades.getFloat("KgLts"),null, null, unidades.getShort("TipoEstado"), unidades.getShort("DecimalProducto"), unidades.getFloat("PorcentajeVariacion")));
					if (unidades.getShort("DecimalProducto") == 0){
						txtCantidad1.setInputType(InputType.TYPE_CLASS_NUMBER);
					}else{
						txtCantidad1.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL|InputType.TYPE_CLASS_NUMBER);
					}

					if (((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("ModificarUnidadAlterna").equals(unidades.getString("PRUTipoUnidad"))){
						txtCantidad1.setEnabled(false);
					}

                    if (unidades.moveToNext()){
						if (tipoTransProd == Enumeradores.TiposTransProd.DEVOLUCIONES_MANUALES){
							existencia = Consultas.ConsultasInventario.obtenerExistenciaDobleUnidad(oProducto.ProductoClave, unidades.getShort("PRUTipoUnidad"),  InventarioDobleUnidad.TiposInventario.NODISPONIBLE);
						}else{
							existencia = Consultas.ConsultasInventario.obtenerExistenciaDobleUnidad(oProducto.ProductoClave, unidades.getShort("PRUTipoUnidad"),  InventarioDobleUnidad.TiposInventario.DISPONIBLE );
						}
						if (tipoValidacionExistencia != TiposValidacionInventario.NoValidar) {
							lblUnidad2.setText(ValoresReferencia.getDescripcion("UNIDADV", unidades.getString("PRUTipoUnidad")) + "(" + Generales.getFormatoDecimal(existencia,"#,##0.#####") + ")");
						}else {
							lblUnidad2.setText(ValoresReferencia.getDescripcion("UNIDADV", unidades.getString("PRUTipoUnidad")));
						}
                        /*Tag compuesto por PRUTipoUnidad|DecimalProducto|Factor|TipoEstado*/
						txtCantidad2.setTag(new InventarioDobleUnidad.DetalleProductoDobleUnidad(unidades.getShort("PRUTipoUnidad"),unidades.getFloat("KgLts"),null, null, unidades.getShort("TipoEstado"), unidades.getShort("DecimalProducto"), unidades.getFloat("PorcentajeVariacion")));
						if (((MOTConfiguracion)Sesion.get(Campo.MOTConfiguracion)).get("ModificarUnidadAlterna").equals(unidades.getString("PRUTipoUnidad"))){
							txtCantidad2.setEnabled(false);
						}
						if (unidades.getShort("DecimalProducto") == 0){
							txtCantidad2.setInputType(InputType.TYPE_CLASS_NUMBER);
						}else{
							txtCantidad2.setInputType(InputType.TYPE_NUMBER_FLAG_DECIMAL|InputType.TYPE_CLASS_NUMBER);
						}
					}
					txtCantidad1.requestFocus();
                }
            }
            unidades.close();

        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
        }
    }

	public void mostrarCapturarLotes(Producto oProducto)
	{
		if (bMostrandoBusqueda)
			return;
		if (buscarListener != null)
		{
			buscarListener.onProductoNoEncontrado();
		}

		final HashMap<String, Object> parametros = new HashMap<String, Object>();
		parametros.put("ProductoEspecifico", oProducto.ProductoClave);
		parametros.put("Esquema", "Todos");
		parametros.put("Cadena", "");
		parametros.put("ListaPrecios", CadenaListasPrecios);
		parametros.put("TransProd", TransProdIds);
		parametros.put("TipoValidarExistencia", tipoValidacionExistencia);
		parametros.put("TipoMovimiento", tipoMovimiento);
		parametros.put("TipoTransProd", tipoTransProd);
		parametros.put("ModuloEsquemas", moduloEsquemas);
		parametros.put("UbicacionExistencia", ubicacionExistencia);
		parametros.put("SoloEnvase", bSoloEnvase);//Envase Devolucion Cliente
		parametros.put("ExcluirCanjes",excluirCanjes);
		parametros.put("ExcluirMensajePrecio", excluirMensajePrecio );
		bMostrandoBusqueda = true;
		//No aplica para Busqueda
		mVista.iniciarActividadConResultado(IBuscaProducto.class, Enumeradores.Solicitudes.SOLICITUD_BUSQUEDA_PRODUCTOS, Enumeradores.Acciones.ACCION_OBTENER_PRODUCTOS_SELECCIONADOS, parametros);

		/*try {
			LayoutInflater inflater = (LayoutInflater) mVista
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);

			View dialogViewCapturarLotes = inflater.inflate(R.layout.dialog_captura_lote_cantidad, null);

			AlertDialog.Builder builder = new AlertDialog.Builder(mVista);
			//builder.getWindow().setSoftInputMode(
			//		WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE);
			ListView lstProductoUnidadLote = (ListView) dialogViewCapturarLotes.findViewById(R.id.lstProductoUnidadLote);
			lstProductoUnidadLote.setDescendantFocusability(ViewGroup.FOCUS_BEFORE_DESCENDANTS);
			lstProductoUnidadLote.setChoiceMode(1);
			lstProductoUnidadLote.setItemsCanFocus(true);
			lstProductoUnidadLote.setClickable(false);
			//builder.setCancelable(false);

			//builder.setTitle();
			TextView title = new TextView(mVista);
			title.setText(oProducto.ProductoClave + " - " + oProducto.Nombre);
			//title.setPadding(0, 20, 0, 20);
			title.setBackgroundColor(Color.RED);
			title.setTextColor(Color.WHITE);
			title.setGravity(View.TEXT_ALIGNMENT_CENTER);
			builder.setCustomTitle(title);
			ISetDatos prodInventarioLotes = Consultas.ConsultasInventarioLotes.obtenerProductoInventarioLotes(oProducto.ProductoClave);
			Cursor cProductoInventarioLotes = (Cursor) prodInventarioLotes.getOriginal();
			//startManagingCursor(cProductoInventarioLotes);
			SimpleCursorAdapter adapter = new SimpleCursorAdapter(mVista, R.layout.elemento_captura_producto_unidad_lote, cProductoInventarioLotes, new String[] { "TipoUnidad", "Lote", "Caducidad","Existencia" }, new int[] { R.id.lblUnidad, R.id.lblLote, R.id.lblCaducidad, R.id.lblExistencia });
			adapter.setViewBinder(new vistaProductoUnidadLote());
			lstProductoUnidadLote.setAdapter(adapter);
			lstProductoUnidadLote.requestFocusFromTouch();
			lstProductoUnidadLote.setSelection(0);
			//registerForContextMenu(lstProductoUnidadLote);
			*/
			/*lstProductoUnidadLote.setOnItemClickListener(new AdapterView.OnItemClickListener() {
				public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
					String sPrecioManual;
					Cursor listasprecios = (Cursor) parent.getItemAtPosition(position);
					listasprecios.moveToPosition(position);
					sPrecioManual = listasprecios.getString(2);

					Cursor producto = (Cursor) (((SimpleCursorAdapter) lista.getAdapter()).getCursor());
					final String transProdID= producto.getString(producto.getColumnIndex("TransProdID"));
					final String transProdDetalleID = producto.getString(producto.getColumnIndex("TransProdDetalleID"));
					final String subEmpresaId = producto.getString(producto.getColumnIndex("SubEmpresaId"));
					final String productoClave = producto.getString(producto.getColumnIndex("ProductoClave"));
					final short tipoUnidad = producto.getShort(producto.getColumnIndex("TipoUnidad"));
					final float cantidad = producto.getFloat(producto.getColumnIndex("Cantidad"));
					float precioEspecial = Generales.getRound(Float.parseFloat(sPrecioManual),Integer.parseInt(((CONHist)Sesion.get(Campo.CONHist)).get("DecimalesImporte").toString()));

					Sesion.set(Campo.CambioLPTpdExtra,true);
					Sesion.set(Campo.LPTpdExtra,listasprecios.getString(0));
					//mPresenta.eliminarDetalle(transProdID, transProdDetalleID, subEmpresaId, productoClave, tipoUnidad, cantidad, false );
					//mPresenta.agregarProductoUnidad(productoClave, subEmpresaId, tipoUnidad, cantidad, precioEspecial);
					Sesion.set(Campo.LPTpdExtra,"");
					Sesion.set(Campo.CambioLPTpdExtra,false);
					//btPrecioManualAceptar.performClick();
				}
			});*/
			/*builder.setPositiveButton(Mensajes.get("XAceptar"),new DialogInterface.OnClickListener()
			{
				@Override
				public void onClick(DialogInterface dialog, int which)
				{

					dialog.dismiss();
				}

			});

			builder.setNegativeButton(Mensajes.get("XCancelar"),new DialogInterface.OnClickListener()
			{
				@Override
				public void onClick(DialogInterface dialog, int which)
				{

					dialog.dismiss();
				}

			});
			builder.setView(dialogViewCapturarLotes);


			final Dialog dialog = builder.create();
			dialog.setOnShowListener(new DialogInterface.OnShowListener() {
				@Override
				public void onShow(DialogInterface dialog) {
					//btPrecioManualAceptar = ((AlertDialog) dialog)
					//		.getButton(AlertDialog.BUTTON_NEGATIVE);
				}
			});

			dialog.show();
			//input.requestFocus();
			//InputMethodManager imm = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
			//imm.toggleSoftInput(InputMethodManager.SHOW_FORCED, 0);
		}catch(Exception ex){
			mVista.mostrarError("Error al mostrar lotes: " + ex.getMessage());
		}*/

	}

	private class vistaProductoUnidadLote implements ViewBinder
	{

		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();
			switch (viewId)
			{
				case R.id.lblUnidad:
					TextView unidad = (TextView) view;
					unidad.setText(ValoresReferencia.getDescripcion("UNIDADV",cursor.getString(columnIndex)));
					//total.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), "$ #,##0.00"));
					break;
				case R.id.lblCaducidad:
					TextView lblCaducidad = (TextView) view;
					String fecha = cursor.getString(columnIndex);
					fecha = fecha.substring(0, 6) + fecha.substring(8, 10);
					lblCaducidad.setText(fecha);
					break;
				default:
					TextView texto = (TextView) view;
					texto.setText(cursor.getString(columnIndex));
					break;
			}
			return true;
		}
	}
	public boolean validarProductoContenido(Producto producto) throws Exception
	{
		if (producto.Contenido && !producto.Venta)
		{
			throw new ControlError("E0725");
		}
		return true;
	}

	public boolean validarCaptura()
	{
		if (oProducto == null)
		{
			mVista.mostrarError(Mensajes.get("BE0001", Mensajes.get("XProducto")));
			txtScanner.requestFocus();
			return false;
		}
		if (manejoDobleUnidad){
			if (txtCantidad1.getText().toString().trim().equals("")) {
				TextView lblUnidad1 = (TextView) findViewById(R.id.lblUnidad1);
				mVista.mostrarError(Mensajes.get("BE0001", lblUnidad1.getText().toString()));
				txtCantidad1.requestFocus();
				return false;
			}
			if (txtCantidad2.isShown() && txtCantidad2.getText().toString().trim().equals("")) {
				TextView lblUnidad2 = (TextView) findViewById(R.id.lblUnidad2);
				mVista.mostrarError(Mensajes.get("BE0001", lblUnidad2.getText().toString()));
				txtCantidad2.requestFocus();
				return false;
			}
			if (tipoTransProd != Enumeradores.TiposTransProd.DESCARGAS && tipoTransProd != Enumeradores.TiposTransProd.DEVOLUCIONES_MANUALES){
				String sValores = ValoresReferencia.getStringVAVClave("UNIDADV", "VARIABLE");
				if (txtCantidad2.isShown() && sValores !=null && sValores.length()>0){
					String[] aValoresXRef = sValores.split(",");
					if (((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).PRUTipoUnidad == Short.parseShort(String.valueOf(aValoresXRef[0]))){
						Float cantidadCalculada = ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad2.getTag()).KgLts * Float.parseFloat(txtCantidad2.getText().toString());
						Float variacionKilos = (cantidadCalculada * ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).PorcentajeVariacion) / 100;
						int decimales = ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).DecimalProducto;
						if ((Generales.getRound(Float.parseFloat(txtCantidad1.getText().toString()),decimales) >   Generales.getRound(cantidadCalculada + variacionKilos,decimales)) || (Generales.getRound(Float.parseFloat(txtCantidad1.getText().toString()),decimales) <   Generales.getRound(cantidadCalculada - variacionKilos,decimales)) ){
							mVista.mostrarError(Mensajes.get("E0957"));
							txtCantidad1.requestFocus();
							return false;
						}
					}else if (((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad2.getTag()).PRUTipoUnidad == Short.parseShort(String.valueOf(aValoresXRef[0]))){
						Float cantidadCalculada = ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad1.getTag()).KgLts * Float.parseFloat(txtCantidad1.getText().toString());
						Float variacionKilos = (cantidadCalculada * ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad2.getTag()).PorcentajeVariacion) / 100;
						int decimales = ((InventarioDobleUnidad.DetalleProductoDobleUnidad)txtCantidad2.getTag()).DecimalProducto;
						if ((Generales.getRound(Float.parseFloat(txtCantidad2.getText().toString()), decimales ) >   Generales.getRound(cantidadCalculada + variacionKilos, decimales)) || (Generales.getRound(Float.parseFloat(txtCantidad2.getText().toString()), decimales) <   Generales.getRound(cantidadCalculada - variacionKilos,decimales)) ){
							mVista.mostrarError(Mensajes.get("E0957"));
							txtCantidad2.requestFocus();
							return false;
						}
					}
				}
			}
		}else {
			if (cboUnidad.getSelectedItemPosition() < 0) {
				mVista.mostrarError(Mensajes.get("BE0001", Mensajes.get("XUnidad")));
				cboUnidad.requestFocus();
				return false;
			}
			if (txtCantidad.getText().toString().trim().equals("")) {
				mVista.mostrarError(Mensajes.get("BE0001", Mensajes.get("XCantidad")));
				txtCantidad.requestFocus();
				return false;
			}

			if (tipoTransProd == Enumeradores.TiposTransProd.PEDIDO || tipoTransProd == Enumeradores.TiposTransProd.MOV_SIN_INV_EV) {
				try {
					if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ValidarVtaMultiplo").length() > 0) {
						if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ValidarVtaMultiplo").equals("1")) {
							if (oProducto.CantidadProduccion > 0) {
								if ((Float.parseFloat(Generales.getFormatoDecimal(Float.parseFloat(txtCantidad.getText().toString()), oProducto.DecimalProducto)) % oProducto.CantidadProduccion) != 0) {
									mVista.mostrarError(Mensajes.get("E0935", String.valueOf(oProducto.CantidadProduccion)));
									txtCantidad.requestFocus();
									return false;
								}
							}
						}
					}
				} catch (Exception ex) {
					mVista.mostrarError(ex.getMessage());
					return false;
				}

			}
		}

		return true;
	}

	private class vista implements ViewBinder
	{
		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();
			switch (viewId)
			{
				case android.R.id.text1: // para llenar el combo de la unidad
					TextView combo = (TextView) view;
					Log.e("", ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("PRUTipoUnidad"))));
					combo.setText(ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("PRUTipoUnidad"))));
					break;
				default:
					TextView texto = (TextView) view;
					texto.setText(cursor.getString(columnIndex));
					break;
			}
			return true;
		}
	}

    private class vistaCodigoRepetido implements ViewBinder
    {

        @Override
        public boolean setViewValue(View view, Cursor cursor, int columnIndex)
        {
            int viewId = view.getId();

            LinearLayout.LayoutParams lParams;
            switch (viewId)
            {
                case R.id.txtUnidad:
                    TextView unidad = (TextView) view;
                    unidad.setText(ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(columnIndex)));
                    unidad.setTag(cursor.getInt(columnIndex));
                    break;
				case R.id.txtExistencia:
					TextView existencia = (TextView) view;
					if (tipoTransProd != Enumeradores.TiposTransProd.PEDIDO) {
						existencia.setVisibility(View.GONE);
					}
					existencia.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex),"#,##0"));
					break;
                default:
                    TextView texto = (TextView) view;
                    if (!texto.getText().equals(cursor.getString(columnIndex)))
                    {
                        texto.setText(cursor.getString(columnIndex));
                    }

                    break;
            }

            return true;
        }
    }

	public String obtenerCodigoValido(String codigo){
		try {
			/*if(codigo.length() > 17) {
				if(porBarcode){
					codigo = codigo.substring(3, 16);
				}else{
					codigo = codigo.substring(3, 17);
				}
				boolean existe = Consultas.ConsultasProducto.existeCodigoBarras(codigo);
				if(!existe) {
					codigo = codigo.substring(1, 13);
					String inicio = codigo.substring(0, 1);
					if (inicio.equals("0")) {
						existe = Consultas.ConsultasProducto.existeCodigoBarras(codigo);
						if (!existe) {
							if (codigo.length() > 12) {
								codigo = codigo.substring(1, 13);
							} else {
								codigo = codigo.substring(1, 12);
							}
						}
					}
				}
			}*/

			if(codigo.length() > 20) {
				codigo = codigo.substring(19, 25);
				validarClaveProducto = true;
			}


		} catch (Exception e) {
			e.printStackTrace();
		}

		return codigo;
	}

	public String getCantidad()
	{
		return txtCantidad.getText().toString();
	}

	public float getFactorLeidoProductoActual()
	{
		return factorLeidoProductoActual;
	}

	private OnClickListener mAgregarProducto = new OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			// solo se dispara el listener cuando esta el producto capturado y
			// tiene cantidad > 0
			if (agregarListener == null)
				return;
			// if(agregarListener != null && oProducto != null &&
			// !txtCantidad.getText().toString().equals("")){
			if (validarCaptura())
			{
				if (Float.isInfinite(Float.parseFloat(txtCantidad.getText().toString()))){
					txtCantidad.setText("0");
				}
				//permitir capturar cero en reparto, ya que la opcion de eliminar no existe, se eliminan con cero
				if (Float.parseFloat(txtCantidad.getText().toString()) > 0 || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && Float.parseFloat(txtCantidad.getText().toString()) == 0 && tipoTransProd == 1 && surtir ) || (capturarCantidadCero &&  Float.parseFloat(txtCantidad.getText().toString()) == 0 ))
				{
					//ajustar la cantidad capturada al numero de decimales configurados para el producto
					float cantidad = Float.parseFloat(Generales.getFormatoDecimal(Float.parseFloat(txtCantidad.getText().toString()), oProducto.DecimalProducto));
					agregarListener.onAgregarProducto(oProducto, Short.parseShort(String.valueOf(cboUnidad.getSelectedItemId())), cantidad);
					//agregarListener.onAgregarProducto(oProducto, Integer.parseInt(String.valueOf(cboUnidad.getSelectedItemId())), Float.parseFloat(txtCantidad.getText().toString()));
					if (error == "")
					{
						limpiarProducto();
					}
					else
					{
						mVista.mostrarError(error);
						error = "";
						if (bAdvertencia)
						{
							limpiarProducto();
							bAdvertencia = false;
						}
					}
				}
				else
				{
					mVista.mostrarError(Mensajes.get("E0012"));
				}
			}
		}
	};

	private OnClickListener mAgregarProductoDobleUnidad = new OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			// solo se dispara el listener cuando esta el producto capturado y
			// tiene cantidad > 0
			if (agregarDobleUnidadListener == null)
				return;

			try {
				if(txtCantidad1.hasFocus()) {
					txtCantidad1.clearFocus();
				}
				btnAgregar.requestFocus();
				if (validarCaptura()) {
					boolean cantidadesValidas = false;
					//permitir capturar cero en reparto, ya que la opcion de eliminar no existe, se eliminan con cero
					if(tipoTransProd == Enumeradores.TiposTransProd.DESCARGAS || tipoTransProd == Enumeradores.TiposTransProd.DEVOLUCIONES_MANUALES){
						if(Float.parseFloat(txtCantidad1.getText().toString()) > 0 || (txtCantidad2.isShown() && Float.parseFloat(txtCantidad2.getText().toString()) > 0 )){
							cantidadesValidas = true;
						}
					}else if ((Float.parseFloat(txtCantidad1.getText().toString()) > 0 || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && Float.parseFloat(txtCantidad1.getText().toString()) == 0 && tipoTransProd == 1 && surtir) || (Float.parseFloat(txtCantidad1.getText().toString()) == 0 && tipoTransProd == 3 && surtir)) &&
							(!txtCantidad2.isShown() || Float.parseFloat(txtCantidad2.getText().toString()) > 0 || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO && Float.parseFloat(txtCantidad2.getText().toString()) == 0 && tipoTransProd == 1 && surtir))) {
						cantidadesValidas = true;
					}

					if(!cantidadesValidas){
						mVista.mostrarError(Mensajes.get("E0012"));
						return;
					}

					//ajustar la cantidad capturada al numero de decimales configurados para el producto
					HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades = new HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad>();

					InventarioDobleUnidad.DetalleProductoDobleUnidad Cant1 = (InventarioDobleUnidad.DetalleProductoDobleUnidad) txtCantidad1.getTag();
					Cant1.Cantidad = Generales.getRound(Float.parseFloat(txtCantidad1.getText().toString()), Cant1.DecimalProducto);
					hmDetalleUnidades.put(Cant1.PRUTipoUnidad,Cant1);

					if(txtCantidad2.isShown()) {
						InventarioDobleUnidad.DetalleProductoDobleUnidad Cant2 = (InventarioDobleUnidad.DetalleProductoDobleUnidad) txtCantidad2.getTag();
						Cant2.Cantidad = Generales.getRound(Float.parseFloat(txtCantidad2.getText().toString()), Cant2.DecimalProducto);
						hmDetalleUnidades.put(Cant2.PRUTipoUnidad, Cant2);
					}

					agregarDobleUnidadListener.onAgregarProdDobleUnidad(oProducto, hmDetalleUnidades);
					if (error == "") {
						limpiarProducto();
					} else {
						mVista.mostrarError(error);
						error = "";
						if (bAdvertencia) {
							limpiarProducto();
							bAdvertencia = false;
						}
					}
				}
			}catch (Exception ex){
				if (ex!=null && ex.getMessage() != null) {
					mVista.mostrarError(ex.getMessage());
				}else{
					mVista.mostrarError("Error al agregar Producto");
				}

			}
		}
	};
	// ***************************** listener para agregar producto
	// **************************************
	public interface onAgregarProductoListener
	{
		void onAgregarProducto(Producto producto, int tipoUnidad, float cantidad);
	}

	private onAgregarProductoListener agregarListener = null;

	public void setOnAgregarProductoListener(onAgregarProductoListener l)
	{
		agregarListener = l;
	}

	// ***************************** listener para agregar producto con doble unidad
	// **************************************
	public interface onAgregarProdDobleUnidadListener
	{
		void onAgregarProdDobleUnidad(Producto producto, HashMap<Short, InventarioDobleUnidad.DetalleProductoDobleUnidad> hmDetalleUnidades);
	}

	private onAgregarProdDobleUnidadListener agregarDobleUnidadListener = null;

	public void setOnAgregarProdDobleUnidadListener(onAgregarProdDobleUnidadListener l)
	{
		agregarDobleUnidadListener = l;
	}

	// ***************************************************************************************************

	// ***************************** listener para buscar producto
	// ***************************************
	public interface onProductoNoEncontradoListener
	{
		void onProductoNoEncontrado();
	}

	private onProductoNoEncontradoListener buscarListener = null;

	public void setOnProductoNoEncontradoListener(onProductoNoEncontradoListener l)
	{
		buscarListener = l;
	}
    
	public String ValidarSoloEnvase(Producto producto){//Envase Devolucion Cliente
        MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
        //Log.i(null, "pasa 1 transprod: "+tipoTransProd);

        if (oProducto != null){
            //Log.i(null,Integer.parseInt(Sesion.get(Campo.TipoModulo).toString())+" == "+TiposModulos.REPARTO );
            //Log.i(null,Enumeradores.TiposTransProd.PEDIDO+" == "+tipoTransProd);
            if (tipoTransProd == Enumeradores.TiposTransProd.PEDIDO  && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO){
                if (motConfig.get("SoloVentaEnvase").equals("1") && !producto.Contenido && !producto.Venta){
                    bSoloEnvase = true;
                    //return Mensajes.get("E0907");
                    return "E0907";
                }
            }
            else if(tipoTransProd == Enumeradores.TiposTransProd.DEVOLUCIONES_CLIENTE ){
                if (motConfig.get("RecoleccionEnvase").equals("1") && !producto.Contenido){
                    bSoloEnvase=true;
                    //return Mensajes.get("E0773").replace("$0$","Envase");
                    return "E0773";
                }
            }
        }
        return "";
	}

    public void setEnableCantidadAgregar(boolean habilita)
	{
    	txtCantidad.setEnabled(habilita);
    	btnAgregar.setEnabled(habilita);
    }

    public void IngresaProductoBusquedaSimple (String sProductoClave){
        try{
            if (sProductoClave != null){
				if(!sProductoClave.equals("")) {
					bMostrandoBusqueda = false;
					oProducto = Consultas.ConsultasProducto.obtenerProductoIdentico(sProductoClave);
					obtenerDetallesProducto(oProducto);
				}
            }
        }catch (Exception ex){
            mVista.mostrarError(ex.getMessage());
        }
    }

	private AdapterView.OnItemSelectedListener mTipoUnidad = new AdapterView.OnItemSelectedListener() {

		@Override
		public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3) {
			try {
				if (tipoTransProd == Enumeradores.TiposTransProd.DESCARGAS) {
					if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("CalcularKardexUnidad") && ((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("CalcularKardexUnidad").toString().equals("1")) {
						Cursor item = (Cursor) arg0.getItemAtPosition(arg2);
						int unidad = item.getInt(0);
						lblProExistencia.setText(Mensajes.get("XExist") + ": " + Generales.getFormatoDecimal(Consultas.ConsultasKardexUnidad.obtenerDisponibleProductoUnidad(oProducto.ProductoClave, unidad), oProducto.DecimalProducto));
					}
				}
			}catch (Exception ex){}
		}

		@Override
		public void onNothingSelected(AdapterView<?> arg0) {

		}
	};

    private class MySimpleCursorAdapter extends SimpleCursorAdapter
    {
        Cursor c;
        Dialog myDialog;

        @SuppressWarnings("deprecation")
        public MySimpleCursorAdapter(Context context, int layout, Cursor c, String[] from, int[] to)
        {
            super(context, layout, c, from, to);
            this.c = c;
        }

        public MySimpleCursorAdapter(Context context, int layout, Cursor c, String[] from, int[] to, Dialog dialog)
        {
            super(context, layout, c, from, to);
            this.c = c;
            this.myDialog = dialog;
        }

        @Override
        public View getView(final int pos, View v, ViewGroup parent)
        {
            v = super.getView(pos, v, parent);
            Cursor c = ((SimpleCursorAdapter) ((ListView) parent).getAdapter()).getCursor();
            final String clave = ((TextView) v.findViewById(R.id.txtClave)).getText().toString();

            v.setOnClickListener(new View.OnClickListener() {
                 @Override
                 public void onClick(View v) {
                     myDialog.dismiss();
                     mostrarProducto(clave);
                     //mVista.setResultado(Enumeradores.Resultados.RESULTADO_BIEN, ((TextView) v.findViewById(R.id.txtClave)).getText().toString());
                     //mVista.finalizar();
                 }
            });

            return v;
        }

    }


}

