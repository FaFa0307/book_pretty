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
    public class modeloestadopedido
    {
        //Agregar
        public static int agregardatoscrudestadopedido(string pestado_pedido)
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

                    SqlCommand cmdinsert = new SqlCommand("INSERT INTO estados_pedidos (estado) VALUES (@estado)", conexion);
                    cmdinsert.Parameters.AddWithValue("@estado", pestado_pedido);

                    retorno = cmdinsert.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se insertaron filas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el estado pedido: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }


        //Cargar Tabla
        public static DataTable CargarEstadoPedido()
        {
            DataTable data;
            try
            {
                string query = "SELECT*FROM estados_pedidos";
                SqlCommand cmdselecestadopedido = new SqlCommand(string.Format(query), modeloconexion.Conectar());
                SqlDataAdapter adp = new SqlDataAdapter(cmdselecestadopedido);
                data = new DataTable();
                adp.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return data = null;
            }
        }

        //Actualizar
        public static int actualizardatoscrudestadopedido(int pidestado_pedido, string pestado_pedido)
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
                        "UPDATE estados_pedidos SET " +
                        "estado = @estado " +
                        "WHERE id_estadopedido = @id_estadopedido", conexion);

                    // Agregar los parámetros a la consulta
                    cdmupdate.Parameters.AddWithValue("@estado", pestado_pedido);
                    cdmupdate.Parameters.AddWithValue("@id_estadopedido", pidestado_pedido); // Identificador del estado pedido a actualizar

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
                MessageBox.Show("Error al actualizar el producto: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }



        //Eliminar

        public static int eliminardatoscrudestadopedido(int pidestado_pedido)
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

                    // Consulta SQL para eliminar el producto
                    SqlCommand cdmdelete = new SqlCommand(
                        "DELETE FROM estados_pedidos WHERE id_estadopedido = @id_estadopedido", conexion);

                    // Agregar el parámetro del ID del producto
                    cdmdelete.Parameters.AddWithValue("@id_estadopedido", pidestado_pedido);

                    // Ejecutar la consulta
                    retorno = cdmdelete.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se eliminó ninguna fila.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el estado del pedido: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }




    }
}
