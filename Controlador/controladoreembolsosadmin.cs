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
    public class controladoreembolsosadmin
    {

        public controladoreembolsosadmin() { }

        public static int id_reembolso { get; set; }

        private DateTime _fecha_reembolso;
        public DateTime fecha_reembolso
        {
            get { return _fecha_reembolso; }
            set
            {
                // Convertimos la fecha a un formato de cadena para la validación
                string fechaString = value.ToString("dd/MM/yyyy");

                if (Validator.ValidateDate(fechaString))
                {
                    _fecha_reembolso = value;
                }
                else
                {
                    MessageBox.Show("La fecha de reembolso no es válida.",
                    "Error con la fecha de reembolso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public int id_estado_reembolso { get; set; }


        public DataTable LeerReembolsosAdmin()
        {
            return modeloreembolsosadmin.CargarReembolsosAdmin();
        }


        public DataTable CargarEstadoReembolsosInnerJoin_Controller()
        {
            return modeloreembolsosadmin.CargarEstadoReembolsoAdminInner();
        }




        //Para actualizar
        public int actualizarReembolsosAdminDatos(DateTime fechaOriginal)
        {
            // Verifica si la nueva fecha de reembolso no es anterior a la fecha original
            if (Validator.ValidateFutureDate(fechaOriginal, fecha_reembolso.ToString("dd/MM/yyyy")))
            {
                return modeloreembolsosadmin.actualizarReembolsosAdminDatos(id_reembolso, id_estado_reembolso, fecha_reembolso);
            }
            else
            {
                MessageBox.Show("No se puede actualizar a una fecha anterior a la fecha original.",
                "Error de Fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // O un código de error apropiado
            }
        }

    }
}
