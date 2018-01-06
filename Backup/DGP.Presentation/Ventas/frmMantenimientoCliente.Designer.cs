namespace DGP.Presentation.Ventas
{
    partial class frmMantenimientoCliente
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvCliente = new System.Windows.Forms.DataGridView();
            this.tipoClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.idZonaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bdsZona = new System.Windows.Forms.BindingSource(this.components);
            this.idClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioCreacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCreacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminarFila = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bdsClientes = new System.Windows.Forms.BindingSource(this.components);
            this.btnAceptar = new System.Windows.Forms.Button();
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
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsZona)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(24, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(746, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dgvCliente
            // 
            this.dgvCliente.AutoGenerateColumns = false;
            this.dgvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipoClienteDataGridViewTextBoxColumn,
            this.idZonaDataGridViewTextBoxColumn,
            this.idClienteDataGridViewTextBoxColumn,
            this.nombresDataGridViewTextBoxColumn,
            this.razonSocialDataGridViewTextBoxColumn,
            this.tipoDocumentoDataGridViewTextBoxColumn,
            this.numDocumentoDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.usuarioCreacionDataGridViewTextBoxColumn,
            this.fechaCreacionDataGridViewTextBoxColumn,
            this.usuarioModificacionDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.btnEliminarFila});
            this.dgvCliente.DataSource = this.bdsClientes;
            this.dgvCliente.Location = new System.Drawing.Point(24, 131);
            this.dgvCliente.Name = "dgvCliente";
            this.dgvCliente.Size = new System.Drawing.Size(746, 180);
            this.dgvCliente.TabIndex = 1;
            this.dgvCliente.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvCliente_UserAddedRow);
            this.dgvCliente.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCliente_CellContentDoubleClick);
            this.dgvCliente.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCliente_RowLeave_1);
            this.dgvCliente.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvCliente_DataError);
            this.dgvCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCliente_CellClick);
            // 
            // tipoClienteDataGridViewTextBoxColumn
            // 
            this.tipoClienteDataGridViewTextBoxColumn.DataPropertyName = "TipoCliente";
            this.tipoClienteDataGridViewTextBoxColumn.HeaderText = "TipoCliente";
            this.tipoClienteDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "MIN",
            "MAY",
            "PRO"});
            this.tipoClienteDataGridViewTextBoxColumn.Name = "tipoClienteDataGridViewTextBoxColumn";
            this.tipoClienteDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tipoClienteDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // idZonaDataGridViewTextBoxColumn
            // 
            this.idZonaDataGridViewTextBoxColumn.DataPropertyName = "Id_Zona";
            this.idZonaDataGridViewTextBoxColumn.DataSource = this.bdsZona;
            this.idZonaDataGridViewTextBoxColumn.DisplayMember = "Descripcion";
            this.idZonaDataGridViewTextBoxColumn.HeaderText = "Id_Zona";
            this.idZonaDataGridViewTextBoxColumn.Name = "idZonaDataGridViewTextBoxColumn";
            this.idZonaDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idZonaDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.idZonaDataGridViewTextBoxColumn.ValueMember = "Id_Zona";
            // 
            // bdsZona
            // 
            this.bdsZona.DataSource = typeof(DGP.Entities.DataSet.DSEntitiesCliente.Tb_ZonaDataTable);
            // 
            // idClienteDataGridViewTextBoxColumn
            // 
            this.idClienteDataGridViewTextBoxColumn.DataPropertyName = "Id_Cliente";
            this.idClienteDataGridViewTextBoxColumn.HeaderText = "Id_Cliente";
            this.idClienteDataGridViewTextBoxColumn.Name = "idClienteDataGridViewTextBoxColumn";
            this.idClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idClienteDataGridViewTextBoxColumn.Visible = false;
            // 
            // nombresDataGridViewTextBoxColumn
            // 
            this.nombresDataGridViewTextBoxColumn.DataPropertyName = "Nombres";
            this.nombresDataGridViewTextBoxColumn.HeaderText = "Nombres";
            this.nombresDataGridViewTextBoxColumn.Name = "nombresDataGridViewTextBoxColumn";
            this.nombresDataGridViewTextBoxColumn.ToolTipText = "Nombre y Apellidos del cliente";
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            // 
            // tipoDocumentoDataGridViewTextBoxColumn
            // 
            this.tipoDocumentoDataGridViewTextBoxColumn.DataPropertyName = "TipoDocumento";
            this.tipoDocumentoDataGridViewTextBoxColumn.HeaderText = "TipoDocumento";
            this.tipoDocumentoDataGridViewTextBoxColumn.Name = "tipoDocumentoDataGridViewTextBoxColumn";
            // 
            // numDocumentoDataGridViewTextBoxColumn
            // 
            this.numDocumentoDataGridViewTextBoxColumn.DataPropertyName = "NumDocumento";
            this.numDocumentoDataGridViewTextBoxColumn.HeaderText = "NumDocumento";
            this.numDocumentoDataGridViewTextBoxColumn.Name = "numDocumentoDataGridViewTextBoxColumn";
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.Visible = false;
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
            // btnEliminarFila
            // 
            this.btnEliminarFila.HeaderText = "Eliminar";
            this.btnEliminarFila.Name = "btnEliminarFila";
            this.btnEliminarFila.Text = "Eliminar";
            // 
            // bdsClientes
            // 
            this.bdsClientes.DataSource = typeof(DGP.Entities.DataSet.DSEntitiesCliente.Tb_Cliente_ProveedorDataTable);
            this.bdsClientes.Sort = "";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(656, 331);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(114, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id_Cliente";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id_Cliente";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Nombres";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombres";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ToolTipText = "Nombre y Apellidos del cliente";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TipoCliente";
            this.dataGridViewTextBoxColumn3.HeaderText = "TipoCliente";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "RazonSocial";
            this.dataGridViewTextBoxColumn4.HeaderText = "RazonSocial";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TipoDocumento";
            this.dataGridViewTextBoxColumn5.HeaderText = "TipoDocumento";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "NumDocumento";
            this.dataGridViewTextBoxColumn6.HeaderText = "NumDocumento";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Estado";
            this.dataGridViewTextBoxColumn7.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Id_Zona";
            this.dataGridViewTextBoxColumn8.HeaderText = "Id_Zona";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "UsuarioCreacion";
            this.dataGridViewTextBoxColumn9.HeaderText = "UsuarioCreacion";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "FechaCreacion";
            this.dataGridViewTextBoxColumn10.HeaderText = "FechaCreacion";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn11.HeaderText = "UsuarioModificacion";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "FechaModificacion";
            this.dataGridViewTextBoxColumn12.HeaderText = "FechaModificacion";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // frmMantenimientoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 392);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvCliente);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMantenimientoCliente";
            this.Text = "frmMantenimientoCliente";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsZona)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvCliente;
        private System.Windows.Forms.BindingSource bdsClientes;
        private System.Windows.Forms.Button btnAceptar;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.BindingSource bdsZona;
        private System.Windows.Forms.DataGridViewComboBoxColumn tipoClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn idZonaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioCreacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCreacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminarFila;
    }
}