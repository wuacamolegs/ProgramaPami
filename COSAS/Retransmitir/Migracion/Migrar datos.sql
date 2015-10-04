-- CABECERA --

INSERT INTO dbo.Cabecera VALUES('30689632447',NULL,NULL,'11-14','Asociacion de Oftalmologos de Rio Negro',2,'UP3068963244701',34720) 
GO

-- PRESTADOR --

INSERT INTO dbo.Prestador VALUES('','30689632447',NULL,'',0,'',59826,2,'',0,'elbiohernandez@gmail.com','01/10/2009',null,'',null,0,0,0,'AORN','Tucuman','1231','','','','','')
GO

truncate table dbo.Prestador
go

select * from dbo.Prestador
GO
-- BOCA ATENCION --

INSERT INTO dbo.Boca_Atencion VALUES ('','30689632447','',0,13745,1,'Tucuman','1231',1,1,'','')
GO

-- MODULOS X PRESTADOR --

INSERT INTO dbo.Modulos_Prestador VALUES ('','30689632447','',0,36,'01/10/2009')
GO

truncate table dbo.Modulos_Prestador
GO
select * from dbo.Modulos_Prestador
GO
-------------------------

--ARCHIVO MARI ARREGLOS

select * from dbo.NoviembreMari

update dbo.NoviembreMari set F_PRACTICA = '05/11/2014 09:30'where F_PRACTICA is null

update dbo.NoviembreMari set Nombre_Médico = 'Román Isabel' where Nombre_Médico = 'Román Isabel F. de '

update dbo.NoviembreMari set NroBeneficiario = '150476348403' where F1 = 14129

update dbo.NoviembreMari set NroBeneficiario = '155549952303' where F1 = 14667

-- PROFESIONALES NOVIEMBRE

INSERT INTO dbo.Profesional (vacio1,vacio2,vacio3, profesional_codigo, profesional_nombreCompleto, 
					profesional_especialidad_id,profesional_matricula_nacional, profesional_matricula_provincial, 
					profesional_tipo_documento_id, profesional_numero_documento,profesional_cuil, profesional_direccion_calle, 
					profesional_direccion_numero, profesional_direccion_piso, profesional_direccion_depto, 
					profesional_codigo_postal, profesional_telefono)
(SELECT DISTINCT '','','',0, 
		'',
		25,
		N_MAT_PROF,
		null,
		'DNI',
		0,
		'',
		'Tucuman',
		'1231',
		'','','',''
 FROM dbo.Prestaciones_1$ WHERE N_MAT_PROF IS NOT NULL)

GO


INSERT into dbo.Profesional2
select DISTINCT '','','',profesional_codigo,Nombre_Médico, profesional_especialidad_id, profesional_matricula_nacional, profesional_matricula_provincial,
		profesional_tipo_documento_id, profesional_numero_documento, profesional_cuil, profesional_direccion_calle, profesional_direccion_numero,'','','',''

 from dbo.Profesional, dbo.NoviembreMari N where N.Médico = profesional_matricula_nacional

GO

truncate table dbo.Profesional

insert into dbo.Profesional select * from dbo.Profesional2

select * from dbo.Profesional
GO



-- DIAGNOSTICOS --

INSERT INTO dbo.Diagnostico (diagnostico_clasificacion, diagnostico_codigo, diagnostico_tipo, diagnostico_descripcion)
SELECT '1',CODIGO,'1',DIAGNOSTICO FROM dbo.DiagnosticosParsear

select * from dbo.Diagnostico

-- AMBULATORIOS -- SOLO MODULOS 36 .. AMBULATORIOS 4385  REGISTROS 14128

INSERT INTO dbo.Ambulatorio 
SELECT DISTINCT '','', N_MAT_PROF,
				b.N_PRESTACION,
				0,
				0,
				1,
				null,
				(CONVERT(datetime,substring(F_PRESTACION,7,4) + '-' + substring(F_PRESTACION,4,2) + '-' + substring(F_PRESTACION,1,2))),
				null,
				null,
				1,  --afiliado propio
				null,
				null,
				b.N_BENEFICIO,
				b.C_GRADO_PAREN
FROM  dbo.Prestaciones_1$ b, dbo.Practicas_1$ a
WHERE b.N_PRESTACION = a.N_PRESTACION
AND C_MODULO_PAMI = 36
GO

truncate table dbo.Ambulatorio
GO

select * from dbo.Ambulatorio
GO


-- BENEFICIO --

INSERT INTO dbo.Beneficio
SELECT DISTINCT '','','',N_BENEFICIO, null,'',1,'01/10/2009' FROM dbo.Prestaciones_1$ P,dbo.Practicas_1$ PR WHERE P.N_PRESTACION = PR.N_PRESTACION AND C_MODULO_PAMI = 36
GO

select * from dbo.Beneficio order by beneficio_id
GO
truncate table dbo.Beneficio
GO

-- DIAGNOSTICO_AMBULATORIO

INSERT INTO dbo.Diagnosticos_Ambulatorio
select DISTINCT  '','','', P.N_PRESTACION ,D.diagnostico_clasificacion,P.N_ORDEN_PRESTACION,D.diagnostico_tipo 
from dbo.Prestaciones_1$ P, dbo.Diagnostico D, dbo.Practicas_1$ PR
WHERE PR.C_MODULO_PAMI = 36 AND
      PR.N_PRESTACION = P.N_PRESTACION AND
	  D.diagnostico_codigo = P.N_ORDEN_PRESTACION
ORDER BY P.N_PRESTACION
GO

select * from dbo.Diagnosticos_Ambulatorio
GO
-- PRACTICAS REALIZADAS X AMBULATORIO

INSERT INTO dbo.PracticasRealizadas_Ambulatorio
SELECT '','','',N_PRESTACION,1,C_PRACTICA,
(CONVERT(datetime,substring(F_PRACTICA,7,4) + '-' + substring(F_PRACTICA,4,2) + '-' + substring(F_PRACTICA,1,2) + ' ' + substring(F_PRACTICA,12,5)+ ':00')),
 1,1,null FROM  dbo.Practicas_1$ WHERE C_MODULO_PAMI = 36
 
 select * from dbo.PracticasRealizadas_Ambulatorio
 go
 truncate table dbo.PracticasRealizadas_Ambulatorio
 
 -- AFILIADOS 
 
select * from dbo.Afiliados

insert into dbo.AfiliadosPami
select * from PAMI.PAMI.Afiliado
 
insert into dbo.Afiliados
select distinct A.*	
from dbo.Prestaciones_1$ P, dbo.AfiliadosPami A, dbo.Practicas_1$ PR WHERE (P.N_BENEFICIO + P.C_GRADO_PAREN) = (A.afiliado_beneficio_id + A.afiliado_parentesco_id) AND
																					            PR.N_PRESTACION = P.N_PRESTACION AND
																							    PR.C_MODULO_PAMI = 36 


--todos los beneficiarios que se atendieron sin contar los viejos  3352
insert into dbo.Planilla (planilla_beneficio)
select distinct N_BENEFICIO + C_GRADO_PAREN AS AF from dbo.Prestaciones_1$ P, dbo.Practicas_1$ PRA where P.N_PRESTACION = PRA.N_PRESTACION AND PRA.C_MODULO_PAMI = 36 


truncate table dbo.AfiliadosPami
truncate table PAMI.PAMI.Afiliados


UPDATE dbo.Planilla SET planilla_anio = 1 WHERE planilla_beneficio in(
select distinct P.N_BENEFICIO + P.C_GRADO_PAREN as AF from dbo.Prestaciones_1$ P, dbo.AfiliadosPami A, dbo.Practicas_1$ PR WHERE (P.N_BENEFICIO + P.C_GRADO_PAREN) = (A.afiliado_beneficio_id + A.afiliado_parentesco_id) AND
																					            PR.N_PRESTACION = P.N_PRESTACION AND
																							    PR.C_MODULO_PAMI = 36)


select * from dbo.Planilla where planilla_anio is null


--------------------------------
-------------------------------
--------------------------------
-------------------------------
--------------------------------
-------------------------------
--SACAR LOS QUE NO VAN!!

-- AMBULATORIOS -- SOLO MODULOS 36 .. AMBULATORIOS 4385  REGISTROS 14128
			    -- 81 no van! quedan en total 4304

select * from dbo.Ambulatorio
GO

DELETE FROM dbo.Ambulatorio where (exists(select * from dbo.Planilla where planilla_anio is null and (ambulatorio_beneficio_id + ambulatorio_parentesco_id) = planilla_beneficio))


-- BENEFICIO --  3210 saque 60 tipos

select * from dbo.Beneficio order by beneficio_id
GO
truncate table dbo.Beneficio
GO

INSERT INTO dbo.Beneficio
SELECT DISTINCT '','','',afiliado_beneficio_id, null,'',1,'2009-10-1' FROM dbo.Afiliados
GO

-- DIAGNOSTICO_AMBULATORIO delete 81 quedaron 4304 (esta bien segun cantidad ambulatorios)

select * from dbo.Diagnosticos_Ambulatorio
GO

delete from dbo.Diagnosticos_Ambulatorio WHERE da_ambulatorio_codigo not in(select ambulatorio_codigo from dbo.Ambulatorio)


-- PRACTICAS REALIZADAS X AMBULATORIO saque 270 de 14128 quedaron en total 13858

INSERT INTO dbo.PracticasRealizadas_Ambulatorio
SELECT '','','',N_PRESTACION,1,C_PRACTICA,
(CONVERT(datetime,substring(F_PRACTICA,7,4) + '-' + substring(F_PRACTICA,4,2) + '-' + substring(F_PRACTICA,1,2) + ' ' + substring(F_PRACTICA,12,5)+ ':00')),
 1,1,null FROM  dbo.Practicas_1$ WHERE C_MODULO_PAMI = 36
 
 select * from dbo.PracticasRealizadas_Ambulatorio
 go
 truncate table dbo.PracticasRealizadas_Ambulatorio
 
 DELETE FROM dbo.PracticasRealizadas_Ambulatorio WHERE pra_ambulatorio_codigo not in(select ambulatorio_codigo from dbo.Ambulatorio) 
 
 
 
---------------------------------------
---------------------------------------
-- ARREGLAR FORMATO FECHAS


INSERT INTO dbo.Afiliados2
SELECT afiliado_apellidoNombre, afiliado_tipo_documento, afiliado_numero_documento, afiliado_estado_civil, afiliado_nacionalidad_id,
afiliado_pais_id, afiliado_direccion_calle, null, null,null,null,null, 
SUBSTRING(afiliado_fecha_nacimiento,9,2)+'/'+SUBSTRING(afiliado_fecha_nacimiento,6,2)+'/'+SUBSTRING(afiliado_fecha_nacimiento,1,4),
afiliado_sexo,
null,null,afiliado_beneficio_id, afiliado_parentesco_id, null,null,null,null,null,null,null,null
FROM dbo.Afiliados

select * from dbo.Afiliados2

INSERT INTO dbo.Afiliados
SELECT * FROM dbo.Afiliados2

SELECT * FROM dbo.Ambulatorio





-------------------------
-- ordeno practicasxambulatorio por ambulatorio y practica

select * from dbo.PracticasRealizadas_Ambulatorio2

select  pra_prestacion_codigo as Practica, pra_cantidad as Cant, practica_descripcion 
from dbo.PracticasRealizadas_Ambulatorio2, dbo.Nomenclador where pra_cantidad > 1 
and CONVERT(VARCHAR(15),pra_prestacion_codigo) = practica_codigo order by pra_cantidad desc

and practica_descripcion like '%' + 'BILATERAL' + '%'


insert into dbo.PracticasRealizadas_Ambulatorio2
 select null,null,null,pra_ambulatorio_codigo,1,pra_prestacion_codigo,'A',count(pra_prestacion_codigo) as cant, 1,null from dbo.PracticasRealizadas_Ambulatorio  group by pra_ambulatorio_codigo, pra_prestacion_codigo 
 go
 
 
select null,null,null,pra_ambulatorio_codigo, 1 , pra_prestacion_codigo ,
CONVERT(VARCHAR(10),CONVERT(datetime, pra_practica_fecha),103) + ' ' + CONVERT(VARCHAR(5),CONVERT(datetime, pra_practica_fecha),8),
pra_cantidad, 1, null
from RetransmitirNoviembre.dbo.PracticasRealizadas_Ambulatorio2 order by pra_cantidad desc





UPDATE RetransmitirNoviembre.dbo.PracticasRealizadas_Ambulatorio2
SET pra_cantidad = 1
WHERE pra_prestacion_codigo in(select practica_codigo from dbo.Nomenclador where practica_descripcion like '%' + 'BILATERAL' + '%')
	  AND pra_cantidad > 1



SELECT * FROM dbo.PracticasRealizadas_Ambulatorio

SELECT * FROM dbo.PracticasRealizadas_Ambulatorio2 order by pra_ambulatorio_codigo


UPDATE RetransmitirNoviembre.dbo.PracticasRealizadas_Ambulatorio2 
SET pra_cantidad = 2 WHERE pra_cantidad = 3

