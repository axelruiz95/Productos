USE [RouteADM]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ClienteSu__Statu__1D114BD1]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ClienteSucursal] DROP CONSTRAINT [DF__ClienteSu__Statu__1D114BD1]
END

GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[ClienteSucursal]    Script Date: 07/13/2010 16:47:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClienteSucursal]') AND type in (N'U'))
DROP TABLE [dbo].[ClienteSucursal]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[ClienteSucursal]    Script Date: 07/13/2010 16:47:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ClienteSucursal](
	[IdCedis] [bigint] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[IdSucursal] [varchar](16) NOT NULL,
	[TDA_GLN] [varchar](20) NULL,
	[NombreSucursal] [varchar](75) NULL,
	[Calle] [varchar](250) NULL,
	[NumExterior] [varchar](20) NULL,
	[NumInterior] [varchar](20) NULL,
	[Colonia] [varchar](100) NULL,
	[Localidad] [varchar](50) NULL,
	[Poblacion] [varchar](50) NULL,
	[Entidad] [varchar](50) NULL,
	[Pais] [varchar](50) NULL,
	[Telefonos] [varchar](100) NULL,
	[CP] [varchar](5) NULL,
	[RFC] [varchar](20) NULL,
	[RazonSocial] [varchar](200) NULL,
	[CalleF] [varchar](250) NULL,
	[NumExteriorF] [varchar](20) NULL,
	[NumInteriorF] [varchar](20) NULL,
	[ColoniaF] [varchar](100) NULL,
	[LocalidadF] [varchar](50) NULL,
	[PoblacionF] [varchar](50) NULL,
	[EntidadF] [varchar](50) NULL,
	[PaisF] [varchar](50) NULL,
	[TelefonosF] [varchar](100) NULL,
	[CPF] [varchar](5) NULL,
	[CodigoBarras] [varchar](50) NULL,
	[FormaVenta] [char](1) NULL,
	[Status] [char](1) NULL,
	[Contacto] [varchar](64) NULL,
	[DiasCredito] [int] NULL,
	[LimiteCredito] [money] NULL,
 CONSTRAINT [PK_ClienteSucursal] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdCliente] ASC,
	[IdSucursal] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ClienteSucursal] ADD  CONSTRAINT [DF__ClienteSu__Statu__1D114BD1]  DEFAULT ('A') FOR [Status]
GO

insert into ClienteSucursal 
select *, 0, 0
from ClienteSucursal2

