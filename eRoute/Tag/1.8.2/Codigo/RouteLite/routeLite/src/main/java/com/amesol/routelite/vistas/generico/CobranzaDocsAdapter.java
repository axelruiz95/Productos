package com.amesol.routelite.vistas.generico;

import android.app.Activity;
import android.content.Context;
import android.text.format.DateFormat;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.CompoundButton.OnCheckedChangeListener;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Mensajes;

import java.util.HashMap;

public class CobranzaDocsAdapter extends ArrayAdapter<Cobranza.VistaDocumentos> {
	int textViewResourceId; 
	Context context;
	boolean habilitar;
    HashMap<String, Boolean> estatus;
	OnCheckedChangeListener checkListener;
    Boolean cargandoLista = false;

	public CobranzaDocsAdapter(Context context, int textViewResourceId,
			Cobranza.VistaDocumentos[] objects, boolean habilitar, OnCheckedChangeListener checklistener) {		
		super(context, textViewResourceId, objects);
		this.textViewResourceId = textViewResourceId;
		this.context = context;
		this.habilitar = habilitar;
		this.checkListener = checklistener;
        estatus = new HashMap<String, Boolean>();

	}
	
	@Override
    public View getView(int position, View convertView, ViewGroup parent) {
		View fila = convertView;
		
		if(convertView == null){
			LayoutInflater inflater = ((Activity)context).getLayoutInflater();
			fila = 	inflater.inflate(textViewResourceId, null);
		}
		try{
			
			Cobranza.VistaDocumentos documento = getItem(position);
			
			TextView texto = (TextView) fila.findViewById(R.id.texto1);		
			if(texto != null) texto.setText(documento.getFolio() + " - " + String.format("$ %.2f", documento.getSaldo()));
						
			texto = (TextView) fila.findViewById(R.id.texto2);		
			if(texto != null  && documento.getFecha() != null) texto.setText(Mensajes.get("XFecha") + ": " + DateFormat.format("dd/MM/yyyy", documento.getFecha()));
			
			texto = (TextView) fila.findViewById(R.id.texto3);		
			if(texto != null) texto.setText(Mensajes.get("ABNTotal") + ": " + String.format("$ %.2f", documento.getTotal()));
			
			CheckBox check = (CheckBox) fila.findViewById(R.id.checkBox1);
			if (!habilitar){				
				check.setChecked(true);
				check.setEnabled(false);							
			}
			if (!estatus.containsKey(documento.getTransprodID()))
                estatus.put(documento.getTransprodID(), check.isChecked());

            cargandoLista = true;
            check.setChecked(estatus.get(documento.getTransprodID()));
            cargandoLista = false;

			check.setTag("'" + documento.getTransprodID() + "'");
			check.setOnCheckedChangeListener(checkListener);
			
			return fila;
		} catch (Exception e){
			e.printStackTrace();
			return fila;
		}		
	}

    public void setEstatus(String transProdID , Boolean estado){
        estatus.put(transProdID.replace("'","") , estado);
    }
	public Boolean getCargandoLista(){
        return cargandoLista;
    }
}
