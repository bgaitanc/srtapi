namespace SRT.Infraestructure.Database;

public static class SpConstants
{
    #region Users

    public const string InsertUser = "sp_Insertar_Usuario";
    public const string GetUserByUserName = "sp_Obtener_Usuarios_username";
    public const string GetUserByUserNameAndEmail = "sp_Obtener_Usuarios_username_email";

    #endregion

    #region Estados

    public const string GetAllEstados = "sp_Obtener_Estados";
    public const string GetEstadoByParams = "sp_Obtener_Estado_By_Params";
    public const string InsertEstado = "sp_Insertar_Estado";
    public const string UpdateEstado = "sp_Eliminar_O_Reactivar_Estado";
    public const string DeleteOrReactiveEstado = "sp_Eliminar_O_Reactivar_Estado";

    #endregion

    #region Paises

    public const string GetAllPaises = "sp_Obtener_Paises";
    public const string GetPaisByParams = "sp_Obtener_Pais_By_Params";
    public const string InsertPais = "sp_Insertar_Pais";
    public const string UpdatePais = "sp_Actualizar_Pais";
    public const string DeleteOrReactivePais = "sp_Eliminar_O_Reactivar_Pais";

    #endregion

    #region Departamentos

    public const string GetAllDepartamentos = "sp_Obtener_Departamentos";
    public const string GetDepartamentoByParams = "sp_Obtener_Departamento_By_Params";
    public const string InsertDepartamento = "sp_Insertar_Departamento";
    public const string UpdateDepartamento = "sp_Actualizar_Departamento";
    public const string DeleteOrReactiveDepartamento = "sp_Eliminar_O_Reactivar_Departamento";

    #endregion

    #region Locaciones

    public const string GetAllLocaciones = "sp_Obtener_Locaciones";
    public const string GetLocacionByParams = "sp_Obtener_Locacion_By_Params";
    public const string InsertLocacion = "sp_Insertar_Locacion";
    public const string UpdateLocacion = "sp_Actualizar_Locacion";
    public const string DeleteOrReactiveLocacion = "sp_Eliminar_O_Reactivar_Locacion";

    #endregion

    #region Vehiculos

    public const string GetAllVehiculos = "sp_Obtener_Vehiculos";
    public const string GetVehiculoByParams = "sp_Obtener_Vehiculo_By_Params";
    public const string InsertVehiculo = "sp_Insertar_Vehiculo";
    public const string UpdateVehiculo = "sp_Actualizar_Vehiculo";
    public const string DeleteOrReactiveVehiculo = "sp_Eliminar_O_Reactivar_Vehiculo";

    #endregion

    #region Rutas

    public const string GetAllRutas = "sp_Obtener_Rutas";
    public const string GetRutaByParams = "sp_Obtener_Ruta_By_Params";
    public const string InsertRuta = "sp_Insertar_Ruta";
    public const string UpdateRuta = "sp_Actualizar_Ruta";
    public const string DeleteOrReactiveRuta = "sp_Eliminar_O_Reactivar_Ruta";

    #endregion

    #region Viajes

    public const string GetAllViajes = "sp_Obtener_Viajes";

    #endregion
    
    #region Reservas
    
    public const string InsertReserva = "sp_Insertar_Reserva";
    
    #endregion
    
    #region DetalleReservas
    
    public const string GetDetalleReservasByParams = "sp_Obtener_DetalleReservas_By_Params";
    public const string InsertDetalleReserva = "sp_Insertar_DetalleReserva";
    #endregion
}