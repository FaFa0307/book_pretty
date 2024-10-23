using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;


namespace Modelo
{
    public class modeloconexion
    {
        public static SqlConnection Conectar() {

            SqlConnection connect;
			try
			{
				string server, database, uid, pwd;
				server = "localhost";
				database = "book_pretty";
				uid = "sa";
				pwd = "12345678";
                connect = new SqlConnection("server=" + server + "; database=" + database + "; uid=" + uid + "; pwd=" + pwd + "; TrustServerCertificate=True; Encrypt=True;");
                connect.Open();
				return connect;
            }
            catch (Exception ex)
			{
                MessageBox.Show("Error: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
