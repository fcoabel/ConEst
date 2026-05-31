using ConEst.Controladores;

namespace ConEst.Modelos
{
    /// <summary>
     /// Proporciona una lista estática de acciones obtenidas desde la base de datos
     /// y métodos utilitarios para consultarlas.
     /// </summary>
    public static class ListaAcciones
    {
        /// <summary>
        /// Obtiene la lista de acciones disponibles en el sistema.
        /// </summary>
        public static List<Accion> Acciones { get; private set; }

        /// <summary>
        /// Inicializa la clase cargando las acciones desde la base de datos.
        /// </summary>
        static ListaAcciones()
        {
            Acciones = ControladorDB.ObtenerAcciones();
        }

        /// <summary>
        /// Obtiene el identificador de una acción según su nombre.
        /// </summary>
        /// <param name="nombre">El nombre del tipo de acción a buscar.</param>
        /// <returns>
        /// El identificador de la acción si existe; de lo contrario, <c>-1</c>.
        /// </returns>
        public static int ObtenerIdPorNombre(string nombre)
        {
            return Acciones
                    .FirstOrDefault(a => a.Tipo == nombre)
                    ?.Id ?? -1;
        }
    }
    /// <summary>
    /// Representa una acción del sistema con su identificador y tipo.
    /// </summary>
    public class Accion
    {
        /// <summary>
        /// Identificador único de la acción.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre o tipo de la acción.
        /// </summary>
        public string Tipo { get; set; }
    }
}
