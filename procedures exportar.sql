

use [PAMI]
go

CREATE PROCEDURE PAMI.TraerListadoCabecera
AS
	BEGIN
		SELECT * FROM RetransmitirNoviembre.dbo.Cabecera
	END
GO

CREATE PROCEDURE PAMI.TraerListadoProfesionales
AS
	BEGIN
		SELECT * FROM RetransmitirNoviembre.dbo.Profesional
	END
GO

CREATE PROCEDURE PAMI.TraerListadoPrestador
AS
	BEGIN
		SELECT * FROM RetransmitirNoviembre.dbo.Prestador
	END
GO

CREATE PROCEDURE PAMI.TraerListadoBocaAtencion
AS
	BEGIN
		SELECT * FROM RetransmitirNoviembre.dbo.Boca_Atencion
	END
GO

CREATE PROCEDURE PAMI.TraerListadoREL_MODULOSXPRESTADOR
AS
	BEGIN
		SELECT * FROM RetransmitirNoviembre.dbo.Modulos_Prestador
	END
GO

CREATE PROCEDURE PAMI.TraerListadoREL_PROFESIONALESXPRESTADOR
AS
	BEGIN
		SELECT * FROM RetransmitirNoviembre.dbo.Profesionales_Prestador
	END
GO

CREATE PROCEDURE PAMI.TraerListadoBENEFICIO
AS
	BEGIN
		SELECT * FROM RetransmitirNoviembre.dbo.Beneficio
	END
GO

CREATE PROCEDURE PAMI.TraerListadoAFILIADO
AS
	BEGIN
		SELECT * FROM RetransmitirNoviembre.dbo.Afiliados
	END
GO

CREATE PROCEDURE PAMI.TraerListadoAMBULATORIOS
AS
	BEGIN
		SELECT ambulatorio_red_cuit, '',ambulatorio_profesional_matricula_nacional,ambulatorio_codigo,0,0,13745,0,
		(SUBSTRING(ambulatorio_fecha_atencion,9,2)+'/'+SUBSTRING(ambulatorio_fecha_atencion,6,2)+'/'+SUBSTRING(ambulatorio_fecha_atencion,1,4)),
		'','',1,'','',ambulatorio_beneficio_id, ambulatorio_parentesco_id		
		FROM RetransmitirNoviembre.dbo.Ambulatorio
	END
GO

ALTER PROCEDURE PAMI.TraerListadoDatosAmbulatorio
	@Ambulatorio int
AS
	BEGIN
		SELECT '','','',0,da_diagnostico_codigo_clasificacion, da_diagnostico_codigo, da_diagnostico_tipo FROM RetransmitirNoviembre.dbo.Diagnosticos_Ambulatorio WHERE da_ambulatorio_codigo = @Ambulatorio
		select null,null,null,pra_ambulatorio_codigo, 1 , pra_prestacion_codigo ,
		CONVERT(VARCHAR(10),CONVERT(datetime, pra_practica_fecha),103) + ' ' + CONVERT(VARCHAR(5),CONVERT(datetime, pra_practica_fecha),8),
		pra_cantidad, 1, null
		from RetransmitirNoviembre.dbo.PracticasRealizadas_Ambulatorio2 
		WHERE pra_ambulatorio_codigo = @Ambulatorio
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

