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
    public class modelodevoluciones
    {
        public static int AgregarDevolucion(int pid_detalle_pedido, DateTime pfecha_devolucion, string pmotivo_devolucion, int pid_estadodevolucion, int pcantidad_devuelta)
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

                    SqlCommand cmdinsert = new SqlCommand(
                        "INSERT INTO devoluciones (id_detallepedido, fecha_devolucion, motivo_devolucion, id_estadodevolucion, cantidad_devuelta) " +
                        "VALUES (@IdDetallePedido, @FechaDevolucion, @MotivoDevolucion, @IdEstadoDevolucion, @CantidadDevuelta);", conexion);

                    cmdinsert.Parameters.AddWithValue("@IdDetallePedido", pid_detalle_pedido);
                    cmdinsert.Parameters.AddWithValue("@FechaDevolucion", pfecha_devolucion);
                    cmdinsert.Parameters.AddWithValue("@MotivoDevolucion", pmotivo_devolucion);
                    cmdinsert.Parameters.AddWithValue("@IdEstadoDevolucion", pid_estadodevolucion);
                    cmdinsert.Parameters.AddWithValue("@CantidadDevuelta", pcantidad_devuelta);
                    retorno = cmdinsert.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se insertaron filas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar devolucion: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

        public static int ActualizarDevolucion(int pid_devolucion, int pid_detalle_pedido, DateTime pfecha_devolucion, string pmotivo_devolucion, int pid_estadodevolucion, int pcantidad_devuelta)
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

                    SqlCommand cmdupdate = new SqlCommand(
                        "UPDATE devoluciones " +
                        "SET id_detallepedido = @IdDetallePedido, fecha_devolucion = @FechaDevolucion, motivo_devolucion = @MotivoDevolucion, " +
                        "id_estadodevolucion = @IdEstadoDevolucion, cantidad_devuelta = @CantidadDevuelta " +
                        "WHERE id_devolucion = @IdDevolucion;", conexion);

                    cmdupdate.Parameters.AddWithValue("@IdDetallePedido", pid_detalle_pedido);
                    cmdupdate.Parameters.AddWithValue("@FechaDevolucion", pfecha_devolucion);
                    cmdupdate.Parameters.AddWithValue("@MotivoDevolucion", pmotivo_devolucion);
                    cmdupdate.Parameters.AddWithValue("@IdEstadoDevolucion", pid_estadodevolucion);
                    cmdupdate.Parameters.AddWithValue("@CantidadDevuelta", pcantidad_devuelta);
                    cmdupdate.Parameters.AddWithValue("@IdDevolucion", pid_devolucion);

                    retorno = cmdupdate.ExecuteNonQuery();

                    if (retorno == 0)
                    {
                        throw new Exception("No se actualizaron filas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar devolucion: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

        public static int EliminarDevolucion(int pid_devolucion)
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

                    SqlCommand cmddelete = new SqlCommand("DELETE FROM devoluciones WHERE id_devolucion = @IdDevolucion", conexion);

                    cmddelete.Parameters.AddWithValue("@IdDevolucion", pid_devolucion);

                    retorno = cmddelete.ExecuteNonQuery();

                    if (retorno == 0)
                    {
                        throw new Exception("No se actualizaron filas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar devolucion: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

        public static DataTable CargarDevoluciones()
        {
            DataTable data;
            try
            {
                string query = "SELECT*FROM devoluciones";
                SqlCommand cmdselectDetalle = new SqlCommand(string.Format(query), modeloconexion.Conectar());
                SqlDataAdapter adp = new SqlDataAdapter(cmdselectDetalle);
                data = new DataTable();
                adp.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
