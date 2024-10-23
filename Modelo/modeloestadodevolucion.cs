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
    public class modeloestadodevolucion
    {
        public static int agregarDatosCrudEstadoDevolucion(string pEstadoDevolucion)
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

                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO estado_devolucion (estadodevolucion) VALUES (@estadodevolucion)", conexion);
                    cmdInsert.Parameters.AddWithValue("@estadodevolucion", pEstadoDevolucion);

                    retorno = cmdInsert.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se insertaron filas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el estado de devolución: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

        public static DataTable CargarEstadosDevolucion()
        {
            DataTable data = new DataTable();
            try
            {
                string query = "SELECT * FROM estado_devolucion";
                using (SqlConnection conexion = modeloconexion.Conectar())
                {
                    SqlCommand cmdSelectEstados = new SqlCommand(query, conexion);
                    SqlDataAdapter adp = new SqlDataAdapter(cmdSelectEstados);
                    adp.Fill(data);
                }
                return data;
            }
            catch (Exception)
            {
                return null; // Retorna null en caso de error
            }
        }

        public static int actualizarDatosCrudEstadoDevolucion(int pidEstadoDevolucion, string pEstadoDevolucion)
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

                    SqlCommand cmdUpdate = new SqlCommand(
                        "UPDATE estado_devolucion SET " +
                        "estadodevolucion = @estadodevolucion " +
                        "WHERE id_estadodevolucion = @id_estadodevolucion", conexion);

                    cmdUpdate.Parameters.AddWithValue("@estadodevolucion", pEstadoDevolucion);
                    cmdUpdate.Parameters.AddWithValue("@id_estadodevolucion", pidEstadoDevolucion);

                    retorno = cmdUpdate.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se actualizó ninguna fila.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el estado de devolución: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

        public static int eliminarDatosCrudEstadoDevolucion(int pidEstadoDevolucion)
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

                    SqlCommand cmdDelete = new SqlCommand(
                        "DELETE FROM estado_devolucion WHERE id_estadodevolucion = @id_estadodevolucion", conexion);

                    cmdDelete.Parameters.AddWithValue("@id_estadodevolucion", pidEstadoDevolucion);

                    retorno = cmdDelete.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se eliminó ninguna fila.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el estado de devolución: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }
    }
}
