using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;

namespace Controlador
{
    public class controladorusuario
    {

        public controladorusuario() { }
        public int id_usuario { get; set; }

        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
            set
            {
                // Valida si el nombre contiene solo letras
                if (Validator.ValidateAlphabetic(value))
                {
                    _nombre = value;
                }
                else
                {
                    MessageBox.Show("El nombre debe contener solo letras.",
                    "Error con el nombre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public int id_tipodoc { get; set; }

        public string numero_doc { get; set; }

        private string _telefono;
        public string telefono
        {
            get { return _telefono; }
            set
            {
                // Valida si el número de teléfono cumple con el patrón definido
                if (Validator.ValidatePhoneNumber(value))
                {
                    _telefono = value;
                }
                else
                {
                    MessageBox.Show("El número de teléfono no es válido. Debe comenzar con 6 o 7 y tener 8 dígitos.",
                    "Error con el número de teléfono", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private string _correo_electronico;
        public string correo_electronico
        {
            get { return _correo_electronico; }
            set
            {
                // Valida si el correo electrónico cumple con el patrón definido
                if (Validator.ValidateEmail(value))
                {
                    _correo_electronico = value;
                }
                else
                {
                    MessageBox.Show("El correo electrónico no es válido. Debe tener un formato correcto como ejemplo@dominio.com.",
                    "Error con el correo electrónico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public string direccion { get; set; }

        private string _clave;
        public string clave
        {
            get { return _clave; }
            set
            {
                // Valida si la clave cumple con los requisitos de longitud
                if (Validator.ValidatePassword(value))
                {
                    _clave = value;
                }
                else
                {
                    MessageBox.Show("La clave debe tener al menos 8 caracteres.",
                    "Error con la clave", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


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
