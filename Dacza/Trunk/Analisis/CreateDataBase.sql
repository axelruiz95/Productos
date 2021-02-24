USE [master]
GO
/****** Object:  Database [DACZA]    Script Date: 11/06/2016 02:10:11 a. m. ******/
CREATE DATABASE [DACZA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DACZA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DACZA.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DACZA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DACZA_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DACZA] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DACZA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DACZA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DACZA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DACZA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DACZA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DACZA] SET ARITHABORT OFF 
GO
ALTER DATABASE [DACZA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DACZA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DACZA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DACZA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DACZA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DACZA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DACZA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DACZA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DACZA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DACZA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DACZA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DACZA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DACZA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DACZA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DACZA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DACZA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DACZA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DACZA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DACZA] SET  MULTI_USER 
GO
ALTER DATABASE [DACZA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DACZA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DACZA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DACZA] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DACZA] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DACZA]
GO
/****** Object:  Table [dbo].[Almacen]    Script Date: 11/06/2016 02:10:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Almacen](
	[AlmacenId] [varchar](8) NOT NULL,
	[SucursalId] [varchar](8) NOT NULL,
	[Clave] [varchar](10) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Activo] [bit] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioId] [varchar](8) NOT NULL,
 CONSTRAINT [PK_Almacen] PRIMARY KEY CLUSTERED 
(
	[AlmacenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Articulo]    Script Date: 11/06/2016 02:10:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Articulo](
	[ArticuloId] [varchar](8) NOT NULL,
	[Clave] [varchar](10) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[DescripcionLarga] [varchar](250) NULL,
	[Grupo] [varchar](50) NOT NULL,
	[Unidad] [varchar](20) NOT NULL,
	[Tipo] [smallint] NOT NULL,
	[Activo] [bit] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioId] [varchar](8) NOT NULL,
 CONSTRAINT [PK_Articulo] PRIMARY KEY CLUSTERED 
(
	[ArticuloId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 11/06/2016 02:10:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [varchar](8) NOT NULL,
	[Clave] [varchar](10) NOT NULL,
	[RFC] [varchar](15) NOT NULL,
	[RazonSocial] [varchar](150) NOT NULL,
	[Activo] [bit] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioId] [varchar](8) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClienteDomicilio]    Script Date: 11/06/2016 02:10:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClienteDomicilio](
	[DomicilioId] [varchar](8) NOT NULL,
	[ClienteId] [varchar](8) NOT NULL,
	[Tipo] [smallint] NOT NULL,
	[Calle] [varchar](64) NOT NULL,
	[NumeroExt] [varchar](16) NOT NULL,
	[NumeroInt] [varchar](16) NULL,
	[CodigoPostal] [varchar](16) NULL,
	[Colonia] [varchar](64) NOT NULL,
	[Localidad] [varchar](64) NULL,
	[Poblacion] [varchar](64) NOT NULL,
	[Entidad] [varchar](64) NOT NULL,
	[Pais] [varchar](64) NOT NULL,
	[Activo] [bit] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioId] [varchar](8) NOT NULL,
 CONSTRAINT [PK_ClienteDomicilio] PRIMARY KEY CLUSTERED 
(
	[DomicilioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClienteTelefono]    Script Date: 11/06/2016 02:10:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClienteTelefono](
	[TelefonoId] [varchar](8) NOT NULL,
	[ClienteId] [varchar](8) NOT NULL,
	[Tipo] [smallint] NOT NULL,
	[Lada] [varchar](10) NULL,
	[Numero] [varchar](20) NOT NULL,
	[Activo] [bit] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioId] [varchar](8) NOT NULL,
 CONSTRAINT [PK_ClienteTelefono] PRIMARY KEY CLUSTERED 
(
	[TelefonoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Folio]    Script Date: 11/06/2016 02:10:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Folio](
	[FolioId] [varchar](8) NOT NULL,
	[TipoMovimiento] [smallint] NOT NULL,
	[ValorInicial] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioId] [varchar](8) NOT NULL,
 CONSTRAINT [PK_Folio] PRIMARY KEY CLUSTERED 
(
	[FolioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FolioDetalle]    Script Date: 11/06/2016 02:10:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FolioDetalle](
	[DetalleId] [varchar](8) NOT NULL,
	[FolioId] [varchar](8) NOT NULL,
	[TipoContenido] [smallint] NOT NULL,
	[Formato] [varchar](20) NOT NULL,
	[Activo] [bit] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioId] [varchar](8) NOT NULL,
 CONSTRAINT [PK_FolioDetalle] PRIMARY KEY CLUSTERED 
(
	[DetalleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FolioTaller]    Script Date: 11/06/2016 02:10:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FolioTaller](
	[FolioId] [varchar](8) NOT NULL,
	[TallerId] [varchar](8) NOT NULL,
	[Usados] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioId] [varchar](8) NOT NULL,
 CONSTRAINT [PK_FolioTaller] PRIMARY KEY CLUSTERED 
(
	[FolioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InventarioTaller]    Script Date: 11/06/2016 02:10:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InventarioTaller](
	[TallerId] [varchar](8) NOT NULL,
	[ArticuloId] [varchar](8) NOT NULL,
	[Existencia] [float] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioId] [varchar](8) NOT NULL,
 CONSTRAINT [PK_InventarioTaller] PRIMARY KEY CLUSTERED 
(
	[TallerId] ASC,
	[ArticuloId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ODTDetalle]    Script Date: 11/06/2016 02:10:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ODTDetalle](
	[OrdenId] [varchar](8) NOT NULL,
	[ArticuloId] [varchar](8) NOT NULL,
	[Cantidad] [float] NOT NULL,
	[Partida] [smallint] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioId] [varchar](8) NOT NULL,
 CONSTRAINT [PK_ODTDetalle] PRIMARY KEY CLUSTERED 
(
	[OrdenId] ASC,
	[ArticuloId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrdenTrabajo]    Script Date: 11/06/2016 02:10:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrdenTrabajo](
	[OrdenId] [varchar](8) NOT NULL,
	[TallerId] [varchar](8) NOT NULL,
	[AgenteId] [varchar](8) NOT NULL,
	[ClienteId] [varchar](8) NOT NULL,
	[VinId] [varchar](8) NOT NULL,
	[Folio] [varchar](20) NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFin] [datetime] NULL,
	[Fase] [smallint] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioId] [varchar](8) NOT NULL,
 CONSTRAINT [PK_OrdenTrabajo] PRIMARY KEY CLUSTERED 
(
	[OrdenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Recarga]    Script Date: 11/06/2016 02:10:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Recarga](
	[RecargaId] [varchar](8) NOT NULL,
	[TallerId] [varchar](8) NOT NULL,
	[AgenteId] [varchar](8) NOT NULL,
	[Folio] [varchar](20) NOT NULL,
	[FechaSolicitud] [datetime] NOT NULL,
	[FechaSurtido] [datetime] NULL,
	[Fase] [smallint] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioId] [varchar](8) NOT NULL,
 CONSTRAINT [PK_Recarga] PRIMARY KEY CLUSTERED 
(
	[RecargaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RECDetalle]    Script Date: 11/06/2016 02:10:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RECDetalle](
	[DetalleId] [varchar](8) NOT NULL,
	[RecargaId] [varchar](8) NOT NULL,
	[ArticuloId] [varchar](8) NULL,
	[ArticuloDesc] [varchar](100) NULL,
	[Cantidad] [float] NOT NULL,
	[Partida] [smallint] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioId] [varchar](8) NOT NULL,
 CONSTRAINT [PK_RECDetalle] PRIMARY KEY CLUSTERED 
(
	[DetalleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 11/06/2016 02:10:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sucursal](
	[SucursalId] [varchar](8) NOT NULL,
	[Clave] [varchar](10) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Activo] [bit] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioId] [varchar](8) NOT NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[SucursalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Taller]    Script Date: 11/06/2016 02:10:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Taller](
	[TallerId] [varchar](8) NOT NULL,
	[AlmacenId] [varchar](8) NOT NULL,
	[Clave] [varchar](10) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Activo] [bit] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioId] [varchar](8) NOT NULL,
 CONSTRAINT [PK_Taller] PRIMARY KEY CLUSTERED 
(
	[TallerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Traspaso]    Script Date: 11/06/2016 02:10:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Traspaso](
	[TraspasoId] [varchar](8) NOT NULL,
	[RecargaId] [varchar](8) NOT NULL,
	[AlmacenId] [varchar](8) NOT NULL,
	[TallerId] [varchar](8) NOT NULL,
	[Folio] [varchar](20) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Fase] [smallint] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioId] [varchar](8) NOT NULL,
 CONSTRAINT [PK_Traspaso] PRIMARY KEY CLUSTERED 
(
	[TraspasoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRPDetalle]    Script Date: 11/06/2016 02:10:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRPDetalle](
	[TraspasoId] [varchar](8) NOT NULL,
	[ArticuloId] [varchar](8) NOT NULL,
	[Cantidad] [float] NOT NULL,
	[Partida] [smallint] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioId] [varchar](8) NOT NULL,
 CONSTRAINT [PK_TRPDetalle] PRIMARY KEY CLUSTERED 
(
	[TraspasoId] ASC,
	[ArticuloId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 11/06/2016 02:10:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioId] [varchar](8) NOT NULL,
	[TallerId] [varchar](8) NOT NULL,
	[Clave] [varchar](10) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Tipo] [smallint] NOT NULL,
	[Activo] [bit] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
 CONSTRAINT [PK_Agente] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vin]    Script Date: 11/06/2016 02:10:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vin](
	[VinId] [varchar](8) NOT NULL,
	[ArticuloId] [varchar](8) NOT NULL,
	[ClienteId] [varchar](8) NOT NULL,
	[Clave] [varchar](20) NOT NULL,
	[Placas] [varchar](20) NOT NULL,
	[Activo] [bit] NOT NULL,
	[MFechaHora] [datetime] NOT NULL,
	[MUsuarioId] [varchar](8) NOT NULL,
 CONSTRAINT [PK_Vin] PRIMARY KEY CLUSTERED 
(
	[VinId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Almacen]  WITH CHECK ADD  CONSTRAINT [FK_Almacen_Sucursal] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[Sucursal] ([SucursalId])
GO
ALTER TABLE [dbo].[Almacen] CHECK CONSTRAINT [FK_Almacen_Sucursal]
GO
ALTER TABLE [dbo].[ClienteDomicilio]  WITH CHECK ADD  CONSTRAINT [FK_ClienteDomicilio_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[ClienteDomicilio] CHECK CONSTRAINT [FK_ClienteDomicilio_Cliente]
GO
ALTER TABLE [dbo].[ClienteTelefono]  WITH CHECK ADD  CONSTRAINT [FK_ClienteTelefono_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[ClienteTelefono] CHECK CONSTRAINT [FK_ClienteTelefono_Cliente]
GO
ALTER TABLE [dbo].[FolioDetalle]  WITH CHECK ADD  CONSTRAINT [FK_FolioDetalle_Folio] FOREIGN KEY([FolioId])
REFERENCES [dbo].[Folio] ([FolioId])
GO
ALTER TABLE [dbo].[FolioDetalle] CHECK CONSTRAINT [FK_FolioDetalle_Folio]
GO
ALTER TABLE [dbo].[FolioTaller]  WITH CHECK ADD  CONSTRAINT [FK_FolioTaller_Taller] FOREIGN KEY([TallerId])
REFERENCES [dbo].[Taller] ([TallerId])
GO
ALTER TABLE [dbo].[FolioTaller] CHECK CONSTRAINT [FK_FolioTaller_Taller]
GO
ALTER TABLE [dbo].[InventarioTaller]  WITH CHECK ADD  CONSTRAINT [FK_InventarioTaller_Articulo] FOREIGN KEY([ArticuloId])
REFERENCES [dbo].[Articulo] ([ArticuloId])
GO
ALTER TABLE [dbo].[InventarioTaller] CHECK CONSTRAINT [FK_InventarioTaller_Articulo]
GO
ALTER TABLE [dbo].[InventarioTaller]  WITH CHECK ADD  CONSTRAINT [FK_InventarioTaller_Taller] FOREIGN KEY([TallerId])
REFERENCES [dbo].[Taller] ([TallerId])
GO
ALTER TABLE [dbo].[InventarioTaller] CHECK CONSTRAINT [FK_InventarioTaller_Taller]
GO
ALTER TABLE [dbo].[ODTDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ODTDetalle_Articulo] FOREIGN KEY([ArticuloId])
REFERENCES [dbo].[Articulo] ([ArticuloId])
GO
ALTER TABLE [dbo].[ODTDetalle] CHECK CONSTRAINT [FK_ODTDetalle_Articulo]
GO
ALTER TABLE [dbo].[ODTDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ODTDetalle_OrdenTrabajo] FOREIGN KEY([OrdenId])
REFERENCES [dbo].[OrdenTrabajo] ([OrdenId])
GO
ALTER TABLE [dbo].[ODTDetalle] CHECK CONSTRAINT [FK_ODTDetalle_OrdenTrabajo]
GO
ALTER TABLE [dbo].[OrdenTrabajo]  WITH CHECK ADD  CONSTRAINT [FK_OrdenTrabajo_Agente] FOREIGN KEY([AgenteId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[OrdenTrabajo] CHECK CONSTRAINT [FK_OrdenTrabajo_Agente]
GO
ALTER TABLE [dbo].[OrdenTrabajo]  WITH CHECK ADD  CONSTRAINT [FK_OrdenTrabajo_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[OrdenTrabajo] CHECK CONSTRAINT [FK_OrdenTrabajo_Cliente]
GO
ALTER TABLE [dbo].[OrdenTrabajo]  WITH CHECK ADD  CONSTRAINT [FK_OrdenTrabajo_Taller] FOREIGN KEY([TallerId])
REFERENCES [dbo].[Taller] ([TallerId])
GO
ALTER TABLE [dbo].[OrdenTrabajo] CHECK CONSTRAINT [FK_OrdenTrabajo_Taller]
GO
ALTER TABLE [dbo].[OrdenTrabajo]  WITH CHECK ADD  CONSTRAINT [FK_OrdenTrabajo_Vin] FOREIGN KEY([VinId])
REFERENCES [dbo].[Vin] ([VinId])
GO
ALTER TABLE [dbo].[OrdenTrabajo] CHECK CONSTRAINT [FK_OrdenTrabajo_Vin]
GO
ALTER TABLE [dbo].[Recarga]  WITH CHECK ADD  CONSTRAINT [FK_Recarga_Agente] FOREIGN KEY([AgenteId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[Recarga] CHECK CONSTRAINT [FK_Recarga_Agente]
GO
ALTER TABLE [dbo].[Recarga]  WITH CHECK ADD  CONSTRAINT [FK_Recarga_Taller] FOREIGN KEY([TallerId])
REFERENCES [dbo].[Taller] ([TallerId])
GO
ALTER TABLE [dbo].[Recarga] CHECK CONSTRAINT [FK_Recarga_Taller]
GO
ALTER TABLE [dbo].[RECDetalle]  WITH CHECK ADD  CONSTRAINT [FK_RECDetalle_Articulo] FOREIGN KEY([ArticuloId])
REFERENCES [dbo].[Articulo] ([ArticuloId])
GO
ALTER TABLE [dbo].[RECDetalle] CHECK CONSTRAINT [FK_RECDetalle_Articulo]
GO
ALTER TABLE [dbo].[RECDetalle]  WITH CHECK ADD  CONSTRAINT [FK_RECDetalle_Recarga] FOREIGN KEY([RecargaId])
REFERENCES [dbo].[Recarga] ([RecargaId])
GO
ALTER TABLE [dbo].[RECDetalle] CHECK CONSTRAINT [FK_RECDetalle_Recarga]
GO
ALTER TABLE [dbo].[Taller]  WITH CHECK ADD  CONSTRAINT [FK_Taller_Almacen] FOREIGN KEY([AlmacenId])
REFERENCES [dbo].[Almacen] ([AlmacenId])
GO
ALTER TABLE [dbo].[Taller] CHECK CONSTRAINT [FK_Taller_Almacen]
GO
ALTER TABLE [dbo].[Traspaso]  WITH CHECK ADD  CONSTRAINT [FK_Traspaso_Almacen] FOREIGN KEY([AlmacenId])
REFERENCES [dbo].[Almacen] ([AlmacenId])
GO
ALTER TABLE [dbo].[Traspaso] CHECK CONSTRAINT [FK_Traspaso_Almacen]
GO
ALTER TABLE [dbo].[Traspaso]  WITH CHECK ADD  CONSTRAINT [FK_Traspaso_Recarga] FOREIGN KEY([RecargaId])
REFERENCES [dbo].[Recarga] ([RecargaId])
GO
ALTER TABLE [dbo].[Traspaso] CHECK CONSTRAINT [FK_Traspaso_Recarga]
GO
ALTER TABLE [dbo].[Traspaso]  WITH CHECK ADD  CONSTRAINT [FK_Traspaso_Taller] FOREIGN KEY([TallerId])
REFERENCES [dbo].[Taller] ([TallerId])
GO
ALTER TABLE [dbo].[Traspaso] CHECK CONSTRAINT [FK_Traspaso_Taller]
GO
ALTER TABLE [dbo].[TRPDetalle]  WITH CHECK ADD  CONSTRAINT [FK_TRPDetalle_Articulo] FOREIGN KEY([ArticuloId])
REFERENCES [dbo].[Articulo] ([ArticuloId])
GO
ALTER TABLE [dbo].[TRPDetalle] CHECK CONSTRAINT [FK_TRPDetalle_Articulo]
GO
ALTER TABLE [dbo].[TRPDetalle]  WITH CHECK ADD  CONSTRAINT [FK_TRPDetalle_Traspaso] FOREIGN KEY([TraspasoId])
REFERENCES [dbo].[Traspaso] ([TraspasoId])
GO
ALTER TABLE [dbo].[TRPDetalle] CHECK CONSTRAINT [FK_TRPDetalle_Traspaso]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Agente_Taller] FOREIGN KEY([TallerId])
REFERENCES [dbo].[Taller] ([TallerId])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Agente_Taller]
GO
ALTER TABLE [dbo].[Vin]  WITH CHECK ADD  CONSTRAINT [FK_Vin_Articulo] FOREIGN KEY([ArticuloId])
REFERENCES [dbo].[Articulo] ([ArticuloId])
GO
ALTER TABLE [dbo].[Vin] CHECK CONSTRAINT [FK_Vin_Articulo]
GO
ALTER TABLE [dbo].[Vin]  WITH CHECK ADD  CONSTRAINT [FK_Vin_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[Vin] CHECK CONSTRAINT [FK_Vin_Cliente]
GO
USE [master]
GO
ALTER DATABASE [DACZA] SET  READ_WRITE 
GO
