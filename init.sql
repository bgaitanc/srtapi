IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'DB_SRT')
BEGIN
    CREATE DATABASE DB_SRT;
END;
GO

USE DB_SRT;
GO

-- Tabla de estados
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Estados')
BEGIN
    CREATE TABLE Estados
    (
        EstadoID            INT PRIMARY KEY IDENTITY (1,1),
        Estado              VARCHAR(100) NOT NULL,
        FechaCreacion       DATETIME     NOT NULL,
        FechaModificacion   DATETIME,
        CreadorID           INT,
        ModificadorID       INT,
        Activo              BIT DEFAULT 1
    );
END;
GO

-- Tabla de pais
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Pais')
BEGIN
    CREATE TABLE Pais
    (
        PaisID              INT PRIMARY KEY IDENTITY (1,1),
        Pais                VARCHAR(100) NOT NULL,
        FechaCreacion       DATETIME     NOT NULL,
        FechaModificacion   DATETIME,
        CreadorID           INT,
        ModificadorID       INT,
        Activo              BIT DEFAULT 1
    );
END;
GO

-- Tabla de departamentos
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Departamentos')
BEGIN
    CREATE TABLE Departamentos
    (
        DepartamentoID      INT PRIMARY KEY IDENTITY (1,1),
        PaisID              INT REFERENCES Pais (PaisID),
        Departamento        VARCHAR(100) NOT NULL,
        FechaCreacion       DATETIME     NOT NULL,
        FechaModificacion   DATETIME,
        CreadorID           INT,
        ModificadorID       INT,
        Activo              BIT DEFAULT 1
    );
END;
GO

-- Tabla de locaciones
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Locaciones')
BEGIN
    CREATE TABLE Locaciones
    (
        DestinoID           INT PRIMARY KEY IDENTITY (1,1),
        DepartamentoID      INT REFERENCES Departamentos (DepartamentoID),
        Locacion            VARCHAR(255) NOT NULL,
        FechaCreacion       DATETIME     NOT NULL,
        FechaModificacion   DATETIME,
        CreadorID           INT,
        ModificadorID       INT,
        Activo              BIT DEFAULT 1
    );
END;
GO

-- Tabla Roles
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Roles')
BEGIN
    CREATE TABLE Roles
    (
        RolID               INT PRIMARY KEY IDENTITY (1,1),
        Rol                 VARCHAR(255) NOT NULL,
        FechaCreacion       DATETIME     NOT NULL,
        FechaModificacion   DATETIME,
        CreadorID           INT,
        ModificadorID       INT,
        Activo              BIT DEFAULT 1
    );
END;
GO

-- Tabla de usuarios
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Usuarios')
BEGIN
    CREATE TABLE Usuarios
    (
        UsuarioID           INT PRIMARY KEY IDENTITY (1,1),
        Nombres             VARCHAR(150) NOT NULL,
        Apellidos           VARCHAR(150) NOT NULL,
        Usuario             VARCHAR(100),
        Contrasena          VARCHAR(100),
        Correo              VARCHAR(255),
        Telefono            VARCHAR(25),
        FechaCreacion       DATETIME     NOT NULL,
        FechaModificacion   DATETIME,
        CreadorID           INT,
        ModificadorID       INT,
        Activo              BIT DEFAULT 1
    );
END;
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'UsuarioRoles')
BEGIN
    CREATE TABLE UsuarioRoles
    (
        UsuarioRolID        INT PRIMARY KEY IDENTITY (1,1),
        UsuarioID           INT FOREIGN KEY REFERENCES Usuarios (UsuarioID),
        RolID               INT FOREIGN KEY REFERENCES Roles (RolID),
        FechaAsignacion     DATETIME DEFAULT GETDATE(),
        CreadorID           INT,
        Activo              BIT      DEFAULT 1
    );
END;
GO

-- Tabla de vehículos
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Vehiculos')
BEGIN
    CREATE TABLE Vehiculos
    (
        VehiculoID          INT PRIMARY KEY IDENTITY (1,1),
        Placa               NVARCHAR(20),
        Modelo              NVARCHAR(100),
        Capacidad           INT,
        FechaCreacion       DATETIME NOT NULL,
        FechaModificacion   DATETIME,
        CreadorID           INT,
        ModificadorID       INT,
        Activo              BIT DEFAULT 1
    );
END;
GO

-- Tabla de rutas
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Rutas')
BEGIN
    CREATE TABLE Rutas
    (
        RutaID              INT PRIMARY KEY IDENTITY (1,1),
        LocacionOrigenID    INT REFERENCES Locaciones (DestinoID),
        LocacionDestinoID   INT REFERENCES Locaciones (DestinoID),
        DistanciaKM         DECIMAL(18, 2),
        TiempoEstimado      TIME,
        FechaCreacion       DATETIME NOT NULL,
        FechaModificacion   DATETIME,
        CreadorID           INT,
        ModificadorID       INT,
        Activo              BIT DEFAULT 1
    );
END;
GO

-- Tabla de viajes
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Viajes')
BEGIN
    CREATE TABLE Viajes
    (
        ViajeID             INT PRIMARY KEY IDENTITY (1,1),
        RutaID              INT REFERENCES Rutas (RutaID),
        VehiculoID          INT REFERENCES Vehiculos (VehiculoID),
        Conductor           INT REFERENCES Usuarios (UsuarioID),
        Costo               DECIMAL(18, 2) NOT NULL,
        FechaHoraSalida     DATETIME,
        FechaHoraLlegada    DATETIME,
        FechaCreacion       DATETIME       NOT NULL,
        FechaModificacion   DATETIME,
        CreadorID           INT,
        ModificadorID       INT,
        EstadoID            INT REFERENCES Estados (EstadoID)
    );
END;
GO

-- Tabla de reservas
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Reservas')
BEGIN
    CREATE TABLE Reservas
    (
        ReservaID           INT PRIMARY KEY IDENTITY (1,1),
        ViajeID             INT REFERENCES Viajes (ViajeID),
        ClienteID           INT FOREIGN KEY REFERENCES Usuarios (UsuarioID),
        FechaReserva        DATETIME,
        FechaCreacion       DATETIME NOT NULL,
        FechaModificacion   DATETIME,
        CreadorID           INT,
        ModificadorID       INT,
        EstadoID            INT REFERENCES Estados (EstadoID)
    );
END;
GO

-- Tabla de DetalleReservas
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'DetalleReservas')
BEGIN
    CREATE TABLE DetalleReservas
    (
        DetalleReservaID INT PRIMARY KEY IDENTITY (1,1),
        ReservaID        INT REFERENCES Reservas (ReservaID),
        NumeroAsiento    INT
    );
END;
GO

-- Métodos de pago
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'MetodosPago')
BEGIN
    CREATE TABLE MetodosPago
    (
        MetodoPagoID        INT PRIMARY KEY IDENTITY (1,1),
        MetodoPago          VARCHAR(50),
        FechaCreacion       DATETIME NOT NULL,
        FechaModificacion   DATETIME,
        CreadorID           INT,
        ModificadorID       INT,
        Activo              BIT DEFAULT 1
    );
END;
GO

-- Métodos de pago de usuario
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'MetodosPagoUsuario')
BEGIN
    CREATE TABLE MetodosPagoUsuario
    (
        MetodoPagoUsuarioID INT PRIMARY KEY IDENTITY (1,1),
        MetodoPagoID        INT REFERENCES MetodosPago (MetodoPagoID),
        UsuarioID           INT REFERENCES Usuarios (UsuarioID),
        Referencia          VARCHAR(50),
        FechaCreacion       DATETIME NOT NULL,
        FechaModificacion   DATETIME,
        CreadorID           INT,
        ModificadorID       INT,
        Activo              BIT DEFAULT 1
    );
END;
GO

-- Tabla de pagos
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Pagos')
BEGIN
    CREATE TABLE Pagos
    (
        PagoID              INT PRIMARY KEY IDENTITY (1,1),
        ReservaID           INT REFERENCES Reservas (ReservaID),
        FechaPago           DATETIME NOT NULL,
        Monto               DECIMAL(10, 2),
        MetodoPagoUsuarioID INT REFERENCES MetodosPagoUsuario (MetodoPagoUsuarioID),
        FechaCreacion       DATETIME NOT NULL,
        FechaModificacion   DATETIME,
        CreadorID           INT,
        ModificadorID       INT,
        EstadoID            INT REFERENCES Estados (EstadoID)
    );
END;
GO