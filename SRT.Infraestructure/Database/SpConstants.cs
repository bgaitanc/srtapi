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
}