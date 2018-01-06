using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DGP.Entities.Ventas;
using DGP.Entities;
using DGP.BusinessLogic.Ventas;

using DGP.BusinessLogic;

namespace DGP.Presentation.Ventas
{
    public partial class frmAplicarPreciosGrupo : Form
    {
        private frmMantenimientoVentas frmMantenimientoVentas { get; set; }
        public frmAplicarPreciosGrupo(frmMantenimientoVentas ofrmMantenimientoVentas)
        {
            InitializeComponent();
            this.frmMantenimientoVentas = ofrmMantenimientoVentas;
        }

        private void frmAplicarPreciosGrupo_Load(object sender, EventArgs e)
        {
            try
            {
                CargarListaProducto();
                CargarAplicarPrecios();


            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
        
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                BEProducto producto = (BEProducto)this.cbProducto.SelectedItem;
                if (producto == null) return;

                
                this.frmMantenimientoVentas.AplicarPreciosGrupo(producto, this.nudPrecioBase.Value, this.nubMargenMinimo.Value, (int)this.cbFormaAplicar.SelectedValue);

                this.Close();


            }
            catch (Exception ex)
            {
                
                this.MostrarMensaje(ex.Message , MessageBoxIcon.Error);
            }

        }
        private void MostrarMensaje(string pMensaje, MessageBoxIcon pMsgBoxicon)
        {
            MessageBox.Show(pMensaje, "DGP", MessageBoxButtons.OK, pMsgBoxicon);
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarProducto();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        private void CargarListaProducto()
        {
            List<BEProducto> vLista = new List<BEProducto>();
            vLista = new BLProducto().Listar(new BEProducto());
            cbProducto.DataSource = vLista;
            cbProducto.DisplayMember = "Nombre";
            cbProducto.ValueMember = "IdProducto";
            CargarProducto();
        }
        private void CargarAplicarPrecios()
        {
            Dictionary<string , int   > lista = new Dictionary<string , int >();
            lista.Add("Todos", 1);
            lista.Add("Precio Variable",2);
            //cbProducto.Items.Add(new System.Collections.DictionaryEntry("Todos", 1));
            //cbProducto.Items.Add(new System.Collections.DictionaryEntry("Precio Variable", 2));
            cbFormaAplicar.DataSource = new BindingSource(lista, null);
            cbFormaAplicar.DisplayMember = "Key";
            cbFormaAplicar.ValueMember = "Value";
            cbFormaAplicar.SelectedIndex = 1;
        }
        private void CargarProducto()
        {
            BEProducto producto = (BEProducto)this.cbProducto.SelectedItem;
            if (producto == null) return;

            this.nudPrecioBase.Value = producto.PrecioCompra;
            //this.nubMargenMinimo 

        }
    }
}
