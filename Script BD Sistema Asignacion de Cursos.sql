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
  noDocumento_pk INT,
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
  creditos INT,
  precio DECIMAL(10,2),
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
  codigoAsignacionCurso_pk INT auto_increment,
  codigoCurso_fk INT,
  seccion CHAR(1),
  salon VARCHAR(10),
  horario TIME,
  diasCurso INT,
  semestreAsignacion INT,
  añoAsignacion INT,
  codigoCarrera_fk INT,
  PRIMARY KEY (codigoAsignacionCurso_pk),
  FOREIGN KEY (codigoCurso_fk) REFERENCES Curso(codigoCurso_pk),
  FOREIGN KEY (codigoCarrera_fk) REFERENCES Carrera(codigoCarrera_pk)
);

CREATE TABLE AsignacionAlumno (
  codigoAsignacion_pk INT auto_increment,
  carnetEstudiante_fk INT,
  codigoAsignacionCurso_fk INT,
  fechaAsignacion DATE,
  noDocumento_fk INT,
  PRIMARY KEY (codigoAsignacion_pk),
  FOREIGN KEY (carnetEstudiante_fk) REFERENCES Estudiante(carnetEstudiante_pk),
  FOREIGN KEY (codigoAsignacionCurso_fk) REFERENCES AsignacionCurso(codigoAsignacionCurso_pk),
  FOREIGN KEY (noDocumento_fk) REFERENCES Inscripcion(noDocumento_pk)
);

CREATE TABLE AsignacionCursoCatedratico (
  codigoAsignacionCatedratico_pk INT auto_increment,
  carnetCatedratico_fk INT,
  codigoAsignacionCurso_fk INT,
  fechaAsignacion DATE,
  PRIMARY KEY (codigoAsignacionCatedratico_pk),
  FOREIGN KEY (carnetCatedratico_fk) REFERENCES Catedratico(carnetCatedratico_pk),
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
  codigoAsignacionLaboratorio_pk INT auto_increment,
  codigoCurso_fk INT,
  precioLaboratorio DECIMAL(10,2),
  horario TIME,
  diaLaboratorio VARCHAR(20),
  semestreAsignacion INT,
  añoAsignacion INT,
  codigoCarrera_fk INT,
  PRIMARY KEY (codigoAsignacionLaboratorio_pk),
  FOREIGN KEY (codigoCurso_fk) REFERENCES Curso(codigoCurso_pk),
  FOREIGN KEY (codigoCarrera_fk) REFERENCES Carrera(codigoCarrera_pk)
);



INSERT INTO usuario (usuario, contraseña) values ("administrador", "admin&1");

INSERT INTO rolesusuario(rolUsuario) 
values 
("Estudiante"), 
("Catedratico"),
("Administrativo");


