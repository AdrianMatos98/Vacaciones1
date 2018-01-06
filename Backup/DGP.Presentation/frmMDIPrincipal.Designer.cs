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
            this.tsmSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSalirSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReporteCobranza = new System.Windows.Forms.ToolStripMenuItem();
            this.tableroDeVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuadreCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hojaTableroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDePreciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMenuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenuPrincipal
            // 
            this.msMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmVentas,
            this.tsmSalir,
            this.reportesToolStripMenuItem});
            this.msMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.msMenuPrincipal.Name = "msMenuPrincipal";
            this.msMenuPrincipal.Size = new System.Drawing.Size(292, 24);
            this.msMenuPrincipal.TabIndex = 1;
            // 
            // tsmVentas
            // 
            this.tsmVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstmiVentas_TableroElectronico,
            this.tsmiDetalleVenta,
            this.tsmiAmortizacion,
            this.tsmiPagoAdelanto,
            this.tsmiDevoluciones,
            this.actPrecioVentaMasivoToolStripMenuItem,
            this.mantenimientoDeClienteToolStripMenuItem});
            this.tsmVentas.Name = "tsmVentas";
            this.tsmVentas.Size = new System.Drawing.Size(52, 20);
            this.tsmVentas.Text = "Ventas";
            // 
            // tstmiVentas_TableroElectronico
            // 
            this.tstmiVentas_TableroElectronico.Name = "tstmiVentas_TableroElectronico";
            this.tstmiVentas_TableroElectronico.Size = new System.Drawing.Size(206, 22);
            this.tstmiVentas_TableroElectronico.Text = "Tablero Electronico";
            this.tstmiVentas_TableroElectronico.Click += new System.EventHandler(this.tstmiVentas_TableroElectronico_Click);
            // 
            // tsmiDetalleVenta
            // 
            this.tsmiDetalleVenta.Name = "tsmiDetalleVenta";
            this.tsmiDetalleVenta.Size = new System.Drawing.Size(206, 22);
            this.tsmiDetalleVenta.Text = "Mantenimiento Venta";
            this.tsmiDetalleVenta.Click += new System.EventHandler(this.tsmiDetalleVenta_Click);
            // 
            // tsmiAmortizacion
            // 
            this.tsmiAmortizacion.Name = "tsmiAmortizacion";
            this.tsmiAmortizacion.Size = new System.Drawing.Size(206, 22);
            this.tsmiAmortizacion.Text = "Amortización";
            this.tsmiAmortizacion.Click += new System.EventHandler(this.tsmiPagoCuenta_Click);
            // 
            // tsmiPagoAdelanto
            // 
            this.tsmiPagoAdelanto.Name = "tsmiPagoAdelanto";
            this.tsmiPagoAdelanto.Size = new System.Drawing.Size(206, 22);
            this.tsmiPagoAdelanto.Text = "Pago Adelanto";
            this.tsmiPagoAdelanto.Click += new System.EventHandler(this.tsmiPagoAdelanto_Click);
            // 
            // tsmiDevoluciones
            // 
            this.tsmiDevoluciones.Name = "tsmiDevoluciones";
            this.tsmiDevoluciones.Size = new System.Drawing.Size(206, 22);
            this.tsmiDevoluciones.Text = "Devoluciones";
            this.tsmiDevoluciones.Click += new System.EventHandler(this.tsmiDevoluciones_Click);
            // 
            // actPrecioVentaMasivoToolStripMenuItem
            // 
            this.actPrecioVentaMasivoToolStripMenuItem.Name = "actPrecioVentaMasivoToolStripMenuItem";
            this.actPrecioVentaMasivoToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.actPrecioVentaMasivoToolStripMenuItem.Text = "Act. Precio Venta Masivo";
            this.actPrecioVentaMasivoToolStripMenuItem.Click += new System.EventHandler(this.actPrecioVentaMasivoToolStripMenuItem_Click);
            // 
            // mantenimientoDeClienteToolStripMenuItem
            // 
            this.mantenimientoDeClienteToolStripMenuItem.Name = "mantenimientoDeClienteToolStripMenuItem";
            this.mantenimientoDeClienteToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.mantenimientoDeClienteToolStripMenuItem.Text = "Mantenimiento de Cliente";
            this.mantenimientoDeClienteToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoDeClienteToolStripMenuItem_Click);
            // 
            // tsmSalir
            // 
            this.tsmSalir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSalirSistema});
            this.tsmSalir.Name = "tsmSalir";
            this.tsmSalir.Size = new System.Drawing.Size(39, 20);
            this.tsmSalir.Text = "Salir";
            // 
            // tsmiSalirSistema
            // 
            this.tsmiSalirSistema.Name = "tsmiSalirSistema";
            this.tsmiSalirSistema.Size = new System.Drawing.Size(162, 22);
            this.tsmiSalirSistema.Text = "Salir del Sistema";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReporteCobranza,
            this.tableroDeVentasToolStripMenuItem,
            this.cuadreCajaToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // tsmiReporteCobranza
            // 
            this.tsmiReporteCobranza.Name = "tsmiReporteCobranza";
            this.tsmiReporteCobranza.Size = new System.Drawing.Size(172, 22);
            this.tsmiReporteCobranza.Text = "Hoja de Cobranza";
            this.tsmiReporteCobranza.Click += new System.EventHandler(this.tsmiReporteCobranza_Click);
            // 
            // tableroDeVentasToolStripMenuItem
            // 
            this.tableroDeVentasToolStripMenuItem.Name = "tableroDeVentasToolStripMenuItem";
            this.tableroDeVentasToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.tableroDeVentasToolStripMenuItem.Text = "Tablero de Ventas";
            this.tableroDeVentasToolStripMenuItem.Click += new System.EventHandler(this.tsmiReporteFiltros_Click);
            // 
            // cuadreCajaToolStripMenuItem
            // 
            this.cuadreCajaToolStripMenuItem.Name = "cuadreCajaToolStripMenuItem";
            this.cuadreCajaToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.cuadreCajaToolStripMenuItem.Text = "Cuadre Caja ";
            this.cuadreCajaToolStripMenuItem.Click += new System.EventHandler(this.cuadreCajaToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hojaTableroToolStripMenuItem,
            this.listaDePreciosToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // hojaTableroToolStripMenuItem
            // 
            this.hojaTableroToolStripMenuItem.Name = "hojaTableroToolStripMenuItem";
            this.hojaTableroToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hojaTableroToolStripMenuItem.Text = "Hoja Tablero";
            this.hojaTableroToolStripMenuItem.Click += new System.EventHandler(this.hojaTableroToolStripMenuItem_Click);
            // 
            // listaDePreciosToolStripMenuItem
            // 
            this.listaDePreciosToolStripMenuItem.Name = "listaDePreciosToolStripMenuItem";
            this.listaDePreciosToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.listaDePreciosToolStripMenuItem.Text = "Lista de Precios";
            this.listaDePreciosToolStripMenuItem.Click += new System.EventHandler(this.listaDePreciosToolStripMenuItem_Click);
            // 
            // frmMDIPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.msMenuPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMenuPrincipal;
            this.Name = "frmMDIPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DGP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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


    }
}