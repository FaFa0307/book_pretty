using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controlador
{
    public class controladorproductos
    {
        //Aqui se pone el constructor
        public controladorproductos() { }   
        //Aqui los atributos


        public static int id_producto { get; set; }


        private string _nombre_producto;

        public string nombre_producto 
        {
            get { return _nombre_producto; }
            set
            {
                if (Validator.ValidateAlphabetic(value))
                {
                    _nombre_producto = value;
                }
                else
                {
                    MessageBox.Show("El nombre debe contener solo letras.",
                    "Error con el nombre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string _descripcion;
        public string descripcion {
            get { return _descripcion; }
            set
            {
                if (Validator.ValidateAlphanumeric(value))
                {
                    _descripcion = value;
                }
                else
                {
                    MessageBox.Show("La dirección no tiene el formato adecuado.",
                    "Error dirección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
        }

        private decimal _precio; // Cambiado a decimal
        public decimal precio // Cambiado a decimal
        {
            get { return _precio; }
            set
            {
                // Usa la validación para verificar si el valor es un número decimal válido
                if (value >= 0) // Verifica si el valor es mayor o igual a 0
                {
                    _precio = value;
                }
                else
                {
                    MessageBox.Show("El precio debe ser un número decimal válido mayor o igual a 0.",
                    "Error con el precio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private decimal _porcentaje;
        public decimal porcentaje
        {
            get { return _porcentaje; }
            set
            {

                if (value >= 0)
                {
                    _precio = value;
                }
                else
                {
                    MessageBox.Show("El procentaje debe ser 0 o mayor.",
                    "Error con el porcentaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private decimal _isbn;
        public string isbn {
            get { return _isbn; }
            set
            {
                if (Validator.ValidateAlphanumeric(value))
                {
                    _isbn = value;
                }
                else
                {
                    MessageBox.Show("ISBN no tiene el formato adecuado.",
                    "Error dirección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public string imagen { get; set; }

        public int stock { get; set; }

        public bool estado_producto { get; set; }   
        public int id_categoria { get; set; }
        public int id_editorial { get; set; }
        public int id_autor { get; set; }
        public int id_usuario { get; set; }

        //metodos
        //insercion
        public  int ingresarDatos() {
            return modeloproductos.agregardatos(nombre_producto, descripcion, precio, porcentaje, isbn, imagen, stock, estado_producto, id_categoria, id_editorial, id_autor, id_usuario);
        }
        //actualizacion
        public int actualizarDatos()
        {
            return modeloproductos.actualizardatos(id_producto, nombre_producto, descripcion, precio, porcentaje, isbn, imagen, stock, estado_producto, id_categoria, id_editorial, id_autor, id_usuario);
        }

        public int eliminarDatos(int id_producto)
        {
            return modeloproductos.eliminardatos(id_producto); // Pasa el id_producto a la capa de modelo
        }

        //Cargar tabla
        public DataTable LeerProductos() {
            return modeloproductos.CargarProductos();
        }

        //Cargar cmb de datagrid a el formulatio principal
        public DataTable CargarCategoriaInnerJoin_Controller(int id) {
            return modeloproductos.CargarCategoriaInner(id);
        }

        public DataTable CargarEditorialInnerJoin_Controller(int id)
        {
            return modeloproductos.CargarEditorialInner(id);
        }

        public DataTable CargarUsuarioInnerJoin_Controller(int id)
        {
            return modeloproductos.CargarUsuarioInner(id);
        }

        public DataTable CargarAutoresInnerJoin_Controller(int id)
        {
            return modeloproductos.CargarAutorInner(id);
        }

    }
}
