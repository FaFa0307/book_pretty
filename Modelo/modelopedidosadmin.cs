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
    public class modelopedidosadmin
    {


        

        public static DataTable CargarEstadoPedidoAdminInner()
        {
            DataTable data;
            try
            {
                string query = "SELECT * FROM estados_pedidos";
                SqlCommand cmdselectestadopedidoadmin = new SqlCommand(query, modeloconexion.Conectar());
                SqlDataAdapter adp = new SqlDataAdapter(cmdselectestadopedidoadmin);
                data = new DataTable();
                adp.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return data = null;
            }
        }



        public static DataTable CargarPedidosAdmin()
        {
            DataTable data;
            try
            {
                string query = "SELECT*FROM pedidos";
                SqlCommand cmdselectpedidosadmin = new SqlCommand(string.Format(query), modeloconexion.Conectar());
                SqlDataAdapter adp = new SqlDataAdapter(cmdselectpedidosadmin);
                data = new DataTable();
                adp.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return data = null;
            }
        }


        public static int actualizarPedidosAdminDatos(int pid_pedido, int pid_estadopedido, DateTime pfecha_entrega)
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
                        "UPDATE pedidos SET " +
                        "id_estadopedido = @id_estadopedido, " + // El nuevo estado
                        "fecha_entrega = @fecha_entrega " +     // La nueva fecha de entrega
                        "WHERE id_pedido = @id_pedido", conexion);

                    // Agregar los parámetros a la consulta
                    cdmupdate.Parameters.AddWithValue("@id_estadopedido", pid_estadopedido);
                    cdmupdate.Parameters.AddWithValue("@fecha_entrega", pfecha_entrega);
                    cdmupdate.Parameters.AddWithValue("@id_pedido", pid_pedido); // Identificador del pedido a actualizar

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
                MessageBox.Show("Error al actualizar el pedido: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

    }
}
