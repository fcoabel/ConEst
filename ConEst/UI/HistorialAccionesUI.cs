using ConEst.Controladores;

namespace ConEst.UI
{

    /// <summary>
    /// Formulario que muestra el historial de acciones registradas en el sistema.
    /// Carga automáticamente los registros desde la base de datos al inicializarse.
    /// </summary>
    public partial class HistorialAccionesUI : Form
    {

        /// <summary>
        /// Inicializa una nueva instancia del formulario <see cref="HistorialAccionesUI"/>
        /// y carga los registros en el control <c>DataGridView</c>.
        /// </summary>
        public HistorialAccionesUI()
        {
            InitializeComponent();

            RegistrosDGV.DataSource = ControladorDB.ObtenerRegistros();
        }
    }
}
