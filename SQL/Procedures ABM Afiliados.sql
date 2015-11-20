USE [PAMI]
GO

ALTER PROCEDURE PAMI.TraerListadoAfiliadosConFiltros 
    @Nombre varchar(60) = '', 
    @Tipo_Dni varchar(3) = '',
    @Dni varchar(15) = '',
    @Beneficio varchar(12) = '',
    @Parentesco varchar(2) = ''
AS 
BEGIN
    SELECT apellido_nombre, documento_tipo, documento_numero, beneficio, parentesco, fecha_nacimiento 
    FROM PAMI.AfiliadosPami
    WHERE	(apellido_nombre LIKE (CASE WHEN @Nombre <> '' THEN '%' + @Nombre + '%' ELSE apellido_nombre END))					
    AND		(documento_tipo LIKE (CASE WHEN @Tipo_Dni <> '' THEN '%' + @Tipo_Dni + '%' ELSE documento_tipo END))     
    AND	    (CONVERT(VARCHAR(15), documento_numero) LIKE (CASE WHEN @Dni <> '' THEN '%' + @Dni + '%' ELSE documento_numero END))
    AND		(beneficio LIKE (CASE WHEN @Beneficio <> '' THEN '%' + @Beneficio + '%' ELSE beneficio END))
    AND		(CONVERT(VARCHAR(2), parentesco) LIKE (CASE WHEN @Parentesco <> '' THEN '%' + @Parentesco + '%' ELSE parentesco END))
    END
GO

ALTER PROCEDURE PAMI.TraerListadoAfiliadosPorBeneficio
	@Beneficio varchar(12),
	@Parentesco varchar(2)
AS
BEGIN
	SELECT TOP 1 apellido_nombre, documento_tipo, documento_numero, beneficio, parentesco, fecha_nacimiento, sexo, padron_codigo
	FROM PAMI.AfiliadosPami WHERE beneficio = @Beneficio AND parentesco = @Parentesco
END
GO

ALTER PROCEDURE PAMI.InsertAfiliado
	@Nombre nvarchar(60),
	@Beneficio varchar(12),
	@Parentesco varchar(2),
	@Tipo_Dni varchar(3),
	@Dni numeric(15,0),
	@Sexo varchar(1),
	@FechaNac varchar(10),
	@Padron numeric(1,0)
AS
BEGIN
	INSERT INTO PAMI.AfiliadosPami (apellido_nombre,beneficio, parentesco, documento_tipo, documento_numero, fecha_nacimiento, sexo, padron_codigo)
	VALUES(@Nombre,@Beneficio,@Parentesco,@Tipo_Dni,@Dni,CONVERT(varchar(10),CONVERT(datetime, @FechaNac,103),103),@Sexo,@Padron)
END
GO

ALTER PROCEDURE PAMI.UpdateAfiliado
	@Nombre nvarchar(60),
	@Beneficio varchar(12),
	@Parentesco varchar(2),
	@Tipo_Dni varchar(3),
	@Dni numeric(15,0),
	@Sexo varchar(1),
	@FechaNac varchar(10),
	@Padron numeric(10,0)
AS
BEGIN
	UPDATE PAMI.AfiliadosPami SET 
	apellido_nombre = @Nombre,
	documento_tipo = @Tipo_Dni,
	documento_numero = @Dni,
	fecha_nacimiento = CONVERT(varchar(10),CONVERT(datetime, @FechaNac,103),103),
	sexo = @Sexo,
	padron_codigo = @Padron
	WHERE beneficio = @Beneficio AND parentesco =  @Parentesco
END
GO

ALTER PROCEDURE PAMI.DeleteAfiliado
	@Beneficio varchar(12),
	@Parentesco varchar(2)
AS
BEGIN
	DELETE PAMI.AfiliadosPami WHERE beneficio = @Beneficio AND parentesco = @Parentesco
END

