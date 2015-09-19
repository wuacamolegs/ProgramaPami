-- IMPORTAR DATOS --

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

ALTER PROCEDURE PAMI.ActualizarPadronAfiliados
AS
	BEGIN TRANSACTION
		--TRUNCATE TABLE PAMI.AfiliadosPami
		INSERT INTO PAMI.AfiliadosPami(afiliado_beneficio_id, afiliado_parentesco_id,afiliado_apellidoNombre,afiliado_fecha_nacimiento, afiliado_tipo_documento, afiliado_numero_documento,afiliado_sexo)
		(SELECT 
			CONVERT(varchar(12),substring(padron,5,12)),
			CONVERT(numeric(2),substring(padron,17,2)),
			substring(padron,32,40),
			substring(padron,78,2) + '/' + substring(padron,76,2) + '/' + substring(padron,72,4),
			substring(padron,80,3),
			CONVERT(numeric(15,0),substring(padron,83,8)),
			substring(padron,98,1)
		 FROM PAMI.padron);
		 TRUNCATE TABLE PAMI.padron;
	COMMIT
GO



