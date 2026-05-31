using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConEst.Modelos
{
    /// <summary>
    /// Representa un elemento dentro del sistema, incluyendo su identificación,
    /// nombre, descripción, estación asociada y tipo.
    /// </summary>
    public class Elemento
    {
        /// <summary>
        /// Identificador único del elemento.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del elemento.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Descripción detallada del elemento.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Identificador de la estación a la que pertenece el elemento.
        /// </summary>
        public int IdEstacion { get; set; }

        /// <summary>
        /// Tipo del elemento representado como un valor numérico.
        /// </summary>
        public int tipoElemento { get; set; }

        /// <summary>
        /// Devuelve una representación en texto del elemento,
        /// incluyendo sus propiedades principales.
        /// </summary>
        /// <returns>Una cadena con los valores del elemento.</returns>
        public override string ToString()
        {
            return $"Id: {Id}, Nombre: {Nombre}, Descripción: {Descripcion}, IdEstacion: {IdEstacion}, Tipo: {tipoElemento}";
        }
        
    }
}
