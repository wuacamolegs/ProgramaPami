USE [PAMI]
GO

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
