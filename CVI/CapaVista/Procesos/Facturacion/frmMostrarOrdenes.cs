using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using CapaControlador;


namespace CapaVista.Procesos.Facturacion
{
    public partial class frmMostrarNumerosOrden : Form
    {
        public frmMostrarNumerosOrden()
        {
            InitializeComponent();
            funcMostrarTabla();
           
        }


        //estado de posible candidato
        int EstadoOrden = 1;
        
     
        ControladorJM Cont_R = new ControladorJM();
        public void funcMostrarTabla()
        {

            
            DataTable dt = Cont_R.funcBuscarOrdenes(EstadoOrden);
            dgvMostrarReclutas.DataSource = dt;
            funcNombresEncabezados();
            

        }

      
        //función para cambiarle el nombre a las columnas del datagrid al momento de mostrar todos los datos
        public void funcNombresEncabezados()
        {
            dgvMostrarReclutas.Columns[0].HeaderText = "No. Orden";
            dgvMostrarReclutas.Columns[1].HeaderText = "Nombre Proveedor";
            dgvMostrarReclutas.Columns[2].HeaderText = "Nombre Empleado";
            dgvMostrarReclutas.Columns[3].HeaderText = "Nombre Empresa";
            dgvMostrarReclutas.Columns[4].HeaderText = "Nombre Sucursal";
            dgvMostrarReclutas.Columns[5].HeaderText = "Nombre Bodega";
            dgvMostrarReclutas.Columns[6].HeaderText = "Fecha Compra";
            dgvMostrarReclutas.Columns[7].HeaderText = "Total";
            dgvMostrarReclutas.Columns[8].HeaderText = "Tipo Compra";
            dgvMostrarReclutas.Columns[9].HeaderText = "Metodo Pago";


        }
     

    
  
     
        //se coloca un máximo de dígitos para el textbox del id
        private void frmMostrarReclutas_Load(object sender, EventArgs e)
        {
            
            
        }

        private void btnIngresoFact_Click(object sender, EventArgs e)
        {
            funcMostrarTabla();
        }
    }
}
