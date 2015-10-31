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
		(SELECT diagnostico_id FROM PAMI.Diagnostico WHERE diagnostico_codigo = @Diagnostico OR diagnostico_descripcion like '%' + @Diagnostico + '%' COLLATE Modern_Spanish_CI_AI OR diagnostico_id = @Diagnostico),
		@Practica, PAMI.ObtenerHoraAmbulatorio(@Asociacion,@Medico,@Fecha,@Hora))		
	END
END
GO

ALTER FUNCTION PAMI.ValidarAmbulatorioExistente(@Beneficio VARCHAR(14), @Fecha VARCHAR(10), @Asociacion numeric(10,0))
RETURNS VARCHAR(6)
AS  --SI YA EXISTE DEVUELVE EL MEDICO QUE TEIEN EL AMBULATORIO
BEGIN 
	 RETURN isnull((SELECT TOP 1 planilla_medico FROM PAMI.Planilla WHERE planilla_afiliado_beneficio = @Beneficio AND planilla_fecha = @Fecha AND planilla_asociacion = @Asociacion),'-1');
END
GO

ALTER FUNCTION PAMI.ValidarPracticaYaExisteEnAmbulatorio(@Beneficio VARCHAR(14), @Fecha VARCHAR(10), @Practica VARCHAR(10), @Asociacion numeric(10,0))
RETURNS int  -- 0 ya existe practica. 1 no existe practica
AS
BEGIN
	 RETURN isnull((SELECT TOP 1 0 FROM PAMI.Planilla WHERE planilla_afiliado_beneficio = @Beneficio AND planilla_fecha = @Fecha AND planilla_practica = @Practica AND planilla_asociacion = @Asociacion),1)
END
GO

alter PROCEDURE PAMI.InsertPlanilla_RetornarIDAmbulatorioExistente
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

alter FUNCTION PAMI.ObtenerHoraAmbulatorio(@Asociacion numeric(10,0), @Medico VARCHAR(6),@Fecha VARCHAR(10), @Hora VARCHAR(5))
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

