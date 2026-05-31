namespace ConEst.Modelos
{
    /// <summary>
    /// Representa un registro de actividad dentro del sistema, incluyendo
    /// información sobre la acción realizada, el usuario que la ejecutó
    /// y la fecha en que ocurrió.
    /// </summary>
    public class Registro
    {
        /// <summary>
        /// Identificador único del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador de la acción asociada al registro.
        /// </summary>
        public int Accion { get; set; }

        /// <summary>
        /// Descripción detallada de la acción realizada.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Identificador del usuario que realizó la acción.
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Fecha y hora en que ocurrió la acción.
        /// </summary>
        public DateTime Fecha { get; set; }
    }

}
