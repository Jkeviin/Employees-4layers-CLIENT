using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibConexionBD;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using LibLlenarGrid;

namespace Lib_LN_cliente
{
    public class Cliente
    {
        #region Atributos

        private int cedula;
        private string nombre;
        private string apellido;
        private string correo;
        private string telefono;
        private double pago;
        private string error;
        SqlDataReader reader;

        #endregion

        #region propiedades 
        public int Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public double Pago { get => pago; set => pago = value; }
        public string Error { get => error; set => error = value; }
        public SqlDataReader Reader { get => reader; set => reader = value; }
        #endregion

        #region metodos publicos
        public Cliente()
        {
            cedula = 0;
            nombre = "";
            apellido = "";
            Correo = "";
            telefono = "";
            error = "";
            pago = 0;
        }
        public bool guardar_cliente()
        {
            ClsConexion objConexion = new ClsConexion();
            String sentencia = $"execute USP_insertar {cedula},'{nombre}','{apellido}','{correo}','{telefono}',{pago}";
            if (!objConexion.EjecutarSentencia(sentencia,false))
            {
                error = objConexion.Error;
                objConexion = null;
                return false;
            }
            else
            {
                error = "Cliente guardado exitosamente";
                objConexion = null;
                return true;
            }  
        }
        public  bool actualizar_cliente()
        {
            ClsConexion objConexion = new ClsConexion();
            string sentencia = $"execute USP_actualizar {cedula} ,'{nombre}','{apellido}','{correo}','{telefono}',{pago}";
            if (!objConexion.EjecutarSentencia(sentencia, false))
            {
                error = objConexion.Error;
                objConexion = null;
                return false;
            }
            error = "Cliente actualizado exitosamente";
            objConexion = null;
            return true;
        }
        public bool eliminar_cliente()
        {
            ClsConexion objConexion = new ClsConexion();
            string sentencia = $"execute USP_eliminar {cedula} ";
            if (!objConexion.EjecutarSentencia(sentencia, false))
            {
                error = objConexion.Error;
                objConexion = null;
                return false;
            }
            error = "Cliente eliminado exitosamente";
            objConexion = null;
            return true;
        }

        public bool consultar_cliente()
        {
            ClsConexion objConexion = new ClsConexion();
            string sentencia = $"execute USP_consutar {cedula}";
            if (!objConexion.Consultar(sentencia,false))
            {
                error = objConexion.Error;
                objConexion = null;
                return false;

            }
            reader = objConexion.Reader;
            error = "cliente consultado";
            objConexion = null;
            return true;
           
        }
        public bool llenar_grid(DataGridView objDVG)
        {

            ClsLlenarGrid objGrid = new ClsLlenarGrid();

            objGrid.SQL   = $"execute USP_listar";
            objGrid.NombreTabla = "Clientes";
            if (!objGrid.LlenarGrid(objDVG))
            {
                error = objGrid.Error;
                objGrid = null;
                return false;
            }
            objGrid = null;
            return true;

        }
        #endregion
    }
}
