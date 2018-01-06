using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DGP.BusinessLogic.Ventas;
using DGP.BusinessLogic;
using DGP.Entities.Ventas;
using DGP.Entities;

namespace DGP.Presentation.Ventas {

    public partial class frmPagoAdelanto : Form {

        public frmPagoAdelanto() {
            InitializeComponent();
            IniciarFormulario();
        }

        #region "Eventos de frmPagoAdelanto"

            private void frmPagoAdelanto_Load(object sender, EventArgs e) {
                try {
                    lblSimboloMoneda.Text = VariablesSession.ISOCulture.NumberFormat.CurrencySymbol;
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void btnAceptarAdelanto_Click(object sender, EventArgs e) {
                string oMensaje = string.Empty;
                try {
                    if (ValidarFormulario(ref oMensaje)) {
                        BEAmortizacionVenta oBEAmortizacionVenta = ObtenerAdelantoFormulario();
                        int intResultado = 0;
                        intResultado = new BLAmortizacionVenta().InsertarAdelantoVenta(oBEAmortizacionVenta);
                        //
                        if (intResultado > 0) {
                            MostrarMensaje("Se registró la venta correctamente", MessageBoxIcon.Information);
                            IniciarFormulario();
                        } else {
                            MostrarMensaje("No se pudo registrar el adelanto, intentelo de nuevo", MessageBoxIcon.Exclamation);
                        }
                    } else {
                        MostrarMensaje(oMensaje, MessageBoxIcon.Exclamation);
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

        #endregion

        #region "Métodos de frmPagoAdelanto"

            private void MostrarMensaje(string pMensaje, MessageBoxIcon pMsgBoxicon) {
                MessageBox.Show(pMensaje, "DGP", MessageBoxButtons.OK, pMsgBoxicon);
            }

            private void IniciarFormulario() {
                LimpiarControles();
                CargarCliente();
            }

            private void CargarCliente() {
                List<BEClienteProveedor> vListaCliente = new List<BEClienteProveedor>();
                vListaCliente = new BLClienteProveedor().Listar(new BEClienteProveedor());
                vListaCliente.Insert(0, new BEClienteProveedor(0, "Todos"));
                cbCliente.DataSource = vListaCliente;
                cbCliente.DisplayMember = "Nombre";
                cbCliente.ValueMember = "IdCliente";
            }

            private void LimpiarControles() {
                txtObservacion.ResetText();
                nudPrecioAdelanto.Value = 1;
                DGP_Util.LiberarComboBox(cbCliente);
            }

            private bool ValidarFormulario(ref string pMensaje) {
                bool vResultado = true;
                if (cbCliente.SelectedIndex == 0) {
                    pMensaje = "- Seleccionar cliente\n";
                    vResultado = false;
                }
                if (string.IsNullOrEmpty(txtObservacion.Text.Trim())) {
                    pMensaje += "- Ingresar observación\n";
                    vResultado = false;
                }
                return vResultado;
            }

            private BEAmortizacionVenta ObtenerAdelantoFormulario() {
                BEAmortizacionVenta oEntidad = new BEAmortizacionVenta();
                oEntidad.BEUsuarioLogin = VariablesSession.BEUsuarioSession;
                oEntidad.IdCliente = Convert.ToInt32(cbCliente.SelectedValue);
                oEntidad.Monto = nudPrecioAdelanto.Value;
                oEntidad.Observacion = txtObservacion.Text;
                oEntidad.IdEstado = BEAmortizacionVenta.ESTADO_REGISTRADO;
                oEntidad.IdFormaPago = BEAmortizacionVenta.FORMAPAGO_EFECTIVO;
                oEntidad.IdTipoAmortizacion = BEAmortizacionVenta.TIPOAMORTIZACION_ADELANTO;
                return oEntidad;
            }

        #endregion

    }
}