namespace DGP.Presentation.Ventas
{
    partial class frmAplicarPreciosGrupo
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
            this.cbFormaAplicar = new System.Windows.Forms.ComboBox();
            this.nudPrecioBase = new System.Windows.Forms.NumericUpDown();
            this.nubMargenMinimo = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cbProducto = new System.Windows.Forms.ComboBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAplicar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nubMargenMinimo)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFormaAplicar
            // 
            this.cbFormaAplicar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormaAplicar.FormattingEnabled = true;
            this.cbFormaAplicar.Location = new System.Drawing.Point(165, 75);
            this.cbFormaAplicar.Name = "cbFormaAplicar";
            this.cbFormaAplicar.Size = new System.Drawing.Size(121, 21);
            this.cbFormaAplicar.TabIndex = 0;
            // 
            // nudPrecioBase
            // 
            this.nudPrecioBase.DecimalPlaces = 2;
            this.nudPrecioBase.Location = new System.Drawing.Point(166, 113);
            this.nudPrecioBase.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPrecioBase.Name = "nudPrecioBase";
            this.nudPrecioBase.Size = new System.Drawing.Size(120, 20);
            this.nudPrecioBase.TabIndex = 1;
            this.nudPrecioBase.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // nubMargenMinimo
            // 
            this.nubMargenMinimo.DecimalPlaces = 2;
            this.nubMargenMinimo.Location = new System.Drawing.Point(166, 160);
            this.nubMargenMinimo.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nubMargenMinimo.Name = "nubMargenMinimo";
            this.nubMargenMinimo.Size = new System.Drawing.Size(120, 20);
            this.nubMargenMinimo.TabIndex = 2;
            this.nubMargenMinimo.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Forma Aplicar";
            // 
            // cbProducto
            // 
            this.cbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProducto.FormattingEnabled = true;
            this.cbProducto.Location = new System.Drawing.Point(165, 31);
            this.cbProducto.Name = "cbProducto";
            this.cbProducto.Size = new System.Drawing.Size(121, 21);
            this.cbProducto.TabIndex = 4;
            this.cbProducto.SelectedIndexChanged += new System.EventHandler(this.cbProducto_SelectedIndexChanged);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(27, 39);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(50, 13);
            this.lblProducto.TabIndex = 5;
            this.lblProducto.Text = "Producto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Precio Base";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Margen Por Defecto";
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(166, 208);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 23);
            this.btnAplicar.TabIndex = 8;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // frmAplicarPreciosGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 256);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.cbProducto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nubMargenMinimo);
            this.Controls.Add(this.nudPrecioBase);
            this.Controls.Add(this.cbFormaAplicar);
            this.Name = "frmAplicarPreciosGrupo";
            this.Text = "frmAplicarPreciosGrupo";
            this.Load += new System.EventHandler(this.frmAplicarPreciosGrupo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nubMargenMinimo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFormaAplicar;
        private System.Windows.Forms.NumericUpDown nudPrecioBase;
        private System.Windows.Forms.NumericUpDown nubMargenMinimo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAplicar;
    }
}