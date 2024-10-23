using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;

namespace plantilla_navegable.Forms
{
    public partial class FormReembolsosCliente : Form
    {
        controladorreembolsocliente reembolso = new controladorreembolsocliente();

        void metodosReembolso()
        {
            comboBox1.DataSource = reembolso.ObtenerMetodosReembolso();
            comboBox1.DisplayMember = "descripcion";
            comboBox1.ValueMember = "id_metodoreembolso";
        }

        public FormReembolsosCliente(int id_devolucion)
        {
            InitializeComponent();
            reembolso.id_devolucion = id_devolucion;
        }



        private void FormReembolsosCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out double monto))
                return;

            reembolso.id_estado_reembolso = 1;
            reembolso.fecha_reembolso = DateTime.Now;
            reembolso.id_metodoreembolso = comboBox1.SelectedIndex + 1;
            reembolso.monto_reembolso = monto;
            reembolso.id_estado_reembolso = 1;

            if (reembolso.CrearReembolso())
                MessageBox.Show("Se ha enviado la solicitud de reembolso");
            else
                MessageBox.Show("Ha ocurrido un error al intentar crear el reembolso");

        }
    }
}
