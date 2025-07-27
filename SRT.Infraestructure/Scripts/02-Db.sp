-- Insertar Estado
CREATE PROCEDURE sp_Insertar_Estado
    @Estado VARCHAR(100),
    @FechaCreacion DATETIME,
    @FechaModificacion DATETIME,
    @CreadorID INT,
    @ModificadorID INT,
    @Activo BIT
AS
BEGIN
    INSERT INTO Estados (Estado, FechaCreacion, FechaModificacion, CreadorID, ModificadorID, Activo)
    VALUES (@Estado, @FechaCreacion, @FechaModificacion, @CreadorID, @ModificadorID, @Activo)
END
GO

-- Obtener Estados
CREATE PROCEDURE sp_Obtener_Estados
AS
BEGIN
    SELECT * FROM Estados
END
GO

-- Actualizar Estado
CREATE PROCEDURE sp_Actualizar_Estado
    @EstadoID INT,
    @Estado VARCHAR(100),
    @FechaModificacion DATETIME,
    @ModificadorID INT,
    @Activo BIT
AS
BEGIN
    UPDATE Estados
    SET Estado = @Estado,
        FechaModificacion = @FechaModificacion,
        ModificadorID = @ModificadorID,
        Activo = @Activo
    WHERE EstadoID = @EstadoID
END
GO

-- Eliminar Estado
CREATE PROCEDURE sp_Eliminar_Estado
    @EstadoID INT
AS
BEGIN
    DELETE FROM Estados WHERE EstadoID = @EstadoID
END
GO
------------------------------------------------------------------------------------------------------------------------

-- Insertar País
CREATE PROCEDURE sp_Insertar_Pais
    @Pais VARCHAR(100),
    @FechaCreacion DATETIME,
    @FechaModificacion DATETIME,
    @CreadorID INT,
    @ModificadorID INT,
    @Activo BIT
AS
BEGIN
    INSERT INTO Pais (Pais, FechaCreacion, FechaModificacion, CreadorID, ModificadorID, Activo)
    VALUES (@Pais, @FechaCreacion, @FechaModificacion, @CreadorID, @ModificadorID, @Activo)
END
GO

-- Obtener Países
CREATE PROCEDURE sp_Obtener_Paises
AS
BEGIN
    SELECT * FROM Pais
END
GO

-- Actualizar País
CREATE PROCEDURE sp_Actualizar_Pais
    @PaisID INT,
    @Pais VARCHAR(100),
    @FechaModificacion DATETIME,
    @ModificadorID INT,
    @Activo BIT
AS
BEGIN
    UPDATE Pais
    SET Pais = @Pais,
        FechaModificacion = @FechaModificacion,
        ModificadorID = @ModificadorID,
        Activo = @Activo
    WHERE PaisID = @PaisID
END
GO

-- Eliminar País
CREATE PROCEDURE sp_Eliminar_Pais
    @PaisID INT
AS
BEGIN
    DELETE FROM Pais WHERE PaisID = @PaisID
END
GO
------------------------------------------------------------------------------------------------------

-- Insertar Departamento
CREATE PROCEDURE sp_Insertar_Departamento
    @PaisID INT,
    @Departamento VARCHAR(100),
    @FechaCreacion DATETIME,
    @FechaModificacion DATETIME,
    @CreadorID INT,
    @ModificadorID INT,
    @Activo BIT
AS
BEGIN
    INSERT INTO Departamentos (PaisID, Departamento, FechaCreacion, FechaModificacion, CreadorID, ModificadorID, Activo)
    VALUES (@PaisID, @Departamento, @FechaCreacion, @FechaModificacion, @CreadorID, @ModificadorID, @Activo)
END
GO

-- Obtener Departamentos
CREATE PROCEDURE sp_Obtener_Departamentos
AS
BEGIN
    SELECT * FROM Departamentos
END
GO

-- Actualizar Departamento
CREATE PROCEDURE sp_Actualizar_Departamento
    @DepartamentoID INT,
    @PaisID INT,
    @Departamento VARCHAR(100),
    @FechaModificacion DATETIME,
    @ModificadorID INT,
    @Activo BIT
AS
BEGIN
    UPDATE Departamentos
    SET PaisID = @PaisID,
        Departamento = @Departamento,
        FechaModificacion = @FechaModificacion,
        ModificadorID = @ModificadorID,
        Activo = @Activo
    WHERE DepartamentoID = @DepartamentoID
END
GO

-- Eliminar Departamento
CREATE PROCEDURE sp_Eliminar_Departamento
    @DepartamentoID INT
AS
BEGIN
    DELETE FROM Departamentos WHERE DepartamentoID = @DepartamentoID
END
GO
--------------------------------------------------------------------------------------------
-- Insertar Locación
CREATE PROCEDURE sp_Insertar_Locacion
    @DepartamentoID INT,
    @Locacion VARCHAR(255),
    @FechaCreacion DATETIME,
    @FechaModificacion DATETIME,
    @CreadorID INT,
    @ModificadorID INT,
    @Activo BIT
AS
BEGIN
    INSERT INTO Locaciones (DepartamentoID, Locacion, FechaCreacion, FechaModificacion, CreadorID, ModificadorID, Activo)
    VALUES (@DepartamentoID, @Locacion, @FechaCreacion, @FechaModificacion, @CreadorID, @ModificadorID, @Activo)
END
GO

-- Obtener Locaciones
CREATE PROCEDURE sp_Obtener_Locaciones
AS
BEGIN
    SELECT * FROM Locaciones
END
GO

-- Actualizar Locación
CREATE PROCEDURE sp_Actualizar_Locacion
    @DestinoID INT,
    @DepartamentoID INT,
    @Locacion VARCHAR(255),
    @FechaModificacion DATETIME,
    @ModificadorID INT,
    @Activo BIT
AS
BEGIN
    UPDATE Locaciones
    SET DepartamentoID = @DepartamentoID,
        Locacion = @Locacion,
        FechaModificacion = @FechaModificacion,
        ModificadorID = @ModificadorID,
        Activo = @Activo
    WHERE DestinoID = @DestinoID
END
GO

-- Eliminar Locación
CREATE PROCEDURE sp_Eliminar_Locacion
    @DestinoID INT
AS
BEGIN
    DELETE FROM Locaciones WHERE DestinoID = @DestinoID
END
GO
-------------------------------------------------------------------------------------------------
-- Insertar Rol
CREATE PROCEDURE sp_Insertar_Rol
    @Rol VARCHAR(255),
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
CREATE PROCEDURE sp_Obtener_Roles
AS
BEGIN
    SELECT * FROM Roles
END
GO

-- Actualizar Rol
CREATE PROCEDURE sp_Actualizar_Rol
    @RolID INT,
    @Rol VARCHAR(255),
    @FechaModificacion DATETIME,
    @ModificadorID INT,
    @Activo BIT
AS
BEGIN
    UPDATE Roles
    SET Rol = @Rol,
        FechaModificacion = @FechaModificacion,
        ModificadorID = @ModificadorID,
        Activo = @Activo
    WHERE RolID = @RolID
END
GO

-- Eliminar Rol
CREATE PROCEDURE sp_Eliminar_Rol
    @RolID INT
AS
BEGIN
    DELETE FROM Roles WHERE RolID = @RolID
END
GO
----------------------------------------------------------------------------------------------
-- Insertar Usuario
CREATE PROCEDURE sp_Insertar_Usuario
    @Nombres VARCHAR(150),
    @Apellidos VARCHAR(150),
    @Usuario VARCHAR(100),
    @Contrasena VARCHAR(100),
    @Correo VARCHAR(255),
    @Telefono VARCHAR(25),
    @FechaCreacion DATETIME,
    @FechaModificacion DATETIME,
    @CreadorID INT,
    @ModificadorID INT,
    @Activo BIT
AS
BEGIN
    INSERT INTO Usuarios (Nombres, Apellidos, Usuario, Contrasena, Correo, Telefono, FechaCreacion, FechaModificacion, CreadorID, ModificadorID, Activo)
    VALUES (@Nombres, @Apellidos, @Usuario, @Contrasena, @Correo, @Telefono, @FechaCreacion, @FechaModificacion, @CreadorID, @ModificadorID, @Activo)
END
GO

-- Obtener Usuarios
CREATE PROCEDURE sp_Obtener_Usuarios
AS
BEGIN
    SELECT * FROM Usuarios
END
GO

-- Actualizar Usuario
CREATE PROCEDURE sp_Actualizar_Usuario
    @UsuarioID INT,
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
    SET Nombres = @Nombres,
        Apellidos = @Apellidos,
        Usuario = @Usuario,
        Contrasena = @Contrasena,
        Correo = @Correo,
        Telefono = @Telefono,
        FechaModificacion = @FechaModificacion,
        ModificadorID = @ModificadorID,
        Activo = @Activo
    WHERE UsuarioID = @UsuarioID
END
GO

-- Eliminar Usuario
CREATE PROCEDURE sp_Eliminar_Usuario
    @UsuarioID INT
AS
BEGIN
    DELETE FROM Usuarios WHERE UsuarioID = @UsuarioID
END
GO
-------------------------------------------------------------------------------------------
-- Insertar UsuarioRol
CREATE PROCEDURE sp_Insertar_UsuarioRol
    @UsuarioID INT,
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
CREATE PROCEDURE sp_Obtener_UsuarioRoles
AS
BEGIN
    SELECT * FROM UsuarioRoles
END
GO

-- Actualizar UsuarioRol
CREATE PROCEDURE sp_Actualizar_UsuarioRol
    @UsuarioRolID INT,
    @UsuarioID INT,
    @RolID INT,
    @Activo BIT
AS
BEGIN
    UPDATE UsuarioRoles
    SET UsuarioID = @UsuarioID,
        RolID = @RolID,
        Activo = @Activo
    WHERE UsuarioRolID = @UsuarioRolID
END
GO

-- Eliminar UsuarioRol
CREATE PROCEDURE sp_Eliminar_UsuarioRol
    @UsuarioRolID INT
AS
BEGIN
    DELETE FROM UsuarioRoles WHERE UsuarioRolID = @UsuarioRolID
END
GO
----------------------------------------------------------------------------------------------------
-- Insertar Vehículo
CREATE PROCEDURE sp_Insertar_Vehiculo
    @Placa NVARCHAR(20),
    @Modelo NVARCHAR(100),
    @Capacidad INT,
    @FechaCreacion DATETIME,
    @FechaModificacion DATETIME,
    @CreadorID INT,
    @ModificadorID INT,
    @Activo BIT
AS
BEGIN
    INSERT INTO Vehiculos (Placa, Modelo, Capacidad, FechaCreacion, FechaModificacion, CreadorID, ModificadorID, Activo)
    VALUES (@Placa, @Modelo, @Capacidad, @FechaCreacion, @FechaModificacion, @CreadorID, @ModificadorID, @Activo)
END
GO

-- Obtener Vehículos
CREATE PROCEDURE sp_Obtener_Vehiculos
AS
BEGIN
    SELECT * FROM Vehiculos
END
GO

-- Actualizar Vehículo
CREATE PROCEDURE sp_Actualizar_Vehiculo
    @VehiculoID INT,
    @Placa NVARCHAR(20),
    @Modelo NVARCHAR(100),
    @Capacidad INT,
    @FechaModificacion DATETIME,
    @ModificadorID INT,
    @Activo BIT
AS
BEGIN
    UPDATE Vehiculos
    SET Placa = @Placa,
        Modelo = @Modelo,
        Capacidad = @Capacidad,
        FechaModificacion = @FechaModificacion,
        ModificadorID = @ModificadorID,
        Activo = @Activo
    WHERE VehiculoID = @VehiculoID
END
GO

-- Eliminar Vehículo
CREATE PROCEDURE sp_Eliminar_Vehiculo
    @VehiculoID INT
AS
BEGIN
    DELETE FROM Vehiculos WHERE VehiculoID = @VehiculoID
END
GO
---------------------------------------------------------------------------------------------------
-- Insertar Ruta
CREATE PROCEDURE sp_Insertar_Ruta
    @LocacionOrigenID INT,
    @LocacionDestinoID INT,
    @DistanciaKM DECIMAL(18,2),
    @TiempoEstimado TIME,
    @FechaCreacion DATETIME,
    @FechaModificacion DATETIME,
    @CreadorID INT,
    @ModificadorID INT,
    @Activo BIT
AS
BEGIN
    INSERT INTO Rutas (LocacionOrigenID, LocacionDestinoID, DistanciaKM, TiempoEstimado, FechaCreacion, FechaModificacion, CreadorID, ModificadorID, Activo)
    VALUES (@LocacionOrigenID, @LocacionDestinoID, @DistanciaKM, @TiempoEstimado, @FechaCreacion, @FechaModificacion, @CreadorID, @ModificadorID, @Activo)
END
GO

-- Obtener Rutas
CREATE PROCEDURE sp_Obtener_Rutas
AS
BEGIN
    SELECT * FROM Rutas
END
GO

-- Actualizar Ruta
CREATE PROCEDURE sp_Actualizar_Ruta
    @RutaID INT,
    @LocacionOrigenID INT,
    @LocacionDestinoID INT,
    @DistanciaKM DECIMAL(18,2),
    @TiempoEstimado TIME,
    @FechaModificacion DATETIME,
    @ModificadorID INT,
    @Activo BIT
AS
BEGIN
    UPDATE Rutas
    SET LocacionOrigenID = @LocacionOrigenID,
        LocacionDestinoID = @LocacionDestinoID,
        DistanciaKM = @DistanciaKM,
        TiempoEstimado = @TiempoEstimado,
        FechaModificacion = @FechaModificacion,
        ModificadorID = @ModificadorID,
        Activo = @Activo
    WHERE RutaID = @RutaID
END
GO

-- Eliminar Ruta
CREATE PROCEDURE sp_Eliminar_Ruta
    @RutaID INT
AS
BEGIN
    DELETE FROM Rutas WHERE RutaID = @RutaID
END
GO
--------------------------------------------------------------------------------------------------
-- Insertar Viaje
CREATE PROCEDURE sp_Insertar_Viaje
    @RutaID INT,
    @VehiculoID INT,
    @Conductor INT,
    @Costo DECIMAL(18,2),
    @FechaHoraSalida DATETIME,
    @FechaHoraLlegada DATETIME,
    @FechaCreacion DATETIME,
    @FechaModificacion DATETIME,
    @CreadorID INT,
    @ModificadorID INT,
    @EstadoID INT
AS
BEGIN
    INSERT INTO Viajes (RutaID, VehiculoID, Conductor, Costo, FechaHoraSalida, FechaHoraLlegada,
                        FechaCreacion, FechaModificacion, CreadorID, ModificadorID, EstadoID)
    VALUES (@RutaID, @VehiculoID, @Conductor, @Costo, @FechaHoraSalida, @FechaHoraLlegada,
            @FechaCreacion, @FechaModificacion, @CreadorID, @ModificadorID, @EstadoID)
END
GO

-- Obtener Viajes
CREATE PROCEDURE sp_Obtener_Viajes
AS
BEGIN
    SELECT * FROM Viajes
END
GO

-- Actualizar Viaje
CREATE PROCEDURE sp_Actualizar_Viaje
    @ViajeID INT,
    @RutaID INT,
    @VehiculoID INT,
    @Conductor INT,
    @Costo DECIMAL(18,2),
    @FechaHoraSalida DATETIME,
    @FechaHoraLlegada DATETIME,
    @FechaModificacion DATETIME,
    @ModificadorID INT,
    @EstadoID INT
AS
BEGIN
    UPDATE Viajes
    SET RutaID = @RutaID,
        VehiculoID = @VehiculoID,
        Conductor = @Conductor,
        Costo = @Costo,
        FechaHoraSalida = @FechaHoraSalida,
        FechaHoraLlegada = @FechaHoraLlegada,
        FechaModificacion = @FechaModificacion,
        ModificadorID = @ModificadorID,
        EstadoID = @EstadoID
    WHERE ViajeID = @ViajeID
END
GO

-- Eliminar Viaje
CREATE PROCEDURE sp_Eliminar_Viaje
    @ViajeID INT
AS
BEGIN
    DELETE FROM Viajes WHERE ViajeID = @ViajeID
END
GO
-------------------------------------------------------------------------------------------------------
-- Insertar Reserva
CREATE PROCEDURE sp_Insertar_Reserva
    @ViajeID INT,
    @ClienteID INT,
    @FechaReserva DATETIME,
    @FechaCreacion DATETIME,
    @FechaModificacion DATETIME,
    @CreadorID INT,
    @ModificadorID INT,
    @EstadoID INT
AS
BEGIN
    INSERT INTO Reservas (ViajeID, ClienteID, FechaReserva, FechaCreacion, FechaModificacion,
                          CreadorID, ModificadorID, EstadoID)
    VALUES (@ViajeID, @ClienteID, @FechaReserva, @FechaCreacion, @FechaModificacion,
            @CreadorID, @ModificadorID, @EstadoID)
END
GO

-- Obtener Reservas
CREATE PROCEDURE sp_Obtener_Reservas
AS
BEGIN
    SELECT * FROM Reservas
END
GO

-- Actualizar Reserva
CREATE PROCEDURE sp_Actualizar_Reserva
    @ReservaID INT,
    @ViajeID INT,
    @ClienteID INT,
    @FechaReserva DATETIME,
    @FechaModificacion DATETIME,
    @ModificadorID INT,
    @EstadoID INT
AS
BEGIN
    UPDATE Reservas
    SET ViajeID = @ViajeID,
        ClienteID = @ClienteID,
        FechaReserva = @FechaReserva,
        FechaModificacion = @FechaModificacion,
        ModificadorID = @ModificadorID,
        EstadoID = @EstadoID
    WHERE ReservaID = @ReservaID
END
GO

-- Eliminar Reserva
CREATE PROCEDURE sp_Eliminar_Reserva
    @ReservaID INT
AS
BEGIN
    DELETE FROM Reservas WHERE ReservaID = @ReservaID
END
GO
-------------------------------------------------------------------------------------------------------
-- Insertar DetalleReserva
CREATE PROCEDURE sp_Insertar_DetalleReserva
    @ReservaID INT,
    @NumeroAsiento INT
AS
BEGIN
    INSERT INTO DetalleReservas (ReservaID, NumeroAsiento)
    VALUES (@ReservaID, @NumeroAsiento)
END
GO

-- Obtener DetalleReservas
CREATE PROCEDURE sp_Obtener_DetalleReservas
AS
BEGIN
    SELECT * FROM DetalleReservas
END
GO

-- Actualizar DetalleReserva
CREATE PROCEDURE sp_Actualizar_DetalleReserva
    @DetalleReservaID INT,
    @ReservaID INT,
    @NumeroAsiento INT
AS
BEGIN
    UPDATE DetalleReservas
    SET ReservaID = @ReservaID,
        NumeroAsiento = @NumeroAsiento
    WHERE DetalleReservaID = @DetalleReservaID
END
GO

-- Eliminar DetalleReserva
CREATE PROCEDURE sp_Eliminar_DetalleReserva
    @DetalleReservaID INT
AS
BEGIN
    DELETE FROM DetalleReservas WHERE DetalleReservaID = @DetalleReservaID
END
GO
-----------------------------------------------------------------------------------
-- Insertar MetodoPago
CREATE PROCEDURE sp_Insertar_MetodoPago
    @MetodoPago VARCHAR(50),
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
CREATE PROCEDURE sp_Obtener_MetodosPago
AS
BEGIN
    SELECT * FROM MetodosPago
END
GO

-- Actualizar MetodoPago
CREATE PROCEDURE sp_Actualizar_MetodoPago
    @MetodoPagoID INT,
    @MetodoPago VARCHAR(50),
    @FechaModificacion DATETIME,
    @ModificadorID INT,
    @Activo BIT
AS
BEGIN
    UPDATE MetodosPago
    SET MetodoPago = @MetodoPago,
        FechaModificacion = @FechaModificacion,
        ModificadorID = @ModificadorID,
        Activo = @Activo
    WHERE MetodoPagoID = @MetodoPagoID
END
GO

-- Eliminar MetodoPago
CREATE PROCEDURE sp_Eliminar_MetodoPago
    @MetodoPagoID INT
AS
BEGIN
    DELETE FROM MetodosPago WHERE MetodoPagoID = @MetodoPagoID
END
GO
------------------------------------------------------------------------------------
-- Insertar MetodoPagoUsuario
CREATE PROCEDURE sp_Insertar_MetodoPagoUsuario
    @MetodoPagoID INT,
    @UsuarioID INT,
    @Referencia VARCHAR(50),
    @FechaCreacion DATETIME,
    @FechaModificacion DATETIME,
    @CreadorID INT,
    @ModificadorID INT,
    @Activo BIT
AS
BEGIN
    INSERT INTO MetodosPagoUsuario (MetodoPagoID, UsuarioID, Referencia, FechaCreacion, FechaModificacion, CreadorID, ModificadorID, Activo)
    VALUES (@MetodoPagoID, @UsuarioID, @Referencia, @FechaCreacion, @FechaModificacion, @CreadorID, @ModificadorID, @Activo)
END
GO

-- Obtener MetodosPagoUsuario
CREATE PROCEDURE sp_Obtener_MetodosPagoUsuario
AS
BEGIN
    SELECT * FROM MetodosPagoUsuario
END
GO

-- Actualizar MetodoPagoUsuario
CREATE PROCEDURE sp_Actualizar_MetodoPagoUsuario
    @MetodoPagoUsuarioID INT,
    @MetodoPagoID INT,
    @UsuarioID INT,
    @Referencia VARCHAR(50),
    @FechaModificacion DATETIME,
    @ModificadorID INT,
    @Activo BIT
AS
BEGIN
    UPDATE MetodosPagoUsuario
    SET MetodoPagoID = @MetodoPagoID,
        UsuarioID = @UsuarioID,
        Referencia = @Referencia,
        FechaModificacion = @FechaModificacion,
        ModificadorID = @ModificadorID,
        Activo = @Activo
    WHERE MetodoPagoUsuarioID = @MetodoPagoUsuarioID
END
GO

-- Eliminar MetodoPagoUsuario
CREATE PROCEDURE sp_Eliminar_MetodoPagoUsuario
    @MetodoPagoUsuarioID INT
AS
BEGIN
    DELETE FROM MetodosPagoUsuario WHERE MetodoPagoUsuarioID = @MetodoPagoUsuarioID
END
GO
-----------------------------------------------------------------------------
-- Insertar Pago
CREATE PROCEDURE sp_Insertar_Pago
    @ReservaID INT,
    @FechaPago DATETIME,
    @Monto DECIMAL(10,2),
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
CREATE PROCEDURE sp_Obtener_Pagos
AS
BEGIN
    SELECT * FROM Pagos
END
GO

-- Actualizar Pago
CREATE PROCEDURE sp_Actualizar_Pago
    @PagoID INT,
    @ReservaID INT,
    @FechaPago DATETIME,
    @Monto DECIMAL(10,2),
    @MetodoPagoUsuarioID INT,
    @FechaModificacion DATETIME,
    @ModificadorID INT,
    @EstadoID INT
AS
BEGIN
    UPDATE Pagos
    SET ReservaID = @ReservaID,
        FechaPago = @FechaPago,
        Monto = @Monto,
        MetodoPagoUsuarioID = @MetodoPagoUsuarioID,
        FechaModificacion = @FechaModificacion,
        ModificadorID = @ModificadorID,
        EstadoID = @EstadoID
    WHERE PagoID = @PagoID
END
GO

-- Eliminar Pago
CREATE PROCEDURE sp_Eliminar_Pago
    @PagoID INT
AS
BEGIN
    DELETE FROM Pagos WHERE PagoID = @PagoID
END
GO
