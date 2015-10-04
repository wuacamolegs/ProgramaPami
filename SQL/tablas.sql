USE [PAMI]
GO
/****** Object:  Schema [PAMI]    Script Date: 09/27/2015 17:51:43 ******/
CREATE SCHEMA [PAMI] AUTHORIZATION [dbo]
GO
/****** Object:  Table [PAMI].[REL_ProfesionalesXPrestador]    Script Date: 09/27/2015 17:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[REL_ProfesionalesXPrestador](
	[vacio] [varchar](1) NULL,
	[cuit_prestador] [varchar](53) NULL,
	[matricula_profesional] [varchar](6) NULL,
	[c_prestador_default] [varchar](10) NULL,
	[c_profesional_default] [varchar](53) NULL,
	[fecha_inicio_relacion] [varchar](10) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[REL_ProfesionalAsociacion]    Script Date: 09/27/2015 17:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[REL_ProfesionalAsociacion](
	[profesional_matricula] [varchar](6) NOT NULL,
	[asociacion_id] [numeric](10, 0) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[REL_PracticasRealizadasXAmbulatorio]    Script Date: 09/27/2015 17:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[REL_PracticasRealizadasXAmbulatorio](
	[vacio1] [varchar](1) NULL,
	[vacio2] [varchar](1) NULL,
	[vacio3] [varchar](1) NULL,
	[c_ambulatorio_default] [varchar](10) NOT NULL,
	[cod_prestacion] [varchar](2) NOT NULL,
	[practica_codigo] [varchar](10) NOT NULL,
	[practica_fecha] [varchar](10) NOT NULL,
	[practica_cantidad] [varchar](3) NOT NULL,
	[modalidad_prestacion] [varchar](2) NOT NULL,
	[numero_orden] [varchar](10) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[REL_ModulosXPrestador]    Script Date: 09/27/2015 17:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[REL_ModulosXPrestador](
	[vacio] [varchar](1) NULL,
	[cuit_prestador] [varchar](9) NOT NULL,
	[vacio1] [varchar](1) NULL,
	[c_prestador_default] [varchar](10) NOT NULL,
	[modulonomenclador] [varchar](2) NOT NULL,
	[fechaInicio] [varchar](10) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[REL_DiagnosticosXAmbulatorio]    Script Date: 09/27/2015 17:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[REL_DiagnosticosXAmbulatorio](
	[vacio1] [varchar](1) NULL,
	[vacio2] [varchar](1) NULL,
	[vacio3] [varchar](1) NULL,
	[c_ambulatorio_default] [varchar](10) NOT NULL,
	[diagnostico_clasificacion_tipo] [varchar](2) NOT NULL,
	[diagnostico_codigo] [varchar](10) NOT NULL,
	[diagnostico_tipo] [varchar](1) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[Profesional]    Script Date: 09/27/2015 17:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[Profesional](
	[vacio1] [varchar](1) NULL,
	[vacio2] [varchar](1) NULL,
	[vacio3] [varchar](1) NULL,
	[profesional_codigo] [varchar](8) NOT NULL,
	[profesional_nombreCompleto] [varchar](60) NOT NULL,
	[profesional_especialidad_id] [varchar](4) NOT NULL,
	[profesional_matricula_nacional] [varchar](6) NOT NULL,
	[profesional_matricula_provincial] [varchar](6) NULL,
	[profesional_tipo_documento_id] [varchar](3) NOT NULL,
	[profesional_numero_documento] [varchar](15) NOT NULL,
	[profesional_cuil] [varchar](15) NULL,
	[profesional_direccion_calle] [varchar](30) NOT NULL,
	[profesional_direccion_numero] [varchar](5) NOT NULL,
	[profesional_direccion_piso] [varchar](2) NULL,
	[profesional_direccion_depto] [varchar](5) NULL,
	[profesional_codigo_postal] [varchar](9) NULL,
	[profesional_telefono] [varchar](20) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[Prestador]    Script Date: 09/27/2015 17:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[Prestador](
	[vacio1] [varchar](1) NULL,
	[prestador_cuit] [varchar](15) NOT NULL,
	[profesional_matricula] [varchar](6) NULL,
	[vacio2] [varchar](1) NULL,
	[c_prestador_default] [varchar](10) NOT NULL,
	[n_nro_prestador] [varchar](16) NULL,
	[nro_sap] [varchar](5) NULL,
	[tipo_prestador] [varchar](1) NOT NULL,
	[c_iva] [varchar](2) NULL,
	[m_medico_cabecera] [varchar](1) NOT NULL,
	[d_mail] [varchar](50) NOT NULL,
	[f_fecha_alta] [varchar](10) NOT NULL,
	[f_fecha_baja] [varchar](10) NULL,
	[d_motivo_baja] [varchar](60) NULL,
	[f_actualizac] [varchar](10) NULL,
	[c_cuit_default] [varchar](8) NOT NULL,
	[C_Profesional_default] [varchar](8) NOT NULL,
	[Id_Red_default] [varchar](10) NOT NULL,
	[D_denominacion] [varchar](30) NOT NULL,
	[d_calle] [varchar](30) NOT NULL,
	[d_puerta] [varchar](1) NOT NULL,
	[d_piso] [varchar](2) NULL,
	[d_departamento] [varchar](5) NULL,
	[npostal] [varchar](9) NULL,
	[d_telefono] [varchar](20) NULL,
	[c_instalacion] [varchar](20) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[padron]    Script Date: 09/27/2015 17:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[padron](
	[padron] [varchar](8000) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[Nomenclador]    Script Date: 09/27/2015 17:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PAMI].[Nomenclador](
	[practica_codigo] [nvarchar](255) NULL,
	[practica_descripcion] [nvarchar](255) NULL,
	[codigo_modulo] [float] NULL,
	[descripcion_modulo] [nvarchar](255) NULL,
	[vigencia_inicio] [datetime] NULL,
	[totales] [float] NULL,
	[honorarios] [nvarchar](255) NULL,
	[gastos] [nvarchar](255) NULL,
	[cantidad_maxima] [numeric](18, 0) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [PAMI].[Diagnosticos]    Script Date: 09/27/2015 17:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[Diagnosticos](
	[CODIGO] [varchar](50) NULL,
	[DIAGNOSTICO] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[Diagnostico]    Script Date: 09/27/2015 17:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[Diagnostico](
	[diagnostico_clasificacion_tipo] [varchar](2) NULL,
	[diagnostico_codigo] [varchar](10) NOT NULL,
	[diagnostico_tipo] [varchar](1) NULL,
	[diagnostico_descripcion] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[Cabecera]    Script Date: 09/27/2015 17:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[Cabecera](
	[cuit_prestador] [varchar](8) NULL,
	[numero_emulacion] [varchar](5) NOT NULL,
	[fecha_emulacion] [varchar](10) NOT NULL,
	[mes_anio_prestacion] [varchar](5) NULL,
	[prestador_nombre] [varchar](30) NULL,
	[prestador_tipo] [varchar](2) NULL,
	[usuario_nombre] [varchar](16) NULL,
	[nro_instalacion_efectores] [varchar](20) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[BocaAtencion]    Script Date: 09/27/2015 17:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[BocaAtencion](
	[vacio] [varchar](1) NULL,
	[cuit_prestador] [varchar](8) NOT NULL,
	[vacio1] [varchar](1) NULL,
	[c_prestador_default] [varchar](10) NOT NULL,
	[c_boca_atencion] [varchar](5) NOT NULL,
	[sucursal] [varchar](2) NOT NULL,
	[direccion_calle] [varchar](30) NOT NULL,
	[direccion_numero] [varchar](5) NOT NULL,
	[direccion_piso] [varchar](2) NULL,
	[direccion_depto] [varchar](5) NULL,
	[npostal] [varchar](9) NULL,
	[telefono] [varchar](20) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[Beneficio]    Script Date: 09/27/2015 17:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[Beneficio](
	[vacio1] [varchar](1) NULL,
	[vacio2] [varchar](1) NULL,
	[vacio3] [varchar](1) NULL,
	[beneficio] [varchar](12) NOT NULL,
	[tipo_beneficio] [varchar](2) NULL,
	[denom_beneficio] [varchar](30) NULL,
	[default_alta_por_prestador] [varchar](1) NOT NULL,
	[fecha_alta] [varchar](10) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[Asociacion]    Script Date: 09/27/2015 17:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[Asociacion](
	[asociacion_id] [numeric](10, 0) NOT NULL,
	[asociacion_nombre] [varchar](50) NOT NULL,
	[asociacion_nombreCorto] [varchar](30) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[Ambulatorio]    Script Date: 09/27/2015 17:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[Ambulatorio](
	[Cuit_Red] [varchar](1) NULL,
	[vacio1] [varchar](1) NULL,
	[matricula_nacional] [varchar](6) NOT NULL,
	[c_ambulatorio_default] [varchar](10) NOT NULL,
	[ID_RED_default] [varchar](9) NULL,
	[C_prestador_default] [varchar](10) NOT NULL,
	[c_boca_atencion] [varchar](5) NOT NULL,
	[c_profesional] [varchar](8) NOT NULL,
	[f_fecha_atencion] [varchar](10) NOT NULL,
	[d_estado] [varchar](12) NULL,
	[d_motivo_rechazo] [varchar](60) NULL,
	[id_modalidad_presta] [varchar](2) NOT NULL,
	[n_nro_orden] [varchar](10) NULL,
	[id_tipo_atencion] [varchar](2) NULL,
	[id_beneficio] [varchar](12) NOT NULL,
	[id_parentesco] [varchar](2) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[AfiliadosPami]    Script Date: 09/27/2015 17:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[AfiliadosPami](
	[apellido_nombre] [varchar](60) NOT NULL,
	[documento_tipo] [varchar](3) NOT NULL,
	[documento_numero] [varchar](15) NOT NULL,
	[estado_civil] [varchar](2) NULL,
	[nacionalidad] [varchar](3) NULL,
	[pais] [varchar](3) NULL,
	[direccion_calle] [varchar](30) NULL,
	[direccion_puerta] [varchar](5) NULL,
	[direccion_piso] [varchar](2) NULL,
	[direccion_departamento] [varchar](5) NULL,
	[direccion_numero_postal] [varchar](9) NULL,
	[direccion_telefono] [varchar](20) NULL,
	[fecha_nacimiento] [varchar](10) NOT NULL,
	[sexo] [varchar](1) NOT NULL,
	[cuit] [varchar](15) NULL,
	[cuil] [varchar](15) NULL,
	[beneficio] [varchar](12) NOT NULL,
	[parentesco] [varchar](2) NOT NULL,
	[sucursal] [varchar](2) NULL,
	[agencia] [varchar](2) NULL,
	[corresponsalia] [varchar](2) NULL,
	[afjp] [varchar](2) NULL,
	[afiliacion_vto] [varchar](10) NULL,
	[formulario_tipo] [varchar](11) NULL,
	[fecha_baja] [varchar](10) NULL,
	[codigo_baja] [varchar](10) NULL,
	[padron_codigo] [numeric](18, 0) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[Afiliados]    Script Date: 09/27/2015 17:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[Afiliados](
	[apellido_nombre] [varchar](60) NOT NULL,
	[documento_tipo] [varchar](3) NOT NULL,
	[documento_numero] [varchar](15) NOT NULL,
	[estado_civil] [varchar](2) NULL,
	[nacionalidad] [varchar](3) NULL,
	[pais] [varchar](3) NULL,
	[direccion_calle] [varchar](30) NULL,
	[direccion_puerta] [varchar](5) NULL,
	[direccion_piso] [varchar](2) NULL,
	[direccion_departamento] [varchar](5) NULL,
	[direccion_numero_postal] [varchar](9) NULL,
	[direccion_telefono] [varchar](20) NULL,
	[fecha_nacimiento] [varchar](10) NOT NULL,
	[sexo] [varchar](1) NOT NULL,
	[cuit] [varchar](15) NULL,
	[cuil] [varchar](15) NULL,
	[beneficio] [varchar](12) NOT NULL,
	[parentesco] [varchar](2) NOT NULL,
	[sucursal] [varchar](2) NULL,
	[agencia] [varchar](2) NULL,
	[corresponsalia] [varchar](2) NULL,
	[afjp] [varchar](2) NULL,
	[afiliacion_vto] [varchar](10) NULL,
	[formulario_tipo] [varchar](11) NULL,
	[fecha_baja] [varchar](10) NULL,
	[codigo_baja] [varchar](10) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_Ambulatorio_c_ambulatorio_default]    Script Date: 09/27/2015 17:51:44 ******/
ALTER TABLE [PAMI].[Ambulatorio] ADD  CONSTRAINT [DF_Ambulatorio_c_ambulatorio_default]  DEFAULT ((0)) FOR [c_ambulatorio_default]
GO
/****** Object:  Default [DF_Ambulatorio_ID_RED_default]    Script Date: 09/27/2015 17:51:44 ******/
ALTER TABLE [PAMI].[Ambulatorio] ADD  CONSTRAINT [DF_Ambulatorio_ID_RED_default]  DEFAULT ((0)) FOR [ID_RED_default]
GO
/****** Object:  Default [DF_Ambulatorio_C_prestador_default]    Script Date: 09/27/2015 17:51:44 ******/
ALTER TABLE [PAMI].[Ambulatorio] ADD  CONSTRAINT [DF_Ambulatorio_C_prestador_default]  DEFAULT ((0)) FOR [C_prestador_default]
GO
/****** Object:  Default [DF_Beneficio_default_alta_por_prestador]    Script Date: 09/27/2015 17:51:44 ******/
ALTER TABLE [PAMI].[Beneficio] ADD  CONSTRAINT [DF_Beneficio_default_alta_por_prestador]  DEFAULT ((1)) FOR [default_alta_por_prestador]
GO
/****** Object:  Default [DF_BocaAtencion_c_prestador_default]    Script Date: 09/27/2015 17:51:44 ******/
ALTER TABLE [PAMI].[BocaAtencion] ADD  CONSTRAINT [DF_BocaAtencion_c_prestador_default]  DEFAULT ((0)) FOR [c_prestador_default]
GO
/****** Object:  Default [DF_Prestador_c_prestador]    Script Date: 09/27/2015 17:51:44 ******/
ALTER TABLE [PAMI].[Prestador] ADD  CONSTRAINT [DF_Prestador_c_prestador]  DEFAULT ((0)) FOR [c_prestador_default]
GO
/****** Object:  Default [DF_Prestador_c_cuit_default]    Script Date: 09/27/2015 17:51:44 ******/
ALTER TABLE [PAMI].[Prestador] ADD  CONSTRAINT [DF_Prestador_c_cuit_default]  DEFAULT ((0)) FOR [c_cuit_default]
GO
/****** Object:  Default [DF_Prestador_C_Profesional_default]    Script Date: 09/27/2015 17:51:44 ******/
ALTER TABLE [PAMI].[Prestador] ADD  CONSTRAINT [DF_Prestador_C_Profesional_default]  DEFAULT ((0)) FOR [C_Profesional_default]
GO
/****** Object:  Default [DF_Prestador_Id_Red_default]    Script Date: 09/27/2015 17:51:44 ******/
ALTER TABLE [PAMI].[Prestador] ADD  CONSTRAINT [DF_Prestador_Id_Red_default]  DEFAULT ((0)) FOR [Id_Red_default]
GO
/****** Object:  Default [DF_Profesional_profesional_codigo]    Script Date: 09/27/2015 17:51:44 ******/
ALTER TABLE [PAMI].[Profesional] ADD  CONSTRAINT [DF_Profesional_profesional_codigo]  DEFAULT ((0)) FOR [profesional_codigo]
GO
/****** Object:  Default [DF_REL_DiagnosticosXAmbulatorio_c_ambulatorio_default]    Script Date: 09/27/2015 17:51:44 ******/
ALTER TABLE [PAMI].[REL_DiagnosticosXAmbulatorio] ADD  CONSTRAINT [DF_REL_DiagnosticosXAmbulatorio_c_ambulatorio_default]  DEFAULT ((0)) FOR [c_ambulatorio_default]
GO
/****** Object:  Default [DF_ModulosXPrestador_c_prestador_default]    Script Date: 09/27/2015 17:51:44 ******/
ALTER TABLE [PAMI].[REL_ModulosXPrestador] ADD  CONSTRAINT [DF_ModulosXPrestador_c_prestador_default]  DEFAULT ((0)) FOR [c_prestador_default]
GO
/****** Object:  Default [DF_REL_PracticasRealizadasXAmbulatorio_c_ambulatorio_default]    Script Date: 09/27/2015 17:51:44 ******/
ALTER TABLE [PAMI].[REL_PracticasRealizadasXAmbulatorio] ADD  CONSTRAINT [DF_REL_PracticasRealizadasXAmbulatorio_c_ambulatorio_default]  DEFAULT ((0)) FOR [c_ambulatorio_default]
GO
/****** Object:  Default [DF_REL_ProfesionalesXPrestador_c_prestador_default]    Script Date: 09/27/2015 17:51:44 ******/
ALTER TABLE [PAMI].[REL_ProfesionalesXPrestador] ADD  CONSTRAINT [DF_REL_ProfesionalesXPrestador_c_prestador_default]  DEFAULT ((0)) FOR [c_prestador_default]
GO
/****** Object:  Default [DF_REL_ProfesionalesXPrestador_c_profesional_default]    Script Date: 09/27/2015 17:51:44 ******/
ALTER TABLE [PAMI].[REL_ProfesionalesXPrestador] ADD  CONSTRAINT [DF_REL_ProfesionalesXPrestador_c_profesional_default]  DEFAULT ((0)) FOR [c_profesional_default]
GO
