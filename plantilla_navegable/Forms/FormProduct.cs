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
using System.IO;

namespace plantilla_navegable.Forms
{
    public partial class FormProduct : Form
    {
        private Form1 mainForm;
        private string rutaImagen; // Variable para almacenar la ruta de la imagen

        // Constructor que recibe el formulario principal (Form1)
        public FormProduct(Form1 formPrincipal)
        {
            InitializeComponent();
            this.mainForm = formPrincipal; // Guardamos la referencia del formulario principal
           
        }

        controladorproductos objcon = new controladorproductos();
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

        private void FormProduct_Load(object sender, EventArgs e)
        {
            LoadTheme();
            CargarListas();
        }

        //métodos llenar combobux
        void LlenarCategoria() {

            cmbcategoria.DataSource = controladorproductosdatos.CargarCategoria();
            cmbcategoria.DisplayMember = "nombre_categoria";
            cmbcategoria.ValueMember = "id_categoria";
        }

        void LlenarEditoriales() {
            cmbeditorial.DataSource = controladorproductosdatos.CargarEditoriales();
            cmbeditorial.DisplayMember = "nombre_editorial";
            cmbeditorial.ValueMember = "id_editorial";
        }

        void LlenarUsuario()
        {
            cmbusuario.DataSource = controladorproductosdatos.CargarUsuario();
            cmbusuario.DisplayMember = "nombre";
            cmbusuario.ValueMember = "id_usuario";
        }

        void LlenarAutor()
        {
            cmbautor.DataSource = controladorproductosdatos.CargarAutor();
            cmbautor.DisplayMember = "nombre_autor";
            cmbautor.ValueMember = "id_autor";
        }

        void CargarListas() {
            LlenarCategoria();
            LlenarEditoriales();
            LlenarUsuario();
            LlenarAutor();
        }

        private void LimpiarCampos()
        {
            txtnombrep.Text = string.Empty;
            txtdescripcion.Text = string.Empty;
            txtprecio.Text = string.Empty;
            txtporcentajedescuento.Text = string.Empty;
            txtisbn.Text = string.Empty;
            txtstock.Text = string.Empty;
            chkestadoproducto.Checked = false;
            cmbcategoria.SelectedIndex = -1; 
            cmbeditorial.SelectedIndex = -1; 
            cmbusuario.SelectedIndex = -1; 
            cmbautor.SelectedIndex = -1; 
            rutaImagen = string.Empty; 
            pictureBoxImagen.Image = null;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        
        void insertarDatos()
        {
            controladorproductos objproductos = new controladorproductos();
            objproductos.nombre_producto = txtnombrep.Text;
            objproductos.descripcion = txtdescripcion.Text;
            objproductos.precio = decimal.Parse(txtprecio.Text);
            objproductos.estado_producto = chkestadoproducto.Checked ? true : false;
            objproductos.porcentaje = decimal.Parse(txtporcentajedescuento.Text);
            objproductos.isbn = txtisbn.Text;
            objproductos.stock = int.Parse(txtstock.Text);
            objproductos.id_categoria = Convert.ToInt16(cmbcategoria.SelectedValue);
            objproductos.id_editorial = Convert.ToInt16(cmbeditorial.SelectedValue);
            objproductos.id_usuario = Convert.ToInt16(cmbusuario.SelectedValue);
            objproductos.id_autor = Convert.ToInt16(cmbautor.SelectedValue);
            //---------------------------------AQUI HAY PAUSA PARA TRATAR A LA IMAGEN-----------
            //ESTA PARTE PERTENECE A LA IMAGEN SON VALIDACIONES
            if (string.IsNullOrEmpty(rutaImagen))
            {
                MessageBox.Show("Por favor, seleccione una imagen antes de insertar el producto.");
                return;
            }
            if (rutaImagen.Length > 255) // Cambia 255 al tamaño real que tengas en la base de datos
            {
                MessageBox.Show("La ruta de la imagen es demasiado larga. Asegúrate de que no exceda los 255 caracteres.");
                return;
            }
            // Guardar la ruta de la imagen
            objproductos.imagen = rutaImagen;
            //---------------------------------AQUI SIGUE EL CODIGO--------------------
            try
            {
                int respuesta = objproductos.ingresarDatos();
                if (respuesta >= 1)
                {
                    MessageBox.Show("Producto insertado con éxito.");
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el producto: " + ex.Message);
            }
        }
        
        void Actualizardatos() {
            controladorproductos objproductos = new controladorproductos();
            objproductos.nombre_producto = txtnombrep.Text;
            objproductos.descripcion = txtdescripcion.Text;
            objproductos.precio = decimal.Parse(txtprecio.Text);
            objproductos.estado_producto = chkestadoproducto.Checked ? true : false;
            objproductos.porcentaje = decimal.Parse(txtporcentajedescuento.Text);
            objproductos.isbn = txtisbn.Text;
            objproductos.stock = int.Parse(txtstock.Text);
            objproductos.id_categoria = Convert.ToInt16(cmbcategoria.SelectedValue);
            objproductos.id_editorial = Convert.ToInt16(cmbeditorial.SelectedValue);
            objproductos.id_usuario = Convert.ToInt16(cmbusuario.SelectedValue);
            objproductos.id_autor = Convert.ToInt16(cmbautor.SelectedValue);
            controladorproductos.id_producto = Convert.ToInt16(txtidproducto.Text);

            try
            {
                int respuesta = objproductos.actualizarDatos();
                if (respuesta >= 1)
                {
                    MessageBox.Show("Producto actualizado con éxito.");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se actualizó el producto. Verifique los datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el producto: " + ex.Message);
            }

        }

        private void btningresarproductos_Click(object sender, EventArgs e)
        {
            insertarDatos();
        }

        private void btnimagenproducto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|Todos los archivos (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rutaImagen = ofd.FileName; // Guardar la ruta de la imagen
                    pictureBoxImagen.Image = new Bitmap(rutaImagen); // Mostrar la imagen en el PictureBox
                }
            }
        }



        //AQUI ES EL BOTON QUE TE MANDA HACIA LA TABLA
        private void btnmostrarproductos_Click(object sender, EventArgs e)
        {
            // Abre el formulario de la tabla de productos y pasa el formulario actual como referencia
            FormProductosTabla formTabla = new FormProductosTabla(this);
            formTabla.Show();  // Abre el nuevo formulario

        }

       //Aca se manda el datagrid del otro formulario a este
        public void CargarDatosDesdeTabla(DataGridViewRow filaSeleccionada)
        {
            
            try
            {
                // Asigna los valores de la fila seleccionada a los controles del formulario
                txtidproducto.Text = filaSeleccionada.Cells[3].Value.ToString();
                txtnombrep.Text = filaSeleccionada.Cells[4].Value.ToString(); // "nombre_producto"
                txtdescripcion.Text = filaSeleccionada.Cells[5].Value.ToString(); // "descripcion"
                txtprecio.Text = filaSeleccionada.Cells[6].Value.ToString(); // "precio"

                // Obtener el id de la categoría de la celda correspondiente
                int idcategoriadgv = Convert.ToInt32(filaSeleccionada.Cells[7].Value);
                cmbcategoria.DataSource = objcon.CargarCategoriaInnerJoin_Controller(idcategoriadgv);
                cmbcategoria.DisplayMember = "nombre_categoria";
                cmbcategoria.ValueMember = "id_categoria";
                cmbcategoria.SelectedValue = idcategoriadgv;

                //Obtener el id del editorial de la celda correspondiente
                int ideditortialdgv = Convert.ToInt32(filaSeleccionada.Cells[8].Value);
                cmbeditorial.DataSource = objcon.CargarEditorialInnerJoin_Controller(ideditortialdgv);
                cmbeditorial.DisplayMember = "nombre_editorial";
                cmbeditorial.ValueMember = "id_editorial";
                cmbeditorial.SelectedValue = ideditortialdgv;

                // Convertir el valor del checkbox (estado_producto) en booleano
                chkestadoproducto.Checked = Convert.ToBoolean(filaSeleccionada.Cells[9].Value); // "estado_producto"


                //Obtener el id del usuario de la celda correspondiente
                int idusuariodgv = Convert.ToInt32(filaSeleccionada.Cells[10].Value);
                cmbusuario.DataSource = objcon.CargarUsuarioInnerJoin_Controller(idusuariodgv);
                cmbusuario.DisplayMember = "nombre";
                cmbusuario.ValueMember = "id_usuario";
                cmbusuario.SelectedValue = idusuariodgv;

                //Obtener el id del autor de la celda correspondiente
                int idautordgv = Convert.ToInt32(filaSeleccionada.Cells[11].Value);
                cmbautor.DataSource = objcon.CargarAutoresInnerJoin_Controller(idautordgv);
                cmbautor.DisplayMember = "nombre_autor";
                cmbautor.ValueMember = "id_autor";
                cmbautor.SelectedValue = idautordgv;

                txtporcentajedescuento.Text = filaSeleccionada.Cells[12].Value.ToString(); // "porcentaje"
                txtisbn.Text = filaSeleccionada.Cells[13].Value.ToString(); // "isbn"

               //LA IMAGEN FALTA [14]

                txtstock.Text = filaSeleccionada.Cells[15].Value.ToString(); // "stock"

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }




        //Esto se hace para poder cambiar los cmb si se quieren actualizar
        private void cmbcategoria_Click(object sender, EventArgs e)
        {
            LlenarCategoria();
        }

        private void cmbeditorial_Click(object sender, EventArgs e)
        {
            LlenarEditoriales();
        }

        private void cmbusuario_Click(object sender, EventArgs e)
        {
            LlenarUsuario();
        }

        private void cmbautor_Click(object sender, EventArgs e)
        {
            LlenarAutor();
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            Actualizardatos();
        }
    }
}
