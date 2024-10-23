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
    public class modelocategoria
    {
        public static int AgregarCategoria(string pnombre_categoria)
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

                    SqlCommand cmdinsert = new SqlCommand("INSERT INTO categorias (nombre_categoria) VALUES (@nombre_categoria)", conexion);
                    cmdinsert.Parameters.AddWithValue("@nombre_categoria", pnombre_categoria);
                    retorno = cmdinsert.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se insertaron filas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar categoria: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

        public static int ActualizarCategoria(int pid_categoria, string pnombre_categoria)
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

                    SqlCommand cmdinsert = new SqlCommand("UPDATE categorias SET nombre_categoria = @nombre_categoria WHERE id_categoria = @id_categoria", conexion);
                    cmdinsert.Parameters.AddWithValue("@nombre_categoria", pnombre_categoria);
                    cmdinsert.Parameters.AddWithValue("@id_categoria", pid_categoria);
                    retorno = cmdinsert.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se insertaron filas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar categoria: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

        public static int EliminarCategoria(int pid_categoria)
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

                    SqlCommand cmddelete = new SqlCommand("DELETE FROM categorias WHERE id_categoria = @id_categoria", conexion);
                    cmddelete.Parameters.AddWithValue("@id_categoria", pid_categoria);
                    retorno = cmddelete.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se insertaron filas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar categoria: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

        public static DataTable CargarCategoria()
        {
            DataTable data;
            try
            {
                string query = "SELECT*FROM categorias";
                SqlCommand cmdselectcat = new SqlCommand(string.Format(query), modeloconexion.Conectar());
                SqlDataAdapter adp = new SqlDataAdapter(cmdselectcat);
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
