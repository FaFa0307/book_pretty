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
    public class modeloestadoreembolso
    {
        public static int agregarDatosCrudEstadoReembolso(string pEstadoReembolso)
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

                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO estado_reembolso (estadoreembolso) VALUES (@estadoreembolso)", conexion);
                    cmdInsert.Parameters.AddWithValue("@estadoreembolso", pEstadoReembolso);

                    retorno = cmdInsert.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se insertaron filas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el estado de reembolso: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

        public static DataTable CargarEstadosReembolso()
        {
            DataTable data = new DataTable();
            try
            {
                string query = "SELECT * FROM estado_reembolso";
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

        public static int actualizarDatosCrudEstadoReembolso(int pidEstadoReembolso, string pEstadoReembolso)
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
                        "UPDATE estado_reembolso SET " +
                        "estadoreembolso = @estadoreembolso " +
                        "WHERE id_estado_reembolso = @id_estado_reembolso", conexion);

                    cmdUpdate.Parameters.AddWithValue("@estadoreembolso", pEstadoReembolso);
                    cmdUpdate.Parameters.AddWithValue("@id_estado_reembolso", pidEstadoReembolso);

                    retorno = cmdUpdate.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se actualizó ninguna fila.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el estado de reembolso: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

        public static int eliminarDatosCrudEstadoReembolso(int pidEstadoReembolso)
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
                        "DELETE FROM estado_reembolso WHERE id_estado_reembolso = @id_estado_reembolso", conexion);

                    cmdDelete.Parameters.AddWithValue("@id_estado_reembolso", pidEstadoReembolso);

                    retorno = cmdDelete.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se eliminó ninguna fila.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el estado de reembolso: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }
    }
}
