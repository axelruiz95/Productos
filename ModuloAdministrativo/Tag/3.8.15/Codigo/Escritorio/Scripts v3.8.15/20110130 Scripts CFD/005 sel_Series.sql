USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Series]    Script Date: 01/31/2011 00:03:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Series]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Series]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Series]    Script Date: 01/31/2011 00:03:55 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO



CREATE PROCEDURE [dbo].[sel_Series]
@IdCedis as bigint,
@IdRuta as bigint,
@SubEmpresaId as varchar(20),
@Serie as varchar(5),
@Folio as bigint,
@Fecha as datetime,
@Opc as int
AS

if @Opc = 1
begin
	if exists( select FosH.VendedorID from Route.dbo.FOSHist FosH where FosH.VendedorID = CAST(@IdCedis as varchar(10)) + REPLICATE('0', 4-len(@IdRuta)) + CAST(@IdRuta as varchar(4)) and @IdRuta in (select IdRuta from Rutas where IdCedis = @IdCedis and IdRuta = @IdRuta and CFD = 1) )
		select FolS.Serie as SerieId, FolS.Serie, SubE.NombreEmpresa, SubE.SubEmpresaId as SubId, 1 as CFD --isnull(FolS.Usados + 1,1)
		from Route.dbo.SubEmpresa SubE 
		inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
		inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
		inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FosH.FOSId 
		where SubE.TipoEstado = 1 and FosH.VendedorID = CAST(@IdCedis as varchar(10)) + REPLICATE('0', 4-len(@IdRuta)) + CAST(@IdRuta as varchar(4))
	else
		select SerieFacturasCredito as SerieId, SerieFacturasCredito as Serie, Cedis as Marca, IdCedis as CentroExpID 
		from Configuracion 
		where IdCedis = @IdCedis
end

if @Opc = 2
begin
	if exists( select FosH.VendedorID from Route.dbo.FOSHist FosH where FosH.VendedorID = CAST(@IdCedis as varchar(10)) + REPLICATE('0', 4-len(@IdRuta)) + CAST(@IdRuta as varchar(4)) and @IdRuta in (select IdRuta from Rutas where IdCedis = @IdCedis and IdRuta = @IdRuta and CFD = 1) )
		select FolS.Serie, isnull(FolS.Usados + 1,1)
		from Route.dbo.SubEmpresa SubE 
		inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
		inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
		inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FosH.FOSId 
		where SubE.TipoEstado = 1 and SubE.SubEmpresaId = @SubEmpresaId 
			and FosH.VendedorID = CAST(@IdCedis as varchar(10)) + REPLICATE('0', 4-len(@IdRuta)) + CAST(@IdRuta as varchar(4))
	else
		select SerieFacturasCredito as Serie, ISNULL((select MAX(Folio) + 1 from Ventas where Serie = SerieFacturasCredito),1) as Folio
		from Configuracion 
		where IdCedis = @IdCedis
end

if @Opc = 3
begin
	if exists( select FosH.VendedorID from Route.dbo.FOSHist FosH where FosH.VendedorID = CAST(@IdCedis as varchar(10)) + REPLICATE('0', 4-len(@IdRuta)) + CAST(@IdRuta as varchar(4)) and @IdRuta in (select IdRuta from Rutas where IdCedis = @IdCedis and IdRuta = @IdRuta and CFD = 1) )

		select FolS.Serie, FolS.Usados, @Folio
		from Route.dbo.SubEmpresa SubE 
		inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
		inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
		inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FosH.FOSId 
		where SubE.TipoEstado = 1 and SubE.SubEmpresaId = @SubEmpresaId and FolS.Usados <= @Folio and FolS.Serie = @Serie 
			and FosH.VendedorID = CAST(@IdCedis as varchar(10)) + REPLICATE('0', 4-len(@IdRuta)) + CAST(@IdRuta as varchar(4))
		--select FS.Serie, FS.Usados, @Folio, 'S' as IdMarca, '0' as Existe
		--from Route.dbo.FolioSolicitado FS
		--where Serie = @Serie 
	else
		select SerieFacturasCredito as Serie, ISNULL((select max(Folio) from Ventas where Serie = SerieFacturasCredito),0) as Usados, 
		@Folio as Folio, 'N' as IdMarca, isnull((select Folio from Ventas where IdCedis = @IdCedis and Serie = @Serie and Folio = @Folio),0) as Existe
		from Configuracion 
		where IdCedis = @IdCedis and SerieFacturasCredito = @Serie 
end

if @Opc = 4
begin
	if exists( select FosH.VendedorID from Route.dbo.FOSHist FosH where FosH.VendedorID = CAST(@IdCedis as varchar(10)) + REPLICATE('0', 4-len(@IdRuta)) + CAST(@IdRuta as varchar(4)) and @IdRuta in (select IdRuta from Rutas where IdCedis = @IdCedis and IdRuta = @IdRuta and CFD = 1) )
		select FolS.Serie as SerieId, FolS.Serie, SubE.NombreEmpresa, isnull(FolS.Usados + 1,1), SubE.SubEmpresaId as SubId 		
		from Route.dbo.SubEmpresa SubE 
		inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId 
		inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
		inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FosH.FOSId 
		where SubE.TipoEstado = 1 and FosH.VendedorID = CAST(@IdCedis as varchar(10)) + REPLICATE('0', 4-len(@IdRuta)) + CAST(@IdRuta as varchar(4))

		--select FS.Serie as SerieId, cast(replace(FS.Serie, 'X', '') as varchar(7)) as Serie, 
		--Marca, isnull(VentasContado.Folio,0) as Folio, FH.CentroExpID
		--from Route.dbo.FolioSolicitado FS
		--inner join Route.dbo.FOSHist FH on FH.FolioID = FS.FolioID and FH.FOSId = FS.FOSId  
		--inner join Marcas on Marcas.IdMarca = FH.CentroExpID
		--left outer join VentasContado on VentasContado.IdMarca = Marcas.IdMarca 
		--	and VentasContado.IdCedis = @IdCedis and VentasContado.Fecha = @Fecha 
		--where FS.Serie like '' + isnull((select SerieFacturasCredito from Configuracion where IdCedis = @IdCedis),'') + '%'
	else
		select SerieFacturasContado as SerieId, SerieFacturasContado as Serie, Cedis as Marca, 
		ISNULL((select max(Folio) + 1 from VentasContado where Serie = SerieFacturasContado),1), IdCedis as CentroExpID 
		from Configuracion 
		where IdCedis = @IdCedis
end
	

GO

