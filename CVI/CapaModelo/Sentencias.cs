using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CapaModelo
{
   public class Sentencias
    {
        Conexion cn = new Conexion();
        OdbcCommand Comm;
        private DataTable tabla;
        //funcion para realizar consultas al a DB
        public OdbcDataReader funcConsulta(string Consulta)
        {
            try
            {
                Comm = new OdbcCommand(Consulta, cn.conexion());
                OdbcDataReader reader = Comm.ExecuteReader();
                return reader;
            }
            catch (Exception Error)
            {
                Console.WriteLine("Error en modelo " + Error);
                return null;
            }

        }
        //Funcion obtener datos combobox
        public DataTable funcObtenerCamposCombobox(string Comando)
        {
            try
            {
                OdbcDataAdapter datos = new OdbcDataAdapter(Comando, cn.conexion());
                tabla = new DataTable();
                datos.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //funcion para insertar en la BD
        public OdbcDataReader funcInsertar(String Consulta)
        {
            try
            {
                Comm = new OdbcCommand(Consulta, cn.conexion());
                OdbcDataReader mostrar = Comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine("Ocurrio un error al registrar modelo" + err);
                return null;
            }
        }
        //funcion para la modificacion en la DB
        public OdbcDataReader funcModificar(string Consulta)
        {
            try
            {
                Comm = new OdbcCommand(Consulta, cn.conexion());
                OdbcDataReader mostrar = Comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception Error)
            {
                Console.WriteLine("Error en modelo-modificar ", Error);
                return null;
            }
        }



        //Consulta para buscar un recluta por el Id
        public OdbcDataReader funcBuscarFactura(string NumOrden)
        {
            try
            {
                //sentencia para realizar la busqueda obteniendo los nombres de las diferentes entidades e igualando los ID de las diferentes tablas
                string sentencia = "SELECT ce.pkNoDocumentoEnca, prov.direccionProv, concat(empl.nombreEmpleado,' ',empl.apellidoEmpleado) AS DATOE, emp.nombreEmpresa, suc.nombreSucursal, bod.descripcionBodega,ce.fechaCompra, ce.totalCompra, tc.nombretipocompra, mp.descripcionMetodo FROM compraencabezado as ce, empleado as empl, empresa as emp, proveedor as prov, sucursal as suc, bodega as bod, tipocompra as tc, metodopago as mp WHERE ce.fkIdProv = prov.pkIdProv AND ce.fkIdEmpleado = pkIdEmpleado  AND ce.fkIdEmpresa = emp.pkIdEmpresa AND ce.fkIdSucursal = suc.pkIdSucursal AND ce.fkIdBodegadestino = bod.pkIdBodega AND ce.fktipocompra = tc.pktipocompra AND ce.fkmetodoPago = mp.pkIdMetodoPago AND ce.pkNoDocumentoEnca = '" + NumOrden + "';";


                OdbcCommand Query_BusquedaReclu = new OdbcCommand(sentencia, cn.conexion());
                OdbcDataReader Lector = Query_BusquedaReclu.ExecuteReader();
                return Lector;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar SQL: " +
                    System.Environment.NewLine + System.Environment.NewLine +
                    ex.GetType().ToString() + System.Environment.NewLine +
                    ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

     

        //consulta para mostrar datos de la entidad empleado
        public OdbcDataAdapter funcBuscarOrdenes(int EstadoOrden)
        {
            try
            {
                //sentencia para realizar la busqueda obteniendo los nombres de las diferentes entidades e igualando los ID de las diferentes tablas
                string sentencia = "SELECT ce.pkNoDocumentoEnca, prov.direccionProv, concat(empl.nombreEmpleado,' ',empl.apellidoEmpleado) AS DATOE, emp.nombreEmpresa, suc.nombreSucursal, bod.descripcionBodega,ce.fechaCompra, ce.totalCompra, tc.nombretipocompra, mp.descripcionMetodo FROM compraencabezado as ce, empleado as empl, empresa as emp, proveedor as prov, sucursal as suc, bodega as bod, tipocompra as tc, metodopago as mp WHERE ce.fkIdProv = prov.pkIdProv AND ce.fkIdEmpleado = pkIdEmpleado  AND ce.fkIdEmpresa = emp.pkIdEmpresa AND ce.fkIdSucursal = suc.pkIdSucursal AND ce.fkIdBodegadestino = bod.pkIdBodega AND ce.fktipocompra = tc.pktipocompra AND ce.fkmetodoPago = mp.pkIdMetodoPago AND ce.estadoCompra = '" + EstadoOrden + "';";

                OdbcDataAdapter dataTable = new OdbcDataAdapter(sentencia, cn.conexion());

                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar SQL: " +
                    System.Environment.NewLine + System.Environment.NewLine +
                    ex.GetType().ToString() + System.Environment.NewLine +
                    ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //Consulta para ingresar una Entrevista
        public void funcInsertarFactura(string NumOrden, string Proveedor, string Empleado, string Empresa, string Sucursal, string Bodega, string FechaComp, string Total, string TipoC, string Metodo, string FechaFact,int Estado)
        {
            try
            {

                int IdFactura;
                string CorrelativoReclu = "SELECT IFNULL(MAX(pkIdFactura),0) +1 FROM FACTURA";
                OdbcCommand QueryIdReclu = new OdbcCommand(CorrelativoReclu, cn.conexion());
                IdFactura = Convert.ToInt32(QueryIdReclu.ExecuteScalar());
                OdbcDataReader Ejecucion1 = QueryIdReclu.ExecuteReader();


                //Sentencia para insertar datos a entidad Reclutamiento
                string SentenciaRecluta = "INSERT INTO FACTURA(pkIdFactura, fkNumOrden, NomProveedor, NomEmpleado, NomEmpresa, NomSucursal, NomBodega,FechaCompra,TotalCompra,TipoPago,Metodo,FechaFacturación,estado) VALUES " + "('" + IdFactura + "','" + NumOrden +"','" + Proveedor + "','" + Empleado + "','" + Empresa + "','" + Sucursal + "','" + Bodega + "','" + FechaComp + "','" + Total + "','" + TipoC + "','" + Metodo + "','" + FechaFact + "','" + Estado + "')";


              

                OdbcCommand Query_IngresoRec = new OdbcCommand(SentenciaRecluta, cn.conexion());
                Query_IngresoRec.ExecuteNonQuery();

                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar SQL: " +
                    System.Environment.NewLine + System.Environment.NewLine +
                    ex.GetType().ToString() + System.Environment.NewLine +
                    ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
