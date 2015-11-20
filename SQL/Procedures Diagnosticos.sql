CREATE PROCEDURE PAMI.TraerListadoDiagnosticosConFiltros
	@Codigo varchar(10)
AS
BEGIN
	SELECT D.diagnostico_codigo , D.diagnostico_descripcion
	FROM PAMI.Diagnostico D WHERE (D.diagnostico_codigo LIKE (CASE WHEN @Codigo <> '' THEN '%' + @Codigo + '%' ELSE D.diagnostico_codigo END))
END
GO
	