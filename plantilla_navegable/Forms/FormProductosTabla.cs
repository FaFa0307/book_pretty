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
    public partial class FormProductosTabla : Form
    {
        private FormProduct mainForm;

        public FormProductosTabla(FormProduct formPrincipal)
        {
            InitializeComponent();
            this.mainForm = formPrincipal; // Guardamos la referencia al formulario principal
        }

        private void CargarTabla()
        {
            controladorproductos objproductostabla = new controladorproductos();
            dgvproductos.DataSource = objproductostabla.LeerProductos();
        }

        private void FormProductosTabla_Load(object sender, EventArgs e)
        {
            //Aca se carga la tabla
            CargarTabla();

            //Aqui se agrega el check al dgv
            if (!dgvproductos.Columns.Contains("Seleccionar"))
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "", // Título de la columna
                    Width = 30, // Establecer un ancho específico
                    Name = "" // Nombre de la columna para poder referenciarla más tarde
                };
                dgvproductos.Columns.Insert(0, checkColumn); // Insertar en la posición 0
            }

            // Agregar botones de actualizar y eliminar
            if (!dgvproductos.Columns.Contains("Actualizar"))
            {
                DataGridViewButtonColumn btnUpdate = new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Text = "Up",
                    UseColumnTextForButtonValue = true,
                    Width = 50 // Establecer un ancho específico
                };
                dgvproductos.Columns.Insert(1, btnUpdate);
            }


            if (!dgvproductos.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Text = "Del",
                    UseColumnTextForButtonValue = true,
                    Width = 50 // Establecer un ancho específico
                };
                dgvproductos.Columns.Insert(2, btnDelete);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void dgvproductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        

        private void dgvproductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtiene la fila actual
                DataGridViewRow filaSeleccionada = dgvproductos.Rows[e.RowIndex];

                // Verifica si se hizo clic en el botón de actualizar (columna 1) que en este caso es el boton actualizar
                if (e.ColumnIndex == 1) 
                {
                    // Verifica si el checkbox está seleccionado
                    bool isChecked = (bool)filaSeleccionada.Cells[0].Value; // Suponiendo que el checkbox está en la columna 0

                    if (isChecked) // Solo actualiza si está seleccionado
                    {
                        // Envía los valores de la fila seleccionada al formulario principal
                        mainForm.CargarDatosDesdeTabla(filaSeleccionada);

                        // Cierra el formulario actual después de la actualización
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("Por favor, seleccione un producto para actualizar.");
                    }
                }

                // Verifica si se hizo clic en el botón de eliminar (columna 2)
                if (e.ColumnIndex == 2) // Índice 2 para el botón "Eliminar"
                {
                    bool isChecked = (bool)filaSeleccionada.Cells[0].Value; // Suponiendo que el checkbox está en la columna 0

                    if (isChecked) // Solo elimina si está seleccionado
                    {
                        // Muestra un MessageBox con las opciones Sí y No
                        DialogResult result = MessageBox.Show("¿Desea eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes) // Si el usuario selecciona "Sí"
                        {
                            // Obtiene el ID del producto de la celda correspondiente
                            int idProducto = Convert.ToInt32(filaSeleccionada.Cells[3].Value); // Asumiendo que el ID del producto está en la columna 3

                            // Llama al método para eliminar el producto
                            controladorproductos objproductos = new controladorproductos();
                            int respuesta = objproductos.eliminarDatos(idProducto); // Pasar el ID del producto al método eliminarDatos

                            if (respuesta >= 1)
                            {
                                MessageBox.Show("Producto eliminado con éxito.");
                                CargarTabla(); // Actualiza el DataGridView con los datos nuevos
                            }
                            else
                            {
                                MessageBox.Show("No se pudo eliminar el producto. Verifique los datos.");
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
                        MessageBox.Show("Por favor, seleccione un producto para eliminar.");
                    }
                }

            }
        }
    }
}
