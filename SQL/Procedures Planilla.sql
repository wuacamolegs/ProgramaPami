USE [PAMI]
GO

CREATE PROCEDURE PAMI.ImportarPadron
	@ruta nvarchar(200)
AS
	BEGIN
	DECLARE @comando nvarchar(400);
	SET @comando = 'BULK INSERT PAMI.padron FROM ''' + @ruta + ''' WITH (ROWTERMINATOR=''\n'')';
	EXEC sp_executesql @comando;
	EXEC PAMI.ActualizarPadronAfiliados;
	END
GO				

CREATE PROCEDURE PAMI.ActualizarPadronAfiliados
AS
	BEGIN TRANSACTION
		--TRUNCATE TABLE PAMI.Afiliado
		INSERT INTO PAMI.AfiliadosPami(beneficio,parentesco,apellido_nombre,fecha_nacimiento, documento_tipo, documento_numero,sexo)
		(SELECT 
			CONVERT(varchar(12),substring(padron,5,12)),
			CONVERT(numeric(2),substring(padron,17,2)),
			substring(padron,32,40),
			substring(padron,72,4) + '-' + substring(padron,76,2) + '-' + substring(padron,78,2),
			substring(padron,80,3),
			CONVERT(numeric(15,0),substring(padron,83,8)),
			substring(padron,98,1)
		 FROM PAMI.padron);
		 TRUNCATE TABLE PAMI.padron;
	COMMIT
GO


CREATE PROCEDURE PAMI.traerListadoAfiliadosConFiltros 
    @Nombre nvarchar(30) = null, 
    @Apellido nvarchar(30) = null,
    @Tipo_Dni varchar(3) = null,
    @Dni numeric(15,0) = null,
    @Beneficio numeric(12,0) = null,
    @Parentesco numeric(2,0) = null
AS 
BEGIN
    SELECT apellido_nombre, documento_tipo, documento_numero, beneficio, parentesco, fecha_nacimiento 
    FROM PAMI.AfiliadosPami
    WHERE	
           (apellido_nombre LIKE (CASE WHEN @Nombre <> '' THEN '%' + @Nombre + '%' ELSE apellido_nombre END)
	OR   	apellido_nombre LIKE (CASE WHEN @Apellido <> '' THEN '%' + @Apellido + '%' ELSE apellido_nombre END))					
    AND		documento_tipo LIKE (CASE WHEN @Tipo_Dni <> '' THEN '%' + @Tipo_Dni + '%' ELSE documento_tipo END)      
    AND		(@Dni is null OR @Dni = 0 OR CONVERT(VARCHAR(15), documento_numero) LIKE '%' + CONVERT(VARCHAR(15), @Dni) + '%')
    AND		(@Beneficio is null OR @Beneficio = 0 OR CONVERT(VARCHAR(12), beneficio) LIKE '%' + CONVERT(VARCHAR(15), @Beneficio) + '%')
    AND		(@Parentesco is null OR @Parentesco = 0 OR CONVERT(VARCHAR(2), parentesco) LIKE '%' + CONVERT(VARCHAR(2), @Parentesco) + '%')
END
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
	IF(NOT EXISTS (SELECT * FROM PAMI.AfiliadosPami WHERE apellido_nombre LIKE '%' + @Nombre + '%'
											 AND beneficio + parentesco LIKE @Beneficio))
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
	 WHERE apellido_nombre LIKE ('%' + @Afiliado + '%') AND
		   beneficio = SUBSTRING(@BeneficioParentesco,1,12) AND
		   parentesco = SUBSTRING(@BeneficioParentesco,13,2) AND
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
	
