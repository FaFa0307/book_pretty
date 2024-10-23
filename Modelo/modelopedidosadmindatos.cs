using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;


namespace Modelo
{
    public class modelopedidosadmindatos
    {
        public static DataTable CargarEstadoPedidoAdmin()
        {
            DataTable data;
            try
            {
                string query = "SELECT*FROM estados_pedidos";
                SqlCommand cmdselectestadopedidoadmin = new SqlCommand(string.Format(query), modeloconexion.Conectar());
                SqlDataAdapter adp = new SqlDataAdapter(cmdselectestadopedidoadmin);
                data = new DataTable();
                adp.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return data = null;
            }
        }
    }
}
