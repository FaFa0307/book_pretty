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
    public class modelologin
    {

        public static bool AutenticarUsuario(string nombreUsuario, string contrasena)
        {
            try
            {
                using (SqlConnection conexion = modeloconexion.Conectar())
                {
                    if (conexion == null || conexion.State != ConnectionState.Open)
                    {
                        throw new Exception("No se pudo conectar a la base de datos.");
                    }

                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM usuarios WHERE nombre=@nombre AND clave=@clave", conexion);
                    cmd.Parameters.AddWithValue("@nombre", nombreUsuario);
                    cmd.Parameters.AddWithValue("@clave", contrasena);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al autenticar el usuario: " + ex.Message);
                return false; // Retorno para indicar error
            }
        }

        public static bool AutenticarCliente(string nombreUsuario, string contrasena)
        {
            try
            {
                using (SqlConnection conexion = modeloconexion.Conectar())
                {
                    if (conexion == null || conexion.State != ConnectionState.Open)
                    {
                        throw new Exception("No se pudo conectar a la base de datos.");
                    }

                    // Consulta para obtener el id_cliente si el correo y clave son correctos
                    SqlCommand cmd = new SqlCommand("SELECT id_cliente FROM clientes WHERE correo_electronico=@nombres AND clave=@clave_cliente", conexion);
                    cmd.Parameters.AddWithValue("@nombres", nombreUsuario);
                    cmd.Parameters.AddWithValue("@clave_cliente", contrasena);

                    object resultado = cmd.ExecuteScalar();

                    // Si el resultado no es nulo, significa que la autenticación fue exitosa
                    if (resultado != null)
                    {
                        // Guardar el id_cliente en VariablesGlobales
                        VariablesGlobales.IdCliente = Convert.ToInt32(resultado);

                        return true; // Autenticación exitosa
                    }
                    else
                    {
                        // Autenticación fallida
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al autenticar el cliente: " + ex.Message);
                return false; // Retorno para indicar error
            }
        }


    }
}
