DECLARE @Clave as VARCHAR(35)
DECLARE @Titulo as VARCHAR(150)
DECLARE @Descripcion VARCHAR(150)
DECLARE @Ruta VARCHAR(150)
DECLARE @Perfil VARCHAR(8)

SET @Clave = 'KPI008'
SET @Titulo = 'Gr�ficos de Desempe�o del Negocio'
SET @Descripcion = 'An�lisis Gr�fico del Desempe�o del Negocio'
SET @Ruta = 'GraphVentasSeg.asp'
SET @Perfil = 'Admin'


DECLARE @MODId VARCHAR(16)
SET @MODId = (SELECT TOP 1 MODId FROM Modulo WHERE TipoInterfaz = 3)

/*
DELETE IntPer WHERE ACTId = 'ACT'+@Clave
DELETE IntUsu WHERE ACTId = 'ACT'+@Clave
delete Interfaz where ACTId = 'ACT'+@Clave 
delete Actividad where ACTId = 'ACT'+@Clave 

DELETE MENDetalle WHERE MENClave = 'XACTWEB'+@Clave
DELETE Mensaje WHERE MENClave = 'XACTWEB'+@Clave
DELETE MENDetalle WHERE MENClave = 'XACTWEB'+@Clave+'D'
DELETE Mensaje WHERE MENClave = 'XACTWEB'+@Clave+'D'
*/


INSERT INTO Mensaje VALUES ('XACTWEB'+@Clave,'M',1,3,'Admin',GETDATE())
INSERT INTO MENDetalle VALUES('XACTWEB'+@Clave,'EC',@Titulo,'Admin',GETDATE())
INSERT INTO MENDetalle VALUES('XACTWEB'+@Clave,'EM',@Titulo,'Admin',GETDATE())
INSERT INTO MENDetalle VALUES('XACTWEB'+@Clave,'EP',@Titulo,'Admin',GETDATE())
INSERT INTO MENDetalle VALUES('XACTWEB'+@Clave,'ECR',@Titulo,'Admin',GETDATE())

INSERT INTO Mensaje VALUES ('XACTWEB'+@Clave+'D','M',1,3,'Admin',GETDATE())
INSERT INTO MENDetalle VALUES('XACTWEB'+@Clave+'D','EC',@Descripcion,'Admin',GETDATE())
INSERT INTO MENDetalle VALUES('XACTWEB'+@Clave+'D','EM',@Descripcion,'Admin',GETDATE())
INSERT INTO MENDetalle VALUES('XACTWEB'+@Clave+'D','EP',@Descripcion,'Admin',GETDATE())
INSERT INTO MENDetalle VALUES('XACTWEB'+@Clave+'D','ECR',@Descripcion,'Admin',GETDATE())


INSERT INTO Actividad VALUES('ACT'+@Clave,'XACTWEB'+@Clave,'XACTWEB'+@Clave+'D',0x0,'Admin', GETDATE())
update actividad set imagen = (Select TOP 1 Imagen from Modulo where MODId= @MODId) where actid = 'ACT'+@Clave
INSERT INTO Interfaz values('ACT'+@Clave,3,@MODId,1,@Ruta,'inicio','inicio','CRUD',0,getdate(),'Admin')
INSERT INTO IntPer VALUES('ACT'+@Clave,3,'Admin',@MODId, 'CRUDEOP',0,GETDATE(),'Admin')
