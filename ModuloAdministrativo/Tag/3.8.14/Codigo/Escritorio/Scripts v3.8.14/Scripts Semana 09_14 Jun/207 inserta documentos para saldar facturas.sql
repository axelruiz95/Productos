USE RouteCPC

insert into Documentos 
values ('NR', 'NOTA DE CR�DITO', 'A', 'A')

insert into DocumentosTipo 
values ('NR', 'NRCF', 'SALDAR VENTAS POR CONSOLIDACI�N', 'A', 'A')

insert into FacturacionGlobal 
values (1, 'LPCF', 'Cadena Global', 'NR', 'NRCF')

select * from DocumentosTipo 

select * from FacturacionGlobal 
