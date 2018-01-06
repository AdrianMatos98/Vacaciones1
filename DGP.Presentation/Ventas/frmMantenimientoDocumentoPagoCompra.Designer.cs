namespace DGP.Presentation.Ventas
{
    partial class frmMantenimientoDocumentoPagoCompra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoDocumentoPagoCompra));
            this.dgvDocumentoPago = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dtFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tsbAgregar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.bsDocumetosPago = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentoPago)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocumetosPago)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDocumentoPago
            // 
            this.dgvDocumentoPago.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDocumentoPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentoPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocumentoPago.Location = new System.Drawing.Point(0, 132);
            this.dgvDocumentoPago.Name = "dgvDocumentoPago";
            this.dgvDocumentoPago.Size = new System.Drawing.Size(560, 270);
            this.dgvDocumentoPago.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAgregar,
            this.tsbEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 107);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(560, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtFechaFinal);
            this.panel1.Controls.Add(this.dtFechaInicial);
            this.panel1.Controls.Add(this.cmbClientes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 107);
            this.panel1.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(235, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha Final";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "FechaInicial";
            // 
            // dtFechaFinal
            // 
            this.dtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFinal.Location = new System.Drawing.Point(326, 53);
            this.dtFechaFinal.Name = "dtFechaFinal";
            this.dtFechaFinal.Size = new System.Drawing.Size(96, 20);
            this.dtFechaFinal.TabIndex = 3;
            // 
            // dtFechaInicial
            // 
            this.dtFechaInicial.AccessibleDescription = "a";
            this.dtFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicial.Location = new System.Drawing.Point(99, 54);
            this.dtFechaInicial.Name = "dtFechaInicial";
            this.dtFechaInicial.Size = new System.Drawing.Size(111, 20);
            this.dtFechaInicial.TabIndex = 2;
            // 
            // cmbClientes
            // 
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(89, 18);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(121, 21);
            this.cmbClientes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // tsbAgregar
            // 
            this.tsbAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAgregar.Image = global::DGP.Presentation.Properties.Resources.plusIcon;
            this.tsbAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAgregar.Name = "tsbAgregar";
            this.tsbAgregar.Size = new System.Drawing.Size(23, 22);
            this.tsbAgregar.Text = "toolStripButton1";
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Text = "toolStripButton2";
            // 
            // bsDocumetosPago
            // 
            this.bsDocumetosPago.AllowNew = false;
            this.bsDocumetosPago.DataSource = typeof(DGP.Entities.Ventas.BEDocumento);
            // 
            // frmMantenimientoDocumentoPagoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 402);
            this.Controls.Add(this.dgvDocumentoPago);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "frmMantenimientoDocumentoPagoCompra";
            this.Text = "frmMantenimientoDocumentoPagoCompra";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentoPago)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocumetosPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDocumentoPago;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAgregar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFechaFinal;
        private System.Windows.Forms.DateTimePicker dtFechaInicial;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bsDocumetosPago;
    }
}