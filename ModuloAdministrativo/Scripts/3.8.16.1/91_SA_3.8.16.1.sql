USE [RouteADM]
GO

/****** Object:  Table [dbo].[ComisionesHistorico]    Script Date: 08/31/2011 00:25:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ComisionesHistorico]') AND type in (N'U'))
DROP TABLE [dbo].[ComisionesHistorico]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[ComisionesHistorico]    Script Date: 08/31/2011 00:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ComisionesHistorico](
	[IdCedis] [bigint] NOT NULL,
	[IdVendedor] [bigint] NOT NULL,
	[Vendedor] [varchar](200) NOT NULL,
	[FechaIni] [datetime] NOT NULL,
	[FechaFin] [datetime] NOT NULL,
	[IdComEsquema] [bigint] NOT NULL,
	[Esquema] [varchar](50) NULL,
	[IdConceptoPago] [bigint] NULL,
	[ConceptoPago] [varchar](50) NULL,
	[IdTipoVendedor] [bigint] NULL,
	[TipoVendedor] [varchar](50) NULL,
	[IdMarca] [bigint] NULL,
	[Marca] [varchar](50) NULL,
	[IdProducto] [bigint] NULL,
	[Producto] [varchar](50) NULL,
	[VentaLunes] [money] NULL,
	[VentaMartes] [money] NULL,
	[VentaMiercoles] [money] NULL,
	[VentaJueves] [money] NULL,
	[VentaViernes] [money] NULL,
	[VentaSabado] [money] NULL,
	[DiasTrabajados] [smallint] NULL,
	[PromSemanal] [money] NULL,
	[Inicial] [money] NULL,
	[Final] [money] NULL,
	[Factor] [money] NULL,
	[Pago] [money] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 91, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 91 where  Tipo = 'SA' and Version ='3.8.16.1'
END

GO
