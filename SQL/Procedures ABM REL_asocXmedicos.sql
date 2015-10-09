ALTER PROCEDURE PAMI.TraerListadoAsociacionProfesionalesSeleccion
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

ALTER PROCEDURE PAMI.TraerListadoAsociacionProfesionalesSeleccion
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

ALTER PROCEDURE PAMI.TraerListadoAsociacionProfesionalesSeleccion
@AsociacionID numeric(10,0)
AS
BEGIN
	SELECT PAMI.ProfesionalPerteneceAAsociacion(@AsociacionID,profesional_matricula_nacional) as Estado, profesional_matricula_nacional as matricula, profesional_nombreCompleto as medico FROM PAMI.Profesional ORDER BY profesional_nombreCompleto
END
GO


ALTER PROCEDURE PAMI.UpdateAsociacion_REL_Profesionales
	@AsociacionID numeric(10,0),
	@Medicos TVP_Profesionales READONLY
AS
BEGIN
	DELETE FROM PAMI.REL_ProfesionalAsociacion WHERE asociacion_id = @AsociacionID
	INSERT INTO PAMI.REL_ProfesionalAsociacion(asociacion_id,profesional_matricula) SELECT @AsociacionID, tvp_matricula FROM @Medicos
END
GO

