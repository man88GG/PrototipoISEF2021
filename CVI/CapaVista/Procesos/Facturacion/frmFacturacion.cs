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
using System.Net;
using CapaVista.Procesos.Facturacion;

namespace CapaVista.Procesos.Facturacion
{
    public partial class frmIngresoFacturacion : Form
    {

        ControladorJM Cont_R = new ControladorJM();

        public frmIngresoFacturacion()
        {
            InitializeComponent();
  
        }

  

        string NumOrden, Proveedor, Empleado, Empresa, Sucursal, Bodega, FechaComp, Total, TipoC, Metodo, FechaFact;

        private void btnIngresoFact_Click(object sender, EventArgs e)
        {
            //Mensaje de Validación
            if (txtOrden.Text == "") { MessageBox.Show("ADVERTENCIA: El campo del Número de Orden no puede estar vacío.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else
            {



                //Mensaje de Pregunta
                if (MessageBox.Show("¿Desea agregar la Factura ?", "Facturacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes) { }
                else
                {

                    //Se da a las variables los valores correspondientes para enviarse a la capa Controlador
                    //datos Reclutamiento


                    Proveedor = txtNomProv.Text;

                    Empleado = txtNomEmpl.Text;
                    Empresa = txtNomEmp.Text;
                    Sucursal = txtNomSuc.Text;
                    Bodega = txtNomBod.Text;
                    FechaComp = dtpFechaC.Value.Date.ToShortDateString();
                    Total = txtTotal.Text;
                    TipoC = txtTipo.Text;
                    Metodo = txtMetodo.Text;
                    FechaFact = dtpFechaF.Value.Date.ToShortDateString();
                    Estado = 1;



                    //envío de datos hacia capa Controlador
                    Cont_R.funcInsertarFactura(NumOrden, Proveedor, Empleado, Empresa, Sucursal, Bodega, FechaComp, Total, TipoC, Metodo, FechaFact, Estado);
                    MessageBox.Show("Se ha ingresado la Entrevista con Éxito", "FORMULARIO ENTREVISTA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    funcLimpieza();
                    funcBloqueo();

                }//fin elseif Pregunta



            }
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            //Se llama al formulario que contiene todos una tabla de todos los empleados
            frmMostrarNumerosOrden MostrarOrden = new frmMostrarNumerosOrden();
            MostrarOrden.ShowDialog();
        }

        int Estado ;



        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            //Mensaje de Validación
            if (txtOrden.Text == "") { MessageBox.Show("ADVERTENCIA: El campo de busqueda no puede estar vacío.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else
            {
                //se desbloquean los componentes en los que se puede agregar/cambiar información
                NumOrden = txtOrden.Text;
                btnIngresoFact.Enabled = true;
                dtpFechaF.Enabled = true;

                //Inicio para Busqueda
                OdbcDataReader Lector = Cont_R.funcBuscarFactura(NumOrden);
                if (Lector.HasRows == true)
                {
                    while (Lector.Read())
                    {
                        //Se agrega el valor del lector a los textbox dependiendo la posicion 
                        //Tabla reclutamiento


                        txtNomProv.Text = Lector.GetString(1);
                        txtNomEmpl.Text = Lector.GetString(2);
                        txtNomEmp.Text = Lector.GetString(3);
                        txtNomSuc.Text = Lector.GetString(4);
                        txtNomBod.Text = Lector.GetString(5);
                        dtpFechaC.Text = Lector.GetString(6);
                        txtTotal.Text = Lector.GetString(7);
                        txtTipo.Text = Lector.GetString(8);
                        txtMetodo.Text = Lector.GetString(9);

                    }
                }
                else
                {
                    //Mensaje de error
                    MessageBox.Show("ERROR: El Numero de orden no se encuentra Registrado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    funcBloqueo();
                    funcLimpieza();
                    btnIngresoFact.Enabled = false;

                }

            }//fin ifelse
        }

        private void frmEntrevista_Load(object sender, EventArgs e)
        {
            
          
        }


 
        //Funcion de Limpieza
        private void funcLimpieza()
        {
           
            txtOrden.Text = "";
            txtNomProv.Text = "";
            txtNomEmpl.Text = ""; 
            txtNomEmp.Text = "";
            txtNomSuc.Text = "";
            txtNomBod.Text = "";
            dtpFechaC.Value = DateTime.Now;
            txtTotal.Text = "";
            txtTipo.Text = "";
            txtMetodo.Text = "";
            dtpFechaF.Value = DateTime.Now;



        }
        //Función de Bloqueo
        private void funcBloqueo()
        {
            
           
        }


    }

}
