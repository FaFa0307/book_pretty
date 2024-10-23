using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Modelo
{
    public class modelodevoadmindatos
    {
        public static DataTable CargarEstadoDevolucionAdmin()
        {
            DataTable data;
            try
            {
                // Consulta para obtener los datos de la tabla estado_devolucion
                string query = "SELECT * FROM estado_devolucion";
                SqlCommand cmdselectestadodevolucionadmin = new SqlCommand(query, modeloconexion.Conectar());
                SqlDataAdapter adp = new SqlDataAdapter(cmdselectestadodevolucionadmin);
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
