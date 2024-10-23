using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;
using Microsoft.IdentityModel.Tokens;

namespace plantilla_navegable.Forms
{
    public partial class FormUsuario : Form
    {
        private controladorusuario usuario = new controladorusuario();

        private void llenarTipoDoc()
        {
            cmbDock.DataSource = usuario.ObtenerTipoDocumentoUsuarios();
            cmbDock.DisplayMember = "tipo_documento";
            cmbDock.ValueMember = "id_tipodoc";
        }

        private void llenarEstados()
        {
            cmbEstado.DataSource = usuario.ObtenerEstadoUsuarios();
            cmbEstado.DisplayMember = "estado";
            cmbEstado.ValueMember = "id_estadousuario";
        }

        private void obtenerUsuarios()
        {
            dataGridView1.DataSource = usuario.ObtenerUsuarios();
        }

        private bool contraseñaSegura()
        {
            bool tieneMayuscula = false;
            bool tieneMinuscula = false;
            bool tieneNumero = false;
            bool tieneCaracterEspecial = false;

            foreach (char c in usuario.clave)
            {
                if (char.IsUpper(c))
                    tieneMayuscula = true;
                else if (char.IsLower(c))
                    tieneMinuscula = true;
                else if (char.IsDigit(c))
                    tieneNumero = true;
                else if (!char.IsLetterOrDigit(c))
                    tieneCaracterEspecial = true;
            }

            if (tieneMayuscula && tieneMinuscula && tieneNumero && tieneCaracterEspecial)
                return true;
            else return false;
        }

        public FormUsuario()
        {
            InitializeComponent();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            llenarEstados();
            llenarTipoDoc();
            obtenerUsuarios();
        }


        private (bool, string) validarCampos()
        {
            // Patrón para validar correos electrónicos
            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Validar si hay algún campo vacío
            if (string.IsNullOrEmpty(txtclave.Text) ||
                string.IsNullOrEmpty(txtcorreo.Text) ||
                string.IsNullOrEmpty(txtdireccion.Text) ||
                string.IsNullOrEmpty(txtdoc.Text) ||
                string.IsNullOrEmpty(txttelefono.Text) ||
                string.IsNullOrEmpty(txtUsuario.Text))
            {
                return (false, "No se permiten campos vacíos");
            }

            // Validar el formato del correo electrónico
            else if (!Regex.IsMatch(txtcorreo.Text, patronCorreo))
            {
                return (false, "Correo con formato inválido");
            }

            // Validar longitud de la contraseña
            else if (txtclave.Text.Length < 8)
            {
                return (false, "La contraseña debe contener al menos 8 caracteres");
            }

            // Validar seguridad de la contraseña
            else if (!contraseñaSegura())
            {
                return (false, "La contraseña debe contener al menos una mayúscula, una minúscula, un número y un carácter especial");
            }

            // Si todo está correcto
            return (true, "");
        }


        private void datosUsuario()
        {
            usuario.id_usuario = int.Parse(txtId.Text);
            usuario.clave = txtclave.Text;
            usuario.nombre = txtUsuario.Text;
            usuario.telefono = txttelefono.Text;
            usuario.direccion = txtdireccion.Text;
            usuario.correo_electronico = txtcorreo.Text;
            usuario.numero_doc = txtdoc.Text;
            usuario.id_estadousuario = Convert.ToInt16(cmbEstado.SelectedValue);
            usuario.id_tipodoc = Convert.ToInt16(cmbEstado.SelectedValue);
        }



        private void limpiar()
        {
            txtId.Clear();
            txtUsuario.Clear();
            txttelefono.Clear();
            txtdireccion.Clear();
            txtcorreo.Clear();
            txtclave.Clear();
            txtdoc.Clear();
            cmbDock.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtId.Text = "1";
            datosUsuario();

            (bool valido, string mensaje) = validarCampos();

            if (!valido)
                MessageBox.Show(mensaje);
            else if (usuario.InsertarUsuario())
            {
                MessageBox.Show("Usuario Ingresado con exito");
                obtenerUsuarios();
                limpiar();
            }
            else
            {
                MessageBox.Show("Ha ocurriodo un error interno al intentar ingresar el usuario");
            }
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            datosUsuario();

            (bool valido, string mensaje) = validarCampos();

            if (!valido)
                MessageBox.Show(mensaje);
            else if (usuario.ActualizarUsuario())
            {
                MessageBox.Show("Usuario Actualizado con exito");
                obtenerUsuarios();
                limpiar();
            }
            else
            {
                MessageBox.Show("Ha ocurriodo un error interno al intentar actualizar el usuario");
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            datosUsuario();
            if (usuario.EliminarUsuario())
                MessageBox.Show("Usuario Eliminado con exito");
            else
                MessageBox.Show("Ha ocurriodo un error interno al intentar eliminar el usuario");
            obtenerUsuarios();
            limpiar();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                txtId.Text = fila.Cells[0].Value.ToString();
                txtUsuario.Text = fila.Cells[1].Value.ToString();
                cmbDock.SelectedIndex = (int.Parse(fila.Cells[2].Value.ToString()) - 1);
                txtdoc.Text = fila.Cells[3].Value.ToString();
                txttelefono.Text = fila.Cells[4].Value.ToString();
                txtcorreo.Text = fila.Cells[5].Value.ToString();
                txtdireccion.Text = fila.Cells[6].Value.ToString();
                txtclave.Text = fila.Cells[7].Value.ToString();
                cmbEstado.SelectedIndex = (int.Parse(fila.Cells[8].Value.ToString()) - 1);
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
