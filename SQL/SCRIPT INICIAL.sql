-- SCRIPT INICIAL
USE [PAMI]
GO

CREATE SCHEMA [PAMI] AUTHORIZATION [dbo]
GO

----------------------------------------------------------
---------------------CREACION TABLAS----------------------
----------------------------------------------------------

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

CREATE TABLE [PAMI].[AmbulatoriosExistentes](
	[asociacion] [numeric](10, 0) NULL,
	[profesional_posta] [varchar](6) NOT NULL,
	[profesional_facturado] [varchar](6) NOT NULL,
	[ambulatorio_id] [numeric](18, 0) NOT NULL,
	[fecha] [varchar](10) NULL
) ON [PRIMARY]

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

CREATE TABLE [PAMI].[Asociacion] ADD  CONSTRAINT [DF_Asociacion_nroEmulacion]  DEFAULT ((0)) FOR [nroEmulacion]
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

CREATE TABLE [PAMI].[Diagnosticos](
	[CODIGO] [varchar](50) NULL,
	[DIAGNOSTICO] [varchar](50) NULL
) ON [PRIMARY]

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

CREATE TABLE [PAMI].[NomencladorImportar](
	[practica_codigo] [nvarchar](255) NULL,
	[practica_descripcion] [nvarchar](255) NULL,
	[codigo_modulo] [nvarchar](255) NULL
) ON [PRIMARY]

GO

CREATE TABLE [PAMI].[padron](
	[padron] [varchar](8000) NULL
) ON [PRIMARY]

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
	[planilla_modalidad_prestacion] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Planilla] PRIMARY KEY CLUSTERED 
(
	[planilla_asociacion] ASC,
	[planilla_medico] ASC,
	[planilla_fecha] ASC,
	[planilla_hora] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [PAMI].[Planilla] ADD  CONSTRAINT [DF_Planilla_planilla_modalidad_prestacion]  DEFAULT ((0)) FOR [planilla_modalidad_prestacion]
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
	[profesional_direccion_calle] [varchar](30) NULL,
	[profesional_direccion_numero] [varchar](5) NULL,
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

CREATE TABLE [PAMI].[ProfesionalImportar](
	[profesional_nombreCompleto] [varchar](60) NOT NULL,
	[profesional_especialidad_id] [varchar](4) NOT NULL,
	[profesional_matricula_nacional] [varchar](6) NOT NULL,
	[profesional_tipo_documento_id] [varchar](3) NOT NULL,
	[profesional_numero_documento] [varchar](15) NOT NULL
) ON [PRIMARY]

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

CREATE TABLE [PAMI].[REL_DiagnosticosXAmbulatorio] ADD  CONSTRAINT [DF_REL_DiagnosticosXAmbulatorio_c_ambulatorio_default]  DEFAULT ((0)) FOR [c_ambulatorio_default]
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

CREATE TABLE [PAMI].[REL_ModulosXPrestador] ADD  CONSTRAINT [DF_ModulosXPrestador_c_prestador_default]  DEFAULT ((0)) FOR [c_prestador_default]
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

CREATE TABLE [PAMI].[REL_PracticasRealizadasXAmbulatorio] ADD  CONSTRAINT [DF_REL_PracticasRealizadasXAmbulatorio_c_ambulatorio_default]  DEFAULT ((0)) FOR [c_ambulatorio_default]
GO

CREATE TABLE [PAMI].[REL_ProfesionalAsociacion](
	[profesional_matricula] [varchar](6) NOT NULL,
	[asociacion_id] [numeric](10, 0) NOT NULL
) ON [PRIMARY]

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

CREATE TABLE [PAMI].[REL_ProfesionalesXPrestador] ADD  CONSTRAINT [DF_REL_ProfesionalesXPrestador_c_prestador_default]  DEFAULT ((0)) FOR [c_prestador_default]
GO

CREATE TABLE [PAMI].[REL_ProfesionalesXPrestador] ADD  CONSTRAINT [DF_REL_ProfesionalesXPrestador_c_profesional_default]  DEFAULT ((0)) FOR [c_profesional_default]
GO



----------------------------------------------------------
----------------------PROCEDIMIENTOS----------------------
----------------------------------------------------------


----------------------------------------------------------
----------------------AFILIADOS---------------------------
----------------------------------------------------------

CREATE PROCEDURE PAMI.TraerListadoAfiliadosConFiltros 
    @Nombre varchar(60) = '', 
    @Tipo_Dni varchar(3) = '',
    @Dni varchar(15) = '',
    @Beneficio varchar(12) = '',
    @Parentesco varchar(2) = ''
AS 
BEGIN
    SELECT apellido_nombre, documento_tipo, documento_numero, beneficio, parentesco, fecha_nacimiento 
    FROM PAMI.AfiliadosPami
    WHERE	(apellido_nombre LIKE (CASE WHEN @Nombre <> '' THEN '%' + @Nombre + '%' ELSE apellido_nombre END))					
    AND		(documento_tipo LIKE (CASE WHEN @Tipo_Dni <> '' THEN '%' + @Tipo_Dni + '%' ELSE documento_tipo END))     
    AND	    (CONVERT(VARCHAR(15), documento_numero) LIKE (CASE WHEN @Dni <> '' THEN '%' + @Dni + '%' ELSE documento_numero END))
    AND		(beneficio LIKE (CASE WHEN @Beneficio <> '' THEN '%' + @Beneficio + '%' ELSE beneficio END))
    AND		(CONVERT(VARCHAR(2), parentesco) LIKE (CASE WHEN @Parentesco <> '' THEN '%' + @Parentesco + '%' ELSE parentesco END))
    END
GO

CREATE PROCEDURE PAMI.TraerListadoAfiliadosPorBeneficio
	@Beneficio varchar(12),
	@Parentesco varchar(2)
AS
BEGIN
	SELECT TOP 1 apellido_nombre, documento_tipo, documento_numero, beneficio, parentesco, fecha_nacimiento, sexo, padron_codigo
	FROM PAMI.AfiliadosPami WHERE beneficio = @Beneficio AND parentesco = @Parentesco
END
GO

CREATE PROCEDURE PAMI.InsertAfiliado
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

CREATE PROCEDURE PAMI.UpdateAfiliado
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

CREATE PROCEDURE PAMI.DeleteAfiliado
	@Beneficio varchar(12),
	@Parentesco varchar(2)
AS
BEGIN
	DELETE PAMI.AfiliadosPami WHERE beneficio = @Beneficio AND parentesco = @Parentesco
END
GO


----------------------------------------------------------
----------------------CONTADORES--------------------------
----------------------------------------------------------

CREATE PROCEDURE PAMI.TraerListadoProfesionalContadorPracticas
	@MedicoID VARCHAR(6),
	@AsociacionID numeric(10,0),
	@Mes VARCHAR(2),
	@Anio VARCHAR(4)
AS
BEGIN
	IF(LEN(@Mes) = 1)
	BEGIN
	 SET @Mes = '0' + @Mes
	END
	
	SELECT planilla_practica, COUNT(planilla_practica) as Cantidad FROM PAMI.Planilla WHERE SUBSTRING(planilla_fecha,4,2) = @Mes AND SUBSTRING(planilla_fecha,7,4) = @Anio 
	AND planilla_asociacion = @AsociacionID AND planilla_medico = @MedicoID
	GROUP BY planilla_practica
	UNION
	SELECT 'TOTAL' as planilla_practica, COUNT(planilla_practica) as Cantidad FROM PAMI.Planilla WHERE SUBSTRING(planilla_fecha,4,2) = @Mes AND SUBSTRING(planilla_fecha,7,4) = @Anio 
	AND planilla_asociacion = @AsociacionID AND planilla_medico = @MedicoID 
END
GO

----------------------------------------------------------
----------------------DIAGNOSTICOS------------------------
----------------------------------------------------------

CREATE PROCEDURE PAMI.TraerListadoDiagnosticosConFiltros
	@Codigo VARCHAR(10),
	@AsocID VARCHAR(15)
AS
BEGIN
	SET @AsocID = (SELECT PAMI.DevolverCuitAsoc(@AsocID))

	SELECT D.diagnostico_codigo , D.diagnostico_descripcion
	FROM PAMI.Diagnostico D WHERE (D.diagnostico_codigo LIKE (CASE WHEN @Codigo <> '' THEN '%' + @Codigo + '%' ELSE D.diagnostico_codigo END) AND
														D.asociacion_cuit = @AsocID)
END
GO

CREATE PROCEDURE PAMI.TraerListadoDiagnosticosPorCodigo
	@Codigo varchar(10)
AS
BEGIN
	SELECT diagnostico_codigo, diagnostico_descripcion, CONVERT(NUMERIC(15),PAMI.DevolverIDAsoc(asociacion_cuit)) FROM PAMI.Diagnostico  WHERE diagnostico_codigo = @Codigo
END
GO

CREATE PROCEDURE PAMI.DeleteDiagnosticos
	@Codigo varchar(10)
AS
BEGIN
	DELETE PAMI.Diagnostico WHERE diagnostico_codigo = @Codigo;
END
GO

CREATE PROCEDURE PAMI.InsertDiagnosticos
	@Codigo VARCHAR(10),
	@AsocID VARCHAR(15),
	@Descripcion VARCHAR(50)
AS
BEGIN
	DELETE PAMI.Diagnostico WHERE diagnostico_codigo = @Codigo
	INSERT INTO PAMI.Diagnostico(diagnostico_codigo,diagnostico_descripcion,asociacion_cuit)
	SELECT @Codigo,@Descripcion, PAMI.DevolverCuitAsoc(@AsocID)
END
GO

CREATE PROCEDURE PAMI.UpdateDiagnosticos
	@Codigo VARCHAR(10),
	@AsocID VARCHAR(15),
	@Descripcion VARCHAR(50)
AS
BEGIN
	UPDATE PAMI.Diagnostico SET diagnostico_descripcion = @Descripcion, asociacion_cuit = PAMI.DevolverCuitAsoc(@AsocID) WHERE diagnostico_codigo = @Codigo
END
GO
----------------------------------------------------------
------------------------EXPORTAR--------------------------
----------------------------------------------------------
	
CREATE PROCEDURE PAMI.TraerListadoCabeceraParaExportar
	@AsocID numeric(10,0),
	@Anio varchar(4),
	@Mes varchar(2)
AS
	BEGIN
	SELECT TOP 1 A.asociacion_cuit ,A.nroEmulacion + 1 ,@Mes + '-' + SUBSTRING(@Anio,3,2),'','','',A.asociacion_usuario,'' FROM PAMI.Asociacion A WHERE A.asociacion_id = @AsocID
	END
GO

CREATE PROCEDURE PAMI.TraerListadoProfesionalesParaExportar
	@AsocID numeric(10,0),
	@Anio varchar(4),
	@Mes varchar(2)
AS
	BEGIN
		SELECT * FROM PAMI.Profesional WHERE PAMI.ProfesionalPerteneceAPeriodo(profesional_matricula_nacional,@Mes, @Anio, @AsocID) = 0	
	END
GO

CREATE FUNCTION PAMI.ProfesionalPerteneceAPeriodo(@Profesional VARCHAR(6) ,@Mes VARCHAR(2), @Anio VARCHAR(4), @AsocID numeric(10,0))
	RETURNS int
AS
BEGIN
	RETURN ISNULL((SELECT TOP 1 0 FROM PAMI.Planilla WHERE planilla_medico = @Profesional AND substring(planilla_fecha,4,2) = @Mes AND substring(planilla_fecha,7,4) = @Anio AND planilla_asociacion = @AsocID) ,1)
END
GO

CREATE PROCEDURE PAMI.TraerListadoPrestadorParaExportar
	@AsocID numeric(10,0)
AS
	BEGIN
		SELECT '',A.asociacion_cuit,'','',0,'','',tipo_prestador,'',0,A.mail,A.fecha_alta,'','','',
		0,0,0,A.asociacion_nombreCorto,A.calle,A.puerta,'','','','',''
		FROM PAMI.Asociacion A WHERE asociacion_id = @AsocID
	END
GO

CREATE PROCEDURE PAMI.TraerListadoREL_PROFESIONALESXPRESTADORParaExportar
	@AsocID numeric(10,0),
	@Anio varchar(4),
	@Mes varchar(2)
AS
	BEGIN
		SELECT '',A.asociacion_cuit, R.profesional_matricula,0,0,'' FROM PAMI.REL_ProfesionalAsociacion R, PAMI.Asociacion A WHERE R.asociacion_id = @AsocID AND A.asociacion_id = R.asociacion_id
		AND PAMI.ProfesionalPerteneceAPeriodo(R.profesional_matricula,@Mes, @Anio, @AsocID) = 0
	END
GO

CREATE PROCEDURE PAMI.TraerListadoBocaAtencionParaExportar
	@AsocID numeric(10,0)
AS
	BEGIN
		SELECT '',A.asociacion_cuit,'',0, A.codigo_boca_atencion,1,A.calle,A.puerta,'','','','' FROM PAMI.Asociacion A WHERE @AsocID = asociacion_id
	END
GO

CREATE PROCEDURE PAMI.TraerListadoREL_MODULOSXPRESTADORParaExportar
	@AsocID numeric(10,0)
AS
	BEGIN
		SELECT '',cuit_prestador,'',c_prestador_default,modulonomenclador,'' FROM PAMI.REL_ModulosXPrestador R, PAMI.Asociacion A WHERE
		asociacion_id = @AsocID AND cuit_prestador = A.asociacion_cuit
	END
GO

CREATE PROCEDURE PAMI.TraerListadoBENEFICIOParaExportar
	@AsocID numeric(10,0),
	@Anio varchar(4),
	@Mes varchar(2)
AS
	BEGIN
		SELECT DISTINCT '','','',SUBSTRING(planilla_afiliado_beneficio,1,12),'','',1, padron_fecha_alta FROM PAMI.Planilla P, PAMI.AfiliadosPami A WHERE P.planilla_asociacion = @AsocID AND (A.beneficio + A.parentesco) = planilla_afiliado_beneficio AND substring(planilla_fecha,4,2) = @Mes AND substring(planilla_fecha,7,4) = @Anio 
	END
GO

CREATE FUNCTION PAMI.AfiliadoPerteneceAPeriodo(@NroAfiliado VARCHAR(14),@Mes VARCHAR(2), @Anio VARCHAR(4), @AsocID numeric(10,0))
	RETURNS int
AS
BEGIN
	RETURN ISNULL((SELECT TOP 1 0 FROM PAMI.Planilla WHERE planilla_afiliado_beneficio = @NroAfiliado AND substring(planilla_fecha,4,2) = @Mes AND substring(planilla_fecha,7,4) = @Anio AND planilla_asociacion = @AsocID) ,1)
END
GO

CREATE PROCEDURE PAMI.TraerListadoAFILIADOParaExportar
	@AsocID numeric(10,0),
	@Anio varchar(4),
	@Mes varchar(2)
AS
	BEGIN
		SELECT DISTINCT	RTRIM(apellido_nombre), documento_tipo, documento_numero, '','','','','','','','','',fecha_nacimiento,sexo,'','',beneficio,parentesco,'','','','','','','',''
		FROM PAMI.Planilla P , PAMI.AfiliadosPami A WHERE P.planilla_afiliado_beneficio = A.beneficio + A.parentesco AND 
		P.planilla_asociacion = @AsocID AND substring(planilla_fecha,4,2) = @Mes AND substring(planilla_fecha,7,4) = @Anio 
	END
GO

/*
MODALIDAD PRESTACION
1- AFILIADO PROPIO  --> voy a tener en planilla_modalidad_prestacion = 0
2- ORDEN DE PRESTACION  --> voy a tener en planilla_modalidad_prestacion = nro de prestacion
*/

CREATE PROCEDURE PAMI.TraerListadoAMBULATORIOSParaExportar
	@AsocID numeric(10,0),
	@Anio varchar(4),
	@Mes varchar(2)
AS
	BEGIN
		SELECT 
		--AMBULATORIO  
		'','',P.planilla_medico,0,0,0,A.codigo_boca_atencion,0,P.planilla_fecha,'','', CASE planilla_modalidad_prestacion WHEN 0 THEN 1 ELSE 2 END, CASE planilla_modalidad_prestacion WHEN 0 THEN '' ELSE planilla_modalidad_prestacion END,'',substring(planilla_afiliado_beneficio,1,12), SUBSTRING(planilla_afiliado_beneficio,13,2),
		--REL DIAGNOSTICOS X AMBULATORIO
		'','','',0,1,diagnostico_codigo,1,
		--REL_PRACTICASREALIZADASXAMBULATORIO
		'','','',0,1,planilla_practica,planilla_fecha + ' ' + planilla_hora, 1, CASE planilla_modalidad_prestacion WHEN 0 THEN 1 ELSE 2 END, CASE planilla_modalidad_prestacion WHEN 0 THEN '' ELSE planilla_modalidad_prestacion END		
		 FROM PAMI.Planilla P, PAMI.Asociacion A, PAMI.Diagnostico D
		 WHERE P.planilla_asociacion = A.asociacion_id AND asociacion_id = @AsocID AND CONVERT(numeric(18,0),planilla_diagnostico) = D.diagnostico_id AND substring(planilla_fecha,4,2) = @Mes AND substring(planilla_fecha,7,4) = @Anio 
		 ORDER BY  planilla_medico, planilla_fecha, planilla_afiliado_beneficio, planilla_practica
	END
GO

CREATE PROCEDURE PAMI.ValidarExistenAmbulatoriosAsociacion
	@AsocID numeric(10,0),
	@Anio varchar(4),
	@Mes varchar(2)
AS
	BEGIN
		SELECT COUNT(*) FROM PAMI.Planilla WHERE  planilla_asociacion = @AsocID AND substring(planilla_fecha,4,2) = @Mes AND substring(planilla_fecha,7,4) = @Anio  	
	END
GO

CREATE PROCEDURE PAMI.AumentarContadorEmulaciones
	@AsocID numeric(10,0)
AS
	BEGIN
		UPDATE PAMI.Asociacion SET nroEmulacion = nroEmulacion + 1 WHERE asociacion_id = @AsocID
	END
GO


----------------
---LOGEO--------
----------------

CREATE PROCEDURE PAMI.TraerListadoLogueoParaExportar
	@AsocID numeric(10,0),
	@Anio varchar(4),
	@Mes varchar(2)
AS
	BEGIN
		IF(LEN(@Mes) = 1)
		BEGIN
		 SET @Mes = '0' + @Mes
		END
		
		SELECT PRO.profesional_nombreCompleto ,planilla_practica, COUNT(planilla_practica) as Cantidad FROM PAMI.Planilla, PAMI.Profesional PRO WHERE SUBSTRING(planilla_fecha,4,2) = @Mes AND SUBSTRING(planilla_fecha,7,4) = @Anio 
		AND planilla_asociacion = @AsocID AND planilla_medico = PRO.profesional_matricula_nacional
		GROUP BY planilla_practica, PRO.profesional_nombreCompleto

		EXEC PAMI.TraerListadoPlanillaAmbulatoriosCargadosAOtroMedico @AsocID,@Mes, @Anio
	END
GO

CREATE PROCEDURE PAMI.TraerListadoPlanillaParaExportar
	@AsocID numeric(10,0),
	@Anio varchar(4),
	@Mes varchar(2)
AS
	BEGIN
		SELECT PRO.profesional_nombreCompleto, PLA.planilla_fecha, AF.apellido_nombre, PLA.planilla_afiliado_beneficio, PLA.planilla_diagnostico, PLA.planilla_practica, PLA.planilla_hora, PLA.planilla_modalidad_prestacion FROM PAMI.Planilla PLA, PAMI.Profesional PRO, PAMI.AfiliadosPami AF WHERE SUBSTRING(planilla_fecha,4,2) = @Mes AND SUBSTRING(planilla_fecha,7,4) = @Anio 
		AND planilla_asociacion = @AsocID AND planilla_medico = PRO.profesional_matricula_nacional AND AF.beneficio + AF.parentesco = PLA.planilla_afiliado_beneficio
		ORDER BY PRO.profesional_nombreCompleto, PLA.planilla_fecha
	END
GO

	
----------------------------------------------------------
----------------------IMPORTAR----------------------------
----------------------------------------------------------
	
CREATE FUNCTION PAMI.DevolverCuitAsoc(@IndexAsoc VARCHAR(15))
RETURNS VARCHAR(15)
AS  
BEGIN 
	DECLARE @RETURN VARCHAR(15) = '0';
	IF('0' = @IndexAsoc)
	BEGIN 
		SET @RETURN = '30689632447'
	END
	IF('1' = @IndexAsoc)
	BEGIN
		SET @RETURN = '30708916532'
	END
	RETURN @RETURN
END
GO

CREATE FUNCTION PAMI.DevolverIDAsoc(@CuitAsoc VARCHAR(15))
RETURNS VARCHAR(15)
AS  
BEGIN 
	DECLARE @RETURN varchar(15) = '0';
	IF('30689632447' = @CuitAsoc)
	BEGIN 
		SET @RETURN = '0'
	END
	IF('30708916532' = @CuitAsoc)
	BEGIN
		SET @RETURN = '1'
	END
	RETURN @RETURN
END
GO

--///// PADRON \\\\\--

CREATE PROCEDURE PAMI.ImportarPadron
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
	TRUNCATE TABLE PAMI.Padron;
	SELECT COUNT(beneficio) FROM PAMI.AfiliadosPami WHERE padron_codigo = @Padron
	END
GO				

CREATE PROCEDURE PAMI.ActualizarPadronAfiliados
	@Padron numeric(2,0)
AS
	BEGIN TRANSACTION
		INSERT INTO PAMI.AfiliadosPami(beneficio,parentesco,apellido_nombre,fecha_nacimiento, documento_tipo, documento_numero,sexo,padron_codigo)
		(SELECT 
			CONVERT(varchar(12),substring(padron,5,12)),
			CONVERT(varchar(2),substring(padron,17,2)),
			RTRIM(substring(padron,32,40)),
			substring(padron,78,2) + '/' + substring(padron,76,2) + '/' + substring(padron,72,4),
			substring(padron,80,3),
			CONVERT(numeric(15,0),substring(padron,83,8)),
			substring(padron,98,1),
			@Padron
		 FROM PAMI.padron);
	COMMIT
GO

CREATE PROCEDURE PAMI.ArreglarParentescos
AS
BEGIN
	UPDATE PAMI.AfiliadosPami SET parentesco = '0' + parentesco WHERE LEN(parentesco) = 1
END
GO

--///// PROFESIONALES \\\\\--

CREATE PROCEDURE PAMI.ImportarProfesionales
	@ruta varchar(200),
	@Cuit varchar(15)
AS
	BEGIN
	DECLARE @comando nvarchar(400);
	
	TRUNCATE TABLE PAMI.ProfesionalImportar;
	SET @Cuit = (SELECT PAMI.DevolverCuitAsoc(@Cuit))
	DELETE PAMI.Profesional WHERE profesional_matricula_nacional NOT IN(SELECT R.profesional_matricula FROM PAMI.Asociacion A, PAMI.REL_ProfesionalAsociacion R WHERE A.asociacion_id = R.asociacion_id AND A.asociacion_cuit != @Cuit);
	DELETE PAMI.REL_ProfesionalAsociacion WHERE asociacion_id IN(SELECT A.asociacion_id FROM PAMI.Asociacion A WHERE A.asociacion_cuit = @Cuit);
	
	INSERT INTO PAMI.Profesional SELECT '','','',0,profesional_nombreCompleto, profesional_especialidad_id, profesional_matricula_nacional, '', profesional_tipo_documento_id, profesional_numero_documento,'','','','','','','' FROM PAMI.ProfesionalImportar
	
	SET @comando = 'BULK INSERT PAMI.ProfesionalImportar FROM ''' + @ruta + ''' WITH (FIELDTERMINATOR ='';'', ROWTERMINATOR=''\n'')';
	EXEC sp_executesql @comando;
	
	END
GO

--///// DIAGNOSTICOS \\\\\--

CREATE PROCEDURE PAMI.ImportarDiagnostico
	@ruta varchar(200),
	@Cuit varchar(15)
AS
	BEGIN
	DECLARE @comando nvarchar(400);
	TRUNCATE TABLE PAMI.Diagnosticos;
	TRUNCATE TABLE PAMI.Diagnostico;
	SET @comando = 'BULK INSERT PAMI.Diagnosticos FROM ''' + @ruta + ''' WITH (FIELDTERMINATOR ='';'', ROWTERMINATOR=''\n'')';
	EXEC sp_executesql @comando;
	
	SET @Cuit = (SELECT PAMI.DevolverCuitAsoc(@Cuit))
	
	EXEC PAMI.ActualizarDiagnosticos @Cuit;
	END
GO

CREATE PROCEDURE PAMI.ActualizarDiagnosticos
	@Cuit varchar(15)
AS
	BEGIN
	UPDATE PAMI.Diagnosticos SET CODIGO = UPPER(CODIGO);
	UPDATE PAMI.Diagnosticos SET DIAGNOSTICO = UPPER(DIAGNOSTICO);
	INSERT INTO PAMI.Diagnostico (diagnostico_clasificacion_tipo, diagnostico_codigo, diagnostico_tipo, diagnostico_descripcion, asociacion_cuit)
	SELECT '1',CODIGO,'1',DIAGNOSTICO, @Cuit FROM PAMI.Diagnosticos
	END
GO



--///// NOMENCLADOR \\\\\--

CREATE PROCEDURE PAMI.ImportarNomenclador
	@ruta nvarchar(200),
	@Cuit VARCHAR(15)
AS
	DECLARE @comando nvarchar(400);
	
	TRUNCATE TABLE PAMI.NomencladorImportar;
	SET @comando = 'BULK INSERT PAMI.NomencladorImportar FROM ''' + @ruta + ''' WITH (FIELDTERMINATOR ='';'', ROWTERMINATOR=''\n'')';
	EXEC sp_executesql @comando;
	
	BEGIN
	SET @Cuit = (SELECT PAMI.DevolverCuitAsoc(@Cuit))

	DELETE PAMI.Nomenclador WHERE codigo_modulo IN(SELECT codigo_modulo FROM PAMI.REL_ModulosXPrestador WHERE cuit_prestador = @Cuit);
	DELETE PAMI.REL_ModulosXPrestador WHERE cuit_prestador = @Cuit;
		
	INSERT INTO PAMI.Nomenclador(practica_codigo, practica_descripcion,codigo_modulo, cantidad_maxima)
	SELECT practica_codigo, practica_descripcion, codigo_modulo, 1 FROM PAMI.NomencladorImportar
	
	-- AGREGAR LA RELACION EN LA TABLA REL_MODULOXPRESTADOR 
	INSERT INTO PAMI.REL_ModulosXPrestador (cuit_prestador, modulonomenclador)
	SELECT DISTINCT @Cuit ,codigo_modulo FROM PAMI.NomencladorImportar
	END
GO

----------------------------------------------------------
----------------------NOMENCLADOR-------------------------
----------------------------------------------------------


CREATE PROCEDURE PAMI.TraerListadoNomencladorConFiltros
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
 
CREATE PROCEDURE PAMI.TraerListadoNomencladorPorCodigo
	@Codigo varchar(10)
AS
BEGIN
		SELECT practica_codigo, practica_descripcion, cantidad_maxima, codigo_modulo
		FROM PAMI.Nomenclador WHERE practica_codigo = @Codigo
END
GO

CREATE PROCEDURE PAMI.InsertNomenclador
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

CREATE PROCEDURE PAMI.UpdateNomenclador
   @Codigo varchar(10),
   @Descripcion varchar(255),
   @Modulo numeric(5,0),
   @CantMaxima numeric(3,0)
AS
BEGIN
	UPDATE PAMI.Nomenclador SET practica_descripcion = @Descripcion, codigo_modulo = @Modulo, cantidad_maxima = @CantMaxima WHERE practica_codigo = @Codigo
END
GO

CREATE PROCEDURE PAMI.DeleteNomenclador
	@Codigo varchar(10)
AS
BEGIN
	DELETE PAMI.Nomenclador WHERE practica_codigo = @Codigo
END
GO

----------------------------------------------------------
-------------------NUEVO AMBULATORIO----------------------
----------------------------------------------------------
CREATE PROCEDURE PAMI.traerListadoAsociacionCompleto
AS
BEGIN
	SELECT asociacion_id, asociacion_nombre FROM PAMI.Asociacion
END
GO

CREATE PROCEDURE PAMI.traerListadoDiagnosticosCompleto
AS
BEGIN
	SELECT diagnostico_id,diagnostico_codigo, diagnostico_descripcion FROM PAMI.Diagnostico
END
GO

CREATE PROCEDURE PAMI.TraerListadoAfiliadosConBeneficioNombreDocumento
	@AsocID numeric(10,0)
AS
BEGIN
	SELECT beneficio + parentesco as afiliado_beneficio, apellido_nombre as afiliado_nombre, documento_numero as afiliado_documento FROM PAMI.AfiliadosPami AF, PAMI.Asociacion A WHERE A.padron = AF.padron_codigo AND asociacion_id = @AsocID
END
GO

CREATE PROCEDURE PAMI.TraerListadoAsociacionProfesionales
	@AsociacionID numeric(10,0)
AS
BEGIN
	SELECT profesional_matricula, profesional_nombreCompleto as profesional_nombre FROM PAMI.REL_ProfesionalAsociacion, PAMI.Profesional WHERE profesional_matricula_nacional = profesional_matricula AND asociacion_id = @AsociacionID
END
GO

CREATE PROCEDURE PAMI.traerListadoAfiliadosConFiltrosPorPadronAsociacion
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

CREATE PROCEDURE PAMI.TraerListadoPlanillaNomencladorPorAsociacion
    @AsocID numeric(10,0)
AS
BEGIN
	SELECT practica_codigo, practica_codigo + ' - ' + practica_descripcion as practica_descripcion FROM PAMI.Nomenclador N, PAMI.REL_ModulosXPrestador R, PAMI.Asociacion A WHERE N.codigo_modulo = R.modulonomenclador AND R.cuit_prestador = A.asociacion_cuit AND A.asociacion_id = @AsocID
END
GO


CREATE PROCEDURE PAMI.TraerListadoDiagnosticosPorAsocID
	@AsocID numeric(10,0)
AS
BEGIN
	SELECT diagnostico_id, diagnostico_codigo, diagnostico_descripcion as diagnostico_descripcion FROM PAMI.Diagnostico D, PAMI.Asociacion A WHERE A.asociacion_id = @AsocID AND A.asociacion_cuit = D.asociacion_cuit
END
GO

--si existe me devuelve el ambulatorio!
CREATE PROCEDURE PAMI.ValidarAmbulatorioExistenteEnPlanilla
     @Fecha VARCHAR(10),
     @Afiliado VARCHAR(14),
     @Asociacion numeric(10,0)
AS
BEGIN
	SELECT planilla_medico, planilla_practica, planilla_hora, planilla_diagnostico, planilla_modalidad_prestacion FROM PAMI.Planilla WHERE planilla_afiliado_beneficio = @Afiliado AND planilla_fecha = @Fecha AND planilla_asociacion = @Asociacion
END
GO

CREATE PROCEDURE PAMI.DeletePlanilla
	@Asociacion numeric(10,0),
	@Medico varchar(6),
	@Fecha varchar(10),
	@Beneficio varchar(15)
AS
BEGIN
	DELETE PAMI.Planilla WHERE planilla_asociacion = @Asociacion AND planilla_medico = @Medico AND planilla_afiliado_beneficio = @Beneficio AND planilla_fecha = @Fecha
END
GO


----------------------------------------------------------
-----------------------PLANILLA---------------------------
----------------------------------------------------------

CREATE PROCEDURE PAMI.TraerListadoPlanillaTablasParaValidar
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

CREATE PROCEDURE PAMI.InsertPlanilla_RetornarID
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
	@OP varchar(10),
	@Consulta numeric(1) --Consulta = 1, entonces solo una consulta por mes. si consulta = 0 se puede mas de una consulta por mes por afiliado.
AS
BEGIN

	DECLARE @AmbulatorioExistenteMedico VARCHAR(6);
	DECLARE @PracticaExisteEnAmbulatorio numeric(18,0);
	DECLARE @MedicoNombre VARCHAR(50);

	SET @Beneficio = (SELECT TOP 1 beneficio + parentesco FROM PAMI.AfiliadosPami WHERE beneficio + parentesco = @Beneficio OR documento_numero = @Beneficio)
	SET @AmbulatorioExistenteMedico = (SELECT TOP 1 PAMI.ValidarAmbulatorioExistente(@Beneficio, @Fecha, @Asociacion));
	SET @PracticaExisteEnAmbulatorio = (SELECT TOP 1 PAMI.ValidarPracticaYaExisteEnAmbulatorio(@Beneficio, @Fecha, @Practica, @Asociacion, @Consulta));
	
	IF((@AmbulatorioExistenteMedico <> @Medico AND @AmbulatorioExistenteMedico <> '-1') OR (@AmbulatorioExistenteMedico = @Medico AND (@PracticaExisteEnAmbulatorio = 0 OR @PracticaExisteEnAmbulatorio = 2)) OR (@AmbulatorioExistenteMedico = '-1' AND @PracticaExisteEnAmbulatorio = 2))
	BEGIN
		SET @MedicoNombre = ISNULL((SELECT profesional_nombreCompleto  FROM PAMI.Profesional WHERE @AmbulatorioExistenteMedico = profesional_matricula_nacional),-1);
		SELECT @PracticaExisteEnAmbulatorio as Existe, @AmbulatorioExistenteMedico as Medico, @MedicoNombre as MedicoNombre;
	END

	-- El afiliado no tiene ambulatorios ese dia.  o tiene pero no esa práctica.
	IF(@PracticaExisteEnAmbulatorio <> 2 AND (@AmbulatorioExistenteMedico = '-1' OR (@PracticaExisteEnAmbulatorio = 1 AND @AmbulatorioExistenteMedico = @Medico)))
	BEGIN
		SELECT '-1' as Existe ,'-1' as Medico, '-1' as MedicoNombre,PAMI.ObtenerHoraAmbulatorio(@Asociacion,@AmbulatorioExistenteMedico,@Fecha,@Hora)
		
 		INSERT INTO PAMI.Planilla (planilla_asociacion,planilla_medico,planilla_fecha,planilla_afiliado_beneficio,planilla_diagnostico,planilla_practica,planilla_hora, planilla_modalidad_prestacion)
		(SELECT @Asociacion, @Medico, @Fecha,
		(SELECT TOP 1 beneficio + parentesco FROM PAMI.AfiliadosPami WHERE beneficio + parentesco = @Beneficio OR documento_numero = @Beneficio),
		(SELECT TOP 1 diagnostico_id FROM PAMI.Diagnostico WHERE diagnostico_codigo = @Diagnostico OR diagnostico_descripcion like '%' + @Diagnostico + '%' COLLATE Modern_Spanish_CI_AI OR Convert(varchar(18),diagnostico_id) = @Diagnostico),
		@Practica, PAMI.ObtenerHoraAmbulatorio(@Asociacion,@Medico,@Fecha,@Hora), @OP)		
	END
	
END
GO


CREATE FUNCTION PAMI.ValidarAmbulatorioExistente(@Beneficio VARCHAR(14), @Fecha VARCHAR(10), @Asociacion numeric(10,0))
RETURNS VARCHAR(6)
AS  --SI YA EXISTE DEVUELVE EL MEDICO QUE TIENE EL AMBULATORIO
BEGIN 
	 RETURN isnull((SELECT TOP 1 planilla_medico FROM PAMI.Planilla WHERE planilla_afiliado_beneficio = @Beneficio AND planilla_fecha = @Fecha AND planilla_asociacion = @Asociacion),'-1');
END
GO

CREATE FUNCTION PAMI.ValidarPracticaYaExisteEnAmbulatorio(@Beneficio VARCHAR(14), @Fecha VARCHAR(10), @Practica VARCHAR(10), @Asociacion numeric(10,0),@Consulta numeric(1,0))
RETURNS int  -- 0 ya existe practica, NO SE PUEDE INSERTAR OTRA. 1 no existe practica SE PUEDE INSERTAR OTRA PRACTICA
AS           -- 2 ya existe la consulta ese mes! NO SE PUEDE INSERTAR OTRA.
BEGIN
	 DECLARE @CantMax numeric(3,0) = (SELECT cantidad_maxima FROM PAMI.Nomenclador WHERE practica_codigo = @Practica)
	 DECLARE @Return numeric(3,0) = 0;
	 IF( @CantMax >
	 (SELECT TOP 1 COUNT(planilla_practica) FROM PAMI.Planilla WHERE planilla_afiliado_beneficio = @Beneficio AND planilla_fecha = @Fecha AND planilla_practica = @Practica AND planilla_asociacion = @Asociacion))
	 BEGIN
		SET @Return = 1;
	 END
	 	--Consulta = 1, entonces solo una consulta por mes. si consulta = 0 se puede mas de una consulta por mes por afiliado.
	 IF(@Consulta = 1 AND (@Practica = '428101' OR @Practica = '428102'))
	 BEGIN
	 	 SET @Return = (SELECT  CASE WHEN COUNT(planilla_practica) > 0 THEN 2 ELSE 1 END FROM PAMI.Planilla WHERE planilla_afiliado_beneficio = @Beneficio AND planilla_practica = @Practica 
	 						AND planilla_asociacion = @Asociacion AND  SUBSTRING(planilla_fecha,4,2) = SUBSTRING(@Fecha,4,2) AND SUBSTRING(planilla_fecha,7,4) = SUBSTRING(@Fecha,7,4));
	 END
	 RETURN @Return
END
GO

CREATE PROCEDURE PAMI.InsertPlanilla_RetornarIDAmbulatorioExistente  --ESTE LO USO UNA VEZ QUE YA VALIDE QUE LAS PRACTICAS SE PUEDEN AGREGAR. EN PLANILLA CUANDO APARECE AMBULATORIOS EXISTENTES.
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
	@OP varchar(10),
	@MedicoPosta varchar(6)
AS
BEGIN
	DECLARE @AmbulatorioID numeric(18,0)
	SELECT PAMI.ObtenerHoraAmbulatorio(@Asociacion,@Medico,@Fecha,@Hora)	
	INSERT INTO PAMI.Planilla (planilla_asociacion,planilla_medico,planilla_fecha,planilla_afiliado_beneficio,planilla_diagnostico,planilla_practica,planilla_hora,planilla_modalidad_prestacion)
		(SELECT @Asociacion, @Medico, @Fecha,
		(SELECT beneficio + parentesco FROM PAMI.AfiliadosPami WHERE beneficio + parentesco = @Beneficio OR documento_numero = @Beneficio),
		(SELECT diagnostico_codigo FROM PAMI.Diagnostico WHERE diagnostico_codigo = @Diagnostico OR diagnostico_descripcion like '%' + @Diagnostico + '%' COLLATE Modern_Spanish_CI_AI),
		@Practica, PAMI.ObtenerHoraAmbulatorio(@Asociacion,@Medico,@Fecha,@Hora),@OP)
	
	SET @AmbulatorioID = (SELECT TOP 1 planilla_ambulatorio_codigo FROM PAMI.Planilla P ORDER BY P.planilla_ambulatorio_codigo DESC)
	INSERT INTO PAMI.AmbulatoriosExistentes (profesional_posta,profesional_facturado,ambulatorio_id, fecha,asociacion)
	VALUES (@MedicoPosta,@Medico,@AmbulatorioID,@Fecha,@Asociacion)
END
GO

CREATE FUNCTION PAMI.ObtenerHoraAmbulatorio(@Asociacion numeric(10,0), @Medico VARCHAR(6),@Fecha VARCHAR(10), @Hora VARCHAR(5))
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

CREATE PROCEDURE PAMI.TraerListadoPlanillaAmbulatoriosCargadosAOtroMedico
	@Asociacion numeric(10,0),
	@Mes varchar(2),
	@Anio varchar(4)
AS
BEGIN
	SELECT PRO1.profesional_nombreCompleto AS profesional_facturado, PRO2.profesional_nombreCompleto as profesional_posta, P.planilla_fecha, AF.apellido_nombre as planilla_afiliado_nombre, P.planilla_afiliado_beneficio,
	planilla_diagnostico, planilla_practica,planilla_hora 
    FROM PAMI.AmbulatoriosExistentes A, PAMI.Planilla P, PAMI.AfiliadosPami AF, PAMI.Profesional PRO1,PAMI.Profesional PRO2
    WHERE	SUBSTRING(fecha,4,2) = @Mes AND SUBSTRING(fecha,7,4) = @Anio AND asociacion = @Asociacion AND P.planilla_ambulatorio_codigo = A.ambulatorio_id		 
			AND P.planilla_afiliado_beneficio = AF.beneficio + AF.parentesco AND PRO1.profesional_matricula_nacional = A.profesional_facturado AND PRO2.profesional_matricula_nacional = A.profesional_posta
END
GO
 
CREATE PROCEDURE PAMI.TraerListadoPlanillaActualPorMedicoAsociacion
	@Asociacion numeric(10,0),
	@Medico varchar(6),
	@Mes varchar(2),
	@Anio varchar(4),
	@Beneficio varchar(15)
AS
BEGIN
	SELECT planilla_fecha, A.apellido_nombre as "planilla_afiliado_nombre", planilla_afiliado_beneficio, D.diagnostico_descripcion as "planilla_diagnostico",planilla_practica,planilla_hora, '(' + RTRIM(CONVERT(VARCHAR(18),planilla_ambulatorio_codigo)) + ') Ver ambulatorio' as planilla_ambulatorio
	FROM PAMI.Planilla P, PAMI.AfiliadosPami A, PAMI.Diagnostico D WHERE planilla_asociacion = @Asociacion AND 
	(P.planilla_medico LIKE (CASE WHEN @Medico <> 0 THEN @Medico ELSE P.planilla_medico END)) AND
	(P.planilla_afiliado_beneficio LIKE (CASE WHEN @Beneficio <> '' THEN '%' + @Beneficio + '%' ELSE P.planilla_afiliado_beneficio END)) AND
	(SUBSTRING(planilla_fecha,4,2) LIKE (CASE WHEN @Mes <> 0 THEN @Mes ELSE SUBSTRING(planilla_fecha,4,2) END)) AND
	(SUBSTRING(planilla_fecha,7,4) LIKE (CASE WHEN @Anio <> 0 THEN @Anio ELSE SUBSTRING(planilla_fecha,7,4) END))
	AND planilla_afiliado_beneficio = A.beneficio + A.parentesco AND D.diagnostico_id = planilla_diagnostico
END
GO

CREATE PROCEDURE PAMI.DeletePlanillaPracticaAPractica
	@Asociacion numeric(10,0),
	@Medico varchar(6),
	@Fecha varchar(10),
	@Beneficio varchar(15),
	@Practica varchar(20)
AS
BEGIN
	DELETE PAMI.Planilla WHERE planilla_asociacion = @Asociacion AND planilla_medico = @Medico AND planilla_afiliado_beneficio = @Beneficio AND planilla_fecha = @Fecha AND planilla_practica = @Practica
END
GO

CREATE PROCEDURE PAMI.RegistrarAmbulatorioExistente
	@Asociacion numeric(10,0),
	@Medico varchar(6),
	@Fecha varchar(10),
	@Beneficio varchar(15),
	@MedicoPosta numeric(18,0),
	@Practica varchar(20)
AS
BEGIN
	INSERT INTO PAMI.AmbulatoriosExistentes(asociacion,profesional_posta,profesional_facturado,fecha, ambulatorio_id)
	VALUES (@Asociacion,@MedicoPosta,@Medico,@Fecha,
	(SELECT TOP 1 planilla_ambulatorio_codigo FROM PAMI.Planilla WHERE planilla_asociacion = @Asociacion AND planilla_medico = @Medico AND planilla_afiliado_beneficio = @Beneficio AND planilla_fecha = @Fecha AND planilla_practica = @Practica))
END
GO

----------------------------------------------------------
-------------------------TRIGGERS-------------------------
----------------------------------------------------------

CREATE TRIGGER PAMI.TR_arreglar_fechas
ON PAMI.Planilla
AFTER INSERT, UPDATE
AS
BEGIN
SET NOCOUNT ON
	UPDATE PAMI.Planilla SET planilla_fecha = '0' + planilla_fecha WHERE LEN(planilla_fecha) = 9 AND planilla_ambulatorio_codigo IN(SELECT I.planilla_ambulatorio_codigo FROM INSERTED I)
END
GO

CREATE TRIGGER PAMI.TR_DeleteAmbulatorioExistenteAfterDeleteAmbulatorio
ON PAMI.Planilla
AFTER DELETE
AS
BEGIN
SET NOCOUNT ON
	DELETE PAMI.AmbulatoriosExistentes WHERE ambulatorio_id IN(SELECT planilla_ambulatorio_codigo FROM DELETED)
END
GO

CREATE TRIGGER PAMI.TR_DeleteProfesionalAsociacionAfterDeleteProfesional
ON PAMI.Profesional
AFTER DELETE
AS
BEGIN
SET NOCOUNT ON
	DELETE PAMI.REL_ProfesionalAsociacion WHERE profesional_matricula IN(SELECT profesional_matricula_nacional FROM DELETED)
END
GO


----------------------------------------------------------
-----------------------PRESTADOR--------------------------
----------------------------------------------------------

CREATE PROCEDURE PAMI.TraerListadoPrestadorPorCuitYUsuario
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

CREATE PROCEDURE PAMI.InsertPrestador
      @Cuit varchar(15),
      @Nombre varchar(50),
      @BocaAtencion varchar(5),
      @Sap varchar(5),
      @FechaAlta varchar(10),
      @NombreCorto varchar(30),
      @Usuario varchar(16),
      @Calle varchar(30),
      @Numero numeric(5,0),
      @Piso varchar(2),
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

CREATE PROCEDURE PAMI.UpdatePrestador
	@Cuit varchar(15),
	@Nombre varchar(50),
	@BocaAtencion varchar(5),
	@Sap varchar(5),
	@FechaAlta varchar(10),
	@NombreCorto varchar(30),
	@Usuario varchar(16),
	@Calle varchar(30),
	@Numero numeric(5,0),
	@Piso varchar(2),
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

CREATE PROCEDURE PAMI.TraerListadoPrestadorPorAsociacionID
	@AsocID numeric(10,0)
AS
BEGIN
	SELECT A.asociacion_nombre as prestador_nombre, A.asociacion_nombreCorto as prestador_nombre_corto,A.asociacion_cuit AS prestador_cuit, A.codigo_SAP AS nro_sap,
	A.fecha_alta AS f_fecha_alta, A.asociacion_usuario as usuario_nombre,A.calle AS d_calle, A.puerta AS d_puerta,A.piso AS d_piso, 
	A.depto AS d_departamento, A.tipo_prestador, A.codigo_boca_atencion AS c_boca_atencion, A.mail AS d_mail, A.padron
	FROM PAMI.Asociacion A WHERE A.asociacion_id = @AsocID
END
GO	

CREATE PROCEDURE PAMI.DeletePrestador
	@AsocID numeric(10,0)
AS
BEGIN
	DELETE PAMI.Asociacion WHERE asociacion_id = @AsocID
END
GO

----------------------------------------------------------
---------------------PROFESIONAL--------------------------
----------------------------------------------------------
CREATE PROCEDURE PAMI.TraerListadoProfesionalPorFiltros 
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

CREATE PROCEDURE PAMI.TraerListadoProfesionalPorMatricula
	@Matricula varchar(6)
AS
BEGIN
	SELECT profesional_nombreCompleto as profesional_nombre, profesional_numero_documento as documento_numero, profesional_tipo_documento_id as documento_tipo, profesional_matricula_nacional, profesional_especialidad_id , profesional_direccion_calle, profesional_direccion_numero, '0' as profesional_direccion_depto, '0' as profesional_direccion_piso
    FROM PAMI.Profesional WHERE profesional_matricula_nacional = @Matricula
END
GO

CREATE PROCEDURE PAMI.DeleteProfesional
	@Matricula varchar(6)
AS
BEGIN
	DELETE PAMI.Profesional WHERE profesional_matricula_nacional = @Matricula
END
GO

CREATE PROCEDURE PAMI.InsertProfesional
	@Nombre nvarchar(60), 
    @TipoDoc varchar(3),
    @Documento varchar(15),
	@Especialidad varchar(4),
	@Matricula varchar(6)
AS
BEGIN
	INSERT INTO PAMI.Profesional(profesional_nombreCompleto,profesional_especialidad_id,profesional_matricula_nacional,profesional_tipo_documento_id,profesional_numero_documento)
	VALUES(@Nombre,@Especialidad,@Matricula,@TipoDoc,@Documento)
END
GO

CREATE PROCEDURE PAMI.UpdateProfesional
	@Nombre nvarchar(60) = null, 
    @TipoDoc varchar(3) = null,
    @Documento varchar(15) = null,
	@Especialidad varchar(4) = null,
	@Matricula varchar(6)= null
AS
BEGIN
	UPDATE PAMI.Profesional SET profesional_nombreCompleto = @Nombre, profesional_tipo_documento_id = @TipoDoc, profesional_numero_documento = @Documento, profesional_especialidad_id = @Especialidad WHERE profesional_matricula_nacional = @Matricula
END
GO


----------------------------------------------------------
------------REL ASOCIACION PROFESIONALES------------------
----------------------------------------------------------
CREATE PROCEDURE PAMI.TraerListadoAsociacionProfesionalesSeleccion
@AsociacionID numeric(10,0)
AS
BEGIN
	SELECT 0 as Estado, profesional_matricula_nacional as Matricula, profesional_nombreCompleto as Medico FROM PAMI.Profesional P 
	WHERE profesional_matricula_nacional NOT IN(SELECT profesional_matricula FROM REL_ProfesionalAsociacion WHERE asociacion_id = @AsociacionID)
	UNION
	SELECT 1 as Estado, profesional_matricula as Matricula, profesional_nombreCompleto as Medico FROM PAMI.Profesional P , PAMI.REL_ProfesionalAsociacion R 
	WHERE P.profesional_matricula_nacional = R.profesional_matricula AND asociacion_id = @AsociacionID	
END
GO

CREATE PROCEDURE PAMI.TraerListadoAsociacionProfesionalesSeleccion
@AsociacionID numeric(10,0)
AS
BEGIN
	SELECT 0 as Estado, profesional_matricula_nacional as Matricula, profesional_nombreCompleto as Medico FROM PAMI.Profesional P 
	WHERE profesional_matricula_nacional NOT IN(SELECT profesional_matricula FROM REL_ProfesionalAsociacion WHERE asociacion_id = @AsociacionID)
	UNION
	SELECT 1 as Estado, profesional_matricula as Matricula, profesional_nombreCompleto as Medico FROM PAMI.Profesional P , PAMI.REL_ProfesionalAsociacion R 
	WHERE P.profesional_matricula_nacional = R.profesional_matricula AND asociacion_id = @AsociacionID
END
GO

CREATE FUNCTION PAMI.ProfesionalPerteneceAAsociacion(@AsociacionID numeric(10,0), @Medico varchar(6))
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

CREATE PROCEDURE PAMI.TraerListadoAsociacionProfesionalesSeleccion
@AsociacionID numeric(10,0)
AS
BEGIN
	SELECT PAMI.ProfesionalPerteneceAAsociacion(@AsociacionID,profesional_matricula_nacional) as Estado, profesional_matricula_nacional as matricula, profesional_nombreCompleto as medico FROM PAMI.Profesional ORDER BY profesional_nombreCompleto
END
GO


CREATE PROCEDURE PAMI.UpdateAsociacion_REL_Profesionales
	@AsociacionID numeric(10,0),
	@Medicos TVP_Profesionales READONLY
AS
BEGIN
	DELETE FROM PAMI.REL_ProfesionalAsociacion WHERE asociacion_id = @AsociacionID
	INSERT INTO PAMI.REL_ProfesionalAsociacion(asociacion_id,profesional_matricula) SELECT @AsociacionID, tvp_matricula FROM @Medicos
END
GO


----------------
--ASOCIACIONES--
----------------

--ASOCIACION

SET IDENTITY_INSERT [PAMI].[Asociacion] ON
INSERT [PAMI].[Asociacion] ([asociacion_id], [asociacion_cuit], [asociacion_usuario], [asociacion_nombre], [asociacion_nombreCorto], [padron], [nroEmulacion], [codigo_boca_atencion], [codigo_SAP], [tipo_prestador], [fecha_alta], [mail], [calle], [puerta], [piso], [depto]) VALUES (CAST(1 AS Numeric(10, 0)), N'30689632447', N'UP3068963244701', N'Asociación de Oftalmólogos de Río Negro', N'AORN', CAST(0 AS Numeric(1, 0)), CAST(3 AS Numeric(10, 0)), N'13745', N'59826', N'2', N'01/10/2009', N'elbiohernandez@gmail.com', N'Tucuman', N'1231', N'', N'')
INSERT [PAMI].[Asociacion] ([asociacion_id], [asociacion_cuit], [asociacion_usuario], [asociacion_nombre], [asociacion_nombreCorto], [padron], [nroEmulacion], [codigo_boca_atencion], [codigo_SAP], [tipo_prestador], [fecha_alta], [mail], [calle], [puerta], [piso], [depto]) VALUES (CAST(5 AS Numeric(10, 0)), N'30689632447', N'UP30689632447', N'Asociación de Oftalmólogos de Neuquén', N'AORN', CAST(1 AS Numeric(1, 0)), CAST(0 AS Numeric(10, 0)), N'13745', N'59826', N'2', N'01/10/2009', N'elbiohernandez@gmail.com', N'Tucuman', N'1231', N'', N'')
INSERT [PAMI].[Asociacion] ([asociacion_id], [asociacion_cuit], [asociacion_usuario], [asociacion_nombre], [asociacion_nombreCorto], [padron], [nroEmulacion], [codigo_boca_atencion], [codigo_SAP], [tipo_prestador], [fecha_alta], [mail], [calle], [puerta], [piso], [depto]) VALUES (CAST(6 AS Numeric(10, 0)), N'30708916532', N'UP30708916532N1', N'Asociación de HyH Río Negro', N'AHYHNP', CAST(0 AS Numeric(1, 0)), CAST(0 AS Numeric(10, 0)), N'13745', N'65031', N'2', N'01/10/2009', N'elbiohernandez@gmail.com', N'Tucuman', N'1231', N'', N'')
INSERT [PAMI].[Asociacion] ([asociacion_id], [asociacion_cuit], [asociacion_usuario], [asociacion_nombre], [asociacion_nombreCorto], [padron], [nroEmulacion], [codigo_boca_atencion], [codigo_SAP], [tipo_prestador], [fecha_alta], [mail], [calle], [puerta], [piso], [depto]) VALUES (CAST(7 AS Numeric(10, 0)), N'30708916532', N'UP30689632447', N'Asociación de HYH Neuquén', N'AHYHNP', CAST(1 AS Numeric(1, 0)), CAST(0 AS Numeric(10, 0)), N'13745', N'65031', N'2', N'01/10/2009', N'elbiohernandez@gmail.com', N'Tucuman', N'1231', N'', N'')
SET IDENTITY_INSERT [PAMI].[Asociacion] OFF
