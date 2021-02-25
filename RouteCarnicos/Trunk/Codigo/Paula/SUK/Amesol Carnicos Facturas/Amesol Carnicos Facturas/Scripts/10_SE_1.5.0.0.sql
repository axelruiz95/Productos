IF(SELECT COUNT(*) FROM ValorReferencia WHERE VARCodigo = 'FRMFAC')=0
BEGIN
	INSERT INTO ValorReferencia(VARCodigo,Descripcion,TipoDato,TipoAplicacion,TipoNulo,TipoModificable,MUsuarioId,MFechaHora) VALUES('FRMFAC','Formato de la Factura Electr�nica','N',1,0,0,'Admin',GETDATE())
	INSERT INTO VARValor(VARCodigo,VAVClave,Grupo,Estado,MUsuarioId,MFechaHora) VALUES('FRMFAC','1','',1,'Admin',GETDATE())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FRMFAC','1','EC','Gen�rico','Admin',GETDATE())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FRMFAC','1','ECR','Gen�rico','Admin',GETDATE())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FRMFAC','1','EM','Gen�rico','Admin',GETDATE())
	INSERT INTO VAVDescripcion(VARCodigo,VAVClave,VADTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('FRMFAC','1','EP','Gen�rico','Admin',GETDATE())
END