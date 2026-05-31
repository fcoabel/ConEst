using ConEst.Modelos;

namespace ConEst.Controladores
{
    /// <summary>
    /// Gestiona la sesión actual del sistema, permitiendo iniciar y cerrar sesión
    /// para un usuario específico.
    /// </summary>
    public class Sesion
    {
        /// <summary>
        /// Obtiene la instancia única de la sesión (patrón Singleton).
        /// </summary>
        private static Sesion? _instance;

        /// <summary>
        /// Obtiene el usuario actualmente autenticado en la sesión.
        /// </summary>
        public Usuario UsuarioActual { get; private set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Sesion"/>.
        /// </summary>
        public Sesion() { }

        /// <summary>
        /// Obtiene la instancia única de la sesión (patrón Singleton).
        /// </summary>
        public static Sesion Instancia => _instance ??= new Sesion();

        /// <summary>
        /// Inicia sesión asignando el usuario proporcionado como usuario actual.
        /// </summary>
        /// <param name="usuario">El usuario que inicia sesión.</param>
        public void IniciarSesion(Usuario usuario)
        {
            UsuarioActual = usuario;
        }
        
        /// <summary>
        /// Cierra la sesión eliminando el usuario actual.
        /// </summary>
        public void CerrarSesion()
        {
            UsuarioActual = null;
        }

    }
}
