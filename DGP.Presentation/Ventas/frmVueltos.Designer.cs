namespace DGP.Presentation.Ventas
{
    partial class frmVueltos
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
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.dgvVueltos = new System.Windows.Forms.DataGridView();
            this.isSelectedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalSaldoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPesoNetoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idVentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsVueltos = new System.Windows.Forms.BindingSource(this.components);
            this.rbtVuelto = new System.Windows.Forms.RadioButton();
            this.rbtCancelarVenta = new System.Windows.Forms.RadioButton();
            this.btnProcesarVuelto = new System.Windows.Forms.Button();
            this.dgvSaldos = new System.Windows.Forms.DataGridView();
            this.isSelectedDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fechaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalSaldoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPesoNetoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idVentaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsSaldos = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVueltos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVueltos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSaldos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbClientes
            // 
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(12, 12);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(121, 21);
            this.cmbClientes.TabIndex = 8;
            this.cmbClientes.Leave += new System.EventHandler(this.cmbClientes_Leave);
            this.cmbClientes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbClientes_KeyPress);
            this.cmbClientes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbClientes_KeyUp);
            // 
            // dgvVueltos
            // 
            this.dgvVueltos.AllowUserToAddRows = false;
            this.dgvVueltos.AllowUserToDeleteRows = false;
            this.dgvVueltos.AutoGenerateColumns = false;
            this.dgvVueltos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVueltos.CausesValidation = false;
            this.dgvVueltos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVueltos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isSelectedDataGridViewCheckBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.totalSaldoDataGridViewTextBoxColumn,
            this.totalPesoNetoDataGridViewTextBoxColumn,
            this.precioDataGridViewTextBoxColumn,
            this.idVentaDataGridViewTextBoxColumn});
            this.dgvVueltos.DataSource = this.bsVueltos;
            this.dgvVueltos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvVueltos.Location = new System.Drawing.Point(6, 19);
            this.dgvVueltos.MultiSelect = false;
            this.dgvVueltos.Name = "dgvVueltos";
            this.dgvVueltos.Size = new System.Drawing.Size(401, 222);
            this.dgvVueltos.TabIndex = 9;
            // 
            // isSelectedDataGridViewCheckBoxColumn
            // 
            this.isSelectedDataGridViewCheckBoxColumn.DataPropertyName = "IsSelected";
            this.isSelectedDataGridViewCheckBoxColumn.HeaderText = "";
            this.isSelectedDataGridViewCheckBoxColumn.Name = "isSelectedDataGridViewCheckBoxColumn";
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            // 
            // totalSaldoDataGridViewTextBoxColumn
            // 
            this.totalSaldoDataGridViewTextBoxColumn.DataPropertyName = "Total_Saldo";
            this.totalSaldoDataGridViewTextBoxColumn.HeaderText = "Vuelto";
            this.totalSaldoDataGridViewTextBoxColumn.Name = "totalSaldoDataGridViewTextBoxColumn";
            // 
            // totalPesoNetoDataGridViewTextBoxColumn
            // 
            this.totalPesoNetoDataGridViewTextBoxColumn.DataPropertyName = "Total_Peso_Neto";
            this.totalPesoNetoDataGridViewTextBoxColumn.HeaderText = "Neto";
            this.totalPesoNetoDataGridViewTextBoxColumn.Name = "totalPesoNetoDataGridViewTextBoxColumn";
            // 
            // precioDataGridViewTextBoxColumn
            // 
            this.precioDataGridViewTextBoxColumn.DataPropertyName = "Precio";
            this.precioDataGridViewTextBoxColumn.HeaderText = "Precio";
            this.precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            // 
            // idVentaDataGridViewTextBoxColumn
            // 
            this.idVentaDataGridViewTextBoxColumn.DataPropertyName = "Id_Venta";
            this.idVentaDataGridViewTextBoxColumn.HeaderText = "Id_Venta";
            this.idVentaDataGridViewTextBoxColumn.Name = "idVentaDataGridViewTextBoxColumn";
            // 
            // bsVueltos
            // 
            this.bsVueltos.DataMember = "DTVuelto";
            this.bsVueltos.DataSource = typeof(DGP.Entities.DataSet.DSVueltos);
            // 
            // rbtVuelto
            // 
            this.rbtVuelto.AutoSize = true;
            this.rbtVuelto.Checked = true;
            this.rbtVuelto.Location = new System.Drawing.Point(150, 13);
            this.rbtVuelto.Name = "rbtVuelto";
            this.rbtVuelto.Size = new System.Drawing.Size(99, 17);
            this.rbtVuelto.TabIndex = 10;
            this.rbtVuelto.TabStop = true;
            this.rbtVuelto.Text = "Retornar Vuelto";
            this.rbtVuelto.UseVisualStyleBackColor = true;
            // 
            // rbtCancelarVenta
            // 
            this.rbtCancelarVenta.AutoSize = true;
            this.rbtCancelarVenta.Location = new System.Drawing.Point(270, 12);
            this.rbtCancelarVenta.Name = "rbtCancelarVenta";
            this.rbtCancelarVenta.Size = new System.Drawing.Size(122, 17);
            this.rbtCancelarVenta.TabIndex = 11;
            this.rbtCancelarVenta.Text = "Solo Cancelar Venta";
            this.rbtCancelarVenta.UseVisualStyleBackColor = true;
            // 
            // btnProcesarVuelto
            // 
            this.btnProcesarVuelto.Location = new System.Drawing.Point(825, 308);
            this.btnProcesarVuelto.Name = "btnProcesarVuelto";
            this.btnProcesarVuelto.Size = new System.Drawing.Size(75, 23);
            this.btnProcesarVuelto.TabIndex = 12;
            this.btnProcesarVuelto.Text = "Procesar";
            this.btnProcesarVuelto.UseVisualStyleBackColor = true;
            this.btnProcesarVuelto.Click += new System.EventHandler(this.btnProcesarVuelto_Click);
            // 
            // dgvSaldos
            // 
            this.dgvSaldos.AllowUserToAddRows = false;
            this.dgvSaldos.AllowUserToDeleteRows = false;
            this.dgvSaldos.AutoGenerateColumns = false;
            this.dgvSaldos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSaldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaldos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isSelectedDataGridViewCheckBoxColumn1,
            this.fechaDataGridViewTextBoxColumn1,
            this.totalSaldoDataGridViewTextBoxColumn1,
            this.totalPesoNetoDataGridViewTextBoxColumn1,
            this.precioDataGridViewTextBoxColumn1,
            this.idVentaDataGridViewTextBoxColumn1});
            this.dgvSaldos.DataSource = this.bsSaldos;
            this.dgvSaldos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSaldos.Location = new System.Drawing.Point(6, 19);
            this.dgvSaldos.Name = "dgvSaldos";
            this.dgvSaldos.Size = new System.Drawing.Size(407, 222);
            this.dgvSaldos.TabIndex = 13;
            // 
            // isSelectedDataGridViewCheckBoxColumn1
            // 
            this.isSelectedDataGridViewCheckBoxColumn1.DataPropertyName = "IsSelected";
            this.isSelectedDataGridViewCheckBoxColumn1.HeaderText = "";
            this.isSelectedDataGridViewCheckBoxColumn1.Name = "isSelectedDataGridViewCheckBoxColumn1";
            // 
            // fechaDataGridViewTextBoxColumn1
            // 
            this.fechaDataGridViewTextBoxColumn1.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn1.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn1.Name = "fechaDataGridViewTextBoxColumn1";
            // 
            // totalSaldoDataGridViewTextBoxColumn1
            // 
            this.totalSaldoDataGridViewTextBoxColumn1.DataPropertyName = "Total_Saldo";
            this.totalSaldoDataGridViewTextBoxColumn1.HeaderText = "Saldo";
            this.totalSaldoDataGridViewTextBoxColumn1.Name = "totalSaldoDataGridViewTextBoxColumn1";
            // 
            // totalPesoNetoDataGridViewTextBoxColumn1
            // 
            this.totalPesoNetoDataGridViewTextBoxColumn1.DataPropertyName = "Total_Peso_Neto";
            this.totalPesoNetoDataGridViewTextBoxColumn1.HeaderText = "Neto";
            this.totalPesoNetoDataGridViewTextBoxColumn1.Name = "totalPesoNetoDataGridViewTextBoxColumn1";
            // 
            // precioDataGridViewTextBoxColumn1
            // 
            this.precioDataGridViewTextBoxColumn1.DataPropertyName = "Precio";
            this.precioDataGridViewTextBoxColumn1.HeaderText = "Precio";
            this.precioDataGridViewTextBoxColumn1.Name = "precioDataGridViewTextBoxColumn1";
            // 
            // idVentaDataGridViewTextBoxColumn1
            // 
            this.idVentaDataGridViewTextBoxColumn1.DataPropertyName = "Id_Venta";
            this.idVentaDataGridViewTextBoxColumn1.HeaderText = "Id_Venta";
            this.idVentaDataGridViewTextBoxColumn1.Name = "idVentaDataGridViewTextBoxColumn1";
            // 
            // bsSaldos
            // 
            this.bsSaldos.DataMember = "DTSaldos";
            this.bsSaldos.DataSource = typeof(DGP.Entities.DataSet.DSVueltos);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvVueltos);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 251);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vueltos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSaldos);
            this.groupBox2.Location = new System.Drawing.Point(473, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(427, 251);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saldos";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Fecha";
            this.dataGridViewTextBoxColumn1.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 71;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Total_Saldo";
            this.dataGridViewTextBoxColumn2.HeaderText = "Total_Saldo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 72;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Total_Peso_Neto";
            this.dataGridViewTextBoxColumn3.HeaderText = "Total_Peso_Neto";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 71;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Precio";
            this.dataGridViewTextBoxColumn4.HeaderText = "Precio";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 72;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Id_Venta";
            this.dataGridViewTextBoxColumn5.HeaderText = "Id_Venta";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Fecha";
            this.dataGridViewTextBoxColumn6.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 73;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Total_Saldo";
            this.dataGridViewTextBoxColumn7.HeaderText = "Total_Saldo";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 72;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Total_Peso_Neto";
            this.dataGridViewTextBoxColumn8.HeaderText = "Total_Peso_Neto";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 73;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Precio";
            this.dataGridViewTextBoxColumn9.HeaderText = "Precio";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 73;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Id_Venta";
            this.dataGridViewTextBoxColumn10.HeaderText = "Id_Venta";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // frmVueltos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 351);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnProcesarVuelto);
            this.Controls.Add(this.rbtCancelarVenta);
            this.Controls.Add(this.rbtVuelto);
            this.Controls.Add(this.cmbClientes);
            this.Name = "frmVueltos";
            this.Text = "frmVueltos";
            this.Load += new System.EventHandler(this.frmVueltos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVueltos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVueltos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSaldos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.DataGridView dgvVueltos;
        private System.Windows.Forms.RadioButton rbtVuelto;
        private System.Windows.Forms.RadioButton rbtCancelarVenta;
        private System.Windows.Forms.Button btnProcesarVuelto;
        private System.Windows.Forms.DataGridView dgvSaldos;
        private System.Windows.Forms.BindingSource bsVueltos;
        private System.Windows.Forms.BindingSource bsSaldos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSelectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalSaldoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPesoNetoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSelectedDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalSaldoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPesoNetoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVentaDataGridViewTextBoxColumn1;
    }
}