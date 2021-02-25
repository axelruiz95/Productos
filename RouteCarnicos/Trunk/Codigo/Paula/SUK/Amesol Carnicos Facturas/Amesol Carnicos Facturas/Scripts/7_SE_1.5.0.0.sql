IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'SEMVersionCFD' AND TipoMensaje = 'T' AND TipoAplicacion = 1) = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMVersionCFD','T',1,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMVersionCFD','EC','Versi�n CFD','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMVersionCFD','ECR','Versi�n CFD','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMVersionCFD','EM','Versi�n CFD','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMVersionCFD','EP','Versi�n CFD','Admin',GETDATE())
END

IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'SEMVersionCFDT' AND TipoMensaje = 'G' AND TipoAplicacion = 1) = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMVersionCFDT','G',1,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMVersionCFDT','EC','Versi�n del comprobante fiscal digital','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMVersionCFDT','ECR','Versi�n del comprobante fiscal digital','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMVersionCFDT','EM','Versi�n del comprobante fiscal digital','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMVersionCFDT','EP','Versi�n del comprobante fiscal digitall','Admin',GETDATE())
END


IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'SEMProveedorTimbre' AND TipoMensaje = 'T' AND TipoAplicacion = 1) = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMProveedorTimbre','T',1,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMProveedorTimbre','EC','Proveedor del timbrado','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMProveedorTimbre','ECR','Proveedor del timbrado','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMProveedorTimbre','EM','Proveedor del timbrado','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMProveedorTimbre','EP','Proveedor del timbrado','Admin',GETDATE())
END

IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'SEMProveedorTimbreT' AND TipoMensaje = 'G' AND TipoAplicacion = 1) = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMProveedorTimbreT','G',1,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMProveedorTimbreT','EC','Empresa que timbrar� los comporbantes fiscales digitales','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMProveedorTimbreT','ECR','Empresa que timbrar� los comporbantes fiscales digitales','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMProveedorTimbreT','EM','Empresa que timbrar� los comporbantes fiscales digitales','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMProveedorTimbreT','EP','Empresa que timbrar� los comporbantes fiscales digitales','Admin',GETDATE())
END


IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'SEMCustomerKey' AND TipoMensaje = 'T' AND TipoAplicacion = 1) = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMCustomerKey','T',1,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCustomerKey','EC','Customer Key','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCustomerKey','ECR','Customer Key','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCustomerKey','EM','Customer Key','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCustomerKey','EP','Customer Key','Admin',GETDATE())
END

IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'SEMCustomerKeyT' AND TipoMensaje = 'G' AND TipoAplicacion = 1) = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMCustomerKeyT','G',1,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCustomerKeyT','EC','Llave que te identificar� ante el proovedor','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCustomerKeyT','ECR','Llave que te identificar� ante el proovedor','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCustomerKeyT','EM','Llave que te identificar� ante el proovedor','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCustomerKeyT','EP','Llave que te identificar� ante el proovedor','Admin',GETDATE())
END



IF (SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'SEMServidorTimbre' AND TipoMensaje = 'T' AND TipoAplicacion = 1) = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMServidorTimbre','T',1,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMServidorTimbre','EC','Servidor Timbre','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMServidorTimbre','ECR','Servidor Timbre','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMServidorTimbre','EM','Servidor Timbre','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMServidorTimbre','EP','Servidor Timbre','Admin',GETDATE())
END

IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'SEMServidorTimbreT' AND TipoMensaje = 'G' AND TipoAplicacion = 1) = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMServidorTimbreT','G',1,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMServidorTimbreT','EC','Direcci�n dondte esta el Servidor del Proveedor','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMServidorTimbreT','ECR','Direcci�n dondte esta el Servidor del Proveedor','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMServidorTimbreT','EM','Direcci�n dondte esta el Servidor del Proveedor','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMServidorTimbreT','EP','Direcci�n dondte esta el Servidor del Proveedor','Admin',GETDATE())
END