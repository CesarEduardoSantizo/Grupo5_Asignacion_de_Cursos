/*--------------- Script para crear la base de datos y hacer la conexión a la misma --------------------------------- */

CREATE database BD_AsignacionCursos
/*---------- Credenciales de usuario ----------------------*/
CREATE USER 'grupoCinco'@'%' IDENTIFIED BY 'U&grupo5_2501.';
GRANT ALL PRIVILEGES ON bd_asignacioncursos.* TO 'grupoCinco'@'%';
FLUSH PRIVILEGES;

SHOW GRANTS FOR 'grupoCinco'@'%';

/*------------------------------------------- Creación de tablas -----------------------------------------------------*/

use bd_asignacioncursos;

CREATE TABLE Edificio (
  codigoEdificio_pk INT auto_increment,
  nombreEdificio VARCHAR(10),
  PRIMARY KEY (codigoEdificio_pk)
);

CREATE TABLE Facultad (
  codigoFacultad_pk INT auto_increment,
  nombreFacultad VARCHAR(250),
  codigoEdificio_fk INT,
  PRIMARY KEY (codigoFacultad_pk),
  FOREIGN KEY (codigoEdificio_fk) REFERENCES Edificio(codigoEdificio_pk)
);

CREATE TABLE Carrera (
  codigoCarrera_pk INT auto_increment,
  nombreCarrera VARCHAR(100),
  codigoFacultad_fk INT,
  PRIMARY KEY (codigoCarrera_pk),
  FOREIGN KEY (codigoFacultad_fk) REFERENCES Facultad(codigoFacultad_pk)
);

CREATE TABLE Estudiante (
  carnetEstudiante_pk INT,
  nombreEstudiante VARCHAR(100),
  apellidosEstudiante VARCHAR(100),
  telefonoEstudiante INT,
  correoEstudiante VARCHAR(100),
  totalCreditos INT,
  codigoCarrera_fk INT,
  PRIMARY KEY (carnetEstudiante_pk),
  FOREIGN KEY (codigoCarrera_fk) REFERENCES Carrera(codigoCarrera_pk)
);

CREATE TABLE CostoInscripcion (
  codigoCostoInscripcion_pk INT auto_increment,
  semestre INT,
  año INT,
  costo DECIMAL(10,2),
  PRIMARY KEY (codigoCostoInscripcion_pk)
);

CREATE TABLE Inscripcion (
  noDocumento_pk INT auto_increment,
  carnetEstudiante_fk INT,
  codigoCostoInscripcion_fk INT,
  fechaInscripcion DATE,
  PRIMARY KEY (noDocumento_pk),
  FOREIGN KEY (carnetEstudiante_fk) REFERENCES Estudiante(carnetEstudiante_pk),
  FOREIGN KEY (codigoCostoInscripcion_fk) REFERENCES CostoInscripcion(codigoCostoInscripcion_pk)
);

CREATE TABLE RolesUsuario (
  codigoRolUsuario_pk INT auto_increment,
  rolUsuario VARCHAR(100),
  PRIMARY KEY (codigoRolUsuario_pk)
);

CREATE TABLE Catedratico (
  carnetCatedratico_pk INT,
  nombreCatedratico VARCHAR(100),
  apellidosCatedratico VARCHAR(100),
  telefonoCatedratico INT,
  correoCatedratico VARCHAR(100),
  PRIMARY KEY (carnetCatedratico_pk)
);

CREATE TABLE Usuario (
  codigoUsuario_pk INT auto_increment,
  usuario VARCHAR(250),
  contraseña VARCHAR(100),
  codigoRolUsuario_fk INT,
  carnetEstudiante_fk INT,
  carnetCatedratico_fk INT,
  PRIMARY KEY (codigoUsuario_pk),
  FOREIGN KEY (codigoRolUsuario_fk) REFERENCES RolesUsuario(codigoRolUsuario_pk),
  FOREIGN KEY (carnetEstudiante_fk) REFERENCES Estudiante(carnetEstudiante_pk),
  FOREIGN KEY (carnetCatedratico_fk) REFERENCES Catedratico(carnetCatedratico_pk)
);

CREATE TABLE Curso (
  codigoCurso_pk INT,
  nombreCurso VARCHAR(250),
  creditosAsignados INT,
  precio DECIMAL(10,2),
  creditosNecesarios INT,
  PRIMARY KEY (codigoCurso_pk)
);

CREATE TABLE Notas (
  codigoNota_pk INT auto_increment,
  carnetEstudiante_fk INT,
  codigoCurso_fk INT,
  notaPrimerParcial INT,
  notaSegundoParcial INT,
  notaActividades INT,
  examenFinal INT,
  PRIMARY KEY (codigoNota_pk),
  FOREIGN KEY (codigoCurso_fk) REFERENCES Curso(codigoCurso_pk),
  FOREIGN KEY (carnetEstudiante_fk) REFERENCES Estudiante(carnetEstudiante_pk)
);

CREATE TABLE Pensum (
  codigoPensum_pk INT auto_increment,
  codigoCarrera_fk INT,
  codigoCurso_fk INT,
  codigoPreRequisito_fk INT,
  numeroCiclo INT,
  PRIMARY KEY (codigoPensum_pk),
  FOREIGN KEY (codigoCarrera_fk) REFERENCES Carrera(codigoCarrera_pk),
  FOREIGN KEY (codigoCurso_fk) REFERENCES Curso(codigoCurso_pk),
  FOREIGN KEY (codigoPreRequisito_fk) REFERENCES Curso(codigoCurso_pk)
);

CREATE TABLE AsignacionCurso (
  codigoAsignacionCurso_pk INT AUTO_INCREMENT,
  codigoCurso_fk INT,
  seccion CHAR(1),
  salon VARCHAR(10),
  horaInicio TIME,
  horaSalida TIME,
  diasCurso INT,
  semestreAsignacion INT,
  añoAsignacion INT,
  codigoCarrera_fk INT,
  codigoCatedratico_fk INT,
  fechaAsignacion DATE,
  PRIMARY KEY (codigoAsignacionCurso_pk),
  FOREIGN KEY (codigoCurso_fk) REFERENCES Curso(codigoCurso_pk),
  FOREIGN KEY (codigoCarrera_fk) REFERENCES Carrera(codigoCarrera_pk),
  FOREIGN KEY (codigoCatedratico_fk) REFERENCES Catedratico(carnetCatedratico_pk)
);

CREATE TABLE AsignacionAlumnoE (
  codigoAsignacion_pk INT AUTO_INCREMENT,
  carnetEstudiante_fk INT,
  fechaAsignacion DATE,
  noDocumento_fk INT,
  PRIMARY KEY (codigoAsignacion_pk),
  FOREIGN KEY (carnetEstudiante_fk) REFERENCES Estudiante(carnetEstudiante_pk),
  FOREIGN KEY (noDocumento_fk) REFERENCES Inscripcion(noDocumento_pk)
);

CREATE TABLE AsignacionAlumnoD (
  codigoDetalle_pk INT AUTO_INCREMENT,
  codigoAsignacion_fk INT,
  codigoAsignacionCurso_fk INT,
  PRIMARY KEY (codigoDetalle_pk),
  FOREIGN KEY (codigoAsignacion_fk) REFERENCES AsignacionAlumnoE(codigoAsignacion_pk),
  FOREIGN KEY (codigoAsignacionCurso_fk) REFERENCES AsignacionCurso(codigoAsignacionCurso_pk)
);

CREATE TABLE Salon (
  codigoSalon_pk INT auto_increment,
  numeroSalon VARCHAR(10),
  codigoEdificio_fk INT,
  PRIMARY KEY (codigoSalon_pk),
  FOREIGN KEY (codigoEdificio_fk) REFERENCES Edificio(codigoEdificio_pk)
);

CREATE TABLE AsignacionLaboratorio (
  codigoAsignacionLaboratorio_pk INT AUTO_INCREMENT,
  codigoCurso_fk INT,
  precioLaboratorio DECIMAL(10,2),
  horaInicio TIME,
  horaSalida TIME,
  diaLaboratorio VARCHAR(20),
  semestreAsignacion INT,
  añoAsignacion INT,
  codigoCarrera_fk INT,
  seccion CHAR(1),
  PRIMARY KEY (codigoAsignacionLaboratorio_pk),
  FOREIGN KEY (codigoCurso_fk) REFERENCES Curso(codigoCurso_pk),
  FOREIGN KEY (codigoCarrera_fk) REFERENCES Carrera(codigoCarrera_pk)
);
