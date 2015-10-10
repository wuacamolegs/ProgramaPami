USE [PAMI]
GO


ALTER PROCEDURE PAMI.TraerListadoPlanillaTablasParaValidar
	@AsociacionID numeric(10,0),
	@MedicoID varchar(6)
AS
BEGIN
	SELECT beneficio as Beneficio, documento_numero as Documento FROM PAMI.AfiliadosPami, PAMI.Asociacion WHERE asociacion_id = @AsociacionID AND padron = padron_codigo
	SELECT diagnostico_codigo as Diagnostico_Codigo, diagnostico_descripcion as Diagnostico_Descripcion FROM PAMI.Diagnostico
	SELECT practica_codigo as Practica FROM PAMI.Nomenclador
	SELECT planilla_fecha as Fecha, planilla_hora as Hora FROM PAMI.Planilla WHERE planilla_medico = @MedicoID
END 
GO


ALTER PROCEDURE PAMI.InsertPlanilla_RetornarID
	@Asociacion numeric(10,0),
	@Medico varchar(6),
	@Mes varchar(2),
	@Anio varchar(4),
	--Datos ambulatorio
	@Fecha varchar(30),
	@Nombre varchar(50),
	@Beneficio varchar(15),
	@Diagnostico varchar(50),
	@Practica varchar(10),
	@Hora varchar(5)
AS
BEGIN
	
	DECLARE @FuncionResult numeric(18,0);

	SET @Beneficio = (SELECT TOP 1 beneficio + parentesco FROM PAMI.AfiliadosPami WHERE beneficio + parentesco = @Beneficio OR documento_numero = @Beneficio)
	SELECT @FuncionResult = PAMI.ValidarAmbulatorioExistente( @Medico, @Beneficio, @Fecha);
	
	IF(@FuncionResult > 0)
	BEGIN
	SELECT planilla_medico as MedicoID, profesional_nombreCompleto as Medico,
			planilla_afiliado_beneficio as Beneficio, @Practica as Practica,@Fecha as Fecha,@Hora as Hora
	FROM PAMI.Planilla, PAMI.Profesional WHERE planilla_medico = profesional_matricula_nacional AND planilla_medico <> @Medico AND planilla_afiliado_beneficio = @Beneficio AND planilla_fecha = @Fecha	
	END
	IF(@FuncionResult = 0)
	BEGIN 
		INSERT INTO PAMI.Planilla (planilla_asociacion,planilla_medico,planilla_fecha,planilla_afiliado_beneficio,planilla_diagnostico,planilla_practica,planilla_hora)
		(SELECT @Asociacion, @Medico, @Fecha, 
		(SELECT beneficio + parentesco FROM PAMI.AfiliadosPami WHERE beneficio + parentesco = @Beneficio OR documento_numero = @Beneficio),
		(SELECT diagnostico_codigo FROM PAMI.Diagnostico WHERE diagnostico_codigo = @Diagnostico OR diagnostico_descripcion like '%' + @Diagnostico + '%' COLLATE Modern_Spanish_CI_AI),
		@Practica, @Hora)
	END
END
GO

ALTER FUNCTION PAMI.ValidarAmbulatorioExistente(@Medico VARCHAR(6), @Beneficio VARCHAR(14), @Fecha VARCHAR(10))
RETURNS int
AS
BEGIN 
	DECLARE @Return int;
	SET @Return = (SELECT COUNT(planilla_fecha) FROM PAMI.Planilla WHERE planilla_medico <> @Medico AND planilla_afiliado_beneficio = @Beneficio AND planilla_fecha = @Fecha)
	RETURN @Return
END
GO

