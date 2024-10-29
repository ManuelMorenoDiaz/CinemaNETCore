CREATE DATABASE CinemaNETCore;

USE CinemaNETCore;

-- Tabla de Usuarios
CREATE TABLE Usuarios (
    ID_Usuario INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Contraseña VARCHAR(255) NOT NULL,
    Fecha_Creación DATETIME DEFAULT GETDATE()
);

-- Tabla de Perfiles
CREATE TABLE Perfiles (
    ID_Perfil INT PRIMARY KEY IDENTITY(1,1),
    ID_Usuario INT FOREIGN KEY REFERENCES Usuarios(ID_Usuario),
    Nombre_Perfil VARCHAR(50) NOT NULL,
    Configuraciones TEXT 
);

-- Tabla de Géneros
CREATE TABLE Generos (
    ID_Género INT PRIMARY KEY IDENTITY(1,1),
    Nombre_Género VARCHAR(50) NOT NULL
);

-- Tabla de Películas
CREATE TABLE Peliculas (
    ID_Pelicula INT PRIMARY KEY IDENTITY(1,1),
    Título VARCHAR(100) NOT NULL,
    Descripción TEXT NOT NULL,
    Año_Estreno DATE,
    Duración INT NOT NULL, -- Duración en minutos
    Imagen_URL VARCHAR(255) NOT NULL,
    Trailer_URL VARCHAR(255) NOT NULL,
    ID_Género INT FOREIGN KEY REFERENCES Generos(ID_Género)
);

-- Tabla de Series
CREATE TABLE Series (
    ID_Serie INT PRIMARY KEY IDENTITY(1,1),
    Título VARCHAR(100) NOT NULL,
    Descripción TEXT NOT NULL,
    Año_Estreno DATE,
    Duración_Episodio INT NOT NULL, -- Duración en minutos
    Imagen_URL VARCHAR(255) NOT NULL,
    Trailer_URL VARCHAR(255) NOT NULL,
    ID_Género INT FOREIGN KEY REFERENCES Generos(ID_Género)
);

-- Tabla de Historial Visto
CREATE TABLE HistorialVisto (
   ID_Historial INT PRIMARY KEY IDENTITY(1,1),
   ID_Perfil INT FOREIGN KEY REFERENCES Perfiles(ID_Perfil),
   ID_Pelicula INT NULL FOREIGN KEY REFERENCES Peliculas(ID_Pelicula),
   ID_Serie INT NULL FOREIGN KEY REFERENCES Series(ID_Serie),
   Fecha_Visto DATETIME DEFAULT GETDATE()
);

-- Tabla de Episodios
CREATE TABLE Episodios (
   ID_Episodio INT PRIMARY KEY IDENTITY(1,1),
   ID_Serie INT FOREIGN KEY REFERENCES Series(ID_Serie),
   Título_Episodio VARCHAR(100) NOT NULL,
   Número_Episodio INT NOT NULL,
   Duración_Episodio INT NOT NULL -- Duración en minutos
);

-- Tabla de Actores
CREATE TABLE Actores (
   ID_Actor INT PRIMARY KEY IDENTITY(1,1),
   Nombre VARCHAR(100) NOT NULL,
   Fecha_Nacimiento DATE,
   Biografía TEXT
);

-- Tabla intermedia para relacionar Actores con Películas
CREATE TABLE ActorPelicula (
   ID_Actor INT FOREIGN KEY REFERENCES Actores(ID_Actor),
   ID_Pelicula INT FOREIGN KEY REFERENCES Peliculas(ID_Pelicula),
   Rol VARCHAR(100), -- Rol del actor en la película
   PRIMARY KEY (ID_Actor, ID_Pelicula)
);

-- Tabla intermedia para relacionar Actores con Series
CREATE TABLE ActorSerie (
   ID_Actor INT FOREIGN KEY REFERENCES Actores(ID_Actor),
   ID_Serie INT FOREIGN KEY REFERENCES Series(ID_Serie),
   Rol VARCHAR(100), -- Rol del actor en la serie
   PRIMARY KEY (ID_Actor, ID_Serie)
);