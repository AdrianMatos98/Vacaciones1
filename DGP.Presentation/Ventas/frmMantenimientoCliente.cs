using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DGP.Entities.DataSet.DSEntitiesClienteTableAdapters;
using DGP.Entities.DataSet;

namespace DGP.Presentation.Ventas
{
    public partial class frmMantenimientoCliente : Form
    {
        private DGP.Entities.DataSet.DSEntitiesCliente.Tb_Cliente_ProveedorDataTable dt;
        private int filaAgregada = -1;
        public frmMantenimientoCliente()
        {

            InitializeComponent();
            Tb_ZonaTableAdapter zonaAdapter = new Tb_ZonaTableAdapter();
            this.bdsZona.DataSource = zonaAdapter.GetData();
            load();
        }
        private void refresh()
        {
            
            this.bdsClientes.DataSource = dt;

            this.dgvCliente.Refresh();
        
        }
        private void load()
        {
            Tb_Cliente_ProveedorTableAdapter ClienteAdapter = new Tb_Cliente_ProveedorTableAdapter();
            dt = ClienteAdapter.GetData();

            this.bdsClientes.DataSource = dt;

            this.dgvCliente.Refresh();
        
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            try
            {
                Tb_Cliente_ProveedorTableAdapter ClienteAdapter = new Tb_Cliente_ProveedorTableAdapter();

                ClienteAdapter.Update(this.dt);

                dt.AcceptChanges();

                this.load();

            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message, "btnAceptar_Click");
            }
           
           
        }

        private void dgvCliente_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                Exception exec = e.Exception;
                DataGridViewComboBoxColumn cc = new DataGridViewComboBoxColumn();
               // cc.

            }
            catch (Exception ex)
            {
                
                //throw ex;
            }
        }

        private void dgvCliente_BindingContextChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvCliente_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           //flagFilaNueva = true;
        }

      

    
        private void dgvCliente_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                //string x = e.Row.Cells["nombresDataGridViewTextBoxColumn"].Value.ToString();
                filaAgregada = e.Row.Index;

            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message, "dgvCliente_UserAddedRow");
            }
            

        }

        private void dgvCliente_RowLeave_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (filaAgregada > 0 && !dt.existeFilaAgregada(filaAgregada))
                {
                    string mensajeError = string.Empty;
                    if (!validarEdicionFila(ref mensajeError))
                    {
                        MessageBox.Show(this, mensajeError);

                        dgvCliente.Focus();
                        dgvCliente.Rows[filaAgregada - 1].Selected = true;
                        return;

                    }

                    //DataGridViewCell
                    object objTipoCliente = this.dgvCliente.Rows[filaAgregada - 1].Cells["tipoClienteDataGridViewTextBoxColumn"].Value;
                    object objIdZona = this.dgvCliente.Rows[filaAgregada - 1].Cells["idZonaDataGridViewTextBoxColumn"].Value;
                    //object objIdCliente = this.dgvCliente.Rows[filaAgregada - 1].Cells["idClienteDataGridViewTextBoxColumn"].Value;
                    object objNombres = this.dgvCliente.Rows[filaAgregada - 1].Cells["nombresDataGridViewTextBoxColumn"].Value;
                    object objRazonSocial = this.dgvCliente.Rows[filaAgregada - 1].Cells["razonSocialDataGridViewTextBoxColumn"].Value;

                    object objTipoDocumento = this.dgvCliente.Rows[filaAgregada - 1].Cells["tipoDocumentoDataGridViewTextBoxColumn"].Value;
                    object objNumDocumento = this.dgvCliente.Rows[filaAgregada - 1].Cells["numDocumentoDataGridViewTextBoxColumn"].Value;
                    object objEstado = this.dgvCliente.Rows[filaAgregada - 1].Cells["estadoDataGridViewTextBoxColumn"].Value;
                    DSEntitiesCliente.Tb_Cliente_ProveedorRow row = dt.NewTb_Cliente_ProveedorRow();

                    row.TipoCliente = objTipoCliente.ToString();
                    row.Id_Zona = int.Parse(objIdZona.ToString()); //(objIdZona == null) ? 0 : int.Parse(objIdZona.ToString()); 
                    row.Id_Cliente = dt.maxIdCliente() + 1; //-1*row.Table.Rows.Count;
                    row.Nombres = objNombres.ToString();
                    row.FilaAgregada = filaAgregada;

                    if (objNumDocumento == null) row.SetNumDocumentoNull();
                    else row.NumDocumento = objNumDocumento.ToString(); //objNumDocumento.Value;

                    if (objTipoDocumento == null) row.SetTipoDocumentoNull();
                    else row.TipoDocumento = objTipoDocumento.ToString(); //objNumDocumento.Value;

                    row.Estado = 1;
                    dt.AddTb_Cliente_ProveedorRow(row);

                    filaAgregada = -1;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message, "dgvCliente_RowLeave_1");
                
            }
            
        }

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    switch (dgvCliente[e.ColumnIndex, e.RowIndex].OwningColumn.Name)
                    {
                        case "btnEliminarFila":
                            eliminarFila(e.RowIndex);
                            break;
                        default:
                            break;
                    }


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message, "dgvCliente_CellClick");
            }
            
            
        }
        private bool validarEdicionFila(ref string mensaje)
        {
            object objTipoCliente = this.dgvCliente.Rows[filaAgregada - 1].Cells["tipoClienteDataGridViewTextBoxColumn"].Value;
            object objIdZona = this.dgvCliente.Rows[filaAgregada - 1].Cells["idZonaDataGridViewTextBoxColumn"].Value;
            //object objIdCliente = this.dgvCliente.Rows[filaAgregada - 1].Cells["idClienteDataGridViewTextBoxColumn"].Value;
            object objNombres = this.dgvCliente.Rows[filaAgregada - 1].Cells["nombresDataGridViewTextBoxColumn"].Value;
            //object objRazonSocial = this.dgvCliente.Rows[filaAgregada - 1].Cells["razonSocialDataGridViewTextBoxColumn"].Value;

            //object objTipoDocumento = this.dgvCliente.Rows[filaAgregada - 1].Cells["tipoDocumentoDataGridViewTextBoxColumn"].Value;
            //object objNumDocumento = this.dgvCliente.Rows[filaAgregada - 1].Cells["numDocumentoDataGridViewTextBoxColumn"].Value;
            //object objEstado = this.dgvCliente.Rows[filaAgregada - 1].Cells["estadoDataGridViewTextBoxColumn"].Value;
            string strFila= string.Empty;
            if (objTipoCliente == null || objTipoCliente.ToString() == string.Empty) strFila += ", Tipo Cliente";
            if (objIdZona == null || objIdZona.ToString() == string.Empty) strFila += ", Zona";
            if (objNombres == null || objNombres.ToString() == string.Empty) strFila += ", Nombres";

            if (strFila == string.Empty)
            {
                mensaje = string.Empty;
                return true;

            }
            else
            {

                mensaje = "Los Siguientes campos son obligatorios" + strFila + ".";
                return false;
            
            }

                
        
        }
        private void eliminarFila(int fila)
        {
            DataRowView drvFila = (DataRowView )this.dgvCliente.Rows[fila].DataBoundItem;
            DSEntitiesCliente.Tb_Cliente_ProveedorRow row = (DSEntitiesCliente.Tb_Cliente_ProveedorRow)drvFila.Row;
            if (row != null)
            {
                row.Delete();

            }
            else
            {
                this.dgvCliente.EndEdit();

            
            }
            this.refresh();
        
        }

        private void dgvCliente_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataRowView drvFila = (DataRowView)this.dgvCliente.Rows[e.RowIndex].DataBoundItem;
                    DSEntitiesCliente.Tb_Cliente_ProveedorRow row = (DSEntitiesCliente.Tb_Cliente_ProveedorRow)drvFila.Row;

                    frmProductoCliente obj = new frmProductoCliente(row);
                    obj.ShowDialog();



                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message, "dgvCliente_CellClick");
            }
        }

        private void dgvCliente_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataRowView drvFila = (DataRowView)this.dgvCliente.Rows[e.RowIndex].DataBoundItem;
                    DSEntitiesCliente.Tb_Cliente_ProveedorRow row = (DSEntitiesCliente.Tb_Cliente_ProveedorRow)drvFila.Row;

                    frmProductoCliente obj = new frmProductoCliente(row);
                    obj.ShowDialog();



                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message, "dgvCliente_CellClick");
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Tb_Cliente_ProveedorTableAdapter ClienteAdapter = new Tb_Cliente_ProveedorTableAdapter();
                dt = ClienteAdapter.GetDataBy(this.txtCliente.Text);

                this.bdsClientes.DataSource = dt;

                this.dgvCliente.Refresh();

            }
            catch (Exception ex)
            {
                
                throw;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}