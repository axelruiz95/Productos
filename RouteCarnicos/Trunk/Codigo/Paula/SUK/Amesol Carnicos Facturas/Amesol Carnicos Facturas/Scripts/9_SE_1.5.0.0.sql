IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'SEMServidorCancelacion') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMServidorCancelacion','G',1,3,'Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMServidorCancelacion','EC','Servidor Cancelaci�n','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMServidorCancelacion','ECR','Servidor Cancelaci�n','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMServidorCancelacion','EM','Servidor Cancelaci�n','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMServidorCancelacion','EP','Servidor Cancelaci�n','Admin',getdate())
END

IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'SEMServidorCancelacionT') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMServidorCancelacionT','G',1,3,'Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMServidorCancelacionT','EC','Direcci�n del servicio para cancelaci�n de certificados digitales por internet','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMServidorCancelacionT','ECR','Direcci�n del servicio para cancelaci�n de certificados digitales por internet','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMServidorCancelacionT','EM','Direcci�n del servicio para cancelaci�n de certificados digitales por internet','Admin',getdate())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMServidorCancelacionT','EP','Direcci�n del servicio para cancelaci�n de certificados digitales por internet','Admin',getdate())
END
