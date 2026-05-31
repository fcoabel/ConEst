using ConEst.Controladores;
using ConEst.Modelos;
using System.ComponentModel;

namespace ConEst.UI
{
    /// <summary>
    /// Ventana de inicio de sesión de la aplicación. Permite validar credenciales
    /// del usuario y establecer la sesión activa.
    /// </summary>
    public partial class SesionUI : Form
    {
        /// <summary>
        /// Inicializa una nueva instancia del formulario <see cref="SesionUI"/>.
        /// </summary>
        public SesionUI()
        {
            InitializeComponent();

            bool conexionExitosa = ControladorDB.ProbarConexion();
            if (!conexionExitosa ) MessageBox.Show("No se pudo conectar a la base de datos. Acceda con el usuario por defecto y compruebe los parametros de conexion.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Evento ejecutado al hacer clic en el botón Aceptar. Valida los campos,
        /// verifica credenciales y, si son correctas, inicia sesión.
        /// </summary>
        private void AceptarB_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                if (UsuarioPorDefecto())
                {
                    Sesion.Instancia.IniciarSesion(new Usuario { Nombre = Config.Settings["AppDefaultUser:Name"], Rol = Convert.ToInt32(Config.Settings["AppDefaultUser:Rol"]) });

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                Usuario? usuario = ValidarUsuario();

                if (usuario != null)
                {
                    Sesion.Instancia.IniciarSesion(usuario);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

                MensajeL.ForeColor = Color.Red;
                MensajeL.Text = "Usuario o contraseña incorrectos";
            }
        }

        /// <summary>
        /// Valida las credenciales ingresadas consultando la base de datos.
        /// </summary>
        /// <returns>
        /// Un objeto <see cref="Usuario"/> si las credenciales son válidas;
        /// de lo contrario, <c>null</c>.
        /// </returns>
        private Usuario? ValidarUsuario()
        {
            return ControladorDB.Login(UsuarioTB.Text, ContraseñaTB.Text);
        }

        /// <summary>
        /// Verifica si las credenciales ingresadas coinciden con el usuario
        /// por defecto configurado en <c>appsettings.json</c>.
        /// </summary>
        /// <returns>
        /// <c>true</c> si el usuario y contraseña coinciden con los valores por defecto;
        /// de lo contrario, <c>false</c>.
        /// </returns>
        private bool UsuarioPorDefecto()
        {
            return UsuarioTB.Text == Config.Settings["AppDefaultUser:Name"] && ContraseñaTB.Text == Config.Settings["AppDefaultUser:Password"];
        }

        /// <summary>
        /// Evento ejecutado cuando el formulario se muestra por primera vez.
        /// Quita el foco inicial de los controles.
        /// </summary>
        private void SesionUI_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        /// <summary>
        /// Valida que el campo de usuario no esté vacío.
        /// </summary>
        private void UsuarioTB_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsuarioTB.Text))
            {
                errorProvider1.SetError(UsuarioTB, "El nombre es obligatorio");
            }
        }

        /// <summary>
        /// Limpia el mensaje de error cuando el campo de usuario es válido.
        /// </summary>
        private void UsuarioTB_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(UsuarioTB, null);
        }

        /// <summary>
        /// Valida que el campo de contraseña no esté vacío.
        /// </summary>
        private void ContraseñaTB_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ContraseñaTB.Text))
            {
                errorProvider1.SetError(ContraseñaTB, "La contraseña es obligatoria");
            }
        }

        /// <summary>
        /// Limpia el mensaje de error cuando el campo de contraseña es válido.
        /// </summary>
        private void ContraseñaTB_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(ContraseñaTB, null);
        }

        /// <summary>
        /// Cierra el formulario sin iniciar sesión.
        /// </summary>
        private void CancelarB_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
