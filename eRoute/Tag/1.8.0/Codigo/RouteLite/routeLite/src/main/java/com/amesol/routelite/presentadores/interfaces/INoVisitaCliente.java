package com.amesol.routelite.presentadores.interfaces;

import com.amesol.routelite.presentadores.IVista;

public interface INoVisitaCliente extends IVista
{
	void mostrarMotivosNoVisita(String Grupo);

	short getMotivoNoVisita();

	String getComentario();

    void setMotivoNoVisita(short tipoMotivo);

    void setComentario(String comentario);

	void mostrarMensajeRequerido();
}