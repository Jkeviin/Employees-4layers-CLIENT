using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib_LN_cliente;
using System.Data.SqlClient;
namespace CP_cliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente objCliente = new Cliente();
            // declarar variables
            int cedula;
            string  nombre, apellido, correo, telefono;
            double pago;

            try{
                //capturar variables
                cedula = Convert.ToInt16(txtCedula.Text);
                nombre = txtNombre.Text;
                apellido = txtApellido.Text;
                correo = txtCorreo.Text;
                telefono = txtTelefono.Text;
                pago = Convert.ToDouble(txtPago.Text);

                //Enviar valores al LN

                objCliente.Cedula = cedula;
                objCliente.Nombre = nombre;
                objCliente.Apellido = apellido;
                objCliente.Correo = correo;
                objCliente.Telefono = telefono;
                objCliente.Pago = pago;

                if (!objCliente.guardar_cliente())
                {
                    MessageBox.Show(objCliente.Error);
                    objCliente = null;
                    return;
                }
                else
                {
                    MessageBox.Show(objCliente.Error);
                    objCliente = null;
                    llenarGRid();
                    return;
                }
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
                objCliente = null;
            }
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cliente objcliente = new Cliente();
            int cedula;
            SqlDataReader reader;

            try
            {

                cedula = Convert.ToInt16(txtBoE.Text);
                objcliente.Cedula = cedula;

                if (!objcliente.consultar_cliente())
                {
                    MessageBox.Show(objcliente.Error);
                    objcliente = null;
                    return;
                }
                    reader = objcliente.Reader;
                    
                    if (reader.HasRows)
                    {
                        reader.Read();
                        txtCedula.Text = Convert.ToString(reader.GetInt32(0));
                        txtNombre.Text = reader.GetString(1);
                        txtApellido.Text = reader.GetString(2);
                        txtCorreo.Text = reader.GetString(3);
                        txtTelefono.Text = reader.GetString(4);
                        txtPago.Text = Convert.ToString(reader.GetDouble(5));
                    reader.Close();          

                    }
                    MessageBox.Show(objcliente.Error);
                    objcliente = null;
                    return;
                


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                objcliente = null;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cliente objCliente = new Cliente();
            int cedula;
            double pago;
            string nombre,apellido, correo, telefono;
            try
            {

                cedula = Convert.ToInt16(txtCedula.Text);
                nombre = txtNombre.Text;
                apellido = txtApellido.Text;
                correo = txtCorreo.Text;
                telefono = txtCedula.Text;
                pago = Convert.ToDouble(txtPago.Text);

                objCliente.Cedula = cedula;
                objCliente.Nombre = nombre;
                objCliente.Apellido = apellido;
                objCliente.Correo = correo;
                objCliente.Telefono = telefono;
                objCliente.Pago = pago;

                if (!objCliente.actualizar_cliente())
                {
                    MessageBox.Show(objCliente.Error);
                    objCliente = null;
                    return;
                }
                MessageBox.Show(objCliente.Error);
                objCliente = null;
                llenarGRid();
                return;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                objCliente = null;
               
            }
             
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cliente objcliente = new Cliente();
            int cedula;
            try
            {


                cedula = Convert.ToInt16(txtBoE.Text);

                objcliente.Cedula = cedula;

                if (!objcliente.eliminar_cliente())
                {
                    MessageBox.Show(objcliente.Error);
                    objcliente = null;
                    return;
                }
                else
                {
                    MessageBox.Show(objcliente.Error);
                    objcliente = null;
                    llenarGRid();
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                objcliente = null;
                
            } 
        }
        private void llenarGRid()
        {
            Cliente objCliente = new Cliente();
            if (!objCliente.llenar_grid(dvCliente))
            {
                MessageBox.Show(objCliente.Error);
                objCliente = null;
                return;
            }
            objCliente = null;
            return;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            llenarGRid();
        }

    }
}
