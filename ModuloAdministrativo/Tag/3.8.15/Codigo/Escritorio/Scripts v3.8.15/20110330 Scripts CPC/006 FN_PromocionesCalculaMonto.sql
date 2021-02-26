USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_PromocionesCalculaMonto]    Script Date: 03/30/2011 19:00:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_PromocionesCalculaMonto]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FN_PromocionesCalculaMonto]
GO

USE [RouteCPC]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_PromocionesCalculaMonto]    Script Date: 03/30/2011 19:00:07 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE FUNCTION [dbo].[FN_PromocionesCalculaMonto]
(
@IdAplicacion as bigint,
@IdPromocion as bigint
)  
RETURNS Table AS  
return
(
	select PromocionesAplicadasDetalle.IdAplicacion, PromocionesAplicadasDetalle.IdPromocion, VentasDetalle.IdCedis, VentasDetalle.IdTipoVenta, VentasDetalle.Serie, VentasDetalle.Folio, VentasDetalle.IdProducto, VentasDetalle.Total, Porcentaje, VentasDetalle.Total * Porcentaje as Monto
	from PromocionesAplicadasDetalle
	inner join VentasDetalle on VentasDetalle.IdCedis = PromocionesAplicadasDetalle.IdCedis -- and VentasDetalle.Serie = PromocionesAplicadasDetalle.Serie
		and VentasDetalle.IdTipoVenta = PromocionesAplicadasDetalle.IdTipoVenta and VentasDetalle.Folio = PromocionesAplicadasDetalle.Folio 
	inner join FN_PromocionesProductos (@IdPromocion) as FNProds on FNProds.IdProducto = VentasDetalle.IdProducto
	where IdAplicacion = @IdAplicacion and IdPromocion = @IdPromocion
)

GO

