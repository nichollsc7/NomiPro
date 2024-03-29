USE [master]
GO
/****** Object:  Database [Nomipro]    Script Date: 2/09/2019 7:18:58 a. m. ******/
CREATE DATABASE [Nomipro]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Nomipro', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER01\MSSQL\DATA\Nomipro.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Nomipro_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER01\MSSQL\DATA\Nomipro_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Nomipro] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Nomipro].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Nomipro] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Nomipro] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Nomipro] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Nomipro] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Nomipro] SET ARITHABORT OFF 
GO
ALTER DATABASE [Nomipro] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Nomipro] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Nomipro] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Nomipro] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Nomipro] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Nomipro] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Nomipro] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Nomipro] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Nomipro] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Nomipro] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Nomipro] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Nomipro] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Nomipro] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Nomipro] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Nomipro] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Nomipro] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Nomipro] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Nomipro] SET RECOVERY FULL 
GO
ALTER DATABASE [Nomipro] SET  MULTI_USER 
GO
ALTER DATABASE [Nomipro] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Nomipro] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Nomipro] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Nomipro] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Nomipro] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Nomipro', N'ON'
GO
ALTER DATABASE [Nomipro] SET QUERY_STORE = OFF
GO
USE [Nomipro]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Nomipro]
GO
/****** Object:  Table [dbo].[Cargos]    Script Date: 2/09/2019 7:18:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargos](
	[ID_Cargo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](45) NULL,
	[Estado] [varchar](45) NULL,
	[Valor_Cargo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Cargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Control_Pago]    Script Date: 2/09/2019 7:18:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Control_Pago](
	[ID_Control_Pago] [int] IDENTITY(500,1) NOT NULL,
	[ID_EmpleCP] [int] NULL,
	[Valor_Horas_Extras] [int] NULL,
	[Valor_Parafiscal] [int] NULL,
	[Mes] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Control_Pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 2/09/2019 7:18:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[ID_Emple] [int] IDENTITY(100,1) NOT NULL,
	[Nombre] [varchar](45) NULL,
	[Apellido] [varchar](45) NULL,
	[Correo] [varchar](45) NULL,
	[Telefono] [int] NULL,
	[Tipo_Documento] [varchar](45) NULL,
	[Numero_Documento] [int] NULL,
	[ID_Cargo] [int] NULL,
	[ID_Vinculacion] [int] NULL,
	[ID_Horario] [int] NULL,
	[Estado] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Emple] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HExtraxEmpleado]    Script Date: 2/09/2019 7:18:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HExtraxEmpleado](
	[ID_HEXE] [int] IDENTITY(600,1) NOT NULL,
	[ID_Emple] [int] NULL,
	[ID_HExtras] [int] NULL,
	[Numero_Horas] [int] NULL,
	[Mes] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_HEXE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horario]    Script Date: 2/09/2019 7:18:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horario](
	[ID_Horario] [int] IDENTITY(200,1) NOT NULL,
	[Tipo_Horario] [varchar](45) NULL,
	[Hora_Trabajo] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Horario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horas_Extras]    Script Date: 2/09/2019 7:18:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horas_Extras](
	[ID_Hextras] [int] IDENTITY(700,1) NOT NULL,
	[Nombre] [varchar](45) NULL,
	[Valor] [int] NULL,
	[Estado] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Hextras] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nomina]    Script Date: 2/09/2019 7:18:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nomina](
	[ID_Nomina] [int] IDENTITY(800,1) NOT NULL,
	[ID_EmpleN] [int] NULL,
	[ID_CargoN] [int] NULL,
	[ID_Control_PagoN] [int] NULL,
	[Mes] [varchar](45) NULL,
	[Estado] [varchar](45) NULL,
	[Subtotal] [int] NULL,
	[Total] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Nomina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parafiscales]    Script Date: 2/09/2019 7:18:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parafiscales](
	[ID_Parafiscales] [int] IDENTITY(300,1) NOT NULL,
	[Nombre] [varchar](45) NULL,
	[Valor] [int] NULL,
	[Estado] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Parafiscales] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParaxEmple]    Script Date: 2/09/2019 7:18:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParaxEmple](
	[ID_PAEM] [int] IDENTITY(400,1) NOT NULL,
	[ID_Parafiscales] [int] NULL,
	[ID_EmpleP] [int] NULL,
	[Mes] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_PAEM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_vinculacion]    Script Date: 2/09/2019 7:18:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_vinculacion](
	[ID_vinculacion] [int] IDENTITY(900,1) NOT NULL,
	[Descripcion] [varchar](45) NULL,
	[Estado] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_vinculacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Control_Pago]  WITH CHECK ADD FOREIGN KEY([ID_EmpleCP])
REFERENCES [dbo].[Empleados] ([ID_Emple])
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD FOREIGN KEY([ID_Cargo])
REFERENCES [dbo].[Cargos] ([ID_Cargo])
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD FOREIGN KEY([ID_Horario])
REFERENCES [dbo].[Horario] ([ID_Horario])
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD FOREIGN KEY([ID_Vinculacion])
REFERENCES [dbo].[Tipo_vinculacion] ([ID_vinculacion])
GO
ALTER TABLE [dbo].[HExtraxEmpleado]  WITH CHECK ADD FOREIGN KEY([ID_Emple])
REFERENCES [dbo].[Empleados] ([ID_Emple])
GO
ALTER TABLE [dbo].[HExtraxEmpleado]  WITH CHECK ADD FOREIGN KEY([ID_HExtras])
REFERENCES [dbo].[Horas_Extras] ([ID_Hextras])
GO
ALTER TABLE [dbo].[Nomina]  WITH CHECK ADD FOREIGN KEY([ID_CargoN])
REFERENCES [dbo].[Cargos] ([ID_Cargo])
GO
ALTER TABLE [dbo].[Nomina]  WITH CHECK ADD FOREIGN KEY([ID_Control_PagoN])
REFERENCES [dbo].[Control_Pago] ([ID_Control_Pago])
GO
ALTER TABLE [dbo].[Nomina]  WITH CHECK ADD FOREIGN KEY([ID_EmpleN])
REFERENCES [dbo].[Empleados] ([ID_Emple])
GO
ALTER TABLE [dbo].[ParaxEmple]  WITH CHECK ADD FOREIGN KEY([ID_EmpleP])
REFERENCES [dbo].[Empleados] ([ID_Emple])
GO
ALTER TABLE [dbo].[ParaxEmple]  WITH CHECK ADD FOREIGN KEY([ID_Parafiscales])
REFERENCES [dbo].[Parafiscales] ([ID_Parafiscales])
GO
USE [master]
GO
ALTER DATABASE [Nomipro] SET  READ_WRITE 
GO
