using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;
using Microsoft.Data.SqlClient;
using plantilla_navegable.Forms;

namespace plantilla_navegable
{
    public partial class Form2 : Form
    {
         // Campo para saber si es administrador o cliente

        //filds
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        private bool esAdmin;

        public Form2()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        public Form2(bool esAdmin)
        {
            InitializeComponent();
            this.esAdmin = esAdmin;  // Asignar el valor booleano
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            // Lógica según el tipo de usuario (admin o cliente)
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            //objeto de cada vista

            if (esAdmin)
            {
                // Configurar para administrador
                MessageBox.Show("Bienvenido, administrador");
                // Aquí puedes habilitar botones o funcionalidades exclusivas para el administrador
            }
            else
            {
                // Configurar para cliente
                MessageBox.Show("Bienvenido, cliente");
                // Aquí puedes deshabilitar opciones que solo sean accesibles para el administrador
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //metedos 
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index) {
               index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;  
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }

        }

        private void DisableButton()
        {
            foreach (Control previusBtn in panelMenu.Controls)
            {
                if (previusBtn.GetType() == typeof(Button))
                {
                    previusBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previusBtn.ForeColor = Color.Gainsboro;
                    previusBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }

            }
        }
        public void OpenChildForm(Form childForm, object btnSender)
        {
            //if (activeForm != null)
            //    activeForm.Close();
            //ActivateButton(btnSender);
            //activeForm = childForm;
            //childForm.TopLevel = false;
            //childForm.FormBorderStyle = FormBorderStyle.None;
            //childForm.Dock = DockStyle.Fill;
            //this.panelDesktopPanel.Controls.Add(childForm);
            //this.panelDesktopPanel.Tag = childForm;
            //childForm.BringToFront();
            //childForm.Show();
            //lblTitle.Text = childForm.Text;

            if (activeForm != null)
            {
                activeForm.Close(); // Cerrar el formulario hijo actual
            }

            // Establece el botón activo
            ActivateButton(btnSender);

            // Configura el nuevo formulario
            activeForm = childForm;
            childForm.TopLevel = false; // Permite agregarlo al panel
            childForm.FormBorderStyle = FormBorderStyle.None; // Sin bordes
            childForm.Dock = DockStyle.Fill; // Rellenar el panel
            this.panelDesktopPanel.Controls.Add(childForm); // Agregar al panel
            this.panelDesktopPanel.Tag = childForm; // Guardar referencia
            childForm.BringToFront(); // Llevar al frente
            childForm.Show(); // Mostrar el nuevo formulario
            lblTitle.Text = childForm.Text; // Actualizar el título

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            FormProductosCliente formProduct = new FormProductosCliente(this);
            OpenChildForm(formProduct, sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormEstados(), sender);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormPedidosClientes(), sender);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormTipos(), sender);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormUsuario(), sender);

        }

        private void button5_Click(object sender, EventArgs e)
        {

            // Preguntar al usuario si está seguro de cerrar sesión
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea cerrar sesión?",
                                                     "Confirmar Cierre de Sesión",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

            // Si el usuario confirma, proceder a cerrar sesión
            if (resultado == DialogResult.Yes)
            {
                

                // Abrir el formulario de inicio de sesión
                FormLogin formLogin = new FormLogin();
                formLogin.Show(); // Muestra el formulario de inicio de sesión

                // Ocultar el formulario actual
                this.Hide();
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void bntMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnconexion_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
               con = controladorconexion.ConectarModelo();
            if (con != null)
            {
                MessageBox.Show("Conexion establecida con exito", "Conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show("No se pudo establecer la conexion con exito", " Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
