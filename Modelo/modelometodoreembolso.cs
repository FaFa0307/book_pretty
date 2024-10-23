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
    public class modelometodoreembolso
    {
        // Método para agregar un nuevo registro en la tabla metodo_reembolso
        public static int agregardatoscrudmetodoreembolso(string pdescripcion)
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

                    SqlCommand cmdinsert = new SqlCommand("INSERT INTO metodo_reembolso (descripcion) VALUES (@descripcion)", conexion);
                    cmdinsert.Parameters.AddWithValue("@descripcion", pdescripcion);

                    retorno = cmdinsert.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se insertaron filas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el método de reembolso: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

        // Método para cargar todos los registros de la tabla metodo_reembolso
        public static DataTable CargarMetodosReembolso()
        {
            DataTable data;
            try
            {
                string query = "SELECT * FROM metodo_reembolso";
                SqlCommand cmdselecmetodoreembolso = new SqlCommand(query, modeloconexion.Conectar());
                SqlDataAdapter adp = new SqlDataAdapter(cmdselecmetodoreembolso);
                data = new DataTable();
                adp.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return data = null;
            }
        }

        // Método para actualizar un registro de la tabla metodo_reembolso
        public static int actualizardatoscrudmetodoreembolso(int pid_metodoreembolso, string pdescripcion)
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
                        "UPDATE metodo_reembolso SET " +
                        "descripcion = @descripcion " +
                        "WHERE id_metodoreembolso = @id_metodoreembolso", conexion);

                    cdmupdate.Parameters.AddWithValue("@descripcion", pdescripcion);
                    cdmupdate.Parameters.AddWithValue("@id_metodoreembolso", pid_metodoreembolso);

                    retorno = cdmupdate.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se actualizó ninguna fila.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el método de reembolso: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

        // Método para eliminar un registro de la tabla metodo_reembolso
        public static int eliminardatoscrudmetodoreembolso(int pid_metodoreembolso)
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
                        "DELETE FROM metodo_reembolso WHERE id_metodoreembolso = @id_metodoreembolso", conexion);

                    cdmdelete.Parameters.AddWithValue("@id_metodoreembolso", pid_metodoreembolso);

                    retorno = cdmdelete.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se eliminó ninguna fila.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el método de reembolso: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }


    }
}
