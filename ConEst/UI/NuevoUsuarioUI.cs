using ConEst.Controladores;
using ConEst.Modelos;
using System.ComponentModel;

namespace ConEst.UI
{
    /// <summary>
    /// Formulario para la creación de nuevos usuarios dentro del sistema.
    /// Permite ingresar nombre, contraseña y rol, validando los datos antes de registrarlos.
    /// </summary>
    public partial class NuevoUsuarioUI : Form
    {

        /// <summary>
        /// Inicializa una nueva instancia del formulario <see cref="NuevoUsuarioUI"/>
        /// y carga la lista de roles disponibles.
        /// </summary>
        public NuevoUsuarioUI()
        {
            InitializeComponent();

            RolCB.DataSource = ControladorDB.ObtenerRoles();
            RolCB.DisplayMember = "Nombre";
            RolCB.ValueMember = "Id";
        }

        /// <summary>
        /// Evento ejecutado cuando el formulario se muestra por primera vez.
        /// Quita el foco inicial de los controles.
        /// </summary>
        private void NuevoUsuarioUI_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        /// <summary>
        /// Evento ejecutado al hacer clic en el botón Aceptar.
        /// Valida los datos ingresados, intenta registrar el usuario
        /// y registra la acción en el historial si la operación es exitosa.
        /// </summary>
        private void AceptarB_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                String resultado = ControladorDB.InsertarUsuario(new Usuario
                {
                    Nombre = NombreTB.Text,
                    Contraseña = ContraseñaTB.Text,
                    Rol = (int)RolCB.SelectedValue
                });

                if (resultado != "OK")
                {
                    MessageBox.Show(resultado,
                        "Error al insertar usuario",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    ControladorDB.InsertarRegistro(new Registro
                    {
                        UsuarioId = Sesion.Instancia.UsuarioActual.Id,
                        Accion = ListaAcciones.ObtenerIdPorNombre("Insertar"),
                        Descripcion = $"Se creó el usuario '{NombreTB.Text}' con el rol '{RolCB.Text}'.",
                    });
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Valida que el nombre de usuario no esté vacío y que no exista previamente.
        /// </summary>
        private void NombreTB_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NombreTB.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(NombreTB, "El nombre de usuario no puede estar vacío.");
                return;
            }

            if (ControladorDB.UsuarioExiste(NombreTB.Text))
            {
                e.Cancel = true;
                MessageBox.Show("El nombre de usuario ya existe. Por favor, elige otro nombre.");
            }
        }

        /// <summary>
        /// Limpia el mensaje de error del campo de nombre cuando es válido.
        /// </summary>
        private void NombreTB_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(NombreTB, null); // Limpiar error previo
        }

        /// <summary>
        /// Limpia el mensaje de error del campo de contraseña cuando es válido.
        /// </summary>
        private void ContraseñaTB_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(ContraseñaTB, null); // Limpiar error previo
        }

        /// <summary>
        /// Valida que la contraseña no esté vacía.
        /// </summary>
        private void ContraseñaTB_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ContraseñaTB.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(ContraseñaTB, "La contraseña no puede estar vacía.");
            }
        }

        /// <summary>
        /// Limpia el mensaje de error del campo de confirmación de contraseña cuando es válido.
        /// </summary>
        private void ConfirmarConTB_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(ConfirmarConTB, null); // Limpiar error previo
        }

        /// <summary>
        /// Valida que la confirmación de contraseña no esté vacía
        /// y que coincida con la contraseña ingresada.
        /// </summary>
        private void ConfirmarConTB_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ConfirmarConTB.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(ConfirmarConTB, "Por favor, confirme la contraseña.");
                return;
            }

            if (!string.Equals(ContraseñaTB.Text, ConfirmarConTB.Text))
            {
                errorProvider.SetError(ConfirmarConTB, "Las contraseñas no coinciden.");
                return;
            }
        }

        /// <summary>
        /// Cierra el formulario sin crear un nuevo usuario.
        /// </summary>
        private void CancelarB_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            this.Close();
        }
    }
}
