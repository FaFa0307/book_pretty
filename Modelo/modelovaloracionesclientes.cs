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
    public class modelovaloracionesclientes
    {
        public static bool InsertarValoraciones(int calificacion_producto, string comentario, DateTime fecha_comentario, int id_detallepedido, bool estado_comentario)
        {
            bool response = false;
            try
            {
                using (SqlConnection conexion = modeloconexion.Conectar())
                {
                    if (conexion == null || conexion.State != ConnectionState.Open)
                    {
                        throw new Exception("No se pudo conectar a la base de datos.");
                    }
                    SqlCommand cmd = new SqlCommand("insert into valoraciones (calificacion_producto, comentario, fecha_comentario, id_detallepedido, estado_comentario) values (@calificacion_producto, @comentario, @fecha_comentario, @id_detallepedido, @estado_comentario)", conexion);
                    cmd.Parameters.AddWithValue("@calificacion_producto", calificacion_producto);
                    cmd.Parameters.AddWithValue("@comentario", comentario);
                    cmd.Parameters.AddWithValue("@fecha_comentario", fecha_comentario);
                    cmd.Parameters.AddWithValue("@id_detallepedido", id_detallepedido);
                    cmd.Parameters.AddWithValue("@estado_comentario", estado_comentario);

                    if (cmd.ExecuteNonQuery() > 0)
                        response = true;
                    else response = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el producto: " + ex.Message);
                response = false;
                throw;
            }
            return response;
        }

        public static bool ActualizarValoraciones(int id_valoracion, int calificacion_producto, string comentario, DateTime fecha_comentario, int id_detallepedido, bool estado_comentario)
        {
            bool response = false;
            try
            {
                using (SqlConnection conexion = modeloconexion.Conectar())
                {
                    if (conexion == null || conexion.State != ConnectionState.Open)
                    {
                        throw new Exception("No se pudo conectar a la base de datos.");
                    }
                    SqlCommand cmd = new SqlCommand("update valoraciones set calificacion_producto = @calificacion_producto, comentario = @comentario, fecha_comentario = @fecha_comentario, id_detallepedido = @id_detallepedido, estado_comentario = @estado_comentario where id_valoracion = @id_valoracion", conexion);
                    cmd.Parameters.AddWithValue("@id_valoracion", id_valoracion);
                    cmd.Parameters.AddWithValue("@calificacion_producto", calificacion_producto);
                    cmd.Parameters.AddWithValue("@comentario", comentario);
                    cmd.Parameters.AddWithValue("@fecha_comentario", fecha_comentario);
                    cmd.Parameters.AddWithValue("@id_detallepedido", id_detallepedido);
                    cmd.Parameters.AddWithValue("@estado_comentario", estado_comentario);

                    if (cmd.ExecuteNonQuery() > 0)
                        response = true;
                    else response = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el tipo documento: " + ex.Message);
                response = false;
                throw;
            }
            return response;
        }

        public static DataTable ObtenerValoraciones()
        {
            DataTable data;
            try
            {
                string query = "select * from valoraciones";
                SqlCommand cmd = new SqlCommand(string.Format(query), modeloconexion.Conectar());
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                data = new DataTable();
                adapter.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return data = null;
            }
        }

        public static bool EliminarValoraciones(int id_valoracion)
        {
            bool response = false;
            try
            {
                SqlCommand cmd = new SqlCommand("delete from valoraciones where id_valoracion = @id_valoracion", modeloconexion.Conectar());
                cmd.Parameters.AddWithValue("@id_valoracion", id_valoracion);

                if (cmd.ExecuteNonQuery() > 0)
                    response = true;
                else response = false;
                return response;
            }
            catch (Exception)
            {
                return response;
            }
        }

    }
}
