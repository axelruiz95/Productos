USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasDetalle]    Script Date: 08/17/2011 23:00:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VentasDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VentasDetalle]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasDetalle]    Script Date: 08/17/2011 23:00:43 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[up_VentasDetalle]
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as int,
@Folio as bigint,
@Serie as varchar(5),
@Fecha as datetime,
@IdProducto as bigint,
@Cantidad as float,
@Precio as money,
@Iva as float,
@TVenta as int,
@DctoPorc as money,
@DctoImp as money,
@Entregado as float,
@Opc as int

AS

declare @CantidadAnterior as float, @IdRuta as bigint
declare @IdCliente as bigint, @IdSucursal as varchar(20)

declare 
@IdSurtidoD as bigint,
@IdTipoVentaD as int,
@FolioD as bigint,
@SerieD as varchar(6),
@SerieRem as varchar(6)

if @Opc = 1 -- Actualiza Partida de Factura
begin
	set @CantidadAnterior = isnull( (select Cantidad from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto), 0)
	set @TVenta = (select Tipo from VentasTipo where IdTipoVenta = @IdTipoVenta )
	set @IdRuta = isnull( (select IdRuta from Surtidos where IdCedis = @IdCedis and IdSurtido = @IdSurtido), 0)
	
	select @SerieD = SerieDevoluciones from Configuracion where IdCedis = @IdCedis
	
	if @Iva = 0 
	begin
		select @IdCliente = IdCliente, @IdSucursal = IdSucursal
		from Ventas
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio		
		set @Iva = ISNULL( (select Valor from ClientesImpuestos where IdCedis = @IdCedis and IdCliente = @IdCliente and IdSucursal = @IdSucursal and IdProducto = @IdProducto), 0)
	end
	
	delete from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdProducto = @IdProducto

	if @Cantidad <> 0 
	begin
		if @Serie = @SerieD set @Cantidad = @Cantidad * -1
		insert into VentasDetalle values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @IdProducto, @Serie, @Cantidad, @Precio, @Iva, @DctoPorc, @Cantidad * @Precio * @DctoPorc, @Entregado)
	end
	
	if not exists(select IdProducto from SurtidosDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdProducto = @IdProducto)
		insert into SurtidosDetalle values (@IdCedis, @IdSurtido, @IdProducto, @Fecha, 0,0,0,0,0,0,0,0, @Precio, @Iva )
		
	-- if @Serie <> @SerieD exec up_SurtidosCargas @IdCedis, @IdSurtido, 99, 0, '19000101', 0, 3

	if @TVenta = 2 
	begin
		update SurtidosDetalle set VentaContado = VentaContado + @Cantidad - @CantidadAnterior 
		where SurtidosDetalle.Fecha = @Fecha and SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido and SurtidosDetalle.IdProducto = @IdProducto
		update InventarioKardex set VentaContado = VentaContado + @Cantidad - @CantidadAnterior 
		where InventarioKardex.Fecha = @Fecha and InventarioKardex.IdCedis = @IdCedis and InventarioKardex.IdProducto = @IdProducto
	end
	else
	begin
		update SurtidosDetalle set VentaCredito = VentaCredito + @Cantidad - @CantidadAnterior 
		where SurtidosDetalle.Fecha = @Fecha and SurtidosDetalle.IdCedis = @IdCedis and SurtidosDetalle.IdSurtido = @IdSurtido and SurtidosDetalle.IdProducto = @IdProducto
		update InventarioKardex set VentaCredito = VentaCredito + @Cantidad - @CantidadAnterior 
		where InventarioKardex.Fecha = @Fecha and InventarioKardex.IdCedis = @IdCedis and InventarioKardex.IdProducto = @IdProducto
	end

	update Ventas set Subtotal = isnull((select sum((Cantidad * Precio)- DctoImp) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0), 
	Iva = isnull( (select sum(((Cantidad * Precio) - DctoImp) * Iva) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0),
	Ventas.DctoImp = isnull( (select sum(VentasDetalle.DctoImp) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio ), 0)
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

	if exists( select IdCedis from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdRuta = @IdRuta and Fecha = @Fecha and Status = 'HH' )
	begin
		delete from StatusLiquidacion where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdRuta = @IdRuta and Fecha = @Fecha and Status = 'VEN'
		insert into StatusLiquidacion values ( @IdCedis, @IdSurtido, @IdRuta, @Fecha, 'VEN', 'Actualizaci�n de Ventas', getdate() )
	end

	if exists(select IdSurtido from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Cantidad <> Entregado and Serie <> @SerieD )
	begin
		if not exists(select IdSurtido from VentasDevolucion where IdCedisD = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdSurtidoD = @IdSurtido)
		begin
			select @SerieD = SerieDevoluciones from Configuracion where IdCedis = @IdCedis
			select @SerieRem = SerieRemisiones from Configuracion where IdCedis = @IdCedis
			
			select @FolioD = ISNULL(MAX(Folio) + 1, 1)
			from Ventas 
			where IdCedis = @IdCedis and Serie in (@SerieRem, @SerieD)

			insert into Ventas 	
			select SURD.IdCedis, SURD.IdSurtido, @IdTipoVenta, @FolioD, @SerieD, SURD.Fecha, 0,0,0, '', 0, 0, null, null, null
			from Surtidos SURD 
			where SURD.IdCedis = @IdCedis and SURD.IdSurtido = @IdSurtido  
			
			select @IdCliente = IdCliente, @IdSucursal = IdSucursal, @Serie = Serie, @IdSurtidoD = IdSurtido, @IdTipoVentaD = IdTipoVenta  
			from Ventas
			where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

			update Ventas set IdCliente = @IdCliente, IdSucursal = @IdSucursal 
			where IdCedis = @IdCedis and IdSurtido = @IdSurtidoD and IdTipoVenta = @IdTipoVenta and Folio = @FolioD 
			
			insert into VentasDevolucion values (@IdCedis, @IdSurtidoD, @IdTipoVenta, @FolioD, @SerieD, @IdSurtido, @IdTipoVenta, @Folio, @Serie, @IdCliente, @IdSucursal, 'F') 
		end
		else
		begin
			select @IdSurtidoD = IdSurtido, @IdTipoVentaD = IdTipoVentaD, @SerieD = SerieD, @FolioD = FolioD 
			from VentasDevolucion 
			where IdCedisD = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdSurtidoD = @IdSurtido			
		end
		
		delete from VentasDetalle 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtidoD and IdTipoVenta = @IdTipoVentaD and Folio = @FolioD
		
		insert into VentasDetalle 
		select IdCedis, @IdSurtidoD, @IdTipoVentaD, @FolioD, IdProducto, @SerieD, Entregado - Cantidad, Precio, Iva, DctoPorc, DctoImp, 0
		from VentasDetalle 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 
			and Cantidad <> Entregado 

		update Ventas set Subtotal = isnull((select sum((Cantidad * Precio)- DctoImp) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoD and IdTipoVenta = @IdTipoVentaD and Folio = @FolioD ), 0), 
		Iva = isnull( (select sum(((Cantidad * Precio) - DctoImp) * Iva) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoD and IdTipoVenta = @IdTipoVentaD and Folio = @FolioD ), 0),
		Ventas.DctoImp = isnull( (select sum(VentasDetalle.DctoImp) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoD and IdTipoVenta = @IdTipoVentaD and Folio = @FolioD ), 0)
		where IdCedis = @IdCedis and IdSurtido = @IdSurtidoD and IdTipoVenta = @IdTipoVentaD and Folio = @FolioD 
	end
	else
	begin
		select @IdSurtidoD = IdSurtido, @IdTipoVentaD = IdTipoVentaD, @SerieD = SerieD, @FolioD = FolioD 
		from VentasDevolucion 
		where IdCedisD = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and IdSurtidoD = @IdSurtido			
		
		delete from VentasDetalle 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtidoD and IdTipoVenta = @IdTipoVentaD and Folio = @FolioD

		update Ventas set Subtotal = isnull((select sum((Cantidad * Precio)- DctoImp) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoD and IdTipoVenta = @IdTipoVentaD and Folio = @FolioD ), 0), 
		Iva = isnull( (select sum(((Cantidad * Precio) - DctoImp) * Iva) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoD and IdTipoVenta = @IdTipoVentaD and Folio = @FolioD ), 0),
		Ventas.DctoImp = isnull( (select sum(VentasDetalle.DctoImp) from VentasDetalle where IdCedis = @IdCedis and IdSurtido = @IdSurtidoD and IdTipoVenta = @IdTipoVentaD and Folio = @FolioD ), 0)
		where IdCedis = @IdCedis and IdSurtido = @IdSurtidoD and IdTipoVenta = @IdTipoVentaD and Folio = @FolioD 
	end
end

GO


USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 63, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 63 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO

