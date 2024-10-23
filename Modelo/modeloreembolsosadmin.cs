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
    public class modeloreembolsosadmin
    {


        public static DataTable CargarEstadoReembolsoAdminInner()
        {
            DataTable data;
            try
            {
                string query = "SELECT * FROM estado_reembolso";
                SqlCommand cmdselectestaradmin = new SqlCommand(query, modeloconexion.Conectar());
                SqlDataAdapter adp = new SqlDataAdapter(cmdselectestaradmin);
                data = new DataTable();
                adp.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return data = null;
            }
        }



        public static DataTable CargarReembolsosAdmin()
        {
            DataTable data;
            try
            {
                string query = "SELECT*FROM reembolsos";
                SqlCommand cmdselectreembolsosadmin = new SqlCommand(string.Format(query), modeloconexion.Conectar());
                SqlDataAdapter adp = new SqlDataAdapter(cmdselectreembolsosadmin);
                data = new DataTable();
                adp.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return data = null;
            }
        }


        public static int actualizarReembolsosAdminDatos(int id_reembolso, int id_estado_reembolso, DateTime fecha_reembolso)
        {
            int retorno = 0;
            try
            {
                using (SqlConnection conexion = modeloconexion.Conectar())
                {
                    if (conexion == null || conexion.State != ConnectionState.Open)
                    {
                        throw new Exception("No se pudo conectar a la base de datos.");
                    }

                    SqlCommand cdmupdate = new SqlCommand(
                        "UPDATE reembolsos SET " +
                        "id_estado_reembolso = @id_estado_reembolso, " + // El nuevo estado del reembolso
                        "fecha_reembolso = @fecha_reembolso " +          // La nueva fecha de reembolso
                        "WHERE id_reembolso = @id_reembolso", conexion); // Identificador del reembolso a actualizar

                    // Agregar los parámetros a la consulta
                    cdmupdate.Parameters.AddWithValue("@id_estado_reembolso", id_estado_reembolso);
                    cdmupdate.Parameters.AddWithValue("@fecha_reembolso", fecha_reembolso);
                    cdmupdate.Parameters.AddWithValue("@id_reembolso", id_reembolso); // Identificador del reembolso a actualizar

                    // Ejecutar la consulta
                    retorno = cdmupdate.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se actualizó ninguna fila.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el reembolso: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }


    }
}
