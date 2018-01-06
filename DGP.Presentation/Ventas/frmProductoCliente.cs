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
    public partial class frmProductoCliente : Form
    {
        private DSEntitiesCliente.Tb_Prod_x_ClienteDataTable dtProductoCliente;
        private DSEntitiesCliente.Tb_Cliente_ProveedorRow rowClienteProveedor;
        private int filaAgregada = -1;
        public frmProductoCliente(DSEntitiesCliente.Tb_Cliente_ProveedorRow rowClienteProveedor)
        {
            this.rowClienteProveedor = rowClienteProveedor;
            InitializeComponent();
            this.txtCliente.Text = this.rowClienteProveedor.Nombres;
            loadProducto();
            loadProductoClientes();

        }
        private void loadProducto()
        {
            //Tb_Prod_x_ClienteTableAdapter ClienteProveedorAdapter = new Tb_Prod_x_ClienteTableAdapter();
            //dtProductoCliente = ClienteProveedorAdapter.GetData();

            this.bdsProductos.DataSource = (new DGP.BusinessLogic.BLProducto()).Listar(new DGP.Entities.BEProducto());
            this.loadProductoClientes();
            //this.dgvProductoCliente.Refresh();


        }
        private void loadProductoClientes()
        {
            Tb_Prod_x_ClienteTableAdapter ClienteProveedorAdapter = new Tb_Prod_x_ClienteTableAdapter();
            dtProductoCliente = ClienteProveedorAdapter.GetData(this.rowClienteProveedor.Id_Cliente);

            this.bdsProductosClientes.DataSource = dtProductoCliente;

            //this.dgvProductoCliente.Refresh();
        
        
        }

        private void dgvProductoCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Tb_Prod_x_ClienteTableAdapter ClienteAdapter = new Tb_Prod_x_ClienteTableAdapter();

                ClienteAdapter.Update(this.dtProductoCliente);

                dtProductoCliente.AcceptChanges();

                this.loadProductoClientes();
            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message, "dgvProductoCliente_UserAddedRow");
            }

        }
        private void dgvProductoCliente_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                //string x = e.Row.Cells["nombresDataGridViewTextBoxColumn"].Value.ToString();
                filaAgregada = e.Row.Index;

            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message, "dgvProductoCliente_UserAddedRow");
            }


        }

        private void dgvProductoCliente_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (filaAgregada > 0 && !dtProductoCliente.existeFilaAgregada(filaAgregada))
                {
                    string mensajeError = string.Empty;
                    if (!validarEdicionFila(ref mensajeError))
                    {
                        MessageBox.Show(this, mensajeError);

                        dgvProductoCliente.Focus();
                        dgvProductoCliente.Rows[filaAgregada - 1].Selected = true;
                        return;

                    }

                    //DataGridViewCell
                    //object objIdCliente = this.rowClienteProveedor.Id_Cliente;
                    object objIdProducto =this.dgvProductoCliente.Rows[filaAgregada - 1].Cells["idProductoDataGridViewTextBoxColumn"].Value;
                    object objTara = this.dgvProductoCliente.Rows[filaAgregada - 1].Cells["taraDataGridViewTextBoxColumn"].Value;
                    object objPrecioCompra = this.dgvProductoCliente.Rows[filaAgregada - 1].Cells["PrecioCompraDataGridViewTextBoxColumn"].Value;

                    object objMargen = this.dgvProductoCliente.Rows[filaAgregada - 1].Cells["margenDataGridViewTextBoxColumn"].Value;
                    object objPrecioVenta = this.dgvProductoCliente.Rows[filaAgregada - 1].Cells["precioVentaDataGridViewTextBoxColumn"].Value;
                    
                    DSEntitiesCliente.Tb_Prod_x_ClienteRow row = this.dtProductoCliente.NewTb_Prod_x_ClienteRow();  

                    row.Id_Cliente = this.rowClienteProveedor.Id_Cliente;
                    row.Id_Producto = int.Parse(objIdProducto.ToString()); //(objIdZona == null) ? 0 : int.Parse(objIdZona.ToString()); 
                    row.Id_ProductoCliente = this.dtProductoCliente.maxId() + 1; //-1*row.Table.Rows.Count;
                    row.Tara = decimal.Parse(objTara.ToString());
                    row.PrecioCompra = decimal.Parse(objPrecioCompra.ToString());
                    row.Margen = decimal.Parse(objMargen.ToString());
                    row.PrecioVenta = decimal.Parse(objPrecioVenta.ToString());
                    
                    row.FilaAgregada = filaAgregada;

                   
                    //row.Estado = 1;
                    this.dtProductoCliente.AddTb_Prod_x_ClienteRow(row);

                    filaAgregada = -1;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message, "dgvProductoCliente_RowLeave_1");

            }
        }
        private bool validarEdicionFila(ref string mensaje)
        {
            object objIdProducto = this.dgvProductoCliente.Rows[filaAgregada - 1].Cells["idProductoDataGridViewTextBoxColumn"].Value;
            object objTara = this.dgvProductoCliente.Rows[filaAgregada - 1].Cells["taraDataGridViewTextBoxColumn"].Value;
            object objPrecioCompra = this.dgvProductoCliente.Rows[filaAgregada - 1].Cells["PrecioCompraDataGridViewTextBoxColumn"].Value;

            object objMargen = this.dgvProductoCliente.Rows[filaAgregada - 1].Cells["margenDataGridViewTextBoxColumn"].Value;
            object objPrecioVenta = this.dgvProductoCliente.Rows[filaAgregada - 1].Cells["precioVentaDataGridViewTextBoxColumn"].Value;
                    
            string strFila = string.Empty;
            if (objIdProducto == null || objIdProducto.ToString() == string.Empty) strFila += ", Producto";
            if (objTara == null || objTara.ToString() == string.Empty) strFila += ", Tara";
            if (objPrecioCompra == null || objPrecioCompra.ToString() == string.Empty) strFila += ", Precio Compra";

            if (objMargen == null || objMargen.ToString() == string.Empty) strFila += ", Margen";
            if (objPrecioVenta == null || objPrecioVenta.ToString() == string.Empty) strFila += ", Precio Venta";

            string filtro = "Id_Producto = " +( (objIdProducto != null)?objIdProducto.ToString():"-1");
            if (this.dtProductoCliente.Select(filtro, "").Length > 0)
            {
                strFila += ", el producto ya se encuentra registrado";
            }
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

        private void calcular(int rowIndex)
        {
            //object objTara = this.dgvProductoCliente.Rows[filaAgregada - 1].Cells["taraDataGridViewTextBoxColumn"].Value;
            object objPrecioCompra = this.dgvProductoCliente.Rows[rowIndex].Cells["PrecioCompraDataGridViewTextBoxColumn"].Value;
            object objMargen = this.dgvProductoCliente.Rows[rowIndex].Cells["margenDataGridViewTextBoxColumn"].Value;
            object objPrecioVenta = this.dgvProductoCliente.Rows[rowIndex].Cells["precioVentaDataGridViewTextBoxColumn"].Value;
            bool flag = false;
            decimal precioCompra = 0;
            decimal margen= 0 ;
            decimal precioVenta= 0;

            flag = decimal.TryParse(objPrecioCompra == null? "0": objPrecioCompra.ToString(), out precioCompra);
            flag = decimal.TryParse(objMargen == null ? "0" : objMargen.ToString(), out margen);
            //flag = decimal.TryParse(objPrecioVenta == null ? "0" : objPrecioVenta.ToString(), out precioVenta);

            this.dgvProductoCliente.Rows[rowIndex].Cells["PrecioCompraDataGridViewTextBoxColumn"].Value = precioCompra;
            this.dgvProductoCliente.Rows[rowIndex].Cells["margenDataGridViewTextBoxColumn"].Value = margen;
            this.dgvProductoCliente.Rows[rowIndex].Cells["precioVentaDataGridViewTextBoxColumn"].Value = precioCompra + margen ;
            



                    
        
        }

        private void dgvProductoCliente_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    calcular(e.RowIndex);

                }
               
            }
            catch (Exception ex)
            {
                throw ex;


               // MessageBox.Show(this, ex.Message, "dgvProductoCliente_RowLeave_1");
            }
        }
    }
}