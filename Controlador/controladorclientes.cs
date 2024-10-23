using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class controladorclientes
    {
        public controladorclientes() { }

        public int id_cliente { get; set; }

        public string nombres { get; set; }
        public string apellidos { get; set; }
        public int id_tipo_doc { get; set; }
        public string numero_doc { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public bool estado { get; set; }

        public int IngresarDatos()
        {
            return modeloclientes.AgregarCliente(nombres, apellidos, id_tipo_doc, numero_doc, direccion, telefono, correo, clave, estado);
        }

        public int ActualizarDatos()
        {
            return modeloclientes.ActualizarCliente(id_cliente, nombres, apellidos, id_tipo_doc, numero_doc, direccion, telefono, correo, clave, estado);
        }


        public int EliminarDatos()
        {
            return modeloclientes.EliminarCliente(id_cliente);
        }

        public DataTable ObtenerDatos()
        {
            return modeloclientes.CargarClientes();
        }




    }
}
