using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class controladordevoadmindatos
    {
        // Para cargar el combo box con los estados de las devoluciones
        public static DataTable CargarEstadoDevolucionesAdmin()
        {
            return modelodevoadmindatos.CargarEstadoDevolucionAdmin();
        }
    }
}
