using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Controlador
{
    public class controladoreembolsosadmindatos
    {
        public static DataTable CargarReembolsosAdmin()
        {
            return modeloreembolososadmindatos.CargarEstadoReembolsosAdmin();
        }
    }
}
