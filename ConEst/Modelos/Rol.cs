namespace ConEst.Modelos
{
    /// <summary>
    /// Representa un rol dentro del sistema, utilizado para definir
    /// permisos o niveles de acceso para los usuarios.
    /// </summary>
    public class Rol
    {
        /// <summary>
        /// Identificador único del rol.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del rol, como por ejemplo "Administrador" o "Usuario".
        /// </summary>
        public string Nombre { get; set; }
    }
}
