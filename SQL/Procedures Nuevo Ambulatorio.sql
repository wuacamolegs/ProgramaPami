CREATE PROCEDURE PAMI.traerListadoAsociacionCompleto
AS
BEGIN
	SELECT asociacion_id, asociacion_nombre FROM PAMI.Asociacion
END
GO

CREATE PROCEDURE PAMI.traerListadoDiagnosticosCompleto
AS
BEGIN
	SELECT diagnostico_codigo, diagnostico_descripcion FROM PAMI.Diagnostico
END
GO

ALTER PROCEDURE PAMI.TraerListadoAfiliadosConBeneficioNombreDocumento
	@AsocID numeric(10,0)
AS
BEGIN
	SELECT beneficio + parentesco as afiliado_beneficio, apellido_nombre as afiliado_nombre, documento_numero as afiliado_documento FROM PAMI.AfiliadosPami AF, PAMI.Asociacion A WHERE A.padron = AF.padron_codigo AND asociacion_id = @AsocID
END
GO

ALTER PROCEDURE PAMI.TraerListadoAsociacionProfesionales
	@AsociacionID numeric(10,0)
AS
BEGIN
	SELECT profesional_matricula, profesional_nombreCompleto as profesional_nombre FROM PAMI.REL_ProfesionalAsociacion, PAMI.Profesional WHERE profesional_matricula_nacional = profesional_matricula AND asociacion_id = @AsociacionID
END
GO


ALTER PROCEDURE PAMI.traerListadoAfiliadosConFiltrosPorPadronAsociacion
    @Nombre varchar(60) = null, 
    @Dni numeric(15,0) = null,
    @Beneficio varchar(14) = null,
    @AsocID numeric(10,0)
AS 
BEGIN
    SELECT apellido_nombre, documento_tipo, documento_numero, beneficio, parentesco, fecha_nacimiento 
    FROM PAMI.AfiliadosPami AF, PAMI.Asociacion A
    WHERE	(apellido_nombre LIKE (CASE WHEN @Nombre <> '' THEN '%' + @Nombre + '%' ELSE apellido_nombre END))					
    AND		(@Dni is null OR @Dni = 0 OR CONVERT(VARCHAR(15), documento_numero) LIKE '%' + CONVERT(VARCHAR(15), @Dni) + '%')
    AND		(@Beneficio is null OR @Beneficio = 0 OR CONVERT(VARCHAR(12), beneficio + parentesco) LIKE '%' + CONVERT(VARCHAR(15), @Beneficio) + '%')
    AND		(A.asociacion_id = @AsocID)
    AND		(AF.padron_codigo = A.padron)
END
GO

ALTER PROCEDURE PAMI.TraerListadoPlanillaNomencladorPorAsociacion
    @AsocID numeric(10,0)
AS
BEGIN
	SELECT practica_codigo, practica_codigo + ' - ' + practica_descripcion as practica_descripcion FROM PAMI.Nomenclador N, PAMI.REL_ModulosXPrestador R, PAMI.Asociacion A WHERE N.codigo_modulo = R.modulonomenclador AND R.cuit_prestador = A.asociacion_cuit AND A.asociacion_id = @AsocID
END
GO


ALTER PROCEDURE PAMI.TraerListadoDiagnosticosPorAsocID
	@AsocID numeric(10,0)
AS
BEGIN
	SELECT diagnostico_codigo, diagnostico_codigo + ' - ' + diagnostico_descripcion as diagnostico_descripcion FROM PAMI.Diagnostico D, PAMI.Asociacion A WHERE A.asociacion_id = @AsocID AND A.asociacion_cuit = D.asociacion_cuit
END
GO


CREATE PROCEDURE PAMI.ValidarAmbulatorioExistenteEnPlanilla
     @Fecha VARCHAR(10),
     @Medico VARCHAR(6),
     @Afiliado VARCHAR(14),
     @Asociacion numeric(10,0)
AS
BEGIN
	SELECT planilla_medico, planilla_practica, planilla_hora, planilla_diagnostico FROM PAMI.Planilla WHERE planilla_afiliado_beneficio = @Afiliado AND planilla_fecha = @Fecha AND planilla_asociacion = @Asociacion
END
GO
