INSERT INTO Estados (Estado, FechaCreacion, FechaModificacion, CreadorID, ModificadorID, Activo)
VALUES 
('Programado', GETDATE(), GETDATE(), 1, 1, 1),
('En curso', GETDATE(), GETDATE(), 1, 1, 1),
('Finalizado', GETDATE(), GETDATE(), 1, 1, 1),
('Cancelado', GETDATE(), GETDATE(), 1, 1, 1);

INSERT INTO Pais (Pais, FechaCreacion, FechaModificacion, CreadorID, ModificadorID, Activo)
VALUES ('Nicaragua', GETDATE(), GETDATE(), 1, 1, 1);

INSERT INTO Departamentos (PaisID, Departamento, FechaCreacion, FechaModificacion, CreadorID, ModificadorID, Activo)
VALUES 
(1, 'Managua', GETDATE(), GETDATE(), 1, 1, 1),
(1, 'León', GETDATE(), GETDATE(), 1, 1, 1);

INSERT INTO Locaciones (DepartamentoID, Locacion, FechaCreacion, FechaModificacion, CreadorID, ModificadorID, Activo)
VALUES 
(1, 'Terminal UCA', GETDATE(), GETDATE(), 1, 1, 1),
(2, 'Parque Central León', GETDATE(), GETDATE(), 1, 1, 1);

INSERT INTO Roles (Rol, FechaCreacion, FechaModificacion, CreadorID, ModificadorID, Activo)
VALUES 
('Administrador', GETDATE(), GETDATE(), 1, 1, 1),
('Cliente', GETDATE(), GETDATE(), 1, 1, 1);


INSERT INTO Usuarios (
    Nombres, Apellidos, Usuario, Contrasena, Correo, Telefono, RolID,
    FechaCreacion, FechaModificacion, CreadorID, ModificadorID, Activo
)
VALUES 
('Isidro', 'Potoy', 'ipotoy', 'admin123', 'isidro.potoy@gmail.com', '8496-4605', 1, GETDATE(), GETDATE(), 1, 1, 1),
('Moises', 'Navarrete', 'mnavarrete', 'cliente123', 'moises@gmail.com', '8465-7589', 2, GETDATE(), GETDATE(), 1, 1, 1);


INSERT INTO Vehiculos (Placa, Modelo, Capacidad, FechaCreacion, FechaModificacion, CreadorID, ModificadorID, Activo)
VALUES ('M123456', 'Toyota Hiace', 15, GETDATE(), GETDATE(), 1, 1, 1),
        ('M756878','Toyota ', 15, GETDATE(), GETDATE(), 1, 1, 1);

INSERT INTO Rutas (
    LocacionOrigenID, LocacionDestinoID, DistanciaKM, TiempoEstimado,
    FechaCreacion, FechaModificacion, CreadorID, ModificadorID, Activo
)
VALUES 
(1, 2, 90.5, '02:00:00', GETDATE(), GETDATE(), 1, 1, 1);

