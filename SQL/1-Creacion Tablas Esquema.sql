
use [PAMI]

CREATE TABLE PAMI.Profesional (
	vacio1 varchar(1),
	vacio2 varchar(1),
	vacio3 varchar(1), 
	profesional_codigo varchar(8), 
	profesional_nombreCompleto varchar(60), 
	profesional_especialidad_id varchar(4),
	profesional_matricula_nacional varchar(6),  
	profesional_matricula_provincial varchar(6), 
	profesional_tipo_documento_id varchar(3),
	profesional_numero_documento varchar(15),
	profesional_cuil varchar(15), 
	profesional_direccion_calle varchar(30), 
	profesional_direccion_numero varchar(5), 
	profesional_direccion_piso varchar(2), 
	profesional_direccion_depto varchar(5), 
	profesional_codigo_postal varchar(9), 
	profesional_telefono varchar(20)
	)



CREATE TABLE PAMI.Diagnostico (
	diagnostico_clasificacion_tipo varchar(2),
	diagnostico_codigo varchar(10), 
	diagnostico_tipo varchar(1), 
	diagnostico_descripcion varchar(50)
	)


CREATE TABLE PAMI.Prestador	(
	vacio1 varchar(1),
	prestador_cuit varchar(15),
	profesional_matricula varchar(6),  
	vacio2 varchar(1),  
	c_prestador varchar(10),
	n_nro_prestador varchar(16),
	nro_sap varchar(5),
	tipo_prestador varchar(1),
	c_iva varchar(2),
	m_medico_cabecera varchar(1),
	d_mail varchar(50),
	f_fecha_alta varchar(10),
	f_fecha_baja varchar(10),
	d_motivo_baja varchar(60),
	f_actualizac varchar(10),
	c_cuit varchar(8),
	C_Profesional varchar(8),
	Id_Red varchar(10),
	D_denominacion varchar(30),
	d_calle	varchar(30),
	d_puerta varchar(1),
	d_piso varchar(2),
	d_departamento varchar(5),
	npostal	varchar(9),
	d_telefono varchar(20),
	c_instalacion varchar(20)
	)
	
CREATE TABLE PAMI.Ambulatorio(
	Cuit_Red varchar(1),
	vacio1	varchar(1),
	matricula_nacional varchar(6),
	c_ambulatorio varchar(10),
	ID_RED varchar(9),
	C_prestador varchar(10),
	c_boca_atencion varchar(5),
	c_profesional varchar(8),
	f_fecha_atencion varchar(10),
	d_estado varchar(12),
	d_motivo_rechazo varchar(60),
	id_modalidad_presta varchar(2),
	n_nro_orden	varchar(10),
	id_tipo_atencion varchar(2),
	id_beneficio varchar(12),
	id_parentesco varchar(2),
	)
	
CREATE TABLE PAMI.REL_DiagnosticosXAmbulatorio(
	vacio1 varchar(1),
	vacio2 varchar(1),
	vacio3 varchar(1),
	c_ambulatorio varchar(10),
	diagnostico_clasificacion_tipo varchar(2),
	diagnostico_codigo varchar(10), 
	diagnostico_tipo varchar(1)
	)
	
CREATE TABLE PAMI.REL_PracticasRealizadasXAmbulatorio(
	vacio1 varchar(1),
	vacio2 varchar(1),
	vacio3 varchar(1),
	c_ambulatorio varchar(10),
	cod_prestacion varchar(2),
	practica_codigo varchar(10),
	practica_fecha varchar(10),
	practica_cantidad varchar(3),
	modalidad_prestacion varchar(2),
	numero_orden varchar(10)
	)
	

CREATE TABLE PAMI.Asociacion(
	asociacion_id numeric(10,0) NOT NULL,
	asociacion_nombre varchar(50) NOT NULL,
	asociacion_nombreCorto varchar(30) NOT NULL
	) 
	
CREATE TYPE PAMI.TVP_Planilla AS TABLE(
	tvp_fecha varchar(10),
	tvp_nombre varchar(60),
	tvp_beneficio varchar(14),
	tvp_diagnostico varchar(10),
	tvp_practicas varchar(10),
	tvp_hora varchar(5)
	)
