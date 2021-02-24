package com.duxstar.dacza.vistas.generico;

import android.app.Activity;
import android.content.Context;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.duxstar.dacza.R;
import com.duxstar.dacza.datos.DEVDetalle;
import com.duxstar.dacza.utilerias.Generales;
import com.duxstar.dacza.vistas.CapturaDevolucion;

/**
 * Created by Adriana on 19/05/2016.
 */


public class DEVDetalleAdapter extends ArrayAdapter<DEVDetalle>
{
    int textViewResourceId;
    Context context;
    DEVDetalle objetos[];
    boolean soloLectura;

    public DEVDetalleAdapter(Context context, int textViewResourceId,
                             DEVDetalle[] objects)
    {
        super(context, textViewResourceId, objects);
        this.textViewResourceId = textViewResourceId;
        this.context = context;
        objetos = objects;
    }

    public void setSoloLectura(boolean bSoloLectura){ soloLectura = bSoloLectura; }


    @Override
    public int getViewTypeCount()
    {
        return objetos.length;
    }

    @Override
    public int getItemViewType(int position)
    {
        return position;
    }

    @SuppressWarnings("deprecation")
    @Override
    public View getView(int position, View convertView, ViewGroup parent)
    {
        View fila = convertView;
        Holder holder = null;
        if (convertView == null) {
            LayoutInflater inflater = ((Activity) context).getLayoutInflater();
            fila = inflater.inflate(textViewResourceId, null);
            fila.setOnClickListener(new View.OnClickListener() {

                public void onClick(View v) {
                    if (!soloLectura) {
                        ((CapturaDevolucion)context).modificarProducto(((Holder)v.getTag()).Clave.getTag().toString(), (Float)((Holder)v.getTag()).Cantidad.getTag());
                        Log.d("Item", "Click");
                        return;
                    }
                    return;
                }

            });


            holder = new Holder();
            holder.Clave = (TextView) fila.findViewById(R.id.lblClave);
            holder.Descripcion = (TextView) fila.findViewById(R.id.lblDescripcion);
            holder.Cantidad = (TextView) fila.findViewById(R.id.lblCantidad);


            //asignar el listener solo si no es solo lectura
            if (!soloLectura) {
                fila.setOnLongClickListener(new View.OnLongClickListener() {

                    @Override
                    public boolean onLongClick(View v) {
                        Log.d("Item", "LongClick");
                        return false;
                    }
                });
            }

            fila.setTag(holder);
        } else {
            holder = (Holder) fila.getTag();
        }

        DEVDetalle detalle = getItem(position);

        holder.Clave.setText(detalle.articulo.Clave + " - ");
        holder.Clave.setTag(detalle.articulo.Clave);
        holder.Descripcion.setText(detalle.articulo.Descripcion);
        holder.Cantidad.setText(Generales.getFormatoDecimal(detalle.Cantidad, 2));
        holder.Cantidad.setTag(detalle.Cantidad);

        return fila;
    }

    static class Holder
    {
        TextView Clave;
        TextView Descripcion;
        TextView Cantidad;;
    }

}

