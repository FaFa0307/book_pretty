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
    public class contoladorestadopedido
    {
        //Se pone el controlador que se llama igual que la clase
        public contoladorestadopedido() { }

        public static int id_estadopedido { get; set; }

        private string _estado_pedido;
        public string estado_pedido
        {
            get { return _estado_pedido; }
            set
            {
                if (Validator.ValidateAlphabetic(value))
                {
                    _estado_pedido = value;
                }
                else
                {
                    MessageBox.Show("El nombre del estado de pedido debe contener solo letras.",
                    "Error con el estado de pedido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //Para ingresar
        public int ingresarestadopedido() {
            return modeloestadopedido.agregardatoscrudestadopedido(estado_pedido);
        }

        //Para Cargar Tabla
        public DataTable LeerDatosEstadoPedidos() {
            return modeloestadopedido.CargarEstadoPedido();
        }

        //Para actualizar
        public int actualizarestadopedido() {
            return modeloestadopedido.actualizardatoscrudestadopedido(id_estadopedido, estado_pedido);
        }

        //Para Eliminar

        public int eliminardatosestadopedido(int id_estadopedido) {
            return modeloestadopedido.eliminardatoscrudestadopedido(id_estadopedido);
        }

    }
}
