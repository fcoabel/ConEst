using ConEst.Controladores;
using ConEst.Modelos;
using System.ComponentModel;

namespace ConEst.UI
{

    /// <summary>
    /// Formulario para crear o editar estaciones. Permite gestionar sus datos
    /// y los elementos asociados, incluyendo inserción, actualización y eliminación.
    /// </summary>
    public partial class EstacionUI : Form
    {
        /// <summary>
        /// Objeto estación que se está creando o editando.
        /// </summary>
        internal Estacion estacion = new();

        /// <summary>
        /// Lista de elementos asociados a la estación.
        /// </summary>
        internal BindingList<Elemento> elementos = new();

        /// <summary>
        /// Inicializa una nueva instancia del formulario <see cref="EstacionUI"/>.
        /// Si se proporciona una estación, carga sus datos y elementos asociados.
        /// </summary>
        /// <param name="estacion">Estación existente o <c>null</c> para crear una nueva.</param>
        public EstacionUI(Estacion? estacion = null)
        {
            InitializeComponent();


            if (estacion != null)
            {
                // Cargar los datos de la estación en los controles del formulario

                this.estacion = estacion;

                NombreTB.Text = estacion.Nombre;
                DescripcionTB.Text = estacion.Descripcion;
                LatitudTB.Text = estacion.Latitud.ToString();
                LongitudTB.Text = estacion.Longitud.ToString();
                this.elementos = ControladorDB.ObtenerElementosPorEstacion(this.estacion.Id);
                TablaElementosGV.DataSource = this.elementos;

            }
        }

        /// <summary>
        /// Guarda los cambios realizados en la estación y sus elementos.
        /// Inserta o actualiza según corresponda.
        /// </summary>
        private void AceptarB_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.estacion.Nombre = NombreTB.Text;
                this.estacion.Descripcion = DescripcionTB.Text;
                this.estacion.Latitud = double.Parse(LatitudTB.Text, System.Globalization.CultureInfo.InvariantCulture);
                this.estacion.Longitud = double.Parse(LongitudTB.Text, System.Globalization.CultureInfo.InvariantCulture);



                if (this.estacion.Id == 0)
                { 
                    if (ControladorDB.ComprobarEstacion(NombreTB.Text))
                    {
                        MessageBox.Show("Ya existe una estación con ese nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // INSERTAMOS ESTACION Y OBTENEMOS ID
                    int id = ControladorDB.ObtenerId(this.estacion);

                    ControladorDB.InsertarRegistro(new Registro
                    {
                        UsuarioId = Sesion.Instancia.UsuarioActual.Id,
                        Descripcion = $"Se ha creado la estación {id}",
                        Accion = ListaAcciones.ObtenerIdPorNombre("Insertar")
                    });

                    foreach (var elemento in this.elementos)
                    {
                        elemento.IdEstacion = id;
                        string error = ControladorDB.InsertarElemento(elemento);
                        if (!string.IsNullOrEmpty(error))
                        {
                            MessageBox.Show($"Error al guardar el elemento '{elemento.Nombre}': {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            ControladorDB.InsertarRegistro(new Registro
                            {
                                UsuarioId = Sesion.Instancia.UsuarioActual.Id,
                                Descripcion = $"Se ha creado el elemento {elemento.Nombre} en la estación {id}",
                                Accion = ListaAcciones.ObtenerIdPorNombre("Insertar")
                            });
                        }
                    }
                }
                else {
                    ControladorDB.ActualizarEstacion(this.estacion);
                    ControladorDB.InsertarRegistro(new Registro
                    {
                        UsuarioId = Sesion.Instancia.UsuarioActual.Id,
                        Descripcion = $"Se ha actualizado la estación {this.estacion.Id}",
                        Accion = ListaAcciones.ObtenerIdPorNombre("Actualizar")
                    });
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Quita el foco inicial al mostrar el formulario.
        /// </summary>
        private void EstacionUI_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        /// <summary>
        /// Elimina el elemento seleccionado de la estación.
        /// </summary>
        private void EliminarElementoB_Click(object sender, EventArgs e)
        {
            var elemento = getElementoSeleccionado();

            if (elemento == null)
                return;

            if (MessageBox.Show("¿Está seguro de que desea eliminar el elemento seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string error = ControladorDB.EliminarElemento(elemento.Id);
                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ControladorDB.InsertarRegistro(new Registro
                    {
                        UsuarioId = Sesion.Instancia.UsuarioActual.Id,
                        Descripcion = $"Se ha eliminado el elemento {elemento.Id} de la estación {this.estacion.Id}",
                        Accion = ListaAcciones.ObtenerIdPorNombre("Eliminar")
                    });
                    this.elementos = ControladorDB.ObtenerElementosPorEstacion(this.estacion.Id);
                    TablaElementosGV.DataSource = this.elementos;
                }
            }
        }

        /// <summary>
        /// Abre el formulario para añadir un nuevo elemento a la estación.
        /// </summary>
        private void AñadirElementoB_Click(object sender, EventArgs e)
        {
            

            using (var elementoUI = new NuevoElementoUI(-1, TablaElementosGV))
            {
                if (elementoUI.ShowDialog() == DialogResult.OK)
                {
                    var elemento = elementoUI.nuevoElemento;

                    MessageBox.Show(this.estacion.ToString());

                    if (!this.estacion.isEmpty())
                    {
                        elemento.IdEstacion = this.estacion.Id; // Asignar el ID de la estación al nuevo elemento
                        string error = ControladorDB.InsertarElemento(elemento); // Guardar el nuevo elemento en la base de datos
                        if (!string.IsNullOrEmpty(error))
                        {
                            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            this.elementos = ControladorDB.ObtenerElementosPorEstacion(this.estacion.Id); // Refrescar la tabla para mostrar el nuevo elemento
                            TablaElementosGV.DataSource = this.elementos;   
                        }
                    }
                    else {
                        this.elementos.Add(elemento); // Agregar el nuevo elemento a la lista local si la estación aún no se ha guardado en la base de datos
                    }


                    
                }
            }
        }

        /// <summary>
        /// Abre el formulario de edición al hacer doble clic en un elemento.
        /// </summary>
        private void TablaElementosGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var elemento = getElementoSeleccionado();

            if (elemento == null)
                return;

            using (var elementoUI = new NuevoElementoUI(elemento.Id, TablaElementosGV))
            {

                if (elementoUI.ShowDialog() == DialogResult.OK)
                {
                    // Refrescar la tabla para mostrar los cambios
                    this.elementos = ControladorDB.ObtenerElementosPorEstacion(this.estacion.Id);
                    TablaElementosGV.DataSource = this.elementos;
                }

            }
        }

        /// <summary>
        /// Obtiene el elemento actualmente seleccionado en la tabla.
        /// </summary>
        /// <returns>El elemento seleccionado o <c>null</c> si no hay selección.</returns>
        public Elemento? getElementoSeleccionado()
        {
            // Comprobamos que haya una fila seleccionada
            if (TablaElementosGV.SelectedRows.Count == 0)
                return null;

            // Obtiene la fila seleccionada
            var fila = TablaElementosGV.SelectedRows[0];

            // Devuelve el objeto Elemento asociado a esa fila
            return fila.DataBoundItem as Elemento;
        }

        /// <summary>
        /// Cierra el formulario sin guardar cambios.
        /// </summary>
        private void CancelarB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Valida la entrada de latitud permitiendo solo números, punto y signo negativo.
        /// </summary>
        private void LatitudTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;

            // Permitir dígitos, control, punto y signo negativo
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) &&
                e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            // Solo un signo negativo al inicio
            if (e.KeyChar == '-' && tb.SelectionStart != 0)
                e.Handled = true;

            // Solo un punto decimal
            if (e.KeyChar == '.' && tb.Text.Contains("."))
                e.Handled = true;
        }

        /// <summary>
        /// Valida la entrada de longitud permitiendo solo números, punto y signo negativo.
        /// </summary>
        private void LongitudTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) &&
                e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '-' && tb.SelectionStart != 0)
                e.Handled = true;

            if (e.KeyChar == '.' && tb.Text.Contains("."))
                e.Handled = true;
        }

        /// <summary>
        /// Limpia el error del campo Nombre cuando es válido.
        /// </summary>
        private void NombreTB_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(NombreTB, null);
        }

        /// <summary>
        /// Valida que el nombre no esté vacío.
        /// </summary>
        private void NombreTB_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NombreTB.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(NombreTB, "El nombre es obligatorio.");
                return;
            }

        }

        /// <summary>
        /// Limpia el error del campo Descripción cuando es válido.
        /// </summary>
        private void DescripcionTB_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(DescripcionTB, null);
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
            }
        }

        /// <summary>
        /// Limpia el error del campo Latitud cuando es válido.
        /// </summary>
        private void LatitudTB_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(LatitudTB, null);
        }

        /// <summary>
        /// Valida que la latitud sea un número válido entre -90 y 90.
        /// </summary>
        private void LatitudTB_Validating(object sender, CancelEventArgs e)
        {
            if (!double.TryParse(LatitudTB.Text,
                System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture,
                out double lat) ||
                lat < -90 || lat > 90)
            {
                e.Cancel = true;
                errorProvider1.SetError(LatitudTB, "Latitud inválida. Debe estar entre -90 y 90.");
            }
        }

        /// <summary>
        /// Limpia el error del campo Longitud cuando es válido.
        /// </summary>
        private void LongitudTB_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(LongitudTB, null);
        }

        /// <summary>
        /// Valida que la longitud sea un número válido entre -180 y 180.
        /// </summary>
        private void LongitudTB_Validating(object sender, CancelEventArgs e)
        {
            if (!double.TryParse(LongitudTB.Text,
                System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture,
                out double lon) ||
                lon < -180 || lon > 180)
            {
                e.Cancel = true;
                errorProvider1.SetError(LongitudTB, "Longitud inválida. Debe estar entre -180 y 180.");
            }
        }
    }
}
