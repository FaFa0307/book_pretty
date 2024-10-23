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
    public class modelometodopago
    {


        //Agregar
        public static int agregardatoscrudmetodopago(string pdescripcion)
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

                    SqlCommand cmdinsert = new SqlCommand("INSERT INTO metodo_pago (descripcion) VALUES (@descripcion)", conexion);
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
                MessageBox.Show("Error al insertar el estado pedido: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }


        //Cargar Tabla
        public static DataTable CargarMetodosPagos()
        {
            DataTable data;
            try
            {
                string query = "SELECT*FROM metodo_pago";
                SqlCommand cmdselecmetodopago = new SqlCommand(string.Format(query), modeloconexion.Conectar());
                SqlDataAdapter adp = new SqlDataAdapter(cmdselecmetodopago);
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
        public static int actualizardatoscrudmetodopago(int pid_metodopago, string pdescripcion)
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
                        "UPDATE metodo_pago SET " +
                        "descripcion = @descripcion " +
                        "WHERE id_metodopago = @id_metodopago", conexion);

                    // Agregar los parámetros a la consulta
                    cdmupdate.Parameters.AddWithValue("@descripcion", pdescripcion);
                    cdmupdate.Parameters.AddWithValue("@id_metodopago", pid_metodopago); // Identificador del estado pedido a actualizar

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
                MessageBox.Show("Error al actualizar el metodo pago: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }



        //Eliminar

        public static int eliminardatoscrudmetodopago(int pid_metodopago)
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
                        "DELETE FROM metodo_pago WHERE id_metodopago = @id_metodopago", conexion);

                    // Agregar el parámetro del ID del producto
                    cdmdelete.Parameters.AddWithValue("@id_metodopago", pid_metodopago);

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
                MessageBox.Show("Error al eliminar el metodo de pago: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }




    }
}
