
ALTER PROCEDURE PAMI.TraerListadoProfesionalContadorPracticas
	@Matricula VARCHAR(6),
	@Asociacion numeric(10,0),
	@Mes VARCHAR(2),
	@Anio VARCHAR(4)
AS
BEGIN
	IF(LEN(@Mes) = 1)
	BEGIN
	 SET @Mes = '0' + @Mes
	END
	
	SELECT planilla_practica, COUNT(planilla_practica) as Cantidad FROM PAMI.Planilla WHERE SUBSTRING(planilla_fecha,4,2) = @Mes AND SUBSTRING(planilla_fecha,7,4) = @Anio 
	AND planilla_asociacion = @Asociacion AND planilla_medico = @Matricula
	GROUP BY planilla_practica
END
GO

