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
    public class controlestadodevolucion
    {
        public controlestadodevolucion() { }

        // Propiedades
        public static int id_estado_devolucion { get; set; }
        //public string estado_devolucion { get; set; }

        private string _estado_devolucion;
        public string estado_devolucion
        {
            get { return _estado_devolucion; }
            set
            {
                if (Validator.ValidateAlphabetic(value))
                {
                    _estado_devolucion = value;
                }
                else
                {
                    MessageBox.Show("El nombre del estado devolucion debe contener solo letras.",
                    " Error con el estado de devolucion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Método para ingresar un nuevo estado de devolución
        public int agregarEstadoDevolucion()
        {
            return modeloestadodevolucion.agregarDatosCrudEstadoDevolucion(estado_devolucion);
        }

        // Método para cargar todos los estados de devolución en un DataTable
        public DataTable LeerDatosEstadosDevolucion()
        {
            return modeloestadodevolucion.CargarEstadosDevolucion();
        }

        // Método para actualizar un estado de devolución
        public int actualizarEstadoDevolucion()
        {
            return modeloestadodevolucion.actualizarDatosCrudEstadoDevolucion(id_estado_devolucion, estado_devolucion);
        }

        // Método para eliminar un estado de devolución
        public int eliminarDatosEstadoDevolucion(int id_estado_devolucion)
        {
            return modeloestadodevolucion.eliminarDatosCrudEstadoDevolucion(id_estado_devolucion);
        }
    }
}
