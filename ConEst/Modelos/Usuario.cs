namespace ConEst.Modelos
{
    /// <summary>
    /// Representa un usuario dentro del sistema, incluyendo su identificación,
    /// nombre, rol asignado y credenciales de acceso.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Identificador del rol asignado al usuario.
        /// </summary>
        public int Rol { get; set; }

        /// <summary>
        /// Contraseña del usuario. Se recomienda almacenar este valor de forma segura.
        /// </summary>
        public string Contraseña { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Usuario"/>.
        /// </summary>
        public Usuario() { }

    }
}
