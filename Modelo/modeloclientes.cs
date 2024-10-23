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
    public class modeloclientes
    {

        public static int AgregarCliente(string pnombres, string papellidos, int pid_tipodoc, string pnumero_doc,
                                string pdireccion, string ptelefono, string pcorreo_electronico,
                                string pclave, bool pestado_cliente)
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
                        "INSERT INTO clientes (nombres, apellidos, id_tipodoc, numero_doc, direccion, telefono, correo_electronico, clave, estado_cliente) " +
                        "VALUES (@Nombres, @Apellidos, @IdTipoDoc, @NumeroDoc, @Direccion, @Telefono, @CorreoElectronico, @Clave, @EstadoCliente)",
                        conexion);

                    // Add parameters
                    cmdinsert.Parameters.AddWithValue("@Nombres", pnombres);
                    cmdinsert.Parameters.AddWithValue("@Apellidos", papellidos);
                    cmdinsert.Parameters.AddWithValue("@IdTipoDoc", pid_tipodoc);  // Handles null values
                    cmdinsert.Parameters.AddWithValue("@NumeroDoc", pnumero_doc);  // Handles null values
                    cmdinsert.Parameters.AddWithValue("@Direccion", pdireccion);   // Handles null values
                    cmdinsert.Parameters.AddWithValue("@Telefono", ptelefono);     // Handles null values
                    cmdinsert.Parameters.AddWithValue("@CorreoElectronico", pcorreo_electronico);
                    cmdinsert.Parameters.AddWithValue("@Clave", pclave);
                    cmdinsert.Parameters.AddWithValue("@EstadoCliente", pestado_cliente);

                    // Execute insert command
                    retorno = cmdinsert.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se insertaron filas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar cliente: " + ex.Message);
                return -1; // Return -1 to indicate an error occurred
            }
            return retorno; // Return the number of rows affected
        }

        public static int ActualizarCliente(int pid_cliente, string pnombres, string papellidos, int? pid_tipodoc,
                                    string pnumero_doc, string pdireccion, string ptelefono,
                                    string pcorreo_electronico, string pclave, bool pestado_cliente)
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
                        "UPDATE clientes " +
                        "SET nombres = @Nombres, apellidos = @Apellidos, id_tipodoc = @IdTipoDoc, numero_doc = @NumeroDoc, " +
                        "direccion = @Direccion, telefono = @Telefono, correo_electronico = @CorreoElectronico, clave = @Clave, " +
                        "estado_cliente = @EstadoCliente " +
                        "WHERE id_cliente = @IdCliente;", conexion);

                    // Add parameters
                    cmdupdate.Parameters.AddWithValue("@Nombres", pnombres);
                    cmdupdate.Parameters.AddWithValue("@Apellidos", papellidos);
                    cmdupdate.Parameters.AddWithValue("@IdTipoDoc", pid_tipodoc);  // Handles null values
                    cmdupdate.Parameters.AddWithValue("@NumeroDoc", pnumero_doc);  // Handles null values
                    cmdupdate.Parameters.AddWithValue("@Direccion", pdireccion);   // Handles null values
                    cmdupdate.Parameters.AddWithValue("@Telefono", ptelefono);     // Handles null values
                    cmdupdate.Parameters.AddWithValue("@CorreoElectronico", pcorreo_electronico);
                    cmdupdate.Parameters.AddWithValue("@Clave", pclave);
                    cmdupdate.Parameters.AddWithValue("@EstadoCliente", pestado_cliente);
                    cmdupdate.Parameters.AddWithValue("@IdCliente", pid_cliente);

                    // Execute update command
                    retorno = cmdupdate.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se actualizaron filas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar cliente: " + ex.Message);
                return -1; // Return -1 to indicate an error occurred
            }
            return retorno; // Return the number of rows affected
        }

        public static int EliminarCliente(int pid_cliente)
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

                    SqlCommand cmddelete = new SqlCommand("DELETE FROM clientes WHERE id_cliente = @IdCliente", conexion);
                    cmddelete.Parameters.AddWithValue("@IdCliente", pid_cliente);
                    retorno = cmddelete.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se elimino.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar cliente: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }


        public static DataTable CargarClientes()
        {
            DataTable data;
            try
            {
                string query = "SELECT*FROM  clientes";
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
