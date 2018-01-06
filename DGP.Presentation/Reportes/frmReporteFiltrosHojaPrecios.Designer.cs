namespace DGP.Presentation.Reportes
{
    partial class frmReporteFiltrosHojaPrecios
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
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicial = new System.Windows.Forms.Label();
            this.lblFechaFinal = new System.Windows.Forms.Label();
            this.gbRangoFechas = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkListProductos = new System.Windows.Forms.CheckedListBox();
            this.chkListZonas = new System.Windows.Forms.CheckedListBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbRangoFechas.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(154, 24);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(110, 26);
            this.dtpFechaInicial.TabIndex = 0;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(399, 24);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(110, 26);
            this.dtpFechaFinal.TabIndex = 1;
            // 
            // lblFechaInicial
            // 
            this.lblFechaInicial.AutoSize = true;
            this.lblFechaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicial.Location = new System.Drawing.Point(33, 30);
            this.lblFechaInicial.Name = "lblFechaInicial";
            this.lblFechaInicial.Size = new System.Drawing.Size(98, 20);
            this.lblFechaInicial.TabIndex = 2;
            this.lblFechaInicial.Text = "Fecha Inicial";
            this.lblFechaInicial.Click += new System.EventHandler(this.lblFechaInicial_Click);
            // 
            // lblFechaFinal
            // 
            this.lblFechaFinal.AutoSize = true;
            this.lblFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFinal.Location = new System.Drawing.Point(301, 30);
            this.lblFechaFinal.Name = "lblFechaFinal";
            this.lblFechaFinal.Size = new System.Drawing.Size(92, 20);
            this.lblFechaFinal.TabIndex = 3;
            this.lblFechaFinal.Text = "Fecha Final";
            // 
            // gbRangoFechas
            // 
            this.gbRangoFechas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRangoFechas.Controls.Add(this.lblFechaInicial);
            this.gbRangoFechas.Controls.Add(this.lblFechaFinal);
            this.gbRangoFechas.Controls.Add(this.dtpFechaInicial);
            this.gbRangoFechas.Controls.Add(this.dtpFechaFinal);
            this.gbRangoFechas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRangoFechas.Location = new System.Drawing.Point(12, 12);
            this.gbRangoFechas.Name = "gbRangoFechas";
            this.gbRangoFechas.Size = new System.Drawing.Size(668, 70);
            this.gbRangoFechas.TabIndex = 4;
            this.gbRangoFechas.TabStop = false;
            this.gbRangoFechas.Text = "Rango de Fechas";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkListProductos);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 133);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Productos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkListZonas);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(318, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 133);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Zonas";
            // 
            // chkListProductos
            // 
            this.chkListProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkListProductos.FormattingEnabled = true;
            this.chkListProductos.Location = new System.Drawing.Point(11, 19);
            this.chkListProductos.Name = "chkListProductos";
            this.chkListProductos.Size = new System.Drawing.Size(283, 109);
            this.chkListProductos.TabIndex = 7;
            // 
            // chkListZonas
            // 
            this.chkListZonas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkListZonas.FormattingEnabled = true;
            this.chkListZonas.Location = new System.Drawing.Point(6, 19);
            this.chkListZonas.Name = "chkListZonas";
            this.chkListZonas.Size = new System.Drawing.Size(344, 109);
            this.chkListZonas.TabIndex = 8;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(221, 243);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(87, 29);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(359, 243);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 29);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // frmReporteFiltros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 314);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbRangoFechas);
            this.Name = "frmReporteFiltros";
            this.Text = "frmReporteFiltros";
            this.gbRangoFechas.ResumeLayout(false);
            this.gbRangoFechas.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label lblFechaInicial;
        private System.Windows.Forms.Label lblFechaFinal;
        private System.Windows.Forms.GroupBox gbRangoFechas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox chkListProductos;
        private System.Windows.Forms.CheckedListBox chkListZonas;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}