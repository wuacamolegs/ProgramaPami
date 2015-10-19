

ALTER PROCEDURE PAMI.TraerListadoProfesionalPorFiltros 
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

ALTER PROCEDURE PAMI.TraerListadoProfesionalPorMatricula
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