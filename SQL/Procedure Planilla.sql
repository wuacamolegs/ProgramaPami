use [PAMI]
GO

CREATE PROCEDURE PAMI.ArmarAmbulatorios
	@Planilla TVP_Planilla READONLY,
	@Asociacion numeric(10,0),
	@Medico varchar(6),
	@Periodo varchar(5) -- mm-yy
AS
BEGIN	
	 DECLARE @PlanillaOrdenada TVP_Planilla
	 INSERT INTO @PlanillaOrdenada SELECT * FROM @Planilla ORDER BY tvp_fecha,tvp_beneficio
	 
	 DECLARE itemsPlanilla CURSOR FOR (SELECT tvp_fecha, tvp_nombre, tvp_beneficio, tvp_diagnostico, tvp_practicas, tvp_hora FROM @PlanillaOrdenada)

	 DECLARE @Fecha varchar(10);
	 DECLARE @Afiliado varchar(60);
	 DECLARE @BeneficioParentesco varchar(16);
	 DECLARE @Diagnostico varchar(10);
	 DECLARE @Practica varchar(50);
	 DECLARE @Hora varchar(5);
	 
	 DECLARE @AmbulatorioExistente numeric(10,0);
	
	 --TODO Hacer que Ambulatorio id sea autonumerico
	 SET @AmbulatorioExistente = PAMI.ValidarAmbulatorioExistente @Fecha @BeneficioParentesco @Medico;
	
	 OPEN itemsPlanilla;
	 
	 FETCH NEXT FROM itemsPlanilla INTO @Fecha, @Afiliado,@BeneficioParentesco, @Diagnostico, @Practica, @Hora;
	 
	 WHILE @@FETCH_STATUS = 0
	 BEGIN
	 
		
		FETCH NEXT FROM itemsPlanilla INTO @Fecha, @Afiliado, @Diagnostico, @Practica, @Hora;
		
	END
	 	
	
 	DELETE FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @factura_cliente_id AND transaccion_pendiente_descr <> 'Suscripciones por Apertura Cuenta';
	 
	CLOSE itemsSuscripciones;
	DEALLOCATE itemsSuscripciones;
	
END

GO

CREATE FUNCTION PAMI.ValidarAmbulatorioExistente(
	@Fecha varchar(10),
	@Beneficio varchar(16),
	@Medico varchar(6))
	RETURNS numeric(10,0)
AS
BEGIN 
	DECLARE @AmbulatorioExistente numeric(18,0) = -1;
	
	SELECT TOP 1 @AmbulatorioExistente = planilla_ambulatorio_codigo FROM PAMI.Planilla WHERE c_profesional = @Medico AND
																				(id_beneficio + id_parentesco = @Beneficio OR 
																				 id_beneficio + id_parentesco = (SELECT TOP 1 afiliado_beneficio + afiliado_parentesco FROM PAMI.AfiliadosPami WHERE afiliado_documento = @Beneficio)) AND
																				 f_fecha_atencion = @Fecha												 
RETURN @AmbulatorioExistente

END