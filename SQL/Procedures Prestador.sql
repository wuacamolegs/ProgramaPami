CREATE PROCEDURE PAMI.TraerListadoPrestadorPorCuitYUsuario
	@Cuit varchar(15),
	@Usuario varchar(16)
AS
BEGIN
	SELECT TOP 1 A.asociacion_nombre AS prestador_nombre, A.asociacion_cuit AS prestador_cuit, A.codigo_boca_atencion AS c_boca_atencion,
    A.codigo_SAP AS nro_sap, A.fecha_alta AS f_fecha_alta, A.asociacion_nombreCorto AS prestador_nombre_corto,
	A.asociacion_usuario AS usuario_nombre, A.calle AS d_calle, A.puerta AS d_puerta, A.piso AS d_piso, A.depto AS d_depto, 
	A.tipo_prestador, A.mail AS d_mail, A.padron
	FROM PAMI.Asociacion A WHERE A.asociacion_cuit = @Cuit AND A.asociacion_usuario = @Usuario
END
GO

CREATE PROCEDURE PAMI.InsertPrestador
      @Cuit varchar(15),
      @Nombre varchar(50),
      @BocaAtencion varchar(5),
      @Sap varchar(5),
      @FechaAlta varchar(10),
      @NombreCorto varchar(30),
      @Usuario varchar(16),
      @Calle varchar(30),
      @Numero numeric(5,0),
      @Piso varchar(2),
      @Depto varchar(5),
      @TipoPrestador varchar(1),
      @Mail varchar(50), 
      @AsocID numeric(10,0),
      @Padron numeric(1,0)
AS
BEGIN

	INSERT INTO PAMI.Asociacion(asociacion_nombre, asociacion_nombreCorto, asociacion_cuit,asociacion_usuario,padron,codigo_boca_atencion, codigo_SAP, fecha_alta, calle, puerta, piso, depto,mail,tipo_prestador)
	VALUES(@Nombre,@NombreCorto,@Cuit,@Usuario,@Padron,@BocaAtencion,@Sap,@FechaAlta,@Calle,Convert(varchar(5),@Numero),isnull(CONVERT(varchar(5),@Piso),''),isnull(@Depto,''),@Mail,@TipoPrestador)

END
GO

CREATE PROCEDURE PAMI.UpdatePrestador
	@Cuit varchar(15),
	@Nombre varchar(50),
	@BocaAtencion varchar(5),
	@Sap varchar(5),
	@FechaAlta varchar(10),
	@NombreCorto varchar(30),
	@Usuario varchar(16),
	@Calle varchar(30),
	@Numero numeric(5,0),
	@Piso varchar(2),
	@Depto varchar(5),
	@TipoPrestador varchar(1),
	@AsocID varchar(10),
	@Mail varchar(50),
	@Padron numeric(1,0)
AS
BEGIN

	UPDATE PAMI.Asociacion SET asociacion_cuit = @Cuit, asociacion_nombre = @Nombre, codigo_boca_atencion = @BocaAtencion,
							   codigo_SAP = @Sap, fecha_alta = @FechaAlta, asociacion_nombreCorto = @NombreCorto, asociacion_usuario = @Usuario,
							   calle = @Calle, puerta = @Numero, depto = @Depto, tipo_prestador = @TipoPrestador, mail = @Mail, padron = @Padron
	WHERE asociacion_id = @AsocID
END
GO

CREATE PROCEDURE PAMI.TraerListadoPrestadorPorAsociacionID
	@AsocID numeric(10,0)
AS
BEGIN
	SELECT A.asociacion_nombre as prestador_nombre, A.asociacion_nombreCorto as prestador_nombre_corto,A.asociacion_cuit AS prestador_cuit, A.codigo_SAP AS nro_sap,
	A.fecha_alta AS f_fecha_alta, A.asociacion_usuario as usuario_nombre,A.calle AS d_calle, A.puerta AS d_puerta,A.piso AS d_piso, 
	A.depto AS d_departamento, A.tipo_prestador, A.codigo_boca_atencion AS c_boca_atencion, A.mail AS d_mail, A.padron
	FROM PAMI.Asociacion A WHERE A.asociacion_id = @AsocID
END
GO	

CREATE PROCEDURE PAMI.DeletePrestador
	@AsocID numeric(10,0)
AS
BEGIN
	DELETE PAMI.Asociacion WHERE asociacion_id = @AsocID
END

select * from PAMI.Asociacion