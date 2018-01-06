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
    public partial class frmReporteResumenCobranza : Form
    {
        public frmReporteResumenCobranza()
        {
            InitializeComponent();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                //lbClientes.Items.to

                DSRptClientes oDSRptClientes = null;  //new BLVenta().ReporteEstadoCuentaCliente(this.dtpFechaInicial.Value.Date);
                
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
        
         private void MostrarMensaje(string pMensaje, MessageBoxIcon pMsgBoxicon) {
                MessageBox.Show(pMensaje, "DGP", MessageBoxButtons.OK, pMsgBoxicon);
            }
         private void frmReporteEstadoCuentaCliente_Load(object sender, EventArgs e)
         {
             this.dtpFechaInicial.Value = DateTime.Now.AddDays(-7);
         }

    }
}
