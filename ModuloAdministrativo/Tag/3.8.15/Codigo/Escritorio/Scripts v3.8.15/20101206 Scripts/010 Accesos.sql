
use RouteADM 

insert into Modulo values ('COMHIS', 'Registro de Hist�rico de Comisiones')
insert into ModuloGrupo values ('GCOM', 'COMHIS')
GO

update ModuloGrupo set IdGrupoM = 'GDEVVTAS' where IdModulo = 'DEVVTAS'
GO



 

