CREATE PROCEDURE PAMI.TraerListadoDiagnosticosConFiltros
	@Codigo VARCHAR(10),
	@AsocID VARCHAR(15)
AS
BEGIN
	SET @AsocID = (SELECT PAMI.DevolverCuitAsoc(@AsocID))

	SELECT D.diagnostico_codigo , D.diagnostico_descripcion
	FROM PAMI.Diagnostico D WHERE (D.diagnostico_codigo LIKE (CASE WHEN @Codigo <> '' THEN '%' + @Codigo + '%' ELSE D.diagnostico_codigo END) AND
														D.asociacion_cuit = @AsocID)
END
GO

CREATE PROCEDURE PAMI.TraerListadoDiagnosticosPorCodigo
	@Codigo varchar(10)
AS
BEGIN
	SELECT diagnostico_codigo, diagnostico_descripcion, CONVERT(NUMERIC(15),PAMI.DevolverIDAsoc(asociacion_cuit)) FROM PAMI.Diagnostico  WHERE diagnostico_codigo = @Codigo
END
GO

CREATE PROCEDURE PAMI.DeleteDiagnosticos
	@Codigo varchar(10)
AS
BEGIN
	DELETE PAMI.Diagnostico WHERE diagnostico_codigo = @Codigo;
END
GO

CREATE PROCEDURE PAMI.InsertDiagnosticos
	@Codigo VARCHAR(10),
	@AsocID VARCHAR(15),
	@Descripcion VARCHAR(50)
AS
BEGIN
	DELETE PAMI.Diagnostico WHERE diagnostico_codigo = @Codigo
	INSERT INTO PAMI.Diagnostico(diagnostico_codigo,diagnostico_descripcion,asociacion_cuit)
	SELECT @Codigo,@Descripcion, PAMI.DevolverCuitAsoc(@AsocID)
END
GO

CREATE PROCEDURE PAMI.UpdateDiagnosticos
	@Codigo VARCHAR(10),
	@AsocID VARCHAR(15),
	@Descripcion VARCHAR(50)
AS
BEGIN
	UPDATE PAMI.Diagnostico SET diagnostico_descripcion = @Descripcion, asociacion_cuit = PAMI.DevolverCuitAsoc(@AsocID) WHERE diagnostico_codigo = @Codigo
END
GO