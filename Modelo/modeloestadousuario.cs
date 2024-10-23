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
    public class modeloestadousuario
    {

        public static int agregardatoscrudestadousuario(string pestado_usuario)
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

                    SqlCommand cmdinsert = new SqlCommand("INSERT INTO estados_usuarios (estado) VALUES (@estado)", conexion);
                    cmdinsert.Parameters.AddWithValue("@estado", pestado_usuario);

                    retorno = cmdinsert.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se insertaron filas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el estado usuario: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }


        //Cargar Tabla
        public static DataTable CargarEstadoUsuario()
        {
            DataTable data;
            try
            {
                string query = "SELECT*FROM estados_usuarios";
                SqlCommand cmdselecestadousuario = new SqlCommand(string.Format(query), modeloconexion.Conectar());
                SqlDataAdapter adp = new SqlDataAdapter(cmdselecestadousuario);
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
        public static int actualizardatoscrudestadousuario(int pidestado_usuario, string pestado_usuario)
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
                        "UPDATE estados_usuarios SET " +
                        "estado = @estado " +
                        "WHERE id_estadousuario = @id_estadousuario", conexion);

                    // Agregar los parámetros a la consulta
                    cdmupdate.Parameters.AddWithValue("@estado", pestado_usuario);
                    cdmupdate.Parameters.AddWithValue("@id_estadousuario", pidestado_usuario); // Identificador del estado pedido a actualizar

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
                MessageBox.Show("Error al actualizar el usuario: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }



        //Eliminar

        public static int eliminardatoscrudestadousuario(int pidestado_usuario)
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
                        "DELETE FROM estados_usuarios WHERE id_estadousuario = @id_estadousuario", conexion);

                    // Agregar el parámetro del ID del producto
                    cdmdelete.Parameters.AddWithValue("@id_estadousuario", pidestado_usuario);

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
                MessageBox.Show("Error al eliminar el estado del usuario: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }



    }
}
