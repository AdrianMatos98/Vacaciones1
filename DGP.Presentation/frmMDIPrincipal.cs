using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DGP.Presentation.Ventas;
using DGP.Presentation.Reportes;

namespace DGP.Presentation {

    public partial class frmMDIPrincipal : Form {

        private frmTableroElectronico oVentas_frmTablero = null;
        private frmMantenimientoVentas oVentas_frmDetalleVenta = null;
        private frmAmortizacion oVentas_frmAmortizacion = null;
        private frmPagoAdelanto oVentas_frmAdelanto = null;
        private frmDevoluciones oVentas_frmDevoluvion = null;
        private frmReporteCobranza oReportes_frmReporteCobranza = null;
        private frmReporteFiltrosTablero oReportes_frmReporteFiltros = null;
        private frmActMasivaClientes ofrmActMasivaClientes = null;
        private frmMantenimientoCliente ofrmMantenimientoCliente = null;
        private frmReporteFiltroPersonal oReportes_frmRptFiltroPersonal = null;
        private frmVueltos oVentas_frmVueltos = null;
        

        public frmMDIPrincipal() {
            InitializeComponent();
        }


        private void tstmiVentas_TableroElectronico_Click(object sender, EventArgs e) {
            oVentas_frmTablero = new frmTableroElectronico();
            oVentas_frmTablero.MdiParent = this;
            oVentas_frmTablero.Show();
        }

        private void tsmiDetalleVenta_Click(object sender, EventArgs e) {
            oVentas_frmDetalleVenta = new frmMantenimientoVentas();
            oVentas_frmDetalleVenta.MdiParent = this;
            oVentas_frmDetalleVenta.Show();
        }

        private void tsmiPagoAdelanto_Click(object sender, EventArgs e) {
            oVentas_frmAdelanto = new frmPagoAdelanto();
            oVentas_frmAdelanto.MdiParent = this;
            oVentas_frmAdelanto.Show();
        }

        private void tsmiPagoCuenta_Click(object sender, EventArgs e) {
            oVentas_frmAmortizacion = new frmAmortizacion();
            oVentas_frmAmortizacion.MdiParent = this;
            oVentas_frmAmortizacion.Show();
        }        
        
        private void tsmiDevoluciones_Click(object sender, EventArgs e) {
            oVentas_frmDevoluvion = new frmDevoluciones();
            oVentas_frmDevoluvion.MdiParent = this;
            oVentas_frmDevoluvion.Show();
        }

        private void tsmiReporteCobranza_Click(object sender, EventArgs e) {
            oReportes_frmReporteCobranza = new frmReporteCobranza();
            oReportes_frmReporteCobranza.MdiParent = this;
            oReportes_frmReporteCobranza.Show();
        }
        private void tsmiReporteFiltros_Click(object sender, EventArgs e)
        {
            oReportes_frmReporteFiltros = new frmReporteFiltrosTablero();
            oReportes_frmReporteFiltros.MdiParent = this;
            oReportes_frmReporteFiltros.Show();
        }

        private void actPrecioVentaMasivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmActMasivaClientes ofrmActMasivaClientes = new frmActMasivaClientes();
            ofrmActMasivaClientes.MdiParent = this;
            ofrmActMasivaClientes.Show();
        }

        private void mantenimientoDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofrmMantenimientoCliente = new frmMantenimientoCliente();
            ofrmMantenimientoCliente.MdiParent = this;
            ofrmMantenimientoCliente.Show();
        }

        private void cuadreCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oReportes_frmRptFiltroPersonal = new frmReporteFiltroPersonal();
            oReportes_frmRptFiltroPersonal.MdiParent = this;
            oReportes_frmRptFiltroPersonal.Show();

        }

        private void hojaTableroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteFiltrosHojaTablero oReportes_frmRptFiltro = new frmReporteFiltrosHojaTablero();
            oReportes_frmRptFiltro.MdiParent = this;
            oReportes_frmRptFiltro.Show();
        }

        private void listaDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteFiltrosHojaPrecios oReportes_frmRptFiltro = new frmReporteFiltrosHojaPrecios();
            oReportes_frmRptFiltro.MdiParent = this;
            oReportes_frmRptFiltro.Show();
        }

        private void estadoDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteEstadoCuentaCliente oReportes_frmRptFiltro = new frmReporteEstadoCuentaCliente();
            oReportes_frmRptFiltro.MdiParent = this;
            oReportes_frmRptFiltro.Show();

        }

        private void mantenimientoDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Seguridad.frmMantenimientoUsuario ofrmMantenimientoUsuario = new DGP.Presentation.Seguridad.frmMantenimientoUsuario();
            ofrmMantenimientoUsuario.MdiParent = this;
            ofrmMantenimientoUsuario.Show();
        }

        private void frmMDIPrincipal_Load(object sender, EventArgs e)
        {
            HabilitarOpciones();

        }
        #region MethodsForMenu
        public void HabilitarOpciones()
        {
            List<ToolStripMenuItem> myItems = GetMenuItems(this.msMenuPrincipal);
            foreach (var item in myItems)
            {
             //   MessageBox.Show(item.Text);

                item.Enabled = VariablesSession.Privilegios.Exists(x => x.Descripcion == item.Text);
            }
        
        
        }
 
        /// <summary>
        /// Gets a list of all ToolStripMenuItems
        /// </summary>
        /// <param name="menuStrip">The menu strip control</param>
        /// <returns>List of all ToolStripMenuItems</returns>
        /// 
        public  List<ToolStripMenuItem> GetMenuItems(MenuStrip menuStrip)
        {
            List<ToolStripMenuItem> myItems = new List<ToolStripMenuItem>();
            foreach (ToolStripMenuItem i in menuStrip.Items)
            {
                GetMenuItems(i, myItems);
            }
            return myItems;
        }
 
        /// <summary>
        /// Gets the menu items.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="items">The items.</param>
        private  void GetMenuItems(ToolStripMenuItem item, List<ToolStripMenuItem> items)
        {
            items.Add(item);
            foreach (ToolStripItem i in item.DropDownItems)
            {
                if (i is ToolStripMenuItem)
                {
                    GetMenuItems((ToolStripMenuItem)i, items);
                }
            }
        }
 
        #endregion Methods

        private void aplicarVueltoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //oVentas_frmVueltos = new frmVueltos();
            //oVentas_frmVueltos.MdiParent = this;
            //oVentas_frmVueltos.Show();

        }

        private void mantenimientoDeDocPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoDocumentoPago frm = new frmMantenimientoDocumentoPago();
            frm.MdiParent = this;
            frm.Show();

        }

        private void msMenuPrincipal_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mantenimientoDeDocPagosCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}