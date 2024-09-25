USE [master]
GO
/****** Object:  Database [GestionActividadFisica]    Script Date: 14/09/2024 10:09:51 a. m. ******/
CREATE DATABASE [GestionActividadFisica]
GO
USE [GestionActividadFisica]
GO
/****** Object:  Table [dbo].[Ciudades]    Script Date: 14/09/2024 10:09:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudades](
	[Id] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Ciudades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CondicionesEmocionales]    Script Date: 14/09/2024 10:09:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CondicionesEmocionales](
	[Id] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CondicionesEmocionales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evaluaciones]    Script Date: 14/09/2024 10:09:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluaciones](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[AntecendenteDiabetes] [bit] NOT NULL,
	[AntecendenteCancer] [bit] NOT NULL,
	[IdCiudad] [int] NOT NULL,
	[Peso] [decimal](18, 2) NOT NULL,
	[Talla] [decimal](18, 2) NOT NULL,
	[IdCondicionEmocional] [int] NOT NULL,
 CONSTRAINT [PK_Evaluaciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 14/09/2024 10:09:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PrimerNombre] [varchar](50) NOT NULL,
	[SegundoNombre] [varchar](50) NULL,
	[PrimerApellido] [varchar](50) NOT NULL,
	[SegundoApellido] [varchar](50) NULL,
	[IdTipoDocumento] [int] NOT NULL,
	[NumeroDocumento] [nvarchar](50) NOT NULL,
	[IdSexo] [int] NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sexos]    Script Date: 14/09/2024 10:09:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sexos](
	[Id] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sexos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDocumento]    Script Date: 14/09/2024 10:09:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDocumento](
	[Id] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TiposDocumento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 14/09/2024 10:09:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](50) NOT NULL,
	[Clave] [nvarchar](50) NOT NULL,
	[IdPersona] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Ciudades] ([Id], [Nombre]) VALUES (1, N'Bello')
INSERT [dbo].[Ciudades] ([Id], [Nombre]) VALUES (2, N'Sabaneta')
INSERT [dbo].[Ciudades] ([Id], [Nombre]) VALUES (3, N'Medellín')
GO
INSERT [dbo].[CondicionesEmocionales] ([Id], [Nombre]) VALUES (1, N'Alegre')
INSERT [dbo].[CondicionesEmocionales] ([Id], [Nombre]) VALUES (2, N'Normal')
INSERT [dbo].[CondicionesEmocionales] ([Id], [Nombre]) VALUES (3, N'Triste')
GO
SET IDENTITY_INSERT [dbo].[Evaluaciones] ON 

INSERT [dbo].[Evaluaciones] ([Id], [IdPersona], [Fecha], [AntecendenteDiabetes], [AntecendenteCancer], [IdCiudad], [Peso], [Talla], [IdCondicionEmocional]) VALUES (1, 3, CAST(N'2024-09-14T10:05:42.087' AS DateTime), 1, 1, 1, CAST(100.00 AS Decimal(18, 2)), CAST(189.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Evaluaciones] ([Id], [IdPersona], [Fecha], [AntecendenteDiabetes], [AntecendenteCancer], [IdCiudad], [Peso], [Talla], [IdCondicionEmocional]) VALUES (2, 3, CAST(N'2024-09-14T10:05:42.087' AS DateTime), 1, 1, 1, CAST(100.00 AS Decimal(18, 2)), CAST(189.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Evaluaciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Personas] ON 

INSERT [dbo].[Personas] ([Id], [PrimerNombre], [SegundoNombre], [PrimerApellido], [SegundoApellido], [IdTipoDocumento], [NumeroDocumento], [IdSexo], [FechaNacimiento]) VALUES (1, N'William', N'Alexis', N'Ortiz', N'Perea', 1, N'71984822', 1, CAST(N'1983-04-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Personas] ([Id], [PrimerNombre], [SegundoNombre], [PrimerApellido], [SegundoApellido], [IdTipoDocumento], [NumeroDocumento], [IdSexo], [FechaNacimiento]) VALUES (2, N'Ana', N'Maria', N'Trujillo', N'Zapata', 1, N'1087677456', 1, CAST(N'1998-09-14T10:02:34.220' AS DateTime))
INSERT [dbo].[Personas] ([Id], [PrimerNombre], [SegundoNombre], [PrimerApellido], [SegundoApellido], [IdTipoDocumento], [NumeroDocumento], [IdSexo], [FechaNacimiento]) VALUES (3, N'Javier', N'Antonio', N'Zapata', N'Milan', 1, N'71985545', 2, CAST(N'1997-09-14T10:05:42.097' AS DateTime))
SET IDENTITY_INSERT [dbo].[Personas] OFF
GO
INSERT [dbo].[Sexos] ([Id], [Nombre]) VALUES (1, N'Femenino')
INSERT [dbo].[Sexos] ([Id], [Nombre]) VALUES (2, N'Masculino')
GO
INSERT [dbo].[TiposDocumento] ([Id], [Nombre]) VALUES (1, N'Cédula de Ciudadanía')
INSERT [dbo].[TiposDocumento] ([Id], [Nombre]) VALUES (2, N'Tarjeta de Identidad')
INSERT [dbo].[TiposDocumento] ([Id], [Nombre]) VALUES (3, N'Cédula de Extranjería')
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [NombreUsuario], [Clave], [IdPersona]) VALUES (1, N'wortiz', N'123', 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Personas]    Script Date: 14/09/2024 10:09:51 a. m. ******/
ALTER TABLE [dbo].[Personas] ADD  CONSTRAINT [IX_Personas] UNIQUE NONCLUSTERED 
(
	[IdTipoDocumento] ASC,
	[NumeroDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Usuarios]    Script Date: 14/09/2024 10:09:51 a. m. ******/
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [IX_Usuarios] UNIQUE NONCLUSTERED 
(
	[NombreUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Personas] ADD  CONSTRAINT [DF_Pacientes_NumeroDocumento]  DEFAULT ('0000000000') FOR [NumeroDocumento]
GO
ALTER TABLE [dbo].[Evaluaciones]  WITH CHECK ADD  CONSTRAINT [FK_Evaluaciones_Ciudades] FOREIGN KEY([IdCiudad])
REFERENCES [dbo].[Ciudades] ([Id])
GO
ALTER TABLE [dbo].[Evaluaciones] CHECK CONSTRAINT [FK_Evaluaciones_Ciudades]
GO
ALTER TABLE [dbo].[Evaluaciones]  WITH CHECK ADD  CONSTRAINT [FK_Evaluaciones_CondicionesEmocionales] FOREIGN KEY([IdCiudad])
REFERENCES [dbo].[CondicionesEmocionales] ([Id])
GO
ALTER TABLE [dbo].[Evaluaciones] CHECK CONSTRAINT [FK_Evaluaciones_CondicionesEmocionales]
GO
ALTER TABLE [dbo].[Evaluaciones]  WITH CHECK ADD  CONSTRAINT [FK_Evaluaciones_Personas] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Personas] ([Id])
GO
ALTER TABLE [dbo].[Evaluaciones] CHECK CONSTRAINT [FK_Evaluaciones_Personas]
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_Sexos] FOREIGN KEY([IdSexo])
REFERENCES [dbo].[Sexos] ([Id])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_Sexos]
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_TiposDocumento] FOREIGN KEY([IdTipoDocumento])
REFERENCES [dbo].[TiposDocumento] ([Id])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_TiposDocumento]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Personas] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Personas] ([Id])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Personas]
GO
USE [master]
GO
ALTER DATABASE [GestionActividadFisica] SET  READ_WRITE 
GO
