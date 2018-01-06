using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

namespace DGP.Presentation.Reportes
{
    public partial class frmReporteViewer : Form
    {
        private ReportClass _oReportClass;

        public ReportClass Reporte
        {
            get { return _oReportClass; }
            set { _oReportClass = value;

            //_oReportClass.Refresh();
            //_oReportClass.SetDataSource(oDSRptTablero);

            crViewer.ReportSource = _oReportClass;
            crViewer.RefreshReport();
            
            
            }
        }
	
        public frmReporteViewer(ReportClass oReportClass)
        {
            InitializeComponent();
            this.Reporte = oReportClass;
        }
    }
}