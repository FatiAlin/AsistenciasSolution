CREATE DATABASE AsistenciasDB;
GO

USE AsistenciasDB;
GO

CREATE TABLE Asistencias (
    Id INT PRIMARY KEY IDENTITY,
    EmpleadoId INT NOT NULL,
    Fecha DATE NOT NULL,
    HoraEntrada TIME NOT NULL,
    HoraSalida TIME NULL
);
GO
DROP TABLE Asistencias