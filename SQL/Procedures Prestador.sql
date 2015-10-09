CREATE PROCEDURE PAMI.TraerListadoPrestadorPorCuitYUsuario
	@Cuit varchar(8),
	@Usuario varchar(16)
AS
BEGIN
	SELECT TOP 1 A.asociacion_nombre AS prestador_nombre, P.prestador_cuit, B.c_boca_atencion, P.nro_sap, P.f_fecha_alta, P.D_denominacion as prestador_nombre_corto,
		   P.prestador_usuario, P.d_calle, P.d_puerta, P.d_piso, P.d_departamento, P.tipo_prestador
	FROM PAMI.Prestador P, PAMI.BocaAtencion B, PAMI.Asociacion A WHERE A.asociacion_cuit = P.prestador_cuit AND A.asociacion_usuario = P.prestador_usuario AND B.cuit_prestador = P.prestador_cuit AND P.prestador_cuit = @Cuit AND P.prestador_usuario= @Usuario
END
GO

ALTER PROCEDURE PAMI.InsertPrestador
      @Cuit varchar(8),
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
      @TipoPrestador varchar(1)
AS
BEGIN
	INSERT INTO PAMI.Prestador(prestador_cuit, nro_sap, f_fecha_alta, D_denominacion, d_calle,d_puerta, d_piso, d_departamento, tipo_prestador,prestador_usuario)
	VALUES(@Cuit,@Sap,@FechaAlta,@NombreCorto,@Calle,Convert(varchar(5),@Numero),CONVERT(varchar(5),@Piso),@Depto,@TipoPrestador,@Usuario);
	
	INSERT INTO PAMI.BocaAtencion(cuit_prestador,c_boca_atencion,sucursal,direccion_calle,direccion_numero,direccion_piso,direccion_depto)
	VALUES(@Cuit,@BocaAtencion,'1',@Calle,Convert(varchar(5),@Numero),CONVERT(varchar(5),@Piso),@Depto);
	
	INSERT INTO PAMI.Asociacion(asociacion_nombre, asociacion_nombreCorto, asociacion_cuit,asociacion_usuario)
	VALUES(@Nombre,@NombreCorto,@Cuit,@Usuario)
	
END
GO

CREATE PROCEDURE PAMI.UpdatePrestador
	@Cuit varchar(8),
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
	@TipoPrestador varchar(1)
AS
BEGIN
	UPDATE PAMI.Prestador SET nro_sap = @Sap, f_fecha_alta = @FechaAlta, D_denominacion = @NombreCorto, d_calle = @Calle, d_puerta = @Numero,
	d_piso = @Piso, d_departamento = @Depto, tipo_prestador = @TipoPrestador WHERE prestador_cuit = @Cuit AND prestador_usuario = @Usuario
	
	UPDATE PAMI.Asociacion SET asociacion_nombre = @Nombre, asociacion_nombreCorto = @NombreCorto, 
	asociacion_usuario = @Usuario WHERE asociacion_cuit = @Cuit AND asociacion_usuario = @Usuario
	
	UPDATE PAMI.BocaAtencion SET c_boca_atencion = @BocaAtencion, direccion_calle = @Calle, direccion_depto = @Depto,
	direccion_numero = @Numero, direccion_piso = @Piso WHERE cuit_prestador = @Cuit
END
GO


CREATE PROCEDURE PAMI.TraerListadoPrestadorPorAsociacionID
	@AsocID numeric(10,0)
AS
BEGIN
	SELECT A.asociacion_nombre as prestador_nombre, A.asociacion_nombreCorto as prestador_nombre_corto,prestador_cuit, nro_sap, f_fecha_alta, A.asociacion_usuario as usuario_nombre, P.d_calle, P.d_puerta, P.d_piso, P.d_departamento, P.tipo_prestador, B.c_boca_atencion
	FROM PAMI.Asociacion A, PAMI.Prestador P, PAMI.BocaAtencion B WHERE A.asociacion_id = @AsocID AND P.prestador_cuit = A.asociacion_cuit AND P.prestador_usuario = A.asociacion_usuario AND B.cuit_prestador = P.prestador_cuit
END
GO	