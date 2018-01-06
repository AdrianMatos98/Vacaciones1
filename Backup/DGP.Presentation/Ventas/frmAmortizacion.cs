using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DGP.BusinessLogic.Seguridad;
using DGP.BusinessLogic.Ventas;
using DGP.Entities.Seguridad;
using DGP.Entities.Ventas;
using DGP.BusinessLogic;
using DGP.Entities;

namespace DGP.Presentation.Ventas {

    public partial class frmAmortizacion : Form {

        DataGridViewCellStyle oCeldaPagoCuenta = null;
        frmTableroElectronico _frmTableroElectronico = null;
        public frmAmortizacion() {
            InitializeComponent();
            InicializarFormulario();
        }
        public frmAmortizacion(int IdCliente, frmTableroElectronico frmTableroElectronico)
        {
            InitializeComponent();
            InicializarFormulario();
            this._frmTableroElectronico = frmTableroElectronico;
            //this.cbCliente.Refresh();
            //this.cbCliente.SelectedValue= (object)IdCliente;
        }
        public void SetCliente(int IdCliente , int IdProducto)
        {
            this.cbCliente.SelectedValue = IdCliente;
            this.CargarAmortizaciones(IdCliente, IdProducto);
          
        
        
        }
        public void mensajeSalida()
        {
            if (_frmTableroElectronico != null)
            {
                _frmTableroElectronico.refrescar();
            
            
            }
        
        }

        #region "Eventos de frmAmortizacion.aspx"
        
            private void frmAmortizacion_Load(object sender, EventArgs e) {
                try {
                    dgrvAmortizacion.AutoGenerateColumns = false;
                    lblSimboloMoneda.Text = VariablesSession.ISOCulture.NumberFormat.CurrencySymbol;
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void cbCliente_SelectedIndexChanged(object sender, EventArgs e) {
                try {
                    int intIdCliente = 0;
                    if (cbCliente.SelectedIndex > 0) {
                        int.TryParse(cbCliente.SelectedValue.ToString(), out intIdCliente);
                        CargarProductoCliente(intIdCliente);
                        DGP_Util.EnabledComboBox(cbProducto, true);
                        CargarAmortizaciones(Convert.ToInt32(cbCliente.SelectedValue), 0);
                        DGP_Util.EnableControl(nudPrecioAmortizacion, true);
                    } else {
                        ResetearFormulario();
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void cbProducto_SelectedIndexChanged(object sender, EventArgs e) {
                try {
                    int intIdCliente = 0;
                    int intIdProducto = 0;
                    int.TryParse(cbCliente.SelectedValue.ToString(), out intIdCliente);
                    if (cbProducto.SelectedIndex > 0) {
                        intIdProducto = Convert.ToInt32(cbProducto.SelectedValue);
                        CargarAmortizaciones(intIdCliente, intIdProducto);
                    } else {
                        CargarAmortizaciones(intIdCliente, 0);
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void btnAplicarMonto_Click(object sender, EventArgs e) {
                try {

                    decimal montoTotal = this.nudPrecioAmortizacion.Value;
                    decimal montoAcarreo = 0;
                    foreach (DataGridViewRow vRow in dgrvAmortizacion.Rows) {
                        if (montoAcarreo >= montoTotal) break;

                        object oIndicador = vRow.Cells[ePosicionCol.Indicador.GetHashCode()].Value;
                        string sEstado = vRow.Cells[ePosicionCol.IdEstado.GetHashCode()].Value.ToString();
                    
                        if (oIndicador.ToString() == "1" && sEstado == BEVenta.REGISTRADO) {
                            
                            decimal montoSaldo = 0;       
                            decimal.TryParse(vRow.Cells[ePosicionCol.Saldo.GetHashCode()].Value.ToString() , out montoSaldo);
                            decimal delta = montoTotal - montoAcarreo;
                            decimal montoAmortizar = (delta >= montoSaldo) ? montoSaldo : montoTotal - montoAcarreo;
                            vRow.Cells[ePosicionCol.Pago.GetHashCode()].Value = montoAmortizar.ToString();
                            montoAcarreo = montoAcarreo + montoAmortizar;
                        }
                       
                    }



                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void dgrvAmortizacion_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
                string strMensaje = string.Empty;
                if (!ValidarCampos(ref strMensaje, e.RowIndex, e.ColumnIndex)) {
                    MostrarMensaje(strMensaje, MessageBoxIcon.Exclamation);
                }
            }

            private void btnGrabar_Click(object sender, EventArgs e) {
                string strMensaje = string.Empty;
                bool bCancelarVenta = false;
                try {
                    if (ValidarFormularioAmortizacion(ref strMensaje)) {
                        int intIdUsuario = 0;
                        bool boIndicador = true;
                        int.TryParse(cbUsuario.SelectedValue.ToString(), out intIdUsuario);
                        if (intIdUsuario > 0 && intIdUsuario != VariablesSession.BEUsuarioSession.IdPersonal) {
                            boIndicador = (MessageBox.Show("La amortización se va a registrar con otro usuario, desea continuar?", "DGP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                        }
                        if (boIndicador) {
                            // Obtener las Amortizaciones

                            List<BEAmortizacionVenta> vLista = ObtenerAmortizaciones(boIndicador);
                            int intResultado = 0;
                            intResultado = new BLAmortizacionVenta().Insertar(vLista);
                            if (intResultado == 1) {
                                MostrarMensaje("Se registró la amortización correctamente", MessageBoxIcon.Information);
                                int intIdCliente = Convert.ToInt32(cbCliente.SelectedValue);
                                int intIdProducto = Convert.ToInt32(cbProducto.SelectedValue);
                                CargarAmortizaciones(intIdCliente, intIdProducto);
                            } else {
                                MostrarMensaje("No se pudo registrar la venta, intentelo de nuevo", MessageBoxIcon.Exclamation);                        
                            }                        
                        }                        
                    } else {
                        MostrarMensaje(strMensaje, MessageBoxIcon.Exclamation);
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void btnCancelar_Click(object sender, EventArgs e) {
                try {
                    ResetearFormulario();
                    InicializarFormulario();
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

        #endregion

        #region "Métodos de frmAmortizacion"

            private void MostrarMensaje(string pMensaje, MessageBoxIcon pMsgBoxicon) {
                MessageBox.Show(pMensaje, "DGP", MessageBoxButtons.OK, pMsgBoxicon);
            }

            private void InicializarFormulario() {
                DGP_Util.LiberarComboBox(cbCliente);
                DGP_Util.EnabledComboBox(cbCliente, true);
                DGP_Util.LiberarComboBox(cbProducto);
                DGP_Util.EnabledComboBox(cbProducto, false);
                //DGP_Util.EnableControl(nudPrecioAmortizacion, false);
                //DGP_Util.EnableControl(btnAplicarMonto, false);
                DGP_Util.EnableControl(btnGrabar, false);
                DGP_Util.EnableControl(btnCancelar, false);
                LimpiarFormulario();
                CargarCliente();
                // Definir al Usuario
                CargarUsuarios();
                dtpFechaPago.Value = DateTime.Now.Date;
                cbUsuario.SelectedValue = VariablesSession.BEUsuarioSession.IdPersonal;
            }

            private void CargarCliente() {
                List<BEClienteProveedor> vListaCliente = new List<BEClienteProveedor>();
                BEClienteProveedor oTemp = new BEClienteProveedor();
                oTemp.IdZona = 0;
                vListaCliente = new BLClienteProveedor().Listar(oTemp);
                //vListaCliente.Insert(0, new BEClienteProveedor(0, "CE : Cliente Eventual"));
                vListaCliente.Insert(0, new BEClienteProveedor(0, "--------Todos--------"));
                cbCliente.DataSource = vListaCliente;
                cbCliente.DisplayMember = "Nombre";
                cbCliente.ValueMember = "IdCliente";
            }

            private void ResetearFormulario() {
                if (cbProducto.DataSource != null) {
                    DGP_Util.LiberarComboBox(cbProducto);                    
                }
                DGP_Util.EnabledComboBox(cbProducto, false);
                //DGP_Util.EnableControl(nudPrecioAmortizacion, false);
                //DGP_Util.EnableControl(btnAplicarMonto, false);
                DGP_Util.EnableControl(btnGrabar, false);
                DGP_Util.EnableControl(btnCancelar, false);
                DGP_Util.LiberarGridView(dgrvAmortizacion);
                LimpiarFormulario();
            }

            private void LimpiarFormulario() {
                nudPrecioAmortizacion.Value = 1;
            }

            private void CargarProductoCliente(int pIdCliente) {
                List<BEProducto> vLista = new List<BEProducto>();
                vLista = new BLVenta().ListarProductoCliente(pIdCliente);
                vLista.Insert(0, new BEProducto(0, "Todos"));
                cbProducto.DataSource = vLista;
                cbProducto.DisplayMember = "Nombre";
                cbProducto.ValueMember = "IdProducto";
            }

            private void CargarUsuarios() { 
                List<BEPersonal> vLista = new BLPersonal().ListarPersonal(new BEPersonal());
                cbUsuario.DataSource = vLista;
                cbUsuario.DisplayMember = "Login";
                cbUsuario.ValueMember = "IdPersonal";
            }

            private void CargarAmortizaciones(int pIdCliente, int pIdProducto) {
                VistaAmortizacion oEntidad = new VistaAmortizacion();
                oEntidad.IdCliente = pIdCliente;
                oEntidad.IdProducto = pIdProducto;
                List<VistaAmortizacion> vLista = new List<VistaAmortizacion>();
                vLista = new BLAmortizacionVenta().Listar(oEntidad);
                dgrvAmortizacion.DataSource = vLista;
                // Validar Controles
                if (vLista.Count > 0) {
                    DGP_Util.EnableControl(btnGrabar, true);
                    DGP_Util.EnableControl(btnCancelar, true);
                } else {
                    DGP_Util.EnableControl(btnGrabar, false);
                    DGP_Util.EnableControl(btnCancelar, false);
                }
                // Habilitar solamente las Ventas
                oCeldaPagoCuenta = new DataGridViewCellStyle();
                oCeldaPagoCuenta.SelectionBackColor = Color.Silver;
                oCeldaPagoCuenta.BackColor = Color.Silver;
                foreach (DataGridViewRow vRow in dgrvAmortizacion.Rows) {
                    // Obtener Indicador
                    object oIndicador = vRow.Cells[ePosicionCol.Indicador.GetHashCode()].Value;
                    if (oIndicador.ToString() == "0") {
                        vRow.Cells[ePosicionCol.Cantidad.GetHashCode()].Value = "";
                        vRow.Cells[ePosicionCol.PesoNeto.GetHashCode()].Value = "";
                        vRow.Cells[ePosicionCol.Saldo.GetHashCode()].Value = "";
                        vRow.Cells[ePosicionCol.Pago.GetHashCode()].Value = "";
                        vRow.Cells[ePosicionCol.Pago.GetHashCode()].ReadOnly = true;
                        vRow.Cells[ePosicionCol.Pago.GetHashCode()].Style = oCeldaPagoCuenta;
                    }
                }
            }

            private bool ValidarFormularioAmortizacion(ref string pMensaje) {
                bool boResultado = true;
                int intCantidad = 0;
                bool bExisteCancelar = false;
                foreach (DataGridViewRow vRow in dgrvAmortizacion.Rows) { 
                    // Obtener el indicador
                    object oIndicador = vRow.Cells[ePosicionCol.Indicador.GetHashCode()].Value;
                    if (oIndicador.ToString() == "1") {
                        // Obtener el Pago a Cuenta
                        decimal decPagoCuenta = decimal.Zero;
                        object oPagoCuenta = vRow.Cells[ePosicionCol.Pago.GetHashCode()].Value;
                        if (oPagoCuenta != null && !string.IsNullOrEmpty(oPagoCuenta.ToString())) {
                            intCantidad++;
                        }
                        //obtener el checkbox cancelado
                        bExisteCancelar = bExisteCancelar || ((bool)vRow.Cells[ePosicionCol.Cancelar.GetHashCode()].Value);
                        
                    }
                }
                if (intCantidad <= 0) {
                    pMensaje = "Debe ingresar como mínimo un pago";
                    boResultado = false;
                }
                //if (bExisteCancelar)
                //{
                //    pMensaje = "Debe ingresar como mínimo un pago";
                //    boResultado = false;
                //}
                return boResultado;
            }

            private bool ValidarCampos(ref string pMensaje, int pRowIndex, int pColumnIndex) {
                bool boResultado = true;
                try {
                    switch ((ePosicionCol)pColumnIndex) {
                        case ePosicionCol.Pago:
                            // Validar campo vacio y valor
                            if (!ValidarPagoCuenta(ref pMensaje, pRowIndex)) {
                                boResultado = false;
                                dgrvAmortizacion[pColumnIndex, pRowIndex].Value = "";
                                dgrvAmortizacion.CancelEdit();
                            }
                            break;
                    }
                } catch (Exception ex) {
                    pMensaje = ex.Message;
                    boResultado = false;
                }
                return boResultado;
            }

            private bool ValidarPagoCuenta(ref string pMensaje, int pRowIndex) {
                bool boIndicador = true;
                object oPagoCuenta = dgrvAmortizacion[ePosicionCol.Pago.GetHashCode(), pRowIndex].Value;
                if (oPagoCuenta == null || string.IsNullOrEmpty(oPagoCuenta.ToString())) {
                    boIndicador = true;
                } else {
                    // Validar los decimales
                    //if (DGP_Util.ValidarDigitosDecimales(oPagoCuenta.ToString())) {
                    // Validar que sea de tipo decimal
                    decimal decPagoCuenta = decimal.Zero;
                    decimal.TryParse(oPagoCuenta.ToString(), out decPagoCuenta);
                    if (decPagoCuenta <= decimal.Zero) {
                        boIndicador = false;
                        pMensaje = "Ingresar pago cuenta válido";
                    }
                    //} else {
                    //    boIndicador = false;
                    //    pMensaje = "Ingresar pago cuenta con dos(2) decimales";
                    //}
                }
                return boIndicador;
            }

            private List<BEAmortizacionVenta> ObtenerAmortizaciones(bool pIndicadorUsuario ) {
                List<BEAmortizacionVenta> vLista = new List<BEAmortizacionVenta>();
                BEAmortizacionVenta oBEAmortizacionVenta = null;
                //pCancelarVenta = false;
                //bool tempCancelar = false;

                foreach (DataGridViewRow vRow in dgrvAmortizacion.Rows) {
                    // Obtener el indicador
                    object oIndicador = vRow.Cells[ePosicionCol.Indicador.GetHashCode()].Value;
                    if (oIndicador.ToString() == "1") {
                        // Obtener el Pago a Cuenta
                        decimal decPagoCuenta = decimal.Zero;
                        object oPagoCuenta = vRow.Cells[ePosicionCol.Pago.GetHashCode()].Value;
                        if (oPagoCuenta != null && !string.IsNullOrEmpty(oPagoCuenta.ToString())) {
                            decPagoCuenta = Convert.ToDecimal(oPagoCuenta);
                            // Obtener los demas Valores de la fila
                            int intIdVenta = 0;
                            int intIdProducto = 0;
                            int intIdCliente = 0;
                            intIdVenta = Convert.ToInt32(vRow.Cells[ePosicionCol.IdVenta.GetHashCode()].Value);
                            intIdProducto = Convert.ToInt32(vRow.Cells[ePosicionCol.IdProducto.GetHashCode()].Value);
                            intIdCliente = Convert.ToInt32(cbCliente.SelectedValue);
                            oBEAmortizacionVenta = new BEAmortizacionVenta();
                            oBEAmortizacionVenta.Monto = decPagoCuenta;
                            oBEAmortizacionVenta.NroDocumento = string.Empty;
                            oBEAmortizacionVenta.IdFormaPago = BEAmortizacionVenta.FORMAPAGO_EFECTIVO;
                            oBEAmortizacionVenta.IdTipoAmortizacion = BEAmortizacionVenta.TIPOAMORTIZACION_AMORTIZACION;
                            oBEAmortizacionVenta.Observacion = string.Empty;
                            oBEAmortizacionVenta.IdEstado = BEAmortizacionVenta.ESTADO_REGISTRADO;
                            oBEAmortizacionVenta.IdVenta = intIdVenta;
                            oBEAmortizacionVenta.IdCliente = intIdCliente;
                            oBEAmortizacionVenta.FechaPago = dtpFechaPago.Value.Date;
                            oBEAmortizacionVenta.IdPersonal = (pIndicadorUsuario) ? int.Parse(cbUsuario.SelectedValue.ToString()) : VariablesSession.BEUsuarioSession.IdPersonal;
                            oBEAmortizacionVenta.BEUsuarioLogin = VariablesSession.BEUsuarioSession;
                            //tempCancelar = Convert.ToBoolean( vRow.Cells[ePosicionCol.Cancelar.GetHashCode()].Value );
                            oBEAmortizacionVenta.CancelarVenta = Convert.ToBoolean(vRow.Cells[ePosicionCol.Cancelar.GetHashCode()].Value);
                            vLista.Add(oBEAmortizacionVenta);
                        }
                    }
                }
                return vLista;
            }

        #endregion

        private enum ePosicionCol { 
            Indicador = 0
            ,IdVenta = 1
            ,IdProducto = 2
            ,Cantidad = 7
            ,PesoNeto = 8
            ,Importe = 9
            ,Saldo = 10
            ,Pago = 11
            ,Cancelar = 12
            ,IdEstado = 14
        }

        private void dgrvAmortizacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex>-1 && e.ColumnIndex>-1)
                {

                    if ( this.dgrvAmortizacion.Columns[e.ColumnIndex].Name == "dgvBtnEliminar" )
                    {
                        VistaAmortizacion vistaAmortizacion = (VistaAmortizacion)this.dgrvAmortizacion.Rows[e.RowIndex].DataBoundItem;

                        if (vistaAmortizacion.IdAmortizacion > 0)//esto para saltar las ventas
                        {
                            BEAmortizacionVenta bean = new BEAmortizacionVenta();
                            bean.IdAmortizacionVenta = vistaAmortizacion.IdAmortizacion;
                            bean.BEUsuarioLogin = VariablesSession.BEUsuarioSession;


                            new BLAmortizacionVenta().EliminarAdelantoVenta(bean);

                            int intIdCliente = Convert.ToInt32(cbCliente.SelectedValue);
                            int intIdProducto = Convert.ToInt32(cbProducto.SelectedValue);
                            CargarAmortizaciones(intIdCliente, intIdProducto);
                            //this.CargarAmortizaciones(
                        
                        
                        }
                    
                    
                    }

                    
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
            }
        }

    }
}