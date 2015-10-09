USE [PAMI]
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

ALTER PROCEDURE PAMI.TraerListadoPlanillaTablasParaValidar
	@AsociacionID numeric(10,0),
	@MedicoID varchar(6)
AS
BEGIN
	SELECT beneficio as Beneficio, documento_numero as Documento FROM PAMI.AfiliadosPami
	SELECT diagnostico_codigo as Diagnostico_Codigo, diagnostico_descripcion as Diagnostico_Descripcion FROM PAMI.Diagnostico
	SELECT practica_codigo as Practica FROM PAMI.Nomenclador
	SELECT planilla_fecha as Fecha, planilla_hora as Hora FROM PAMI.Planilla WHERE planilla_medico = @MedicoID
END 
GO


ALTER PROCEDURE PAMI.InsertPlanilla_RetornarID
	@Asociacion numeric(10,0),
	@Medico varchar(6),
	@Mes varchar(2),
	@Anio varchar(4),
	--Datos ambulatorio
	@Fecha varchar(30),
	@Nombre varchar(50),
	@Beneficio varchar(15),
	@Diagnostico varchar(50),
	@Practica varchar(10),
	@Hora varchar(5)
AS
BEGIN
	
	DECLARE @FuncionResult numeric(18,0);

	SET @Beneficio = (SELECT TOP 1 beneficio + parentesco FROM PAMI.AfiliadosPami WHERE beneficio + parentesco = @Beneficio OR documento_numero = @Beneficio)
	SELECT @FuncionResult = PAMI.ValidarAmbulatorioExistente( @Medico, @Beneficio, @Fecha);
	
	IF(@FuncionResult > 0)
	BEGIN
	SELECT planilla_medico as MedicoID, profesional_nombreCompleto as Medico,
			planilla_afiliado_beneficio as Beneficio, @Practica as Practica,@Fecha as Fecha,@Hora as Hora
	FROM PAMI.Planilla, PAMI.Profesional WHERE planilla_medico = profesional_matricula_nacional AND planilla_medico <> @Medico AND planilla_afiliado_beneficio = @Beneficio AND planilla_fecha = @Fecha	
	END
	IF(@FuncionResult = 0)
	BEGIN 
		INSERT INTO PAMI.Planilla (planilla_asociacion,planilla_medico,planilla_fecha,planilla_afiliado_beneficio,planilla_diagnostico,planilla_practica,planilla_hora)
		(SELECT @Asociacion, @Medico, @Fecha, 
		(SELECT beneficio + parentesco FROM PAMI.AfiliadosPami WHERE beneficio + parentesco = @Beneficio OR documento_numero = @Beneficio),
		(SELECT diagnostico_codigo FROM PAMI.Diagnostico WHERE diagnostico_codigo = @Diagnostico OR diagnostico_descripcion like '%' + @Diagnostico + '%' COLLATE Modern_Spanish_CI_AI),
		@Practica, @Hora)
	END
END
GO

SELECT PAMI.ValidarAmbulatorioExistente('3','1506200138050', '7/08/2015')
GO

ALTER FUNCTION PAMI.ValidarAmbulatorioExistente(@Medico VARCHAR(6), @Beneficio VARCHAR(14), @Fecha VARCHAR(10))
RETURNS int
AS
BEGIN 
	DECLARE @Return int;
	SET @Return = (SELECT COUNT(planilla_fecha) FROM PAMI.Planilla WHERE planilla_medico <> @Medico AND planilla_afiliado_beneficio = @Beneficio AND planilla_fecha = @Fecha)
	RETURN @Return
END
GO

truncate table PAMI.Planilla





/*

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
	
*/