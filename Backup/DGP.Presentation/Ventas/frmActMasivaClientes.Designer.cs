namespace DGP.Presentation.Ventas
{
    partial class frmActMasivaClientes
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cmbProductos = new System.Windows.Forms.ComboBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.nudMargen = new System.Windows.Forms.NumericUpDown();
            this.nudPrecio = new System.Windows.Forms.NumericUpDown();
            this.lblMargen = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.chkMasivo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(49, 267);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(95, 29);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cmbProductos
            // 
            this.cmbProductos.DisplayMember = "IdProducto";
            this.cmbProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductos.FormattingEnabled = true;
            this.cmbProductos.Location = new System.Drawing.Point(150, 38);
            this.cmbProductos.Name = "cmbProductos";
            this.cmbProductos.Size = new System.Drawing.Size(121, 28);
            this.cmbProductos.TabIndex = 1;
            this.cmbProductos.ValueMember = "IdProducto";
            this.cmbProductos.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(45, 46);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(77, 20);
            this.lblProducto.TabIndex = 2;
            this.lblProducto.Text = "Producto:";
            this.lblProducto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nudMargen
            // 
            this.nudMargen.DecimalPlaces = 2;
            this.nudMargen.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudMargen.Location = new System.Drawing.Point(150, 138);
            this.nudMargen.MinimumSize = new System.Drawing.Size(120, 0);
            this.nudMargen.Name = "nudMargen";
            this.nudMargen.Size = new System.Drawing.Size(120, 26);
            this.nudMargen.TabIndex = 3;
            this.nudMargen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudPrecio
            // 
            this.nudPrecio.DecimalPlaces = 2;
            this.nudPrecio.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudPrecio.Location = new System.Drawing.Point(150, 88);
            this.nudPrecio.MinimumSize = new System.Drawing.Size(120, 0);
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(120, 26);
            this.nudPrecio.TabIndex = 4;
            this.nudPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMargen
            // 
            this.lblMargen.AutoSize = true;
            this.lblMargen.Location = new System.Drawing.Point(55, 144);
            this.lblMargen.Name = "lblMargen";
            this.lblMargen.Size = new System.Drawing.Size(67, 20);
            this.lblMargen.TabIndex = 5;
            this.lblMargen.Text = "Margen:";
            this.lblMargen.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Precio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(192, 267);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 29);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // chkMasivo
            // 
            this.chkMasivo.AutoSize = true;
            this.chkMasivo.Location = new System.Drawing.Point(49, 187);
            this.chkMasivo.Name = "chkMasivo";
            this.chkMasivo.Size = new System.Drawing.Size(252, 24);
            this.chkMasivo.TabIndex = 8;
            this.chkMasivo.Text = "Aplicación a Todos Los Clientes";
            this.chkMasivo.UseVisualStyleBackColor = true;
            // 
            // frmActMasivaClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 319);
            this.Controls.Add(this.chkMasivo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMargen);
            this.Controls.Add(this.nudPrecio);
            this.Controls.Add(this.nudMargen);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.cmbProductos);
            this.Controls.Add(this.btnAceptar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(351, 304);
            this.Name = "frmActMasivaClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Peso de Venta Masivo";
            ((System.ComponentModel.ISupportInitialize)(this.nudMargen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cmbProductos;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.NumericUpDown nudMargen;
        private System.Windows.Forms.NumericUpDown nudPrecio;
        private System.Windows.Forms.Label lblMargen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox chkMasivo;
    }
}