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
    public class controladorpedidosadmin
    {

        public controladorpedidosadmin() { }

        public static int id_pedidos { get; set; }

        private DateTime _fecha_entrega;
        public DateTime fecha_entrega
        {
            get { return _fecha_entrega; }
            set
            {
                // Convertimos la fecha a un formato de cadena para la validación
                string fechaString = value.ToString("dd/MM/yyyy");

                if (Validator.ValidateDate(fechaString))
                {
                    _fecha_entrega = value;
                }
                else
                {
                    MessageBox.Show("La fecha de entrega no es válida.",
                    "Error con la fecha de entrega", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        public int id_estadopedido { get; set; }


        //Cargar tabla
        public DataTable LeerPedidosAdmin()
        {
            return modelopedidosadmin.CargarPedidosAdmin();
        }


        public DataTable CargarEstadoPedidoInnerJoin_Controller()
        {
            return modelopedidosadmin.CargarEstadoPedidoAdminInner();
        }



        // Para actualizar
        public int actualizarPedidosAdminDatos(DateTime fechaOriginal)
        {
            // Verifica si la nueva fecha de entrega no es anterior a la fecha original
            if (Validator.ValidateFutureDate(fechaOriginal, fecha_entrega.ToString("dd/MM/yyyy")))
            {
                return modelopedidosadmin.actualizarPedidosAdminDatos(id_pedidos, id_estadopedido, fecha_entrega);
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
