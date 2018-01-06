using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DGP.Entities;
using DGP.Entities.Ventas;
using DGP.BusinessLogic.Ventas;
using DGP.BusinessLogic;
using DGP.Util;
using DGP.Entities.Reportes;
using DGP.Entities.DataSet;

namespace DGP.Presentation.Reportes
{
    public partial class frmReporteEstadoCuentaCliente : Form
    {
        public frmReporteEstadoCuentaCliente()
        {
            InitializeComponent();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                //lbClientes.Items.to

                DSRptClientes oDSRptClientes = new BLVenta().ReporteEstadoCuentaCliente(dtpFechaInicial.Value.Date, getClientesList( this.lbClientes));
                //this.MostrarMensaje(getClientesList(this.lbClientes), MessageBoxIcon.Information);

                DGP.Entities.Reportes.CRptEstadoCuentaCliente oCRptEstadoCuentaCliente = new DGP.Entities.Reportes.CRptEstadoCuentaCliente();
                oCRptEstadoCuentaCliente.Refresh();
                oCRptEstadoCuentaCliente.SetDataSource(oDSRptClientes);
                this.CRptEstadoCuentaCliente.ReportSource = oCRptEstadoCuentaCliente;
                this.CRptEstadoCuentaCliente.Refresh();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        private string getClientesList(ListBox plbClientes) {
           
            string resultado = string.Empty;
            foreach (BEClienteProveedor item in plbClientes.Items)
            {
                resultado += "," + item.IdCliente;
            }
            
            return (resultado.Length> 0)? resultado.Substring(1): resultado;
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
         private void MostrarMensaje(string pMensaje, MessageBoxIcon pMsgBoxicon) {
                MessageBox.Show(pMensaje, "DGP", MessageBoxButtons.OK, pMsgBoxicon);
            }

         
         private void cmbClientes_Leave(object sender, EventArgs e)
         {
             if (this.cmbClientes.SelectedIndex >= 0)
             {
                 BEClienteProveedor oBEClienteProveedor= (BEClienteProveedor)this.cmbClientes.SelectedItem;
                 this.lbClientes.Items.Add(oBEClienteProveedor);
                 //MostrarMensaje(oBEClienteProveedor.IdCliente.ToString() + oBEClienteProveedor.Nombre, MessageBoxIcon.Information);
                
             }
         }

         private void btnEliminarClienteLista_Click(object sender, EventArgs e)
         {
             if (this.lbClientes.SelectedIndex>=0) this.lbClientes.Items.RemoveAt(this.lbClientes.SelectedIndex);
         }

         private void frmReporteEstadoCuentaCliente_Load(object sender, EventArgs e)
         {
             this.dtpFechaInicial.Value = DateTime.Now.AddDays(-7);
         }

    }
}
