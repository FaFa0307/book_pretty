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
    public class controladoreditoriales
    {

        // Constructor del controlador
        public controladoreditoriales() { }

        // Propiedades
        public static int id_editorial { get; set; }
        private string _nombre_editorial;
        public string nombre_editorial
        {
            get { return _nombre_editorial; }
            set
            {
                if (Validator.ValidateAlphabetic(value))
                {
                    _nombre_editorial = value;
                }
                else
                {
                    MessageBox.Show("El nombre de la editorial debe contener solo letras.",
                    "Error con el nombre de la editorial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // Método para ingresar una nueva editorial
        public int ingresareditorial()
        {
            return modeloeditoriales.agregardatoscrudeditoriales(nombre_editorial);
        }

        // Método para cargar todas las editoriales en un DataTable
        public DataTable LeerDatosEditoriales()
        {
            return modeloeditoriales.CargarEditoriales();
        }

        // Método para actualizar una editorial
        public int actualizareditorial()
        {
            return modeloeditoriales.actualizardatoscrudeditoriales(id_editorial, nombre_editorial);
        }

        // Método para eliminar una editorial
        public int eliminarDatoEditorial(int id_editorial)
        {
            return modeloeditoriales.eliminardatoscrudeditoriales(id_editorial);
        }



    }
}
