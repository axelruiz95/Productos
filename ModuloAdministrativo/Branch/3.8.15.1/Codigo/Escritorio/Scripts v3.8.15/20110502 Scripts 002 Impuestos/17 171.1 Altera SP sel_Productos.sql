USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Productos]    Script Date: 05/03/2011 16:57:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Productos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Productos]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Productos]    Script Date: 05/03/2011 16:57:40 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sel_Productos]

AS

--select P.IdProducto as 'Clave', P.CodBarras as 'C. Barras', P.PRODUCTO as 'Producto', P.IVA as 'Impuesto', P.CONVERSION as 'Conversion', isnull(M.MARCA, 'Sin Marca') as 'Marca', isnull(G.Grupo, 'Sin Grupo') as 'Grupo', isnull(F.FAMILIA, 'Sin Familia') as 'Familia', isnull(S.SubFamilia, 'Sin SubFamilia') as 'SubFamilia', isnull(r.presentacion, 'Sin Presentaci�n') as 'Presentaci�n', F.FechaAlta,
select P.IdProducto as 'Clave', P.CodBarras as 'C. Barras', P.PRODUCTO as 'Producto', dbo.FN_CalculaImpuestos(0,0,0,P.IdProducto) as Impuestos, P.CONVERSION as 'Conversion', isnull(M.MARCA, 'Sin Marca') as 'Marca', isnull(G.Grupo, 'Sin Grupo') as 'Grupo', isnull(F.FAMILIA, 'Sin Familia') as 'Familia', isnull(S.SubFamilia, 'Sin SubFamilia') as 'SubFamilia', isnull(r.presentacion, 'Sin Presentaci�n') as 'Presentaci�n', F.FechaAlta,
case P.Status 
        when 'A' then 'Activo'
        else 'Baja'
        end as 'Estatus',
case P.Decimales
        when 1 then 'Decimales'
        else 'No Decimales'
        end as 'Decimales'
from Productos P
left outer join Familias F on P.IdFamilia = F.IdFamilia
left outer join Grupos G  on P.IdGrupo = G.IdGrupo
left outer join Marcas M on P.IdMarca = M.IdMarca
left outer join Subfamilias S on P.IdSubfamilia = S.IdSubFamilia
left outer join presentacion r on P.IdPresentacion = R.IdPresentacion
WHERE P.Status = 'A'
order by P.IdProducto
GO

