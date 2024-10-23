using Modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controlador
{
    public class controladodevoadmin
    {
        public controladodevoadmin() { }

        public static int id_devolucion { get; set; }

        private DateTime _fecha_devolucion;
        public DateTime fecha_devolucion
        {
            get { return _fecha_devolucion; }
            set
            {
                // Convertimos la fecha a un formato de cadena para la validación
                string fechaString = value.ToString("dd/MM/yyyy");

                if (Validator.ValidateDate(fechaString))
                {
                    _fecha_devolucion = value;
                }
                else
                {
                    MessageBox.Show("La fecha de devolución no es válida.",
                    "Error con la fecha de devolución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public int id_estadodevolucion { get; set; }

        // Cargar tabla de devoluciones
        public DataTable LeerDevolucionesAdmin()
        {
            return modelodevoadmin.CargarDevolucionesAdmin();
        }

        // Cargar estados de devoluciones con Inner Join (opcional, según necesidades)
        public DataTable CargarEstadoDevolucionInnerJoin_Controller()
        {
            return modelodevoadmin.CargarEstadoDevolucionAdminInner();
        }

        // Para actualizar devoluciones
        public int ActualizarDevolucionesAdminDatos(DateTime fechaOriginal)
        {
            // Verifica si la nueva fecha de devolución no es anterior a la fecha original
            if (Validator.ValidateFutureDate(fechaOriginal, fecha_devolucion.ToString("dd/MM/yyyy")))
            {
                return modelodevoadmin.ActualizarDevolucionesAdminDatos(id_devolucion, id_estadodevolucion, fecha_devolucion);
            }
            else
            {
                MessageBox.Show("No se puede actualizar a una fecha anterior a la fecha original o a una fecha a 31 de dicimebre de este año.",
                "Error de Fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // O un código de error apropiado
            }
        }

    }
}
