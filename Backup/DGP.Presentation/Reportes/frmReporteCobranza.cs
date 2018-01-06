using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DGP.BusinessLogic.Ventas;
using DGP.Entities.DataSet;
using DGP.Entities.Reportes;
using DGP.Entities.Ventas;

namespace DGP.Presentation.Reportes {

    public partial class frmReporteCobranza : Form {
        public frmReporteCobranza() {
            InitializeComponent();
            CargarReporteCobranza();
        }

        private void frmReporteCobranza_Load(object sender, EventArgs e) {

        }

        private void CargarReporteCobranza() {
            DSHojaCobranza oDSHojaCobranza = new DSHojaCobranza();
            VistaVenta oEntidad = new VistaVenta();
            oEntidad.Fecha = DateTime.MinValue;
            oDSHojaCobranza = new BLVenta().ReporteCobranza(oEntidad);
            CRHojaCobranza oCRHojaCobranza = new CRHojaCobranza();
            oCRHojaCobranza.Refresh();
            oCRHojaCobranza.SetDataSource(oDSHojaCobranza);
            crvCobranza.ReportSource = oCRHojaCobranza;
            crvCobranza.RefreshReport();
        }

    }
}