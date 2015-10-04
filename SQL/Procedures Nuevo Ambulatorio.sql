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
AS
BEGIN
	SELECT beneficio + parentesco as afiliado_beneficio, apellido_nombre as afiliado_nombre, documento_numero as afiliado_documento FROM PAMI.AfiliadosPami
END
GO

ALTER PROCEDURE PAMI.traerListadoPlanillaNomenclador
AS
BEGIN
	SELECT practica_codigo, practica_codigo + ' - ' + practica_descripcion as practica_descripcion FROM PAMI.Nomenclador
END
GO

ALTER PROCEDURE PAMI.TraerListadoAsociacionProfesionales
@AsociacionID numeric(10,0)
AS
BEGIN
	SELECT profesional_matricula, profesional_nombreCompleto as profesional_nombre FROM PAMI.REL_ProfesionalAsociacion, PAMI.Profesional WHERE profesional_matricula_nacional = profesional_matricula AND asociacion_id = @AsociacionID
END
GO

CREATE PROCEDURE PAMI.traerListadoAfiliadosConFiltrosPorPadronMedico
    @Nombre nvarchar(60) = null, 
    @Tipo_Dni varchar(3) = null,
    @Dni numeric(15,0) = null,
    @Beneficio numeric(12,0) = null,
    @Parentesco numeric(2,0) = null,
    @MedicoMatricula varchar(6)
AS 
BEGIN
    SELECT apellido_nombre, documento_tipo, documento_numero, beneficio, parentesco, fecha_nacimiento 
    FROM PAMI.AfiliadosPami, PAMI.REL_ProfesionalAsociacion
    WHERE	(apellido_nombre LIKE (CASE WHEN @Nombre <> '' THEN '%' + @Nombre + '%' ELSE apellido_nombre END))					
    AND		(documento_tipo LIKE (CASE WHEN @Tipo_Dni <> '' THEN '%' + @Tipo_Dni + '%' ELSE documento_tipo END))      
    AND		(@Dni is null OR @Dni = 0 OR CONVERT(VARCHAR(15), documento_numero) LIKE '%' + CONVERT(VARCHAR(15), @Dni) + '%')
    AND		(@Beneficio is null OR @Beneficio = 0 OR CONVERT(VARCHAR(12), beneficio) LIKE '%' + CONVERT(VARCHAR(15), @Beneficio) + '%')
    AND		(@Parentesco is null OR @Parentesco = 0 OR CONVERT(VARCHAR(2), parentesco) LIKE '%' + CONVERT(VARCHAR(2), @Parentesco) + '%')
    AND		(profesional_matricula = @MedicoMatricula)
    AND		(asociacion_id = padron_codigo)
END
GO


UPDATE  PAMI.AfiliadosPami SET padron_codigo = 1 WHERE apellido_nombre = 'flor'

select * from PAMI.REL_ProfesionalAsociacion

select * from PAMI.Profesional WHERE profesional_matricula_nacional = 9