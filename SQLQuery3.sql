USE [PAMI]
GO
/****** Object:  Schema [PAMI]    Script Date: 10/30/2015 17:01:50 ******/
CREATE SCHEMA [PAMI] AUTHORIZATION [dbo]
GO
/****** Object:  UserDefinedTableType [PAMI].[TVP_Profesionales]    Script Date: 10/30/2015 17:01:52 ******/
CREATE TYPE [PAMI].[TVP_Profesionales] AS TABLE(
	[tvp_estado] [bit] NULL,
	[tvp_matricula] [varchar](6) NULL,
	[tvp_medico_nombre] [varchar](60) NULL
)
GO
/****** Object:  Table [PAMI].[NomencladorImportar]    Script Date: 10/30/2015 17:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PAMI].[NomencladorImportar](
	[practica_codigo] [nvarchar](255) NULL,
	[practica_descripcion] [nvarchar](255) NULL,
	[codigo_modulo] [nvarchar](255) NULL,
	[descripcion_modulo] [nvarchar](255) NULL,
	[vigencia_inicio] [nvarchar](255) NULL,
	[totales] [nvarchar](255) NULL,
	[honorarios] [nvarchar](255) NULL,
	[gastos] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [PAMI].[Nomenclador]    Script Date: 10/30/2015 17:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[Nomenclador](
	[practica_codigo] [varchar](10) NOT NULL,
	[practica_descripcion] [varchar](255) NULL,
	[codigo_modulo] [numeric](5, 0) NULL,
	[descripcion_modulo] [varchar](150) NULL,
	[vigencia_inicio] [datetime] NULL,
	[totales] [float] NULL,
	[honorarios] [nvarchar](255) NULL,
	[gastos] [nvarchar](255) NULL,
	[cantidad_maxima] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Nomenclador] PRIMARY KEY CLUSTERED 
(
	[practica_codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[Diagnosticos]    Script Date: 10/30/2015 17:01:52 ******/
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
/****** Object:  Table [PAMI].[Diagnostico]    Script Date: 10/30/2015 17:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[Diagnostico](
	[diagnostico_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[diagnostico_clasificacion_tipo] [varchar](2) NULL,
	[diagnostico_codigo] [varchar](10) NOT NULL,
	[diagnostico_tipo] [varchar](1) NULL,
	[diagnostico_descripcion] [varchar](50) NOT NULL,
	[asociacion_cuit] [varchar](15) NULL,
 CONSTRAINT [PK_Diagnostico] PRIMARY KEY CLUSTERED 
(
	[diagnostico_codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[REL_ProfesionalesXPrestador]    Script Date: 10/30/2015 17:01:52 ******/
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
/****** Object:  Table [PAMI].[REL_ProfesionalAsociacion]    Script Date: 10/30/2015 17:01:52 ******/
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
/****** Object:  Table [PAMI].[REL_PracticasRealizadasXAmbulatorio]    Script Date: 10/30/2015 17:01:52 ******/
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
/****** Object:  Table [PAMI].[REL_ModulosXPrestador]    Script Date: 10/30/2015 17:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[REL_ModulosXPrestador](
	[vacio] [varchar](1) NULL,
	[cuit_prestador] [varchar](15) NOT NULL,
	[vacio1] [varchar](1) NULL,
	[c_prestador_default] [varchar](10) NOT NULL,
	[modulonomenclador] [varchar](2) NOT NULL,
	[fechaInicio] [varchar](10) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[REL_DiagnosticosXAmbulatorio]    Script Date: 10/30/2015 17:01:52 ******/
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
/****** Object:  Table [PAMI].[AmbulatoriosExistentes]    Script Date: 10/30/2015 17:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[AmbulatoriosExistentes](
	[asociacion] [numeric](10, 0) NULL,
	[profesional_posta] [varchar](6) NOT NULL,
	[profesional_facturado] [varchar](6) NOT NULL,
	[ambulatorio_id] [numeric](18, 0) NOT NULL,
	[fecha] [varchar](10) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[Ambulatorio]    Script Date: 10/30/2015 17:01:52 ******/
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
	[id_beneficio] [varchar](12) NOT NULL,
	[id_parentesco] [varchar](2) NOT NULL,
	[f_fecha_atencion] [varchar](10) NOT NULL,
	[c_ambulatorio_default] [varchar](10) NOT NULL,
	[ID_RED_default] [varchar](9) NULL,
	[C_prestador_default] [varchar](10) NOT NULL,
	[c_boca_atencion] [varchar](5) NOT NULL,
	[c_profesional] [varchar](8) NOT NULL,
	[d_estado] [varchar](12) NULL,
	[d_motivo_rechazo] [varchar](60) NULL,
	[id_modalidad_presta] [varchar](2) NOT NULL,
	[n_nro_orden] [varchar](10) NULL,
	[id_tipo_atencion] [varchar](2) NULL,
 CONSTRAINT [PK_Ambulatorio] PRIMARY KEY CLUSTERED 
(
	[matricula_nacional] ASC,
	[id_beneficio] ASC,
	[id_parentesco] ASC,
	[f_fecha_atencion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoAMBULATORIOS2]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoAMBULATORIOS2]
	@AsocID numeric(10,0),
	@Anio varchar(4),
	@Mes varchar(2)
AS
	BEGIN
		SELECT ambulatorio_red_cuit, '',ambulatorio_profesional_matricula_nacional,ambulatorio_codigo,0,0,13745,0,
		(SUBSTRING(ambulatorio_fecha_atencion,9,2)+'/'+SUBSTRING(ambulatorio_fecha_atencion,6,2)+'/'+SUBSTRING(ambulatorio_fecha_atencion,1,4)),
		'','',1,'','',ambulatorio_beneficio_id, ambulatorio_parentesco_id		
		FROM RetransmitirNoviembre.dbo.Ambulatorio
	END
GO
/****** Object:  Table [PAMI].[AfiliadosPami]    Script Date: 10/30/2015 17:01:52 ******/
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
	[padron_codigo] [numeric](18, 0) NULL,
	[padron_fecha_alta] [varchar](10) NULL,
 CONSTRAINT [PK_AfiliadosPami] PRIMARY KEY CLUSTERED 
(
	[beneficio] ASC,
	[parentesco] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[Afiliados]    Script Date: 10/30/2015 17:01:52 ******/
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
	[codigo_baja] [varchar](10) NULL,
 CONSTRAINT [PK_Afiliados] PRIMARY KEY CLUSTERED 
(
	[beneficio] ASC,
	[parentesco] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[Cabecera]    Script Date: 10/30/2015 17:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[Cabecera](
	[cuit_prestador] [varchar](15) NOT NULL,
	[numero_emulacion] [varchar](5) NOT NULL,
	[fecha_emulacion] [varchar](10) NOT NULL,
	[mes_anio_prestacion] [varchar](5) NULL,
	[prestador_nombre] [varchar](30) NULL,
	[prestador_tipo] [varchar](2) NULL,
	[usuario_nombre] [varchar](16) NOT NULL,
	[nro_instalacion_efectores] [varchar](20) NULL,
 CONSTRAINT [PK_Cabecera] PRIMARY KEY CLUSTERED 
(
	[cuit_prestador] ASC,
	[fecha_emulacion] ASC,
	[usuario_nombre] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[BocaAtencion]    Script Date: 10/30/2015 17:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[BocaAtencion](
	[vacio] [varchar](1) NULL,
	[cuit_prestador] [varchar](15) NOT NULL,
	[asociacion_id] [numeric](10, 0) NOT NULL,
	[vacio1] [varchar](1) NULL,
	[c_prestador_default] [varchar](10) NOT NULL,
	[c_boca_atencion] [varchar](5) NOT NULL,
	[sucursal] [varchar](2) NOT NULL,
	[direccion_calle] [varchar](30) NOT NULL,
	[direccion_numero] [varchar](5) NOT NULL,
	[direccion_piso] [varchar](2) NULL,
	[direccion_depto] [varchar](5) NULL,
	[npostal] [varchar](9) NULL,
	[telefono] [varchar](20) NULL,
 CONSTRAINT [PK_BocaAtencion] PRIMARY KEY CLUSTERED 
(
	[cuit_prestador] ASC,
	[asociacion_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[Beneficio]    Script Date: 10/30/2015 17:01:52 ******/
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
/****** Object:  Table [PAMI].[Asociacion]    Script Date: 10/30/2015 17:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[Asociacion](
	[asociacion_id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[asociacion_cuit] [varchar](15) NOT NULL,
	[asociacion_usuario] [varchar](16) NOT NULL,
	[asociacion_nombre] [varchar](50) NOT NULL,
	[asociacion_nombreCorto] [varchar](30) NOT NULL,
	[padron] [numeric](1, 0) NULL,
	[nroEmulacion] [numeric](10, 0) NULL,
	[codigo_boca_atencion] [varchar](5) NULL,
	[codigo_SAP] [varchar](5) NULL,
	[tipo_prestador] [varchar](1) NULL,
	[fecha_alta] [varchar](10) NULL,
	[mail] [varchar](50) NULL,
	[calle] [varchar](30) NULL,
	[puerta] [varchar](5) NULL,
	[piso] [varchar](2) NULL,
	[depto] [varchar](5) NULL,
 CONSTRAINT [PK_Asociacion] PRIMARY KEY CLUSTERED 
(
	[asociacion_id] ASC,
	[asociacion_cuit] ASC,
	[asociacion_usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[Profesional]    Script Date: 10/30/2015 17:01:52 ******/
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
	[profesional_telefono] [varchar](20) NULL,
 CONSTRAINT [PK_Profesional] PRIMARY KEY CLUSTERED 
(
	[profesional_matricula_nacional] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[Prestador]    Script Date: 10/30/2015 17:01:52 ******/
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
	[d_puerta] [varchar](5) NOT NULL,
	[d_piso] [varchar](2) NULL,
	[d_departamento] [varchar](5) NULL,
	[npostal] [varchar](9) NULL,
	[d_telefono] [varchar](20) NULL,
	[c_instalacion] [varchar](20) NULL,
	[asociacion_id] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_Prestador_1] PRIMARY KEY CLUSTERED 
(
	[prestador_cuit] ASC,
	[asociacion_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[Planilla]    Script Date: 10/30/2015 17:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [PAMI].[Planilla](
	[planilla_ambulatorio_codigo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[planilla_asociacion] [numeric](10, 0) NOT NULL,
	[planilla_medico] [varchar](6) NOT NULL,
	[planilla_fecha] [varchar](10) NOT NULL,
	[planilla_afiliado_beneficio] [varchar](14) NOT NULL,
	[planilla_diagnostico] [varchar](10) NOT NULL,
	[planilla_practica] [varchar](20) NOT NULL,
	[planilla_hora] [varchar](5) NOT NULL,
	[planilla_modalidad_prestacion] [varchar](10) NULL,
 CONSTRAINT [PK_Planilla] PRIMARY KEY CLUSTERED 
(
	[planilla_asociacion] ASC,
	[planilla_medico] ASC,
	[planilla_fecha] ASC,
	[planilla_hora] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [PAMI].[padron]    Script Date: 10/30/2015 17:01:52 ******/
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
/****** Object:  UserDefinedFunction [PAMI].[ObtenerHoraAmbulatorio]    Script Date: 10/30/2015 17:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [PAMI].[ObtenerHoraAmbulatorio](@Asociacion numeric(10,0), @Medico VARCHAR(6),@Fecha VARCHAR(10), @Hora VARCHAR(5))
RETURNS VARCHAR(5) --si la hora no esta ocupada, devuelve a ella misma, caso contrario va sumando 5 min hasta encontrar hora libre.
AS
BEGIN
	DECLARE @HoraReturn varchar(5) = @Hora
	WHILE(@HoraReturn IN(SELECT planilla_hora FROM PAMI.Planilla WHERE planilla_medico = @Medico AND planilla_asociacion = @Asociacion AND planilla_fecha = @Fecha))
	BEGIN
	SET @HoraReturn = CONVERT(VARCHAR(5),DATEADD(MINUTE, 5, @HoraReturn), 108)
	END	
	RETURN @HoraReturn
END
GO
/****** Object:  StoredProcedure [PAMI].[ArreglarParentescos]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[ArreglarParentescos]
AS
BEGIN
	UPDATE PAMI.AfiliadosPami SET parentesco = '0' + parentesco WHERE LEN(parentesco) = 1
END
GO
/****** Object:  StoredProcedure [PAMI].[ArmarAmbulatorios]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[ArmarAmbulatorios]
	@AsocID numeric(10,0), 
	@Anio varchar(4),
	@Mes varchar(2)
AS
BEGIN
	DECLARE @AmbID numeric(18,0) = 0;
	SET @AmbID = (SELECT ISNULL((SELECT TOP 1 ambulatorio_id + 1 FROM PAMI.Planilla ORDER BY ambulatorio_id DESC),1))
	-- 1 si no hay nada, o el ultimo ambulatorio_id + 1

	-- Declaracion de variables para el cursor
		DECLARE @ambulatorio_codigo numeric(18,0), 
				@asociacion numeric(10,0), 
				@medico varchar(6),
				@fecha varchar(10), 
				@afiliado_beneficio varchar(14), 
				@diagnostico varchar(10), 
				@practica varchar(20), 
				@hora varchar(5), 
				@ambulatorio_id numeric(18,0)

		-- Declaración del cursor
		DECLARE cPlanilla CURSOR FOR SELECT planilla_ambulatorio_codigo, planilla_asociacion, planilla_medico, planilla_fecha, planilla_afiliado_beneficio, planilla_diagnostico, planilla_practica, planilla_hora, ambulatorio_id  FROM PAMI.Planilla WHERE planilla_asociacion = @AsocID AND substring(planilla_fecha,4,2) = @Mes AND substring(planilla_fecha,7,4) = @Anio

		-- Apertura del cursor
		OPEN cPlanilla

		-- Lectura de la primera fila del cursor
		FETCH cPlanilla INTO  @ambulatorio_codigo, @asociacion, @medico, @fecha, @afiliado_beneficio,@diagnostico, @practica, @hora, @ambulatorio_id 
		 
		--limpio todos los ambulatorios_id para enumerarlos de nuevo
		UPDATE PAMI.Planilla SET ambulatorio_id = -1 WHERE planilla_asociacion = @AsocID AND substring(planilla_fecha,4,2) = @Mes AND substring(planilla_fecha,7,4) = @Anio

		PRINT @@FETCH_STATUS
		
		WHILE (@@FETCH_STATUS = 0 )
			
		BEGIN
			IF(@ambulatorio_id = -1)
			BEGIN
			UPDATE PAMI.Planilla SET ambulatorio_id = @AmbID WHERE planilla_afiliado_beneficio = @afiliado_beneficio AND planilla_medico = @medico AND planilla_fecha = @fecha AND planilla_asociacion = @asociacion AND ambulatorio_id = -1
			SET @AmbID = @AmbID + 1;
			END

			FETCH cPlanilla INTO  @ambulatorio_codigo, @asociacion, @medico, @fecha, @afiliado_beneficio,@diagnostico, @practica, @hora, @ambulatorio_id 
		END
		
		-- Cierre del cursor
		CLOSE cPlanilla

		-- Liberar los recursos
		DEALLOCATE cPlanilla
END
GO
/****** Object:  UserDefinedFunction [PAMI].[AfiliadoPerteneceAPeriodo]    Script Date: 10/30/2015 17:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [PAMI].[AfiliadoPerteneceAPeriodo](@NroAfiliado VARCHAR(14),@Mes VARCHAR(2), @Anio VARCHAR(4), @AsocID numeric(10))
	RETURNS int
AS
BEGIN
	RETURN ISNULL((SELECT TOP 1 0 FROM PAMI.Planilla WHERE planilla_afiliado_beneficio = @NroAfiliado AND substring(planilla_fecha,4,2) = @Mes AND substring(planilla_fecha,7,4) = @Anio AND planilla_asociacion = @AsocID) ,1)
END
GO
/****** Object:  StoredProcedure [PAMI].[ActualizarPadronAfiliados]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[ActualizarPadronAfiliados]
	@Padron numeric(2,0)
AS
	BEGIN TRANSACTION
		INSERT INTO PAMI.AfiliadosPami(beneficio,parentesco,apellido_nombre,fecha_nacimiento, documento_tipo, documento_numero,sexo,padron_codigo)
		(SELECT 
			CONVERT(varchar(12),substring(padron,5,12)),
			CONVERT(varchar(2),substring(padron,17,2)),
			substring(padron,32,40),
			substring(padron,78,2) + '/' + substring(padron,76,2) + '/' + substring(padron,72,4),
			substring(padron,80,3),
			CONVERT(numeric(15,0),substring(padron,83,8)),
			substring(padron,98,1),
			@Padron
		 FROM PAMI.padron);
	COMMIT
GO
/****** Object:  StoredProcedure [PAMI].[ActualizarDiagnosticos]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[ActualizarDiagnosticos]
	@Cuit varchar(15)
AS
	BEGIN
	UPDATE PAMI.Diagnosticos SET CODIGO = UPPER(CODIGO);
	UPDATE PAMI.Diagnosticos SET DIAGNOSTICO = UPPER(DIAGNOSTICO);
	INSERT INTO PAMI.Diagnostico (diagnostico_clasificacion_tipo, diagnostico_codigo, diagnostico_tipo, diagnostico_descripcion, asociacion_cuit)
	SELECT '1',CODIGO,'1',DIAGNOSTICO, @Cuit FROM PAMI.Diagnosticos
	END
GO
/****** Object:  StoredProcedure [dbo].[prueba]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[prueba]
as
begin
	DECLARE @HoraReturn varchar(5) = '09:20';
	WHILE(@HoraReturn IN(SELECT planilla_hora FROM PAMI.Planilla WHERE planilla_medico = '3' AND planilla_asociacion = 1 AND planilla_fecha = '1/10/2015'))
	BEGIN
	SELECT @HoraReturn, 'hola'
	SET @HoraReturn = CONVERT(VARCHAR(5),DATEADD(MINUTE, 5, @HoraReturn), 108)
	END	
	SELECT @HoraReturn, 'CHAU';
end
GO
/****** Object:  UserDefinedFunction [PAMI].[ProfesionalPerteneceAPeriodo]    Script Date: 10/30/2015 17:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [PAMI].[ProfesionalPerteneceAPeriodo](@Profesional VARCHAR(6) ,@Mes VARCHAR(2), @Anio VARCHAR(4), @AsocID numeric(10,0))
	RETURNS int
AS
BEGIN
	RETURN ISNULL((SELECT TOP 1 0 FROM PAMI.Planilla WHERE planilla_medico = @Profesional AND substring(planilla_fecha,4,2) = @Mes AND substring(planilla_fecha,7,4) = @Anio AND planilla_asociacion = @AsocID) ,1)
END
GO
/****** Object:  UserDefinedFunction [PAMI].[ProfesionalPerteneceAAsociacion]    Script Date: 10/30/2015 17:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [PAMI].[ProfesionalPerteneceAAsociacion](@AsociacionID numeric(10,0), @Medico varchar(6))
RETURNS numeric(1,0)
AS
BEGIN
	IF(@Medico NOT IN(SELECT profesional_matricula FROM REL_ProfesionalAsociacion WHERE asociacion_id = @AsociacionID))
	BEGIN
	RETURN 0
	END
	ELSE
	BEGIN
	RETURN 1
	END
	RETURN -1
END
GO
/****** Object:  StoredProcedure [PAMI].[DeleteProfesional]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[DeleteProfesional]
	@Matricula varchar(6)
AS
BEGIN
	DELETE PAMI.Profesional WHERE profesional_matricula_nacional = @Matricula
END
GO
/****** Object:  StoredProcedure [PAMI].[DeletePrestador]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[DeletePrestador]
	@AsocID numeric(10,0)
AS
BEGIN
	DELETE PAMI.BocaAtencion WHERE asociacion_id = @AsocID
	DELETE PAMI.Prestador WHERE asociacion_id = @AsocID
	DELETE PAMI.Asociacion WHERE asociacion_id = @AsocID
END
GO
/****** Object:  StoredProcedure [PAMI].[DeleteNomenclador]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[DeleteNomenclador]
	@Codigo varchar(10)
AS
BEGIN
	DELETE PAMI.Nomenclador WHERE practica_codigo = @Codigo
END
GO
/****** Object:  StoredProcedure [PAMI].[DeleteAfiliado]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[DeleteAfiliado]
	@Beneficio varchar(12),
	@Parentesco varchar(2)
AS
BEGIN
	DELETE PAMI.AfiliadosPami WHERE beneficio = @Beneficio AND parentesco = @Parentesco
END
GO
/****** Object:  StoredProcedure [PAMI].[InsertPrestador]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[InsertPrestador]
      @Cuit varchar(15),
      @Nombre varchar(50),
      @BocaAtencion varchar(5),
      @Sap varchar(5),
      @FechaAlta varchar(10),
      @NombreCorto varchar(30),
      @Usuario varchar(16),
      @Calle varchar(30),
      @Numero numeric(5,0),
      @Piso numeric(2,0),
      @Depto varchar(5),
      @TipoPrestador varchar(1),
      @Mail varchar(50), 
      @AsocID numeric(10,0),
      @Padron numeric(1,0)
AS
BEGIN

	INSERT INTO PAMI.Asociacion(asociacion_nombre, asociacion_nombreCorto, asociacion_cuit,asociacion_usuario,padron,codigo_boca_atencion, codigo_SAP, fecha_alta, calle, puerta, piso, depto,mail,tipo_prestador)
	VALUES(@Nombre,@NombreCorto,@Cuit,@Usuario,@Padron,@BocaAtencion,@Sap,@FechaAlta,@Calle,Convert(varchar(5),@Numero),isnull(CONVERT(varchar(5),@Piso),''),isnull(@Depto,''),@Mail,@TipoPrestador)

END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoAfiliadosPorBeneficio]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoAfiliadosPorBeneficio]
	@Beneficio varchar(12),
	@Parentesco varchar(2)
AS
BEGIN
	SELECT TOP 1 apellido_nombre, documento_tipo, documento_numero, beneficio, parentesco, fecha_nacimiento, sexo, padron_codigo
	FROM PAMI.AfiliadosPami WHERE beneficio = @Beneficio AND parentesco = @Parentesco
END
GO
/****** Object:  StoredProcedure [PAMI].[traerListadoAfiliadosConFiltrosPorPadronAsociacion]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[traerListadoAfiliadosConFiltrosPorPadronAsociacion]
    @Nombre varchar(60) = null, 
    @Dni varchar(15) = null,
    @Beneficio varchar(14) = null,
    @AsocID numeric(10,0)
AS 
BEGIN
    SELECT apellido_nombre, documento_tipo, documento_numero, beneficio, parentesco, fecha_nacimiento 
    FROM PAMI.AfiliadosPami AF, PAMI.Asociacion A
    WHERE	(apellido_nombre LIKE (CASE WHEN @Nombre <> '' THEN '%' + @Nombre + '%' ELSE apellido_nombre END))					
    AND		(@Dni is null OR CONVERT(VARCHAR(15), documento_numero) LIKE '%' + CONVERT(VARCHAR(15), @Dni) + '%')
    AND		(@Beneficio is null OR CONVERT(VARCHAR(14), beneficio + parentesco) LIKE '%' + CONVERT(VARCHAR(14), @Beneficio) + '%')
    AND		(A.asociacion_id = @AsocID)
    AND		(AF.padron_codigo = A.padron)
END
GO
/****** Object:  StoredProcedure [PAMI].[traerListadoAfiliadosConFiltros]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[traerListadoAfiliadosConFiltros] 
    @Nombre nvarchar(60) = null, 
    @Tipo_Dni varchar(3) = null,
    @Dni numeric(15,0) = null,
    @Beneficio varchar(12) = null,
    @Parentesco varchar(2) = null
AS 
BEGIN
    SELECT apellido_nombre, documento_tipo, documento_numero, beneficio, parentesco, fecha_nacimiento 
    FROM PAMI.AfiliadosPami
    WHERE	(apellido_nombre LIKE (CASE WHEN @Nombre <> '' THEN '%' + @Nombre + '%' ELSE apellido_nombre END))					
    AND		(documento_tipo LIKE (CASE WHEN @Tipo_Dni <> '' THEN '%' + @Tipo_Dni + '%' ELSE documento_tipo END))      
    AND		(@Dni is null OR @Dni = 0 OR CONVERT(VARCHAR(15), documento_numero) LIKE '%' + CONVERT(VARCHAR(15), @Dni) + '%')
    AND		(beneficio LIKE (CASE WHEN @Beneficio <> '' THEN '%' + @Beneficio + '%' ELSE beneficio END))
    AND		(@Parentesco is null OR @Parentesco = 0 OR CONVERT(VARCHAR(2), parentesco) LIKE '%' + CONVERT(VARCHAR(2), @Parentesco) + '%')
    END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoAfiliadosConBeneficioNombreDocumento]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoAfiliadosConBeneficioNombreDocumento]
	@AsocID numeric(10,0)
AS
BEGIN
	SELECT beneficio + parentesco as afiliado_beneficio, apellido_nombre as afiliado_nombre, documento_numero as afiliado_documento FROM PAMI.AfiliadosPami AF, PAMI.Asociacion A WHERE A.padron = AF.padron_codigo AND asociacion_id = @AsocID
END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoAFILIADOParaExportar]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoAFILIADOParaExportar]
	@AsocID numeric(10),
	@Anio varchar(4),
	@Mes varchar(2)
AS
	BEGIN
		SELECT apellido_nombre, documento_tipo, documento_numero, '','','','','','','','','',fecha_nacimiento,sexo,'','',beneficio,parentesco,'','','','','','','',''
		FROM PAMI.Planilla P , PAMI.AfiliadosPami A WHERE P.planilla_afiliado_beneficio = A.beneficio + A.parentesco AND 
		P.planilla_asociacion = @AsocID AND substring(planilla_fecha,4,2) = @Mes AND substring(planilla_fecha,7,4) = @Anio 
	END
GO
/****** Object:  StoredProcedure [PAMI].[traerListadoAfiliadoConBeneficioNombreDiagnostico]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[traerListadoAfiliadoConBeneficioNombreDiagnostico]
AS
BEGIN
	SELECT beneficio as afiliado_beneficio, apellido_nombre as afiliado_nombre, documento_numero as afiliado_documento FROM PAMI.AfiliadosPami
END
GO
/****** Object:  StoredProcedure [PAMI].[ImportarNomenclador]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--///// NOMENCLADOR \\\\\--

CREATE PROCEDURE [PAMI].[ImportarNomenclador]
	@ruta nvarchar(200),
	@Cuit varchar(15)
AS
	DECLARE @comando nvarchar(400);
	

	TRUNCATE TABLE PAMI.NomencladorImportar;
	SET @comando = 'BULK INSERT PAMI.NomencladorImportar FROM ''' + @ruta + ''' WITH (FIELDTERMINATOR ='';'', ROWTERMINATOR=''\n'')';
	EXEC sp_executesql @comando;
	
	BEGIN
	IF('0' = @Cuit)
	BEGIN 
		SET @Cuit = '30689632447'
	END
	IF('1' = @Cuit)
	BEGIN
		SET @Cuit = '30708916532'
	END

	DELETE PAMI.Nomenclador WHERE codigo_modulo IN(SELECT codigo_modulo FROM PAMI.REL_ModulosXPrestador WHERE cuit_prestador = @Cuit);
	DELETE PAMI.REL_ModulosXPrestador WHERE cuit_prestador = @Cuit;
	
	
	INSERT INTO PAMI.Nomenclador(practica_codigo, practica_descripcion,codigo_modulo, cantidad_maxima)
	SELECT practica_codigo, practica_descripcion, codigo_modulo, 1 FROM PAMI.NomencladorImportar
	-- AGREGAR LA RELACION EN LA TABLA REL_MODULOXPRESTADOR 
	INSERT INTO PAMI.REL_ModulosXPrestador (cuit_prestador, modulonomenclador)
	SELECT DISTINCT @Cuit ,codigo_modulo FROM PAMI.NomencladorImportar
	END
GO
/****** Object:  StoredProcedure [PAMI].[InsertNomenclador]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[InsertNomenclador]
   @Codigo varchar(10),
   @Descripcion varchar(255),
   @Modulo numeric(5,0),
   @CantMaxima numeric(3,0)
AS
BEGIN
	INSERT INTO PAMI.Nomenclador(practica_codigo, practica_descripcion, codigo_modulo, cantidad_maxima)
	VALUES (@Codigo, @Descripcion, @Modulo,@CantMaxima)
END
GO
/****** Object:  StoredProcedure [PAMI].[InsertAfiliado]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[InsertAfiliado]
	@Nombre nvarchar(60),
	@Beneficio varchar(12),
	@Parentesco varchar(2),
	@Tipo_Dni varchar(3),
	@Dni numeric(15,0),
	@Sexo varchar(1),
	@FechaNac varchar(10),
	@Padron numeric(1,0)
AS
BEGIN
	INSERT INTO PAMI.AfiliadosPami (apellido_nombre,beneficio, parentesco, documento_tipo, documento_numero, fecha_nacimiento, sexo, padron_codigo)
	VALUES(@Nombre,@Beneficio,@Parentesco,@Tipo_Dni,@Dni,CONVERT(varchar(10),CONVERT(datetime, @FechaNac,103),103),@Sexo,@Padron)
END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoProfesionalContadorPracticas]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoProfesionalContadorPracticas]
	@Matricula VARCHAR(6),
	@Asociacion numeric(10,0),
	@Mes VARCHAR(2),
	@Anio VARCHAR(4)
AS
BEGIN
	IF(LEN(@Mes) = 1)
	BEGIN
	 SET @Mes = '0' + @Mes
	END
	
	SELECT planilla_practica, COUNT(planilla_practica) as Cantidad FROM PAMI.Planilla WHERE SUBSTRING(planilla_fecha,4,2) = @Mes AND SUBSTRING(planilla_fecha,7,4) = @Anio 
	AND planilla_asociacion = @Asociacion AND planilla_medico = @Matricula
	GROUP BY planilla_practica
END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoProfesionalContadorPractica]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoProfesionalContadorPractica]
	@Matricula VARCHAR(6),
	@Asociacion numeric(10,0),
	@Mes VARCHAR(2),
	@Anio VARCHAR(4)
AS
BEGIN
	SELECT planilla_practica, COUNT(planilla_practica) FROM PAMI.Planilla WHERE (CONVERT(numeric(2,0),SUBSTRING(planilla_fecha,3,2)) - @Mes) = 0 AND (CONVERT(numeric(2,0),SUBSTRING(planilla_fecha,6,4)) - @Anio) = 0 
	AND planilla_asociacion = @Asociacion AND planilla_medico = @Matricula
	GROUP BY planilla_practica
END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoProfesionalConFiltros]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoProfesionalConFiltros] 
    @Nombre nvarchar(60) = null, 
    @TipoDoc varchar(3) = null,
    @Documento varchar(15) = null,
	@Especialidad varchar(4) = null,
	@Matricula varchar(6)= null
AS 
BEGIN
    SELECT profesional_nombreCompleto as profesional_nombre, profesional_numero_documento as documento_numero, profesional_tipo_documento_id as documento_tipo, profesional_matricula_nacional, profesional_especialidad_id , profesional_direccion_calle, profesional_direccion_numero, profesional_direccion_depto, profesional_direccion_piso
    FROM PAMI.Profesional
    WHERE	(profesional_nombreCompleto LIKE (CASE WHEN @Nombre <> '' THEN '%' + @Nombre + '%' ELSE profesional_nombreCompleto END))					
    AND		(profesional_tipo_documento_id LIKE (CASE WHEN @TipoDoc <> '' THEN '%' + @TipoDoc + '%' ELSE profesional_tipo_documento_id END))      
    AND		(profesional_numero_documento LIKE (CASE WHEN @Documento <> '' THEN '%' + @Documento + '%' ELSE profesional_numero_documento END))
    AND		(profesional_matricula_nacional LIKE (CASE WHEN @Matricula <> '' THEN '%' + @Matricula + '%' ELSE profesional_matricula_nacional END))
    AND		(profesional_especialidad_id LIKE (CASE WHEN @Especialidad <> '' THEN '%' + @Especialidad + '%' ELSE profesional_especialidad_id END))
    END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoPrestadorPorCuitYUsuario]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoPrestadorPorCuitYUsuario]
	@Cuit varchar(15),
	@Usuario varchar(16)
AS
BEGIN
	SELECT TOP 1 A.asociacion_nombre AS prestador_nombre, A.asociacion_cuit AS prestador_cuit, A.codigo_boca_atencion AS c_boca_atencion,
    A.codigo_SAP AS nro_sap, A.fecha_alta AS f_fecha_alta, A.asociacion_nombreCorto AS prestador_nombre_corto,
	A.asociacion_usuario AS usuario_nombre, A.calle AS d_calle, A.puerta AS d_puerta, A.piso AS d_piso, A.depto AS d_depto, 
	A.tipo_prestador, A.mail AS d_mail, A.padron
	FROM PAMI.Asociacion A WHERE A.asociacion_cuit = @Cuit AND A.asociacion_usuario = @Usuario
END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoPrestadorPorCuit]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoPrestadorPorCuit]
	@Cuit varchar(8)
AS
BEGIN
	SELECT A.asociacion_nombre AS prestador_nombre, P.prestador_cuit, B.c_boca_atencion, P.nro_sap, P.f_fecha_alta, P.D_denominacion as prestador_nombre_corto,
		   C.usuario_nombre, P.d_calle, P.d_puerta, P.d_piso, P.d_departamento, P.tipo_prestador
	FROM PAMI.Prestador P,PAMI.Cabecera C, PAMI.BocaAtencion B, PAMI.Asociacion A WHERE C.cuit_prestador = P.prestador_cuit AND B.cuit_prestador = P.prestador_cuit AND asociacion_cuit = P.prestador_cuit AND P.prestador_cuit = @Cuit
END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoPrestadorPorAsocID]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoPrestadorPorAsocID]
	@AsocID numeric(10,0)
AS
BEGIN
	SELECT A.asociacion_nombre as prestador_nombre, A.asociacion_nombreCorto as prestador_nombre_corto,prestador_cuit, nro_sap, f_fecha_alta, A.asociacion_usuario as usuario_nombre, P.d_calle, P.d_puerta, P.d_piso, P.d_departamento, P.tipo_prestador, B.c_boca_atencion
	FROM PAMI.Asociacion A, PAMI.Prestador P, PAMI.BocaAtencion B WHERE A.asociacion_id = @AsocID AND P.prestador_cuit = A.asociacion_cuit AND P.prestador_usuario = A.asociacion_usuario AND B.cuit_prestador = P.prestador_cuit
END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoPrestadorPorAsociacionID]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoPrestadorPorAsociacionID]
	@AsocID numeric(10,0)
AS
BEGIN
	SELECT A.asociacion_nombre as prestador_nombre, A.asociacion_nombreCorto as prestador_nombre_corto,A.asociacion_cuit AS prestador_cuit, A.codigo_SAP AS nro_sap,
	A.fecha_alta AS f_fecha_alta, A.asociacion_usuario as usuario_nombre,A.calle AS d_calle, A.puerta AS d_puerta,A.piso AS d_piso, 
	A.depto AS d_departamento, A.tipo_prestador, A.codigo_boca_atencion AS c_boca_atencion, A.mail AS d_mail, A.padron
	FROM PAMI.Asociacion A WHERE A.asociacion_id = @AsocID
END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoPrestadorParaExportar]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoPrestadorParaExportar]
	@AsocID numeric(10,0)
AS
	BEGIN
		SELECT '',A.asociacion_cuit,'','',0,'','',tipo_prestador,'',0,A.mail,A.fecha_alta,'','','',
		0,0,0,A.asociacion_nombreCorto,A.calle,A.puerta,'','','','',''
		FROM PAMI.Asociacion A WHERE asociacion_id = @AsocID
	END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoPlanillaTablasParaValidar]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoPlanillaTablasParaValidar]
	@AsociacionID numeric(10,0),
	@MedicoID varchar(6),
	@Mes varchar(2),
	@Anio varchar(4)
AS
BEGIN
	SELECT DISTINCT beneficio + parentesco as Beneficio, documento_numero as Documento FROM PAMI.AfiliadosPami, PAMI.Asociacion WHERE asociacion_id = @AsociacionID AND padron = padron_codigo
	SELECT DISTINCT diagnostico_codigo as Diagnostico_Codigo, diagnostico_descripcion as Diagnostico_Descripcion FROM PAMI.Diagnostico
	SELECT DISTINCT practica_codigo as Practica FROM PAMI.Nomenclador N, PAMI.REL_ModulosXPrestador R, PAMI.Asociacion A WHERE N.codigo_modulo = R.modulonomenclador AND A.asociacion_id = @AsociacionID AND A.asociacion_cuit = R.cuit_prestador
	SELECT DISTINCT planilla_fecha as Fecha, planilla_hora as Hora FROM PAMI.Planilla WHERE planilla_medico = @MedicoID AND planilla_asociacion = @AsociacionID AND SUBSTRING(planilla_fecha,4,2) = @Mes AND SUBSTRING(planilla_fecha,7,4) = @Anio
END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoPlanillaNomencladorPorAsociacion]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoPlanillaNomencladorPorAsociacion]
    @AsocID numeric(10,0)
AS
BEGIN
	SELECT practica_codigo, practica_codigo + ' - ' + practica_descripcion as practica_descripcion FROM PAMI.Nomenclador N, PAMI.REL_ModulosXPrestador R, PAMI.Asociacion A WHERE N.codigo_modulo = R.modulonomenclador AND R.cuit_prestador = A.asociacion_cuit AND A.asociacion_id = @AsocID
END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoPlanillaAmbulatoriosCargadosAOtroMedico]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoPlanillaAmbulatoriosCargadosAOtroMedico]
	@Asociacion numeric(10,0),
	@Medico varchar(6),
	@Mes varchar(2),
	@Anio varchar(4)
AS
BEGIN
	SELECT * 
    FROM PAMI.AmbulatoriosExistentes
    WHERE	(profesional_posta LIKE (CASE WHEN @Medico <> '' THEN '%' + @Medico + '%' ELSE profesional_posta END) OR 
			 profesional_facturado LIKE (CASE WHEN @Medico <> '' THEN '%' + @Medico + '%' ELSE profesional_facturado END)) AND
			 SUBSTRING(fecha,4,2) = @Mes AND SUBSTRING(fecha,7,4) = @Anio		 
END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoNomencladorPorCodigo]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoNomencladorPorCodigo]
	@Codigo varchar(10)
AS
BEGIN
		SELECT practica_codigo, practica_descripcion, cantidad_maxima, codigo_modulo
		FROM PAMI.Nomenclador WHERE practica_codigo = @Codigo
END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoNomencladorConFiltros]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoNomencladorConFiltros]
   @AsociacionID numeric(10,0),
   @Codigo varchar(10),
   @Descripcion varchar(255),
   @Modulo numeric(5,0)
AS
BEGIN
		SELECT practica_codigo, practica_descripcion, cantidad_maxima, codigo_modulo
		FROM PAMI.Nomenclador
		WHERE	(practica_descripcion LIKE (CASE WHEN @Descripcion <> '' THEN '%' + @Descripcion + '%' ELSE practica_descripcion END))					
		AND		(practica_codigo LIKE (CASE WHEN @Codigo <> '' THEN '%' + @Codigo + '%' ELSE practica_codigo END))      
		AND		(@Modulo is null OR @Modulo = -1 OR CONVERT(VARCHAR(5), codigo_modulo) LIKE '%' + CONVERT(VARCHAR(5), @Modulo) + '%')
		AND		(@AsociacionID is null OR @AsociacionID = -1 OR 
				@Modulo IN(SELECT R.modulonomenclador FROM PAMI.REL_ModulosXPrestador R, Asociacion WHERE @AsociacionID = asociacion_id AND asociacion_cuit = R.cuit_prestador))
END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoDiagnosticosPorAsocID]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoDiagnosticosPorAsocID]
	@AsocID numeric(10,0)
AS
BEGIN
	SELECT diagnostico_id, diagnostico_codigo, diagnostico_descripcion as diagnostico_descripcion FROM PAMI.Diagnostico D, PAMI.Asociacion A WHERE A.asociacion_id = @AsocID AND A.asociacion_cuit = D.asociacion_cuit
END
GO
/****** Object:  StoredProcedure [PAMI].[traerListadoDiagnosticosCompleto]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[traerListadoDiagnosticosCompleto]
AS
BEGIN
	SELECT diagnostico_id,diagnostico_codigo, diagnostico_descripcion FROM PAMI.Diagnostico
END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoDatosAmbulatorio]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoDatosAmbulatorio]
	@Ambulatorio int
AS
	BEGIN
		SELECT '','','',0,diagnostico_clasificacion_tipo, diagnostico_codigo, diagnostico_tipo FROM PAMI.REL_DiagnosticosXAmbulatorio WHERE c_ambulatorio_default = @Ambulatorio
		select null,null,null,c_ambulatorio_default, 1 , practica_codigo ,
		CONVERT(VARCHAR(10),CONVERT(datetime, practica_fecha),103) + ' ' + CONVERT(VARCHAR(5),CONVERT(datetime, practica_fecha),8),
		practica_cantidad, 1, null
		from PAMI.REL_PracticasRealizadasXAmbulatorio 
		WHERE c_ambulatorio_default = @Ambulatorio
	END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoCabeceraParaExportar]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoCabeceraParaExportar]
	@AsocID numeric(10,0),
	@Anio varchar(4),
	@Mes varchar(2)
AS
	BEGIN
	SELECT TOP 1 A.asociacion_cuit ,A.nroEmulacion + 1 ,@Mes + '-' + SUBSTRING(@Anio,3,2),'','','',A.asociacion_usuario,'' FROM PAMI.Asociacion A WHERE A.asociacion_id = @AsocID
	END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoBocaAtencionParaExportar]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoBocaAtencionParaExportar]
	@AsocID numeric(10,0)
AS
	BEGIN
		SELECT '',A.asociacion_cuit,'',0, A.codigo_boca_atencion,1,A.calle,A.puerta,'','','','' FROM PAMI.Asociacion A WHERE @AsocID = asociacion_id
	END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoBENEFICIOParaExportar]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoBENEFICIOParaExportar]
	@AsocID numeric(10,0),
	@Anio varchar(4),
	@Mes varchar(2)
AS
	BEGIN
		SELECT DISTINCT '','','',SUBSTRING(planilla_afiliado_beneficio,1,12),'','',1, padron_fecha_alta FROM PAMI.Planilla P, PAMI.AfiliadosPami A WHERE P.planilla_asociacion = @AsocID AND (A.beneficio + A.parentesco) = planilla_afiliado_beneficio AND substring(planilla_fecha,4,2) = @Mes AND substring(planilla_fecha,7,4) = @Anio 
	END
GO
/****** Object:  UserDefinedFunction [PAMI].[ValidarPracticaYaExisteEnAmbulatorio]    Script Date: 10/30/2015 17:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [PAMI].[ValidarPracticaYaExisteEnAmbulatorio](@Beneficio VARCHAR(14), @Fecha VARCHAR(10), @Practica VARCHAR(10), @Asociacion numeric(10,0))
RETURNS int  -- 0 ya existe practica. 1 no existe practica
AS
BEGIN
	 RETURN isnull((SELECT TOP 1 0 FROM PAMI.Planilla WHERE planilla_afiliado_beneficio = @Beneficio AND planilla_fecha = @Fecha AND planilla_practica = @Practica AND planilla_asociacion = @Asociacion),1)
END
GO
/****** Object:  UserDefinedFunction [PAMI].[ValidarFechaHoraExistente]    Script Date: 10/30/2015 17:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [PAMI].[ValidarFechaHoraExistente](@Asociacion numeric(10,0), @Medico VARCHAR(6),@Fecha VARCHAR(10), @Hora VARCHAR(6))
RETURNS int -- 0 ya existe fecha hora, 1 no existe fecha hora
AS
BEGIN
	RETURN isnull((SELECT TOP 1 0 FROM PAMI.Planilla WHERE planilla_asociacion = @Asociacion AND planilla_medico = @Medico AND planilla_fecha = @Fecha AND planilla_hora = @Hora),1)
END
GO
/****** Object:  StoredProcedure [PAMI].[ValidarAmbulatorioExistenteEnPlanilla]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[ValidarAmbulatorioExistenteEnPlanilla]
     @Fecha VARCHAR(10),
     @Afiliado VARCHAR(14),
     @Asociacion numeric(10,0)
AS
BEGIN
	SELECT planilla_medico, planilla_practica, planilla_hora, planilla_diagnostico FROM PAMI.Planilla WHERE planilla_afiliado_beneficio = @Afiliado AND planilla_fecha = @Fecha AND planilla_asociacion = @Asociacion
END
GO
/****** Object:  UserDefinedFunction [PAMI].[ValidarAmbulatorioExistente]    Script Date: 10/30/2015 17:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [PAMI].[ValidarAmbulatorioExistente](@Beneficio VARCHAR(14), @Fecha VARCHAR(10), @Asociacion numeric(10,0))
RETURNS VARCHAR(6)
AS  --SI YA EXISTE DEVUELVE EL MEDICO QUE TEIEN EL AMBULATORIO
BEGIN 
	 RETURN isnull((SELECT TOP 1 planilla_medico FROM PAMI.Planilla WHERE planilla_afiliado_beneficio = @Beneficio AND planilla_fecha = @Fecha AND planilla_asociacion = @Asociacion),'-1');
END
GO
/****** Object:  StoredProcedure [PAMI].[UpdatePrestador]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[UpdatePrestador]
	@Cuit varchar(15),
	@Nombre varchar(50),
	@BocaAtencion varchar(5),
	@Sap varchar(5),
	@FechaAlta varchar(10),
	@NombreCorto varchar(30),
	@Usuario varchar(16),
	@Calle varchar(30),
	@Numero numeric(5,0),
	@Piso numeric(2,0),
	@Depto varchar(5),
	@TipoPrestador varchar(1),
	@AsocID varchar(10),
	@Mail varchar(50),
	@Padron numeric(1,0)
AS
BEGIN

	UPDATE PAMI.Asociacion SET asociacion_cuit = @Cuit, asociacion_nombre = @Nombre, codigo_boca_atencion = @BocaAtencion,
							   codigo_SAP = @Sap, fecha_alta = @FechaAlta, asociacion_nombreCorto = @NombreCorto, asociacion_usuario = @Usuario,
							   calle = @Calle, puerta = @Numero, depto = @Depto, tipo_prestador = @TipoPrestador, mail = @Mail, padron = @Padron
	WHERE asociacion_id = @AsocID
END
GO
/****** Object:  StoredProcedure [PAMI].[UpdateNomenclador]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[UpdateNomenclador]
   @Codigo varchar(10),
   @Descripcion varchar(255),
   @Modulo numeric(5,0),
   @CantMaxima numeric(3,0)
AS
BEGIN
	UPDATE PAMI.Nomenclador SET practica_descripcion = @Descripcion, codigo_modulo = @Modulo, cantidad_maxima = @CantMaxima WHERE practica_codigo = @Codigo
END
GO
/****** Object:  StoredProcedure [PAMI].[UpdateAsociacion_REL_Profesionales]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[UpdateAsociacion_REL_Profesionales]
	@AsociacionID numeric(10,0),
	@Medicos TVP_Profesionales READONLY
AS
BEGIN
	DELETE FROM PAMI.REL_ProfesionalAsociacion WHERE asociacion_id = @AsociacionID
	INSERT INTO PAMI.REL_ProfesionalAsociacion(asociacion_id,profesional_matricula) SELECT @AsociacionID, tvp_matricula FROM @Medicos
END
GO
/****** Object:  StoredProcedure [PAMI].[UpdateAfiliado]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[UpdateAfiliado]
	@Nombre nvarchar(60),
	@Beneficio varchar(12),
	@Parentesco varchar(2),
	@Tipo_Dni varchar(3),
	@Dni numeric(15,0),
	@Sexo varchar(1),
	@FechaNac varchar(10),
	@Padron numeric(10,0)
AS
BEGIN
	UPDATE PAMI.AfiliadosPami SET 
	apellido_nombre = @Nombre,
	documento_tipo = @Tipo_Dni,
	documento_numero = @Dni,
	fecha_nacimiento = CONVERT(varchar(10),CONVERT(datetime, @FechaNac,103),103),
	sexo = @Sexo,
	padron_codigo = @Padron
	WHERE beneficio = @Beneficio AND parentesco =  @Parentesco
END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoREL_MODULOSXPRESTADORParaExportar]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoREL_MODULOSXPRESTADORParaExportar]
	@AsocID numeric(10,0)
AS
	BEGIN
		SELECT '',cuit_prestador,'',c_prestador_default,modulonomenclador,'' FROM PAMI.REL_ModulosXPrestador R, PAMI.Asociacion A WHERE
		asociacion_id = @AsocID AND cuit_prestador = A.asociacion_cuit
	END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoProfesionalPorMatricula]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoProfesionalPorMatricula]
	@Matricula varchar(6)
AS
BEGIN
	SELECT profesional_nombreCompleto as profesional_nombre, profesional_numero_documento as documento_numero, profesional_tipo_documento_id as documento_tipo, profesional_matricula_nacional, profesional_especialidad_id , profesional_direccion_calle, profesional_direccion_numero, '0' as profesional_direccion_depto, '0' as profesional_direccion_piso
    FROM PAMI.Profesional WHERE profesional_matricula_nacional = @Matricula
END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoProfesionalPorFiltros]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoProfesionalPorFiltros] 
    @Nombre nvarchar(60) = null, 
    @TipoDoc varchar(3) = null,
    @Documento varchar(15) = null,
	@Especialidad varchar(4) = null,
	@Matricula varchar(6)= null
AS 
BEGIN
    SELECT profesional_nombreCompleto as profesional_nombre, profesional_numero_documento as documento_numero, profesional_tipo_documento_id as documento_tipo, profesional_matricula_nacional, profesional_especialidad_id , profesional_direccion_calle, profesional_direccion_numero, '0' as profesional_direccion_depto, '0' as profesional_direccion_piso
    FROM PAMI.Profesional
    WHERE	(profesional_nombreCompleto LIKE (CASE WHEN @Nombre <> '' THEN '%' + @Nombre + '%' ELSE profesional_nombreCompleto END))					
    AND		(profesional_tipo_documento_id LIKE (CASE WHEN @TipoDoc <> '' THEN '%' + @TipoDoc + '%' ELSE profesional_tipo_documento_id END))      
    AND		(profesional_numero_documento LIKE (CASE WHEN @Documento <> '' THEN '%' + @Documento + '%' ELSE profesional_numero_documento END))
    AND		(profesional_matricula_nacional LIKE (CASE WHEN @Matricula <> '' THEN '%' + @Matricula + '%' ELSE profesional_matricula_nacional END))
    AND		(profesional_especialidad_id LIKE (CASE WHEN @Especialidad <> '' THEN '%' + @Especialidad + '%' ELSE profesional_especialidad_id END))
    END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoAsociacionProfesionales]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoAsociacionProfesionales]
@AsociacionID numeric(10,0)
AS
BEGIN
	SELECT profesional_matricula, profesional_nombreCompleto as profesional_nombre FROM PAMI.REL_ProfesionalAsociacion, PAMI.Profesional WHERE profesional_matricula_nacional = profesional_matricula AND asociacion_id = @AsociacionID
END
GO
/****** Object:  StoredProcedure [PAMI].[traerListadoAsociacionCompleto]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[traerListadoAsociacionCompleto]
AS
BEGIN
	SELECT asociacion_id, asociacion_nombre FROM PAMI.Asociacion
END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoAMBULATORIOSParaExportar]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoAMBULATORIOSParaExportar]
	@AsocID numeric(10,0),
	@Anio varchar(4),
	@Mes varchar(2)
AS
	BEGIN
		SELECT 
		--AMBULATORIO  
		'','',P.planilla_medico,0,0,0,A.codigo_boca_atencion,0,P.planilla_fecha,'','', CASE planilla_modalidad_prestacion WHEN 0 THEN 1 ELSE 2 END, CASE planilla_modalidad_prestacion WHEN 0 THEN '' ELSE planilla_modalidad_prestacion END,'',substring(planilla_afiliado_beneficio,1,12), SUBSTRING(planilla_afiliado_beneficio,13,2),
		--REL DIAGNOSTICOS X AMBULATORIO
		'','','',0,1,planilla_diagnostico,1,
		--REL_PRACTICASREALIZADASXAMBULATORIO
		'','','',0,1,planilla_practica,planilla_fecha + ' ' + planilla_hora, 1, CASE planilla_modalidad_prestacion WHEN 0 THEN 1 ELSE 2 END, CASE planilla_modalidad_prestacion WHEN 0 THEN '' ELSE planilla_modalidad_prestacion END		
		 FROM PAMI.Planilla P, PAMI.Asociacion A
		 WHERE P.planilla_asociacion = A.asociacion_id AND asociacion_id = @AsocID AND substring(planilla_fecha,4,2) = @Mes AND substring(planilla_fecha,7,4) = @Anio 
		 ORDER BY  planilla_medico, planilla_fecha, planilla_afiliado_beneficio, planilla_practica
	END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoREL_PROFESIONALESXPRESTADORParaExportar]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoREL_PROFESIONALESXPRESTADORParaExportar]
	@AsocID numeric(10),
	@Anio varchar(4),
	@Mes varchar(2)
AS
	BEGIN
		SELECT '',A.asociacion_cuit, R.profesional_matricula,0,0,'' FROM PAMI.REL_ProfesionalAsociacion R, PAMI.Asociacion A WHERE R.asociacion_id = @AsocID AND A.asociacion_id = R.asociacion_id
		AND PAMI.ProfesionalPerteneceAPeriodo(R.profesional_matricula,@Mes, @Anio, @AsocID) = 0
	END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoProfesionalesParaExportar]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoProfesionalesParaExportar]
	@AsocID numeric(10),
	@Anio varchar(4),
	@Mes varchar(2)
AS
	BEGIN
		SELECT * FROM PAMI.Profesional WHERE PAMI.ProfesionalPerteneceAPeriodo(profesional_matricula_nacional,@Mes, @Anio, @AsocID) = 0	
	END
GO
/****** Object:  StoredProcedure [PAMI].[TraerListadoAsociacionProfesionalesSeleccion]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[TraerListadoAsociacionProfesionalesSeleccion]
@AsociacionID numeric(10,0)
AS
BEGIN
	SELECT PAMI.ProfesionalPerteneceAAsociacion(@AsociacionID,profesional_matricula_nacional) as Estado, profesional_matricula_nacional as matricula, profesional_nombreCompleto as medico FROM PAMI.Profesional ORDER BY profesional_nombreCompleto
END
GO
/****** Object:  StoredProcedure [PAMI].[ImportarPadron]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[ImportarPadron]
	@ruta nvarchar(200),
	@Padron numeric(2,0)
AS
	BEGIN
	DECLARE @comando nvarchar(400);
	TRUNCATE TABLE PAMI.Padron;
	DELETE PAMI.AfiliadosPami WHERE padron_codigo = @Padron;
	SET @comando = 'BULK INSERT PAMI.padron FROM ''' + @ruta + ''' WITH (ROWTERMINATOR=''\n'')';
	EXEC sp_executesql @comando;
	EXEC PAMI.ActualizarPadronAfiliados @Padron;
	EXEC PAMI.ArreglarParentescos;
	END
GO
/****** Object:  StoredProcedure [PAMI].[ImportarDiagnosticos]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[ImportarDiagnosticos]
	@ruta varchar(200)
AS
	BEGIN
	DECLARE @comando nvarchar(400);
	TRUNCATE TABLE PAMI.Diagnosticos;
	TRUNCATE TABLE PAMI.Diagnostico;
	SET @comando = 'BULK INSERT PAMI.Diagnosticos FROM ''' + @ruta + ''' WITH (FIELDTERMINATOR ='';'', ROWTERMINATOR=''\n'')';
	EXEC sp_executesql @comando;
	EXEC PAMI.ActualizarDiagnosticos;
	END
GO
/****** Object:  StoredProcedure [PAMI].[ImportarDiagnostico]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[ImportarDiagnostico]
	@ruta varchar(200),
	@Cuit varchar(15)
AS
	BEGIN
	DECLARE @comando nvarchar(400);
	TRUNCATE TABLE PAMI.Diagnosticos;
	TRUNCATE TABLE PAMI.Diagnostico;
	SET @comando = 'BULK INSERT PAMI.Diagnosticos FROM ''' + @ruta + ''' WITH (FIELDTERMINATOR ='';'', ROWTERMINATOR=''\n'')';
	EXEC sp_executesql @comando;
	
	IF('0' = @Cuit)
	BEGIN 
		SET @Cuit = '30689632447'
	END
	IF('1' = @Cuit)
	BEGIN
		SET @Cuit = '30708916532'
	END
	
	EXEC PAMI.ActualizarDiagnosticos @Cuit;
	END
GO
/****** Object:  StoredProcedure [PAMI].[InsertPlanilla_RetornarIDAmbulatorioExistente]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[InsertPlanilla_RetornarIDAmbulatorioExistente]
	@Asociacion numeric(10,0),
	@Medico varchar(6),
	@Mes varchar(2),
	@Anio varchar(4),
	--Datos ambulatorio
	@Fecha varchar(10),
	@Nombre varchar(50),
	@Beneficio varchar(15),
	@Diagnostico varchar(50),
	@Practica varchar(10),
	@Hora varchar(5),
	@MedicoPosta varchar(6)
AS
BEGIN
	DECLARE @AmbulatorioID numeric(18,0)
	SELECT PAMI.ObtenerHoraAmbulatorio(@Asociacion,@Medico,@Fecha,@Hora)	
	INSERT INTO PAMI.Planilla (planilla_asociacion,planilla_medico,planilla_fecha,planilla_afiliado_beneficio,planilla_diagnostico,planilla_practica,planilla_hora)
		(SELECT @Asociacion, @Medico, @Fecha,
		(SELECT beneficio + parentesco FROM PAMI.AfiliadosPami WHERE beneficio + parentesco = @Beneficio OR documento_numero = @Beneficio),
		(SELECT diagnostico_codigo FROM PAMI.Diagnostico WHERE diagnostico_codigo = @Diagnostico OR diagnostico_descripcion like '%' + @Diagnostico + '%' COLLATE Modern_Spanish_CI_AI),
		@Practica, PAMI.ObtenerHoraAmbulatorio(@Asociacion,@Medico,@Fecha,@Hora))
	
	SET @AmbulatorioID = (SELECT TOP 1 planilla_ambulatorio_codigo FROM PAMI.Planilla P ORDER BY P.planilla_ambulatorio_codigo DESC)
	INSERT INTO PAMI.AmbulatoriosExistentes (profesional_posta,profesional_facturado,ambulatorio_id, fecha,asociacion)
	VALUES (@MedicoPosta,@Medico,@AmbulatorioID,@Fecha,@Asociacion)
END
GO
/****** Object:  StoredProcedure [PAMI].[InsertPlanilla_RetornarID]    Script Date: 10/30/2015 17:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [PAMI].[InsertPlanilla_RetornarID]
	@Asociacion numeric(10,0),
	@Medico varchar(6),
	@Mes varchar(2),
	@Anio varchar(4),
	--Datos ambulatorio
	@Fecha varchar(10),
	@Nombre varchar(50),
	@Beneficio varchar(15),
	@Diagnostico varchar(50),
	@Practica varchar(10),
	@Hora varchar(5)
AS
BEGIN

	DECLARE @AmbulatorioExistenteMedico VARCHAR(6);
	DECLARE @PracticaExisteEnAmbulatorio numeric(18,0);

	SET @Beneficio = (SELECT TOP 1 beneficio + parentesco FROM PAMI.AfiliadosPami WHERE beneficio + parentesco = @Beneficio OR documento_numero = @Beneficio)
	SET @AmbulatorioExistenteMedico = (SELECT TOP 1 PAMI.ValidarAmbulatorioExistente(@Beneficio, @Fecha, @Asociacion));
	SET @PracticaExisteEnAmbulatorio = (SELECT TOP 1 PAMI.ValidarPracticaYaExisteEnAmbulatorio(@Beneficio, @Fecha, @Practica, @Asociacion));
	
	IF((@AmbulatorioExistenteMedico <> @Medico AND @AmbulatorioExistenteMedico <> '-1') OR (@AmbulatorioExistenteMedico = @Medico AND @PracticaExisteEnAmbulatorio = 0))
	BEGIN
		SELECT TOP 1 @PracticaExisteEnAmbulatorio as Existe, @AmbulatorioExistenteMedico as Medico, profesional_nombreCompleto as MedicoNombre FROM PAMI.Profesional WHERE @AmbulatorioExistenteMedico = profesional_matricula_nacional
	END
	
	-- El afiliado no tiene ambulatorios ese dia.  o tiene pero no esa práctica.
	IF(@AmbulatorioExistenteMedico = '-1' OR (@PracticaExisteEnAmbulatorio = 1 AND @AmbulatorioExistenteMedico = @Medico))
	BEGIN
		SELECT '-1' as Existe ,'-1' as Medico, '-1' as MedicoNombre,PAMI.ObtenerHoraAmbulatorio(@Asociacion,@AmbulatorioExistenteMedico,@Fecha,@Hora)
		
	 	INSERT INTO PAMI.Planilla (planilla_asociacion,planilla_medico,planilla_fecha,planilla_afiliado_beneficio,planilla_diagnostico,planilla_practica,planilla_hora)
		(SELECT @Asociacion, @Medico, @Fecha,
		(SELECT beneficio + parentesco FROM PAMI.AfiliadosPami WHERE beneficio + parentesco = @Beneficio OR documento_numero = @Beneficio),
		(SELECT diagnostico_codigo FROM PAMI.Diagnostico WHERE diagnostico_codigo = @Diagnostico OR diagnostico_descripcion like '%' + @Diagnostico + '%' COLLATE Modern_Spanish_CI_AI),
		@Practica, PAMI.ObtenerHoraAmbulatorio(@Asociacion,@Medico,@Fecha,@Hora))		
	END
END
GO
/****** Object:  Default [DF_Ambulatorio_c_ambulatorio_default]    Script Date: 10/30/2015 17:01:52 ******/
ALTER TABLE [PAMI].[Ambulatorio] ADD  CONSTRAINT [DF_Ambulatorio_c_ambulatorio_default]  DEFAULT ((0)) FOR [c_ambulatorio_default]
GO
/****** Object:  Default [DF_Ambulatorio_ID_RED_default]    Script Date: 10/30/2015 17:01:52 ******/
ALTER TABLE [PAMI].[Ambulatorio] ADD  CONSTRAINT [DF_Ambulatorio_ID_RED_default]  DEFAULT ((0)) FOR [ID_RED_default]
GO
/****** Object:  Default [DF_Ambulatorio_C_prestador_default]    Script Date: 10/30/2015 17:01:52 ******/
ALTER TABLE [PAMI].[Ambulatorio] ADD  CONSTRAINT [DF_Ambulatorio_C_prestador_default]  DEFAULT ((0)) FOR [C_prestador_default]
GO
/****** Object:  Default [DF_Asociacion_nroEmulacion]    Script Date: 10/30/2015 17:01:52 ******/
ALTER TABLE [PAMI].[Asociacion] ADD  CONSTRAINT [DF_Asociacion_nroEmulacion]  DEFAULT ((0)) FOR [nroEmulacion]
GO
/****** Object:  Default [DF_Beneficio_default_alta_por_prestador]    Script Date: 10/30/2015 17:01:52 ******/
ALTER TABLE [PAMI].[Beneficio] ADD  CONSTRAINT [DF_Beneficio_default_alta_por_prestador]  DEFAULT ((1)) FOR [default_alta_por_prestador]
GO
/****** Object:  Default [DF_BocaAtencion_c_prestador_default]    Script Date: 10/30/2015 17:01:52 ******/
ALTER TABLE [PAMI].[BocaAtencion] ADD  CONSTRAINT [DF_BocaAtencion_c_prestador_default]  DEFAULT ((0)) FOR [c_prestador_default]
GO
/****** Object:  Default [DF_Planilla_planilla_modalidad_prestacion]    Script Date: 10/30/2015 17:01:52 ******/
ALTER TABLE [PAMI].[Planilla] ADD  CONSTRAINT [DF_Planilla_planilla_modalidad_prestacion]  DEFAULT ((1)) FOR [planilla_modalidad_prestacion]
GO
/****** Object:  Default [DF_Prestador_c_prestador]    Script Date: 10/30/2015 17:01:52 ******/
ALTER TABLE [PAMI].[Prestador] ADD  CONSTRAINT [DF_Prestador_c_prestador]  DEFAULT ((0)) FOR [c_prestador_default]
GO
/****** Object:  Default [DF_Prestador_m_medico_cabecera]    Script Date: 10/30/2015 17:01:52 ******/
ALTER TABLE [PAMI].[Prestador] ADD  CONSTRAINT [DF_Prestador_m_medico_cabecera]  DEFAULT ((1)) FOR [m_medico_cabecera]
GO
/****** Object:  Default [DF_Prestador_c_cuit_default]    Script Date: 10/30/2015 17:01:52 ******/
ALTER TABLE [PAMI].[Prestador] ADD  CONSTRAINT [DF_Prestador_c_cuit_default]  DEFAULT ((0)) FOR [c_cuit_default]
GO
/****** Object:  Default [DF_Prestador_C_Profesional_default]    Script Date: 10/30/2015 17:01:52 ******/
ALTER TABLE [PAMI].[Prestador] ADD  CONSTRAINT [DF_Prestador_C_Profesional_default]  DEFAULT ((0)) FOR [C_Profesional_default]
GO
/****** Object:  Default [DF_Prestador_Id_Red_default]    Script Date: 10/30/2015 17:01:52 ******/
ALTER TABLE [PAMI].[Prestador] ADD  CONSTRAINT [DF_Prestador_Id_Red_default]  DEFAULT ((0)) FOR [Id_Red_default]
GO
/****** Object:  Default [DF_Profesional_profesional_codigo]    Script Date: 10/30/2015 17:01:52 ******/
ALTER TABLE [PAMI].[Profesional] ADD  CONSTRAINT [DF_Profesional_profesional_codigo]  DEFAULT ((0)) FOR [profesional_codigo]
GO
/****** Object:  Default [DF_REL_DiagnosticosXAmbulatorio_c_ambulatorio_default]    Script Date: 10/30/2015 17:01:52 ******/
ALTER TABLE [PAMI].[REL_DiagnosticosXAmbulatorio] ADD  CONSTRAINT [DF_REL_DiagnosticosXAmbulatorio_c_ambulatorio_default]  DEFAULT ((0)) FOR [c_ambulatorio_default]
GO
/****** Object:  Default [DF_ModulosXPrestador_c_prestador_default]    Script Date: 10/30/2015 17:01:52 ******/
ALTER TABLE [PAMI].[REL_ModulosXPrestador] ADD  CONSTRAINT [DF_ModulosXPrestador_c_prestador_default]  DEFAULT ((0)) FOR [c_prestador_default]
GO
/****** Object:  Default [DF_REL_PracticasRealizadasXAmbulatorio_c_ambulatorio_default]    Script Date: 10/30/2015 17:01:52 ******/
ALTER TABLE [PAMI].[REL_PracticasRealizadasXAmbulatorio] ADD  CONSTRAINT [DF_REL_PracticasRealizadasXAmbulatorio_c_ambulatorio_default]  DEFAULT ((0)) FOR [c_ambulatorio_default]
GO
/****** Object:  Default [DF_REL_ProfesionalesXPrestador_c_prestador_default]    Script Date: 10/30/2015 17:01:52 ******/
ALTER TABLE [PAMI].[REL_ProfesionalesXPrestador] ADD  CONSTRAINT [DF_REL_ProfesionalesXPrestador_c_prestador_default]  DEFAULT ((0)) FOR [c_prestador_default]
GO
/****** Object:  Default [DF_REL_ProfesionalesXPrestador_c_profesional_default]    Script Date: 10/30/2015 17:01:52 ******/
ALTER TABLE [PAMI].[REL_ProfesionalesXPrestador] ADD  CONSTRAINT [DF_REL_ProfesionalesXPrestador_c_profesional_default]  DEFAULT ((0)) FOR [c_profesional_default]
GO
/****** Object:  UserDefinedTableType [PAMI].[TVP_Planilla]    Script Date: 10/30/2015 17:01:52 ******/
CREATE TYPE [PAMI].[TVP_Planilla] AS TABLE(
	[tvp_fecha] [varchar](10) NULL,
	[tvp_nombre] [varchar](60) NULL,
	[tvp_beneficio] [varchar](14) NULL,
	[tvp_diagnostico] [varchar](10) NULL,
	[tvp_practicas] [varchar](10) NULL,
	[tvp_hora] [varchar](5) NULL
)
GO
