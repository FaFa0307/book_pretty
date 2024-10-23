using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Controlador
{
    public class controladorpedidosadminsdatos
    {
        //Para Cargar el combobux
        public static DataTable CargarEstadoPedidosAdmin()
        {
            return modelopedidosadmindatos.CargarEstadoPedidoAdmin();   
        }
    }
}
