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
    public class modelotipodocumento
    {
        // Agregar datos a la tabla tipos_documentos
        public static int agregardatoscrudtipodocumento(string ptipo_documento)
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

                    SqlCommand cmdinsert = new SqlCommand("INSERT INTO tipos_documentos (tipo_documento) VALUES (@tipo_documento)", conexion);
                    cmdinsert.Parameters.AddWithValue("@tipo_documento", ptipo_documento);

                    retorno = cmdinsert.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se insertaron filas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el tipo de documento: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

        // Cargar la tabla tipos_documentos
        public static DataTable CargarTipoDocumento()
        {
            DataTable data = new DataTable();
            try
            {
                string query = "SELECT * FROM tipos_documentos"; // Se seleccionan todos los campos de la tabla
                using (SqlConnection conexion = modeloconexion.Conectar())
                {
                    SqlCommand cmdselec = new SqlCommand(query, conexion);
                    SqlDataAdapter adp = new SqlDataAdapter(cmdselec);
                    adp.Fill(data);
                }
            }
            catch (Exception)
            {
                return null; // Retorna null en caso de error
            }
            return data; // Retorna el DataTable con los datos
        }

        // Actualizar datos en la tabla tipos_documentos
        public static int actualizardatoscrudtipodocumento(int pid_tipodoc, string ptipo_documento)
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
                        "UPDATE tipos_documentos SET tipo_documento = @tipo_documento WHERE id_tipodoc = @id_tipodoc", conexion);

                    // Agregar los parámetros a la consulta
                    cmdupdate.Parameters.AddWithValue("@tipo_documento", ptipo_documento);
                    cmdupdate.Parameters.AddWithValue("@id_tipodoc", pid_tipodoc); // Identificador del tipo de documento a actualizar

                    // Ejecutar la consulta
                    retorno = cmdupdate.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se actualizó ninguna fila.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el tipo de documento: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

        // Eliminar datos en la tabla tipos_documentos
        public static int eliminardatoscrudtipodocumento(int pid_tipodoc)
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

                    // Consulta SQL para eliminar el tipo de documento
                    SqlCommand cmddelete = new SqlCommand("DELETE FROM tipos_documentos WHERE id_tipodoc = @id_tipodoc", conexion);

                    // Agregar el parámetro del ID del tipo de documento
                    cmddelete.Parameters.AddWithValue("@id_tipodoc", pid_tipodoc);

                    // Ejecutar la consulta
                    retorno = cmddelete.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se eliminó ninguna fila.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el tipo de documento: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }


    }
}
