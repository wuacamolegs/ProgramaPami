-- IMPORTAR DATOS --

ALTER PROCEDURE PAMI.ImportarPadron
	@ruta nvarchar(200)
AS
	BEGIN
	DECLARE @comando nvarchar(400);
	TRUNCATE TABLE PAMI.Padron;
	TRUNCATE TABLE PAMI.AfiliadosPami
	SET @comando = 'BULK INSERT PAMI.padron FROM ''' + @ruta + ''' WITH (ROWTERMINATOR=''\n'')';
	EXEC sp_executesql @comando;
	EXEC PAMI.ActualizarPadronAfiliados;
	EXEC PAMI.ArreglarParentescos;
	END
GO				

ALTER PROCEDURE PAMI.ActualizarPadronAfiliados
AS
	BEGIN TRANSACTION
		INSERT INTO PAMI.AfiliadosPami(beneficio,parentesco,apellido_nombre,fecha_nacimiento, documento_tipo, documento_numero,sexo)
		(SELECT 
			CONVERT(varchar(12),substring(padron,5,12)),
			CONVERT(varchar(2),substring(padron,17,2)),
			substring(padron,32,40),
			substring(padron,78,2) + '/' + substring(padron,76,2) + '/' + substring(padron,72,4),
			substring(padron,80,3),
			CONVERT(numeric(15,0),substring(padron,83,8)),
			substring(padron,98,1)
		 FROM PAMI.padron);
	COMMIT
GO

CREATE PROCEDURE PAMI.ArreglarParentescos
AS
BEGIN
	UPDATE PAMI.AfiliadosPami SET parentesco = '0' + parentesco WHERE LEN(parentesco) = 1
END
GO




--///// DIAGNOSTICOS \\\\\--

ALTER PROCEDURE PAMI.ImportarDiagnosticos
	@ruta varchar(200)
AS
	BEGIN
	DECLARE @comando nvarchar(400);
	TRUNCATE TABLE PAMI.Diagnosticos;
	TRUNCATE TABLE PAMI.Diagnostico;
	SET @comando = 'BULK INSERT PAMI.Diagnosticos FROM ''' + @ruta + ''' WITH (FIELDTERMINATOR ='';'', ROWTERMINATOR=''\n'')';
	EXEC sp_executesql @comando;
	EXEC PAMI.ActualizarDiagnosticos;
	END
GO

ALTER PROCEDURE PAMI.ActualizarDiagnosticos
AS
	BEGIN
	UPDATE PAMI.Diagnosticos SET CODIGO = UPPER(CODIGO);
	UPDATE PAMI.Diagnosticos SET DIAGNOSTICO = UPPER(DIAGNOSTICO);
	INSERT INTO PAMI.Diagnostico (diagnostico_clasificacion_tipo, diagnostico_codigo, diagnostico_tipo, diagnostico_descripcion)
	SELECT '1',CODIGO,'1',DIAGNOSTICO FROM PAMI.Diagnosticos
	END
GO

ALTER PROCEDURE PAMI.ImportarNomenclador
	@ruta nvarchar(200),
	@AsociacionID numeric(10,0)
AS
	BEGIN
	DECLARE @comando nvarchar(400);
	TRUNCATE TABLE PAMI.Nomenclador;
	TRUNCATE TABLE PAMI.NomencladorImportar;
	SET @comando = 'BULK INSERT PAMI.NomencladorImportar FROM ''' + @ruta + ''' WITH (FIELDTERMINATOR ='';'', ROWTERMINATOR=''\n'')';
	EXEC sp_executesql @comando;
	INSERT INTO PAMI.Nomenclador(practica_codigo, practica_descripcion,codigo_modulo, cantidad_maxima)
	SELECT practica_codigo, practica_descripcion, codigo_modulo, 1 FROM PAMI.NomencladorImportar
	-- TODO SE TIENE QUE AGREGAR LA RELACION EN LA TABLA REL_MODULOXPRESTADOR 
	INSERT INTO PAMI.REL_ModulosXPrestador (cuit_prestador, modulonomenclador)
	SELECT DISTINCT asociacion_cuit,codigo_modulo FROM PAMI.NomencladorImportar, PAMI.Asociacion WHERE asociacion_id = @AsociacionID
	END
GO				



