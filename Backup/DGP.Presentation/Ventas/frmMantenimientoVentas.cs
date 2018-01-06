using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DGP.Entities;
using DGP.Entities.Ventas;
using DGP.BusinessLogic;
using DGP.BusinessLogic.Ventas;

namespace DGP.Presentation.Ventas {

    public partial class frmMantenimientoVentas : Form {

        public frmMantenimientoVentas() {
            InitializeComponent();
            InicializarFormulario();
        }

        #region "Eventos de frmMantenimientoVentas"
        
            private void frmMantenimientoVentas_Load(object sender, EventArgs e) {
                try {
                    dgrvVentas.AutoGenerateColumns = false;
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void txtCodigoVenta_KeyPress(object sender, KeyPressEventArgs e) {
                if (Char.IsNumber(e.KeyChar)) {
                    e.Handled = false;
                } else {
                    e.Handled = true;
                }
            }

            private void btnBuscarVentas_Click(object sender, EventArgs e) {
                try {
                    BEVenta oBEVenta = ObtenerVentaBusqueda();
                    dgrvVentas.DataSource = new BLVenta().ListarVentaMantenimiento(oBEVenta);
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void dgrvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
                try {
                    object objIDVenta = dgrvVentas[0, e.RowIndex].Value;
                    frmDetalleVenta frmMantVenta = new frmDetalleVenta(Convert.ToInt32(objIDVenta));
                    frmMantVenta.ShowDialog();
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

        #endregion

        #region "Métodos de frmMantenimientoVentas"

            private void InicializarFormulario() {
                LimpiarFiltrosBusqueda();
                CargarTipoDocumento();
                CargarCliente();
                CargarProducto();
                CargarEmpresa();
            }

            private void LimpiarFiltrosBusqueda() {
                txtCodigoVenta.Text = string.Empty;
                DGP_Util.LiberarComboBox(cbTipoDocumento);
                txtNroDocumento.Text = string.Empty;
                DGP_Util.LiberarComboBox(cbCliente);
                DGP_Util.LiberarComboBox(cbProducto);
                DGP_Util.LiberarComboBox(cbEmpresa);
                DGP_Util.SetDateTimeNow(dtpFechaInicial);
                DGP_Util.SetDateTimeNow(dtpFechaFinal);
                DGP_Util.LiberarGridView(dgrvVentas);
            }

            private void CargarTipoDocumento() {
                List<BEParametroDetalle> vLista = new List<BEParametroDetalle>();
                BEParametroDetalle oBEParametroDetalle = new BEParametroDetalle();
                oBEParametroDetalle.IdParametro = eParametro.TipoDocumento_Venta.GetHashCode();
                vLista = new BLParametroDetalle().Listar(oBEParametroDetalle);
                vLista.Insert(0, new BEParametroDetalle("0", "Todos"));
                cbTipoDocumento.DataSource = vLista;
                cbTipoDocumento.DisplayMember = "Texto";
                cbTipoDocumento.ValueMember = "Valor";
            }

            private void CargarCliente() {
                List<BEClienteProveedor> vListaCliente = new List<BEClienteProveedor>();
                vListaCliente = new BLClienteProveedor().Listar(new BEClienteProveedor());
                vListaCliente.Insert(0, new BEClienteProveedor(0, "CE : Cliente Eventual"));
                vListaCliente.Insert(0, new BEClienteProveedor(-1, "Todos"));
                cbCliente.DataSource = vListaCliente;
                cbCliente.DisplayMember = "Nombre";
                cbCliente.ValueMember = "IdCliente";
            }

            private void CargarProducto() {
                List<BEProducto> vLista = new List<BEProducto>();
                vLista = new BLProducto().Listar(new BEProducto());
                vLista.Insert(0, new BEProducto(0, "Todos"));
                cbProducto.DataSource = vLista;
                cbProducto.DisplayMember = "Nombre";
                cbProducto.ValueMember = "IdProducto";
            }

            private void CargarEmpresa() {
                List<BEEmpresa> vLista = new List<BEEmpresa>();
                vLista = new BLEmpresa().Listar(new BEEmpresa());
                vLista.Insert(0, new BEEmpresa(0, "Todos"));
                cbEmpresa.DataSource = vLista;
                cbEmpresa.DisplayMember = "RazonSocial";
                cbEmpresa.ValueMember = "IdEmpresa";
            }

            private void MostrarMensaje(string pMensaje, MessageBoxIcon pMsgBoxicon) {
                MessageBox.Show(pMensaje, "DGP", MessageBoxButtons.OK, pMsgBoxicon);
            }

            private BEVenta ObtenerVentaBusqueda() {
                BEVenta oBEVenta = new BEVenta();
                oBEVenta.IdVenta = string.IsNullOrEmpty(txtCodigoVenta.Text) ? 0 : int.Parse(txtCodigoVenta.Text);
                oBEVenta.IdTipoDocumentoVenta = (cbTipoDocumento.SelectedIndex == 0) ? string.Empty : cbTipoDocumento.SelectedValue.ToString();
                oBEVenta.NumeroDocumento = string.IsNullOrEmpty(txtNroDocumento.Text) ? string.Empty : txtNroDocumento.Text;
                oBEVenta.IdCliente = (cbCliente.SelectedIndex == 0) ? -1 : Convert.ToInt32(cbCliente.SelectedValue);
                oBEVenta.IdProducto = (cbProducto.SelectedIndex == 0) ? 0 : Convert.ToInt32(cbProducto.SelectedValue);
                oBEVenta.IdEmpresa = (cbEmpresa.SelectedIndex == 0) ? 0 : Convert.ToInt32(cbEmpresa.SelectedValue);
                oBEVenta.FechaInicio = dtpFechaInicial.Value.Date;
                oBEVenta.FechaFin = dtpFechaFinal.Value.Date;
                return oBEVenta;
            }

        #endregion

    }
}