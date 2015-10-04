use [PAMI]
go

CREATE PROCEDURE PAMI.TraerListadoCabecera
AS
	BEGIN
		SELECT * FROM PAMI.Cabecera
	END
GO

CREATE PROCEDURE PAMI.TraerListadoProfesionales
AS
	BEGIN
		SELECT * FROM PAMI.Profesional
	END
GO

CREATE PROCEDURE PAMI.TraerListadoPrestador
AS
	BEGIN
		SELECT * FROM PAMI.Prestador
	END
GO

CREATE PROCEDURE PAMI.TraerListadoBocaAtencion
AS
	BEGIN
		SELECT * FROM PAMI.BocaAtencion
	END
GO

CREATE PROCEDURE PAMI.TraerListadoREL_MODULOSXPRESTADOR
AS
	BEGIN
		SELECT * FROM PAMI.REL_ModulosXPrestador
	END
GO

CREATE PROCEDURE PAMI.TraerListadoREL_PROFESIONALESXPRESTADOR
AS
	BEGIN
		SELECT * FROM PAMI.REL_ProfesionalesXPrestador
	END
GO

CREATE PROCEDURE PAMI.TraerListadoBENEFICIO
AS
	BEGIN
		SELECT * FROM PAMI.Beneficio
	END
GO

CREATE PROCEDURE PAMI.TraerListadoAFILIADO
AS
	BEGIN
		SELECT * FROM PAMI.Afiliados
	END
GO

CREATE PROCEDURE PAMI.TraerListadoAMBULATORIOS
AS
	BEGIN
		SELECT * FROM PAMI.Ambulatorio
	END
GO

CREATE PROCEDURE PAMI.TraerListadoAMBULATORIOS2
AS
	BEGIN
		SELECT ambulatorio_red_cuit, '',ambulatorio_profesional_matricula_nacional,ambulatorio_codigo,0,0,13745,0,
		(SUBSTRING(ambulatorio_fecha_atencion,9,2)+'/'+SUBSTRING(ambulatorio_fecha_atencion,6,2)+'/'+SUBSTRING(ambulatorio_fecha_atencion,1,4)),
		'','',1,'','',ambulatorio_beneficio_id, ambulatorio_parentesco_id		
		FROM RetransmitirNoviembre.dbo.Ambulatorio
	END
GO

CREATE PROCEDURE PAMI.TraerListadoDatosAmbulatorio
	@Ambulatorio int
AS
	BEGIN
		SELECT '','','',0,diagnostico_clasificacion_tipo, diagnostico_codigo, diagnostico_tipo FROM PAMI.REL_DiagnosticosXAmbulatorio WHERE c_ambulatorio_default = @Ambulatorio
		select null,null,null,c_ambulatorio_default, 1 , practica_codigo ,
		CONVERT(VARCHAR(10),CONVERT(datetime, practica_fecha),103) + ' ' + CONVERT(VARCHAR(5),CONVERT(datetime, practica_fecha),8),
		practica_cantidad, 1, null
		from PAMI.REL_PracticasRealizadasXAmbulatorio 
		WHERE c_ambulatorio_default = @Ambulatorio
	END
GO



ALTER PROCEDURE PAMI.ArreglarFechasPracticas
AS
	BEGIN
	
	DECLARE @ambulatorio numeric(10,0)
	DECLARE @practica numeric(10,0)
	DECLARE @fecha varchar(16) = 'hola'
	DECLARE @cantidad numeric(5)
	
	
	 DECLARE practicasAmb CURSOR FOR (SELECT pra_ambulatorio_codigo, pra_prestacion_codigo FROM RetransmitirNoviembre.dbo.PracticasRealizadas_ambulatorio2)
	 
	 OPEN practicasAmb;
	 	 
	 FETCH NEXT FROM practicasAmb INTO @ambulatorio, @practica;
	 
	 WHILE @@FETCH_STATUS = 0
	 BEGIN
		
		select top 1 @fecha = pra_practica_fecha from RetransmitirNoviembre.dbo.PracticasRealizadas_Ambulatorio where pra_ambulatorio_codigo = @ambulatorio AND pra_prestacion_codigo = @practica
		update RetransmitirNoviembre.dbo.PracticasRealizadas_Ambulatorio2 
		set pra_practica_fecha = @fecha where pra_ambulatorio_codigo = @ambulatorio AND pra_prestacion_codigo = @practica
		
		FETCH NEXT FROM practicasAmb INTO @ambulatorio, @practica;		
	END
	 	
	CLOSE practicasAmb;
	DEALLOCATE practicasAmb;
	
	END
GO

