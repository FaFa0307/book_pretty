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
    public partial class FormListaPedidos : Form
    {

        public FormListaPedidos()
        {
            InitializeComponent();
            CargarListas();
            CargarTablaPedidos();
            CargarTablaReembolsos();
            CargarTablaDevoluciones();
        }

        //ESTE SERA EL CARGAR LISTAS PARA TDOS
        void CargarListas()
        {
            LlenarEstadoPedidoAdmin();
            LlenarEstadoReembolsosAdmin();
            LlenarEstadoDevolucionesAdmin();


        }

        //-----------------------------------------CRUD PEDIDOS ADMIN---------------------------

        controladorpedidosadmin objcon = new controladorpedidosadmin();
        //Cargar combobux ESTADO PEDIDO CRUD
        void LlenarEstadoPedidoAdmin() {
            cmbestadopedidoadmin.DataSource = controladorpedidosadminsdatos.CargarEstadoPedidosAdmin();
            cmbestadopedidoadmin.DisplayMember = "estado";
            cmbestadopedidoadmin.ValueMember = "id_estadopedido";
        }

        //Cargar Tabla PEDIDOS CRUD
        private void CargarTablaPedidos()
        {
           controladorpedidosadmin objpedidosadmin = new controladorpedidosadmin();
            dgvpedidoadmin.DataSource = objpedidosadmin.LeerPedidosAdmin();

        }

        //Limpiar PEDIDOS CRUD
        void LimpiarCamposPedidosAdmins() {
            txtidpedidoadmin.Text = string.Empty;
            cmbestadopedidoadmin.SelectedIndex = -1;
            dtpfechaentregapedidoadmin.Value = DateTime.Now;
        }

        //Actualizar PEDIDOS CRUD
        void actualizarDatosPedidosAdmin()
        {


            controladorpedidosadmin objpedidosadminactualizar = new controladorpedidosadmin();
            objpedidosadminactualizar.fecha_entrega = dtpfechaentregapedidoadmin.Value;
            objpedidosadminactualizar.id_estadopedido = Convert.ToInt16(cmbestadopedidoadmin.SelectedValue);
            controladorpedidosadmin.id_pedidos = Convert.ToInt16(txtidpedidoadmin.Text);


            

            try
            {
              
                int respuestaestadopedido = objpedidosadminactualizar.actualizarPedidosAdminDatos(fechaOriginal);
                if (respuestaestadopedido >= 1)
                {
                    MessageBox.Show("Pedido actualizado con éxito.");
                    LimpiarCamposPedidosAdmins();
                    CargarTablaPedidos();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar Pedido: " + ex.Message);
            }
        }


        //No hacer caso
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        //-----------------------------------------CRUD REEMBOLSOS ADMIN---------------------------
        controladoreembolsosadmin objconr = new controladoreembolsosadmin();
        //Cargar combobux ESTADO REEMBOLSO CRUD
        void LlenarEstadoReembolsosAdmin()
        {
            cmbestadoreembolso.DataSource = controladoreembolsosadmindatos.CargarReembolsosAdmin();
            cmbestadoreembolso.DisplayMember = "estadoreembolso";
            cmbestadoreembolso.ValueMember = "id_estado_reembolso";
        }
        //Cargar tabla REEMBOLSOS
        private void CargarTablaReembolsos()
        {
            controladoreembolsosadmin objreembolsosadmin = new controladoreembolsosadmin();
            dgvreembolsosadmin.DataSource = objreembolsosadmin.LeerReembolsosAdmin();

        }
        //Limpiar Campos REEMBOLSOS
        void LimpiarCamposReembolsosAdmins()
        {
            txtidreemboloso.Text = string.Empty;
            cmbestadoreembolso.SelectedIndex = -1;
            dtpreembolsos.Value = DateTime.Now;
        }

        //Actualizar REEMBOLSOS CRUD

        void actualizarDatosReembolsosAdmin()
        {


            controladoreembolsosadmin objreembolsosadminactualizar = new controladoreembolsosadmin();
            objreembolsosadminactualizar.fecha_reembolso = dtpreembolsos.Value;
            objreembolsosadminactualizar.id_estado_reembolso = Convert.ToInt16(cmbestadoreembolso.SelectedValue);
            controladoreembolsosadmin.id_reembolso = Convert.ToInt16(txtidreemboloso.Text);

            try
            {

                int respuestaestadoreembolsos = objreembolsosadminactualizar.actualizarReembolsosAdminDatos(fechaOriginalrem);
                if (respuestaestadoreembolsos >= 1)
                {
                    MessageBox.Show("Reembolso actualizado con éxito.");
                    LimpiarCamposReembolsosAdmins();
                    CargarTablaReembolsos();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar Reembolso: " + ex.Message);
            }
        }


        //-----------------------------------------CRUD DEVOLUCIONES ADMIN---------------------------
        controladodevoadmin objcondev = new controladodevoadmin();
        // Llenar ComboBox de Estados de Devoluciones
        void LlenarEstadoDevolucionesAdmin()
        {
            cmbdevo.DataSource = controladordevoadmindatos.CargarEstadoDevolucionesAdmin();
            cmbdevo.DisplayMember = "estadodevolucion"; // Asumiendo que la columna se llama 'estadodevolucion'
            cmbdevo.ValueMember = "id_estadodevolucion"; // Asumiendo que la columna se llama 'id_estadodevolucion'
        }

        // Cargar tabla de Devoluciones
        private void CargarTablaDevoluciones()
        {
            controladodevoadmin objDevolucionesAdmin = new controladodevoadmin();
            dgvdevolucion.DataSource = objDevolucionesAdmin.LeerDevolucionesAdmin();
        }

        // Limpiar Campos de Devoluciones
        void LimpiarCamposDevolucionesAdmin()
        {
            txtiddevolucion.Text = string.Empty;
            cmbdevo.SelectedIndex = -1;
            dtfechadevo.Value = DateTime.Now;
        }

        // Actualizar Devoluciones CRUD
        void ActualizarDatosDevolucionesAdmin()
        {
            controladodevoadmin objDevolucionesAdminActualizar = new controladodevoadmin();
            objDevolucionesAdminActualizar.fecha_devolucion = dtfechadevo.Value;
            objDevolucionesAdminActualizar.id_estadodevolucion = Convert.ToInt32(cmbdevo.SelectedValue);
            controladodevoadmin.id_devolucion = Convert.ToInt32(txtiddevolucion.Text);

            try
            {
                int respuestaEstadoDevoluciones = objDevolucionesAdminActualizar.ActualizarDevolucionesAdminDatos(fechaOriginalDev);
                if (respuestaEstadoDevoluciones >= 1)
                {
                    MessageBox.Show("Devolución actualizada con éxito.");
                    LimpiarCamposDevolucionesAdmin();
                    CargarTablaDevoluciones();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la devolución: " + ex.Message);
            }
        }


        //ESTE LO COMPARTEN CRUDS

        private void FormListaPedidos_Load(object sender, EventArgs e)
        {
            // CRUD PEDIDOS
            dtpfechaentregapedidoadmin.Format = DateTimePickerFormat.Custom;
            dtpfechaentregapedidoadmin.CustomFormat = "yyyy-MM-dd";

            // Verificar y crear la columna de CheckBox si no existe
            if (!dgvpedidoadmin.Columns.Contains("Seleccionar"))
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "", // Título de la columna
                    Width = 30, // Establecer un ancho específico
                    Name = "SeleccionarPedido" // Nombre de la columna para poder referenciarla más tarde
                };
                dgvpedidoadmin.Columns.Insert(0, checkColumn); // Insertar en la posición 0
            }

            // CRUD REEMBOLSOS
            dtpreembolsos.Format = DateTimePickerFormat.Custom;
            dtpreembolsos.CustomFormat = "yyyy-MM-dd"; // Formato personalizado para el DateTimePicker de reembolsos

            // Verificar y crear la columna de CheckBox para reembolsos si no existe
            if (!dgvreembolsosadmin.Columns.Contains("Seleccionar"))
            {
                DataGridViewCheckBoxColumn checkColumnReembolsos = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "", // Título de la columna
                    Width = 30, // Ancho específico para la columna
                    Name = "SeleccionarReembolso" // Nombre de la columna, por si necesitas referenciarla más tarde
                };
                dgvreembolsosadmin.Columns.Insert(0, checkColumnReembolsos); // Insertar la columna en la posición 0
            }


            //.........
            // CRUD DEVO
            dtfechadevo.Format = DateTimePickerFormat.Custom;
            dtfechadevo.CustomFormat = "yyyy-MM-dd";

            // Verificar y crear la columna de CheckBox si no existe
            if (!dgvdevolucion.Columns.Contains("Seleccionar"))
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "", // Título de la columna
                    Width = 30, // Establecer un ancho específico
                    Name = "SeleccionarPedido" // Nombre de la columna para poder referenciarla más tarde
                };
                dgvdevolucion.Columns.Insert(0, checkColumn); // Insertar en la posición 0
            }


        }



        // DGV CRUD PEDIDOS ADMIN
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lógica similar para el dgvpedidoadmin
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Asegúrate de que es la columna del CheckBox
            {
                DataGridViewRow filaSeleccionadaP = dgvpedidoadmin.Rows[e.RowIndex];

                // Cambiar el estado del CheckBox
                bool isChecked = Convert.ToBoolean(filaSeleccionadaP.Cells[0].Value);
                filaSeleccionadaP.Cells[0].Value = !isChecked; // Alternar el estado
                dgvpedidoadmin.InvalidateRow(e.RowIndex); // Redibuja la fila para mostrar el cambio
            }
        }

        public static DateTime fechaOriginal;

        private void dgvpedidoadmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int posicionPedido = e.RowIndex; // Usamos e.RowIndex directamente
                DataGridViewRow filaSeleccionada = dgvpedidoadmin.Rows[posicionPedido];

                // Asigna el ID del pedido a su control correspondiente
                txtidpedidoadmin.Text = filaSeleccionada.Cells[1].Value.ToString(); // Asegúrate de que el índice sea correcto

                // Llenar el DateTimePicker con la fecha de entrega
                DateTime fechaEntrega;
                if (DateTime.TryParse(filaSeleccionada.Cells[5].Value?.ToString(), out fechaEntrega))
                {
                    dtpfechaentregapedidoadmin.Value = fechaEntrega; // Asigna la fecha si es válida
                    fechaOriginal = fechaEntrega;
                }
                else
                {
                    dtpfechaentregapedidoadmin.Value = DateTime.Now; // Si no hay fecha, asigna la fecha actual
                }

                // Llenar el ComboBox con el estado del pedido

                int idEstadoPedido = Convert.ToInt32(filaSeleccionada.Cells[6].Value);

                // Limpiar los datos anteriores del ComboBox
                cmbestadopedidoadmin.DataSource = null; // Limpiar los datos anteriores
                cmbestadopedidoadmin.Items.Clear(); // Eliminar los ítems existentes

                // Cargar todos los estados en el ComboBox
                cmbestadopedidoadmin.DataSource = objcon.CargarEstadoPedidoInnerJoin_Controller(); // Llamar al método que carga todos los estados
                cmbestadopedidoadmin.DisplayMember = "estado"; // El nombre del campo que se mostrará
                cmbestadopedidoadmin.ValueMember = "id_estadopedido"; // El valor que corresponde a cada estado

                // Seleccionar el estado actual del pedido en el ComboBox
                cmbestadopedidoadmin.SelectedValue = idEstadoPedido;

                // Marca el checkbox de la fila seleccionada
                foreach (DataGridViewRow row in dgvpedidoadmin.Rows)
                {
                    row.Cells[0].Value = (row.Index == posicionPedido); // Marca solo la fila seleccionada
                }
            }
      
        }

        //ACTUALIZAR PEDIDOS CRUD BOTON
        private void btnactualizarpedidoadmin_Click(object sender, EventArgs e)
        {
            actualizarDatosPedidosAdmin();
        }

        //ACTUALIZAR REEMBOLSOS CRUD BOTON
        private void btnactualizareeembolso_Click(object sender, EventArgs e)
        {
            actualizarDatosReembolsosAdmin();
        }
        public static DateTime fechaOriginalrem;
        private void dgvreembolsosadmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int posicionReembolso = e.RowIndex; // Usamos e.RowIndex directamente
                DataGridViewRow filaSeleccionadaR = dgvreembolsosadmin.Rows[posicionReembolso];

                // Asigna el ID del pedido a su control correspondiente
                txtidreemboloso.Text = filaSeleccionadaR.Cells[1].Value.ToString(); // Asegúrate de que el índice sea correcto

                // Llenar el DateTimePicker con la fecha de entrega
                DateTime fechaEntregaReembolso;
                if (DateTime.TryParse(filaSeleccionadaR.Cells[3].Value?.ToString(), out fechaEntregaReembolso))
                {
                    dtpreembolsos.Value = fechaEntregaReembolso; // Asigna la fecha si es válida
                    fechaOriginalrem = fechaEntregaReembolso;
                }
                else
                {
                    dtpreembolsos.Value = DateTime.Now; // Si no hay fecha, asigna la fecha actual
                }

                // Llenar el ComboBox con el estado del pedido

                int idEstadoReembolsos = Convert.ToInt32(filaSeleccionadaR.Cells[6].Value);

                // Limpiar los datos anteriores del ComboBox
                cmbestadoreembolso.DataSource = null; // Limpiar los datos anteriores
                cmbestadoreembolso.Items.Clear(); // Eliminar los ítems existentes

                // Cargar todos los estados en el ComboBox
                cmbestadoreembolso.DataSource = objconr.CargarEstadoReembolsosInnerJoin_Controller(); // Llamar al método que carga todos los estados
                cmbestadoreembolso.DisplayMember = "estadoreembolso"; // El nombre del campo que se mostrará
                cmbestadoreembolso.ValueMember = "id_estado_reembolso"; // El valor que corresponde a cada estado

                // Seleccionar el estado actual del pedido en el ComboBox
                cmbestadoreembolso.SelectedValue = idEstadoReembolsos;

                // Marca el checkbox de la fila seleccionada
                foreach (DataGridViewRow row in dgvpedidoadmin.Rows)
                {
                    row.Cells[0].Value = (row.Index == posicionReembolso); // Marca solo la fila seleccionada
                }
            }


        }

        private void dgvreembolsosadmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si el clic fue en la columna de CheckBox
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Asegúrate de que es la columna del CheckBox
            {
                DataGridViewRow filaSeleccionadaR = dgvreembolsosadmin.Rows[e.RowIndex];

                // Cambiar el estado del CheckBox
                bool isChecked = Convert.ToBoolean(filaSeleccionadaR.Cells[0].Value);
                filaSeleccionadaR.Cells[0].Value = !isChecked; // Alternar el estado
                dgvreembolsosadmin.InvalidateRow(e.RowIndex); // Redibuja la fila para mostrar el cambio
            }
        
        }

        public static DateTime fechaOriginalDev;
        private void dgvdevolucion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que la fila seleccionada sea válida
            {
                int posicionDevolucion = e.RowIndex; // Usamos e.RowIndex directamente
                DataGridViewRow filaSeleccionada = dgvdevolucion.Rows[posicionDevolucion];

                // Asigna el ID de la devolución a su control correspondiente
                txtiddevolucion.Text = filaSeleccionada.Cells[1].Value.ToString(); // Asegúrate de que el índice sea correcto

                // Llenar el DateTimePicker con la fecha de devolución
                DateTime fechaDevolucion;
                if (DateTime.TryParse(filaSeleccionada.Cells[3].Value?.ToString(), out fechaDevolucion))
                {
                    dtfechadevo.Value = fechaDevolucion; // Asigna la fecha si es válida
                    fechaOriginalDev = fechaDevolucion;
                }
                else
                {
                    dtfechadevo.Value = DateTime.Now; // Si no hay fecha, asigna la fecha actual
                }

                // Llenar el ComboBox con el estado de la devolución
                int idEstadoDevolucion = Convert.ToInt32(filaSeleccionada.Cells[5].Value);

                // Limpiar los datos anteriores del ComboBox
                cmbdevo.DataSource = null; // Limpiar los datos anteriores
                cmbdevo.Items.Clear(); // Eliminar los ítems existentes

                // Cargar todos los estados en el ComboBox
                cmbdevo.DataSource = objcondev.CargarEstadoDevolucionInnerJoin_Controller(); // Llamar al método que carga todos los estados
                cmbdevo.DisplayMember = "estadodevolucion"; // El nombre del campo que se mostrará
                cmbdevo.ValueMember = "id_estadodevolucion"; // El valor que corresponde a cada estado

                // Seleccionar el estado actual de la devolución en el ComboBox
                cmbdevo.SelectedValue = idEstadoDevolucion;

                // Marca el checkbox de la fila seleccionada (si existe una columna de CheckBox)
                foreach (DataGridViewRow row in dgvdevolucion.Rows)
                {
                    row.Cells[0].Value = (row.Index == posicionDevolucion); // Marca solo la fila seleccionada
                }
            }
        }

        private void dgvdevolucion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si el clic fue en la columna de CheckBox
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Asegúrate de que es la columna del CheckBox
            {
                DataGridViewRow filaSeleccionada = dgvdevolucion.Rows[e.RowIndex];

                // Cambiar el estado del CheckBox
                bool isChecked = Convert.ToBoolean(filaSeleccionada.Cells[0].Value);
                filaSeleccionada.Cells[0].Value = !isChecked; // Alternar el estado
                dgvdevolucion.InvalidateRow(e.RowIndex); // Redibuja la fila para mostrar el cambio
            }

        }

        private void btnactualizardevolucion_Click(object sender, EventArgs e)
        {
            ActualizarDatosDevolucionesAdmin();
        }
    }
}
