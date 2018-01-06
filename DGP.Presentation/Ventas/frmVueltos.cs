using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DGP.Entities;
using DGP.BusinessLogic.Ventas;
using DGP.Entities.DataSet;

using DGP.BusinessLogic;

namespace DGP.Presentation.Ventas
{
    public partial class frmVueltos : Form
    {
        public frmVueltos()
        {
            InitializeComponent();
        }

        private void frmVueltos_Load(object sender, EventArgs e)
        {

        }

        private void cmbClientes_Leave(object sender, EventArgs e)
        {
            try
            {
                RefrescarFormulario();

            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.ToString(), MessageBoxIcon.Error);
            }
        }
        private void RefrescarFormulario()
        {
            if (this.cmbClientes.SelectedIndex >= 0)
            {
                BEClienteProveedor oBEClienteProveedor = (BEClienteProveedor)this.cmbClientes.SelectedItem;
                this.CargarVueltos(oBEClienteProveedor);
            }
        
        
        }


        private void CmbClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cmbClientes_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                // Do nothing for certain keys, such as navigation keys.
                if (
                    (e.KeyCode == Keys.Escape) ||

                    (e.KeyCode == Keys.Left) ||
                    (e.KeyCode == Keys.Right) ||
                    (e.KeyCode == Keys.Up) ||
                    (e.KeyCode == Keys.Down) ||
                    (e.KeyCode == Keys.PageUp) ||
                    (e.KeyCode == Keys.PageDown) ||
                    (e.KeyCode == Keys.Home) ||
                    (e.KeyCode == Keys.End) ||

                    (e.KeyCode == Keys.Enter) ||

                    (e.KeyCode == Keys.Multiply) ||
                    (e.KeyCode == Keys.Divide) ||
                    (e.KeyCode == Keys.Subtract) ||
                    (e.KeyCode == Keys.Add) ||
                    (e.KeyCode == Keys.NumLock)
                    )
                {
                    e.Handled = true;
                    return;
                }
                string actual = cmbClientes.Text;
                //
                int intIdZona = 0;
                BEClienteProveedor oEntidad = new BEClienteProveedor();

                oEntidad.Nombre = actual;
                oEntidad.IdZona = intIdZona;
                oEntidad.IdCliente = 0;
                List<BEClienteProveedor> vTemp = new BLClienteProveedor().Listar(oEntidad);
                vTemp.Insert(0, new BEClienteProveedor(0, ""));
                if (vTemp != null && vTemp.Count > 0)
                {
                    cmbClientes.Text = string.Empty;
                    cmbClientes.DataSource = vTemp;
                    cmbClientes.DisplayMember = "Nombre";
                    cmbClientes.ValueMember = "IdCliente";
                    cmbClientes.DroppedDown = true;
                    cmbClientes.Refresh();
                    cmbClientes.Text = actual;
                    if (!string.IsNullOrEmpty(actual))
                    {
                        cmbClientes.Select(actual.Length, 0);
                    }
                    else
                    {
                        cmbClientes.SelectedIndex = -1;
                    }
                }
                else
                {
                    cmbClientes.DroppedDown = false;
                    cmbClientes.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message, MessageBoxIcon.Error);
            }
        }
        private void MostrarMensaje(string pMensaje, MessageBoxIcon pMsgBoxicon)
        {
            MessageBox.Show(pMensaje, "DGP", MessageBoxButtons.OK, pMsgBoxicon);
        }

        private void cmbClientes_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void CargarVueltos(BEClienteProveedor oBEClienteProveedor)
        {
            if (oBEClienteProveedor != null)
            {
                BLVueltos blVueltos = new BLVueltos();
                
                DSVueltos dsVueltos = blVueltos.ListarVueltos(oBEClienteProveedor);
                dgvVueltos.DataSource = dsVueltos.DTVuelto;
                dgvSaldos.DataSource = dsVueltos.DTSaldos;
                dgvVueltos.Refresh();
                dgvSaldos.Refresh();

            }
        }

        private void btnProcesarVuelto_Click(object sender, EventArgs e)
        {
            try
            {
                BLVueltos blVueltos = new BLVueltos();
                bool AplicarVuelto = this.rbtVuelto.Checked;

                List<int> idVentasVueltos = this.ObtenerVueltosSeleccionados();
                List<int> idVentasSaldos = this.ObtenerSaldosSeleccionados();

                blVueltos.AplicarVueltos(idVentasVueltos, idVentasSaldos, AplicarVuelto, VariablesSession.BEUsuarioSession.IdPersonal, VariablesSession.BECaja.IdCaja);
                RefrescarFormulario();
            }
            catch (Exception ex)
            {

                MostrarMensaje(ex.Message, MessageBoxIcon.Error);
            }
        }
        private List<int> ObtenerVueltosSeleccionados()
        {
            List<int> lista = new List<int>();
            this.dgvVueltos.EndEdit();

            DSVueltos.DTVueltoDataTable dtVuelto = (DSVueltos.DTVueltoDataTable)this.dgvVueltos.DataSource;

            foreach (DSVueltos.DTVueltoRow item in dtVuelto.Rows)
            {
                if (item.IsSelected)
                {
                    lista.Add(item.Id_Venta);
                
                }
               
                
            }
            return lista;
        }
        private List<int> ObtenerSaldosSeleccionados()
        {
            List<int> lista = new List<int>();
            this.dgvSaldos.EndEdit();
            DSVueltos.DTSaldosDataTable dtSaldos = (DSVueltos.DTSaldosDataTable)this.dgvSaldos.DataSource;

            foreach (DSVueltos.DTSaldosRow item in dtSaldos.Rows)
            {
                if (item.IsSelected)
                {
                    lista.Add(item.Id_Venta);

                }


            }
            return lista;
        }

        

    }
}
