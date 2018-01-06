namespace DGP.Presentation.Reportes
{
    partial class frmReporteEstadoCuentaCliente
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
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.lbClientes = new System.Windows.Forms.ListBox();
            this.btnEliminarClienteLista = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.CRptEstadoCuentaCliente = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.CustomFormat = "d/M/yyyy";
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(428, 19);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(99, 20);
            this.dtpFechaInicial.TabIndex = 0;
            // 
            // lbClientes
            // 
            this.lbClientes.DisplayMember = "Nombre";
            this.lbClientes.FormattingEnabled = true;
            this.lbClientes.Location = new System.Drawing.Point(6, 46);
            this.lbClientes.MultiColumn = true;
            this.lbClientes.Name = "lbClientes";
            this.lbClientes.Size = new System.Drawing.Size(521, 43);
            this.lbClientes.TabIndex = 2;
            this.lbClientes.ValueMember = "IdCliente";
            // 
            // btnEliminarClienteLista
            // 
            this.btnEliminarClienteLista.Location = new System.Drawing.Point(533, 46);
            this.btnEliminarClienteLista.Name = "btnEliminarClienteLista";
            this.btnEliminarClienteLista.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarClienteLista.TabIndex = 5;
            this.btnEliminarClienteLista.Text = "Eliminar";
            this.btnEliminarClienteLista.UseVisualStyleBackColor = true;
            this.btnEliminarClienteLista.Click += new System.EventHandler(this.btnEliminarClienteLista_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(6, 95);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Consultar";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbClientes);
            this.groupBox1.Controls.Add(this.lbClientes);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.dtpFechaInicial);
            this.groupBox1.Controls.Add(this.btnEliminarClienteLista);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 130);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // cmbClientes
            // 
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(6, 16);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(121, 21);
            this.cmbClientes.TabIndex = 7;
            this.cmbClientes.Leave += new System.EventHandler(this.cmbClientes_Leave);
            this.cmbClientes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbClientes_KeyPress);
            this.cmbClientes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbClientes_KeyUp);
            // 
            // CRptEstadoCuentaCliente
            // 
            this.CRptEstadoCuentaCliente.ActiveViewIndex = -1;
            this.CRptEstadoCuentaCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CRptEstadoCuentaCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRptEstadoCuentaCliente.Location = new System.Drawing.Point(18, 157);
            this.CRptEstadoCuentaCliente.Name = "CRptEstadoCuentaCliente";
            this.CRptEstadoCuentaCliente.SelectionFormula = "";
            this.CRptEstadoCuentaCliente.Size = new System.Drawing.Size(608, 184);
            this.CRptEstadoCuentaCliente.TabIndex = 8;
            this.CRptEstadoCuentaCliente.ViewTimeSelectionFormula = "";
            // 
            // frmReporteEstadoCuentaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 353);
            this.Controls.Add(this.CRptEstadoCuentaCliente);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmReporteEstadoCuentaCliente";
            this.Text = "Detalle Estado de Cuenta del Cliente";
            this.Load += new System.EventHandler(this.frmReporteEstadoCuentaCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.ListBox lbClientes;
        private System.Windows.Forms.Button btnEliminarClienteLista;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRptEstadoCuentaCliente;
        private System.Windows.Forms.ComboBox cmbClientes;
    }
}