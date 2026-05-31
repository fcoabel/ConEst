using ConEst.Controladores;
using ConEst.Modelos;

namespace ConEst.UI
{
    /// <summary>
    /// Formulario de ajustes generales de la aplicación.
    /// Permite administrar usuarios, visualizar registros de actividad
    /// y modificar la configuración de conexión a la base de datos.
    /// </summary>
    public partial class AjustesUI : Form
    {
        /// <summary>
        /// Obtiene el nombre de la base de datos desde la configuración.
        /// </summary>
        private string NombreDatabase => Config.Settings["DatabaseSettings:Name"];

        /// <summary>
        /// Obtiene la dirección del servidor de base de datos desde la configuración.
        /// </summary>
        private string EnlaceDatabase => Config.Settings["DatabaseSettings:url"];

        /// <summary>
        /// Inicializa una nueva instancia del formulario <see cref="AjustesUI"/>.
        /// Carga los valores actuales de configuración y la lista de usuarios.
        /// </summary>
        public AjustesUI()
        {
            InitializeComponent();

            this.ControlBox = false; // Deshabilita el botón de cerrar

            EnlaceTB.Text = EnlaceDatabase;
            NombreBDTB.Text = NombreDatabase;

            UsuariosDGV.DataSource = ControladorDB.ObtenerUsuarios();
        }

        /// <summary>
        /// Abre el formulario para añadir un nuevo usuario y actualiza la tabla al finalizar.
        /// </summary>
        private void AñadirB_Click(object sender, EventArgs e)
        {
            var nuevoUsuarioUI = new NuevoUsuarioUI();
            nuevoUsuarioUI.ShowDialog();

            UsuariosDGV.DataSource = ControladorDB.ObtenerUsuarios();
        }

        /// <summary>
        /// Elimina el usuario seleccionado tras confirmar la acción
        /// y registra la operación en el historial.
        /// </summary>
        private void EliminarB_Click(object sender, EventArgs e)
        {
            if (UsuariosDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            DialogResult result = MessageBox.Show(
                "¿Desea eliminar el usuario seleccionado?",
                "Atención",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                // Obtiene la fila seleccionada
                var fila = UsuariosDGV.SelectedRows[0];

                // Devuelve el objeto Estacion asociado a esa fila
                var usuario = fila.DataBoundItem as Usuario;

                bool ok = ControladorDB.EliminarUsuario(usuario.Id);
                
                ControladorDB.InsertarRegistro(new Registro
                {
                    UsuarioId = Sesion.Instancia.UsuarioActual.Id,
                    Accion = ListaAcciones.ObtenerIdPorNombre("Eliminar"),
                    Descripcion = $"El usuario '{usuario.Nombre}' ha sido eliminado."
                });

                UsuariosDGV.DataSource = ControladorDB.ObtenerUsuarios();
            }

        }

        /// <summary>
        /// Oculta la columna de contraseña en la tabla de usuarios si está presente.
        /// </summary>
        private void UsuariosDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (UsuariosDGV.Columns.Contains("Contraseña")) UsuariosDGV.Columns["Contraseña"].Visible = false;
        }

        /// <summary>
        /// Evento ejecutado al mostrar el formulario. Quita el foco inicial de los controles.
        /// </summary>
        private void AjustesUI_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        /// <summary>
        /// Abre el formulario de historial de acciones.
        /// </summary>
        private void RegistrosB_Click(object sender, EventArgs e)
        {
            var HistorialUI = new HistorialAccionesUI();
            HistorialUI.ShowDialog();
        }

        /// <summary>
        /// Guarda los cambios en la configuración de conexión si el usuario lo confirma
        /// y verifica previamente que la conexión sea válida.
        /// </summary>
        private void AceptarB_Click(object sender, EventArgs e)
        {
            // Si NO hay cambios → cerrar directamente
            if (string.Equals(NombreBDTB.Text, NombreDatabase) &&
                string.Equals(EnlaceTB.Text, EnlaceDatabase))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            // Si hay cambios → preguntar
            DialogResult result = MessageBox.Show(
                "Ha modificado los parámetros de conexión. ¿Desea guardar los cambios?",
                "Atención",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                string nuevoServer = EnlaceTB.Text;
                string nuevoNombreBD = NombreBDTB.Text;

                string user = Config.Settings["DatabaseSettings:User"];
                string password = Config.Settings["DatabaseSettings:Password"];

                bool ok = ControladorDB.ProbarConexion(nuevoServer, nuevoNombreBD, user, password);

                if (!ok)
                {
                    MessageBox.Show("No se pudo conectar con la base de datos. Verifique los datos.",
                                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AppSettingsEditor.UpdateSetting("DatabaseSettings", "url", nuevoServer);
                AppSettingsEditor.UpdateSetting("DatabaseSettings", "Name", nuevoNombreBD);

                Config.Settings.Reload();

                MessageBox.Show("Conexión correcta. Configuración guardada.");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
