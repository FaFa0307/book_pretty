using System;
using Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Controlador
{
    public class controladorestadousuario
    {

        //Se pone el controlador que se llama igual que la clase
        public controladorestadousuario() { }

        public static int id_estadousuario { get; set; }
        private string _estado_usuario;
        public string estado_usuario
        {
            get { return _estado_usuario; }
            set
            {
                if (Validator.ValidateAlphabetic(value))
                {
                    _estado_usuario = value;
                }
                else
                {
                    MessageBox.Show("El nombre del estado de usuario debe contener solo letras.",
                    "Error con el estado de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //Para ingresar
        public int ingresarestadousuario()
        {
            return modeloestadousuario.agregardatoscrudestadousuario(estado_usuario);
        }

        //Para Cargar Tabla
        public DataTable LeerDatosEstadoUsuarios()
        {
            return modeloestadousuario.CargarEstadoUsuario();
        }

        //Para actualizar
        public int actualizarestadousuario()
        {
            return modeloestadousuario.actualizardatoscrudestadousuario(id_estadousuario, estado_usuario);
        }

        //Para Eliminar

        public int eliminardatosestadousuario(int id_estadousuario)
        {
            return modeloestadousuario.eliminardatoscrudestadousuario(id_estadousuario);
        }


    }
}
