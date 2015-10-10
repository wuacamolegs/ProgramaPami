ALTER PROCEDURE PAMI.TraerListadoPrestadorPorCuitYUsuario
	@Cuit varchar(15),
	@Usuario varchar(16)
AS
BEGIN
	SELECT TOP 1 A.asociacion_nombre AS prestador_nombre, P.prestador_cuit, B.c_boca_atencion, P.nro_sap, P.f_fecha_alta, P.D_denominacion as prestador_nombre_corto,
		   A.asociacion_usuario AS usuario_nombre, P.d_calle, P.d_puerta, P.d_piso, P.d_departamento, P.tipo_prestador, P.d_mail,A.padron
	FROM PAMI.Prestador P, PAMI.BocaAtencion B, PAMI.Asociacion A WHERE A.asociacion_cuit = P.prestador_cuit AND A.asociacion_id = P.asociacion_id AND B.cuit_prestador = P.prestador_cuit AND P.prestador_cuit = @Cuit AND A.asociacion_usuario = @Usuario
END
GO

ALTER PROCEDURE PAMI.InsertPrestador
      @Cuit varchar(15),
      @Nombre varchar(50),
      @BocaAtencion varchar(5),
      @Sap varchar(5),
      @FechaAlta varchar(10),
      @NombreCorto varchar(30),
      @Usuario varchar(16),
      @Calle varchar(30),
      @Numero numeric(5,0),
      @Piso numeric(2,0),
      @Depto varchar(5),
      @TipoPrestador varchar(1),
      @Mail varchar(50), 
      @AsocID numeric(10,0),
      @Padron numeric(1,0)
AS
BEGIN

	INSERT INTO PAMI.Asociacion(asociacion_nombre, asociacion_nombreCorto, asociacion_cuit,asociacion_usuario, padron)
	VALUES(@Nombre,@NombreCorto,@Cuit,@Usuario,@Padron)
	
	SET @AsocID = (SELECT asociacion_id FROM PAMI.Asociacion WHERE asociacion_cuit = @Cuit AND asociacion_usuario = @Usuario)

	INSERT INTO PAMI.Prestador(prestador_cuit, nro_sap, f_fecha_alta, D_denominacion, d_calle,d_puerta, d_piso, d_departamento, tipo_prestador,asociacion_id, d_mail)
	VALUES(@Cuit,@Sap,@FechaAlta,@NombreCorto,@Calle,Convert(varchar(5),@Numero),CONVERT(varchar(5),@Piso),@Depto,@TipoPrestador,@AsocID,@Mail);
	
	INSERT INTO PAMI.BocaAtencion(cuit_prestador,c_boca_atencion,sucursal,direccion_calle,direccion_numero,direccion_piso,direccion_depto,asociacion_id)
	VALUES(@Cuit,@BocaAtencion,'1',@Calle,Convert(varchar(5),@Numero),CONVERT(varchar(5),@Piso),@Depto, @AsocID);
	
END
GO

ALTER PROCEDURE PAMI.UpdatePrestador
	@Cuit varchar(15),
	@Nombre varchar(50),
	@BocaAtencion varchar(5),
	@Sap varchar(5),
	@FechaAlta varchar(10),
	@NombreCorto varchar(30),
	@Usuario varchar(16),
	@Calle varchar(30),
	@Numero numeric(5,0),
	@Piso numeric(2,0),
	@Depto varchar(5),
	@TipoPrestador varchar(1),
	@AsocID varchar(10),
	@Mail varchar(50),
	@Padron numeric(1,0)
AS
BEGIN
	UPDATE PAMI.Prestador SET nro_sap = @Sap, f_fecha_alta = @FechaAlta, D_denominacion = @NombreCorto, d_calle = @Calle, d_puerta = @Numero,
	d_piso = @Piso, d_departamento = @Depto, tipo_prestador = @TipoPrestador ,prestador_cuit = CONVERT(VARCHAR(15),@Cuit), d_mail = @Mail WHERE asociacion_id = @AsocID
	
	UPDATE PAMI.Asociacion SET asociacion_nombre = @Nombre, asociacion_nombreCorto = @NombreCorto, 
	asociacion_usuario = @Usuario,asociacion_cuit = @Cuit, padron = @Padron WHERE asociacion_id = @AsocID
	
	UPDATE PAMI.BocaAtencion SET c_boca_atencion = @BocaAtencion, direccion_calle = @Calle, direccion_depto = @Depto,
	direccion_numero = @Numero, direccion_piso = @Piso, cuit_prestador = @Cuit WHERE asociacion_id = @AsocID
END
GO

ALTER PROCEDURE PAMI.TraerListadoPrestadorPorAsociacionID
	@AsocID numeric(10,0)
AS
BEGIN
	SELECT A.asociacion_nombre as prestador_nombre, A.asociacion_nombreCorto as prestador_nombre_corto,prestador_cuit, nro_sap, f_fecha_alta, A.asociacion_usuario as usuario_nombre, P.d_calle, P.d_puerta, P.d_piso, P.d_departamento, P.tipo_prestador, B.c_boca_atencion, P.d_mail, A.padron
	FROM PAMI.Asociacion A, PAMI.Prestador P, PAMI.BocaAtencion B WHERE A.asociacion_id = @AsocID AND P.asociacion_id = @AsocID AND B.asociacion_id = @AsocID
END
GO	


ALTER PROCEDURE PAMI.DeletePrestador
	@AsocID numeric(10,0)
AS
BEGIN
	DELETE PAMI.BocaAtencion WHERE asociacion_id = @AsocID
	DELETE PAMI.Prestador WHERE asociacion_id = @AsocID
	DELETE PAMI.Asociacion WHERE asociacion_id = @AsocID
END


SELECT * FROM PAMI.Asociacion

UPDATE PAMI.Asociacion SET padron = 1 where asociacion_id = 5 OR asociacion_id = 7
