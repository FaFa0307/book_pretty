using System;
using Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Controlador
{
    public class controladorlogin
    {
        // Propiedades para el controlador
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }

        // Constructor
        public controladorlogin() { }

        // Método para autenticar usuario
        public bool AutenticarUsuario()
        {
            return modelologin.AutenticarUsuario(NombreUsuario, Contrasena);
        }

        // Método para autenticar cliente
        public bool AutenticarCliente()
        {
            return modelologin.AutenticarCliente(NombreUsuario, Contrasena);
        }

    }
}
