USE [PAMI]
GO

ALTER PROCEDURE PAMI.TraerListadoPlanillaTablasParaValidar
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

ALTER PROCEDURE PAMI.InsertPlanilla_RetornarID
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


ALTER FUNCTION PAMI.ValidarAmbulatorioExistente(@Beneficio VARCHAR(14), @Fecha VARCHAR(10), @Asociacion numeric(10,0))
RETURNS VARCHAR(6)
AS  --SI YA EXISTE DEVUELVE EL MEDICO QUE TIENE EL AMBULATORIO
BEGIN 
	 RETURN isnull((SELECT TOP 1 planilla_medico FROM PAMI.Planilla WHERE planilla_afiliado_beneficio = @Beneficio AND planilla_fecha = @Fecha AND planilla_asociacion = @Asociacion),'-1');
END
GO

ALTER FUNCTION PAMI.ValidarPracticaYaExisteEnAmbulatorio(@Beneficio VARCHAR(14), @Fecha VARCHAR(10), @Practica VARCHAR(10), @Asociacion numeric(10,0),@Consulta numeric(1,0))
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

ALTER PROCEDURE PAMI.InsertPlanilla_RetornarIDAmbulatorioExistente  --ESTE LO USO UNA VEZ QUE YA VALIDE QUE LAS PRACTICAS SE PUEDEN AGREGAR. EN PLANILLA CUANDO APARECE AMBULATORIOS EXISTENTES.
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

ALTER FUNCTION PAMI.ObtenerHoraAmbulatorio(@Asociacion numeric(10,0), @Medico VARCHAR(6),@Fecha VARCHAR(10), @Hora VARCHAR(5))
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

ALTER PROCEDURE PAMI.TraerListadoPlanillaAmbulatoriosCargadosAOtroMedico
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
 
ALTER PROCEDURE PAMI.TraerListadoPlanillaActualPorMedicoAsociacion
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

ALTER PROCEDURE PAMI.RegistrarAmbulatorioExistente
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


select * from PAMI.Planilla
