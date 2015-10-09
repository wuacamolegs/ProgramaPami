      
ALTER PROCEDURE PAMI.TraerListadoNomencladorConFiltros
   @AsociacionID numeric(10,0),
   @Codigo varchar(10),
   @Descripcion varchar(255),
   @Modulo numeric(5,0)
AS
BEGIN
		SELECT practica_codigo, practica_descripcion, cantidad_maxima, codigo_modulo
		FROM PAMI.Nomenclador
		WHERE	(practica_descripcion LIKE (CASE WHEN @Descripcion <> '' THEN '%' + @Descripcion + '%' ELSE practica_descripcion END))					
		AND		(practica_codigo LIKE (CASE WHEN @Codigo <> '' THEN '%' + @Codigo + '%' ELSE practica_codigo END))      
		AND		(@Modulo is null OR @Modulo = -1 OR CONVERT(VARCHAR(5), codigo_modulo) LIKE '%' + CONVERT(VARCHAR(5), @Modulo) + '%')
		AND		(@AsociacionID is null OR @AsociacionID = -1 OR 
				@Modulo IN(SELECT R.modulonomenclador FROM PAMI.REL_ModulosXPrestador R, Asociacion WHERE @AsociacionID = asociacion_id AND asociacion_cuit = R.cuit_prestador))
END
GO 
 
CREATE PROCEDURE PAMI.TraerListadoNomencladorPorCodigo
	@Codigo varchar(10)
AS
BEGIN
		SELECT practica_codigo, practica_descripcion, cantidad_maxima, codigo_modulo
		FROM PAMI.Nomenclador WHERE practica_codigo = @Codigo
END
GO

CREATE PROCEDURE PAMI.InsertNomenclador
   @Codigo varchar(10),
   @Descripcion varchar(255),
   @Modulo numeric(5,0),
   @CantMaxima numeric(3,0)
AS
BEGIN
	INSERT INTO PAMI.Nomenclador(practica_codigo, practica_descripcion, codigo_modulo, cantidad_maxima)
	VALUES (@Codigo, @Descripcion, @Modulo,@CantMaxima)
END
GO

CREATE PROCEDURE PAMI.UpdateNomenclador
   @Codigo varchar(10),
   @Descripcion varchar(255),
   @Modulo numeric(5,0),
   @CantMaxima numeric(3,0)
AS
BEGIN
	UPDATE PAMI.Nomenclador SET practica_descripcion = @Descripcion, codigo_modulo = @Modulo, cantidad_maxima = @CantMaxima WHERE practica_codigo = @Codigo
END
GO

CREATE PROCEDURE PAMI.DeleteNomenclador
	@Codigo varchar(10)
AS
BEGIN
	DELETE PAMI.Nomenclador WHERE practica_codigo = @Codigo
END
GO