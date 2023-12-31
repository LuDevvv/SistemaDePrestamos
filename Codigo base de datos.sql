CREATE DATABASE finalProject
GO
USE [finalProject]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 07/12/2022 16:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 07/12/2022 16:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[cedula] [char](11) NOT NULL,
	[nombre] [varchar](25) NOT NULL,
	[apellido] [varchar](40) NOT NULL,
	[direccion] [varchar](100) NOT NULL,
	[telefono] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuenta]    Script Date: 07/12/2022 16:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuenta](
	[idCuenta] [int] IDENTITY(1,1) NOT NULL,
	[banco] [varchar](40) NOT NULL,
	[tipo] [int] NOT NULL,
	[idCliente] [char](11) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuota_inversion]    Script Date: 07/12/2022 16:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuota_inversion](
	[cod_cuota] [int] IDENTITY(1,1) NOT NULL,
	[fecha_planificada] [date] NOT NULL,
	[monto] [int] NOT NULL,
	[fecha_realizada] [date] NULL,
	[cod_comprobante] [varchar](20) NULL,
	[idInversion] [int] NOT NULL,
	[tipoTransaccion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_cuota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuota_prestamo]    Script Date: 07/12/2022 16:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuota_prestamo](
	[cod_cuota] [int] IDENTITY(1,1) NOT NULL,
	[fecha_planificada] [date] NOT NULL,
	[monto] [int] NOT NULL,
	[fecha_realizada] [date] NULL,
	[cod_comprobante] [varchar](20) NULL,
	[idPrestamo] [int] NOT NULL,
	[tipoTransaccion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_cuota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inversion_garantia]    Script Date: 07/12/2022 16:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[inversion_garantia](
	[idGarantia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[tipo] [varchar](20) NOT NULL,
	[valor] [decimal](11, 0) NOT NULL,
	[ubicacion] [varchar](100) NOT NULL,
	[idInversion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idGarantia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inversiones]    Script Date: 07/12/2022 16:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[inversiones](
	[idInversion] [int] IDENTITY(1,1) NOT NULL,
	[monto] [decimal](18, 0) NOT NULL,
	[fecha_inicio] [date] NOT NULL,
	[fecha_final] [date] NOT NULL,
	[interes] [decimal](18, 0) NOT NULL,
	[idCuenta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idInversion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prestamo_garantia]    Script Date: 07/12/2022 16:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prestamo_garantia](
	[idGarantia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[tipo] [varchar](20) NOT NULL,
	[valor] [decimal](11, 0) NOT NULL,
	[ubicacion] [varchar](100) NOT NULL,
	[idPrestamo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idGarantia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prestamos]    Script Date: 07/12/2022 16:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prestamos](
	[idprestamo] [int] IDENTITY(1,1) NOT NULL,
	[monto] [decimal](18, 0) NOT NULL,
	[fecha_aprobacion] [date] NOT NULL,
	[fecha_inicio] [date] NOT NULL,
	[fecha_final] [date] NOT NULL,
	[interes] [decimal](18, 0) NOT NULL,
	[idCliente] [char](11) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idprestamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoCuenta]    Script Date: 07/12/2022 16:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoCuenta](
	[idTipo] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoPago]    Script Date: 07/12/2022 16:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoPago](
	[idTipo] [int] IDENTITY(1,1) NOT NULL,
	[tipoPago] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cuenta]  WITH CHECK ADD FOREIGN KEY([idCliente])
REFERENCES [dbo].[cliente] ([cedula])
GO
ALTER TABLE [dbo].[cuenta]  WITH CHECK ADD FOREIGN KEY([tipo])
REFERENCES [dbo].[tipoCuenta] ([idTipo])
GO
ALTER TABLE [dbo].[cuota_inversion]  WITH CHECK ADD FOREIGN KEY([idInversion])
REFERENCES [dbo].[inversiones] ([idInversion])
GO
ALTER TABLE [dbo].[cuota_inversion]  WITH CHECK ADD FOREIGN KEY([tipoTransaccion])
REFERENCES [dbo].[tipoPago] ([idTipo])
GO
ALTER TABLE [dbo].[cuota_prestamo]  WITH CHECK ADD FOREIGN KEY([idPrestamo])
REFERENCES [dbo].[prestamos] ([idprestamo])
GO
ALTER TABLE [dbo].[cuota_prestamo]  WITH CHECK ADD FOREIGN KEY([tipoTransaccion])
REFERENCES [dbo].[tipoPago] ([idTipo])
GO
ALTER TABLE [dbo].[inversion_garantia]  WITH CHECK ADD FOREIGN KEY([idInversion])
REFERENCES [dbo].[inversiones] ([idInversion])
GO
ALTER TABLE [dbo].[inversiones]  WITH CHECK ADD FOREIGN KEY([idCuenta])
REFERENCES [dbo].[cuenta] ([idCuenta])
GO
ALTER TABLE [dbo].[prestamo_garantia]  WITH CHECK ADD FOREIGN KEY([idPrestamo])
REFERENCES [dbo].[prestamos] ([idprestamo])
GO
ALTER TABLE [dbo].[prestamos]  WITH CHECK ADD FOREIGN KEY([idCliente])
REFERENCES [dbo].[cliente] ([cedula])
GO
ALTER TABLE [dbo].[cuenta]  WITH CHECK ADD CHECK  (([tipo]=(0) OR [tipo]=(1)))
GO
ALTER TABLE [dbo].[inversiones]  WITH CHECK ADD CHECK  (([interes]>=(0)))
GO
ALTER TABLE [dbo].[prestamos]  WITH CHECK ADD CHECK  (([interes]>=(0)))
GO
