USE [master]
GO
/****** Object:  Database [gestioncafeteria]    Script Date: 16/06/2024 5:38:34 p. m. ******/
CREATE DATABASE [gestioncafeteria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'gestioncafeteria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\gestioncafeteria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'gestioncafeteria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\gestioncafeteria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [gestioncafeteria] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [gestioncafeteria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [gestioncafeteria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [gestioncafeteria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [gestioncafeteria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [gestioncafeteria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [gestioncafeteria] SET ARITHABORT OFF 
GO
ALTER DATABASE [gestioncafeteria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [gestioncafeteria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [gestioncafeteria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [gestioncafeteria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [gestioncafeteria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [gestioncafeteria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [gestioncafeteria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [gestioncafeteria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [gestioncafeteria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [gestioncafeteria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [gestioncafeteria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [gestioncafeteria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [gestioncafeteria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [gestioncafeteria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [gestioncafeteria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [gestioncafeteria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [gestioncafeteria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [gestioncafeteria] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [gestioncafeteria] SET  MULTI_USER 
GO
ALTER DATABASE [gestioncafeteria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [gestioncafeteria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [gestioncafeteria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [gestioncafeteria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [gestioncafeteria] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [gestioncafeteria] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [gestioncafeteria] SET QUERY_STORE = ON
GO
ALTER DATABASE [gestioncafeteria] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [gestioncafeteria]
GO
/****** Object:  Table [dbo].[tCategorias]    Script Date: 16/06/2024 5:38:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tCategorias](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
 CONSTRAINT [PK_tCategorias] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tEstadoProductos]    Script Date: 16/06/2024 5:38:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tEstadoProductos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[estado] [varchar](100) NULL,
 CONSTRAINT [PK_tEstadoProductos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tGeneros]    Script Date: 16/06/2024 5:38:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tGeneros](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[genero] [varchar](100) NULL,
 CONSTRAINT [PK_tGeneros] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tProductos]    Script Date: 16/06/2024 5:38:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tProductos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[referencia] [varchar](100) NULL,
	[nombre] [varchar](100) NULL,
	[precio] [int] NULL,
	[cantidad] [int] NULL,
	[descripcion] [varchar](500) NULL,
	[id_Estado] [int] NULL,
	[id_Categoria] [int] NULL,
	[fechaVencimiento] [date] NULL,
 CONSTRAINT [PK_tProductos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tProductosxVentas]    Script Date: 16/06/2024 5:38:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tProductosxVentas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Venta] [int] NULL,
	[id_Productos] [int] NULL,
	[cantidad] [int] NULL,
	[precioxcantidad] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tProductosxVentas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tProductoxProveedores]    Script Date: 16/06/2024 5:38:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tProductoxProveedores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Producto] [int] NULL,
	[id_Proveedor] [int] NULL,
 CONSTRAINT [PK_tProductoxProveedores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tProveedores]    Script Date: 16/06/2024 5:38:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tProveedores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nit] [int] NULL,
	[nombre] [varchar](100) NULL,
	[direccion] [varchar](100) NULL,
	[contacto] [varchar](100) NULL,
 CONSTRAINT [PK_tProveedores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tRoles]    Script Date: 16/06/2024 5:38:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tRoles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
 CONSTRAINT [PK_tRoles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tTiposDoc]    Script Date: 16/06/2024 5:38:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tTiposDoc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
 CONSTRAINT [PK_tTiposDoc] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tTrabajadores]    Script Date: 16/06/2024 5:38:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tTrabajadores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[apellido] [varchar](100) NULL,
	[id_TipoDoc] [int] NULL,
	[numDocumento] [int] NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [int] NULL,
	[id_Genero] [int] NULL,
	[estado] [int] NULL,
	[usuario] [varchar](100) NULL,
	[contrasenia] [varchar](100) NULL,
	[id_Rol] [int] NULL,
 CONSTRAINT [PK_tTrabajadores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tVentas]    Script Date: 16/06/2024 5:38:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tVentas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NULL,
	[totalPagado] [decimal](18, 0) NULL,
	[id_Trabajador] [int] NULL,
 CONSTRAINT [PK_tVentas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tProductos]  WITH CHECK ADD  CONSTRAINT [FK_tProductos_tCategorias] FOREIGN KEY([id_Categoria])
REFERENCES [dbo].[tCategorias] ([id])
GO
ALTER TABLE [dbo].[tProductos] CHECK CONSTRAINT [FK_tProductos_tCategorias]
GO
ALTER TABLE [dbo].[tProductos]  WITH CHECK ADD  CONSTRAINT [FK_tProductos_tEstadoProductos] FOREIGN KEY([id_Estado])
REFERENCES [dbo].[tEstadoProductos] ([id])
GO
ALTER TABLE [dbo].[tProductos] CHECK CONSTRAINT [FK_tProductos_tEstadoProductos]
GO
ALTER TABLE [dbo].[tProductosxVentas]  WITH CHECK ADD  CONSTRAINT [FK_tProductosxVentas_tProductos] FOREIGN KEY([id_Productos])
REFERENCES [dbo].[tProductos] ([id])
GO
ALTER TABLE [dbo].[tProductosxVentas] CHECK CONSTRAINT [FK_tProductosxVentas_tProductos]
GO
ALTER TABLE [dbo].[tProductosxVentas]  WITH CHECK ADD  CONSTRAINT [FK_tProductosxVentas_tVentas] FOREIGN KEY([id_Venta])
REFERENCES [dbo].[tVentas] ([id])
GO
ALTER TABLE [dbo].[tProductosxVentas] CHECK CONSTRAINT [FK_tProductosxVentas_tVentas]
GO
ALTER TABLE [dbo].[tProductoxProveedores]  WITH CHECK ADD  CONSTRAINT [FK_tProductoxProveedores_tProductos] FOREIGN KEY([id_Producto])
REFERENCES [dbo].[tProductos] ([id])
GO
ALTER TABLE [dbo].[tProductoxProveedores] CHECK CONSTRAINT [FK_tProductoxProveedores_tProductos]
GO
ALTER TABLE [dbo].[tProductoxProveedores]  WITH CHECK ADD  CONSTRAINT [FK_tProductoxProveedores_tProveedores] FOREIGN KEY([id_Proveedor])
REFERENCES [dbo].[tProveedores] ([id])
GO
ALTER TABLE [dbo].[tProductoxProveedores] CHECK CONSTRAINT [FK_tProductoxProveedores_tProveedores]
GO
ALTER TABLE [dbo].[tTrabajadores]  WITH CHECK ADD  CONSTRAINT [FK_tTrabajadores_tGeneros] FOREIGN KEY([id_Genero])
REFERENCES [dbo].[tGeneros] ([id])
GO
ALTER TABLE [dbo].[tTrabajadores] CHECK CONSTRAINT [FK_tTrabajadores_tGeneros]
GO
ALTER TABLE [dbo].[tTrabajadores]  WITH CHECK ADD  CONSTRAINT [FK_tTrabajadores_tRoles] FOREIGN KEY([id_Rol])
REFERENCES [dbo].[tRoles] ([id])
GO
ALTER TABLE [dbo].[tTrabajadores] CHECK CONSTRAINT [FK_tTrabajadores_tRoles]
GO
ALTER TABLE [dbo].[tTrabajadores]  WITH CHECK ADD  CONSTRAINT [FK_tTrabajadores_tTiposDoc] FOREIGN KEY([id_TipoDoc])
REFERENCES [dbo].[tTiposDoc] ([id])
GO
ALTER TABLE [dbo].[tTrabajadores] CHECK CONSTRAINT [FK_tTrabajadores_tTiposDoc]
GO
ALTER TABLE [dbo].[tVentas]  WITH CHECK ADD  CONSTRAINT [FK_tVentas_tTrabajadores] FOREIGN KEY([id_Trabajador])
REFERENCES [dbo].[tTrabajadores] ([id])
GO
ALTER TABLE [dbo].[tVentas] CHECK CONSTRAINT [FK_tVentas_tTrabajadores]
GO
USE [master]
GO
ALTER DATABASE [gestioncafeteria] SET  READ_WRITE 
GO
