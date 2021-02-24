package com.duxstar.dacza.vistas.generico;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.ImageView;
import android.widget.TextView;

import com.duxstar.dacza.R;
//import com.duxstar.dacza.actividades.Mensajes;
import com.duxstar.dacza.actividades.ValorReferencia;
//import com.amesol.routelite.datos.basedatos.Consultas;
//import com.amesol.routelite.vistas.RevisionPendientes.pendientes;

public class ValorReferenciaAdapter extends ArrayAdapter<ValorReferencia>
{

	int textViewResourceId;
	boolean flagMessage = false;
	Context context;
	ArrayList<Boolean> checkedStates = new ArrayList<Boolean>();
    HashMap<Integer,CheckBox> checkedControl = new HashMap<Integer,CheckBox>();

	public ValorReferenciaAdapter(Context context, int textViewResourceId, ArrayList<ValorReferencia> objects)
	{
		super(context, textViewResourceId, objects);
		this.textViewResourceId = textViewResourceId;
		this.context = context;

		if (isInteger(objects.get(0).getDescripcion().substring(0, 1)))
		{
			Collections.sort(objects, new CustomComparatorNumber());
		}
		else
			Collections.sort(objects, new CustomComparator());

		for (int i = 0; i < objects.size(); i++)
		{
			checkedStates.add(i, false);
		}
	}

	public boolean isInteger(String str)
	{
		try
		{
			Integer.parseInt(str);
			return true;
		}
		catch (NumberFormatException nfe)
		{
		}
		return false;
	}

	public class CustomComparatorNumber implements Comparator<ValorReferencia>
	{
		@Override
		public int compare(ValorReferencia o1, ValorReferencia o2)
		{
			if (o1.getDescripcion().substring(0, 2) == o2.getDescripcion().substring(0, 2))
			{
				return 0;
			}
			else if (Integer.parseInt(o1.getDescripcion().substring(0, 2)) < Integer.parseInt(o2.getDescripcion().substring(0, 2)))
			{
				return -1;
			}
			return 1;
		}
	}

	public class CustomComparator implements Comparator<ValorReferencia>
	{
		@Override
		public int compare(ValorReferencia o1, ValorReferencia o2)
		{
			if (o1.getVavclave() == o2.getVavclave())
			{
				return 0;
			}
			else if (Integer.parseInt(o1.getVavclave()) < Integer.parseInt(o2.getVavclave()))
			{
				return -1;
			}
			return 1;
		}
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent)
	{
		View fila = convertView;

		if (convertView == null)
		{
			LayoutInflater inflater = ((Activity) context).getLayoutInflater();
			fila = inflater.inflate(textViewResourceId, null);
		}
		ValorReferencia vr = getItem(position);
		//		if (!vr.getVavclave().equals("22"))
		//		if (!((Vendedor) Sesion.get(Campo.VendedorActual)).JornadaTrabajo && !vr.getVavclave().equals("28"))
		//		{
		if (this.textViewResourceId == R.layout.elemento_checkbox)
		{
            if (!checkedControl.containsKey(position)){
                checkedControl.put(position, (CheckBox) fila.findViewById(android.R.id.text1));
            }

			CheckBox chkbox = (CheckBox) fila.findViewById(android.R.id.text1);
			if (chkbox != null)
			{
				chkbox.setClickable(false);
				chkbox.setFocusable(false);
				chkbox.setText(vr.getDescripcion());
				chkbox.setTag(vr.getVavclave());
			}
		}
		else
		{
			// red title
			TextView texto = (TextView) fila.findViewById(android.R.id.text1);
			if (texto != null)
			{
				if (isInteger(vr.getDescripcion().substring(0, 1)))
					texto.setText(vr.getDescripcion().substring(2));
				else
					texto.setText(vr.getDescripcion());

			}

//			texto = (TextView) fila.findViewById(R.id.txtItemDesc);
//			texto.setText(vr.getDescripcion());

			// image
			ImageView imagen = (ImageView) fila.findViewById(android.R.id.icon);
			if (imagen != null)
			{
				Integer intImagen = obtenerImagen(vr);
				if (intImagen != null)
					imagen.setImageResource(intImagen);
			}

		}

		return fila;
	}

	private Integer obtenerImagen(ValorReferencia valorReferencia)
	{
        if (valorReferencia.getVarcodigo().equals("ACTAGENTE")) {
            if (valorReferencia.getVavclave().equals("1"))
                return R.drawable.actagente1;
            else if (valorReferencia.getVavclave().equals("2"))
                return R.drawable.actagente2;
            else if (valorReferencia.getVavclave().equals("3"))
                return R.drawable.actagente3;
        }
        else if (valorReferencia.getVarcodigo().equals("ACTINVENT")) {
			if (valorReferencia.getVavclave().equals("1"))
				return R.drawable.actinvent1;
			else if (valorReferencia.getVavclave().equals("2"))
				return R.drawable.actinvent2;
			else if (valorReferencia.getVavclave().equals("3"))
				return R.drawable.actinvent3;
            else if (valorReferencia.getVavclave().equals("4"))
                return R.drawable.actinvent4;
        }
		return null;
	}

	public boolean isChecked(int posicion)
	{
		return checkedStates.get(posicion);
	}

	public void setChecked(View v, int posicion)
	{
		// checkedStates
		CheckBox chkbox = (CheckBox) v.findViewById(android.R.id.text1);
		chkbox.setChecked(!checkedStates.get(posicion));
		checkedStates.set(posicion, !checkedStates.get(posicion));
	}

    public void setChecked(int posicion, boolean valor)
    {
        // checkedStates
        CheckBox chkbox =checkedControl.get(posicion);
        chkbox.setChecked(valor);
        checkedStates.set(posicion, valor);
    }
}