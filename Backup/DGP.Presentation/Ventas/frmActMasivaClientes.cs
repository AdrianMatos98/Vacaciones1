using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DGP.Entities.Ventas;
using DGP.BusinessLogic.Ventas;
using DGP.BusinessLogic;
using DGP.Util;
using DGP.Entities.Reportes;
using DGP.Entities.DataSet;
using DGP.Entities;

namespace DGP.Presentation.Ventas
{
    public partial class frmActMasivaClientes : Form
    {
        public frmActMasivaClientes()
        {
            InitializeComponent();
            cargarDatos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                BEProductoCliente pBEProductoCliente = new BEProductoCliente();
                pBEProductoCliente.IdProducto = (int)this.cmbProductos.SelectedValue;
                pBEProductoCliente.Margen = this.nudMargen.Value;
                pBEProductoCliente.PrecioCompra = this.nudPrecio.Value;
                bool flagAplicaTodos = this.chkMasivo.Checked;
                int total = new BLProductoCliente().cambioPrecioMasivo(pBEProductoCliente, flagAplicaTodos);
                MessageBox.Show("Se modificarón: " + total.ToString(), "", MessageBoxButtons.OK);

                this.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "DGP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
            }
        }

        public bool cargarDatos()
        {

            // bEProductoBindingSource.DataSource = ;
            //bEProductoBindingSource.DataMember = "IdProducto";
            //(new BLProducto()).Listar(new DGP.Entities.BEProducto())


            this.cmbProductos.DataSource = (new BLProducto()).Listar(new DGP.Entities.BEProducto());
            this.cmbProductos.DisplayMember = "Nombre";
            this.cmbProductos.ValueMember = "IdProducto";
            this.cmbProductos.Refresh();
           
            return true;



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DGP.Entities.BEProducto oProducto = (DGP.Entities.BEProducto)this.cmbProductos.SelectedItem;
            nudPrecio.Value = oProducto.PrecioCompra;
            nudMargen.Value = oProducto.Margen;





        }
    }
}