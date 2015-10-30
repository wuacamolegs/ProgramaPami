--TRIGGERS PLANILLA--

CREATE TRIGGER PAMI.TR_arreglar_fechas
ON PAMI.Planilla
AFTER INSERT, UPDATE
AS
BEGIN
SET NOCOUNT ON
	UPDATE PAMI.Planilla SET planilla_fecha = '0' + planilla_fecha WHERE LEN(planilla_fecha) = 9
END
GO

