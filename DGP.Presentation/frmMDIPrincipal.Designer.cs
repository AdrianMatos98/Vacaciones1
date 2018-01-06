namespace DGP.Presentation
{
    partial class frmMDIPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.msMenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.tsmVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.tstmiVentas_TableroElectronico = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDetalleVenta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAmortizacion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPagoAdelanto = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDevoluciones = new System.Windows.Forms.ToolStripMenuItem();
            this.actPrecioVentaMasivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoDeClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aplicarVueltoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoDeComprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReporteCobranza = new System.Windows.Forms.ToolStripMenuItem();
            this.tableroDeVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuadreCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hojaTableroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDePreciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadoDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSalirSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoDeDocPagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoDeDocPagosCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMenuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenuPrincipal
            // 
            this.msMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmVentas,
            this.comprasToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.tsmSalir});
            this.msMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.msMenuPrincipal.Name = "msMenuPrincipal";
            this.msMenuPrincipal.Size = new System.Drawing.Size(597, 24);
            this.msMenuPrincipal.TabIndex = 1;
            this.msMenuPrincipal.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.msMenuPrincipal_ItemClicked);
            // 
            // tsmVentas
            // 
            this.tsmVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstmiVentas_TableroElectronico,
            this.tsmiDetalleVenta,
            this.mantenimientoDeDocPagosToolStripMenuItem,
            this.tsmiAmortizacion,
            this.tsmiPagoAdelanto,
            this.tsmiDevoluciones,
            this.actPrecioVentaMasivoToolStripMenuItem,
            this.mantenimientoDeClienteToolStripMenuItem,
            this.mantenimientoDeUsuariosToolStripMenuItem,
            this.aplicarVueltoToolStripMenuItem});
            this.tsmVentas.Name = "tsmVentas";
            this.tsmVentas.Size = new System.Drawing.Size(53, 20);
            this.tsmVentas.Text = "Ventas";
            // 
            // tstmiVentas_TableroElectronico
            // 
            this.tstmiVentas_TableroElectronico.Name = "tstmiVentas_TableroElectronico";
            this.tstmiVentas_TableroElectronico.Size = new System.Drawing.Size(234, 22);
            this.tstmiVentas_TableroElectronico.Text = "Tablero Electronico";
            this.tstmiVentas_TableroElectronico.Click += new System.EventHandler(this.tstmiVentas_TableroElectronico_Click);
            // 
            // tsmiDetalleVenta
            // 
            this.tsmiDetalleVenta.Name = "tsmiDetalleVenta";
            this.tsmiDetalleVenta.Size = new System.Drawing.Size(234, 22);
            this.tsmiDetalleVenta.Text = "Mantenimiento de Venta";
            this.tsmiDetalleVenta.Click += new System.EventHandler(this.tsmiDetalleVenta_Click);
            // 
            // tsmiAmortizacion
            // 
            this.tsmiAmortizacion.Name = "tsmiAmortizacion";
            this.tsmiAmortizacion.Size = new System.Drawing.Size(234, 22);
            this.tsmiAmortizacion.Text = "Amortización";
            this.tsmiAmortizacion.Click += new System.EventHandler(this.tsmiPagoCuenta_Click);
            // 
            // tsmiPagoAdelanto
            // 
            this.tsmiPagoAdelanto.Name = "tsmiPagoAdelanto";
            this.tsmiPagoAdelanto.Size = new System.Drawing.Size(234, 22);
            this.tsmiPagoAdelanto.Text = "Pago Adelanto";
            this.tsmiPagoAdelanto.Visible = false;
            this.tsmiPagoAdelanto.Click += new System.EventHandler(this.tsmiPagoAdelanto_Click);
            // 
            // tsmiDevoluciones
            // 
            this.tsmiDevoluciones.Name = "tsmiDevoluciones";
            this.tsmiDevoluciones.Size = new System.Drawing.Size(234, 22);
            this.tsmiDevoluciones.Text = "Devoluciones";
            this.tsmiDevoluciones.Visible = false;
            this.tsmiDevoluciones.Click += new System.EventHandler(this.tsmiDevoluciones_Click);
            // 
            // actPrecioVentaMasivoToolStripMenuItem
            // 
            this.actPrecioVentaMasivoToolStripMenuItem.Name = "actPrecioVentaMasivoToolStripMenuItem";
            this.actPrecioVentaMasivoToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.actPrecioVentaMasivoToolStripMenuItem.Text = "Act. Precio Venta Masivo";
            this.actPrecioVentaMasivoToolStripMenuItem.Click += new System.EventHandler(this.actPrecioVentaMasivoToolStripMenuItem_Click);
            // 
            // mantenimientoDeClienteToolStripMenuItem
            // 
            this.mantenimientoDeClienteToolStripMenuItem.Name = "mantenimientoDeClienteToolStripMenuItem";
            this.mantenimientoDeClienteToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.mantenimientoDeClienteToolStripMenuItem.Text = "Mantenimiento de Clientes";
            this.mantenimientoDeClienteToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoDeClienteToolStripMenuItem_Click);
            // 
            // mantenimientoDeUsuariosToolStripMenuItem
            // 
            this.mantenimientoDeUsuariosToolStripMenuItem.Name = "mantenimientoDeUsuariosToolStripMenuItem";
            this.mantenimientoDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.mantenimientoDeUsuariosToolStripMenuItem.Text = "Mantenimiento de Usuarios";
            this.mantenimientoDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoDeUsuariosToolStripMenuItem_Click);
            // 
            // aplicarVueltoToolStripMenuItem
            // 
            this.aplicarVueltoToolStripMenuItem.Name = "aplicarVueltoToolStripMenuItem";
            this.aplicarVueltoToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.aplicarVueltoToolStripMenuItem.Text = "Aplicar Vueltos";
            this.aplicarVueltoToolStripMenuItem.Click += new System.EventHandler(this.aplicarVueltoToolStripMenuItem_Click);
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenimientoDeComprasToolStripMenuItem,
            this.mantenimientoDeDocPagosCompraToolStripMenuItem});
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.comprasToolStripMenuItem.Text = "Compras";
            // 
            // mantenimientoDeComprasToolStripMenuItem
            // 
            this.mantenimientoDeComprasToolStripMenuItem.Name = "mantenimientoDeComprasToolStripMenuItem";
            this.mantenimientoDeComprasToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.mantenimientoDeComprasToolStripMenuItem.Text = "Mantenimiento de Compras";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReporteCobranza,
            this.tableroDeVentasToolStripMenuItem,
            this.cuadreCajaToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.estadoDeToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // tsmiReporteCobranza
            // 
            this.tsmiReporteCobranza.Name = "tsmiReporteCobranza";
            this.tsmiReporteCobranza.Size = new System.Drawing.Size(206, 22);
            this.tsmiReporteCobranza.Text = "Hoja de Cobranza";
            this.tsmiReporteCobranza.Click += new System.EventHandler(this.tsmiReporteCobranza_Click);
            // 
            // tableroDeVentasToolStripMenuItem
            // 
            this.tableroDeVentasToolStripMenuItem.Name = "tableroDeVentasToolStripMenuItem";
            this.tableroDeVentasToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.tableroDeVentasToolStripMenuItem.Text = "Tablero de Ventas";
            this.tableroDeVentasToolStripMenuItem.Click += new System.EventHandler(this.tsmiReporteFiltros_Click);
            // 
            // cuadreCajaToolStripMenuItem
            // 
            this.cuadreCajaToolStripMenuItem.Name = "cuadreCajaToolStripMenuItem";
            this.cuadreCajaToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.cuadreCajaToolStripMenuItem.Text = "Cuadre de Caja";
            this.cuadreCajaToolStripMenuItem.Click += new System.EventHandler(this.cuadreCajaToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hojaTableroToolStripMenuItem,
            this.listaDePreciosToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.toolsToolStripMenuItem.Text = "Herramientas";
            // 
            // hojaTableroToolStripMenuItem
            // 
            this.hojaTableroToolStripMenuItem.Name = "hojaTableroToolStripMenuItem";
            this.hojaTableroToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.hojaTableroToolStripMenuItem.Text = "Hoja de Tablero";
            this.hojaTableroToolStripMenuItem.Click += new System.EventHandler(this.hojaTableroToolStripMenuItem_Click);
            // 
            // listaDePreciosToolStripMenuItem
            // 
            this.listaDePreciosToolStripMenuItem.Name = "listaDePreciosToolStripMenuItem";
            this.listaDePreciosToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.listaDePreciosToolStripMenuItem.Text = "Lista de Precios";
            this.listaDePreciosToolStripMenuItem.Click += new System.EventHandler(this.listaDePreciosToolStripMenuItem_Click);
            // 
            // estadoDeToolStripMenuItem
            // 
            this.estadoDeToolStripMenuItem.Name = "estadoDeToolStripMenuItem";
            this.estadoDeToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.estadoDeToolStripMenuItem.Text = "Estado de Cuenta Cliente";
            this.estadoDeToolStripMenuItem.Click += new System.EventHandler(this.estadoDeToolStripMenuItem_Click);
            // 
            // tsmSalir
            // 
            this.tsmSalir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSalirSistema});
            this.tsmSalir.Name = "tsmSalir";
            this.tsmSalir.Size = new System.Drawing.Size(41, 20);
            this.tsmSalir.Text = "Salir";
            // 
            // tsmiSalirSistema
            // 
            this.tsmiSalirSistema.Name = "tsmiSalirSistema";
            this.tsmiSalirSistema.Size = new System.Drawing.Size(159, 22);
            this.tsmiSalirSistema.Text = "Salir del Sistema";
            // 
            // mantenimientoDeDocPagosToolStripMenuItem
            // 
            this.mantenimientoDeDocPagosToolStripMenuItem.Name = "mantenimientoDeDocPagosToolStripMenuItem";
            this.mantenimientoDeDocPagosToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.mantenimientoDeDocPagosToolStripMenuItem.Text = "Mantenimiento de Doc. Pagos Venta";
            this.mantenimientoDeDocPagosToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoDeDocPagosToolStripMenuItem_Click);
            // 
            // mantenimientoDeDocPagosCompraToolStripMenuItem
            // 
            this.mantenimientoDeDocPagosCompraToolStripMenuItem.Name = "mantenimientoDeDocPagosCompraToolStripMenuItem";
            this.mantenimientoDeDocPagosCompraToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.mantenimientoDeDocPagosCompraToolStripMenuItem.Text = "Mantenimiento de Doc. Pagos Compra";
            this.mantenimientoDeDocPagosCompraToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoDeDocPagosCompraToolStripMenuItem_Click);
            // 
            // frmMDIPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 341);
            this.Controls.Add(this.msMenuPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMenuPrincipal;
            this.Name = "frmMDIPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DGP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMDIPrincipal_Load);
            this.msMenuPrincipal.ResumeLayout(false);
            this.msMenuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem tsmVentas;
        private System.Windows.Forms.ToolStripMenuItem tsmSalir;
        private System.Windows.Forms.ToolStripMenuItem tsmiSalirSistema;
        private System.Windows.Forms.ToolStripMenuItem tstmiVentas_TableroElectronico;
        private System.Windows.Forms.ToolStripMenuItem tsmiDevoluciones;
        private System.Windows.Forms.ToolStripMenuItem tsmiAmortizacion;
        private System.Windows.Forms.ToolStripMenuItem tsmiPagoAdelanto;
        private System.Windows.Forms.ToolStripMenuItem tsmiDetalleVenta;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiReporteCobranza;
        private System.Windows.Forms.ToolStripMenuItem tableroDeVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actPrecioVentaMasivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoDeClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuadreCajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hojaTableroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDePreciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadoDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoDeComprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aplicarVueltoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoDeDocPagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoDeDocPagosCompraToolStripMenuItem;


    }
}