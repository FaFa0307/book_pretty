using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class controladorreembolsocliente
    {

        public controladorreembolsocliente() { }

        public int id_reembolso { get; set; }
        public int id_devolucion { get; set; }
        public DateTime fecha_reembolso { get; set; }
        public double monto_reembolso { get; set; }
        public int id_metodoreembolso { get; set; }
        public int id_estado_reembolso { get; set; }

        public bool CrearReembolso()
        {
            return modeloreembolsocliente.InsertarReembolso(id_reembolso, id_devolucion, fecha_reembolso, monto_reembolso, id_metodoreembolso, id_estado_reembolso);
        }

        public DataTable ObtenerMetodosReembolso()
        {
            return modeloreembolsocliente.ObtenerMetodosReembolsos();
        }


    }
}
