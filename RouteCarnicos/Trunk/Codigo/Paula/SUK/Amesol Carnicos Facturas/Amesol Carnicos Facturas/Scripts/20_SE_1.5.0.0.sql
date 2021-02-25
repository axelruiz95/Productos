
IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'E0816')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('E0816','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('E0816', 'EC', '[E0816] El formato de correo es incorrecto', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('E0816', 'ECR', '[E0816] El formato de correo es incorrecto', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('E0816', 'EP', '[E0816] El formato de correo es incorrecto', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('E0816', 'EM', '[E0816] El formato de correo es incorrecto', 'Admin', GETDATE())
END


IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHCorreoElectronico')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHCorreoElectronico','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHCorreoElectronico', 'EC', 'Correo electr�nico', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHCorreoElectronico', 'ECR', 'Correo electr�nico', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHCorreoElectronico', 'EP', 'Correo electr�nico', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHCorreoElectronico', 'EM', 'Correo electr�nico', 'Admin', GETDATE())
END


IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHCorreoElectronicoT')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHCorreoElectronicoT','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHCorreoElectronicoT', 'EC', 'Direcci�n del correo electr�nico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHCorreoElectronicoT', 'ECR', 'Direcci�n del correo electr�nico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHCorreoElectronicoT', 'EP', 'Direcci�n del correo electr�nico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHCorreoElectronicoT', 'EM', 'Direcci�n del correo electr�nico saliente', 'Admin', GETDATE())
END



IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHPuerto')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHPuerto','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHPuerto', 'EC', 'Puerto', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHPuerto', 'ECR', 'Puerto', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHPuerto', 'EP', 'Puerto', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHPuerto', 'EM', 'Puerto', 'Admin', GETDATE())
END


IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHPuertoT')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHPuertoT','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHPuertoT', 'EC', 'Puerto del servidor SMTP del correo electr�nico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHPuertoT', 'ECR', 'Puerto del servidor SMTP del correo electr�nico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHPuertoT', 'EP', 'Puerto del servidor SMTP del correo electr�nico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHPuertoT', 'EM', 'Puerto del servidor SMTP del correo electr�nico saliente', 'Admin', GETDATE())
END

IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHServidorSMTP')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHServidorSMTP','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHServidorSMTP', 'EC', 'Servidor SMTP', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHServidorSMTP', 'ECR', 'Servidor SMTP', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHServidorSMTP', 'EP', 'Servidor SMTP', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHServidorSMTP', 'EM', 'Servidor SMTP', 'Admin', GETDATE())
END

IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHServidorSMTPT')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHServidorSMTPT','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHServidorSMTPT', 'EC', 'Nombre del servidor SMTP de la cuenta de correo electr�nico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHServidorSMTPT', 'ECR', 'Nombre del servidor SMTP de la cuenta de correo electr�nico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHServidorSMTPT', 'EP', 'Nombre del servidor SMTP de la cuenta de correo electr�nico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHServidorSMTPT', 'EM', 'Nombre del servidor SMTP de la cuenta de correo electr�nico saliente', 'Admin', GETDATE())
END

IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHConfirmarContrase�a')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHConfirmarContrase�a','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContrase�a', 'EC', 'Confirmar Contrase�a', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContrase�a', 'ECR', 'Confirmar Contrase�a', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContrase�a', 'EP', 'Confirmar Contrase�a', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContrase�a', 'EM', 'Confirmar Contrase�a', 'Admin', GETDATE())
END

IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHContrase�a')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHContrase�a','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHContrase�a', 'EC', 'Contrase�a', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHContrase�a', 'ECR', 'Contrase�a', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHContrase�a', 'EP', 'Contrase�a', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHContrase�a', 'EM', 'Contrase�a', 'Admin', GETDATE())
END

IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHContrase�aT')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHContrase�aT','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHContrase�aT', 'EC', 'Contrase�a del correo electr�nico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHContrase�aT', 'ECR', 'Contrase�a del correo electr�nico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHContrase�aT', 'EP', 'Contrase�a del correo electr�nico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHContrase�aT', 'EM', 'Contrase�a del correo electr�nico saliente', 'Admin', GETDATE())
END



IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHConfirmarContrase�a')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHConfirmarContrase�a','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContrase�a', 'EC', 'Confirmar Contrase�a', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContrase�a', 'ECR', 'Confirmar Contrase�a', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContrase�a', 'EP', 'Confirmar Contrase�a', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContrase�a', 'EM', 'Confirmar Contrase�a', 'Admin', GETDATE())
END

IF(SELECT COUNT(*) FROM Mensaje WHERE MENClave = 'COHConfirmarContrase�aT')=0
BEGIN
	INSERT INTO Mensaje (MENClave, TipoMensaje, TipoAplicacion, TipoProyecto, MUsuarioId, MFechaHora)
	VALUES('COHConfirmarContrase�aT','U',1,3,'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContrase�aT', 'EC', 'Confirmar contrase�a del correo electr�nico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContrase�aT', 'ECR', 'Confirmar contrase�a del correo electr�nico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContrase�aT', 'EP', 'Confirmar contrase�a del correo electr�nico saliente', 'Admin', GETDATE())
	INSERT INTO MENDetalle (MENClave, MEDTipoLenguaje, Descripcion, MUsuarioId, MFechaHora)
	VALUES 
	('COHConfirmarContrase�aT', 'EM', 'Confirmar contrase�a del correo electr�nico saliente', 'Admin', GETDATE())
END

if(Select COUNT (*) from Mensaje where MENClave ='COHSSL')= 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('COHSSL','T',1,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('COHSSL','EM','Secure Socket Layer','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('COHSSL','EC','Secure Socket Layer','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('COHSSL','ECR','Secure Socket Layer','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('COHSSL','EP','Secure Socket Layer','Admin',GETDATE())
END

if (Select COUNT(*) from Mensaje where MENClave ='COHSSLT') = 0
BEGIN
	INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('COHSSLT','U',1,3,'Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('COHSSLT','EM','Indica si se utiliza SSL (Secure Sockets Layer) para cifrar la conexi�n.','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('COHSSLT','EC','Indica si se utiliza SSL (Secure Sockets Layer) para cifrar la conexi�n.','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('COHSSLT','ECR','Indica si se utiliza SSL (Secure Sockets Layer) para cifrar la conexi�n.','Admin',GETDATE())
	INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('COHSSLT','EP','Indica si se utiliza SSL (Secure Sockets Layer) para cifrar la conexi�n.','Admin',GETDATE())
END
