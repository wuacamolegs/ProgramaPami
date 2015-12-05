--TRIGGERS PLANILLA--

CREATE TRIGGER PAMI.TR_arreglar_fechas
ON PAMI.Planilla
AFTER INSERT, UPDATE
AS
BEGIN
SET NOCOUNT ON
	UPDATE PAMI.Planilla SET planilla_fecha = '0' + planilla_fecha WHERE LEN(planilla_fecha) = 9 AND planilla_ambulatorio_codigo IN(SELECT I.planilla_ambulatorio_codigo FROM INSERTED I)
END
GO

CREATE TRIGGER PAMI.TR_DeleteAmbulatorioExistenteAfterDeleteAmbulatorio
ON PAMI.Planilla
AFTER DELETE
AS
BEGIN
SET NOCOUNT ON
	DELETE PAMI.AmbulatoriosExistentes WHERE ambulatorio_id IN(SELECT planilla_ambulatorio_codigo FROM DELETED)
END
GO

CREATE TRIGGER PAMI.TR_DeleteProfesionalAsociacionAfterDeleteProfesional
ON PAMI.Profesional
AFTER DELETE
AS
BEGIN
SET NOCOUNT ON
	DELETE PAMI.REL_ProfesionalAsociacion WHERE profesional_matricula IN(SELECT profesional_matricula_nacional FROM DELETED)
END
GO

