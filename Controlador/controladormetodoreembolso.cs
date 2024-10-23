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
    public class controladormetodoreembolso
    {

        // Constructor del controlador
        public controladormetodoreembolso() { }

        // Propiedades
        public static int id_metodoreembolso { get; set; }
        private string _descripcion;
        public string descripcion
        {
            get { return _descripcion; }
            set
            {
                if (Validator.ValidateAlphabetic(value)) // Asegúrate de que no sea una cadena vacía o solo espacios
                {
                    _descripcion = value;
                }
                else
                {
                    MessageBox.Show("La descripción debe contener solo letras.",
                    "Error con la descripción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // Método para ingresar un nuevo método de reembolso
        public int ingresarmetodoreembolso()
        {
            return modelometodoreembolso.agregardatoscrudmetodoreembolso(descripcion);
        }

        // Método para cargar todos los métodos de reembolso en un DataTable
        public DataTable LeerDatosMetodosReembolso()
        {
            return modelometodoreembolso.CargarMetodosReembolso();
        }

        // Método para actualizar un método de reembolso
        public int actualizarmetodoreembolso()
        {
            return modelometodoreembolso.actualizardatoscrudmetodoreembolso(id_metodoreembolso, descripcion);
        }

        // Método para eliminar un método de reembolso
        public int eliminardatometodoreembolso(int id_metodoreembolso)
        {
            return modelometodoreembolso.eliminardatoscrudmetodoreembolso(id_metodoreembolso);
        }

    }
}
