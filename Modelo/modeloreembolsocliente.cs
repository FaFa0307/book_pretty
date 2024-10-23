using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Modelo
{
    public class modeloreembolsocliente
    {

        public static bool InsertarReembolso(int id_reembolso, int id_devolucion, DateTime fecha_reembolso, double monto_reembolso, int id_metodoreembolso, int id_estado_reembolso)
        {
            bool response = false;
            try
            {
                using (SqlConnection conexion = modeloconexion.Conectar())
                {
                    if (conexion == null || conexion.State != ConnectionState.Open)
                    {
                        throw new Exception("No se pudo conectar a la base de datos.");
                    }

                    SqlCommand cmd = new SqlCommand("insert into reembolsos values(@id_reembolso, @id_devolucion, @fecha_reembolso, @monto_reembolso, @id_metodoreembolso, @id_estado_reembolso)", conexion);
                    cmd.Parameters.AddWithValue("@id_reembolso", id_reembolso);
                    cmd.Parameters.AddWithValue("@id_devolucion", id_devolucion);
                    cmd.Parameters.AddWithValue("@fecha_reembolso", fecha_reembolso);
                    cmd.Parameters.AddWithValue("@monto_reembolso", monto_reembolso);
                    cmd.Parameters.AddWithValue("@id_metodoreembolso", id_metodoreembolso);
                    cmd.Parameters.AddWithValue("@id_estado_reembolso", id_estado_reembolso);

                    if (cmd.ExecuteNonQuery() > 0)
                        response = true;
                    else response = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el producto: " + ex.Message);
                response = false;
                throw;
            }
            return response;
        }

        public static DataTable ObtenerMetodosReembolsos()
        {
            DataTable data;
            try
            {
                SqlCommand cmd = new SqlCommand("select * from metodo_reembolso", modeloconexion.Conectar());
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                data = new DataTable();
                adapter.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return data = null;
            }
        }


    }
}
