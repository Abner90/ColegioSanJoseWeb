IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Alumnos] (
    [IdAlumno] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Apellido] nvarchar(max) NOT NULL,
    [FechaNacimiento] datetime2 NOT NULL,
    CONSTRAINT [PK_Alumnos] PRIMARY KEY ([IdAlumno])
);
GO

CREATE TABLE [Materias] (
    [IdMateria] int NOT NULL IDENTITY,
    [NombreMateria] nvarchar(max) NOT NULL,
    [Docente] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Materias] PRIMARY KEY ([IdMateria])
);
GO

CREATE TABLE [Expedientes] (
    [IdExpediente] int NOT NULL IDENTITY,
    [IdAlumno] int NOT NULL,
    [IdMateria] int NOT NULL,
    [NotaFinal] float NOT NULL,
    [Observaciones] nvarchar(500) NULL,
    [MateriaIdMateria] int NULL,
    CONSTRAINT [PK_Expedientes] PRIMARY KEY ([IdExpediente]),
    CONSTRAINT [FK_Expedientes_Alumnos_IdAlumno] FOREIGN KEY ([IdAlumno]) REFERENCES [Alumnos] ([IdAlumno]) ON DELETE CASCADE,
    CONSTRAINT [FK_Expedientes_Materias_IdMateria] FOREIGN KEY ([IdMateria]) REFERENCES [Materias] ([IdMateria]) ON DELETE CASCADE,
    CONSTRAINT [FK_Expedientes_Materias_MateriaIdMateria] FOREIGN KEY ([MateriaIdMateria]) REFERENCES [Materias] ([IdMateria])
);
GO

CREATE INDEX [IX_Expedientes_IdAlumno] ON [Expedientes] ([IdAlumno]);
GO

CREATE INDEX [IX_Expedientes_IdMateria] ON [Expedientes] ([IdMateria]);
GO

CREATE INDEX [IX_Expedientes_MateriaIdMateria] ON [Expedientes] ([MateriaIdMateria]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260504030743_InicialFinal', N'8.0.0');
GO

COMMIT;
GO

