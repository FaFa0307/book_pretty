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
    public class modeloreembolososadmindatos
    {
        public static DataTable CargarEstadoReembolsosAdmin()
        {
            DataTable data;
            try
            {
                string query = "SELECT*FROM estado_reembolso";
                SqlCommand cmdselectestadoradmin = new SqlCommand(string.Format(query), modeloconexion.Conectar());
                SqlDataAdapter adp = new SqlDataAdapter(cmdselectestadoradmin);
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
