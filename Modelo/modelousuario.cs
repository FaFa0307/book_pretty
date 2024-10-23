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
    public class modelousuario
    {
        public static bool InsertarUsuario(string nombre, int id_tipodoc, string numero_doc, string telefono, string correo_electronico, string direccion, string clave, int id_estadousuario)
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

                    SqlCommand cmd = new SqlCommand("insert into usuarios (nombre, id_tipodoc, numero_doc, telefono, correo_electronico, direccion, clave, id_estadousuario) values (@nombre, @id_tipodoc, @numero_doc, @telefono, @correo_electronico, @direccion, @clave, @id_estadousuario)", conexion);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@id_tipodoc", id_tipodoc);
                    cmd.Parameters.AddWithValue("@numero_doc", numero_doc);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@correo_electronico", correo_electronico);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@clave", clave);
                    cmd.Parameters.AddWithValue("@id_estadousuario", id_estadousuario);

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

        public static bool ActualizarUsuario(int id_usuario, string nombre, int id_tipodoc, string numero_doc, string telefono, string correo_electronico, string direccion, string clave, int id_estadousuario)
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

                    SqlCommand cmd = new SqlCommand("update usuarios set nombre = @nombre, id_tipodoc = @id_tipodoc, numero_doc = @numero_doc, telefono = @telefono, correo_electronico = @correo_electronico, direccion= @direccion, clave= @clave, id_estadousuario = @id_estadousuario where id_usuario = @id_usuario", conexion);
                    cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@id_tipodoc", id_tipodoc);
                    cmd.Parameters.AddWithValue("@numero_doc", numero_doc);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@correo_electronico", correo_electronico);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@clave", clave);
                    cmd.Parameters.AddWithValue("@id_estadousuario", id_estadousuario);

                    if (cmd.ExecuteNonQuery() > 0)
                        response = true;
                    else response = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Actualizar el producto: " + ex.Message);
                response = false;
                throw;
            }


            return response;
        }

        public static DataTable ObtenerUsuario(int id_usuario)
        {
            DataTable data;
            try
            {
                using (SqlConnection conexion = modeloconexion.Conectar())
                {
                    if (conexion == null || conexion.State != ConnectionState.Open)
                    {
                        throw new Exception("No se pudo conectar a la base de datos.");
                    }

                    SqlCommand cmd = new SqlCommand("select * from usuarios where id_usuario = @id_usuario", conexion);
                    cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    data = new DataTable();
                    adapter.Fill(data);
                    return data;
                }
            }
            catch (Exception)
            {
                return data = null;
            }
        }

        public static DataTable ObtenerUsuarios()
        {
            DataTable data;
            try
            {
                SqlCommand cmd = new SqlCommand("select * from usuarios", modeloconexion.Conectar());
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

        public static DataTable ObtenerEstadosUsuarios()
        {
            DataTable data;
            try
            {
                SqlCommand cmd = new SqlCommand("select * from estados_usuarios", modeloconexion.Conectar());
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

        public static DataTable ObtenerTipoDocumentoUsuarios()
        {
            DataTable data;
            try
            {
                string query = "select * from tipos_documentos";
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

        public static bool EliminarUsuarios(int id_usuario)
        {
            bool response = false;
            try
            {
                SqlCommand cmd = new SqlCommand("delete from usuarios where id_usuario = @id_usuario", modeloconexion.Conectar());
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);

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
