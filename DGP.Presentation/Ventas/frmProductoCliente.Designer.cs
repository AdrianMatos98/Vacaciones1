namespace DGP.Presentation.Ventas
{
    partial class frmProductoCliente
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
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.dgvProductoCliente = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bdsProductos = new System.Windows.Forms.BindingSource(this.components);
            this.idProductoClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioCompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.margenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioVentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioCreacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCreacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsProductosClientes = new System.Windows.Forms.BindingSource(this.components);
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
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductoCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsProductosClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(228, 18);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(200, 20);
            this.txtCliente.TabIndex = 0;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(72, 21);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(51, 17);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente";
            // 
            // dgvProductoCliente
            // 
            this.dgvProductoCliente.AutoGenerateColumns = false;
            this.dgvProductoCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductoCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductoCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnEliminar,
            this.idProductoDataGridViewTextBoxColumn,
            this.idProductoClienteDataGridViewTextBoxColumn,
            this.idClienteDataGridViewTextBoxColumn,
            this.taraDataGridViewTextBoxColumn,
            this.precioCompraDataGridViewTextBoxColumn,
            this.margenDataGridViewTextBoxColumn,
            this.precioVentaDataGridViewTextBoxColumn,
            this.productoDataGridViewTextBoxColumn,
            this.usuarioCreacionDataGridViewTextBoxColumn,
            this.fechaCreacionDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn});
            this.dgvProductoCliente.DataSource = this.bdsProductosClientes;
            this.dgvProductoCliente.Location = new System.Drawing.Point(12, 77);
            this.dgvProductoCliente.Name = "dgvProductoCliente";
            this.dgvProductoCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductoCliente.Size = new System.Drawing.Size(597, 150);
            this.dgvProductoCliente.TabIndex = 2;
            this.dgvProductoCliente.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvProductoCliente_UserAddedRow);
            this.dgvProductoCliente.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductoCliente_RowLeave);
            this.dgvProductoCliente.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductoCliente_CellValueChanged);
            this.dgvProductoCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductoCliente_CellContentClick);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(514, 253);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(95, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.HeaderText = "Eliminar";
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnEliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // idProductoDataGridViewTextBoxColumn
            // 
            this.idProductoDataGridViewTextBoxColumn.DataPropertyName = "Id_Producto";
            this.idProductoDataGridViewTextBoxColumn.DataSource = this.bdsProductos;
            this.idProductoDataGridViewTextBoxColumn.DisplayMember = "Nombre";
            this.idProductoDataGridViewTextBoxColumn.HeaderText = "Id_Producto";
            this.idProductoDataGridViewTextBoxColumn.Name = "idProductoDataGridViewTextBoxColumn";
            this.idProductoDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idProductoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.idProductoDataGridViewTextBoxColumn.ValueMember = "IdProducto";
            // 
            // bdsProductos
            // 
            this.bdsProductos.DataSource = typeof(DGP.Entities.BEProducto);
            // 
            // idProductoClienteDataGridViewTextBoxColumn
            // 
            this.idProductoClienteDataGridViewTextBoxColumn.DataPropertyName = "Id_ProductoCliente";
            this.idProductoClienteDataGridViewTextBoxColumn.HeaderText = "Id_ProductoCliente";
            this.idProductoClienteDataGridViewTextBoxColumn.Name = "idProductoClienteDataGridViewTextBoxColumn";
            this.idProductoClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idProductoClienteDataGridViewTextBoxColumn.Visible = false;
            // 
            // idClienteDataGridViewTextBoxColumn
            // 
            this.idClienteDataGridViewTextBoxColumn.DataPropertyName = "Id_Cliente";
            this.idClienteDataGridViewTextBoxColumn.HeaderText = "Id_Cliente";
            this.idClienteDataGridViewTextBoxColumn.Name = "idClienteDataGridViewTextBoxColumn";
            this.idClienteDataGridViewTextBoxColumn.Visible = false;
            // 
            // taraDataGridViewTextBoxColumn
            // 
            this.taraDataGridViewTextBoxColumn.DataPropertyName = "Tara";
            this.taraDataGridViewTextBoxColumn.HeaderText = "Tara";
            this.taraDataGridViewTextBoxColumn.Name = "taraDataGridViewTextBoxColumn";
            // 
            // precioCompraDataGridViewTextBoxColumn
            // 
            this.precioCompraDataGridViewTextBoxColumn.DataPropertyName = "PrecioCompra";
            this.precioCompraDataGridViewTextBoxColumn.HeaderText = "PrecioCompra";
            this.precioCompraDataGridViewTextBoxColumn.Name = "precioCompraDataGridViewTextBoxColumn";
            // 
            // margenDataGridViewTextBoxColumn
            // 
            this.margenDataGridViewTextBoxColumn.DataPropertyName = "Margen";
            this.margenDataGridViewTextBoxColumn.HeaderText = "Margen";
            this.margenDataGridViewTextBoxColumn.Name = "margenDataGridViewTextBoxColumn";
            // 
            // precioVentaDataGridViewTextBoxColumn
            // 
            this.precioVentaDataGridViewTextBoxColumn.DataPropertyName = "PrecioVenta";
            this.precioVentaDataGridViewTextBoxColumn.HeaderText = "PrecioVenta";
            this.precioVentaDataGridViewTextBoxColumn.Name = "precioVentaDataGridViewTextBoxColumn";
            this.precioVentaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productoDataGridViewTextBoxColumn
            // 
            this.productoDataGridViewTextBoxColumn.DataPropertyName = "Producto";
            this.productoDataGridViewTextBoxColumn.HeaderText = "Producto";
            this.productoDataGridViewTextBoxColumn.Name = "productoDataGridViewTextBoxColumn";
            this.productoDataGridViewTextBoxColumn.Visible = false;
            // 
            // usuarioCreacionDataGridViewTextBoxColumn
            // 
            this.usuarioCreacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioCreacion";
            this.usuarioCreacionDataGridViewTextBoxColumn.HeaderText = "UsuarioCreacion";
            this.usuarioCreacionDataGridViewTextBoxColumn.Name = "usuarioCreacionDataGridViewTextBoxColumn";
            this.usuarioCreacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaCreacionDataGridViewTextBoxColumn
            // 
            this.fechaCreacionDataGridViewTextBoxColumn.DataPropertyName = "FechaCreacion";
            this.fechaCreacionDataGridViewTextBoxColumn.HeaderText = "FechaCreacion";
            this.fechaCreacionDataGridViewTextBoxColumn.Name = "fechaCreacionDataGridViewTextBoxColumn";
            this.fechaCreacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // usuarioModificacionDataGridViewTextBoxColumn
            // 
            this.usuarioModificacionDataGridViewTextBoxColumn.DataPropertyName = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.HeaderText = "UsuarioModificacion";
            this.usuarioModificacionDataGridViewTextBoxColumn.Name = "usuarioModificacionDataGridViewTextBoxColumn";
            this.usuarioModificacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "FechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // bdsProductosClientes
            // 
            this.bdsProductosClientes.DataSource = typeof(DGP.Entities.DataSet.DSEntitiesCliente.Tb_Prod_x_ClienteDataTable);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id_ProductoCliente";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id_ProductoCliente";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Id_Cliente";
            this.dataGridViewTextBoxColumn2.HeaderText = "Id_Cliente";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Tara";
            this.dataGridViewTextBoxColumn3.HeaderText = "Tara";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 92;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PrecioCompra";
            this.dataGridViewTextBoxColumn4.HeaderText = "PrecioCompra";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 92;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Margen";
            this.dataGridViewTextBoxColumn5.HeaderText = "Margen";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 93;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PrecioVenta";
            this.dataGridViewTextBoxColumn6.HeaderText = "PrecioVenta";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 92;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Producto";
            this.dataGridViewTextBoxColumn7.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "UsuarioCreacion";
            this.dataGridViewTextBoxColumn8.HeaderText = "UsuarioCreacion";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "FechaCreacion";
            this.dataGridViewTextBoxColumn9.HeaderText = "FechaCreacion";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn10.HeaderText = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "FechaModificacion";
            this.dataGridViewTextBoxColumn11.HeaderText = "FechaModificacion";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // frmProductoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 305);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvProductoCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtCliente);
            this.Name = "frmProductoCliente";
            this.Text = "frmProductoCliente";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductoCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsProductosClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.DataGridView dgvProductoCliente;
        private System.Windows.Forms.BindingSource bdsProductosClientes;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.BindingSource bdsProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProductoClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn idProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioCompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn margenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioVentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioCreacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCreacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminar;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
    }
}