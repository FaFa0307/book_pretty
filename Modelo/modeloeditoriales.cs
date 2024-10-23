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
    public class modeloeditoriales
    {


        public static int agregardatoscrudeditoriales(string pnombre_editorial)
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

                    SqlCommand cmdinsert = new SqlCommand("INSERT INTO editoriales (nombre_editorial) VALUES (@nombre_editorial)", conexion);
                    cmdinsert.Parameters.AddWithValue("@nombre_editorial", pnombre_editorial);

                    retorno = cmdinsert.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se insertaron filas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar la editorial: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

        public static DataTable CargarEditoriales()
        {
            DataTable data;
            try
            {
                string query = "SELECT * FROM editoriales";
                SqlCommand cmdselecEditoriales = new SqlCommand(query, modeloconexion.Conectar());
                SqlDataAdapter adp = new SqlDataAdapter(cmdselecEditoriales);
                data = new DataTable();
                adp.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return data = null;
            }
        }

        public static int actualizardatoscrudeditoriales(int pid_editorial, string pnombre_editorial)
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
                        "UPDATE editoriales SET " +
                        "nombre_editorial = @nombre_editorial " +
                        "WHERE id_editorial = @id_editorial", conexion);

                    cdmupdate.Parameters.AddWithValue("@nombre_editorial", pnombre_editorial);
                    cdmupdate.Parameters.AddWithValue("@id_editorial", pid_editorial);

                    retorno = cdmupdate.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se actualizó ninguna fila.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la editorial: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }


        public static int eliminardatoscrudeditoriales(int pid_editorial)
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

                    SqlCommand cdmdelete = new SqlCommand(
                        "DELETE FROM editoriales WHERE id_editorial = @id_editorial", conexion);

                    cdmdelete.Parameters.AddWithValue("@id_editorial", pid_editorial);

                    retorno = cdmdelete.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se eliminó ninguna fila.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la editorial: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }



    }
}
