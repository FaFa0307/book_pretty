using Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plantilla_navegable
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            // Crear un nuevo controlador y asignarle los datos del formulario
            controladorlogin controlador = new controladorlogin
            {
                NombreUsuario = txtUsername.Text,
                Contrasena = txtPassword.Text
            };

            // Si es administrador
            if (controlador.AutenticarUsuario())
            {
                // Abrir el formulario principal para administrador
                Form1 adminForm = new Form1(true); // true indica permisos de administrador
                adminForm.Show();
                this.Hide();
            }
            // Si es cliente
            else if (controlador.AutenticarCliente())
            {
                // Abrir el formulario principal para cliente
                Form1 clientForm = new Form1(false); // false indica permisos de cliente
                clientForm.Show();
                this.Hide();
            }
            else
            {
                // Si las credenciales son incorrectas
                lberror.Text = "Nombre o contraseña incorrectos.";
            }

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
