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

namespace plantilla_navegable.Forms
{
    public partial class FormValoracionesClientes : Form
    {
        controladorvaloracionesclientes obj = new controladorvaloracionesclientes();


        public FormValoracionesClientes(int id_detallepedido)
        {
            InitializeComponent();
            obj.id_detallepedido = id_detallepedido;
        }

        private (bool, string) validaciones()
        {
            if (!int.TryParse(textBox1.Text, out int valoracion))
                return (false, "La calificacion debe ser un numero entero");
            else if (valoracion > 10 || valoracion < 0)
                return (false, "La calificacion debe ser un numero entre 0 y 10");
            else
                return (true, "");
        }

        private void FormValoracionesClientes_Load(object sender, EventArgs e)
        {

        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            (bool validacion, string mensaje) = validaciones();

            if (!validacion)
            {
                MessageBox.Show(mensaje);
                return;
            }
            MessageBox.Show(obj.id_detallepedido.ToString());
            obj.id_valoracion = 1;
            obj.calificacion_valoracion = int.Parse(textBox1.Text);
            obj.comentario = textBox2.Text;
            obj.fecha_comentario = DateTime.Now;
            obj.estado_comentario = true;

            if (obj.IngresarValoracion())
                MessageBox.Show("Valoracion Ingresada con exito");
            else
                MessageBox.Show("Ocurrio un error al intentar ingresar la valoracion");
        }
    }
}
