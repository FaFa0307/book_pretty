using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class controladorusuario
    {

        public controladorusuario() { }
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public int id_tipodoc { get; set; }
        public string numero_doc { get; set; }
        public string telefono { get; set; }
        public string correo_electronico { get; set; }
        public string direccion { get; set; }
        public string clave { get; set; }
        public int id_estadousuario { get; set; }
        public bool InsertarUsuario()
        {
            return modelousuario.InsertarUsuario(nombre, id_tipodoc, numero_doc, telefono, correo_electronico, direccion, clave, id_estadousuario);
        }

        public bool ActualizarUsuario()
        {
            return modelousuario.ActualizarUsuario(id_usuario, nombre, id_tipodoc, numero_doc, telefono, correo_electronico, direccion, clave, id_estadousuario);
        }

        public DataTable ObtenerUsuario()
        {
            return modelousuario.ObtenerUsuario(id_usuario);
        }

        public DataTable ObtenerUsuarios()
        {
            return modelousuario.ObtenerUsuarios();
        }

        public bool EliminarUsuario()
        {
            return modelousuario.EliminarUsuarios(id_usuario);
        }

        public DataTable ObtenerEstadoUsuarios()
        {
            return modelousuario.ObtenerEstadosUsuarios();
        }

        public DataTable ObtenerTipoDocumentoUsuarios()
        {
            return modelousuario.ObtenerTipoDocumentoUsuarios();
        }


    }
}
