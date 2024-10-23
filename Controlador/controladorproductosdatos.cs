using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Modelo;
namespace Controlador
{
    public class controladorproductosdatos
    {
        public static DataTable CargarCategoria() {
            return modeloproductosdatos.CargarCatergoriaProductos();
        }

        public static DataTable CargarEditoriales() { 
            return modeloproductosdatos.CargarEditorialProductos();
        }

        public static DataTable CargarUsuario() {
            return modeloproductosdatos.CargarUsuarioProductos();
        }

        public static DataTable CargarAutor() {
            return modeloproductosdatos.CargarAutorProductos();
        }

    }
}
