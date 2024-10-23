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
    public class modeloestadopagos
    {
        public static int agregarDatosCrudEstadoPago(string pEstadoPago)
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

                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO estados_pago (estado_pago) VALUES (@estado_pago)", conexion);
                    cmdInsert.Parameters.AddWithValue("@estado_pago", pEstadoPago);

                    retorno = cmdInsert.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se insertaron filas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el estado de pago: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

        public static DataTable CargarEstadosPago()
        {
            DataTable data = new DataTable();
            try
            {
                string query = "SELECT * FROM estados_pago";
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

        public static int actualizarDatosCrudEstadoPago(int pidEstadoPago, string pEstadoPago)
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
                        "UPDATE estados_pago SET " +
                        "estado_pago = @estado_pago " +
                        "WHERE id_estadopago = @id_estadopago", conexion);

                    cmdUpdate.Parameters.AddWithValue("@estado_pago", pEstadoPago);
                    cmdUpdate.Parameters.AddWithValue("@id_estadopago", pidEstadoPago);

                    retorno = cmdUpdate.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se actualizó ninguna fila.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el estado de pago: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

        public static int eliminarDatosCrudEstadoPago(int pidEstadoPago)
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
                        "DELETE FROM estados_pago WHERE id_estadopago = @id_estadopago", conexion);

                    cmdDelete.Parameters.AddWithValue("@id_estadopago", pidEstadoPago);

                    retorno = cmdDelete.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se eliminó ninguna fila.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el estado de pago: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }
    }
}
