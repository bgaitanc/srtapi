CREATE DATABASE DB_SRT
GO

USE DB_SRT
GO

-- Tabla de estados
CREATE TABLE Estados
(
    EstadoID          INT PRIMARY KEY IDENTITY (1,1),
    Estado            VARCHAR(100) NOT NULL,
    FechaCreacion     DATETIME     NOT NULL,
    FechaModificacion DATETIME     NOT NULL,
    CreadorID         INT,
    ModificadorID     INT,
    Activo            BIT          NOT NULL
);

-- Tabla de pais
CREATE TABLE Pais
(
    PaisID            INT PRIMARY KEY IDENTITY (1,1),
    Pais              VARCHAR(100) NOT NULL,
    FechaCreacion     DATETIME     NOT NULL,
    FechaModificacion DATETIME     NOT NULL,
    CreadorID         INT,
    ModificadorID     INT,
    Activo            BIT          NOT NULL
);

-- Tabla de departamentos
CREATE TABLE Departamentos
(
    DepartamentoID    INT PRIMARY KEY IDENTITY (1,1),
    PaisID            INT REFERENCES Pais (PaisID),
    Departamento      VARCHAR(100) NOT NULL,
    FechaCreacion     DATETIME     NOT NULL,
    FechaModificacion DATETIME     NOT NULL,
    CreadorID         INT,
    ModificadorID     INT,
    Activo            BIT          NOT NULL
);

-- Tabla de locaciones
CREATE TABLE Locaciones
(
    DestinoID         INT PRIMARY KEY IDENTITY (1,1),
    DepartamentoID    INT REFERENCES Departamentos (DepartamentoID),
    Locacion          VARCHAR(255) NOT NULL,
    FechaCreacion     DATETIME     NOT NULL,
    FechaModificacion DATETIME     NOT NULL,
    CreadorID         INT,
    ModificadorID     INT,
    Activo            BIT          NOT NULL
);

-- Tabla Roles
CREATE TABLE Roles
(
    RolID             INT PRIMARY KEY IDENTITY (1,1),
    Rol               VARCHAR(255) NOT NULL,
    FechaCreacion     DATETIME     NOT NULL,
    FechaModificacion DATETIME     NOT NULL,
    CreadorID         INT,
    ModificadorID     INT,
    Activo            BIT          NOT NULL
);

-- Tabla de usuarios
CREATE TABLE Usuarios
(
    UsuarioID         INT PRIMARY KEY IDENTITY (1,1),
    Nombres           VARCHAR(150) NOT NULL,
    Apellidos         VARCHAR(150) NOT NULL,
    Usuario           VARCHAR(100),
    Contrasena        VARCHAR(100),
    Correo            VARCHAR(255),
    Telefono          VARCHAR(25),
    RolID             INT REFERENCES Roles (RolID),
    FechaCreacion     DATETIME     NOT NULL,
    FechaModificacion DATETIME     NOT NULL,
    CreadorID         INT,
    ModificadorID     INT,
    Activo            BIT          NOT NULL
);

-- Tabla de vehículos
CREATE TABLE Vehiculos
(
    VehiculoID        INT PRIMARY KEY IDENTITY (1,1),
    Placa             NVARCHAR(20),
    Modelo            NVARCHAR(100),
    Capacidad         INT,
    FechaCreacion     DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    CreadorID         INT,
    ModificadorID     INT,
    Activo            BIT      NOT NULL
);

-- Tabla de rutas
CREATE TABLE Rutas
(
    RutaID            INT PRIMARY KEY IDENTITY (1,1),
    LocacionOrigenID  INT REFERENCES Locaciones (DestinoID),
    LocacionDestinoID INT REFERENCES Locaciones (DestinoID),
    DistanciaKM       DECIMAL(18, 2),
    TiempoEstimado    TIME,
    FechaCreacion     DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    CreadorID         INT,
    ModificadorID     INT,
    Activo            BIT      NOT NULL
);

-- Tabla de viajes
CREATE TABLE Viajes
(
    ViajeID           INT PRIMARY KEY IDENTITY (1,1),
    RutaID            INT REFERENCES Rutas (RutaID),
    VehiculoID        INT REFERENCES Vehiculos (VehiculoID),
    Conductor         INT REFERENCES Usuarios (UsuarioID),
    Costo             DECIMAL(18, 2) NOT NULL,
    FechaHoraSalida   DATETIME,
    FechaHoraLlegada  DATETIME,
    FechaCreacion     DATETIME       NOT NULL,
    FechaModificacion DATETIME       NOT NULL,
    CreadorID         INT,
    ModificadorID     INT,
    EstadoID          INT REFERENCES Estados (EstadoID)
);

-- Tabla de reservas
CREATE TABLE Reservas
(
    ReservaID         INT PRIMARY KEY IDENTITY (1,1),
    ViajeID           INT REFERENCES Viajes (ViajeID),
    ClienteID         INT FOREIGN KEY REFERENCES Usuarios (UsuarioID),
    FechaReserva      DATETIME,
    FechaCreacion     DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    CreadorID         INT,
    ModificadorID     INT,
    EstadoID          INT REFERENCES Estados (EstadoID)
);

-- Tabla de reservas
CREATE TABLE DetalleReservas
(
    DetalleReservaID INT PRIMARY KEY IDENTITY (1,1),
    ReservaID        INT REFERENCES Reservas (ReservaID),
    NumeroAsiento    INT
);

-- Métodos de pago (opcional si es simple)
CREATE TABLE MetodosPago
(
    MetodoPagoID      INT PRIMARY KEY IDENTITY (1,1),
    MetodoPago        VARCHAR(50),
    FechaCreacion     DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    CreadorID         INT,
    ModificadorID     INT,
    Activo            BIT
);

-- Métodos de pago (opcional si es simple)
CREATE TABLE MetodosPagoUsuario
(
    MetodoPagoUsuarioID INT PRIMARY KEY IDENTITY (1,1),
    MetodoPagoID        INT REFERENCES MetodosPago (MetodoPagoID),
    UsuarioID           INT REFERENCES Usuarios (UsuarioID),
    Referencia          VARCHAR(50),
    FechaCreacion       DATETIME NOT NULL,
    FechaModificacion   DATETIME NOT NULL,
    CreadorID           INT,
    ModificadorID       INT,
    Activo              BIT
);

-- Tabla de pagos
CREATE TABLE Pagos
(
    PagoID              INT PRIMARY KEY IDENTITY (1,1),
    ReservaID           INT REFERENCES Reservas (ReservaID),
    FechaPago           DATETIME NOT NULL,
    Monto               DECIMAL(10, 2),
    MetodoPagoUsuarioID INT REFERENCES MetodosPagoUsuario (MetodoPagoUsuarioID),
    FechaCreacion       DATETIME NOT NULL,
    FechaModificacion   DATETIME NOT NULL,
    CreadorID           INT,
    ModificadorID       INT,
    EstadoID            INT REFERENCES Estados (EstadoID)
);