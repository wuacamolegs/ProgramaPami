USE [PAMI]
GO


CREATE PROCEDURE PAMI.ValidarPlanillaPorFila
	@Fecha varchar(30),
	@Nombre varchar(50),
	@Beneficio numeric(15),
	@Diagnostico varchar(50),
	@Practica varchar(10),
	@Hora varchar(5)
AS
BEGIN
	DECLARE @Errores varchar(100);
	SET @Errores = '';
	IF(NOT EXISTS (SELECT * FROM PAMI.Afiliado WHERE afiliado_apellidoNombre LIKE '%' + @Nombre + '%'
											 AND afiliado_beneficio_id + afiliado_parentesco_id LIKE @Beneficio))
	BEGIN 
		SET @Errores = @Errores + ' Beneficio y/o Nombre no se corresponden\n'
	END
	
	IF(NOT EXISTS(SELECT * FROM PAMI.Nomenclador WHERE practica_codigo = @Practica))
	BEGIN
		SET @Errores = @Errores + ' Practica invalida\n'
	END
	IF(NOT EXISTS(SELECT * FROM PAMI.Diagnostico WHERE (diagnostico_codigo = @Diagnostico OR diagnostico_descripcion LIKE '%' + @Diagnostico + '%')))
	BEGIN 
		SET @Errores = @Errores + ' Diagnostico invalido\n'
	END
	
END
GO


CREATE PROCEDURE PAMI.ImportarPlanilla -- TERMINAR!!!!!!!!!!!!!!!!!!!!
	@Planilla TVP_Planilla READONLY,
	@Medico numeric(5,0),
	@Asociacion numeric(5,0),
	@Mes numeric(2,0),
	@Anio numeric(2,0)
AS
BEGIN TRANSACTION

	 DECLARE itemsPlanilla CURSOR FOR (SELECT tvp_fecha, tvp_nombre, tvp_beneficio, tvp_diagnostico, tvp_practicas, tvp_hora FROM @Planilla)
	 DECLARE @CantidadRegistros numeric(5,0); 
	 DECLARE @Fecha date;
	 DECLARE @Afiliado varchar(60);
	 DECLARE @BeneficioParentesco varchar(16)
	 DECLARE @Diagnostico varchar(10);
	 DECLARE @Practica varchar(50);
	 DECLARE @Hora time(5)
	
	 SET @CantidadRegistros = (SELECT COUNT(*) FROM @Planilla);
	
	 SELECT COUNT(*) FROM PAMI.Afiliado, PAMI.Diagnostico, PAMI.Nomenclador, PAMI.Profesional
	 WHERE afiliado_apellidoNombre LIKE ('%' + @Afiliado + '%') AND
		   afiliado_beneficio_id = SUBSTRING(@BeneficioParentesco,1,12) AND
		   afiliado_parentesco_id = SUBSTRING(@BeneficioParentesco,13,2) AND
		  (diagnostico_descripcion LIKE ('%' + @Diagnostico + '%') OR diagnostico_codigo = @Diagnostico) AND
		   practica_codigo = @Practica AND
		   profesional_codigo = @Medico
	 ;  
	 
	 OPEN itemsPlanilla;
	 

	 FETCH NEXT FROM itemsPlanilla INTO @Fecha, @Afiliado,@BeneficioParentesco, @Diagnostico, @Practica, @Hora;
	 
	 WHILE @@FETCH_STATUS = 0
	 BEGIN
	 
		 
	 /*
		WITH suscripciones AS (SELECT TOP (@CantidadSuscripciones) * 
							 FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE  transaccion_pendiente_cliente_id = @Cliente AND
																			  transaccion_pendiente_cuenta_id = @Cuenta
															   				  ORDER BY transaccion_pendiente_fecha)
		DELETE FROM suscripciones;
		
		UPDATE OOZMA_KAPPA.Cuenta SET cuenta_estado = 1, cuenta_pendiente_activacion = 0 WHERE cuenta_id = @Cuenta
		
		INSERT INTO OOZMA_KAPPA.Item_factura(item_factura_numero_cuenta,item_factura_numero_factura, item_factura_cantidad, item_factura_costo, item_factura_desc)
		VALUES (@Cuenta, @Factura, @CantidadSuscripciones, @Costo, 'Suscripciones por Apertura Cuenta'); */
		
		FETCH NEXT FROM itemsPlanilla INTO @Fecha, @Afiliado, @Diagnostico, @Practica, @Hora;
		
	END
	 	
	
 	DELETE FROM OOZMA_KAPPA.Transacciones_Pendientes WHERE transaccion_pendiente_cliente_id = @factura_cliente_id AND transaccion_pendiente_descr <> 'Suscripciones por Apertura Cuenta';
	 
	CLOSE itemsSuscripciones;
	DEALLOCATE itemsSuscripciones;
	
