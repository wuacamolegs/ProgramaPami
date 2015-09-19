USE [PAMI]
GO

ALTER PROCEDURE PAMI.traerListadoAfiliadosConFiltros 
    @Nombre nvarchar(60) = null, 
    @TipoDni varchar(3) = null,
    @Dni numeric(15,0) = null,
    @Beneficio numeric(12,0) = null,
    @Parentesco numeric(2,0) = null
AS 
BEGIN
    SELECT afiliado_apellidoNombre, afiliado_tipo_documento, afiliado_numero_documento, afiliado_beneficio_id, afiliado_parentesco_id, afiliado_fecha_nacimiento 
    FROM PAMI.AfiliadosPami
    WHERE	(afiliado_apellidoNombre LIKE (CASE WHEN @Nombre <> '' THEN '%' + @Nombre + '%' ELSE afiliado_apellidoNombre END))					
    AND		(afiliado_tipo_documento LIKE (CASE WHEN @TipoDni <> '' THEN '%' + @TipoDni + '%' ELSE afiliado_tipo_documento END))      
    AND		(@Dni is null OR @Dni = 0 OR CONVERT(VARCHAR(15), afiliado_numero_documento) LIKE '%' + CONVERT(VARCHAR(15), @Dni) + '%')
    AND		(@Beneficio is null OR @Beneficio = 0 OR CONVERT(VARCHAR(12), afiliado_beneficio_id) LIKE '%' + CONVERT(VARCHAR(15), @Beneficio) + '%')
    AND		(@Parentesco is null OR @Parentesco = 0 OR CONVERT(VARCHAR(2), afiliado_parentesco_id) LIKE '%' + CONVERT(VARCHAR(2), @Parentesco) + '%')
END
GO

ALTER PROCEDURE PAMI.TraerListadoAfiliadosPorBeneficio
	@Beneficio numeric(12,0),
	@Parentesco numeric(2,0)
AS
BEGIN
	SELECT TOP 1 afiliado_apellidoNombre, afiliado_tipo_documento, afiliado_numero_documento, afiliado_beneficio_id, afiliado_parentesco_id, afiliado_fecha_nacimiento, afiliado_sexo 
	FROM PAMI.AfiliadosPami WHERE afiliado_beneficio_id = @Beneficio AND afiliado_parentesco_id = @Parentesco
END
GO

alter PROCEDURE PAMI.InsertAfiliado
	@Nombre nvarchar(60),
	@Beneficio numeric(12,0),
	@Parentesco numeric(2,0),
	@TipoDni varchar(3),
	@Dni numeric(15,0),
	@Sexo varchar(1),
	@FechaNac varchar(10)
AS
BEGIN
	INSERT INTO PAMI.AfiliadosPami (afiliado_apellidoNombre,afiliado_beneficio_id, afiliado_parentesco_id, afiliado_tipo_documento, afiliado_numero_documento, afiliado_fecha_nacimiento, afiliado_sexo)
	VALUES(@Nombre,@Beneficio,@Parentesco,@TipoDni,@Dni,CONVERT(varchar(10),CONVERT(datetime, @FechaNac,103),103),@Sexo)
END
GO

alter PROCEDURE PAMI.UpdateAfiliado
	@Nombre nvarchar(60),
	@Beneficio numeric(12,0),
	@Parentesco numeric(2,0),
	@TipoDni varchar(3),
	@Dni numeric(15,0),
	@Sexo varchar(1),
	@FechaNac varchar(10)
AS
BEGIN
	UPDATE PAMI.AfiliadosPami SET 
	afiliado_apellidoNombre = @Nombre,
	afiliado_tipo_documento = @TipoDni,
	afiliado_numero_documento = @Dni,
	afiliado_fecha_nacimiento = CONVERT(varchar(10),CONVERT(datetime, @FechaNac,103),103),
	afiliado_sexo = @Sexo
	WHERE afiliado_beneficio_id = @Beneficio AND afiliado_parentesco_id =  @Parentesco
END
GO

CREATE PROCEDURE PAMI.DeleteAfiliado
	@Beneficio numeric(12,0),
	@Parentesco numeric(2,0)
AS
BEGIN
	DELETE PAMI.AfiliadosPami WHERE afiliado_beneficio_id = @Beneficio AND afiliado_parentesco_id = @Parentesco
END