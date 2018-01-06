namespace DGP.Presentation.Ventas
{
    partial class frmPagoAdelanto
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSimboloMoneda = new System.Windows.Forms.Label();
            this.nudPrecioAdelanto = new System.Windows.Forms.NumericUpDown();
            this.btnAceptarAdelanto = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioAdelanto)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSimboloMoneda);
            this.groupBox1.Controls.Add(this.nudPrecioAdelanto);
            this.groupBox1.Controls.Add(this.btnAceptarAdelanto);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtObservacion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbCliente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registrar Adelanto";
            // 
            // lblSimboloMoneda
            // 
            this.lblSimboloMoneda.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.lblSimboloMoneda.Location = new System.Drawing.Point(282, 22);
            this.lblSimboloMoneda.Name = "lblSimboloMoneda";
            this.lblSimboloMoneda.Size = new System.Drawing.Size(25, 23);
            this.lblSimboloMoneda.TabIndex = 0;
            // 
            // nudPrecioAdelanto
            // 
            this.nudPrecioAdelanto.DecimalPlaces = 2;
            this.nudPrecioAdelanto.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudPrecioAdelanto.Location = new System.Drawing.Point(314, 20);
            this.nudPrecioAdelanto.Margin = new System.Windows.Forms.Padding(4);
            this.nudPrecioAdelanto.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPrecioAdelanto.Name = "nudPrecioAdelanto";
            this.nudPrecioAdelanto.Size = new System.Drawing.Size(127, 20);
            this.nudPrecioAdelanto.TabIndex = 2;
            this.nudPrecioAdelanto.ThousandsSeparator = true;
            this.nudPrecioAdelanto.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAceptarAdelanto
            // 
            this.btnAceptarAdelanto.Location = new System.Drawing.Point(305, 124);
            this.btnAceptarAdelanto.Name = "btnAceptarAdelanto";
            this.btnAceptarAdelanto.Size = new System.Drawing.Size(136, 23);
            this.btnAceptarAdelanto.TabIndex = 15;
            this.btnAceptarAdelanto.Text = "Aceptar";
            this.btnAceptarAdelanto.UseVisualStyleBackColor = true;
            this.btnAceptarAdelanto.Click += new System.EventHandler(this.btnAceptarAdelanto_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Observación";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(79, 50);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size = new System.Drawing.Size(362, 68);
            this.txtObservacion.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Precio";
            // 
            // cbCliente
            // 
            this.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(51, 19);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(188, 21);
            this.cbCliente.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // frmPagoAdelanto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 182);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frmPagoAdelanto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DGP - Pago Adelanto";
            this.Load += new System.EventHandler(this.frmPagoAdelanto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioAdelanto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Button btnAceptarAdelanto;
        private System.Windows.Forms.NumericUpDown nudPrecioAdelanto;
        private System.Windows.Forms.Label lblSimboloMoneda;
    }
}