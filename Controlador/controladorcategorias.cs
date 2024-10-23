using Modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Controlador
{
    public class controladorcategorias
    {

        public controladorcategorias() { }

        //declare attributes
        public static int id_categoria { get; set; }
        private string _nombre_categoria;
        public string nombre_categoria
        {
            get { return _nombre_categoria; }
            set
            {
                if (Validator.ValidateAlphabetic(value))
                {
                    _nombre_categoria = value;
                }
                else
                {
                    MessageBox.Show("El nombre de la categoría debe contener solo letras.",
                    "Error con el nombre de la categoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public int ingresarDatos()
        {
            return modelocategoria.AgregarCategoria(nombre_categoria);
        }
        //actualizacion
        public int actualizarDatos()
        {
            return modelocategoria.ActualizarCategoria(id_categoria, nombre_categoria);
        }

        public int eliminarDatos(int id_producto)
        {
            return modelocategoria.EliminarCategoria(id_categoria);
        }

        //Cargar tabla
        public DataTable LeerCat ()
        {
            return modelocategoria.CargarCategoria();
        }





    }
}
