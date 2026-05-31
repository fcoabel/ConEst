using ConEst.Controladores;
using ConEst.Modelos;
using ConEst.UI;
using System.ComponentModel;

namespace ConEst
{

    /// <summary>
    /// Formulario principal de gestión de estaciones. Permite visualizar,
    /// agregar, editar y eliminar estaciones, así como acceder a los ajustes
    /// y cerrar sesión.
    /// </summary>
    public partial class EstacionesUI : Form
    {
        /// <summary>
        /// Inicializa una nueva instancia del formulario <see cref="EstacionesUI"/>.
        /// Registra el inicio de sesión del usuario y carga la lista de estaciones.
        /// </summary>
        public EstacionesUI()
        {

            InitializeComponent();
            ControladorDB.InsertarRegistro(new Registro
            {
                UsuarioId = Sesion.Instancia.UsuarioActual.Id,
                Accion = ListaAcciones.ObtenerIdPorNombre("Iniciar Sesion"),
                Descripcion = $"El usuario {Sesion.Instancia.UsuarioActual.Nombre} ha iniciado sesión."
            });


            if (Sesion.Instancia.UsuarioActual.Rol != 1) AjustesTSB.Visible = false; // Solo el rol admin (1) puede ver los ajustes
            EstacionesDGV.DataSource = ControladorDB.ObtenerEstaciones();
        }

        /// <summary>
        /// Abre el formulario de ajustes y recarga la lista de estaciones
        /// al cerrar dicho formulario.
        /// </summary>
        private void AjustesTSB_Click(object sender, EventArgs e)
        {

            using var ajustesDialog = new AjustesUI();
            ajustesDialog.ShowDialog();
            // Al cerrar el diálogo de ajustes, se recargan las estaciones para reflejar cualquier cambio
            EstacionesDGV.DataSource = ControladorDB.ObtenerEstaciones();

        }

        /// <summary>
        /// Evento ejecutado al mostrar el formulario. Quita el foco inicial.
        /// </summary>
        private void EstacionesUI_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        /// <summary>
        /// Elimina la estación seleccionada. Si tiene elementos asociados,
        /// pregunta si deben eliminarse antes de borrar la estación.
        /// Registra la acción en el historial.
        /// </summary>
        private void EliminarTSB_Click(object sender, EventArgs e)
        {
            var estacion = GetEstacionSeleccionada();

            if (estacion == null)
            {
                MessageBox.Show("Por favor, seleccione una estación para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmar = MessageBox.Show(
                $"¿Eliminar la estación '{estacion.Nombre}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmar != DialogResult.Yes) return;

            if (!ControladorDB.EliminarEstacion(estacion.Id))
            {
                var resultado = MessageBox.Show(
                    "La estación tiene elementos asociado. ¿Desea borrar los elementos?.",
                    "Atencion.",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                    );

                if (resultado != DialogResult.Yes) return;

                if (ControladorDB.EliminarElementoIdEstacion(estacion.Id))
                    MessageBox.Show("Elementos eliminados.", "Información.");
                
                ControladorDB.EliminarEstacion(estacion.Id);

                ControladorDB.InsertarRegistro(new Registro
                {
                    UsuarioId = Sesion.Instancia.UsuarioActual.Id,
                    Accion = ListaAcciones.ObtenerIdPorNombre("Eliminar"),
                    Descripcion = $"El usuario {Sesion.Instancia.UsuarioActual.Nombre} ha eliminado la estación {estacion.Nombre}."
                });

            }

            var lista = EstacionesDGV.DataSource as BindingList<Estacion>;
            lista.Remove(estacion);
        }

        /// <summary>
        /// Abre el formulario para añadir una nueva estación y recarga la lista al finalizar.
        /// </summary>
        private void AñadirTSB_Click(object sender, EventArgs e)
        {
            using var dialogoEstacion = new EstacionUI();
            dialogoEstacion.ShowDialog();
            EstacionesDGV.DataSource = ControladorDB.ObtenerEstaciones();
        }

        /// <summary>
        /// Abre el formulario de edición al hacer doble clic en una estación.
        /// Recarga la lista al cerrar el formulario.
        /// </summary>
        private void EstacionesDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Evita errores al hacer doble clic en el encabezado

            var estacion = GetEstacionSeleccionada();

            var estacionUI = new EstacionUI(estacion);
            estacionUI.ShowDialog();

            // Después de cerrar el diálogo, se recarga la lista de estaciones para reflejar cualquier cambio
            EstacionesDGV.DataSource = ControladorDB.ObtenerEstaciones();
        }

        /// <summary>
        /// Obtiene la estación actualmente seleccionada en la tabla.
        /// </summary>
        /// <returns>
        /// Un objeto <see cref="Estacion"/> si hay una fila seleccionada;
        /// de lo contrario, <c>null</c>.
        /// </returns>
        public Estacion? GetEstacionSeleccionada()
        {
            // Comprobamos que haya una fila seleccionada
            if (EstacionesDGV.SelectedRows.Count == 0)
                return null;

            // Obtiene la fila seleccionada
            var fila = EstacionesDGV.SelectedRows[0];

            // Devuelve el objeto Estacion asociado a esa fila
            return fila.DataBoundItem as Estacion;
        }

        /// <summary>
        /// Cierra la sesión actual y reinicia la aplicación.
        /// </summary>
        private void CerrarSesionTSB_Click(object sender, EventArgs e)
        {
            Sesion.Instancia.CerrarSesion();
            Application.Restart();
        }
    }
}
