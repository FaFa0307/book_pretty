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
    public class controladorestadopagos
    {
        // Constructor del controlador
        public controladorestadopagos() { }

        // Propiedades
        public static int id_estado_pago { get; set; }
        private string _estado_pago;
        public string estado_pago
        {
            get { return _estado_pago; }
            set
            {
                if (Validator.ValidateAlphabetic(value))
                {
                    _estado_pago = value;
                }
                else
                {
                    MessageBox.Show("El nombre del estado de pago debe contener solo letras.",
                    "Error con el estado de pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        // Método para ingresar un nuevo estado de pago
        public int agregarEstadoPago()
        {
            return modeloestadopagos.agregarDatosCrudEstadoPago(estado_pago);
        }

        // Método para cargar todos los estados de pago en un DataTable
        public DataTable LeerDatosEstadosPago()
        {
            return modeloestadopagos.CargarEstadosPago();
        }

        // Método para actualizar un estado de pago
        public int actualizarEstadoPago()
        {
            return modeloestadopagos.actualizarDatosCrudEstadoPago(id_estado_pago, estado_pago);
        }

        // Método para eliminar un estado de pago
        public int eliminarDatosEstadoPago(int id_estado_pago)
        {
            return modeloestadopagos.eliminarDatosCrudEstadoPago(id_estado_pago);
        }
    }
}
