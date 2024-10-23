using Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plantilla_navegable.Forms
{
    public partial class FormEstados : Form
    {
        public FormEstados()
        {
            InitializeComponent();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label4.ForeColor = ThemeColor.SecondaryColor;
            label5.ForeColor = ThemeColor.PrimaryColor;
        }

        private void FormPerfil_Load(object sender, EventArgs e)
        {
            LoadTheme();
            CargarTablaEstadoPedido();
            CargarTablaEstadoUsuario();


            //------------------ PERSONALIZAR DGV CRUD ESTADO PEDIDO INICIO-----------------


            //Aqui se agrega el check al dgv
            if (!dgvestadopedido.Columns.Contains("Seleccionar"))
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "", // Título de la columna
                    Width = 30, // Establecer un ancho específico
                    Name = "" // Nombre de la columna para poder referenciarla más tarde
                };
                dgvestadopedido.Columns.Insert(0, checkColumn); // Insertar en la posición 0
            }

            if (!dgvestadopedido.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Text = "Del",
                    UseColumnTextForButtonValue = true,
                    Width = 50 // Establecer un ancho específico
                };
                dgvestadopedido.Columns.Insert(1, btnDelete);
            }

            //------------------ PERSONALIZAR DGV CRUD ESTADO PEDIDO FIN-----------------

          

            //------------------ PERSONALIZAR DGV CRUD ESTADO Usuario INICIO-----------------
            //Aqui se agrega el check al dgv
            if (!dgvestadousuario.Columns.Contains("Seleccionar"))
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "", // Título de la columna
                    Width = 30, // Establecer un ancho específico
                    Name = "" // Nombre de la columna para poder referenciarla más tarde
                };
                dgvestadousuario.Columns.Insert(0, checkColumn); // Insertar en la posición 0
            }

            if (!dgvestadousuario.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Text = "Del",
                    UseColumnTextForButtonValue = true,
                    Width = 50 // Establecer un ancho específico
                };
                dgvestadousuario.Columns.Insert(1, btnDelete);
            }

            //------------------ PERSONALIZAR DGV CRUD ESTADO Usuario FIN-----------------


            CargarTablaEstadoDevolucion();

            //------------------ PERSONALIZAR DGV CRUD ESTADO DEVOLUCION INICIO-----------------

            if (!dgvestadodevolucion.Columns.Contains("Seleccionar"))
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "", // Título de la columna
                    Width = 30, // Establecer un ancho específico
                    Name = "" // Nombre de la columna para poder referenciarla más tarde
                };
                dgvestadodevolucion.Columns.Insert(0, checkColumn); // Insertar en la posición 0
            }

            if (!dgvestadodevolucion.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Text = "Del",
                    UseColumnTextForButtonValue = true,
                    Width = 50 // Establecer un ancho específico
                };
                dgvestadodevolucion.Columns.Insert(1, btnDelete);
            }

            //------------------ PERSONALIZAR DGV CRUD ESTADO DEVOLUCION FIN-----------------



            CargarTablaEstadoReembolso();

            //------------------ PERSONALIZAR DGV CRUD ESTADO REEMBOLSO INICIO-----------------
            //Aqui se agrega el check al dgv
            if (!dgvestadoreembolso.Columns.Contains("Seleccionar"))
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "", // Título de la columna
                    Width = 30, // Establecer un ancho específico
                    Name = "" // Nombre de la columna para poder referenciarla más tarde
                };
                dgvestadoreembolso.Columns.Insert(0, checkColumn); // Insertar en la posición 0
            }

            if (!dgvestadoreembolso.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Text = "Del",
                    UseColumnTextForButtonValue = true,
                    Width = 50 // Establecer un ancho específico
                };
                dgvestadoreembolso.Columns.Insert(1, btnDelete);
            }

            //------------------ PERSONALIZAR DGV CRUD ESTADO REEMBOLSO FIN-----------------


            CargarTablaEstadoPago();

            //------------------ PERSONALIZAR DGV CRUD ESTADO PAGOS INICIO-----------------

            //Aqui se agrega el check al dgv
            if (!dgvestadopagos.Columns.Contains("Seleccionar"))
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "", // Título de la columna
                    Width = 30, // Establecer un ancho específico
                    Name = "" // Nombre de la columna para poder referenciarla más tarde
                };
                dgvestadopagos.Columns.Insert(0, checkColumn); // Insertar en la posición 0
            }

            if (!dgvestadopagos.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Text = "Del",
                    UseColumnTextForButtonValue = true,
                    Width = 50 // Establecer un ancho específico
                };
                dgvestadopagos.Columns.Insert(1, btnDelete);
            }

            //------------------ PERSONALIZAR DGV CRUD ESTADO PAGOS FIN-----------------

        }


        //----------------------INICIO CRUD ESTADO PEDIDO--------------------

        private void LimpiarCamposEstadoPedido()
        {
            txtestadoingresarpedido.Text = string.Empty;
        }

        //Cargar Tabla Estado Pedido
        private void CargarTablaEstadoPedido()
        {
            contoladorestadopedido objestadopedidotabla = new contoladorestadopedido();
            dgvestadopedido.DataSource = objestadopedidotabla.LeerDatosEstadoPedidos();
            
        }

        //Ingresar Datos Estado Pedido
        void insertarDatosEstadoPedido()
        {
            contoladorestadopedido objestadopedido = new contoladorestadopedido();
            objestadopedido.estado_pedido = txtestadoingresarpedido.Text;

            try
            {
                int respuestaestadopedido = objestadopedido.ingresarestadopedido();
                if (respuestaestadopedido >= 1)
                {
                    MessageBox.Show("Estado Pedido insertado con éxito.");
                    LimpiarCamposEstadoPedido();
                    CargarTablaEstadoPedido();
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el Estado Pedido: " + ex.Message);
            }
        }
        //Actualizar Estado Pedido
        void actualizarDatosEstadoPedido() {

            contoladorestadopedido objestadopedido = new contoladorestadopedido();
            objestadopedido.estado_pedido = txtestadoingresarpedido.Text;
            contoladorestadopedido.id_estadopedido = Convert.ToInt16(txtidestadoproducto.Text);

            try
            {
                int respuestaestadopedido = objestadopedido.actualizarestadopedido();
                if (respuestaestadopedido >= 1)
                {
                    MessageBox.Show("Estado Pedido actualizado con éxito.");
                    LimpiarCamposEstadoPedido();
                    CargarTablaEstadoPedido();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el Estado Pedido: " + ex.Message);
            }
        }

        //..................No hacer caso............................

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        //..................Si hacer caso............................

        //Boton para ingresar datos del crud estado pedido
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            insertarDatosEstadoPedido();
        }

        //El CellContenClick para eliminar los estado pedidos 
        private void dgvestadopedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionadaEstadoPedido = dgvestadopedido.Rows[e.RowIndex];

                // Verifica si se hizo clic en el botón de eliminar (columna 1)
                if (e.ColumnIndex == 1) // Índice 1 para el botón "Eliminar"
                {
                    // Verifica si el checkbox está en la columna 0
                    if (filaSeleccionadaEstadoPedido.Cells[0] is DataGridViewCheckBoxCell checkBoxCell)
                    {
                        bool isCheckedEstadoPedido = Convert.ToBoolean(checkBoxCell.Value);

                        if (isCheckedEstadoPedido) // Solo elimina si está seleccionado
                        {
                            // Muestra un MessageBox con las opciones Sí y No
                            DialogResult result = MessageBox.Show("¿Desea eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes) // Si el usuario selecciona "Sí"
                            {
                                // Obtiene el ID del estado pedido de la celda correspondiente (suponiendo que está en la columna 2)
                                int idEstadoPedido = Convert.ToInt32(filaSeleccionadaEstadoPedido.Cells[2].Value); // Asumiendo que el ID está en la columna 2

                                // Llama al método para eliminar el estado de pedido
                                contoladorestadopedido objestadopedidoeliminar = new contoladorestadopedido();
                                int respuestaestadopedido = objestadopedidoeliminar.eliminardatosestadopedido(idEstadoPedido); // Pasar el ID del estado pedido al método eliminarDatos

                                if (respuestaestadopedido >= 1)
                                {
                                    MessageBox.Show("Estado Pedido eliminado con éxito.");
                                    CargarTablaEstadoPedido(); // Actualiza el DataGridView con los datos nuevos
                                    LimpiarCamposEstadoPedido();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo eliminar el estado pedido. Verifique los datos.");
                                }
                            }
                            else
                            {
                                // El usuario seleccionó "No", no se realiza ninguna acción
                                MessageBox.Show("Eliminación cancelada.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, seleccione un Estado Pedido para eliminar.");
                        }
                    }
                }
            }
       
        }
      
        
        //El celClick para mandar los datos del datagrid a los txt
        private void dgvestadopedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // Verifica que se hizo clic en una fila válida
            if (e.RowIndex >= 0)
            {
                // Captura el número de fila a la cual se le dio clic.
                int posicionestadopedido = e.RowIndex; // Usamos e.RowIndex directamente

                // Llenar los TextBox con los datos de la fila seleccionada
                txtidestadoproducto.Text = dgvestadopedido[2, posicionestadopedido].Value.ToString();
                txtestadoingresarpedido.Text = dgvestadopedido[3, posicionestadopedido].Value.ToString();

                // Marca el checkbox de la fila seleccionada
                foreach (DataGridViewRow row in dgvestadopedido.Rows)
                {
                    // Desmarcar todos los checkboxes en el DataGridView
                    if (row.Index != posicionestadopedido) // No desmarcar el checkbox de la fila seleccionada
                    {
                        row.Cells[0].Value = false; // Desmarcar
                    }
                    else
                    {
                        // Marcar el checkbox de la fila seleccionada
                        row.Cells[0].Value = true;
                    }
                }
            }
        }

        private void btnActualizarEstadoPedido_Click(object sender, EventArgs e)
        {
            actualizarDatosEstadoPedido();
            CargarTablaEstadoPedido();

        }

        //----------------------FIN CRUD ESTADO PEDIDO--------------------


        //------------------ CRUD Estado usuario INICIO-----------------

        private void dgvestadousuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionadaEstadoUsuario = dgvestadousuario.Rows[e.RowIndex];

                // Verifica si se hizo clic en el botón de eliminar (columna 1)
                if (e.ColumnIndex == 1) // Índice 1 para el botón "Eliminar"
                {
                    // Verifica si el checkbox está en la columna 0
                    if (filaSeleccionadaEstadoUsuario.Cells[0] is DataGridViewCheckBoxCell checkBoxCell)
                    {
                        bool isCheckedEstadoUsuario = Convert.ToBoolean(checkBoxCell.Value);

                        if (isCheckedEstadoUsuario) // Solo elimina si está seleccionado
                        {
                            // Muestra un MessageBox con las opciones Sí y No
                            DialogResult result = MessageBox.Show("¿Desea eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes) // Si el usuario selecciona "Sí"
                            {
                                // Obtiene el ID del estado pedido de la celda correspondiente (suponiendo que está en la columna 2)
                                int idEstadoUsuario = Convert.ToInt32(filaSeleccionadaEstadoUsuario.Cells[2].Value); // Asumiendo que el ID está en la columna 2

                                // Llama al método para eliminar el estado de pedido
                                controladorestadousuario objestadousuarioeliminar = new controladorestadousuario();
                                int respuestaestadousuario = objestadousuarioeliminar.eliminardatosestadousuario(idEstadoUsuario); // Pasar el ID del estado pedido al método eliminarDatos

                                if (respuestaestadousuario >= 1)
                                {
                                    MessageBox.Show("Estado usuario eliminado con éxito.");
                                    CargarTablaEstadoUsuario(); // Actualiza el DataGridView con los datos nuevos
                                    LimpiarCamposEstadoUsuario();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo eliminar el estado usuario. Verifique los datos.");
                                }
                            }
                            else
                            {
                                // El usuario seleccionó "No", no se realiza ninguna acción
                                MessageBox.Show("Eliminación cancelada.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, seleccione un Estado Pedido para eliminar.");
                        }
                    }
                }
            }

        }

        private void LimpiarCamposEstadoUsuario()
        {
            txtestadoingresarusuario.Text = string.Empty;
        }

        //Cargar Tabla Estado Usuario
        private void CargarTablaEstadoUsuario()
        {
            controladorestadousuario objestadousuariotabla = new controladorestadousuario();
            dgvestadousuario.DataSource = objestadousuariotabla.LeerDatosEstadoUsuarios();

        }

        //Ingresar Datos Estado Pedido
        void insertarDatosEstadoUsuario()
        {
            controladorestadousuario objestadousuario = new controladorestadousuario();
            objestadousuario.estado_usuario = txtestadoingresarusuario.Text;

            try
            {
                int respuestaestadousuario = objestadousuario.ingresarestadousuario();
                if (respuestaestadousuario >= 1)
                {
                    MessageBox.Show("Estado Usuario insertado con éxito.");
                    LimpiarCamposEstadoUsuario();
                    CargarTablaEstadoUsuario();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el Estado Usuario: " + ex.Message);
            }
        }

        //Actualizar Estado Pedido
        void actualizarDatosEstadoUsuario()
        {

            controladorestadousuario objestadousuario = new controladorestadousuario();
            objestadousuario.estado_usuario = txtestadoingresarusuario.Text;
            controladorestadousuario.id_estadousuario = Convert.ToInt16(txtIDprodu2.Text);

            try
            {
                int respuestaestadousuario = objestadousuario.actualizarestadousuario();
                if (respuestaestadousuario >= 1)
                {
                    MessageBox.Show("Estado Usuario actualizado con éxito.");
                    LimpiarCamposEstadoUsuario();
                    CargarTablaEstadoUsuario();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el Estado usuario: " + ex.Message);
            }
        }

        private void btnIngresarEstadousuario_Click(object sender, EventArgs e)
        {
            insertarDatosEstadoUsuario();
        }

        private void btnActualizarEstadousuario_Click(object sender, EventArgs e)
        {
            actualizarDatosEstadoUsuario();
            CargarTablaEstadoUsuario();
        }

        private void dgvestadousuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se hizo clic en una fila válida
            if (e.RowIndex >= 0)
            {
                // Captura el número de fila a la cual se le dio clic.
                int posicionestadousuario = e.RowIndex; // Usamos e.RowIndex directamente

                // Llenar los TextBox con los datos de la fila seleccionada
                txtIDprodu2.Text = dgvestadousuario[2, posicionestadousuario].Value.ToString();
                txtestadoingresarusuario.Text = dgvestadousuario[3, posicionestadousuario].Value.ToString();

                // Marca el checkbox de la fila seleccionada
                foreach (DataGridViewRow row in dgvestadousuario.Rows)
                {
                    // Desmarcar todos los checkboxes en el DataGridView
                    if (row.Index != posicionestadousuario) // No desmarcar el checkbox de la fila seleccionada
                    {
                        row.Cells[0].Value = false; // Desmarcar
                    }
                    else
                    {
                        // Marcar el checkbox de la fila seleccionada
                        row.Cells[0].Value = true;
                    }
                }
            }

        }

        //----------------------FIN CRUD ESTADO USUARIO--------------------


        //------------------ CRUD Estado Devolucion INICIO-----------------

        private void LimpiarCamposEstadoDevolucion()
        {
            txtestadodevolucion.Text = string.Empty;
        }



        private void CargarTablaEstadoDevolucion()
        {
            controlestadodevolucion objmestadodevolucion = new controlestadodevolucion();
            dgvestadodevolucion.DataSource = objmestadodevolucion.LeerDatosEstadosDevolucion();

        }

        //Ingresar Datos Metodo 
        void insertarDatosEstadoDevolucion()
        {
            controlestadodevolucion objmestadodevolucion= new controlestadodevolucion();
            objmestadodevolucion.estado_devolucion = txtestadodevolucion.Text;

            try
            {
                int respuestaestadodevolucion = objmestadodevolucion.agregarEstadoDevolucion();
                if (respuestaestadodevolucion >= 1)
                {
                    MessageBox.Show("Estado Devolucion insertado con éxito.");
                    LimpiarCamposEstadoDevolucion();
                    CargarTablaEstadoDevolucion();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el Estado Devolucion nuevo: " + ex.Message);
            }
        }


        //Actualizar Metodo 
        void actualizarDatosEstadoDevolucion()
        {

            controlestadodevolucion objmestadodevolucionactualizar = new controlestadodevolucion();
            objmestadodevolucionactualizar.estado_devolucion = txtestadodevolucion.Text;
            controlestadodevolucion.id_estado_devolucion = Convert.ToInt16(txtidestadodevolucion.Text);

            try
            {
                int respuestaestadodev = objmestadodevolucionactualizar.actualizarEstadoDevolucion();
                if (respuestaestadodev >= 1)
                {
                    MessageBox.Show("Estado Devolucion actualizado con éxito.");
                    LimpiarCamposEstadoDevolucion();
                    CargarTablaEstadoDevolucion();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el Estado Devolucion: " + ex.Message);
            }
        }



        private void btningresarestadodevolucion_Click(object sender, EventArgs e)
        {
            insertarDatosEstadoDevolucion();
        }

        private void btnactualizarestadodevolucion_Click(object sender, EventArgs e)
        {
            actualizarDatosEstadoDevolucion();
            CargarTablaEstadoDevolucion();
        }

        private void dgvestadodevolucion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionadaEstadoDevolucion = dgvestadodevolucion.Rows[e.RowIndex];

                // Verifica si se hizo clic en el botón de eliminar (columna 1)
                if (e.ColumnIndex == 1) // Índice 1 para el botón "Eliminar"
                {
                    // Verifica si el checkbox está en la columna 0
                    if (filaSeleccionadaEstadoDevolucion.Cells[0] is DataGridViewCheckBoxCell checkBoxCell)
                    {
                        bool isCheckedEstadoDevolucion = Convert.ToBoolean(checkBoxCell.Value);

                        if (isCheckedEstadoDevolucion) // Solo elimina si está seleccionado
                        {
                            // Muestra un MessageBox con las opciones Sí y No
                            DialogResult result = MessageBox.Show("¿Desea eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes) // Si el usuario selecciona "Sí"
                            {
                                // Obtiene el ID del estado de devolución de la celda correspondiente (suponiendo que está en la columna 2)
                                int id_estado_devolucion = Convert.ToInt32(filaSeleccionadaEstadoDevolucion.Cells[2].Value); // Asumiendo que el ID está en la columna 2

                                // Llama al método para eliminar el estado de devolución
                                controlestadodevolucion objEstadoDevolucionEliminar = new controlestadodevolucion();
                                int respuestaEstadoDevolucion = objEstadoDevolucionEliminar.eliminarDatosEstadoDevolucion(id_estado_devolucion); // Pasar el ID al método eliminarDatos

                                if (respuestaEstadoDevolucion >= 1)
                                {
                                    MessageBox.Show("Estado de devolución eliminado con éxito.");
                                    CargarTablaEstadoDevolucion(); // Actualiza el DataGridView con los datos nuevos
                                    LimpiarCamposEstadoDevolucion();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo eliminar el estado de devolución. Verifique los datos.");
                                }
                            }
                            else
                            {
                                // El usuario seleccionó "No", no se realiza ninguna acción
                                MessageBox.Show("Eliminación cancelada.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, seleccione un Estado de Devolución para eliminar.");
                        }
                    }
                }
            }


        }

        private void dgvestadodevolucion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Captura el número de fila a la cual se le dio clic.
                int posicionEstadoDevolucion = e.RowIndex; // Usamos e.RowIndex directamente

                // Llenar los TextBox con los datos de la fila seleccionada
                txtidestadodevolucion.Text = dgvestadodevolucion[2, posicionEstadoDevolucion].Value.ToString();
                txtestadodevolucion.Text = dgvestadodevolucion[3, posicionEstadoDevolucion].Value.ToString();

                // Marca el checkbox de la fila seleccionada
                foreach (DataGridViewRow row in dgvestadodevolucion.Rows)
                {
                    // Desmarcar todos los checkboxes en el DataGridView
                    if (row.Index != posicionEstadoDevolucion) // No desmarcar el checkbox de la fila seleccionada
                    {
                        row.Cells[0].Value = false; // Desmarcar
                    }
                    else
                    {
                        // Marcar el checkbox de la fila seleccionada
                        row.Cells[0].Value = true;
                    }
                }
            }

        }
        //------------------ CRUD Estado Devolucion FIN--------------------

        //------------------ CRUD Estado Reembolso INICIO-----------------


        private void CargarTablaEstadoReembolso()
        {
            controladorestadoreembolso objestactablaesrem = new controladorestadoreembolso();
            dgvestadoreembolso.DataSource = objestactablaesrem.LeerDatosEstadosReembolso();

        }

        private void LimpiarCamposEstadoReembolso()
        {
            txtestadoreembolso.Text = string.Empty;
            txtidestadoreembolso.Text = string.Empty;
        }

        void insertarDatosEstadosReembolso()
        {
            // Crear una instancia del controlador de estado de reembolso
            controladorestadoreembolso objestadoreembolso = new controladorestadoreembolso();

            // Asignar el valor del TextBox a la propiedad estado_reembolso del controlador
            objestadoreembolso.estado_reembolso = txtestadoreembolso.Text;

            try
            {
                // Llamar al método para insertar el nuevo estado de reembolso
                int respuestaEstadoReembolso = objestadoreembolso.agregarEstadoReembolso();

                // Verificar si la inserción fue exitosa
                if (respuestaEstadoReembolso >= 1)
                {
                    MessageBox.Show("Estado de reembolso insertado con éxito.");

                    // Limpiar los campos del formulario
                    LimpiarCamposEstadoReembolso();

                    // Recargar la tabla de estados de reembolso en el DataGridView
                    CargarTablaEstadoReembolso();
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de falla
                MessageBox.Show("Error al insertar el nuevo estado de reembolso: " + ex.Message);
            }
        }

        void actualizarDatosEstadosReembolso()
        {
            // Crear una instancia del controlador de estado de reembolso
            controladorestadoreembolso objestadoreembolso = new controladorestadoreembolso();

            // Asignar el valor del TextBox a la propiedad estado_reembolso del controlador
            objestadoreembolso.estado_reembolso = txtestadoreembolso.Text;

            // Convertir y asignar el ID del estado de reembolso desde el TextBox correspondiente
            controladorestadoreembolso.id_estado_reembolso = Convert.ToInt16(txtidestadoreembolso.Text);

            try
            {
                // Llamar al método para actualizar el estado de reembolso
                int respuestaEstadoReembolso = objestadoreembolso.actualizarEstadoReembolso();

                // Verificar si la actualización fue exitosa
                if (respuestaEstadoReembolso >= 1)
                {
                    MessageBox.Show("Estado de reembolso actualizado con éxito.");

                    // Limpiar los campos del formulario
                    LimpiarCamposEstadoReembolso();

                    // Recargar la tabla de estados de reembolso en el DataGridView
                    CargarTablaEstadoReembolso();
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de falla
                MessageBox.Show("Error al actualizar el estado de reembolso: " + ex.Message);
            }
        }

        private void dgvestadoreembolso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionadaEstadoReembolso = dgvestadoreembolso.Rows[e.RowIndex];

                // Verifica si se hizo clic en el botón de eliminar (columna 1)
                if (e.ColumnIndex == 1) // Índice 1 para el botón "Eliminar"
                {
                    // Verifica si el checkbox está en la columna 0
                    if (filaSeleccionadaEstadoReembolso.Cells[0] is DataGridViewCheckBoxCell checkBoxCell)
                    {
                        bool isCheckedEstadoReembolso = Convert.ToBoolean(checkBoxCell.Value);

                        if (isCheckedEstadoReembolso) // Solo elimina si está seleccionado
                        {
                            // Muestra un MessageBox con las opciones Sí y No
                            DialogResult result = MessageBox.Show("¿Desea eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes) // Si el usuario selecciona "Sí"
                            {
                                // Obtiene el ID del estado de reembolso de la celda correspondiente (suponiendo que está en la columna 2)
                                int id_estado_reembolso = Convert.ToInt32(filaSeleccionadaEstadoReembolso.Cells[2].Value); // Asumiendo que el ID está en la columna 2

                                // Llama al método para eliminar el estado de reembolso
                                controladorestadoreembolso objestadoreembolsoeliminar = new controladorestadoreembolso();
                                int respuestaEstadoReembolso = objestadoreembolsoeliminar.eliminarDatosEstadoReembolso(id_estado_reembolso); // Pasar el ID del estado de reembolso al método eliminar

                                if (respuestaEstadoReembolso >= 1)
                                {
                                    MessageBox.Show("Estado de reembolso eliminado con éxito.");
                                    CargarTablaEstadoReembolso(); // Actualiza el DataGridView con los datos nuevos
                                    LimpiarCamposEstadoReembolso();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo eliminar el estado de reembolso. Verifique los datos.");
                                }
                            }
                            else
                            {
                                // El usuario seleccionó "No", no se realiza ninguna acción
                                MessageBox.Show("Eliminación cancelada.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, seleccione un estado de reembolso para eliminar.");
                        }
                    }
                }
            }



        }

        private void dgvestadoreembolso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Captura el número de fila a la cual se le dio clic.
                int posicionEstadoReembolso = e.RowIndex; // Usamos e.RowIndex directamente

                // Llenar los TextBox con los datos de la fila seleccionada
                txtidestadoreembolso.Text = dgvestadoreembolso[2, posicionEstadoReembolso].Value.ToString(); // Suponiendo que la columna 2 tiene el ID
                txtestadoreembolso.Text = dgvestadoreembolso[3, posicionEstadoReembolso].Value.ToString(); // Suponiendo que la columna 3 tiene la descripción

                // Marca el checkbox de la fila seleccionada
                foreach (DataGridViewRow row in dgvestadoreembolso.Rows)
                {
                    // Desmarcar todos los checkboxes en el DataGridView
                    if (row.Index != posicionEstadoReembolso) // No desmarcar el checkbox de la fila seleccionada
                    {
                        row.Cells[0].Value = false; // Desmarcar
                    }
                    else
                    {
                        // Marcar el checkbox de la fila seleccionada
                        row.Cells[0].Value = true; // Marcar el checkbox de la fila seleccionada
                    }
                }
            }

        }

        private void btningresarestadoreembolso_Click(object sender, EventArgs e)
        {
            insertarDatosEstadosReembolso();
        }

        private void btnactualizarestadoreembolso_Click(object sender, EventArgs e)
        {
            actualizarDatosEstadosReembolso();
            LimpiarCamposEstadoReembolso();
        }


        //------------------ CRUD Estado Reembolso FIN-----------------



        //------------------ CRUD Estado Estado Pago Inicio-----------------

        private void CargarTablaEstadoPago()
        {
            controladorestadopagos objestactablaep = new controladorestadopagos();
            dgvestadopagos.DataSource = objestactablaep.LeerDatosEstadosPago();

        }

        private void LimpiarCamposEstadoPago()
        {
            txtestadopago.Text = string.Empty;
            txtidestadopago.Text = string.Empty;
        }

        void insertarDatosEstadosPagos()
        {
            // Crear una instancia del controlador de estado de pago
            controladorestadopagos objestadopago = new controladorestadopagos();

            // Asignar el valor del TextBox a la propiedad descripción del controlador
            objestadopago.estado_pago = txtestadopago.Text;

            try
            {
                // Llamar al método para insertar el nuevo estado de pago
                int respuestaestadopago = objestadopago.agregarEstadoPago();

                // Verificar si la inserción fue exitosa
                if (respuestaestadopago >= 1)
                {
                    MessageBox.Show("Estado de pago insertado con éxito.");

                    // Limpiar los campos del formulario
                    LimpiarCamposEstadoPago();

                    // Recargar la tabla de estados de pago en el DataGridView
                    CargarTablaEstadoPago();
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de falla
                MessageBox.Show("Error al insertar el nuevo estado de pago: " + ex.Message);
            }
        }

        void actualizarDatosEstadosPagos()
        {
            // Crear una instancia del controlador de estado de pago
            controladorestadopagos objestadopago = new controladorestadopagos();

            // Asignar el valor del TextBox a la propiedad descripción del controlador
            objestadopago.estado_pago = txtestadopago.Text;

            // Convertir y asignar el ID del estado de pago desde el TextBox correspondiente
            controladorestadopagos.id_estado_pago = Convert.ToInt16(txtidestadopago.Text);

            try
            {
                // Llamar al método para actualizar el estado de pago
                int respuestaestadopago = objestadopago.actualizarEstadoPago();

                // Verificar si la actualización fue exitosa
                if (respuestaestadopago >= 1)
                {
                    MessageBox.Show("Estado de pago actualizado con éxito.");

                    // Limpiar los campos del formulario
                    LimpiarCamposEstadoPago();

                    // Recargar la tabla de estados de pago en el DataGridView
                    CargarTablaEstadoPago();
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de falla
                MessageBox.Show("Error al actualizar el estado de pago: " + ex.Message);
            }
        }



        private void btningresaresradopagos_Click(object sender, EventArgs e)
        {
            insertarDatosEstadosPagos();
        }

        private void btnactualizarestadopago_Click(object sender, EventArgs e)
        {
            actualizarDatosEstadosPagos();
            CargarTablaEstadoPago();

        }

        private void dgvestadopagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionadaEstadoPago = dgvestadopagos.Rows[e.RowIndex];

                // Verifica si se hizo clic en el botón de eliminar (columna 1)
                if (e.ColumnIndex == 1) // Índice 1 para el botón "Eliminar"
                {
                    // Verifica si el checkbox está en la columna 0
                    if (filaSeleccionadaEstadoPago.Cells[0] is DataGridViewCheckBoxCell checkBoxCell)
                    {
                        bool isCheckedEstadoPago = Convert.ToBoolean(checkBoxCell.Value);

                        if (isCheckedEstadoPago) // Solo elimina si está seleccionado
                        {
                            // Muestra un MessageBox con las opciones Sí y No
                            DialogResult result = MessageBox.Show("¿Desea eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes) // Si el usuario selecciona "Sí"
                            {
                                // Obtiene el ID del estado de pago de la celda correspondiente (suponiendo que está en la columna 2)
                                int id_estadopago = Convert.ToInt32(filaSeleccionadaEstadoPago.Cells[2].Value); // Asumiendo que el ID está en la columna 2

                                // Llama al método para eliminar el estado de pago
                                controladorestadopagos objestadopagoeliminar = new controladorestadopagos();
                                int respuestaestadopago = objestadopagoeliminar.eliminarDatosEstadoPago(id_estadopago); // Pasar el ID del estado de pago al método eliminar

                                if (respuestaestadopago >= 1)
                                {
                                    MessageBox.Show("Estado de pago eliminado con éxito.");
                                    CargarTablaEstadoPago(); // Actualiza el DataGridView con los datos nuevos
                                    LimpiarCamposEstadoPago();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo eliminar el estado de pago. Verifique los datos.");
                                }
                            }
                            else
                            {
                                // El usuario seleccionó "No", no se realiza ninguna acción
                                MessageBox.Show("Eliminación cancelada.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, seleccione un estado de pago para eliminar.");
                        }
                    }
                }
            }

        }

        private void dgvestadopagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Captura el número de fila a la cual se le dio clic.
                int posicionEstadoPago = e.RowIndex; // Usamos e.RowIndex directamente

                // Llenar los TextBox con los datos de la fila seleccionada
                txtidestadopago.Text = dgvestadopagos[2, posicionEstadoPago].Value.ToString(); // Suponiendo que la columna 2 tiene el ID
                txtestadopago.Text = dgvestadopagos[3, posicionEstadoPago].Value.ToString(); // Suponiendo que la columna 3 tiene la descripción

                // Marca el checkbox de la fila seleccionada
                foreach (DataGridViewRow row in dgvestadopagos.Rows)
                {
                    // Desmarcar todos los checkboxes en el DataGridView
                    if (row.Index != posicionEstadoPago) // No desmarcar el checkbox de la fila seleccionada
                    {
                        row.Cells[0].Value = false; // Desmarcar
                    }
                    else
                    {
                        // Marcar el checkbox de la fila seleccionada
                        row.Cells[0].Value = true; // Marcar el checkbox de la fila seleccionada
                    }
                }
            }

        }
    }
}
