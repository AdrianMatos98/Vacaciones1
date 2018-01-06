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

    public partial class frmDevoluciones : Form {

        private int vg_intIdVenta = int.MinValue;
        private int vg_intIdProducto = int.MinValue;
        private decimal vg_decTara = decimal.Zero;
        private decimal gv_decTotalNeto = decimal.Zero;

        private string vg_strCantidad = string.Empty;
        private string vg_strPesoBruto = string.Empty;
        private string vg_strPesoTara = string.Empty;
        DataGridViewCellStyle oCeldaObservaciones = null;

        public frmDevoluciones() {
            InitializeComponent();
            InicializarFormulario();
        }

        #region "Eventos de frmDevoluciones.aspx"

            private void frmDevoluciones_Load(object sender, EventArgs e) {
                try {
                    dgrvDevolucion.AutoGenerateColumns = false;
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
                try {
                    // Validar si eligio el producto
                    if (!string.IsNullOrEmpty(cbCliente.Text.Trim())) { 
                        int intIdCliente = 0;
                        if (cbCliente.SelectedIndex <= 0) {
                            CargarVentaCliente(false, int.MinValue);
                            LimpiarDatosCliente();
                        } else {
                            int.TryParse(cbCliente.SelectedValue.ToString(), out intIdCliente);
                            CargarVentaCliente(true, intIdCliente);
                        }
                    } else {
                        if (this.Visible == true) {
                            DGP_Util.LiberarComboBox(cbVenta);
                        }
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }


            private void cbVenta_SelectedIndexChanged(object sender, EventArgs e) {
                try {
                    // Validar si eligio una Ventas
                    if (cbVenta.SelectedIndex > 0) {
                        int.TryParse(cbVenta.SelectedValue.ToString(), out vg_intIdVenta);
                        // Obtener datos de la Venta
                        BEVenta oBEVenta = new BLVenta().ObtenerVenta(vg_intIdVenta);
                        if (oBEVenta != null) {
                            BEProductoCliente oBEProductoCliente = new BEProductoCliente();
                            oBEProductoCliente.IdCliente = oBEVenta.IdCliente;
                            oBEProductoCliente.IdProducto = oBEVenta.IdProducto;
                            vg_decTara = new BLProductoCliente().ObtenerTara(oBEProductoCliente);
                            // Establecer los datos
                            vg_intIdProducto = oBEVenta.IdProducto;
                            lblProducto.Text = oBEVenta.Producto;
                            lblPrecio.Text = oBEVenta.Precio.ToString("#.00"); ;
                            lblTotalBruto.Text = oBEVenta.TotalPesoBruto.ToString();
                            lblTotalTara.Text = oBEVenta.TotalPesoTara.ToString();
                            lblTotalNeto.Text = oBEVenta.TotalPesoNeto.ToString();
                            DGP_Util.LiberarGridView(dgrvDevolucion);
                            DGP_Util.EnableControl(dgrvDevolucion, true);
                            dgrvDevolucion.AllowUserToAddRows = true;
                            DGP_Util.EnableControl(btnAceptarDevolucion, true);
                        }
                    } else {
                        vg_decTara = decimal.Zero;
                        vg_intIdVenta = int.MinValue;
                        vg_intIdProducto = int.MinValue;
                        lblProducto.ResetText();
                        lblPrecio.ResetText();
                        lblTotalBruto.ResetText();
                        lblTotalTara.ResetText();
                        lblTotalNeto.ResetText();
                        DGP_Util.EnableControl(dgrvDevolucion, false);
                        dgrvDevolucion.AllowUserToAddRows = false;
                        DGP_Util.LiberarGridView(dgrvDevolucion);
                        DGP_Util.EnableControl(btnAceptarDevolucion, false);
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void dgrvDevolucion_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
                dgrvDevolucion[0, e.RowIndex].Value = "0"; // Flag Java (Oculto)
                dgrvDevolucion[1, e.RowIndex].Value = "0"; // Flag Peso Tara (Oculto)
                dgrvDevolucion[2, e.RowIndex].Value = ""; // Peso Tara Calculado (Oculto)
                dgrvDevolucion[3, e.RowIndex].Value = ""; // Cantidad Javas (Ingreso)
                dgrvDevolucion[4, e.RowIndex].Value = vg_decTara; // Peso Java (Editable)
                dgrvDevolucion[5, e.RowIndex].Value = ""; // Peso Bruto (Ingreso)
                dgrvDevolucion[6, e.RowIndex].Value = ""; // Peso Tara (Calculado, Editable)
                dgrvDevolucion[7, e.RowIndex].Value = ""; // Peso Neto (Calculado)
                dgrvDevolucion[8, e.RowIndex].Value = ""; // Observacion (Condición)    
            }

            private void dgrvDevolucion_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
                bool boIndicador = false;
                // Validar que sea edicion si solo hay una fila
                if (dgrvDevolucion.Rows.Count == 1 && dgrvDevolucion.Rows[e.RowIndex].IsNewRow == true) {
                    boIndicador = true;
                } else {
                    // Validar que sea edicion para todas las demas menos la ultima
                    if (e.RowIndex < dgrvDevolucion.Rows.Count - 1) {
                        boIndicador = true;
                    }
                }
                if (boIndicador) {
                    // Validar que sea solo para algunas celdas
                    if (e.ColumnIndex != 9) {
                        Point oPoint = dgrvDevolucion.CurrentCellAddress;
                        if (oPoint.X == e.ColumnIndex && oPoint.Y == e.RowIndex && e.Button == MouseButtons.Left && dgrvDevolucion.EditMode != DataGridViewEditMode.EditProgrammatically) {
                            if (!dgrvDevolucion.IsCurrentCellInEditMode) {
                                dgrvDevolucion.BeginEdit(true);
                            }
                        }
                    }
                } else {
                    dgrvDevolucion.CancelEdit();
                }
            }

            private void dgrvDevolucion_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
                switch ((ePosicionCol)e.ColumnIndex) {
                    case ePosicionCol.CantidadJavas:
                        // Validar si existe valor
                        object oCantidad = dgrvDevolucion[ePosicionCol.CantidadJavas.GetHashCode(), e.RowIndex].Value;
                        if (oCantidad == null || string.IsNullOrEmpty(oCantidad.ToString())) {
                            vg_strCantidad = string.Empty;
                        } else {
                            vg_strCantidad = oCantidad.ToString();
                        }
                        break;
                    case ePosicionCol.PesoBruto:
                        // Validar si existe valor
                        object oPesoBruto = dgrvDevolucion[ePosicionCol.PesoBruto.GetHashCode(), e.RowIndex].Value;
                        if (oPesoBruto == null || string.IsNullOrEmpty(oPesoBruto.ToString())) {
                            vg_strPesoBruto = string.Empty;
                        } else {
                            vg_strPesoBruto = oPesoBruto.ToString();
                        }
                        break;
                    case ePosicionCol.PesoTara:
                        // Validar si existe valor
                        object oPesoTara = dgrvDevolucion[ePosicionCol.PesoTara.GetHashCode(), e.RowIndex].Value;
                        if (oPesoTara == null || string.IsNullOrEmpty(oPesoTara.ToString())) {
                            vg_strPesoTara = string.Empty;
                        } else {
                            // Calcular Peso tara
                            object oCantJavas = dgrvDevolucion[ePosicionCol.CantidadJavas.GetHashCode(), e.RowIndex].Value;
                            object oPesoJava = dgrvDevolucion[ePosicionCol.PesoJava.GetHashCode(), e.RowIndex].Value;
                            if (!string.IsNullOrEmpty(oCantJavas.ToString()) && !string.IsNullOrEmpty(oPesoJava.ToString())) {
                                vg_strPesoTara = (int.Parse(oCantJavas.ToString()) * decimal.Parse(oPesoJava.ToString())).ToString();
                            } else {
                                vg_strPesoTara = oPesoTara.ToString();
                            }
                        }
                        break;
                }
            }

            private void dgrvDevolucion_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
                string strMensaje = string.Empty;
                if (!ValidarCampos(ref strMensaje, e.RowIndex, e.ColumnIndex)) {
                    MostrarMensaje(strMensaje, MessageBoxIcon.Exclamation);
                }
            }

            private void dgrvDevolucion_CellContentClick(object sender, DataGridViewCellEventArgs e) {
                if (e.ColumnIndex == 9 && e.RowIndex >= 0) {
                    DataGridViewButtonCell objeto = (DataGridViewButtonCell)dgrvDevolucion[e.ColumnIndex, e.RowIndex];
                    if (!string.IsNullOrEmpty(objeto.FormattedValue.ToString())) {
                        dgrvDevolucion.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }

            private void btnAceptarDevolucion_Click(object sender, EventArgs e) {
                try {
                    BEVenta oBEVenta = ObtenerVentaFormulario();
                    int intResultado = 0;
                    intResultado = new BLVenta().RegistrarVentaDevolucionDependiente(oBEVenta);
                    if (intResultado == 2) {
                        MostrarMensaje("Se registro la amortización correctamente", MessageBoxIcon.Exclamation);
                        ResetearFormulario();
                        InicializarFormulario();
                    } else {
                        MostrarMensaje("No se pudo registrar la amortización, intentelo de nuevo", MessageBoxIcon.Exclamation);
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

        #endregion

        #region "Métodos de frmDevoluciones.aspx"

            private void MostrarMensaje(string pMensaje, MessageBoxIcon pMsgBoxicon) {
                MessageBox.Show(pMensaje, "DGP", MessageBoxButtons.OK, pMsgBoxicon);
            }

            private void InicializarFormulario() {
                try {
                    // Inicializar Controles
                    CargarCliente();
                } catch (Exception ex) {
                    throw ex;
                }
            }

            private void CargarCliente() {
                List<BEClienteProveedor> vListaCliente = new List<BEClienteProveedor>();
                BEClienteProveedor oTemp = new BEClienteProveedor();
                oTemp.IdZona = 0;
                vListaCliente = new BLClienteProveedor().Listar(oTemp);
                vListaCliente.Insert(0, new BEClienteProveedor(0, ""));
                cbCliente.DataSource = vListaCliente;
                cbCliente.DisplayMember = "Nombre";
                cbCliente.ValueMember = "IdCliente";
            }

            private void LimpiarDatosCliente() {
                vg_decTara = decimal.Zero;
                vg_intIdVenta = int.MinValue;
                vg_intIdProducto = int.MinValue;
                lblProducto.ResetText();
                lblTotalBruto.ResetText();
                lblTotalTara.ResetText();
                lblTotalNeto.ResetText();
                DGP_Util.EnableControl(dgrvDevolucion, false);
                dgrvDevolucion.AllowUserToAddRows = false;
                DGP_Util.LiberarGridView(dgrvDevolucion);
            }
            
            private void CargarVentaCliente(bool pValor, int pIdCliente) {
                List<BEVenta> vLista = new List<BEVenta>();
                if (pValor) {
                    BEVenta oBEVenta = new BEVenta();
                    oBEVenta.IdCliente = pIdCliente;
                    oBEVenta.IdCaja = VariablesSession.BEUsuarioSession.IdCaja;
                    vLista = new BLVenta().ListarVentaCliente(oBEVenta);
                }
                vLista.Insert(0, new BEVenta(-1, (vLista.Count == 0) ? string.Empty : "----Seleccione----"));
                cbVenta.DataSource = vLista;
                cbVenta.DisplayMember = "NombreVenta";
                cbVenta.ValueMember = "IdVenta";
            }

            private BEVenta ObtenerVentaFormulario() {
                BEVenta oBEVenta = new BEVenta();
                oBEVenta.IdVenta = vg_intIdVenta;
                oBEVenta.IdProducto = vg_intIdProducto;
                oBEVenta.IdCliente = int.Parse(cbCliente.SelectedValue.ToString());
                oBEVenta.BEUsuarioLogin = VariablesSession.BEUsuarioSession;
                oBEVenta.ListaAmortizacion = ObtenerDevoluciones();
                return oBEVenta;
            }

            private List<BELineaVenta> ObtenerDevoluciones() {
                List<BELineaVenta> vLista = new List<BELineaVenta>();
                BELineaVenta oBELineaVenta = null;
                foreach (DataGridViewRow oLineaVenta in dgrvDevolucion.Rows) {
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
                        oBELineaVenta.EsDevolucion = "S";
                        oBELineaVenta.Observacion = (intFlagEsPesoTaraEditado == 1) ? oLineaVenta.Cells[ePosicionCol.Observaciones.GetHashCode()].Value.ToString() : string.Empty;
                        oBELineaVenta.IdEstado = BEVenta.REGISTRADO;
                        vLista.Add(oBELineaVenta);
                    }
                }
                return vLista;
            }

            private void ResetearFormulario() { 
                vg_intIdVenta = int.MinValue;
                vg_intIdProducto = int.MinValue;
                vg_decTara = decimal.Zero;
                gv_decTotalNeto = decimal.Zero;
                vg_strCantidad = string.Empty;
                vg_strPesoBruto = string.Empty;
                vg_strPesoTara = string.Empty;
                DGP_Util.LiberarComboBox(cbCliente);
                DGP_Util.LiberarComboBox(cbVenta);
                LimpiarDatosCliente();
                DGP_Util.EnableControl(btnAceptarDevolucion, false);
            }

        #endregion

        #region "Métodos de Validación de frmTableroElectronico.aspx"

            private bool ValidarCampos(ref string pMensaje, int pRowIndex, int pColumnIndex) {
                bool boResultado = true;
                try {
                    switch ((ePosicionCol)pColumnIndex) {
                        case ePosicionCol.CantidadJavas: // Para las Cantidades de Java
                            // Validar Campo vacio y valor
                            if (ValidarCantidadJavas(ref pMensaje, pRowIndex)) {
                                // Calcular Cantidades de Javas
                                CalcularCantidadJavas(pRowIndex);
                                // Reestablecer Style de la Columna de Observacion
                                oCeldaObservaciones = new DataGridViewCellStyle();
                                oCeldaObservaciones.SelectionBackColor = Color.White;
                                oCeldaObservaciones.BackColor = Color.White;
                                dgrvDevolucion[ePosicionCol.Observaciones.GetHashCode(), pRowIndex].ReadOnly = true;
                                dgrvDevolucion[ePosicionCol.Observaciones.GetHashCode(), pRowIndex].Style = oCeldaObservaciones;
                            } else {
                                boResultado = false;
                                dgrvDevolucion.CancelEdit();
                            }
                            break;
                        case ePosicionCol.PesoJava: // Para el Peso Java
                            // Validar campo vacio y valor
                            if (ValidarPesoJava(ref pMensaje, pRowIndex)) {
                                // Validar si es Editado
                                object oPesoJava = dgrvDevolucion[pColumnIndex, pRowIndex].Value;
                                if (vg_decTara.Equals(decimal.Parse(oPesoJava.ToString()))) {
                                    // Reestablecer el Flag y el PesoJavaDefecto
                                    dgrvDevolucion[ePosicionCol.FlagJava.GetHashCode(), pRowIndex].Value = "0";
                                    dgrvDevolucion[ePosicionCol.PesoJavaDefecto.GetHashCode(), pRowIndex].Value = vg_decTara;
                                } else {
                                    // Cambiar el Flag y el PesoJavaDefecto
                                    dgrvDevolucion[ePosicionCol.FlagJava.GetHashCode(), pRowIndex].Value = "1";
                                    dgrvDevolucion[ePosicionCol.PesoJavaDefecto.GetHashCode(), pRowIndex].Value = decimal.Parse(oPesoJava.ToString());
                                    RecalcularPesoJava(pRowIndex);
                                }
                            } else {
                                boResultado = false;
                                dgrvDevolucion.CancelEdit();
                            }
                            break;
                        case ePosicionCol.PesoBruto: // Para el Peso Bruto
                            // Validar campo vacio y valor
                            if (ValidarPesoBruto(ref pMensaje, pRowIndex)) {
                                // Calcular Peso Bruto
                                CalcularPesoBruto(pRowIndex);
                            } else {
                                boResultado = false;
                                dgrvDevolucion.CancelEdit();
                            }
                            break;
                        case ePosicionCol.PesoTara: // Para el Peso tara
                            // Validar campo vacio y valor
                            if (ValidarPesoTara(ref pMensaje, pRowIndex)) {
                                bool boLectura = true;
                                oCeldaObservaciones = new DataGridViewCellStyle();
                                // Validar si es Editado
                                object oPesoTara = dgrvDevolucion[pColumnIndex, pRowIndex].Value;
                                if (vg_strPesoTara.Equals(oPesoTara.ToString())) {
                                    dgrvDevolucion[ePosicionCol.FlagPesoTara.GetHashCode(), pRowIndex].Value = "0";
                                    // Reestablecer Style de la Columna de Observacion
                                    oCeldaObservaciones.SelectionBackColor = Color.White;
                                    oCeldaObservaciones.BackColor = Color.White;
                                } else {
                                    dgrvDevolucion[ePosicionCol.FlagPesoTara.GetHashCode(), pRowIndex].Value = "1";
                                    // Recalcular Peso Tara
                                    RecalcularPesoTara(pRowIndex);
                                    // Establecer Style de la Columna de Observacion
                                    oCeldaObservaciones.SelectionBackColor = Color.LightSalmon;
                                    oCeldaObservaciones.BackColor = Color.LightSalmon;
                                    boLectura = false;
                                }
                                dgrvDevolucion[ePosicionCol.Observaciones.GetHashCode(), pRowIndex].ReadOnly = boLectura;
                                dgrvDevolucion[ePosicionCol.Observaciones.GetHashCode(), pRowIndex].Style = oCeldaObservaciones;
                            } else {
                                boResultado = false;
                                dgrvDevolucion.CancelEdit();
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
                object oCantidad = dgrvDevolucion[ePosicionCol.CantidadJavas.GetHashCode(), pRowIndex].Value;
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
                    if (intCantidadJavas <= 0) {
                        boIndicadorCJ = false;
                        pMensaje = "Ingresar cantidad javas válida";
                        GridViewEstablecerValor(vg_strCantidad, pRowIndex, ePosicionCol.CantidadJavas.GetHashCode());
                    }
                }
                return boIndicadorCJ;
            }

            private bool ValidarPesoJava(ref string pMensaje, int pRowIndex) {
                bool boIndicadorPJ = true;
                object oPesoJava = dgrvDevolucion[ePosicionCol.PesoJava.GetHashCode(), pRowIndex].Value;
                if (oPesoJava == null || string.IsNullOrEmpty(oPesoJava.ToString())) {
                    GridViewEstablecerValor(vg_decTara, pRowIndex, ePosicionCol.PesoJava.GetHashCode());
                } else {
                    // Validar los decimales
                    //if (DGP_Util.ValidarDigitosDecimales(oPesoJava.ToString())) {
                    // Validar que sea de tipo decimal
                    decimal decPesoJava = decimal.Zero;
                    decimal.TryParse(oPesoJava.ToString(), out decPesoJava);
                    if (decPesoJava <= decimal.Zero) {
                        boIndicadorPJ = false;
                        pMensaje = "Ingresar peso javas válido";
                        GridViewEstablecerValor(vg_decTara, pRowIndex, ePosicionCol.PesoJava.GetHashCode());
                    }
                    //} else {
                    //    boIndicadorPJ = false;
                    //    pMensaje = "Ingresar peso javas con dos(2) decimales";
                    //}
                }
                return boIndicadorPJ;
            }

            private bool ValidarPesoBruto(ref string pMensaje, int pRowIndex) {
                bool boIndicadorPB = true;
                object oPesoBruto = dgrvDevolucion[ePosicionCol.PesoBruto.GetHashCode(), pRowIndex].Value;
                if (oPesoBruto == null || string.IsNullOrEmpty(oPesoBruto.ToString())) {
                    if (!string.IsNullOrEmpty(vg_strPesoBruto)) {
                        GridViewEstablecerValor(vg_strPesoBruto, pRowIndex, ePosicionCol.PesoBruto.GetHashCode());
                    } else {
                        boIndicadorPB = false;
                        pMensaje = "Ingresar peso bruto";
                    }
                } else {
                    // Validar los decimales
                    //if (DGP_Util.ValidarDigitosDecimales(oPesoBruto.ToString())) {
                    // Validar que sea de tipo decimal
                    decimal decPesoBruto = decimal.Zero;
                    decimal.TryParse(oPesoBruto.ToString(), out decPesoBruto);
                    if (decPesoBruto <= decimal.Zero) {
                        boIndicadorPB = false;
                        pMensaje = "Ingresar peso bruto válido";
                        GridViewEstablecerValor(string.Empty, pRowIndex, ePosicionCol.PesoBruto.GetHashCode());
                    }
                    //} else {
                    //    boIndicadorPB = false;
                    //    pMensaje = "Ingresar peso bruto con dos(2) decimales";
                    //}
                }
                return boIndicadorPB;
            }

            private bool ValidarPesoTara(ref string pMensaje, int pRowIndex) {
                bool boIndicadorPT = true;
                object oPesoTara = dgrvDevolucion[ePosicionCol.PesoTara.GetHashCode(), pRowIndex].Value;
                if (oPesoTara == null || string.IsNullOrEmpty(oPesoTara.ToString())) {
                    if (!string.IsNullOrEmpty(vg_strPesoTara)) {
                        GridViewEstablecerValor(vg_strPesoTara, pRowIndex, ePosicionCol.PesoTara.GetHashCode());
                        RecalcularPesoTara(pRowIndex);
                    } else {
                        boIndicadorPT = false;
                        pMensaje = "Ingresar peso tara";
                    }
                } else {
                    // Validar los decimales
                    //if (DGP_Util.ValidarDigitosDecimales(oPesoTara.ToString())) {
                    // Validar que sea de tipo decimal
                    decimal decPesoTara = decimal.Zero;
                    decimal.TryParse(oPesoTara.ToString(), out decPesoTara);
                    if (decPesoTara <= decimal.Zero) {
                        boIndicadorPT = false;
                        pMensaje = "Ingresar peso tara válido";
                        GridViewEstablecerValor(vg_strPesoTara, pRowIndex, ePosicionCol.PesoTara.GetHashCode());
                    }
                    //} else {
                    //    boIndicadorPT = false;
                    //    pMensaje = "Ingresar peso tara con dos(2) decimales";
                    //}
                }
                return boIndicadorPT;
            }

            private void CalcularCantidadJavas(int pRowIndex) {
                object oCantidad = dgrvDevolucion[ePosicionCol.CantidadJavas.GetHashCode(), pRowIndex].Value;
                object oPesoJava = dgrvDevolucion[ePosicionCol.PesoJava.GetHashCode(), pRowIndex].Value;
                // Calcular Peso Tara
                int intCantidad = int.Parse(oCantidad.ToString());
                decimal decPesoJava = decimal.Parse(oPesoJava.ToString());
                decimal decPesoTara = (intCantidad * decPesoJava);
                GridViewEstablecerValor(decPesoTara, pRowIndex, ePosicionCol.PesoTara.GetHashCode());
                // Recalcular Peso Neto
                object oPesoBruto = dgrvDevolucion[ePosicionCol.PesoBruto.GetHashCode(), pRowIndex].Value;
                if (!string.IsNullOrEmpty(oPesoBruto.ToString())) {
                    decimal decPesoBruto = decimal.Parse(oPesoBruto.ToString());
                    decimal decPesoNeto = (decPesoBruto - decPesoTara);
                    GridViewEstablecerValor(decPesoNeto, pRowIndex, ePosicionCol.PesoNeto.GetHashCode());
                }
            }

            private void RecalcularPesoJava(int pRowIndex) {
                object oCantidad = dgrvDevolucion[ePosicionCol.CantidadJavas.GetHashCode(), pRowIndex].Value;
                // Recalcular Peso Tara
                object oPesoJava = dgrvDevolucion[ePosicionCol.PesoJava.GetHashCode(), pRowIndex].Value;
                if (!string.IsNullOrEmpty(oCantidad.ToString())) {
                    int intCantidad = int.Parse(oCantidad.ToString());
                    decimal decPesoJava = decimal.Parse(oPesoJava.ToString());
                    decimal decPesoTara = (intCantidad * decPesoJava);
                    GridViewEstablecerValor(decPesoTara, pRowIndex, ePosicionCol.PesoTara.GetHashCode());
                    // Recalcular Peso Neto
                    object oPesoBruto = dgrvDevolucion[ePosicionCol.PesoBruto.GetHashCode(), pRowIndex].Value;
                    if (!string.IsNullOrEmpty(oPesoBruto.ToString())) {
                        decimal decPesoBruto = decimal.Parse(oPesoBruto.ToString());
                        decimal decPesoNeto = (decPesoBruto - decPesoTara);
                        GridViewEstablecerValor(decPesoNeto, pRowIndex, ePosicionCol.PesoNeto.GetHashCode());
                    }
                }
            }

            private void CalcularPesoBruto(int pRowIndex) {
                object oPesoTara = dgrvDevolucion[ePosicionCol.PesoTara.GetHashCode(), pRowIndex].Value;
                object oPesoBruto = dgrvDevolucion[ePosicionCol.PesoBruto.GetHashCode(), pRowIndex].Value;
                // Recalcular Peso Neto
                if (!string.IsNullOrEmpty(oPesoTara.ToString())) {
                    decimal decPesoTara = decimal.Parse(oPesoTara.ToString());
                    decimal decPesoBruto = decimal.Parse(oPesoBruto.ToString());
                    decimal decPesoNeto = (decPesoBruto - decPesoTara);
                    GridViewEstablecerValor(decPesoNeto, pRowIndex, ePosicionCol.PesoNeto.GetHashCode());
                }
            }

            private void RecalcularPesoTara(int pRowIndex) {
                object oPesoBruto = dgrvDevolucion[ePosicionCol.PesoBruto.GetHashCode(), pRowIndex].Value;
                object oPesoTara = dgrvDevolucion[ePosicionCol.PesoTara.GetHashCode(), pRowIndex].Value;
                // Recalcular Peso Neto
                if (!string.IsNullOrEmpty(oPesoBruto.ToString())) {
                    decimal decPesoBruto = decimal.Parse(oPesoBruto.ToString());
                    decimal decPesoTara = decimal.Parse(oPesoTara.ToString());
                    decimal decPesoNeto = (decPesoBruto - decPesoTara);
                    GridViewEstablecerValor(decPesoNeto, pRowIndex, ePosicionCol.PesoNeto.GetHashCode());
                }
            }

            private void GridViewEstablecerValor(object pValor, int pRowIndex, int pColumnIndex) {
                dgrvDevolucion[pColumnIndex, pRowIndex].Value = pValor;
            }

        #endregion

        public enum ePosicionCol {
            FlagJava = 0
            ,PesoJavaDefecto = 1
            ,FlagPesoTara = 2
            ,CantidadJavas = 3
            ,PesoJava = 4
            ,PesoBruto = 5
            ,PesoTara = 6
            ,PesoNeto = 7
            ,Observaciones = 8
            , BotonEliminar = 9
        }



    }
}