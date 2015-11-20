
ALTER PROCEDURE PAMI.TraerListadoProfesionalContadorPracticas
	@MedicoID VARCHAR(6),
	@AsociacionID numeric(10,0),
	@Mes VARCHAR(2),
	@Anio VARCHAR(4)
AS
BEGIN
	IF(LEN(@Mes) = 1)
	BEGIN
	 SET @Mes = '0' + @Mes
	END
	
	SELECT planilla_practica, COUNT(planilla_practica) as Cantidad FROM PAMI.Planilla WHERE SUBSTRING(planilla_fecha,4,2) = @Mes AND SUBSTRING(planilla_fecha,7,4) = @Anio 
	AND planilla_asociacion = @AsociacionID AND planilla_medico = @MedicoID
	GROUP BY planilla_practica
	UNION
	SELECT 'TOTAL' as planilla_practica, COUNT(planilla_practica) as Cantidad FROM PAMI.Planilla WHERE SUBSTRING(planilla_fecha,4,2) = @Mes AND SUBSTRING(planilla_fecha,7,4) = @Anio 
	AND planilla_asociacion = @AsociacionID AND planilla_medico = @MedicoID 
END
GO
