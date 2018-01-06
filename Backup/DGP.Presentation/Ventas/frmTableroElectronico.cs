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
using System.Threading;
using DGP.Entities.DataSet;
using DGP.Entities.DataSet.DSEntitiesTableroTableAdapters;

namespace DGP.Presentation.Ventas {

    public partial class frmTableroElectronico : Form {
        private int vg_unidades_por_java = 8;
        private int vg_intIdVenta = int.MinValue;
        private List<BEClienteProveedor> vTempCliente = new List<BEClienteProveedor>();
        private decimal vg_decTara = decimal.Zero;
        private decimal vg_decPrecioVenta = decimal.Zero;
        private string vg_strCantidad = string.Empty;
        private string vg_strPesoBruto = string.Empty;
        private string vg_strPesoTara = string.Empty;
        private string vg_strCantidadPollos = string.Empty;
        DataGridViewCellStyle oCeldaObservaciones = null;

        public frmTableroElectronico() {
            InitializeComponent();
            InicializarFormulario();
            this.dtpFechaCaja.Value = VariablesSession.BECaja.Fecha;
        }
        
        #region "Eventos de frmTableroElectronico"
        
            private void frmTableroElectronico_Load(object sender, EventArgs e) {
                try {
                    dgvLineaVenta.AutoGenerateColumns = false;
                    dgvListaVenta.AutoGenerateColumns = false;
                    lblSimboloMoneda.Text = VariablesSession.ISOCulture.NumberFormat.CurrencySymbol;


                    DSEntitiesTablero ds = new DSEntitiesTablero();
                    this.bdsGasto2.DataSource = ds.tb_gasto;

                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void tcTableroElectronico_SelectedIndexChanged(object sender, EventArgs e) {
                if (tcTableroElectronico.SelectedIndex > 0) {
                    CargarControlesBusqueda();
                    CargarListaVentas(false, 0, 0, 0, 0);
                }
            }

            private void ckbEsSobrante_CheckedChanged(object sender, EventArgs e) {
                try {
                    if (ckbEsSobrante.Checked) {
                        DGP_Util.LiberarComboBox(cbZona);
                        DGP_Util.EnabledComboBox(cbZona, false);
                        cbCliente.SelectedIndex = -1;
                        cbCliente.Text = "Sobrante del día";
                        DGP_Util.EnabledComboBox(cbCliente, false);
                        CargarVentaCliente(false, int.MinValue, int.MinValue);
                        cbVenta.SelectedValue = 0;
                        DGP_Util.EnabledComboBox(cbVenta, false);
                        CargarProducto(cbProducto, true);
                        DGP_Util.EnabledComboBox(cbProducto, true);
                        DGP_Util.EnableControl(nudPredio, false);
                        DGP_Util.EnableControl(txtObservacionesVenta, true);
                        CargarTipoDocumento(true);
                        DGP_Util.EnabledComboBox(cbTipoDocumento, true);
                        DGP_Util.EnableControl(txtNroDocumento, true);
                        CargarEmpresa(true);
                        DGP_Util.EnabledComboBox(cbEmpresa, true);
                        nudPredio.Value = 1;
                        DGP_Util.EnableControl(dgvLineaVenta, false);
                        dgvLineaVenta.AllowUserToAddRows = false;
                    } else {
                        DGP_Util.LiberarComboBox(cbVenta);
                        ResetearVenta();
                        InicializarFormulario();
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void cbZona_SelectedIndexChanged(object sender, EventArgs e) {
                try {
                    int IntIdZona = 0;
                    if (cbZona.SelectedIndex > 0) {
                        int.TryParse(cbZona.SelectedValue.ToString(), out IntIdZona);
                    }
                    CargarCliente(cbCliente, true, IntIdZona);
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void cbProducto_SelectedIndexChanged(object sender, EventArgs e) {
                try {
                    int intIdCliente = 0;
                    int intIdProducto = 0;
                    if (cbProducto.SelectedIndex > 0) {
                        if (cbCliente.SelectedIndex > 0) {
                            int.TryParse(cbCliente.SelectedValue.ToString(), out intIdCliente);
                        }
                        int.TryParse(cbProducto.SelectedValue.ToString(), out intIdProducto);
                        //** INICIO : Establecer el precio de compra del Producto **//
                        if (ckbEsSobrante.Checked) {
                            List<BEProducto> vLista = new List<BEProducto>();
                            BEProducto oBEProducto = new BEProducto();
                            oBEProducto.IdProducto = intIdProducto;
                            vLista = new BLProducto().Listar(oBEProducto);
                            if (vLista != null && vLista.Count == 1) {
                                nudPredio.Value = vLista[0].PrecioCompra;
                            }
                            //** Precio Tara **//
                            vg_decTara = vLista[0].Tara;
                            DGP_Util.LiberarGridView(dgvLineaVenta);
                            DGP_Util.EnableControl(dgvLineaVenta, true);
                            dgvLineaVenta.AllowUserToAddRows = true;
                        //** FIN : Establecer el precio de compra **//
                        } else {
                            //** INICIO : Establecer el precio de Venta del Cliente-Producto **//
                            vg_decPrecioVenta = new BLProductoCliente().ObtenerPrecioVenta(new BEProductoCliente(intIdProducto, intIdCliente));
                            nudPredio.Value = vg_decPrecioVenta;
                            dgvLineaVenta.Update();
                            //** FIN : Establecer el precio de Venta del Cliente-Producto **//
                            // Actualizar Grid y Peso tara
                            if (cbVenta.Enabled == true) {
                                vg_decTara = new BLProductoCliente().ObtenerTara(new BEProductoCliente(intIdProducto, intIdCliente));
                                DGP_Util.LiberarGridView(dgvLineaVenta);
                                dgvLineaVenta.AllowUserToAddRows = true;                                
                            }
                            //
                        }
                    } else {
                        DGP_Util.LiberarGridView(dgvLineaVenta);
                        DGP_Util.EnableControl(dgvLineaVenta, false);
                        dgvLineaVenta.AllowUserToAddRows = false;
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void cbCliente_KeyUp(object sender, KeyEventArgs e) {
                try {
                    // Do nothing for certain keys, such as navigation keys.
                    if (
                        (e.KeyCode == Keys.Escape) ||

                        (e.KeyCode == Keys.Left) ||
                        (e.KeyCode == Keys.Right) ||
                        (e.KeyCode == Keys.Up) ||
                        (e.KeyCode == Keys.Down) ||
                        (e.KeyCode == Keys.PageUp) ||
                        (e.KeyCode == Keys.PageDown) ||
                        (e.KeyCode == Keys.Home) ||
                        (e.KeyCode == Keys.End) ||

                        (e.KeyCode == Keys.Enter) ||

                        (e.KeyCode == Keys.Multiply) ||
                        (e.KeyCode == Keys.Divide) ||
                        (e.KeyCode == Keys.Subtract) ||
                        (e.KeyCode == Keys.Add) ||
                        (e.KeyCode == Keys.NumLock)
                        )
                    {
                        e.Handled = true;
                        return;
                    }

                    string actual = cbCliente.Text;
                    //
                    int intIdZona = 0;
                    BEClienteProveedor oEntidad = new BEClienteProveedor();
                    if (cbZona.SelectedIndex > 0) {
		                 int.TryParse(cbZona.SelectedValue.ToString(), out intIdZona);
	                }
                    oEntidad.Nombre = actual;
                    oEntidad.IdZona = intIdZona;
                    oEntidad.IdCliente = 0;
                    List<BEClienteProveedor> vTemp = new BLClienteProveedor().Listar(oEntidad);
                    vTemp.Insert(0, new BEClienteProveedor(0, ""));
                    if (vTemp != null && vTemp.Count > 0) {
                        cbCliente.Text = string.Empty;
                        cbCliente.DataSource = vTemp;
                        cbCliente.DisplayMember = "Nombre";
                        cbCliente.ValueMember = "IdCliente";
                        cbCliente.DroppedDown = true;
                        cbCliente.Refresh();
                        cbCliente.Text = actual;
                        if (!string.IsNullOrEmpty(actual)) {
                            cbCliente.Select(actual.Length, 0);
                        } else {
                            cbCliente.SelectedIndex = -1;
                        }
                    } else {
                        cbCliente.DroppedDown = false;
                        cbCliente.SelectedIndex = -1;
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void cbCliente_Leave(object sender, EventArgs e) {
                // Validar si eligio el producto
                if (!string.IsNullOrEmpty(cbCliente.Text.Trim())) {
                    if (cbProducto.SelectedIndex > 0) {
                        //DGP_Util.EnabledComboBox(cbVenta, true);
                        int intIdCliente = 0;
                        int intIdProducto2 = 0;
                        // Cliente
                        if (cbCliente.SelectedIndex <= 0) {
                            CargarVentaCliente(false, int.MinValue, int.MinValue);
                            vg_decTara = decimal.Zero;
                        } else {
                            int.TryParse(cbCliente.SelectedValue.ToString(), out intIdCliente);
                            int.TryParse(cbProducto.SelectedValue.ToString(), out intIdProducto2);
                            CargarVentaCliente(true, intIdCliente, intIdProducto2);
                        }
                        // Establecer Precio Venta
                        int intIdProducto = 0;
                        if (cbProducto.SelectedIndex > 0) {
                            int.TryParse(cbProducto.SelectedValue.ToString(), out intIdProducto);
                            decimal decPrecioVenta = new BLProductoCliente().ObtenerPrecioVenta(new BEProductoCliente(intIdProducto, intIdCliente));
                            vg_decPrecioVenta = decPrecioVenta;
                        }
                        nudPredio.Value = vg_decPrecioVenta;
                        //
                        // Establecer el Precio Tara
                        if (cbProducto.SelectedIndex > 0) {
                            vg_decTara = new BLProductoCliente().ObtenerTara(new BEProductoCliente(intIdProducto, intIdCliente));

                            try
                            {
                                dgvLineaVenta.Rows[0].Cells[ePosicionCol.PesoJava.GetHashCode()].Value = vg_decTara;
                            }
                            catch (Exception)
                            {//no hace nada
                            }
                            //foreach (DataGridViewRow item in dgvLineaVenta.Rows)
                            //{
                            //    item.Cells[ePosicionCol.PesoJava].Value = vg_decPrecioVenta;
                                
                            //}
                        }
                    } else {
                        MostrarMensaje("Seleccione producto", MessageBoxIcon.Exclamation);
                    }
                } else {
                    if (this.Visible == true) {
                        DGP_Util.LiberarComboBox(cbVenta);
                        //DGP_Util.EnabledComboBox(cbVenta, false);
                    }
                }
            }

            private void cbCliente_SelectedIndexChanged(object sender, EventArgs e) {
                //// Validar si eligio el producto
                //if (!string.IsNullOrEmpty(cbCliente.Text.Trim())) {
                //    if (cbProducto.SelectedIndex > 0) {
                //        DGP_Util.EnabledComboBox(cbVenta, true);
                //        int intIdCliente = 0;
                //        // Cliente
                //        if (cbCliente.SelectedIndex <= 0) {
                //            CargarVentaCliente(false, int.MinValue);
                //            vg_decTara = decimal.Zero;
                //        } else {
                //            int.TryParse(cbCliente.SelectedValue.ToString(), out intIdCliente);
                //            CargarVentaCliente(true, intIdCliente);
                //        }
                //        // Establecer Precio Venta
                //        int intIdProducto = 0;
                //        if (cbProducto.SelectedIndex > 0) {
                //            int.TryParse(cbProducto.SelectedValue.ToString(), out intIdProducto);
                //            decimal decPrecioVenta = new BLProductoCliente().ObtenerPrecioVenta(new BEProductoCliente(intIdProducto, intIdCliente));
                //            vg_decPrecioVenta = decPrecioVenta;
                //        }
                //        nudPredio.Value = vg_decPrecioVenta;
                //        //
                //        // Establecer el Precio Tara
                //        if (cbProducto.SelectedIndex > 0) {
                //            vg_decTara = new BLProductoCliente().ObtenerTara(new BEProductoCliente(intIdProducto, intIdCliente));                    
                //        }
                //    } else {
                //        MostrarMensaje("Seleccione producto", MessageBoxIcon.Exclamation);
                //    }
                //} else {
                //    if (this.Visible == true) {
                //        DGP_Util.EnabledComboBox(cbVenta, false);                     
                //    }
                //}
            }

            private void cbVenta_SelectedIndexChanged(object sender, EventArgs e) {
                try {
                    // Validar si elige una Venta
                    if (cbVenta.SelectedIndex > 0) {
                        int.TryParse(cbVenta.SelectedValue.ToString(), out vg_intIdVenta);
                        // Nueva Venta
                        if (vg_intIdVenta == 0) {
                            // Mostrar y Habilitar los controles
                            DGP_Util.EnabledComboBox(cbTipoDocumento, true);
                            DGP_Util.EnabledComboBox(cbEmpresa, true);
                            //
                            DGP_Util.EnableControl(nudPredio, true);
                            DGP_Util.EnableControl(txtObservacionesVenta, true);
                            DGP_Util.EnableControl(txtNroDocumento, true);
                            DGP_Util.EnableControl(dgvLineaVenta, true);
                            DGP_Util.EnableControl(btnAceptarVenta, true);
                            txtNroDocumento.ResetText();
                            txtObservacionesVenta.ResetText();
                        } else {
                            // Venta Existente
                            BEVenta oBEVenta = new BLVenta().ObtenerVenta(vg_intIdVenta);
                            DGP_Util.EnabledComboBox(cbTipoDocumento, false);
                            DGP_Util.EnabledComboBox(cbEmpresa, false);
                            //
                            DGP_Util.EnableControl(nudPredio, true);
                            DGP_Util.EnableControl(txtObservacionesVenta, false);
                            DGP_Util.EnableControl(txtNroDocumento, false);
                            DGP_Util.EnableControl(dgvLineaVenta, true);
                            DGP_Util.EnableControl(btnAceptarVenta, true);
                            // Establecer Valores
                            nudPredio.Value = oBEVenta.Precio;
                            txtObservacionesVenta.Text = oBEVenta.Observacion;
                            cbTipoDocumento.SelectedValue = string.IsNullOrEmpty(oBEVenta.IdTipoDocumentoVenta) ? "0" : oBEVenta.IdTipoDocumentoVenta;
                            cbEmpresa.SelectedValue = oBEVenta.IdEmpresa;
                            txtNroDocumento.Text = oBEVenta.NumeroDocumento;
                            //verificar la cantidad de amortizaciones si tiene mas de 1 debe deshabilitar                            
                            VistaAmortizacion viewAmortizacion = new VistaAmortizacion();
                            viewAmortizacion.IdVenta = vg_intIdVenta;
                            List<VistaAmortizacion> amortizaciones = new BLAmortizacionVenta().Listar(viewAmortizacion);

                            if (amortizaciones.Count == 0)
                            {
                                chkbAlContado.Checked = false;
                                chkbAlContado.Enabled = true;
                                nudAmortizacion.Enabled = true;
                                nudAmortizacion.Value = 0;
                               

                            }
                            else {
                                chkbAlContado.Checked = false;
                                chkbAlContado.Enabled = false;
                                nudAmortizacion.Value = 0;
                                nudAmortizacion.Enabled = false;
                                
                            
                            }
                            
                        }
                        dgvLineaVenta.AllowUserToAddRows = true;
                    } else {
                        dgvLineaVenta.AllowUserToAddRows = false;
                        ResetearVenta();
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }



            private void nudPredio_ValueChanged(object sender, EventArgs e) {
                try {
                    if (dgvLineaVenta.Rows.Count > 1) {
                        CalcularSumaMontos(true, true, true);                        
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void nudPredio_Leave(object sender, EventArgs e) {
                try {
                    if (dgvLineaVenta.Rows.Count > 1) {
                        CalcularSumaMontos(true, true, true);                        
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void dgvLineaVenta_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
                    dgvLineaVenta[0, e.RowIndex].Value = "0"; // Flag Java (Oculto)
                    dgvLineaVenta[1, e.RowIndex].Value = "0"; // Flag Peso Tara (Oculto)
                    dgvLineaVenta[2, e.RowIndex].Value = "0"; // Peso Tara Calculado (Oculto)
                    dgvLineaVenta[3, e.RowIndex].Value = ""; // Cantidad Javas (Ingreso)
                    dgvLineaVenta[4, e.RowIndex].Value = vg_decTara; // Peso Java (Editable)
                    dgvLineaVenta[5, e.RowIndex].Value = ""; // Peso Bruto (Ingreso)
                    dgvLineaVenta[6, e.RowIndex].Value = ""; // Peso Tara (Calculado, Editable)
                    dgvLineaVenta[7, e.RowIndex].Value = ""; // Peso Neto (Calculado)
                    dgvLineaVenta[8, e.RowIndex].Value = ""; // Observacion (Condición)                    
            }

            private void dgvLineaVenta_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
                bool boIndicador = false;
                // Validar que sea edicion si solo hay una fila
                if (dgvLineaVenta.Rows.Count == 1 && dgvLineaVenta.Rows[e.RowIndex].IsNewRow == true) {
                    boIndicador = true;
                } else {
                    // Validar que sea edicion para todas las demas menos la ultima
                    if (e.RowIndex < dgvLineaVenta.Rows.Count - 1) {
                        boIndicador = true;
                    }
                }
                if (boIndicador) {
                    // Validar que sea solo para algunas celdas
                    if (e.ColumnIndex != 9) {
                        Point oPoint = dgvLineaVenta.CurrentCellAddress;
                        if (oPoint.X == e.ColumnIndex && oPoint.Y == e.RowIndex && e.Button == MouseButtons.Left && dgvLineaVenta.EditMode != DataGridViewEditMode.EditProgrammatically) {
                            if (!dgvLineaVenta.IsCurrentCellInEditMode) {
                                dgvLineaVenta.BeginEdit(true);
                            }
                        }
                    }
                } else {
                    dgvLineaVenta.CancelEdit();
                }
            }

            private void dgvLineaVenta_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
                switch ((ePosicionCol)e.ColumnIndex) {
                    case ePosicionCol.CantidadJavas:
                        // Validar si existe valor
                        object oCantidad = dgvLineaVenta[ePosicionCol.CantidadJavas.GetHashCode(), e.RowIndex].Value;
                        if (oCantidad == null || string.IsNullOrEmpty(oCantidad.ToString())) {
                            vg_strCantidad = string.Empty;
                        } else {
                            vg_strCantidad = oCantidad.ToString();
                        }
                        break;
                    case ePosicionCol.PesoBruto:
                        // Validar si existe valor
                        object oPesoBruto = dgvLineaVenta[ePosicionCol.PesoBruto.GetHashCode(), e.RowIndex].Value;
                        if (oPesoBruto == null || string.IsNullOrEmpty(oPesoBruto.ToString())) {
                            vg_strPesoBruto = string.Empty;
                        } else {
                            vg_strPesoBruto = oPesoBruto.ToString();
                        }
                        break;
                    case ePosicionCol.CantidadPollos:
                        object oCantidadPollos = dgvLineaVenta[ePosicionCol.CantidadPollos.GetHashCode(), e.RowIndex].Value;
                        if (oCantidadPollos == null || string.IsNullOrEmpty(oCantidadPollos.ToString()))
                        {
                            vg_strCantidadPollos = string.Empty;
                        }
                        else
                        {
                            // Calcular Peso tara
                            object oCantJavas = dgvLineaVenta[ePosicionCol.CantidadJavas.GetHashCode(), e.RowIndex].Value;
                            object oUnidadesJava = vg_unidades_por_java;
                            if (!string.IsNullOrEmpty(oCantJavas.ToString()) && !string.IsNullOrEmpty(oUnidadesJava.ToString()))
                            {
                                vg_strCantidadPollos = (int.Parse(oCantJavas.ToString()) * decimal.Parse(oUnidadesJava.ToString())).ToString();
                            }
                            else
                            {
                                vg_strCantidadPollos = oCantidadPollos.ToString();
                            }
                        }

                        break;
                    case ePosicionCol.PesoTara:
                        // Validar si existe valor
                        object oPesoTara = dgvLineaVenta[ePosicionCol.PesoTara.GetHashCode(), e.RowIndex].Value;
                        if (oPesoTara == null || string.IsNullOrEmpty(oPesoTara.ToString())) {
                            vg_strPesoTara = string.Empty;
                        } else {
                            // Calcular Peso tara
                            object oCantJavas = dgvLineaVenta[ePosicionCol.CantidadJavas.GetHashCode(), e.RowIndex].Value;
                            object oPesoJava = dgvLineaVenta[ePosicionCol.PesoJava.GetHashCode(), e.RowIndex].Value;
                            if (!string.IsNullOrEmpty(oCantJavas.ToString()) && !string.IsNullOrEmpty(oPesoJava.ToString())) {
                                vg_strPesoTara = (int.Parse(oCantJavas.ToString()) * decimal.Parse(oPesoJava.ToString())).ToString();
                            } else {
                                vg_strPesoTara = oPesoTara.ToString();
                            }
                        }
                        break;
                }
            }
            
            private void dgvLineaVenta_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
                try {
                    string strMensaje = string.Empty;
                    if (!ValidarCampos(ref strMensaje, e.RowIndex, e.ColumnIndex)) {
                        MostrarMensaje(strMensaje, MessageBoxIcon.Exclamation);
                    } else {
                        CalcularSumaMontos(true, true, true);
                    }
                } catch (Exception ex) {
                    MostrarMensaje("Error al registrar la línea de venta, intentelo más tarde", MessageBoxIcon.Error);
                }
            }

            private void dgvLineaVenta_CellContentClick(object sender, DataGridViewCellEventArgs e) {
                if (e.ColumnIndex< 0) return;

                if (e.ColumnIndex == ePosicionCol.BotonEliminar.GetHashCode() && e.RowIndex >= 0) {
                    DataGridViewButtonCell objeto = (DataGridViewButtonCell)dgvLineaVenta[e.ColumnIndex, e.RowIndex];
                    if (!string.IsNullOrEmpty(objeto.FormattedValue.ToString())) {
                        dgvLineaVenta.Rows.RemoveAt(e.RowIndex);
                        CalcularSumaMontos(true, true, true);
                    }
                }
            }

            private void btnAceptarVenta_Click(object sender, EventArgs e) {
                try {
                    string strMensaje = string.Empty;
                    if (ValidarFormulario(ref strMensaje)) {
                        BEVenta oBEVenta = ObtenerVentaFormulario();
                        int intResultado = 0;
                        //evalua si el precio es el mismo con el q esta registrado el cliente, si no es asi cambia el precio
                        this.CambiarPrecioCliente(oBEVenta);
                        //parametros para la amortizacion
                        decimal montoAmortizacion = (chkbAlContado.Checked)?0:nudAmortizacion.Value;
                        bool alContado = chkbAlContado.Checked;
                        oBEVenta.TotalUnidades = (int)nudCantidad.Value;
                        
                        if (oBEVenta.IdVenta.Equals(0)) {
                            intResultado = new BLVenta().RegistrarVentaInicialDependiente(oBEVenta , alContado ,montoAmortizacion);
                        } else {
                            intResultado = new BLVenta().ModificarVentaInicialDependiente(oBEVenta, alContado, montoAmortizacion);
                        }
                        //
                        if (intResultado == 3) {
                            MostrarMensaje("Se registró la venta correctamente", MessageBoxIcon.Information);
                        } else {
                            MostrarMensaje("No se pudo registrar la venta, intentelo de nuevo", MessageBoxIcon.Exclamation);
                        }
                        int intIdZona = 0;
                        if (oBEVenta.EsSobrante == eVentaEsSobrante.No) {
                            int.TryParse(cbZona.SelectedValue.ToString(), out intIdZona);                            
                        }
                        CargarCliente(cbCliente, true, intIdZona);
                        DGP_Util.LiberarComboBox(cbVenta);
                        ResetearVenta();
                        //tcTableroElectronico.SelectTab(1);
                        //MessageBox.Show("Se Grabo Correctamente" , "Registro de Linea de Venta",MessageBoxButtons.OK);
                        ckbEsSobrante.Checked = false;
                    } else {
                        MostrarMensaje(strMensaje, MessageBoxIcon.Exclamation);
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }


            private void btnBuscar_Click(object sender, EventArgs e) {
                try
                {
                   
                }
                catch (Exception ex)
                {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }
       
        public void refrescar()
        {
            int intIdZona = 0;
            int intIdProducto = 0;
            int intIdCliente = 0;
            int.TryParse(cbZonaB.SelectedValue.ToString(), out intIdZona);
            int.TryParse(cbProductoB.SelectedValue.ToString(), out intIdProducto);
            int.TryParse(cbClienteB.SelectedValue.ToString(), out intIdCliente);
            CargarListaVentas(true, 0, intIdZona, intIdProducto, intIdCliente);


        }


            private void dgvListaVenta_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
                try {
                    string strMensaje = string.Empty;
                    if (!ValidarCamposLista(ref strMensaje, e.RowIndex, e.ColumnIndex)) {
                        MostrarMensaje(strMensaje, MessageBoxIcon.Exclamation);
                    }
                } catch (Exception ex) {
                    MostrarMensaje("Error al registrar la línea de venta, intentelo más tarde", MessageBoxIcon.Error);
                }
            }

            private void dgvListaVenta_CellContentClick(object sender, DataGridViewCellEventArgs e) {
                try {
                    if (e.ColumnIndex == ePosicionLista.BottonPagar.GetHashCode() && e.RowIndex >= 0) {
                        DataGridViewButtonCell objeto = (DataGridViewButtonCell)dgvListaVenta[e.ColumnIndex, e.RowIndex];
                        decimal decPago = decimal.Zero;
                        decimal decSaldo = decimal.Zero;
                        int intIdVenta = 0;
                        int intIdCliente = 0;
                        if (!string.IsNullOrEmpty(objeto.FormattedValue.ToString())) {
                            // Validar el pago
                            object objSaldo = dgvListaVenta[ePosicionLista.SaldoAnterior.GetHashCode (), e.RowIndex].Value;
                            object objPago = dgvListaVenta[ePosicionLista.Pago.GetHashCode(), e.RowIndex].Value;
                            if ((objSaldo != null && objPago != null) && !string.IsNullOrEmpty(objPago.ToString())) {
                                decPago = Convert.ToDecimal(objPago);
                                decSaldo = Convert.ToDecimal(objSaldo);
                                object objIdVenta = dgvListaVenta[ePosicionLista.IdVenta.GetHashCode(), e.RowIndex].Value;
                                object objIdCliente = dgvListaVenta[ePosicionLista.IdCliente.GetHashCode(), e.RowIndex].Value;
                                // Validamos si es cliente Eventual
                                intIdCliente = Convert.ToInt32(objIdCliente);
                                intIdVenta = Convert.ToInt32(objIdVenta);
                                BEAmortizacionVenta oBEAmortizacionVenta = new BEAmortizacionVenta();
                                List<BEAmortizacionVenta> vLista = new List<BEAmortizacionVenta>();
                                oBEAmortizacionVenta.Monto = decPago;
                                oBEAmortizacionVenta.NroDocumento = string.Empty;
                                oBEAmortizacionVenta.IdFormaPago = BEAmortizacionVenta.FORMAPAGO_EFECTIVO;
                                oBEAmortizacionVenta.IdTipoAmortizacion = BEAmortizacionVenta.TIPOAMORTIZACION_AMORTIZACION;
                                oBEAmortizacionVenta.IdEstado = BEAmortizacionVenta.ESTADO_REGISTRADO;
                                oBEAmortizacionVenta.FechaPago = DateTime.Now.Date;
                                oBEAmortizacionVenta.IdVenta = intIdVenta;
                                oBEAmortizacionVenta.IdPersonal = VariablesSession.BEUsuarioSession.IdPersonal;
                                oBEAmortizacionVenta.BEUsuarioLogin = VariablesSession.BEUsuarioSession;
                                bool boIndicador = false;
                                if (intIdCliente == 0) {
                                    oBEAmortizacionVenta.Observacion = "Pago de Cliente Eventual";
                                    oBEAmortizacionVenta.IdCliente = 0;
                                    boIndicador = true;
                                    //if (decSaldo <= decPago) {
                                    //    oBEAmortizacionVenta.Observacion = "Pago de Cliente Eventual";
                                    //    oBEAmortizacionVenta.IdCliente = 0;
                                    //    boIndicador = true;
                                    //} else {
                                    //    MostrarMensaje("El monto a pagar debe ser mayor al saldo", MessageBoxIcon.Exclamation);
                                    //}                                    
                                } else {
                                    oBEAmortizacionVenta.Observacion = "Pago de Cliente Espedífico";
                                    oBEAmortizacionVenta.IdCliente = intIdCliente;
                                    boIndicador = true;
                                    //if (decPago <= decSaldo) {
                                    //    oBEAmortizacionVenta.Observacion = "Pago de Cliente Espedífico";
                                    //    oBEAmortizacionVenta.IdCliente = intIdCliente;
                                    //    boIndicador = true;
                                    //} else {
                                    //    MostrarMensaje("El monto a pagar debe ser menor al saldo", MessageBoxIcon.Exclamation);
                                    //}
                                }
                                if (boIndicador) {
                                    int intResultado = 0;
                                    vLista.Add(oBEAmortizacionVenta);
                                    intResultado = new BLAmortizacionVenta().Insertar(vLista);
                                    if (intResultado == 1) {
                                        MostrarMensaje("Se registró la amortización correctamente", MessageBoxIcon.Information);
                                        CargarListaVentas(false, 0, 0, 0, 0);
                                    } else {
                                        MostrarMensaje("No se pudo realizar el pago de la venta, intentelo de nuevo", MessageBoxIcon.Exclamation);
                                    }                                    
                                } else {
                                    dgvListaVenta[ePosicionLista.Pago.GetHashCode(), e.RowIndex].Value = (object)"";
                                }
                            } else {
                                MostrarMensaje("Debe ingresar un monto para el pago", MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                   // MessageBox.Show("e.ColumnIndex" + e.ColumnIndex);
                    if (e.ColumnIndex == ePosicionLista.BotonCuentas.GetHashCode() && e.RowIndex >= 0)
                    { 
                        int IdCliente = (int) dgvListaVenta[ePosicionLista.IdCliente.GetHashCode(), e.RowIndex].Value;
                        int IdProducto = (int)dgvListaVenta[ePosicionLista.IdCliente.GetHashCode(), e.RowIndex].Value;
                        CargarVentanaCuentas ( IdCliente, IdProducto);
                    
                    }

                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

        #endregion

        #region "Métodos de frmTableroElectronico"

            private void InicializarFormulario() {
                // Cargar los Controles Iniciales
                CargarZona(cbZona);
                CargarProducto(cbProducto, true);
                CargarCliente(cbCliente, true, 0);
                CargarTipoDocumento(true);
                CargarEmpresa(true);
                // Habilitar los controles Iniciales
                DGP_Util.EnabledComboBox(cbZona, true);
                DGP_Util.EnabledComboBox(cbProducto, true);
                DGP_Util.EnabledComboBox(cbCliente, true);
                // Deshabilitar los controles del formulario
                //DGP_Util.EnabledComboBox(cbVenta, false);
                nudPredio.Enabled = false;
                txtObservacionesVenta.Enabled = false;
                DGP_Util.EnabledComboBox(cbTipoDocumento, false);
                txtNroDocumento.Enabled = false;
                DGP_Util.EnabledComboBox(cbEmpresa, false);
                dgvLineaVenta.Enabled = false;
                btnAceptarVenta.Enabled = false;
                // Validar Control Sobrante del día
                ckbEsSobrante.Checked = false;
                DGP_Util.EnableControl(ckbEsSobrante, new BLVenta().ValidarVentaSobranteDia(VariablesSession.BEUsuarioSession.IdCaja));
                //

                loadTipoGasto();
                loadGastos();
            }

            private void ResetearVenta() {
                vg_intIdVenta = int.MinValue;
                vg_strCantidad = string.Empty;
                vg_strPesoBruto = string.Empty;
                vg_strPesoTara = string.Empty;
                vg_strCantidadPollos = string.Empty;
                DGP_Util.EnableControl(nudPredio, false);
                //
                DGP_Util.EnableControl(txtObservacionesVenta, false);
                txtObservacionesVenta.ResetText();
                DGP_Util.EnableControl(dgvLineaVenta, false);
                DGP_Util.LiberarGridView(dgvLineaVenta);
                DGP_Util.EnableControl(btnAceptarVenta, false);
                // Limpiar Calculados
                lblTotalPesoBruto.Text = string.Empty;
                lblTotalPesoNeto.Text = string.Empty;
                lblTotalPesoTara.Text = string.Empty;
                lblMonto.Text = string.Empty;

                chkbAlContado.Checked = false;
                chkbAlContado.Enabled = true;
                nudAmortizacion.Value = 0;
                nudAmortizacion.Enabled = true;
            }

            private void MostrarMensaje(string pMensaje, MessageBoxIcon pMsgBoxicon) {
                MessageBox.Show(pMensaje, "DGP", MessageBoxButtons.OK, pMsgBoxicon);
            }

            private void CargarZona(ComboBox pComboBox) { 
                List<BEZona> vListaZona = new List<BEZona>();
                vListaZona = new BLZona().Listar(new BEZona());
                vListaZona.Insert(0, new BEZona(0, "Todos"));
                pComboBox.DataSource = vListaZona;
                pComboBox.DisplayMember = "Descripcion";
                pComboBox.ValueMember = "IdZona";
            }

            private void CargarProducto(ComboBox pComboBox, bool pValor) { 
                List<BEProducto> vLista = new List<BEProducto>();
                if (pValor)	{
		            vLista = new BLProducto().Listar(new BEProducto());
	            }
                vLista.Insert(0, new BEProducto(0, "Todos"));
                pComboBox.DataSource = vLista;
                pComboBox.DisplayMember = "Nombre";
                pComboBox.ValueMember = "IdProducto";
            }


            private void CargarCliente(ComboBox pComboBox, bool pValor, int pIdZona) {
                if (pValor) {
                    List<BEClienteProveedor> vListaCliente = new List<BEClienteProveedor>();
                    BEClienteProveedor oTemp = new BEClienteProveedor();
                    oTemp.IdZona = pIdZona;
                    vListaCliente = new BLClienteProveedor().Listar(oTemp);
                    vListaCliente.Insert(0, new BEClienteProveedor(0, ""));
                    vTempCliente = vListaCliente;
                    pComboBox.Text = string.Empty;
                    pComboBox.DataSource = vListaCliente;
                    pComboBox.DroppedDown = false;
                    pComboBox.DisplayMember = "Nombre";
                    pComboBox.ValueMember = "IdCliente";
                } else {
                    pComboBox.DataSource = null;
                    pComboBox.Items.Clear();
                }
            }

            private void CargarVentaCliente(bool pValor, int pIdCliente, int pIdproducto) {
                List<BEVenta> vLista = new List<BEVenta>();
                if (pValor) {
                    BEVenta oBEVenta = new BEVenta();
                    oBEVenta.IdCliente = pIdCliente;
                    oBEVenta.IdProducto = pIdproducto;
                    oBEVenta.IdCaja = VariablesSession.BEUsuarioSession.IdCaja;
                    vLista = new BLVenta().ListarVentaCliente(oBEVenta);
                }
                vLista.Insert(0, new BEVenta(0, "Nueva Venta"));
                vLista.Insert(0, new BEVenta(-1, "Todos"));
              
                cbVenta.DataSource = vLista;
                cbVenta.DisplayMember = "NombreVenta";
                cbVenta.ValueMember = "IdVenta";
                cbVenta.SelectedIndex = 1;
            }

            private void CargarTipoDocumento(bool pValor) {
                List<BEParametroDetalle> vLista = new List<BEParametroDetalle>();
                if (pValor) {
                    BEParametroDetalle oBEParametroDetalle = new BEParametroDetalle();
                    oBEParametroDetalle.IdParametro = eParametro.TipoDocumento_Venta.GetHashCode();
                    vLista = new BLParametroDetalle().Listar(oBEParametroDetalle);
                }
                vLista.Insert(0, new BEParametroDetalle("0", "Todos"));
                cbTipoDocumento.DataSource = vLista;
                cbTipoDocumento.DisplayMember = "Texto";
                cbTipoDocumento.ValueMember = "Valor";
            }

            private void CargarEmpresa(bool pValor) {
                List<BEEmpresa> vLista = new List<BEEmpresa>();
                if (pValor) {
                    vLista = new BLEmpresa().Listar(new BEEmpresa());
                }
                vLista.Insert(0, new BEEmpresa(0, "Todos"));
                cbEmpresa.DataSource = vLista;
                cbEmpresa.DisplayMember = "RazonSocial";
                cbEmpresa.ValueMember = "IdEmpresa";
            }

            private void CalcularSumaMontos(bool pCalculoPesoBruto, bool pCalculoPesoTara, bool pCalculoPesoNeto) {
                decimal decPesoBruto = decimal.Zero;
                decimal decPesoTara = decimal.Zero;
                decimal decPesoNeto = decimal.Zero;
                decimal decMonto = decimal.Zero;
                int intRowIndex = 0;
                this.nudCantidad.Value = 0;
                foreach (DataGridViewRow oRow in dgvLineaVenta.Rows) {
                    if (intRowIndex < dgvLineaVenta.Rows.Count-1) {
                        foreach (DataGridViewCell oCell in oRow.Cells) {
                            if (pCalculoPesoBruto && oCell.ColumnIndex == ePosicionCol.PesoBruto.GetHashCode()) { // Peso Bruto
                                decPesoBruto += (oCell.Value == null || string.IsNullOrEmpty(oCell.Value.ToString())) ? decimal.Zero : decimal.Parse(oCell.Value.ToString());
                            }
                            if (pCalculoPesoTara && oCell.ColumnIndex == ePosicionCol.PesoTara.GetHashCode()) { // Peso Tara
                                decPesoTara += (oCell.Value == null || string.IsNullOrEmpty(oCell.Value.ToString())) ? decimal.Zero : decimal.Parse(oCell.Value.ToString());
                            }
                            if (pCalculoPesoNeto && oCell.ColumnIndex == ePosicionCol.PesoNeto.GetHashCode()) { // Peso Neto
                                decPesoNeto += (oCell.Value == null || string.IsNullOrEmpty(oCell.Value.ToString())) ? decimal.Zero : decimal.Parse(oCell.Value.ToString());
                            }
                            if (oCell.ColumnIndex == ePosicionCol.CantidadPollos.GetHashCode())
                            { // Peso Neto
                                this.nudCantidad.Value += (oCell.Value == null || string.IsNullOrEmpty(oCell.Value.ToString())) ? decimal.Zero : decimal.Parse(oCell.Value.ToString());
                            }
                        }    
                    
                    }
                    intRowIndex++;
                }
                // Calcular el Monto
                decMonto = decPesoNeto * nudPredio.Value;
                // Mostrar el calculo
                lblTotalPesoBruto.Text = decPesoBruto.ToString();
                lblTotalPesoTara.Text = decPesoTara.ToString();
                lblTotalPesoNeto.Text = decPesoNeto.ToString();
                lblMonto.Text = decMonto.ToString("#.00");
            }

            private bool ValidarFormulario(ref string pMensaje) {
                bool vResultado = true;
                if (cbProducto.SelectedIndex == 0) {
                    pMensaje = "- Seleccionar Producto\n";
                    vResultado = false;
                }
                if (cbTipoDocumento.SelectedIndex > 0 && string.IsNullOrEmpty(txtNroDocumento.Text.Trim())) {
                    pMensaje += "- Ingresar número documento\n";
                }
                if (cbTipoDocumento.SelectedIndex == 0 && !string.IsNullOrEmpty(txtNroDocumento.Text.Trim())) {
                    pMensaje += "- Seleccionar tipo documento\n";
                }
                if (cbEmpresa.SelectedIndex == 0) {
                    pMensaje += "- Seleccionar empresa\n";
                    vResultado = false;
                }
                if (cbVenta.SelectedValue.Equals(0)) {
                    int intCont = 0;
                    foreach (DataGridViewRow vFila in dgvLineaVenta.Rows) {
                        if (!vFila.IsNewRow) {
                            intCont++;
                        }
                    }
                    if (intCont == 0) {
                        pMensaje += "- Ingresar mínimo una línea de venta";
                        vResultado = false;                        
                    }
                }
                return vResultado;
            }

            private BEVenta ObtenerVentaFormulario() {
                BEVenta oBEVenta = new BEVenta();
                oBEVenta.IdVenta = int.Parse(cbVenta.SelectedValue.ToString());
                oBEVenta.IdTipoDocumentoVenta = (cbTipoDocumento.SelectedIndex == 0) ? string.Empty : cbTipoDocumento.SelectedValue.ToString();
                oBEVenta.NumeroDocumento = string.IsNullOrEmpty(txtNroDocumento.Text.Trim()) ? string.Empty : txtNroDocumento.Text.Trim();
                oBEVenta.Precio = nudPredio.Value;
                oBEVenta.EsSobrante = ckbEsSobrante.Checked ? eVentaEsSobrante.Si : eVentaEsSobrante.No;
                oBEVenta.Observacion = txtObservacionesVenta.Text;
                oBEVenta.IdEstado = BEVenta.REGISTRADO;
                oBEVenta.IdCaja = VariablesSession.BECaja.IdCaja;
                oBEVenta.IdEmpresa = int.Parse(cbEmpresa.SelectedValue.ToString());
                oBEVenta.IdProducto = int.Parse(cbProducto.SelectedValue.ToString());
                oBEVenta.IdCliente = (cbCliente.SelectedIndex <= 0) ? 0 : int.Parse(cbCliente.SelectedValue.ToString());
                oBEVenta.ClienteEventual = (cbCliente.SelectedIndex <= 0) ? cbCliente.Text : string.Empty;
                oBEVenta.BEUsuarioLogin = VariablesSession.BEUsuarioSession;
                oBEVenta.ListaLineaVenta = ObtenerLineaVentaFormulario();
                return oBEVenta;
            }

            private List<BELineaVenta> ObtenerLineaVentaFormulario() {
                List<BELineaVenta> vLista = new List<BELineaVenta>();
                BELineaVenta oBELineaVenta = null;
                foreach (DataGridViewRow oLineaVenta in dgvLineaVenta.Rows) {
                    if (!oLineaVenta.IsNewRow) {
                        oBELineaVenta = new BELineaVenta();
                        // Tara
                        int intFlagEsTaraEditada = 0;
                        int.TryParse(oLineaVenta.Cells[ePosicionCol.FlagJava.GetHashCode()].Value.ToString(), out intFlagEsTaraEditada);
                        decimal decTara = decimal.MinValue;
                        if (intFlagEsTaraEditada == 1) {
                            decTara = decimal.Parse(oLineaVenta.Cells[ePosicionCol.PesoJava.GetHashCode()].Value.ToString());
                        }
                        // Peso Tara
                        int intFlagEsPesoTaraEditado = 0;
                        int.TryParse(oLineaVenta.Cells[ePosicionCol.FlagPesoTara.GetHashCode()].Value.ToString(), out intFlagEsPesoTaraEditado);
                        // Establecer loa valores
                        oBELineaVenta.CantidadJavas = int.Parse(oLineaVenta.Cells[ePosicionCol.CantidadJavas.GetHashCode()].Value.ToString());
                        oBELineaVenta.TaraEditada = decTara;
                        oBELineaVenta.PesoBruto = decimal.Parse(oLineaVenta.Cells[ePosicionCol.PesoBruto.GetHashCode()].Value.ToString());
                        oBELineaVenta.EsPesoTaraEditado = (intFlagEsPesoTaraEditado == 1) ? "S" : "N";
                        oBELineaVenta.PesoTara = decimal.Parse(oLineaVenta.Cells[ePosicionCol.PesoTara.GetHashCode()].Value.ToString());
                        oBELineaVenta.PesoNeto = decimal.Parse(oLineaVenta.Cells[ePosicionCol.PesoNeto.GetHashCode()].Value.ToString());
                        oBELineaVenta.EsDevolucion = "N";
                       
                        oBELineaVenta.Observacion = (intFlagEsPesoTaraEditado == 1 && oLineaVenta.Cells[ePosicionCol.Observaciones.GetHashCode()].Value != DBNull.Value) ? oLineaVenta.Cells[ePosicionCol.Observaciones.GetHashCode()].Value.ToString() : string.Empty;
                        oBELineaVenta.IdEstado = BEVenta.REGISTRADO;

                        oBELineaVenta.Unidades = int.Parse(oLineaVenta.Cells[ePosicionCol.CantidadPollos.GetHashCode()].Value.ToString());
                        
                        vLista.Add(oBELineaVenta);
                    }
                }
                return vLista;
            }

            private void CargarControlesBusqueda() {
                CargarZona(cbZonaB);
                CargarProducto(cbProductoB, true);
                // Cliente
                List<BEClienteProveedor> vListaCliente = new List<BEClienteProveedor>();
                BEClienteProveedor oTemp = new BEClienteProveedor();
                oTemp.IdZona = 0;
                vListaCliente = new BLClienteProveedor().Listar(oTemp);
                vListaCliente.Insert(0, new BEClienteProveedor(0, "Todos"));
                cbClienteB.DataSource = vListaCliente;
                cbClienteB.DisplayMember = "Nombre";
                cbClienteB.ValueMember = "IdCliente";
            }

            private void CargarListaVentas(bool pIndicadorBusqueda, int pIdVenta, int pIdZona, int pIdProducto, int pIdCliente) {
                DGP_Util.LiberarGridView(dgvListaVenta);
                if (pIndicadorBusqueda) {
                    dgvListaVenta.DataSource = new BLVenta().ListarVenta(pIdVenta, VariablesSession.BEUsuarioSession.IdCaja, pIdZona, pIdProducto, pIdCliente);                    
                } else {
                    dgvListaVenta.DataSource = new BLVenta().ListarVenta(0, VariablesSession.BEUsuarioSession.IdCaja);                
                }
                // Validar el PAGO para los Clientes Eventuales
                DataGridViewCellStyle oCellStyle = null;
                foreach (DataGridViewRow vRow in dgvListaVenta.Rows) {
                    object objIdCliente = vRow.Cells[ePosicionLista.IdCliente.GetHashCode()].Value;
                    object objIdEsSobranteDia = vRow.Cells[ePosicionLista.EsSobranteDia.GetHashCode()].Value;
                    object objIdEstado = vRow.Cells[ePosicionLista.IdEstado.GetHashCode()].Value;
                    if (objIdCliente != null && objIdEsSobranteDia != null) {
                        int intIdCliente = 0;
                        eVentaEsSobrante mVentaEsSobrante = eVentaEsSobrante.No;
                        intIdCliente = Convert.ToInt32(objIdCliente);
                        mVentaEsSobrante = (eVentaEsSobrante)Convert.ToInt32(objIdEsSobranteDia);
                        string strIdEstado = objIdEstado.ToString();
                        oCellStyle = new DataGridViewCellStyle();
                        oCellStyle.BackColor = Color.Silver;
                        oCellStyle.ForeColor = Color.Silver;
                        oCellStyle.SelectionBackColor = Color.Silver;
                        oCellStyle.SelectionForeColor = Color.Silver;
                        // Validar si es Cliente Eventual
                        // if (intIdCliente == 0 && .....
                        if (mVentaEsSobrante == eVentaEsSobrante.No && !strIdEstado.Equals(BEVenta.CANCELADO))
                        {
                            vRow.Cells[ePosicionLista.Pago.GetHashCode()].ReadOnly = false;
                            vRow.Cells[ePosicionLista.Pago.GetHashCode()].Value = string.Empty;
                            ((DataGridViewButtonCell)vRow.Cells[ePosicionLista.BottonPagar.GetHashCode()]).ReadOnly = false;                            
                        } else {
                            vRow.Cells[ePosicionLista.Pago.GetHashCode()].ReadOnly = true;
                            ((DataGridViewButtonCell)vRow.Cells[ePosicionLista.BottonPagar.GetHashCode()]).ReadOnly = true;
                            vRow.Cells[ePosicionLista.Pago.GetHashCode()].Style = oCellStyle;
                            ((DataGridViewButtonCell)vRow.Cells[ePosicionLista.BottonPagar.GetHashCode()]).Style = oCellStyle;
                        }
                    }
                }
            }

        private void TxtTABToENTER_KeyPress(object sender, KeyPressEventArgs e)   
        {   //this.Controls[1].Focus
            if (e.KeyChar == (char)(Keys.Enter))   
            {   
                e.Handled = true;   
                SendKeys.Send("{TAB}");   
            }   
        }

        #endregion

        #region "Métodos de Validación de frmTableroElectronico.aspx"

            private bool ValidarCampos(ref string pMensaje, int pRowIndex, int pColumnIndex) {
                bool boResultado = true;
                try {
                    switch ((ePosicionCol)pColumnIndex) {
                        case ePosicionCol.CantidadJavas : // Para las Cantidades de Java
                            // Validar Campo vacio y valor
                            if (ValidarCantidadJavas(ref pMensaje, pRowIndex) && ValidarCantidadUnidades(ref pMensaje, pRowIndex))
                            {
                                // Calcular Cantidades de Javas
                                CalcularCantidadJavas(pRowIndex);
                                // Reestablecer Style de la Columna de Observacion
                                oCeldaObservaciones = new DataGridViewCellStyle();
                                oCeldaObservaciones.SelectionBackColor = Color.White;
                                oCeldaObservaciones.BackColor = Color.White;
                                dgvLineaVenta[ePosicionCol.Observaciones.GetHashCode(), pRowIndex].ReadOnly = true;
                                dgvLineaVenta[ePosicionCol.Observaciones.GetHashCode(), pRowIndex].Style = oCeldaObservaciones;
                            } else {
                                boResultado = false;
                                dgvLineaVenta.CancelEdit();
                            }
                            break;
                        case ePosicionCol.PesoJava : // Para el Peso Java
                            // Validar campo vacio y valor
                            if (ValidarPesoJava(ref pMensaje, pRowIndex)) {
                                // Validar si es Editado
                                object oPesoJava = dgvLineaVenta[pColumnIndex, pRowIndex].Value;
                                if (vg_decTara.Equals(decimal.Parse(oPesoJava.ToString()))) {
                                    // Reestablecer el Flag y el PesoJavaDefecto
                                    dgvLineaVenta[ePosicionCol.FlagJava.GetHashCode(), pRowIndex].Value = "0";
                                    dgvLineaVenta[ePosicionCol.PesoJavaDefecto.GetHashCode(), pRowIndex].Value = vg_decTara;
                                } else {
                                    // Cambiar el Flag y el PesoJavaDefecto
                                    dgvLineaVenta[ePosicionCol.FlagJava.GetHashCode(), pRowIndex].Value = "1";
                                    dgvLineaVenta[ePosicionCol.PesoJavaDefecto.GetHashCode(), pRowIndex].Value = decimal.Parse(oPesoJava.ToString());
                                    RecalcularPesoJava(pRowIndex);
                                }
                            } else {
                                boResultado = false;
                                dgvLineaVenta.CancelEdit();
                            }
                            break;
                        case ePosicionCol.PesoBruto: // Para el Peso Bruto
                            // Validar campo vacio y valor
                            if (ValidarPesoBruto(ref pMensaje, pRowIndex)) {
                                // Calcular Peso Bruto
                                CalcularPesoBruto(pRowIndex);
                            } else {
                                boResultado = false;
                                dgvLineaVenta.CancelEdit();
                            }
                            break;
                        case ePosicionCol.PesoTara: // Para el Peso tara
                            // Validar campo vacio y valor
                            if (ValidarPesoTara(ref pMensaje, pRowIndex)) {
                                bool boLectura = true;
                                oCeldaObservaciones = new DataGridViewCellStyle();
                                // Validar si es Editado
                                object oPesoTara = dgvLineaVenta[pColumnIndex, pRowIndex].Value;
                                if (vg_strPesoTara.Equals(oPesoTara.ToString())) {
                                    dgvLineaVenta[ePosicionCol.FlagPesoTara.GetHashCode(), pRowIndex].Value = "0";
                                    // Reestablecer Style de la Columna de Observacion
                                    oCeldaObservaciones.SelectionBackColor = Color.White;
                                    oCeldaObservaciones.BackColor = Color.White;
                                } else {
                                    dgvLineaVenta[ePosicionCol.FlagPesoTara.GetHashCode(), pRowIndex].Value = "1";
                                    // Recalcular Peso Tara
                                    RecalcularPesoTara(pRowIndex);
                                    // Establecer Style de la Columna de Observacion
                                    oCeldaObservaciones.SelectionBackColor = Color.LightSalmon;
                                    oCeldaObservaciones.BackColor = Color.LightSalmon;
                                    boLectura = false;
                                }
                                dgvLineaVenta[ePosicionCol.Observaciones.GetHashCode(), pRowIndex].ReadOnly = boLectura;
                                dgvLineaVenta[ePosicionCol.Observaciones.GetHashCode(), pRowIndex].Style = oCeldaObservaciones;
                            } else {
                                boResultado = false;
                                dgvLineaVenta.CancelEdit();
                            }
                            break;
                    }
                } catch (Exception ex) {
                    pMensaje = ex.Message;
                    boResultado = false;
                }
                return boResultado;
            }

            private bool ValidarCantidadJavas(ref string pMensaje, int pRowIndex) {
                bool boIndicadorCJ = true;
                object oCantidad = dgvLineaVenta[ePosicionCol.CantidadJavas.GetHashCode(), pRowIndex].Value;
                if (oCantidad == null || string.IsNullOrEmpty(oCantidad.ToString())) {
                    if (!string.IsNullOrEmpty(vg_strCantidad)) {
                        GridViewEstablecerValor(vg_strCantidad, pRowIndex, ePosicionCol.CantidadJavas.GetHashCode());                    
                    } else {
                        boIndicadorCJ = false;
                        pMensaje = "Ingresar cantidad javas";
                    }
                } else {
                    // Validar que sea de tipo Int
                    int intCantidadJavas = 0;
                    int.TryParse(oCantidad.ToString(), out intCantidadJavas);
                    if (intCantidadJavas < 0) {
                        boIndicadorCJ = false;
                        pMensaje = "Ingresar cantidad javas válida";
                        GridViewEstablecerValor(vg_strCantidad, pRowIndex, ePosicionCol.CantidadJavas.GetHashCode());
                    }
                }
                return boIndicadorCJ;
            }

        private bool ValidarCantidadUnidades(ref string pMensaje, int pRowIndex)
        {
            bool boIndicadorCJ = true;
            object oCantidadJavas = dgvLineaVenta[ePosicionCol.CantidadJavas.GetHashCode(), pRowIndex].Value;
            decimal cantidadPollos = 0;
            bool resultado = decimal.TryParse(oCantidadJavas.ToString(), out cantidadPollos);
            cantidadPollos = cantidadPollos * this.vg_unidades_por_java;

            GridViewEstablecerValor(cantidadPollos, pRowIndex, ePosicionCol.CantidadPollos.GetHashCode());

            return boIndicadorCJ;
        }

            private bool ValidarPesoJava(ref string pMensaje, int pRowIndex) {
                bool boIndicadorPJ = true;
                object oPesoJava = dgvLineaVenta[ePosicionCol.PesoJava.GetHashCode(), pRowIndex].Value;
                if (oPesoJava == null || string.IsNullOrEmpty(oPesoJava.ToString())) {
                    GridViewEstablecerValor(vg_decTara, pRowIndex, ePosicionCol.PesoJava.GetHashCode());
                } else {
                    // Validar que sea de tipo decimal
                    decimal decPesoJava = decimal.Zero;
                    decimal.TryParse(oPesoJava.ToString(), out decPesoJava);
                    if (decPesoJava <decimal.Zero) {
                        boIndicadorPJ = false;
                        pMensaje = "Ingresar peso javas válido";
                        GridViewEstablecerValor(vg_decTara, pRowIndex, ePosicionCol.PesoJava.GetHashCode());
                    }
                }
                return boIndicadorPJ;
            }

            private bool ValidarPesoBruto(ref string pMensaje, int pRowIndex) {
                bool boIndicadorPB = true;
                object oPesoBruto = dgvLineaVenta[ePosicionCol.PesoBruto.GetHashCode(), pRowIndex].Value;
                if (oPesoBruto == null || string.IsNullOrEmpty(oPesoBruto.ToString())) {
                    if (!string.IsNullOrEmpty(vg_strPesoBruto)) {
                        GridViewEstablecerValor(vg_strPesoBruto, pRowIndex, ePosicionCol.PesoBruto.GetHashCode());
                    } else {
                        boIndicadorPB = false;
                        pMensaje = "Ingresar peso bruto";
                    }
                } else {
                    // Validar que sea de tipo decimal
                    decimal decPesoBruto = decimal.Zero;
                    decimal.TryParse(oPesoBruto.ToString(), out decPesoBruto);
                    if (decPesoBruto <= decimal.Zero) {
                        boIndicadorPB = false;
                        pMensaje = "Ingresar peso bruto válido";
                        GridViewEstablecerValor(string.Empty, pRowIndex, ePosicionCol.PesoBruto.GetHashCode());
                    }
                }
                return boIndicadorPB;
            }

            private bool ValidarPesoTara(ref string pMensaje, int pRowIndex) {
                bool boIndicadorPT = true;
                object oPesoTara = dgvLineaVenta[ePosicionCol.PesoTara.GetHashCode(), pRowIndex].Value;
                if (oPesoTara == null || string.IsNullOrEmpty(oPesoTara.ToString())) {
                    if (!string.IsNullOrEmpty(vg_strPesoTara)) {
                        GridViewEstablecerValor(vg_strPesoTara, pRowIndex, ePosicionCol.PesoTara.GetHashCode());
                        RecalcularPesoTara(pRowIndex);
                    } else {
                        boIndicadorPT = false;
                        pMensaje = "Ingresar peso tara";
                    }
                } else {
                    // Validar que sea de tipo decimal
                    decimal decPesoTara = decimal.Zero;
                    decimal.TryParse(oPesoTara.ToString(), out decPesoTara);
                    if (decPesoTara < decimal.Zero) {
                        boIndicadorPT = false;
                        pMensaje = "Ingresar peso tara válido";
                        GridViewEstablecerValor(vg_strPesoTara, pRowIndex, ePosicionCol.PesoTara.GetHashCode());
                    }
                }
                return boIndicadorPT;
            }

            private void CalcularCantidadJavas(int pRowIndex) {
                object oCantidad = dgvLineaVenta[ePosicionCol.CantidadJavas.GetHashCode(), pRowIndex].Value;
                object oPesoJava = dgvLineaVenta[ePosicionCol.PesoJava.GetHashCode(), pRowIndex].Value;
                // Calcular Peso Tara
                int intCantidad = int.Parse(oCantidad.ToString());
                decimal decPesoJava = decimal.Parse(oPesoJava.ToString());
                decimal decPesoTara = (intCantidad * decPesoJava);
                GridViewEstablecerValor(decPesoTara, pRowIndex, ePosicionCol.PesoTara.GetHashCode());
                // Recalcular Peso Neto
                object oPesoBruto = dgvLineaVenta[ePosicionCol.PesoBruto.GetHashCode(), pRowIndex].Value;
                if (!string.IsNullOrEmpty(oPesoBruto.ToString())) {
                    decimal decPesoBruto = decimal.Parse(oPesoBruto.ToString());
                    decimal decPesoNeto = (decPesoBruto - decPesoTara);
                    GridViewEstablecerValor(decPesoNeto, pRowIndex, ePosicionCol.PesoNeto.GetHashCode());
                }
            }

            private void RecalcularPesoJava(int pRowIndex) {
                object oCantidad = dgvLineaVenta[ePosicionCol.CantidadJavas.GetHashCode(), pRowIndex].Value;
                // Recalcular Peso Tara
                object oPesoJava = dgvLineaVenta[ePosicionCol.PesoJava.GetHashCode(), pRowIndex].Value;
                if (!string.IsNullOrEmpty(oCantidad.ToString())) {
                    int intCantidad = int.Parse(oCantidad.ToString());
                    decimal decPesoJava = decimal.Parse(oPesoJava.ToString());
                    decimal decPesoTara = (intCantidad * decPesoJava);
                    GridViewEstablecerValor(decPesoTara, pRowIndex, ePosicionCol.PesoTara.GetHashCode());
                    // Recalcular Peso Neto
                    object oPesoBruto = dgvLineaVenta[ePosicionCol.PesoBruto.GetHashCode(), pRowIndex].Value;
                    if (!string.IsNullOrEmpty(oPesoBruto.ToString())) {
                        decimal decPesoBruto = decimal.Parse(oPesoBruto.ToString());
                        decimal decPesoNeto = (decPesoBruto - decPesoTara);
                        GridViewEstablecerValor(decPesoNeto, pRowIndex, ePosicionCol.PesoNeto.GetHashCode());
                    }
                }
            }

            private void CalcularPesoBruto(int pRowIndex) {
                object oPesoTara = dgvLineaVenta[ePosicionCol.PesoTara.GetHashCode(), pRowIndex].Value;
                object oPesoBruto = dgvLineaVenta[ePosicionCol.PesoBruto.GetHashCode(), pRowIndex].Value;
                // Recalcular Peso Neto
                if (!string.IsNullOrEmpty(oPesoTara.ToString())) {
                    decimal decPesoTara = decimal.Parse(oPesoTara.ToString());
                    decimal decPesoBruto = decimal.Parse(oPesoBruto.ToString());
                    decimal decPesoNeto = (decPesoBruto - decPesoTara);
                    GridViewEstablecerValor(decPesoNeto, pRowIndex, ePosicionCol.PesoNeto.GetHashCode());
                }
            }

            private void RecalcularPesoTara(int pRowIndex) {
                object oPesoBruto = dgvLineaVenta[ePosicionCol.PesoBruto.GetHashCode(), pRowIndex].Value;
                object oPesoTara = dgvLineaVenta[ePosicionCol.PesoTara.GetHashCode(), pRowIndex].Value;
                // Recalcular Peso Neto
                if (!string.IsNullOrEmpty(oPesoBruto.ToString())) {
                    decimal decPesoBruto = decimal.Parse(oPesoBruto.ToString());
                    decimal decPesoTara = decimal.Parse(oPesoTara.ToString());
                    decimal decPesoNeto = (decPesoBruto - decPesoTara);
                    GridViewEstablecerValor(decPesoNeto, pRowIndex, ePosicionCol.PesoNeto.GetHashCode());
                }
            }

            private void GridViewEstablecerValor(object pValor, int pRowIndex, int pColumnIndex) {
                dgvLineaVenta[pColumnIndex, pRowIndex].Value = pValor;
            }


            private bool ValidarCamposLista(ref string pMensaje, int pRowIndex, int pColumnIndex) {
                bool boResultado = true;
                try {
                    switch ((ePosicionLista)pColumnIndex) {
                        case ePosicionLista.Pago:
                            // Validar campo vacio y valor
                            if (!ValidarPago(ref pMensaje, pRowIndex)) {
                                boResultado = false;
                                dgvListaVenta[pColumnIndex, pRowIndex].Value = "";
                                dgvListaVenta.CancelEdit();
                            }
                            break;
                    }
                } catch (Exception ex) {
                    pMensaje = ex.Message;
                    boResultado = false;
                }
                return boResultado;
            }

            private bool ValidarPago(ref string pMensaje, int pRowIndex) {
                bool boIndicador = true;
                object oPagoCuenta = dgvListaVenta[ePosicionLista.Pago.GetHashCode(), pRowIndex].Value;
                if (oPagoCuenta == null || string.IsNullOrEmpty(oPagoCuenta.ToString())) {
                    boIndicador = true;
                } else {
                    // Validar que sea de tipo decimal
                    decimal decPagoCuenta = decimal.Zero;
                    decimal.TryParse(oPagoCuenta.ToString(), out decPagoCuenta);
                    if (decPagoCuenta <= decimal.Zero) {
                        boIndicador = false;
                        pMensaje = "Ingresar pago válido";
                    }
                }
                return boIndicador;
            }

        private void CargarVentanaCuentas (int IdCliente ,  int IdProducto)
        {
            frmAmortizacion oVentas_frmAmortizacion = new frmAmortizacion(IdCliente , this);
            
            //oVentas_frmAmortizacion.MdiParent = this;
            //oVentas_frmAmortizacion.Show();
            oVentas_frmAmortizacion.SetCliente(IdCliente, IdProducto);
            oVentas_frmAmortizacion.ShowDialog(this);
        
        
        }

        #endregion

        private enum ePosicionCol {
            FlagJava = 0
            ,PesoJavaDefecto = 1
            ,FlagPesoTara = 2
            ,CantidadJavas = 3
           
            
            ,PesoJava = 4
            ,PesoBruto = 5
            ,PesoTara = 6
            ,PesoNeto = 7
            ,CantidadPollos = 8
            ,Observaciones = 9
            ,BotonEliminar = 10
            
        }

        private enum ePosicionLista { 
            IdVenta = 0
            ,SaldoAnterior = 9
            ,Pago = 10
           ,IdEstado = 11
            ,IdCliente = 12
            ,EsSobranteDia = 13
            
           , BotonCuentas = 14
          , BottonPagar = 15
        }

        private void dgvGastos_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //
                dtGastos.limpiarError();
                if (filaAgregada > 0 && !dtGastos.existeFilaAgregada(filaAgregada))
                {
                    string mensajeError = string.Empty;
                    if (!validarEdicionFila(ref mensajeError, filaAgregada-1))
                    {

                        MessageBox.Show(this, mensajeError);

                        dgvGastos.Focus();
                        dgvGastos.Rows[filaAgregada - 1].Selected = true;
                        return;

                    }

                    //DataGridViewCell
                    //object objIdCliente = this.rowClienteProveedor.Id_Cliente;
                    //object objIdPersonal = this.dgvGastos.Rows[filaAgregada - 1].Cells["idpersonalDataGridViewTextBoxColumn"].Value;
                    // object objIdCaja = this.dgvGastos.Rows[filaAgregada - 1].Cells["idcajaDataGridViewTextBoxColumn"].Value;

                    object objMonto = this.dgvGastos.Rows[filaAgregada - 1].Cells["montoDataGridViewTextBoxColumn"].Value;
                    object objConcepto = this.dgvGastos.Rows[filaAgregada - 1].Cells["conceptoDataGridViewTextBoxColumn"].Value;
                    object IdTipoGasto = this.dgvGastos.Rows[filaAgregada - 1].Cells["idtipoGastoDataGridViewTextBoxColumn"].Value;
                    object objObservacion = this.dgvGastos.Rows[filaAgregada - 1].Cells["observacionDataGridViewTextBoxColumn"].Value;

                    DSEntitiesTablero.tb_gastoRow row = this.dtGastos.Newtb_gastoRow();

                    row.id_personal = VariablesSession.BECaja.IdPersonal;
                    row.id_tipo_Gasto = int.Parse(IdTipoGasto.ToString());
                    row.id_caja = VariablesSession.BECaja.IdCaja;
                    row.monto = (objMonto==null)? 0 : decimal.Parse(objMonto.ToString()); //-1*row.Table.Rows.Count;
                    row.concepto = objConcepto.ToString();
                    row.observacion = objObservacion.ToString();
                    row.fecha_gasto = VariablesSession.BECaja.Fecha.Date;
                    row.FilaAgregada = filaAgregada;

                    filaAgregada = -1;

                    this.dtGastos.Addtb_gastoRow(row);

                   
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message, "dgvGastos_RowLeave_1");

            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                tb_gastoTableAdapter gastoTableAdapter = new tb_gastoTableAdapter();
                gastoTableAdapter.Update(this.dtGastos);
                dtGastos.AcceptChanges();
                
                
                this.loadGastos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message, "dgvGastos_UserAddedRow");
            }

        }

        private void dgvGastos_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                //string x = e.Row.Cells["nombresDataGridViewTextBoxColumn"].Value.ToString();
                filaAgregada = e.Row.Index;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "dgvGastos_UserAddedRow");
            }

        }
        private void CambiarPrecioCliente(BEVenta oBEVenta)
        {
            try
            {
                //(oBEVenta.Precio, oBEVenta.Producto)
                BLProductoCliente blProductoCliente = new BLProductoCliente();
                BEProductoCliente beProductoCliente = new BEProductoCliente();
                beProductoCliente.IdCliente= oBEVenta.IdCliente;
                beProductoCliente.IdProducto = oBEVenta.IdProducto;
                decimal precioDB = blProductoCliente.ObtenerPrecioVenta(beProductoCliente);

                if (precioDB != oBEVenta.Precio)
                {
                    if (MessageBox.Show("¿Deseas Cambiarle el precio actual?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    { 
                        beProductoCliente.PrecioVenta = oBEVenta.Precio;
                        blProductoCliente.cambioPrecioProveedor(beProductoCliente);
                    
                    }
                    

                
                }


 



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                
                //MessageBox.Show(this, ex.Message, "CambiarPrecioCliente");
            }
        
        }

        private void chkbAlContado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbAlContado.Checked)
            {
                this.nudAmortizacion.Value = 0;
                this.nudAmortizacion.Enabled = false;

            
            }
            else
            {
                this.nudAmortizacion.Enabled = true;
            
            }
        }

        private void dgvGastos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                Exception exec = e.Exception;
                //DataGridViewComboBoxColumn cc = new DataGridViewComboBoxColumn();
                // cc.

            }
            catch (Exception ex)
            {

                //throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                

                tb_gastoTableAdapter gastoTableAdapter = new tb_gastoTableAdapter();
                DSEntitiesTablero.tb_gastoDataTable dtGastos = (DSEntitiesTablero.tb_gastoDataTable)this.bdsGasto2.DataSource;

                gastoTableAdapter.Update(dtGastos);
                dtGastos.AcceptChanges();
              
            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message, "dgvGastos_UserAddedRow");
            }

        }

        private void dgvGastos2_Validated(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(this, "vvvvv", "dgvGastos_UserAddedRow");
        }

        

       

      

        //private void dgvGastos_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        //string x = e.Row.Cells["nombresDataGridViewTextBoxColumn"].Value.ToString();
        //        filaAgregada = e.Row.Index;

        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(this, ex.Message, "dgvGastos_UserAddedRow");
        //    }
        //}
      

       
        //private void dgvGastos_RowLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        DataRowView drvGasto = (DataRowView)this.dgvGastos.Rows[e.RowIndex].DataBoundItem;
                
        //        DSEntitiesTablero.tb_gastoRow filaGasto = (DSEntitiesTablero.tb_gastoRow)drvGasto.Row;
        //        if (filaGasto.IsconceptoNull() || filaGasto.IsmontoNull())
        //        {
                    
        //            MessageBox.Show("El monto y el concepto son datos obligatorios", "Erroor", MessageBoxButtons.OK);
                   
        //            return;
                    
        //        }
        //        tb_gastoTableAdapter gastoAdapter = new tb_gastoTableAdapter();
                
        //        gastoAdapter.InsertarGasto(VariablesSession.BECaja.IdPersonal,
        //                                    VariablesSession.BECaja.IdCaja,
        //                                    filaGasto.monto,
        //                                    filaGasto.concepto,
        //                                    filaGasto.observacion == string.Empty ? null : filaGasto.observacion
        //                                    );


        //    }
        //    catch (Exception ex)
        //    {
                
        //        throw ex;
        //    }
        //}

        //private void btnAceptar_Click(object sender, EventArgs e)
        //{

        //}

        

    }
}