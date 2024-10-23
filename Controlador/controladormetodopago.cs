using System;
using Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Controlador
{
    public class controladormetodopago
    {

        //Se pone el controlador que se llama igual que la clase
        public controladormetodopago() { }

        public static int id_metodopago { get; set; }
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


        //Para ingresar
        public int ingresarmetodopago()
        {
            return modelometodopago.agregardatoscrudmetodopago(descripcion);
        }

        //Para Cargar Tabla
        public DataTable LeerDatosMetodosPagos()
        {
            return modelometodopago.CargarMetodosPagos();
        }

        //Para actualizar
        public int actualizarmetodospagos()
        {
            return modelometodopago.actualizardatoscrudmetodopago(id_metodopago, descripcion);
        }

        //Para Eliminar

        public int eliminardatometodopago(int id_metodopago)
        {
            return modelometodopago.eliminardatoscrudmetodopago(id_metodopago);
        }




    }
}
