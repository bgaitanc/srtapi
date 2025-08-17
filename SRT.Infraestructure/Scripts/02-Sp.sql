-- Insertar Estado
CREATE OR ALTER PROCEDURE sp_Insertar_Estado @EstadoName VARCHAR(100),
                                             @FechaCreacion DATETIME,
                                             @CreadorId INT
AS
BEGIN
    INSERT INTO Estados (Estado, FechaCreacion, CreadorID, Activo)
    VALUES (@EstadoName, @FechaCreacion, @CreadorId, 1);
    SELECT SCOPE_IDENTITY();
END
GO

-- Obtener Estados
CREATE OR ALTER PROCEDURE sp_Obtener_Estados
AS
BEGIN
    SELECT * FROM Estados
END
GO

-- Obtener Estados por parámetros
CREATE OR ALTER PROCEDURE sp_Obtener_Estado_By_Params @EstadoId INT = NULL,
                                                      @EstadoName VARCHAR(100) = NULL
AS
BEGIN
    IF @EstadoId IS NULL AND @EstadoName IS NULL
        BEGIN
            THROW 50001, N'Debe proporcionar al menos un parámetro: @EstadoId o @EstadoName, ambos no puede ser NULL.', 1;
        END

    IF @EstadoId IS NOT NULL
        SELECT * FROM Estados WHERE EstadoID = @EstadoId
    ELSE
        SELECT * FROM Estados WHERE Estado = @EstadoName
END
GO

-- Actualizar Estado
CREATE OR ALTER PROCEDURE sp_Actualizar_Estado @EstadoId INT,
                                               @EstadoName VARCHAR(100),
                                               @FechaModificacion DATETIME,
                                               @ModificadorId INT
AS
BEGIN
    UPDATE Estados
    SET Estado            = @EstadoName,
        FechaModificacion = @FechaModificacion,
        ModificadorID     = @ModificadorId
    WHERE EstadoID = @EstadoId
END
GO

-- Eliminar o Reactivar Estado
CREATE OR ALTER PROCEDURE sp_Eliminar_O_Reactivar_Estado @EstadoId INT,
                                                         @Activo BIT,
                                                         @FechaModificacion DATETIME,
                                                         @ModificadorId INT
AS
BEGIN
    UPDATE Estados
    SET Activo            = @Activo,
        FechaModificacion = @FechaModificacion,
        ModificadorID     = @ModificadorID
    WHERE EstadoID = @EstadoId
END
GO
------------------------------------------------------------------------------------------------------------------------

-- Insertar País
CREATE OR ALTER PROCEDURE sp_Insertar_Pais @PaisName VARCHAR(100),
                                           @FechaCreacion DATETIME,
                                           @CreadorID INT
AS
BEGIN
    INSERT INTO Pais (Pais, FechaCreacion, CreadorID, Activo)
    VALUES (@PaisName, @FechaCreacion, @CreadorID, 1);
    SELECT SCOPE_IDENTITY();
END
GO

-- Obtener Países
CREATE OR ALTER PROCEDURE sp_Obtener_Paises
AS
BEGIN
    SELECT * FROM Pais
END
GO

-- Obtener pais por parámetros
CREATE OR ALTER PROCEDURE sp_Obtener_Pais_By_Params @PaisId INT = NULL,
                                                    @PaisName VARCHAR(100) = NULL
AS
BEGIN
    IF @PaisId IS NULL AND @PaisName IS NULL
        BEGIN
            THROW 50002, N'Debe proporcionar al menos un parámetro: @PaisId o @PaisName, ambos no puede ser NULL.', 1;
        END

    IF @PaisId IS NOT NULL
        SELECT * FROM Pais WHERE PaisID = @PaisId
    ELSE
        SELECT * FROM Pais WHERE Pais = @PaisName
END
GO

-- Actualizar País
CREATE OR ALTER PROCEDURE sp_Actualizar_Pais @PaisId INT,
                                             @PaisName VARCHAR(100),
                                             @FechaModificacion DATETIME,
                                             @ModificadorId INT
AS
BEGIN
    UPDATE Pais
    SET Pais              = @PaisName,
        FechaModificacion = @FechaModificacion,
        ModificadorID     = @ModificadorId
    WHERE PaisID = @PaisId
END
GO

-- Eliminar o reactivar País
CREATE OR ALTER PROCEDURE sp_Eliminar_O_Reactivar_Pais @PaisId INT,
                                                       @Activo BIT,
                                                       @FechaModificacion DATETIME,
                                                       @ModificadorId INT
AS
BEGIN
    UPDATE Pais
    SET Activo            = @Activo,
        FechaModificacion = @FechaModificacion,
        ModificadorID     = @ModificadorId
    WHERE PaisID = @PaisId
END
GO
------------------------------------------------------------------------------------------------------

-- Insertar Departamento
CREATE OR ALTER PROCEDURE sp_Insertar_Departamento @PaisId INT,
                                                   @DepartamentoName VARCHAR(100),
                                                   @FechaCreacion DATETIME,
                                                   @CreadorId INT
AS
BEGIN
    INSERT INTO Departamentos (PaisID, Departamento, FechaCreacion, CreadorID, Activo)
    VALUES (@PaisId, @DepartamentoName, @FechaCreacion, @CreadorId, 1);
    SELECT SCOPE_IDENTITY();
END
GO

-- Obtener Departamentos
CREATE OR ALTER PROCEDURE sp_Obtener_Departamentos @PaisId INT = NULL
AS
BEGIN
    IF @PaisId IS NULL
        SELECT * FROM Departamentos
    ELSE
        SELECT * FROM Departamentos WHERE PaisID = @PaisId
END
GO

-- Obtener Departamento por parámetros
CREATE OR ALTER PROCEDURE sp_Obtener_Departamento_By_Params @DepartamentoId INT = NULL,
                                                            @DepartamentoName VARCHAR(100) = NULL
AS
BEGIN
    IF @DepartamentoId IS NULL AND @DepartamentoName IS NULL
        BEGIN
            THROW 50003, N'Debe proporcionar al menos un parámetro: @DepartamentoId o @DepartamentoName, ambos no puede ser NULL.', 1;
        END

    IF @DepartamentoId IS NOT NULL
        SELECT * FROM Departamentos WHERE DepartamentoID = @DepartamentoId
    ELSE
        SELECT * FROM Departamentos WHERE Departamento = @DepartamentoName
END
GO

-- Actualizar Departamento
CREATE OR ALTER PROCEDURE sp_Actualizar_Departamento @DepartamentoId INT,
                                                     @PaisId INT,
                                                     @DepartamentoName VARCHAR(100),
                                                     @FechaModificacion DATETIME,
                                                     @ModificadorId INT
AS
BEGIN
    UPDATE Departamentos
    SET PaisID            = @PaisId,
        Departamento      = @DepartamentoName,
        FechaModificacion = @FechaModificacion,
        ModificadorID     = @ModificadorId
    WHERE DepartamentoID = @DepartamentoId
END
GO

-- Eliminar o reactivar Departamento
CREATE OR ALTER PROCEDURE sp_Eliminar_O_Reactivar_Departamento @DepartamentoId INT,
                                                               @Activo BIT,
                                                               @FechaModificacion DATETIME,
                                                               @ModificadorId INT
AS
BEGIN
    UPDATE Departamentos
    SET Activo            = @Activo,
        FechaModificacion = @FechaModificacion,
        ModificadorID     = @ModificadorId
    WHERE DepartamentoId = @DepartamentoId
END
GO
--------------------------------------------------------------------------------------------

-- Insertar Locación
CREATE OR ALTER PROCEDURE sp_Insertar_Locacion @DepartamentoId INT,
                                               @LocacionName VARCHAR(255),
                                               @FechaCreacion DATETIME,
                                               @CreadorID INT
AS
BEGIN
    INSERT INTO Locaciones (DepartamentoID, Locacion, FechaCreacion, CreadorID, Activo)
    VALUES (@DepartamentoId, @LocacionName, @FechaCreacion, @CreadorID, 1);
    SELECT SCOPE_IDENTITY();
END
GO

-- Obtener Locaciones
CREATE OR ALTER PROCEDURE sp_Obtener_Locaciones @DepartamentoId INT = NULL
AS
BEGIN
    IF @DepartamentoId IS NULL
        SELECT * FROM Locaciones
    ELSE
        SELECT * FROM Locaciones WHERE DepartamentoID = @DepartamentoId
END
GO

-- Obtener Locacion por parámetros
CREATE OR ALTER PROCEDURE sp_Obtener_Locacion_By_Params @LocacionId INT = NULL,
                                                        @LocacionName VARCHAR(100) = NULL
AS
BEGIN
    IF @LocacionId IS NULL AND @LocacionName IS NULL
        BEGIN
            THROW 50004, N'Debe proporcionar al menos un parámetro: @LocacionId o @LocacionName, ambos no puede ser NULL.', 1;
        END

    IF @LocacionId IS NOT NULL
        SELECT * FROM Locaciones WHERE DestinoID = @LocacionId
    ELSE
        SELECT * FROM Locaciones WHERE Locacion = @LocacionName
END
GO

-- Actualizar Locación
CREATE OR ALTER PROCEDURE sp_Actualizar_Locacion @LocacionId INT,
                                                 @DepartamentoId INT,
                                                 @LocacionName VARCHAR(255),
                                                 @FechaModificacion DATETIME,
                                                 @ModificadorID INT
AS
BEGIN
    UPDATE Locaciones
    SET DepartamentoID    = @DepartamentoId,
        Locacion          = @LocacionName,
        FechaModificacion = @FechaModificacion,
        ModificadorID     = @ModificadorID
    WHERE DestinoID = @LocacionId
END
GO

-- Eliminar o reactivar Locación
CREATE OR ALTER PROCEDURE sp_Eliminar_O_Reactivar_Locacion @LocacionId INT,
                                                           @Activo BIT,
                                                           @FechaModificacion DATETIME,
                                                           @ModificadorId INT
AS
BEGIN
    UPDATE Locaciones
    SET Activo            = @Activo,
        FechaModificacion = @FechaModificacion,
        ModificadorID     = @ModificadorId
    WHERE DestinoID = @LocacionId
END
GO

-------------------------------------------------------------------------------------------------

-- Insertar Rol
CREATE OR ALTER PROCEDURE sp_Insertar_Rol @Rol VARCHAR(255),
                                          @FechaCreacion DATETIME,
                                          @FechaModificacion DATETIME,
                                          @CreadorID INT,
                                          @ModificadorID INT,
                                          @Activo BIT
AS
BEGIN
    INSERT INTO Roles (Rol, FechaCreacion, FechaModificacion, CreadorID, ModificadorID, Activo)
    VALUES (@Rol, @FechaCreacion, @FechaModificacion, @CreadorID, @ModificadorID, @Activo)
END
GO

-- Obtener Roles
CREATE OR ALTER PROCEDURE sp_Obtener_Roles
AS
BEGIN
    SELECT * FROM Roles
END
GO

-- Obtener Roles By Params
CREATE OR ALTER PROCEDURE sp_Obtener_Roles_By_Params @UserId INT
AS
BEGIN
    SELECT U.UsuarioID AS UsuarioId, R.Rol AS Rol
    FROM Usuarios AS U
             LEFT JOIN UsuarioRoles AS UR ON U.UsuarioID = UR.UsuarioID
             LEFT JOIN Roles AS R ON UR.RolID = R.RolID
    WHERE U.UsuarioID = @UserId
END
GO

-- Actualizar Rol
CREATE OR ALTER PROCEDURE sp_Actualizar_Rol @RolID INT,
                                            @Rol VARCHAR(255),
                                            @FechaModificacion DATETIME,
                                            @ModificadorID INT,
                                            @Activo BIT
AS
BEGIN
    UPDATE Roles
    SET Rol               = @Rol,
        FechaModificacion = @FechaModificacion,
        ModificadorID     = @ModificadorID,
        Activo            = @Activo
    WHERE RolID = @RolID
END
GO

----------------------------------------------------------------------------------------------

-- Insertar Usuario
CREATE OR ALTER PROCEDURE sp_Insertar_Usuario @Nombres VARCHAR(150),
                                              @Apellidos VARCHAR(150),
                                              @Usuario VARCHAR(100),
                                              @Contrasena VARCHAR(100),
                                              @Correo VARCHAR(255),
                                              @Telefono VARCHAR(25),
                                              @FechaCreacion DATETIME,
                                              @CreadorId INT
AS
BEGIN
    INSERT INTO Usuarios (Nombres, Apellidos, Usuario, Contrasena, Correo, Telefono, FechaCreacion, CreadorID, Activo)
    VALUES (@Nombres, @Apellidos, @Usuario, @Contrasena, @Correo, @Telefono, @FechaCreacion, @CreadorId, 1);
    SELECT SCOPE_IDENTITY();
END
GO

-- Obtener Usuarios
CREATE OR ALTER PROCEDURE sp_Obtener_Usuarios
AS
BEGIN
    SELECT * FROM Usuarios
END
GO

-- Obtener Usuario por Username
CREATE OR ALTER PROCEDURE sp_Obtener_Usuarios_username @Username NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Usuarios WHERE Usuario = @Username;
END
GO

-- Obtener Usuario por Username
CREATE OR ALTER PROCEDURE sp_Obtener_Usuarios_username_email @Username NVARCHAR(100), @Correo NVARCHAR(255)
AS
BEGIN
    SELECT * FROM Usuarios WHERE Usuario = @Username OR Correo = @Correo;
END
GO

-- Actualizar Usuario
CREATE OR ALTER PROCEDURE sp_Actualizar_Usuario @UsuarioID INT,
                                                @Nombres VARCHAR(150),
                                                @Apellidos VARCHAR(150),
                                                @Usuario VARCHAR(100),
                                                @Contrasena VARCHAR(100),
                                                @Correo VARCHAR(255),
                                                @Telefono VARCHAR(25),
                                                @FechaModificacion DATETIME,
                                                @ModificadorID INT,
                                                @Activo BIT
AS
BEGIN
    UPDATE Usuarios
    SET Nombres           = @Nombres,
        Apellidos         = @Apellidos,
        Usuario           = @Usuario,
        Contrasena        = @Contrasena,
        Correo            = @Correo,
        Telefono          = @Telefono,
        FechaModificacion = @FechaModificacion,
        ModificadorID     = @ModificadorID,
        Activo            = @Activo
    WHERE UsuarioID = @UsuarioID
END
GO

-------------------------------------------------------------------------------------------

-- Insertar UsuarioRol
CREATE OR ALTER PROCEDURE sp_Insertar_UsuarioRol @UsuarioID INT,
                                                 @RolID INT,
                                                 @CreadorID INT,
                                                 @Activo BIT
AS
BEGIN
    INSERT INTO UsuarioRoles (UsuarioID, RolID, FechaAsignacion, CreadorID, Activo)
    VALUES (@UsuarioID, @RolID, GETDATE(), @CreadorID, @Activo)
END
GO

-- Obtener UsuarioRoles
CREATE OR ALTER PROCEDURE sp_Obtener_UsuarioRoles
AS
BEGIN
    SELECT * FROM UsuarioRoles
END
GO

-- Actualizar UsuarioRol
CREATE OR ALTER PROCEDURE sp_Actualizar_UsuarioRol @UsuarioRolID INT,
                                                   @UsuarioID INT,
                                                   @RolID INT,
                                                   @Activo BIT
AS
BEGIN
    UPDATE UsuarioRoles
    SET UsuarioID = @UsuarioID,
        RolID     = @RolID,
        Activo    = @Activo
    WHERE UsuarioRolID = @UsuarioRolID
END
GO

----------------------------------------------------------------------------------------------------

-- Insertar Vehículo
CREATE OR ALTER PROCEDURE sp_Insertar_Vehiculo @Placa NVARCHAR(20),
                                               @Modelo NVARCHAR(100),
                                               @Capacidad INT,
                                               @FechaCreacion DATETIME,
                                               @CreadorId INT
AS
BEGIN
    INSERT INTO Vehiculos (Placa, Modelo, Capacidad, FechaCreacion, CreadorID, Activo)
    VALUES (@Placa, @Modelo, @Capacidad, @FechaCreacion, @CreadorId, 1);
    SELECT SCOPE_IDENTITY();
END
GO

-- Obtener Vehículos
CREATE OR ALTER PROCEDURE sp_Obtener_Vehiculos
AS
BEGIN
    SELECT * FROM Vehiculos
END
GO

-- Obtener Vehiculo por parámetros
CREATE OR ALTER PROCEDURE sp_Obtener_Vehiculo_By_Params @VehiculoId INT = NULL,
                                                        @Placa VARCHAR(20) = NULL,
                                                        @Modelo VARCHAR(100) = NULL
AS
BEGIN
    IF @VehiculoId IS NULL AND @Placa IS NULL AND @Modelo IS NULL
        BEGIN
            THROW 50005, N'Debe proporcionar al menos un parámetro: @VehiculoId, @Placa o @Modelo, al menos 1 no  puede ser NULL.', 1;
        END

    IF @VehiculoId IS NOT NULL
        SELECT * FROM Vehiculos WHERE VehiculoID = @VehiculoId
    ELSE
        IF @Placa IS NOT NULL
            SELECT * FROM Vehiculos WHERE Placa = @Placa
        ELSE
            SELECT * FROM Vehiculos WHERE Modelo = @Modelo
END
GO

-- Actualizar Vehículo
CREATE OR ALTER PROCEDURE sp_Actualizar_Vehiculo @VehiculoId INT,
                                                 @Placa NVARCHAR(20),
                                                 @Modelo NVARCHAR(100),
                                                 @Capacidad INT,
                                                 @FechaModificacion DATETIME,
                                                 @ModificadorId INT
AS
BEGIN
    UPDATE Vehiculos
    SET Placa             = @Placa,
        Modelo            = @Modelo,
        Capacidad         = @Capacidad,
        FechaModificacion = @FechaModificacion,
        ModificadorID     = @ModificadorId
    WHERE VehiculoID = @VehiculoId
END
GO

-- Eliminar o reactivar Vehículo
CREATE OR ALTER PROCEDURE sp_Eliminar_O_Reactivar_Vehiculo @VehiculoId INT,
                                                           @Activo BIT,
                                                           @FechaModificacion DATETIME,
                                                           @ModificadorId INT
AS
BEGIN
    UPDATE Vehiculos
    SET Activo            = @Activo,
        FechaModificacion = @FechaModificacion,
        ModificadorID     = @ModificadorId
    WHERE VehiculoID = @VehiculoId
END
GO

---------------------------------------------------------------------------------------------------

-- Insertar Ruta
CREATE OR ALTER PROCEDURE sp_Insertar_Ruta @LocacionOrigenId INT,
                                           @LocacionDestinoId INT,
                                           @DistanciaKm DECIMAL(18, 2),
                                           @TiempoEstimado TIME,
                                           @FechaCreacion DATETIME,
                                           @CreadorId INT
AS
BEGIN
    INSERT INTO Rutas (LocacionOrigenID, LocacionDestinoID, DistanciaKM, TiempoEstimado, FechaCreacion, CreadorID,
                       Activo)
    VALUES (@LocacionOrigenId, @LocacionDestinoId, @DistanciaKm, @TiempoEstimado, @FechaCreacion, @CreadorId, 1);
    SELECT SCOPE_IDENTITY();
END
GO

-- Obtener Rutas
CREATE OR ALTER PROCEDURE sp_Obtener_Rutas
AS
BEGIN
    SELECT r.RutaID,
           r.LocacionOrigenID,
           lo.Locacion AS LocacionOrigenNombre,
           r.LocacionDestinoID,
           ld.Locacion AS LocacionDestinoNombre,
           r.DistanciaKM,
           r.TiempoEstimado
    FROM Rutas r
             INNER JOIN Locaciones lo ON r.LocacionOrigenID = lo.DestinoID
             INNER JOIN Locaciones ld ON r.LocacionDestinoID = ld.DestinoID
END
GO

-- Obtener Ruta por parámetros
CREATE OR ALTER PROCEDURE sp_Obtener_Ruta_By_Params @RutaId INT = NULL,
                                                    @LocacionOrigenId INT = NULL,
                                                    @LocacionDestinoId INT = NULL
AS
BEGIN
    IF @RutaId IS NULL AND @LocacionOrigenId IS NULL AND @LocacionDestinoId IS NULL
        BEGIN
            THROW 50005, N'Debe proporcionar al menos un parámetro: @RutaId, @LocacionOrigenId o @LocacionDestinoId, al menos 1 no  puede ser NULL.', 1;
        END

    IF @RutaId IS NOT NULL
        SELECT * FROM Rutas WHERE RutaID = @RutaId
    ELSE
        IF @LocacionOrigenId IS NOT NULL
            SELECT * FROM Rutas WHERE LocacionOrigenID = @LocacionOrigenId
        ELSE
            SELECT * FROM Rutas WHERE LocacionDestinoID = @LocacionDestinoId
END
GO

-- Actualizar Ruta
CREATE OR ALTER PROCEDURE sp_Actualizar_Ruta @RutaId INT,
                                             @LocacionOrigenId INT,
                                             @LocacionDestinoId INT,
                                             @DistanciaKm DECIMAL(18, 2),
                                             @TiempoEstimado TIME,
                                             @FechaModificacion DATETIME,
                                             @ModificadorId INT
AS
BEGIN
    UPDATE Rutas
    SET LocacionOrigenID  = @LocacionOrigenId,
        LocacionDestinoID = @LocacionDestinoId,
        DistanciaKM       = @DistanciaKm,
        TiempoEstimado    = @TiempoEstimado,
        FechaModificacion = @FechaModificacion,
        ModificadorID     = @ModificadorId
    WHERE RutaID = @RutaId
END
GO

-- Eliminar o reactivar Ruta
CREATE OR ALTER PROCEDURE sp_Eliminar_O_Reactivar_Ruta @RutaId INT,
                                                       @Activo BIT,
                                                       @FechaModificacion DATETIME,
                                                       @ModificadorId INT
AS
BEGIN
    UPDATE Rutas
    SET Activo            = @Activo,
        FechaModificacion = @FechaModificacion,
        ModificadorID     = @ModificadorId
    WHERE RutaID = @RutaId
END
GO

--------------------------------------------------------------------------------------------------

-- Insertar Viaje
CREATE OR ALTER PROCEDURE sp_Insertar_Viaje @RutaId INT,
                                            @VehiculoId INT,
                                            @ConductorId INT,
                                            @Costo DECIMAL(18, 2),
                                            @FechaHoraSalida DATETIME,
                                            @FechaHoraLlegada DATETIME,
                                            @FechaCreacion DATETIME,
                                            @CreadorId INT,
                                            @EstadoId INT
AS
BEGIN
    INSERT INTO Viajes (RutaID, VehiculoID, Conductor, Costo, FechaHoraSalida, FechaHoraLlegada, FechaCreacion,
                        CreadorID, EstadoID)
    VALUES (@RutaId, @VehiculoId, @ConductorId, @Costo, @FechaHoraSalida, @FechaHoraLlegada, @FechaCreacion, @CreadorId,
            @EstadoId);
    SELECT SCOPE_IDENTITY();
END
GO

-- Obtener Viajes
CREATE OR ALTER PROCEDURE sp_Obtener_Viajes @ViajeId INT = NULL
AS
BEGIN
    SELECT v.ViajeID    AS ViajeId,
           v.RutaID     AS RutaId,
           v.VehiculoId AS VehiculoId,
           v.Conductor  AS ConductorId,
           v.Costo,
           v.FechaHoraSalida,
           v.FechaHoraLlegada,
           v.EstadoID   AS EstadoId,
           R.RutaID,
           R.LocacionOrigen,
           R.LocacionDestino,
           R.DistanciaKM,
           R.TiempoEstimado,
           VH.VehiculoID,
           VH.Placa,
           VH.Modelo,
           VH.Capacidad,
           C.ConductorID,
           C.Nombres,
           C.Apellidos,
           E.EstadoID,
           E.Estado
    FROM Viajes AS V
             INNER JOIN (SELECT ru.RutaID,
                                LO.Locacion AS LocacionOrigen,
                                LD.Locacion AS LocacionDestino,
                                RU.DistanciaKM,
                                RU.TiempoEstimado
                         FROM Rutas AS ru
                                  INNER JOIN Locaciones AS LO ON ru.LocacionOrigenID = LO.DestinoID
                                  INNER JOIN Locaciones AS LD ON ru.LocacionDestinoID = LD.DestinoID) AS R
                        ON v.RutaID = R.RutaID
             INNER JOIN (SELECT V.VehiculoID, V.Placa, V.Modelo, V.Capacidad FROM Vehiculos AS V) AS VH
                        ON V.VehiculoID = VH.VehiculoID
             INNER JOIN (SELECT U.UsuarioID AS ConductorID, U.Nombres, U.Apellidos FROM Usuarios AS U) AS C
                        ON V.Conductor = C.ConductorID
             INNER JOIN Estados AS E ON V.EstadoID = E.EstadoID
    WHERE @ViajeId IS NULL
       OR V.ViajeID = @ViajeId

END
GO

-- Actualizar Viaje
CREATE OR ALTER PROCEDURE sp_Actualizar_Viaje @ViajeID INT,
                                              @RutaID INT,
                                              @VehiculoID INT,
                                              @Conductor INT,
                                              @Costo DECIMAL(18, 2),
                                              @FechaHoraSalida DATETIME,
                                              @FechaHoraLlegada DATETIME,
                                              @FechaModificacion DATETIME,
                                              @ModificadorID INT,
                                              @EstadoID INT
AS
BEGIN
    UPDATE Viajes
    SET RutaID            = @RutaID,
        VehiculoID        = @VehiculoID,
        Conductor         = @Conductor,
        Costo             = @Costo,
        FechaHoraSalida   = @FechaHoraSalida,
        FechaHoraLlegada  = @FechaHoraLlegada,
        FechaModificacion = @FechaModificacion,
        ModificadorID     = @ModificadorID,
        EstadoID          = @EstadoID
    WHERE ViajeID = @ViajeID
END
GO

-------------------------------------------------------------------------------------------------------

-- Insertar Reserva
CREATE OR ALTER PROCEDURE sp_Insertar_Reserva @ViajeId INT,
                                              @ClienteId INT,
                                              @FechaReserva DATETIME,
                                              @FechaCreacion DATETIME,
                                              @CreadorID INT,
                                              @EstadoId INT
AS
BEGIN
    INSERT INTO Reservas (ViajeID, ClienteID, FechaReserva, FechaCreacion, CreadorID, EstadoID)
    VALUES (@ViajeId, @ClienteId, @FechaReserva, @FechaCreacion, @CreadorID, @EstadoID);
    SELECT SCOPE_IDENTITY();
END
GO

-- sp_Obtener_Reservas_By_Params
CREATE OR ALTER PROCEDURE sp_Obtener_Reservas_By_Params @UserId INT
AS
BEGIN
    SELECT R.ReservaID AS ReservaId, R.ViajeID AS ViajeId, R.FechaReserva, DR.NumeroAsiento
    FROM Reservas AS R
             INNER JOIN dbo.DetalleReservas DR ON R.ReservaID = DR.ReservaID
    WHERE R.ClienteID = @UserId
END
GO

-- Actualizar Reserva
CREATE OR ALTER PROCEDURE sp_Actualizar_Reserva @ReservaID INT,
                                                @ViajeID INT,
                                                @ClienteID INT,
                                                @FechaReserva DATETIME,
                                                @FechaModificacion DATETIME,
                                                @ModificadorID INT,
                                                @EstadoID INT
AS
BEGIN
    UPDATE Reservas
    SET ViajeID           = @ViajeID,
        ClienteID         = @ClienteID,
        FechaReserva      = @FechaReserva,
        FechaModificacion = @FechaModificacion,
        ModificadorID     = @ModificadorID,
        EstadoID          = @EstadoID
    WHERE ReservaID = @ReservaID
END
GO

-------------------------------------------------------------------------------------------------------

-- Insertar DetalleReserva
CREATE OR ALTER PROCEDURE sp_Insertar_DetalleReserva @ReservaId INT,
                                                     @NumeroAsiento INT
AS
BEGIN
    INSERT INTO DetalleReservas (ReservaID, NumeroAsiento)
    VALUES (@ReservaID, @NumeroAsiento);
    SELECT SCOPE_IDENTITY();
END
GO

-- Obtener DetalleReservas
CREATE OR ALTER PROCEDURE sp_Obtener_DetalleReservas
AS
BEGIN
    SELECT * FROM DetalleReservas
END
GO

-- Obtener DetalleReservas by Params
CREATE OR ALTER PROCEDURE sp_Obtener_DetalleReservas_By_Params @ViajeId INT
AS
BEGIN
    SELECT V.ViajeID AS ViajeId, Vh.Capacidad AS Capacidad, DR.NumeroAsiento AS AsientosReservados
    FROM Viajes AS V
             INNER JOIN Vehiculos AS VH ON V.VehiculoID = VH.VehiculoID
             LEFT JOIN Reservas AS R ON V.ViajeID = R.ViajeID
             LEFT JOIN DetalleReservas AS DR ON R.ReservaID = DR.ReservaID
    WHERE V.ViajeID = @ViajeId
END
GO


-- Actualizar DetalleReserva
CREATE OR ALTER PROCEDURE sp_Actualizar_DetalleReserva @DetalleReservaID INT,
                                                       @ReservaID INT,
                                                       @NumeroAsiento INT
AS
BEGIN
    UPDATE DetalleReservas
    SET ReservaID     = @ReservaID,
        NumeroAsiento = @NumeroAsiento
    WHERE DetalleReservaID = @DetalleReservaID
END
GO

-----------------------------------------------------------------------------------

-- Insertar MetodoPago
CREATE OR ALTER PROCEDURE sp_Insertar_MetodoPago @MetodoPago VARCHAR(50),
                                                 @FechaCreacion DATETIME,
                                                 @FechaModificacion DATETIME,
                                                 @CreadorID INT,
                                                 @ModificadorID INT,
                                                 @Activo BIT
AS
BEGIN
    INSERT INTO MetodosPago (MetodoPago, FechaCreacion, FechaModificacion, CreadorID, ModificadorID, Activo)
    VALUES (@MetodoPago, @FechaCreacion, @FechaModificacion, @CreadorID, @ModificadorID, @Activo)
END
GO

-- Obtener MetodosPago
CREATE OR ALTER PROCEDURE sp_Obtener_MetodosPago
AS
BEGIN
    SELECT * FROM MetodosPago
END
GO

-- Actualizar MetodoPago
CREATE OR ALTER PROCEDURE sp_Actualizar_MetodoPago @MetodoPagoID INT,
                                                   @MetodoPago VARCHAR(50),
                                                   @FechaModificacion DATETIME,
                                                   @ModificadorID INT,
                                                   @Activo BIT
AS
BEGIN
    UPDATE MetodosPago
    SET MetodoPago        = @MetodoPago,
        FechaModificacion = @FechaModificacion,
        ModificadorID     = @ModificadorID,
        Activo            = @Activo
    WHERE MetodoPagoID = @MetodoPagoID
END
GO

------------------------------------------------------------------------------------

-- Insertar MetodoPagoUsuario
CREATE OR ALTER PROCEDURE sp_Insertar_MetodoPagoUsuario @MetodoPagoID INT,
                                                        @UsuarioID INT,
                                                        @Referencia VARCHAR(50),
                                                        @FechaCreacion DATETIME,
                                                        @FechaModificacion DATETIME,
                                                        @CreadorID INT,
                                                        @ModificadorID INT,
                                                        @Activo BIT
AS
BEGIN
    INSERT INTO MetodosPagoUsuario (MetodoPagoID, UsuarioID, Referencia, FechaCreacion, FechaModificacion, CreadorID,
                                    ModificadorID, Activo)
    VALUES (@MetodoPagoID, @UsuarioID, @Referencia, @FechaCreacion, @FechaModificacion, @CreadorID, @ModificadorID,
            @Activo)
END
GO

-- Obtener MetodosPagoUsuario
CREATE OR ALTER PROCEDURE sp_Obtener_MetodosPagoUsuario
AS
BEGIN
    SELECT * FROM MetodosPagoUsuario
END
GO

-- Actualizar MetodoPagoUsuario
CREATE OR ALTER PROCEDURE sp_Actualizar_MetodoPagoUsuario @MetodoPagoUsuarioID INT,
                                                          @MetodoPagoID INT,
                                                          @UsuarioID INT,
                                                          @Referencia VARCHAR(50),
                                                          @FechaModificacion DATETIME,
                                                          @ModificadorID INT,
                                                          @Activo BIT
AS
BEGIN
    UPDATE MetodosPagoUsuario
    SET MetodoPagoID      = @MetodoPagoID,
        UsuarioID         = @UsuarioID,
        Referencia        = @Referencia,
        FechaModificacion = @FechaModificacion,
        ModificadorID     = @ModificadorID,
        Activo            = @Activo
    WHERE MetodoPagoUsuarioID = @MetodoPagoUsuarioID
END
GO

-----------------------------------------------------------------------------

-- Insertar Pago
CREATE OR ALTER PROCEDURE sp_Insertar_Pago @ReservaID INT,
                                           @FechaPago DATETIME,
                                           @Monto DECIMAL(10, 2),
                                           @MetodoPagoUsuarioID INT,
                                           @FechaCreacion DATETIME,
                                           @FechaModificacion DATETIME,
                                           @CreadorID INT,
                                           @ModificadorID INT,
                                           @EstadoID INT
AS
BEGIN
    INSERT INTO Pagos (ReservaID, FechaPago, Monto, MetodoPagoUsuarioID, FechaCreacion, FechaModificacion,
                       CreadorID, ModificadorID, EstadoID)
    VALUES (@ReservaID, @FechaPago, @Monto, @MetodoPagoUsuarioID, @FechaCreacion, @FechaModificacion,
            @CreadorID, @ModificadorID, @EstadoID)
END
GO

-- Obtener Pagos
CREATE OR ALTER PROCEDURE sp_Obtener_Pagos
AS
BEGIN
    SELECT * FROM Pagos
END
GO

-- Actualizar Pago
CREATE OR ALTER PROCEDURE sp_Actualizar_Pago @PagoID INT,
                                             @ReservaID INT,
                                             @FechaPago DATETIME,
                                             @Monto DECIMAL(10, 2),
                                             @MetodoPagoUsuarioID INT,
                                             @FechaModificacion DATETIME,
                                             @ModificadorID INT,
                                             @EstadoID INT
AS
BEGIN
    UPDATE Pagos
    SET ReservaID           = @ReservaID,
        FechaPago           = @FechaPago,
        Monto               = @Monto,
        MetodoPagoUsuarioID = @MetodoPagoUsuarioID,
        FechaModificacion   = @FechaModificacion,
        ModificadorID       = @ModificadorID,
        EstadoID            = @EstadoID
    WHERE PagoID = @PagoID
END
GO
