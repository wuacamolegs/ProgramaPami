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
