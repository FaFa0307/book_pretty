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
    public class modeloproductos
    {
        

        public static int agregardatos(string pnombre_producto, string pdescripcion, decimal pprecio, decimal pporcentaje, string pisbn, string pimagen, int pstock, bool pestado_producto, int pid_categoria, int pid_editorial, int pid_autor, int pid_usuario)
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

                    SqlCommand cmdinsert = new SqlCommand("INSERT INTO productos (nombre_producto, descripcion, precio, id_categoria, id_editorial, estado_producto, id_usuario, id_autor, porcentaje_descuento, isbn, imagen, stock) VALUES (@nombre_producto, @descripcion, @precio, @id_categoria, @id_editorial, @estado_producto, @id_usuario, @id_autor, @porcentaje_descuento, @isbn, @imagen, @stock)", conexion);
                    cmdinsert.Parameters.AddWithValue("@nombre_producto", pnombre_producto);
                    cmdinsert.Parameters.AddWithValue("@descripcion", pdescripcion);
                    cmdinsert.Parameters.AddWithValue("@precio", pprecio);
                    cmdinsert.Parameters.AddWithValue("@id_categoria", pid_categoria);
                    cmdinsert.Parameters.AddWithValue("@id_editorial", pid_editorial);
                    cmdinsert.Parameters.AddWithValue("@estado_producto", pestado_producto);
                    cmdinsert.Parameters.AddWithValue("@id_usuario", pid_usuario);
                    cmdinsert.Parameters.AddWithValue("@id_autor", pid_autor);
                    cmdinsert.Parameters.AddWithValue("@porcentaje_descuento", pporcentaje);
                    cmdinsert.Parameters.AddWithValue("@isbn", pisbn);
                    cmdinsert.Parameters.AddWithValue("@imagen", pimagen);
                    cmdinsert.Parameters.AddWithValue("@stock", pstock);

                    retorno = cmdinsert.ExecuteNonQuery();
                    if (retorno == 0)
                    {
                        throw new Exception("No se insertaron filas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el producto: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

        //Cargar tabla
        public static DataTable CargarProductos()
        {
            DataTable data;
            try
            {
                string query = "SELECT*FROM productos";
                SqlCommand cmdselectprod = new SqlCommand(string.Format(query), modeloconexion.Conectar());
                SqlDataAdapter adp = new SqlDataAdapter(cmdselectprod);
                data = new DataTable();
                adp.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return data = null;
            }
        }
        
        //Para que en actualizar se vaya al cmb lo que hay en el datagrid
        public static DataTable CargarCategoriaInner(int id) {
            DataTable data;
            try
            {
                string query = "SELECT*FROM categorias where id_categoria = @param1";
                SqlCommand cmdselectcat = new SqlCommand(string.Format(query), modeloconexion.Conectar());
                cmdselectcat.Parameters.Add(new SqlParameter("param1", id));
                SqlDataAdapter adp = new SqlDataAdapter(cmdselectcat);
                data = new DataTable();
                adp.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return data = null;
            }

        }

        public static DataTable CargarEditorialInner(int id)
        {
            DataTable data;
            try
            {
                string query = "SELECT*FROM editoriales where id_editorial = @param1";
                SqlCommand cmdselectedit = new SqlCommand(string.Format(query), modeloconexion.Conectar());
                cmdselectedit.Parameters.Add(new SqlParameter("param1", id));
                SqlDataAdapter adp = new SqlDataAdapter(cmdselectedit);
                data = new DataTable();
                adp.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return data = null;
            }
        }

        public static DataTable CargarUsuarioInner(int id)
        {
            DataTable data;
            try
            {
                string query = "SELECT*FROM usuarios where id_usuario = @param1";
                SqlCommand cmdselectusu = new SqlCommand(string.Format(query), modeloconexion.Conectar());
                cmdselectusu.Parameters.Add(new SqlParameter("param1", id));
                SqlDataAdapter adp = new SqlDataAdapter(cmdselectusu);
                data = new DataTable();
                adp.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return data = null;
            }
        }

        public static DataTable CargarAutorInner(int id)
        {
            DataTable data;
            try
            {
                string query = "SELECT*FROM autores where id_autor = @param1";
                SqlCommand cmdselectautor = new SqlCommand(string.Format(query), modeloconexion.Conectar());
                cmdselectautor.Parameters.Add(new SqlParameter("param1", id));
                SqlDataAdapter adp = new SqlDataAdapter(cmdselectautor);
                data = new DataTable();
                adp.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return data = null;
            }
        }

        public static int actualizardatos(int pid_producto, string pnombre_producto, string pdescripcion, decimal pprecio, decimal pporcentaje, string pisbn, string pimagen, int pstock, bool pestado_producto, int pid_categoria, int pid_editorial, int pid_autor, int pid_usuario)
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
                        "UPDATE productos SET " +
                        "nombre_producto = @nombre_producto, " +
                        "descripcion = @descripcion, " +
                        "precio = @precio, " +
                        "porcentaje_descuento = @porcentaje_descuento, " +
                        "isbn = @isbn, " +
                        "imagen = @imagen, " +
                        "stock = @stock, " +
                        "estado_producto = @estado_producto, " +
                        "id_categoria = @id_categoria, " +
                        "id_editorial = @id_editorial, " +
                        "id_autor = @id_autor, " +
                        "id_usuario = @id_usuario " +
                        "WHERE id_producto = @id_producto", conexion);

                    // Agregar los parámetros a la consulta
                    cdmupdate.Parameters.AddWithValue("@nombre_producto", pnombre_producto);
                    cdmupdate.Parameters.AddWithValue("@descripcion", pdescripcion);
                    cdmupdate.Parameters.AddWithValue("@precio", pprecio);
                    cdmupdate.Parameters.AddWithValue("@porcentaje_descuento", pporcentaje);
                    cdmupdate.Parameters.AddWithValue("@isbn", pisbn);

                    // Verificar si pimagen es null o vacío
                    if (string.IsNullOrEmpty(pimagen))
                    {
                        cdmupdate.Parameters.AddWithValue("@imagen", DBNull.Value);
                    }
                    else
                    {
                        cdmupdate.Parameters.AddWithValue("@imagen", pimagen);
                    }

                    cdmupdate.Parameters.AddWithValue("@stock", pstock);
                    cdmupdate.Parameters.AddWithValue("@estado_producto", pestado_producto);
                    cdmupdate.Parameters.AddWithValue("@id_categoria", pid_categoria);
                    cdmupdate.Parameters.AddWithValue("@id_editorial", pid_editorial);
                    cdmupdate.Parameters.AddWithValue("@id_autor", pid_autor);
                    cdmupdate.Parameters.AddWithValue("@id_usuario", pid_usuario);
                    cdmupdate.Parameters.AddWithValue("@id_producto", pid_producto); // Identificador del producto a actualizar

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
                MessageBox.Show("Error al actualizar el producto: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }

        public static int eliminardatos(int pid_producto)
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
                        "DELETE FROM productos WHERE id_producto = @id_producto", conexion);

                    // Agregar el parámetro del ID del producto
                    cdmdelete.Parameters.AddWithValue("@id_producto", pid_producto);

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
                MessageBox.Show("Error al eliminar el producto: " + ex.Message);
                return -1; // Retorno para indicar error
            }
            return retorno; // Retorna el número de filas afectadas
        }


    }
}
