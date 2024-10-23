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
    public partial class FormTipos : Form
    {
       

        public FormTipos()
        {
            InitializeComponent();
        }

        private void FormTipos_Load(object sender, EventArgs e)
        {


            CargarTablaTipoDoc();

            //------------------ PERSONALIZAR DGV CRUD Tipo Documento INICIO-----------------

            //Aqui se agrega el check al dgv
            if (!dgvtipodoc.Columns.Contains("Seleccionar"))
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "", // Título de la columna
                    Width = 30, // Establecer un ancho específico
                    Name = "" // Nombre de la columna para poder referenciarla más tarde
                };
                dgvtipodoc.Columns.Insert(0, checkColumn); // Insertar en la posición 0
            }

            if (!dgvtipodoc.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Text = "Del",
                    UseColumnTextForButtonValue = true,
                    Width = 50 // Establecer un ancho específico
                };
                dgvtipodoc.Columns.Insert(1, btnDelete);
            }

            //------------------ PERSONALIZAR DGV CRUD Tipo Documento FIN-----------------

            CargarTablaMetodoPago();

            //------------------ PERSONALIZAR DGV CRUD Metodo Pago INICIO-----------------
            //Aqui se agrega el check al dgv
            if (!dgvmetodopago.Columns.Contains("Seleccionar"))
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "", // Título de la columna
                    Width = 30, // Establecer un ancho específico
                    Name = "" // Nombre de la columna para poder referenciarla más tarde
                };
                dgvmetodopago.Columns.Insert(0, checkColumn); // Insertar en la posición 0
            }

            if (!dgvmetodopago.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Text = "Del",
                    UseColumnTextForButtonValue = true,
                    Width = 50 // Establecer un ancho específico
                };
                dgvmetodopago.Columns.Insert(1, btnDelete);
            }

            //------------------ PERSONALIZAR DGV CRUD Metodo Pago FIN-----------------

             CargarTablaMetodoReembolso();

            //------------------ PERSONALIZAR DGV CRUD Metodo Reembolso INICIO-----------------
            //Aqui se agrega el check al dgv
            if (!dgvmetodoreembolso.Columns.Contains("Seleccionar"))
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "", // Título de la columna
                    Width = 30, // Establecer un ancho específico
                    Name = "" // Nombre de la columna para poder referenciarla más tarde
                };
                dgvmetodoreembolso.Columns.Insert(0, checkColumn); // Insertar en la posición 0
            }

            if (!dgvmetodopago.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Text = "Del",
                    UseColumnTextForButtonValue = true,
                    Width = 50 // Establecer un ancho específico
                };
                dgvmetodoreembolso.Columns.Insert(1, btnDelete);
            }

            //------------------ PERSONALIZAR DGV CRUD Metodo Pago FIN-----------------

            CargarTablaEditoriales();

            //------------------ PERSONALIZAR DGV CRUD Editoriales INICIO-----------------
            //Aqui se agrega el check al dgv
            if (!dgveditoriales.Columns.Contains("Seleccionar"))
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "", // Título de la columna
                    Width = 30, // Establecer un ancho específico
                    Name = "" // Nombre de la columna para poder referenciarla más tarde
                };
                dgveditoriales.Columns.Insert(0, checkColumn); // Insertar en la posición 0
            }

            if (!dgvmetodopago.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Text = "Del",
                    UseColumnTextForButtonValue = true,
                    Width = 50 // Establecer un ancho específico
                };
                dgveditoriales.Columns.Insert(1, btnDelete);
            }

            //------------------ PERSONALIZAR DGV CRUD Editoriales FIN-----------------

            CargarTablaCat();

            //------------------ PERSONALIZAR DGV CRUD Categorias INICIO-----------------
            //Aqui se agrega el check al dgv
            if (!dgvcategoria.Columns.Contains("Seleccionar"))
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "", // Título de la columna
                    Width = 30, // Establecer un ancho específico
                    Name = "" // Nombre de la columna para poder referenciarla más tarde
                };
                dgvcategoria.Columns.Insert(0, checkColumn); // Insertar en la posición 0
            }

            if (!dgvcategoria.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Text = "Del",
                    UseColumnTextForButtonValue = true,
                    Width = 50 // Establecer un ancho específico
                };
                dgvcategoria.Columns.Insert(1, btnDelete);
            }

        }


        //----------------------INICIO CRUD Tipo Doc--------------------
        private void LimpiarCamposTipoDoc()
        {
            textBox1tipodocumento.Text = string.Empty;
        }

        private void CargarTablaTipoDoc()
        {
            controladortipodocumentos objestactabla = new controladortipodocumentos();
            dgvtipodoc.DataSource = objestactabla.ObtenerTiposDocumentos();

        }


        void insertarDatosTipoDoc()
        {
            controladortipodocumentos objtipodoc = new controladortipodocumentos();
            objtipodoc.tipo_documento = textBox1tipodocumento.Text;

            try
            {
                int respuestatipodoc = objtipodoc.InsertarTipoDocumento();
                if (respuestatipodoc >= 1)
                {
                    MessageBox.Show("Tipo doc insertado con éxito.");
                    LimpiarCamposTipoDoc();
                    CargarTablaTipoDoc();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el Tipo doc: " + ex.Message);
            }
        }

        void actualizarDatosTipoDoc()
        {

            controladortipodocumentos objetipodocact = new controladortipodocumentos();
            objetipodocact.tipo_documento = textBox1tipodocumento.Text;
            controladortipodocumentos.id_tipodoc = Convert.ToInt16(textBox2idtd.Text);

            try
            {
                int respuestatipodocac = objetipodocact.ActualizarTipoDocumento();
                if (respuestatipodocac >= 1)
                {
                    MessageBox.Show("Tipo doc actualizado con éxito.");
                    LimpiarCamposTipoDoc();
                    CargarTablaTipoDoc();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el Tipo doc: " + ex.Message);
            }
        }


        //No hacer caso
        private void btningresartp_Click(object sender, EventArgs e)
        {
          
           
        }
        //No hacer caso
        private void btnactualizartp_Click(object sender, EventArgs e)
        {
           
        }


        private void dgvtipodoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionadaTipoDoc = dgvtipodoc.Rows[e.RowIndex];

                // Verifica si se hizo clic en el botón de eliminar (suponiendo que es la columna 1)
                if (e.ColumnIndex == 1) // Índice 1 para el botón "Eliminar"
                {
                    // Verifica si el checkbox está en la columna 0
                    if (filaSeleccionadaTipoDoc.Cells[0] is DataGridViewCheckBoxCell checkBoxCell)
                    {
                        bool isCheckedTipoDoc = Convert.ToBoolean(checkBoxCell.Value);

                        if (isCheckedTipoDoc) // Solo elimina si está seleccionado
                        {
                            // Muestra un MessageBox con las opciones Sí y No
                            DialogResult result = MessageBox.Show("¿Desea eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes) // Si el usuario selecciona "Sí"
                            {
                                // Obtiene el ID del tipo de documento de la celda correspondiente (suponiendo que está en la columna 2)
                                int idTipoDoc = Convert.ToInt32(filaSeleccionadaTipoDoc.Cells[2].Value); // Asumiendo que el ID está en la columna 2

                                // Asigna el ID a la propiedad estática
                                controladortipodocumentos.id_tipodoc = idTipoDoc;

                                // Llama al método para eliminar el tipo de documento
                                controladortipodocumentos objTipoDocEliminar = new controladortipodocumentos();

                                // Llama al método eliminar
                                int respuestaTipoDoc = objTipoDocEliminar.EliminarTipoDocumento(); // Ya no necesitas pasar el ID como parámetro

                                if (respuestaTipoDoc >= 1)
                                {
                                    MessageBox.Show("Tipo de documento eliminado con éxito.");
                                    CargarTablaTipoDoc(); // Actualiza el DataGridView con los datos nuevos
                                    LimpiarCamposTipoDoc(); // Método para limpiar los campos de entrada
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo eliminar el tipo de documento. Verifique los datos.");
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
                            MessageBox.Show("Por favor, seleccione un tipo de documento para eliminar.");
                        }
                    }
                }
            }

        }

        private void dgvtipodoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se hizo clic en una fila válida
            if (e.RowIndex >= 0)
            {
                // Captura el número de fila a la cual se le dio clic.
                int posicionestipodoc = e.RowIndex; // Usamos e.RowIndex directamente

                // Llenar los TextBox con los datos de la fila seleccionada
                textBox2idtd.Text = dgvtipodoc[2, posicionestipodoc].Value.ToString();
                textBox1tipodocumento.Text = dgvtipodoc[3, posicionestipodoc].Value.ToString();

                // Marca el checkbox de la fila seleccionada
                foreach (DataGridViewRow row in dgvtipodoc.Rows)
                {
                    // Desmarcar todos los checkboxes en el DataGridView
                    if (row.Index != posicionestipodoc) // No desmarcar el checkbox de la fila seleccionada
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

        private void btningresartp_Click_1(object sender, EventArgs e)
        {
            insertarDatosTipoDoc();

        }

        private void btnactualizartp_Click_1(object sender, EventArgs e)
        {
            actualizarDatosTipoDoc();
        }

        //No hacer caso
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        //----------------------INICIO CRUD Metodo Pago--------------------

        private void LimpiarCamposMetodoPago()
        {
            txtmetodopago.Text = string.Empty;
        }

        private void CargarTablaMetodoPago()
        {
            controladormetodopago objmetodopagotabla = new controladormetodopago();
            dgvmetodopago.DataSource = objmetodopagotabla.LeerDatosMetodosPagos();

        }

        //Ingresar Datos Metodo Pago
        void insertarDatosMetodosPagos()
        {
            controladormetodopago objmetodopago = new controladormetodopago();
            objmetodopago.descripcion = txtmetodopago.Text;

            try
            {
                int respuestametodopago = objmetodopago.ingresarmetodopago();
                if (respuestametodopago >= 1)
                {
                    MessageBox.Show("Metodo de pago insertado con éxito.");
                    LimpiarCamposMetodoPago();
                    CargarTablaMetodoPago();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el Meotodo de pago nuevo: " + ex.Message);
            }
        }


        //Actualizar Metodo Pago
        void actualizarDatosMetodosPagos()
        {

            controladormetodopago objmetodopago = new controladormetodopago();
            objmetodopago.descripcion = txtmetodopago.Text;
            controladormetodopago.id_metodopago = Convert.ToInt16(txtIDprodu3.Text);

            try
            {
                int respuestametodopago = objmetodopago.actualizarmetodospagos();
                if (respuestametodopago >= 1)
                {
                    MessageBox.Show("Metodo pago actualizado con éxito.");
                    LimpiarCamposMetodoPago();
                    CargarTablaMetodoPago();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el Metodo de pago: " + ex.Message);
            }
        }

        private void dgvmetodopago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionadaMetodoPago = dgvmetodopago.Rows[e.RowIndex];

                // Verifica si se hizo clic en el botón de eliminar (columna 1)
                if (e.ColumnIndex == 1) // Índice 1 para el botón "Eliminar"
                {
                    // Verifica si el checkbox está en la columna 0
                    if (filaSeleccionadaMetodoPago.Cells[0] is DataGridViewCheckBoxCell checkBoxCell)
                    {
                        bool isCheckedMetodoPago = Convert.ToBoolean(checkBoxCell.Value);

                        if (isCheckedMetodoPago) // Solo elimina si está seleccionado
                        {
                            // Muestra un MessageBox con las opciones Sí y No
                            DialogResult result = MessageBox.Show("¿Desea eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes) // Si el usuario selecciona "Sí"
                            {
                                // Obtiene el ID del estado pedido de la celda correspondiente (suponiendo que está en la columna 2)
                                int id_metodopago = Convert.ToInt32(filaSeleccionadaMetodoPago.Cells[2].Value); // Asumiendo que el ID está en la columna 2

                                // Llama al método para eliminar el estado de pedido
                                controladormetodopago objmetodopagoeliminar = new controladormetodopago();
                                int respuestametodopago = objmetodopagoeliminar.eliminardatometodopago(id_metodopago); // Pasar el ID del estado pedido al método eliminarDatos

                                if (respuestametodopago >= 1)
                                {
                                    MessageBox.Show("Metodo de pago eliminado con éxito.");
                                    CargarTablaMetodoPago(); // Actualiza el DataGridView con los datos nuevos
                                    LimpiarCamposMetodoPago();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo eliminar el metodo de pago. Verifique los datos.");
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

        private void dgvmetodopago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se hizo clic en una fila válida
            if (e.RowIndex >= 0)
            {
                // Captura el número de fila a la cual se le dio clic.
                int posicionmetodopago = e.RowIndex; // Usamos e.RowIndex directamente

                // Llenar los TextBox con los datos de la fila seleccionada
                txtIDprodu3.Text = dgvmetodopago[2, posicionmetodopago].Value.ToString();
                txtmetodopago.Text = dgvmetodopago[3, posicionmetodopago].Value.ToString();

                // Marca el checkbox de la fila seleccionada
                foreach (DataGridViewRow row in dgvmetodopago.Rows)
                {
                    // Desmarcar todos los checkboxes en el DataGridView
                    if (row.Index != posicionmetodopago) // No desmarcar el checkbox de la fila seleccionada
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

        private void btnIngresarMetodoPago_Click(object sender, EventArgs e)
        {
            insertarDatosMetodosPagos();
        }

        private void btnActualizarMetodoPago_Click(object sender, EventArgs e)
        {
            actualizarDatosMetodosPagos();
            CargarTablaMetodoPago();
        }



        //----------------------INICIO CRUD Metodo Reembolso--------------------

        private void CargarTablaMetodoReembolso()
        {
            controladormetodoreembolso objestactablamr = new controladormetodoreembolso();
            dgvmetodoreembolso.DataSource = objestactablamr.LeerDatosMetodosReembolso();

        }

        private void LimpiarCamposMetodoReembolso()
        {
            txtmetodoreembolso.Text = string.Empty;
            txtIDmetoreem.Text = string.Empty;
        }


        void insertarDatosMetodosReembolsos()
        {
            // Crear una instancia del controlador de método de reembolso
            controladormetodoreembolso objmetodoreembolso = new controladormetodoreembolso();

            // Asignar el valor del TextBox a la propiedad descripción del controlador
            objmetodoreembolso.descripcion = txtmetodoreembolso.Text;

            try
            {
                // Llamar al método para insertar el nuevo método de reembolso
                int respuestametodoreembolso = objmetodoreembolso.ingresarmetodoreembolso();

                // Verificar si la inserción fue exitosa
                if (respuestametodoreembolso >= 1)
                {
                    MessageBox.Show("Método de reembolso insertado con éxito.");

                    // Limpiar los campos del formulario
                    LimpiarCamposMetodoReembolso();

                    // Recargar la tabla de métodos de reembolso en el DataGridView
                    CargarTablaMetodoReembolso();
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de falla
                MessageBox.Show("Error al insertar el nuevo método de reembolso: " + ex.Message);
            }
        }

        void actualizarDatosMetodosReembolsos()
        {
            // Crear una instancia del controlador de método de reembolso
            controladormetodoreembolso objmetodoreembolso = new controladormetodoreembolso();

            // Asignar el valor del TextBox a la propiedad descripción del controlador
            objmetodoreembolso.descripcion = txtmetodoreembolso.Text;

            // Convertir y asignar el ID del método de reembolso desde el TextBox correspondiente
            controladormetodoreembolso.id_metodoreembolso = Convert.ToInt16(txtIDmetoreem.Text);

            try
            {
                // Llamar al método para actualizar el método de reembolso
                int respuestametodoreembolso = objmetodoreembolso.actualizarmetodoreembolso();

                // Verificar si la actualización fue exitosa
                if (respuestametodoreembolso >= 1)
                {
                    MessageBox.Show("Método de reembolso actualizado con éxito.");

                    // Limpiar los campos del formulario
                    LimpiarCamposMetodoReembolso();

                    // Recargar la tabla de métodos de reembolso en el DataGridView
                    CargarTablaMetodoReembolso();
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de falla
                MessageBox.Show("Error al actualizar el método de reembolso: " + ex.Message);
            }
        }

        private void dgvmetodoreembolso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionadaMetodoReembolso = dgvmetodoreembolso.Rows[e.RowIndex];

                // Verifica si se hizo clic en el botón de eliminar (columna 1)
                if (e.ColumnIndex == 1) // Índice 1 para el botón "Eliminar"
                {
                    // Verifica si el checkbox está en la columna 0
                    if (filaSeleccionadaMetodoReembolso.Cells[0] is DataGridViewCheckBoxCell checkBoxCell)
                    {
                        bool isCheckedMetodoReembolso = Convert.ToBoolean(checkBoxCell.Value);

                        if (isCheckedMetodoReembolso) // Solo elimina si está seleccionado
                        {
                            // Muestra un MessageBox con las opciones Sí y No
                            DialogResult result = MessageBox.Show("¿Desea eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes) // Si el usuario selecciona "Sí"
                            {
                                // Obtiene el ID del método de reembolso de la celda correspondiente (suponiendo que está en la columna 2)
                                int id_metodoreembolso = Convert.ToInt32(filaSeleccionadaMetodoReembolso.Cells[2].Value); // Asumiendo que el ID está en la columna 2

                                // Llama al método para eliminar el método de reembolso
                                controladormetodoreembolso objmetodoreembolsoeliminar = new controladormetodoreembolso();
                                int respuestametodoreembolso = objmetodoreembolsoeliminar.eliminardatometodoreembolso(id_metodoreembolso); // Pasar el ID del método de reembolso al método eliminar

                                if (respuestametodoreembolso >= 1)
                                {
                                    MessageBox.Show("Método de reembolso eliminado con éxito.");
                                    CargarTablaMetodoReembolso(); // Actualiza el DataGridView con los datos nuevos
                                    LimpiarCamposMetodoReembolso();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo eliminar el método de reembolso. Verifique los datos.");
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
                            MessageBox.Show("Por favor, seleccione un método de reembolso para eliminar.");
                        }
                    }
                }
            }

        }

        private void dgvmetodoreembolso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se hizo clic en una fila válida
            if (e.RowIndex >= 0)
            {
                // Captura el número de fila a la cual se le dio clic.
                int posicionMetodoReembolso = e.RowIndex; // Usamos e.RowIndex directamente

                // Llenar los TextBox con los datos de la fila seleccionada
                txtIDmetoreem.Text = dgvmetodoreembolso[2, posicionMetodoReembolso].Value.ToString(); // Suponiendo que la columna 2 tiene el ID
                txtmetodoreembolso.Text = dgvmetodoreembolso[3, posicionMetodoReembolso].Value.ToString(); // Suponiendo que la columna 3 tiene la descripción

                // Marca el checkbox de la fila seleccionada
                foreach (DataGridViewRow row in dgvmetodoreembolso.Rows)
                {
                    // Desmarcar todos los checkboxes en el DataGridView
                    if (row.Index != posicionMetodoReembolso) // No desmarcar el checkbox de la fila seleccionada
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

        private void button12_Click(object sender, EventArgs e)
        {
            insertarDatosMetodosReembolsos();
          
        }

        private void btnactualizarmetodoreembolso_Click(object sender, EventArgs e)
        {
            actualizarDatosMetodosReembolsos();
            LimpiarCamposMetodoReembolso();

        }


        //----------------------INICIO CRUD Editoriales--------------------

        private void LimpiarCamposEditoriales()
        {
            txteditoriales.Text = string.Empty;
        }

        private void CargarTablaEditoriales()
        {
            controladoreditoriales objestactablaeditorial = new controladoreditoriales();
            dgveditoriales.DataSource = objestactablaeditorial.LeerDatosEditoriales();

        }

        void insertarDatosEditorial()
        {
            controladoreditoriales objEditorial = new controladoreditoriales();
            objEditorial.nombre_editorial = txteditoriales.Text; // Captura el nombre de la editorial desde el TextBox

            try
            {
                // Llama al método para insertar la editorial
                int respuestaEditorial = objEditorial.ingresareditorial();

                if (respuestaEditorial >= 1)
                {
                    MessageBox.Show("Editorial insertada con éxito.");
                    LimpiarCamposEditoriales(); // Limpiar los campos después de la inserción
                    CargarTablaEditoriales();  // Recarga el DataGridView con los datos actualizados
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar la editorial: " + ex.Message);
            }
        }

        void actualizarDatosEditoriales()
        {
            controladoreditoriales objEditorial = new controladoreditoriales();
            objEditorial.nombre_editorial = txteditoriales.Text; // Captura el nombre de la editorial desde el TextBox
            controladoreditoriales.id_editorial = Convert.ToInt32(txtideditoriales.Text); // Captura el ID de la editorial

            try
            {
                // Llama al método para actualizar la editorial
                int respuestaEditorial = objEditorial.actualizareditorial();

                if (respuestaEditorial >= 1)
                {
                    MessageBox.Show("Editorial actualizada con éxito.");
                    LimpiarCamposEditoriales(); // Limpia los campos después de la actualización
                    CargarTablaEditoriales();  // Recarga el DataGridView con los datos actualizados
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la editorial: " + ex.Message);
            }
        }

        private void btningresareditoriales_Click(object sender, EventArgs e)
        {
            insertarDatosEditorial();
        }

        private void btnactualizareditoriales_Click(object sender, EventArgs e)
        {
            actualizarDatosEditoriales();
        }

        private void dgveditoriales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionadaEditorial = dgveditoriales.Rows[e.RowIndex];

                // Verifica si se hizo clic en el botón de eliminar (columna 1)
                if (e.ColumnIndex == 1) // Índice 1 para el botón "Eliminar"
                {
                    // Verifica si el checkbox está en la columna 0
                    if (filaSeleccionadaEditorial.Cells[0] is DataGridViewCheckBoxCell checkBoxCell)
                    {
                        bool isCheckedEditorial = Convert.ToBoolean(checkBoxCell.Value);

                        if (isCheckedEditorial) // Solo elimina si está seleccionado
                        {
                            // Muestra un MessageBox con las opciones Sí y No
                            DialogResult result = MessageBox.Show("¿Desea eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes) // Si el usuario selecciona "Sí"
                            {
                                // Obtiene el ID de la editorial de la celda correspondiente (suponiendo que está en la columna 2)
                                int id_editorial = Convert.ToInt32(filaSeleccionadaEditorial.Cells[2].Value); // Asumiendo que el ID está en la columna 2

                                // Llama al método para eliminar la editorial
                                controladoreditoriales objEditorialEliminar = new controladoreditoriales();
                                int respuestaEliminar = objEditorialEliminar.eliminarDatoEditorial(id_editorial); // Pasar el ID de la editorial al método eliminar

                                if (respuestaEliminar >= 1)
                                {
                                    MessageBox.Show("Editorial eliminada con éxito.");
                                    CargarTablaEditoriales(); // Actualiza el DataGridView con los datos nuevos
                                    LimpiarCamposEditoriales(); // Limpia los campos
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo eliminar la editorial. Verifique los datos.");
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
                            MessageBox.Show("Por favor, seleccione una editorial para eliminar.");
                        }
                    }
                }
            }


        }

        private void dgveditoriales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Captura el número de fila a la cual se le dio clic.
                int posicionEditorial = e.RowIndex; // Usamos e.RowIndex directamente

                // Llenar los TextBox con los datos de la fila seleccionada
                txtideditoriales.Text = dgveditoriales[2, posicionEditorial].Value.ToString(); // Suponiendo que la columna 0 tiene el ID
                txteditoriales.Text = dgveditoriales[3, posicionEditorial].Value.ToString(); // Suponiendo que la columna 1 tiene la descripción

                // Marca el checkbox de la fila seleccionada
                foreach (DataGridViewRow row in dgveditoriales.Rows)
                {
                    // Desmarcar todos los checkboxes en el DataGridView
                    if (row.Index != posicionEditorial) // No desmarcar el checkbox de la fila seleccionada
                    {
                        row.Cells[0].Value = false; // Desmarcar (asumiendo que el checkbox está en la columna 0)
                    }
                    else
                    {
                        // Marcar el checkbox de la fila seleccionada
                        row.Cells[0].Value = true; // Marcar el checkbox de la fila seleccionada
                    }
                }
            }
        }

        //----------------------INICIO CRUD Categorias--------------------

        private void CargarTablaCat()
        {
            controladorcategorias objestactablacat = new controladorcategorias();
            dgvcategoria.DataSource = objestactablacat.LeerCat();

        }

        private void LimpiarCamposCat()
        {
            txtcategoria.Text = string.Empty;
            txtIdCategoria.Text = string.Empty;
        }

        void insertarDatosCategorias()
        {
            // Crear una instancia del controlador de categorías
            controladorcategorias objcategoria = new controladorcategorias();

            // Asignar el valor del TextBox al atributo nombre_categoria del controlador
            objcategoria.nombre_categoria = txtcategoria.Text;

            try
            {
                // Llamar al método para insertar la nueva categoría
                int respuestaCategoria = objcategoria.ingresarDatos();

                // Verificar si la inserción fue exitosa
                if (respuestaCategoria >= 1)
                {
                    MessageBox.Show("Categoría insertada con éxito.");

                    // Limpiar los campos del formulario
                    LimpiarCamposCat();

                    // Recargar la tabla de categorías en el DataGridView
                    CargarTablaCat();
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de falla
                MessageBox.Show("Error al insertar la nueva categoría: " + ex.Message);
            }
        }


        void actualizarDatosCategorias()
        {
            // Crear una instancia del controlador de categorías
            controladorcategorias objcategorias = new controladorcategorias();

            // Asignar el valor del TextBox a la propiedad nombre_categoria del controlador
            objcategorias.nombre_categoria = txtcategoria.Text;

            // Convertir y asignar el ID de la categoría desde el TextBox correspondiente
            controladorcategorias.id_categoria = Convert.ToInt16(txtIdCategoria.Text);

            try
            {
                // Llamar al método para actualizar la categoría
                int respuestaCategoria = objcategorias.actualizarDatos();

                // Verificar si la actualización fue exitosa
                if (respuestaCategoria >= 1)
                {
                    MessageBox.Show("Categoría actualizada con éxito.");

                    // Limpiar los campos del formulario
                    LimpiarCamposCat();

                    // Recargar la tabla de categorías en el DataGridView
                    CargarTablaCat();
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de falla
                MessageBox.Show("Error al actualizar la categoría: " + ex.Message);
            }
        }



        private void btningresarcategoria_Click(object sender, EventArgs e)
        {
            insertarDatosCategorias();
        }

        private void btnactualizarcategoria_Click(object sender, EventArgs e)
        {
            actualizarDatosCategorias();
            LimpiarCamposCat();

        }

        private void dgvcategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Captura el número de fila a la cual se le dio clic.
                int posicionCategoria = e.RowIndex; // Usamos e.RowIndex directamente

                // Llenar los TextBox con los datos de la fila seleccionada
                txtIdCategoria.Text = dgvcategoria[2, posicionCategoria].Value.ToString(); // Suponiendo que la columna 2 tiene el ID
                txtcategoria.Text = dgvcategoria[3, posicionCategoria].Value.ToString(); // Suponiendo que la columna 3 tiene el nombre de la categoría

                // Marca el checkbox de la fila seleccionada
                foreach (DataGridViewRow row in dgvcategoria.Rows)
                {
                    // Desmarcar todos los checkboxes en el DataGridView
                    if (row.Index != posicionCategoria) // No desmarcar el checkbox de la fila seleccionada
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

        private void dgvcategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionadaCategoria = dgvcategoria.Rows[e.RowIndex];

                // Verifica si se hizo clic en el botón de eliminar (columna 1)
                if (e.ColumnIndex == 1) // Índice 1 para el botón "Eliminar"
                {
                    // Verifica si el checkbox está en la columna 0
                    if (filaSeleccionadaCategoria.Cells[0] is DataGridViewCheckBoxCell checkBoxCell)
                    {
                        bool isCheckedCategoria = Convert.ToBoolean(checkBoxCell.Value);

                        if (isCheckedCategoria) // Solo elimina si está seleccionado
                        {
                            // Muestra un MessageBox con las opciones Sí y No
                            DialogResult result = MessageBox.Show("¿Desea eliminar esta categoría?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes) // Si el usuario selecciona "Sí"
                            {
                                // Obtiene el ID de la categoría de la celda correspondiente (suponiendo que está en la columna 2)
                                int id_categoria = Convert.ToInt32(filaSeleccionadaCategoria.Cells[2].Value); // Asumiendo que el ID está en la columna 2

                                // Llama al método para eliminar la categoría
                                controladorcategorias objcategoriaEliminar = new controladorcategorias();
                                int respuestaCategoria = objcategoriaEliminar.eliminarDatos(id_categoria); // Pasar el ID de la categoría al método eliminar

                                if (respuestaCategoria >= 1)
                                {
                                    MessageBox.Show("Categoría eliminada con éxito.");
                                    CargarTablaCat(); // Actualiza el DataGridView con los datos nuevos
                                    LimpiarCamposCat();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo eliminar la categoría. Verifique los datos.");
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
                            MessageBox.Show("Por favor, seleccione una categoría para eliminar.");
                        }
                    }
                }
            }

        }







    }

}
