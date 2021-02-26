USE [RouteADM]
GO

/****** Object:  Table [dbo].[RepCreditosCobranza]    Script Date: 09/06/2010 09:45:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RepCreditosCobranza]') AND type in (N'U'))
DROP TABLE [dbo].[RepCreditosCobranza]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[RepCreditosCobranza]    Script Date: 09/06/2010 09:45:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RepCreditosCobranza](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCedis] [bigint] NULL,
	[IdSurtido] [bigint] NULL,
	[Orden] [int] NULL,
	[Concepto] [varchar](10) NULL,
	[IdMarca] [bigint] NULL,
	[Marca] [varchar](30) NULL,
	[NombreSucursal] [varchar](60) NULL,
	[Folio] [varchar](10) NULL,
	[Total] [money] NULL,
 CONSTRAINT [PK_RepCreditosCobranza] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
