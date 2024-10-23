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
    public class modelodevoadmin
    {
        public static DataTable CargarEstadoDevolucionAdminInner()
        {
            DataTable data;
            try
            {
                // Consulta para obtener los estados de devoluciones
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

        public static DataTable CargarDevolucionesAdmin()
        {
            DataTable data;
            try
            {
                // Consulta para obtener las devoluciones
                string query = "SELECT * FROM devoluciones";
                SqlCommand cmdselectdevolucionesadmin = new SqlCommand(query, modeloconexion.Conectar());
                SqlDataAdapter adp = new SqlDataAdapter(cmdselectdevolucionesadmin);
                data = new DataTable();
                adp.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return data = null;
            }
        }

        public static int ActualizarDevolucionesAdminDatos(int pid_devolucion, int pid_estadodevolucion, DateTime pfecha_devolucion)
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

                    // Consulta para actualizar el estado de devolución y la fecha de devolución
                    SqlCommand cdmupdate = new SqlCommand(
                        "UPDATE devoluciones SET " +
                        "id_estadodevolucion = @id_estadodevolucion, " +  // Actualizar el estado
                        "fecha_devolucion = @fecha_devolucion " +         // Actualizar la fecha de devolución
                        "WHERE id_devolucion = @id_devolucion", conexion);

                    // Agregar los parámetros a la consulta
                    cdmupdate.Parameters.AddWithValue("@id_estadodevolucion", pid_estadodevolucion);
                    cdmupdate.Parameters.AddWithValue("@fecha_devolucion", pfecha_devolucion);
                    cdmupdate.Parameters.AddWithValue("@id_devolucion", pid_devolucion); // Identificador de la devolución a actualizar

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
                MessageBox.Show("Error al actualizar la devolución: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

    }
}
