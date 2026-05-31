using System;
using System.Collections.Generic;
using System.Text;

namespace ConEst.Modelos
{
    /// <summary>
    /// Representa una estación dentro del sistema, incluyendo su identificación,
    /// nombre, descripción y coordenadas geográficas.
    /// </summary>
    public class Estacion
    {
        /// <summary>
        /// Identificador único de la estación.
        /// </summary>
        public int Id {  get; set; }

        /// <summary>
        /// Nombre de la estación.
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// Descripción general de la estación.
        /// </summary>
        public string? Descripcion { get; set; }

        /// <summary>
        /// Latitud geográfica de la estación.
        /// </summary>
        public double? Latitud {  get; set; }

        /// <summary>
        /// Longitud geográfica de la estación.
        /// </summary>
        public double? Longitud { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Estacion"/>.
        /// </summary>
        public Estacion() { }

        /// <summary>
        /// Indica si la estación no contiene información relevante.
        /// </summary>
        /// <returns>
        /// <c>true</c> si todos los campos están vacíos o nulos; de lo contrario, <c>false</c>.
        /// </returns>
        public bool isEmpty() { 
            return Id == 0
            && Nombre is null
            && Descripcion is null
            && Latitud is null
            && Longitud is null;
        }
    }
}
