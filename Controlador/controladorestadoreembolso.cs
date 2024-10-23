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
    public class controladorestadoreembolso
    {
        // Constructor del controlador
        public controladorestadoreembolso() { }

        // Propiedades
        public static int id_estado_reembolso { get; set; }
        private string _estado_reembolso;
        public string estado_reembolso
        {
            get { return _estado_reembolso; }
            set
            {
                if (Validator.ValidateAlphabetic(value))
                {
                    _estado_reembolso = value;
                }
                else
                {
                    MessageBox.Show("El nombre del estado de reembolso debe contener solo letras.",
                    "Error con el estado de reembolso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // Método para ingresar un nuevo estado de reembolso
        public int agregarEstadoReembolso()
        {
            return modeloestadoreembolso.agregarDatosCrudEstadoReembolso(estado_reembolso);
        }

        // Método para cargar todos los estados de reembolso en un DataTable
        public DataTable LeerDatosEstadosReembolso()
        {
            return modeloestadoreembolso.CargarEstadosReembolso();
        }

        // Método para actualizar un estado de reembolso
        public int actualizarEstadoReembolso()
        {
            return modeloestadoreembolso.actualizarDatosCrudEstadoReembolso(id_estado_reembolso, estado_reembolso);
        }

        // Método para eliminar un estado de reembolso
        public int eliminarDatosEstadoReembolso(int id_estado_reembolso)
        {
            return modeloestadoreembolso.eliminarDatosCrudEstadoReembolso(id_estado_reembolso);
        }
    }
}
