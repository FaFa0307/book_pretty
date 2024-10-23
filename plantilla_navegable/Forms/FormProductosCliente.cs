using Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plantilla_navegable.Forms
{
    public partial class FormProductosCliente : Form
    {

        private Form2 mainForm;
        // Constructor que recibe el formulario principal (Form1)
        public FormProductosCliente(Form2 formPrincipal)
        {
            InitializeComponent();
            this.mainForm = formPrincipal; // Guardamos la referencia del formulario principal

        }
        public FormProductosCliente()
        {
            InitializeComponent();
        }

        // Cargar productos en un FlowLayoutPanel para que las cartas se acomoden automáticamente
        private void CargarProductos(List<Producto> productos)
        {
            flowLayoutPanel1.Controls.Clear(); // Limpiar el panel

            foreach (var producto in productos)
            {
                // Crear un panel que será la carta del producto
                Panel panelProducto = new Panel();
                panelProducto.Size = new Size(200, 300); // Ajusta el tamaño de la carta
                panelProducto.BorderStyle = BorderStyle.FixedSingle;

                // Crear y configurar un PictureBox para la imagen del producto
                PictureBox pictureBox = new PictureBox();
                string rutaImagen = Path.Combine(Application.StartupPath, "imagenes", "productos", producto.Imagen);

                // Validar si la imagen existe, si no, cargar la imagen por defecto
                if (!File.Exists(rutaImagen))
                {
                    rutaImagen = Path.Combine(Application.StartupPath, "imagenes", "productos", "default.png");
                }

                pictureBox.Image = Image.FromFile(rutaImagen); // Ruta de la imagen (o default.png si no existe)
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Size = new Size(180, 150);
                pictureBox.Location = new Point(10, 10);

                // Crear y configurar un Label para el nombre del producto
                Label lblNombre = new Label();
                lblNombre.Text = producto.Nombre;
                lblNombre.AutoSize = true;
                lblNombre.Location = new Point(10, 170);

                // Crear y configurar un Label para el precio del producto
                Label lblPrecio = new Label();
                lblPrecio.Text = $"$ {producto.Precio:F2}";
                lblPrecio.AutoSize = true;
                lblPrecio.Location = new Point(10, 200);

                // Crear y configurar un Button para agregar al carrito
                Button btnAgregar = new Button();
                btnAgregar.Text = "Agregar al carrito";
                btnAgregar.Size = new Size(180, 30);
                btnAgregar.Location = new Point(10, 230);
                btnAgregar.Click += (s, e) => {
                    // Código para agregar al carrito
                    MessageBox.Show($"Producto {producto.Nombre} agregado al carrito");
                };

                // Agregar los controles al panel del producto
                panelProducto.Controls.Add(pictureBox);
                panelProducto.Controls.Add(lblNombre);
                panelProducto.Controls.Add(lblPrecio);
                panelProducto.Controls.Add(btnAgregar);

                // Agregar el panel al FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(panelProducto);
            }
        }

        // Método para convertir el DataTable en una lista de productos
        private List<Producto> ConvertirDataTableAListaProductos(DataTable dt)
        {
            List<Producto> productos = new List<Producto>();

            foreach (DataRow row in dt.Rows)
            {
                Producto producto = new Producto
                {
                    Nombre = row["nombre_producto"].ToString(),
                    Precio = Convert.ToDecimal(row["precio"]),
                    Imagen = row["imagen"].ToString() // Asumimos que en la columna "imagen" está el nombre del archivo
                };
                productos.Add(producto);
            }

            return productos;
        }

        private void FormProductosCliente_Load(object sender, EventArgs e)
        {
            // Cargar productos cuando el formulario se cargue
            CargarProductosDesdeDB();
        }

        // Cargar productos desde la base de datos
        private void CargarProductosDesdeDB()
        {
            controladorproductos objProductos = new controladorproductos();
            DataTable dtProductos = objProductos.LeerProductos(); // Obtener los datos de la base de datos
            List<Producto> listaProductos = ConvertirDataTableAListaProductos(dtProductos); // Convertir DataTable a List<Producto>
            CargarProductos(listaProductos); // Cargar las cartas de los productos
        }

    }

    // Clase auxiliar para manejar los productos
    public class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
    }
}
