# Prueba
Los 3 tipos de usuarios son los siguientes:
Administrador - correo : "correo@correo.com"  Contraseña : "123"
Ventas - correo : "q@q.com"  Contraseña : "123"
Personal Administrativo - correo : "w@w.com"  Contraseña : "123"

Script de la Base de datos :

USE [master]
GO
/****** Object:  Database [AVC]    Script Date: 24/09/2021 09:23:38 a. m. ******/
CREATE DATABASE [AVC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AVC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AVC.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AVC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AVC_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AVC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AVC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AVC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AVC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AVC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AVC] SET ARITHABORT OFF 
GO
ALTER DATABASE [AVC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AVC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AVC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AVC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AVC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AVC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AVC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AVC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AVC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AVC] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AVC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AVC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AVC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AVC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AVC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AVC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AVC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AVC] SET RECOVERY FULL 
GO
ALTER DATABASE [AVC] SET  MULTI_USER 
GO
ALTER DATABASE [AVC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AVC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AVC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AVC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AVC', N'ON'
GO
USE [AVC]
GO
/****** Object:  Table [dbo].[pantallas]    Script Date: 24/09/2021 09:23:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pantallas](
	[id_pantalla] [int] IDENTITY(1,1) NOT NULL,
	[pantalla_nombre] [varchar](50) NULL,
 CONSTRAINT [PK_pantallas] PRIMARY KEY CLUSTERED 
(
	[id_pantalla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pedidos]    Script Date: 24/09/2021 09:23:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pedidos](
	[id_pedido] [int] IDENTITY(1,1) NOT NULL,
	[pedido_costo] [varchar](50) NULL,
	[pedido_descripcion] [varchar](50) NULL,
	[pedido_id_relacion_productos_por_pedido] [int] NULL,
	[pedido_id_usuario] [int] NULL,
	[pedido_nombre_cliente] [varchar](50) NULL,
 CONSTRAINT [PK_pedidos] PRIMARY KEY CLUSTERED 
(
	[id_pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permisos]    Script Date: 24/09/2021 09:23:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permisos](
	[id_permiso] [int] IDENTITY(1,1) NOT NULL,
	[permiso_id_rol] [int] NULL,
	[permiso_id_pantalla] [int] NULL,
 CONSTRAINT [PK_permisos] PRIMARY KEY CLUSTERED 
(
	[id_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 24/09/2021 09:23:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[producto_nombre] [varchar](50) NULL,
	[producto_descripcion] [varchar](50) NULL,
	[producto_precio] [int] NULL,
	[producto_cantidad_existencia] [int] NULL,
	[producto_clave] [int] NULL,
 CONSTRAINT [PK_productos] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[relacion_productos_por_pedido]    Script Date: 24/09/2021 09:23:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[relacion_productos_por_pedido](
	[id_relacion_productos_por_pedido] [int] IDENTITY(1,1) NOT NULL,
	[relacion_productos_por_pedido_id_producto] [int] NULL,
	[relacion_productos_por_pedido_id_pedido] [int] NULL,
 CONSTRAINT [PK_relacion_productos_por_pedido] PRIMARY KEY CLUSTERED 
(
	[id_relacion_productos_por_pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 24/09/2021 09:23:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[id_rol] [int] IDENTITY(1,1) NOT NULL,
	[rol_nombre] [varchar](50) NULL,
 CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 24/09/2021 09:23:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario_nombre] [varchar](50) NULL,
	[usuario_password] [varchar](50) NULL,
	[usuario_correo] [varchar](50) NULL,
	[usuario_id_rol] [int] NULL,
	[usuario_apellido_paterno] [varchar](50) NULL,
	[usuario_apellido_materno] [varchar](50) NULL,
	[usuario_foto] [varchar](500) NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_1]    Script Date: 24/09/2021 09:23:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_1]
AS
SELECT        dbo.usuarios.usuario_nombre, dbo.roles.rol_nombre, dbo.permisos.permiso_id_rol, dbo.permisos.permiso_id_pantalla
FROM            dbo.usuarios INNER JOIN
                         dbo.roles ON dbo.usuarios.id_usuario = dbo.roles.id_rol INNER JOIN
                         dbo.permisos ON dbo.roles.id_rol = dbo.permisos.permiso_id_rol
GO
SET IDENTITY_INSERT [dbo].[pantallas] ON 
GO
INSERT [dbo].[pantallas] ([id_pantalla], [pantalla_nombre]) VALUES (1, N'1')
GO
INSERT [dbo].[pantallas] ([id_pantalla], [pantalla_nombre]) VALUES (2, N'2')
GO
INSERT [dbo].[pantallas] ([id_pantalla], [pantalla_nombre]) VALUES (3, N'3')
GO
INSERT [dbo].[pantallas] ([id_pantalla], [pantalla_nombre]) VALUES (4, N'4')
GO
INSERT [dbo].[pantallas] ([id_pantalla], [pantalla_nombre]) VALUES (5, N'5')
GO
INSERT [dbo].[pantallas] ([id_pantalla], [pantalla_nombre]) VALUES (6, N'6')
GO
INSERT [dbo].[pantallas] ([id_pantalla], [pantalla_nombre]) VALUES (7, N'7')
GO
INSERT [dbo].[pantallas] ([id_pantalla], [pantalla_nombre]) VALUES (8, N'8')
GO
INSERT [dbo].[pantallas] ([id_pantalla], [pantalla_nombre]) VALUES (9, N'9')
GO
INSERT [dbo].[pantallas] ([id_pantalla], [pantalla_nombre]) VALUES (10, N'10')
GO
INSERT [dbo].[pantallas] ([id_pantalla], [pantalla_nombre]) VALUES (11, N'11')
GO
INSERT [dbo].[pantallas] ([id_pantalla], [pantalla_nombre]) VALUES (12, N'12')
GO
INSERT [dbo].[pantallas] ([id_pantalla], [pantalla_nombre]) VALUES (13, N'13')
GO
INSERT [dbo].[pantallas] ([id_pantalla], [pantalla_nombre]) VALUES (14, N'14')
GO
INSERT [dbo].[pantallas] ([id_pantalla], [pantalla_nombre]) VALUES (15, N'15')
GO
SET IDENTITY_INSERT [dbo].[pantallas] OFF
GO
SET IDENTITY_INSERT [dbo].[permisos] ON 
GO
INSERT [dbo].[permisos] ([id_permiso], [permiso_id_rol], [permiso_id_pantalla]) VALUES (1, 1, 1)
GO
INSERT [dbo].[permisos] ([id_permiso], [permiso_id_rol], [permiso_id_pantalla]) VALUES (21, 2, 5)
GO
INSERT [dbo].[permisos] ([id_permiso], [permiso_id_rol], [permiso_id_pantalla]) VALUES (22, 2, 3)
GO
INSERT [dbo].[permisos] ([id_permiso], [permiso_id_rol], [permiso_id_pantalla]) VALUES (23, 2, 7)
GO
INSERT [dbo].[permisos] ([id_permiso], [permiso_id_rol], [permiso_id_pantalla]) VALUES (24, 3, 2)
GO
INSERT [dbo].[permisos] ([id_permiso], [permiso_id_rol], [permiso_id_pantalla]) VALUES (25, 3, 5)
GO
INSERT [dbo].[permisos] ([id_permiso], [permiso_id_rol], [permiso_id_pantalla]) VALUES (26, 3, 7)
GO
SET IDENTITY_INSERT [dbo].[permisos] OFF
GO
SET IDENTITY_INSERT [dbo].[productos] ON 
GO
INSERT [dbo].[productos] ([id_producto], [producto_nombre], [producto_descripcion], [producto_precio], [producto_cantidad_existencia], [producto_clave]) VALUES (1, N'Papel', N'500 hojas', 100, 12, NULL)
GO
INSERT [dbo].[productos] ([id_producto], [producto_nombre], [producto_descripcion], [producto_precio], [producto_cantidad_existencia], [producto_clave]) VALUES (2, N'Lapiz', N'N12', 5, 13, NULL)
GO
SET IDENTITY_INSERT [dbo].[productos] OFF
GO
SET IDENTITY_INSERT [dbo].[roles] ON 
GO
INSERT [dbo].[roles] ([id_rol], [rol_nombre]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[roles] ([id_rol], [rol_nombre]) VALUES (2, N'Vendedores')
GO
INSERT [dbo].[roles] ([id_rol], [rol_nombre]) VALUES (3, N'Personal Administrativo')
GO
SET IDENTITY_INSERT [dbo].[roles] OFF
GO
SET IDENTITY_INSERT [dbo].[usuarios] ON 
GO
INSERT [dbo].[usuarios] ([id_usuario], [usuario_nombre], [usuario_password], [usuario_correo], [usuario_id_rol], [usuario_apellido_paterno], [usuario_apellido_materno], [usuario_foto]) VALUES (1, N'admin', N'123', N'correo@correo.com', 1, NULL, NULL, NULL)
GO
INSERT [dbo].[usuarios] ([id_usuario], [usuario_nombre], [usuario_password], [usuario_correo], [usuario_id_rol], [usuario_apellido_paterno], [usuario_apellido_materno], [usuario_foto]) VALUES (2, N'Roberto', N'123', N'q@q.com', 2, NULL, NULL, NULL)
GO
INSERT [dbo].[usuarios] ([id_usuario], [usuario_nombre], [usuario_password], [usuario_correo], [usuario_id_rol], [usuario_apellido_paterno], [usuario_apellido_materno], [usuario_foto]) VALUES (3, N'Carlos', N'123', N'w@w.com', 3, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[usuarios] OFF
GO
ALTER TABLE [dbo].[pedidos]  WITH CHECK ADD  CONSTRAINT [FK_pedidos_usuarios] FOREIGN KEY([pedido_id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[pedidos] CHECK CONSTRAINT [FK_pedidos_usuarios]
GO
ALTER TABLE [dbo].[permisos]  WITH CHECK ADD  CONSTRAINT [FK_permisos_pantallas] FOREIGN KEY([permiso_id_pantalla])
REFERENCES [dbo].[pantallas] ([id_pantalla])
GO
ALTER TABLE [dbo].[permisos] CHECK CONSTRAINT [FK_permisos_pantallas]
GO
ALTER TABLE [dbo].[permisos]  WITH CHECK ADD  CONSTRAINT [FK_permisos_roles] FOREIGN KEY([permiso_id_rol])
REFERENCES [dbo].[roles] ([id_rol])
GO
ALTER TABLE [dbo].[permisos] CHECK CONSTRAINT [FK_permisos_roles]
GO
ALTER TABLE [dbo].[relacion_productos_por_pedido]  WITH CHECK ADD  CONSTRAINT [FK_relacion_productos_por_pedido_pedidos] FOREIGN KEY([id_relacion_productos_por_pedido])
REFERENCES [dbo].[pedidos] ([id_pedido])
GO
ALTER TABLE [dbo].[relacion_productos_por_pedido] CHECK CONSTRAINT [FK_relacion_productos_por_pedido_pedidos]
GO
ALTER TABLE [dbo].[relacion_productos_por_pedido]  WITH CHECK ADD  CONSTRAINT [FK_relacion_productos_por_pedido_productos] FOREIGN KEY([id_relacion_productos_por_pedido])
REFERENCES [dbo].[productos] ([id_producto])
GO
ALTER TABLE [dbo].[relacion_productos_por_pedido] CHECK CONSTRAINT [FK_relacion_productos_por_pedido_productos]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_roles] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[roles] ([id_rol])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_roles]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "usuarios"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 263
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "roles"
            Begin Extent = 
               Top = 6
               Left = 301
               Bottom = 102
               Right = 471
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "permisos"
            Begin Extent = 
               Top = 6
               Left = 509
               Bottom = 119
               Right = 703
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
USE [master]
GO
ALTER DATABASE [AVC] SET  READ_WRITE 
GO
