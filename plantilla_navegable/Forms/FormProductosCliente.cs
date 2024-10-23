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
    public partial class FormProductosCliente : Form
    {

        private Form2 mainForm;
        // Constructor que recibe el formulario principal (Form1)
        public FormProductosCliente(Form2 formPrincipal)
        {
            InitializeComponent();
            this.mainForm = formPrincipal; // Guardamos la referencia del formulario principal

        }
        public FormProductosCliente()
        {
            InitializeComponent();
        }
    }
}
