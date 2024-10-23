using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Modelo
{
    public class modeloproductosdatos
    {
        public static DataTable CargarCatergoriaProductos() {
            DataTable data;
			try
			{
                string query = "SELECT*FROM categorias";
                SqlCommand cmdselectcat = new SqlCommand(string.Format(query),modeloconexion.Conectar());
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

        public static DataTable CargarEditorialProductos()
        {
            DataTable data;
            try
            {
                string query = "SELECT*FROM editoriales";
                SqlCommand cmdselectedit = new SqlCommand(string.Format(query), modeloconexion.Conectar());
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

        public static DataTable CargarUsuarioProductos()
        {
            DataTable data;
            try
            {
                string query = "SELECT*FROM usuarios";
                SqlCommand cmdselectusu = new SqlCommand(string.Format(query), modeloconexion.Conectar());
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

        public static DataTable CargarAutorProductos()
        {
            DataTable data;
            try
            {
                string query = "SELECT*FROM autores";
                SqlCommand cmdselectautor = new SqlCommand(string.Format(query), modeloconexion.Conectar());
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


    }
}
