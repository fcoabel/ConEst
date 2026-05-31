using ConEst.Controladores;
using ConEst.Modelos;
using System.ComponentModel;

namespace ConEst.UI
{
    /// <summary>
    /// Formulario para crear o editar elementos asociados a una estación.
    /// Permite validar datos, cargar tipos de elementos y actualizar registros existentes.
    public partial class NuevoElementoUI : Form
    {
        /// <summary>
        /// Contiene el nuevo elemento creado cuando se trabaja en modo de inserción.
        /// </summary>
        public Elemento nuevoElemento = new();

        /// <summary>
        /// Contiene el elemento existente cuando se trabaja en modo de edición.
        /// </summary>
        Elemento elementoExistente = new();

        /// <summary>
        /// Lista enlazada de elementos mostrados en la tabla principal.
        /// </summary>
        BindingList<Elemento> elementos = new();

        /// <summary>
        /// Inicializa una nueva instancia del formulario <see cref="NuevoElementoUI"/>.
        /// Carga los tipos de elementos y, si corresponde, los datos del elemento a editar.
        /// </summary>
        /// <param name="idElemento">Identificador del elemento a editar. Si es -1, se crea uno nuevo.</param>
        /// <param name="TablaElementos">Tabla que contiene los elementos actuales.</param>
        public NuevoElementoUI(int idElemento, DataGridView TablaElementos)
        {
            InitializeComponent();

            TipoCB.DisplayMember = "Nombre";
            TipoCB.ValueMember = "Id";
            TipoCB.DataSource = ControladorDB.ObtenerTiposElementos();

            elementos = TablaElementos.DataSource as BindingList<Elemento>;

            if (idElemento != -1)
            {
                elementoExistente = elementos.SingleOrDefault(e => e.Id == idElemento);

                NombreTB.Text = elementoExistente.Nombre;
                DescripcionTB.Text = elementoExistente.Descripcion;
                TipoCB.SelectedValue = elementoExistente.tipoElemento;
                return;
            }
            
            elementoExistente.Id = idElemento;
            

        }

        /// <summary>
        /// Valida que el nombre del elemento no esté vacío y que no exista duplicado.
        /// </summary>
        private void NombreTB_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NombreTB.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(NombreTB, "El nombre es obligatorio.");
                return;
            }

            if (elementoExistente.Id == -1 && elementos != null )
            {
                if(string.Equals(elementos.Select(e => e.Nombre).FirstOrDefault(), NombreTB.Text)){

                    e.Cancel = true;
                    errorProvider1.SetError(NombreTB, "El nombre ya existe.");

                }

            }
        }

        /// <summary>
        /// Valida que la descripción no esté vacía.
        /// </summary>
        private void DescripcionTB_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DescripcionTB.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(DescripcionTB, "La descripción es obligatoria.");
                return;
            }
        }

        /// <summary>
        /// Evento ejecutado al hacer clic en el botón Aceptar.
        /// Inserta o actualiza un elemento según corresponda.
        /// </summary>
        private void AceptarB_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (elementoExistente.Id == -1)
                {
                    nuevoElemento.Nombre = NombreTB.Text;
                    nuevoElemento.Descripcion = DescripcionTB.Text;
                    nuevoElemento.tipoElemento = (int)TipoCB.SelectedValue;

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    elementoExistente.Nombre = NombreTB.Text.Trim();
                    elementoExistente.Descripcion = DescripcionTB.Text.Trim();
                    elementoExistente.tipoElemento = (int)TipoCB.SelectedValue;
                    string error = ControladorDB.ActualizarElemento(elementoExistente);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else { 
                        ControladorDB.InsertarRegistro(new Registro
                        {
                            UsuarioId = Sesion.Instancia.UsuarioActual.Id,
                            Accion = ListaAcciones.ObtenerIdPorNombre("Actualizar"),
                            Descripcion = $"Elemento actualizado: {elementoExistente.Id}" 
                        });
                        this.DialogResult= DialogResult.OK;
                    }

                }
            }
        }

        /// <summary>
        /// Limpia el mensaje de error del campo de descripción cuando es válido.
        /// </summary>
        private void DescripcionTB_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(DescripcionTB, null);
        }

        /// <summary>
        /// Limpia el mensaje de error del campo de nombre cuando es válido.
        /// </summary>
        private void NombreTB_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(NombreTB, null);
        }
    }
}
