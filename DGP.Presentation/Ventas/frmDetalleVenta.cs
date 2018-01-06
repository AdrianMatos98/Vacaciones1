using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DGP.Entities.Ventas;
using DGP.Entities;
using DGP.BusinessLogic.Ventas;
using DGP.BusinessLogic;

namespace DGP.Presentation.Ventas {

    public partial class frmDetalleVenta : Form {
        private int vg_intUnidades = 8;
        private int vg_intIdVenta = 0;
        private int vg_intIdProducto = 0;
        private int vg_intIdCliente = 0;
        private decimal vg_decPrecioVenta = decimal.Zero;
        private decimal vg_decTara = decimal.Zero;
        private string vg_strCantidad = string.Empty;
        private string vg_strPesoJava = string.Empty;
        private string vg_strPesoBruto = string.Empty;
        private string vg_strPesoTara = string.Empty;
        private BEVenta vg_BEVenta = null;
        private List<VistaAmortizacion> vg_ListaAmortizacionVenta = null;
        DataGridViewCellStyle oCellStyleObservaciones = null;
        DataGridViewCellStyle oCeldaPagoCuenta = null;

        private dsLineaVenta vg_dsLineaVenta = new dsLineaVenta();
        private dsLineaVenta vg_dsLineaVentaEliminados = new dsLineaVenta();

        private dsLineaVenta vg_dsDevolucionVenta = new dsLineaVenta();
        private dsLineaVenta vg_dsDevolucionVentaEliminados = new dsLineaVenta();

        private decimal PrecioInicial = 0;

        public frmDetalleVenta() {
            InitializeComponent();
        }

        public frmDetalleVenta(int pIdVenta) {
            InitializeComponent();
            vg_intIdVenta = pIdVenta;
            InicializarVenta();
            InicializarLineaVenta();
        }

        #region "Eventos de frmDetalleVenta.aspx"

            private void frmDetalleVenta_Load(object sender, EventArgs e) {
                try {
                    dgrvLineaVentaDS.AutoGenerateColumns = false;
                    lblSimboloMoneda.Text = VariablesSession.ISOCulture.NumberFormat.CurrencySymbol;
                    dgrvAmortizacion.AutoGenerateColumns = false;
                    lblSimboloMonedaAM.Text = VariablesSession.ISOCulture.NumberFormat.CurrencySymbol;
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void tcVenta_SelectedIndexChanged(object sender, EventArgs e) {
                try {
                    switch ((eTabDetalleVenta)tcVenta.SelectedIndex) {
                        case eTabDetalleVenta.TabLineaVenta:
                            InicializarLineaVenta();
                            break;
                        case eTabDetalleVenta.TabAmortizacionVenta:
                            InicializarAmortizacionVenta();
                            break;
                        case eTabDetalleVenta.TabDevolucionVenta:
                            InicializarDevolucionVenta();
                            break;
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }



            private void btnRestablecerLineaVenta_Click(object sender, EventArgs e) {
                try {
                    CargarLineaVenta();
                    ActualizarLineaVenta();
                    vg_dsLineaVentaEliminados = null;
                    vg_dsLineaVentaEliminados = new dsLineaVenta();
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void dgrvLineaVentaDS_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
                // Validar que sea solo para algunas celdas
                try
                {
                    if (e.ColumnIndex != ePosicionLineaDS.BotonEliminar.GetHashCode())
                    {
                        Point oPoint = dgrvLineaVentaDS.CurrentCellAddress;
                        if (oPoint.X == e.ColumnIndex && oPoint.Y == e.RowIndex && e.Button == MouseButtons.Left && dgrvLineaVentaDS.EditMode != DataGridViewEditMode.EditProgrammatically)
                        {
                            if (!dgrvLineaVentaDS.IsCurrentCellInEditMode)
                            {
                                dgrvLineaVentaDS.BeginEdit(true);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error); ;
                }
               
            }

            private void dgrvLineaVentaDS_CellContentClick(object sender, DataGridViewCellEventArgs e) {
                if (e.ColumnIndex == ePosicionLineaDS.BotonEliminar.GetHashCode() && e.RowIndex >= 0 && !string.IsNullOrEmpty(dgrvLineaVentaDS[ePosicionLineaDS.BotonEliminar.GetHashCode(), e.RowIndex].FormattedValue.ToString())) {
                    if (vg_dsLineaVenta.DTLineaVenta.Rows.Count > 0) {
                        if (vg_dsLineaVenta.DTLineaVenta[e.RowIndex].EsLineaVentaBD()) {
                            // Agregar la fila eliminada
                            object[] obj = vg_dsLineaVenta.DTLineaVenta[e.RowIndex].ItemArray;
                            dsLineaVenta.DTLineaVentaRow oLineaVenta = vg_dsLineaVentaEliminados.DTLineaVenta.NewDTLineaVentaRow();
                            oLineaVenta.ItemArray = obj;
                            vg_dsLineaVentaEliminados.DTLineaVenta.AddDTLineaVentaRow(oLineaVenta);
                            vg_dsLineaVentaEliminados.DTLineaVenta.AcceptChanges();
                        }
                        // Eliminar la fila de la tabla
                        vg_dsLineaVenta.DTLineaVenta.RemoveDTLineaVentaRow(vg_dsLineaVenta.DTLineaVenta[e.RowIndex]);
                        //ActualizarLineaVenta();
                        dgrvLineaVentaDS.Refresh();
                    }
                }
            }

            private void dgrvLineaVentaDS_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
                switch ((ePosicionLineaDS)e.ColumnIndex) {
                    case ePosicionLineaDS.CantidadJavas:
                        // Validar si existe valor
                        object oCantidad = dgrvLineaVentaDS[ePosicionLineaDS.CantidadJavas.GetHashCode(), e.RowIndex].Value;
                        if (oCantidad == null || string.IsNullOrEmpty(oCantidad.ToString())) {
                            vg_strCantidad = string.Empty;
                        } else {
                            vg_strCantidad = oCantidad.ToString();
                        }
                        break;
                    case ePosicionLineaDS.PesoJava:
                        // Validar si existe valor
                        object oPesoJava1 = dgrvLineaVentaDS[ePosicionLineaDS.PesoJava.GetHashCode(), e.RowIndex].Value;
                        if (oPesoJava1 == null || string.IsNullOrEmpty(oPesoJava1.ToString())) {
                            vg_strPesoJava = string.Empty;
                        } else {
                            vg_strPesoJava = oPesoJava1.ToString();
                        }
                        break;
                    case ePosicionLineaDS.PesoBruto:
                        // Validar si existe valor
                        object oPesoBruto = dgrvLineaVentaDS[ePosicionLineaDS.PesoBruto.GetHashCode(), e.RowIndex].Value;
                        if (oPesoBruto == null || string.IsNullOrEmpty(oPesoBruto.ToString())) {
                            vg_strPesoBruto = string.Empty;
                        } else {
                            vg_strPesoBruto = oPesoBruto.ToString();
                        }
                        break;
                    case ePosicionLineaDS.PesoTara:
                        // Validar si existe valor
                        object oPesoTara = dgrvLineaVentaDS[ePosicionLineaDS.PesoTara.GetHashCode(), e.RowIndex].Value;
                        if (oPesoTara == null || string.IsNullOrEmpty(oPesoTara.ToString())) {
                            vg_strPesoTara = string.Empty;
                        } else {
                            // Calcular Peso tara
                            object oCantJavas = dgrvLineaVentaDS[ePosicionLineaDS.CantidadJavas.GetHashCode(), e.RowIndex].Value;
                            object oPesoJava = dgrvLineaVentaDS[ePosicionLineaDS.PesoJava.GetHashCode(), e.RowIndex].Value;
                            if (!string.IsNullOrEmpty(oCantJavas.ToString()) && !string.IsNullOrEmpty(oPesoJava.ToString())) {
                                vg_strPesoTara = (int.Parse(oCantJavas.ToString()) * decimal.Parse(oPesoJava.ToString())).ToString();
                            } else {
                                vg_strPesoTara = oPesoTara.ToString();
                            }
                        }
                        break;
                }
            }

            private void dgrvLineaVentaDS_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
                try {
                    string strMensaje = string.Empty;
                    if (!dgrvLineaVentaDS.Rows[e.RowIndex].IsNewRow) {
                        // Validar si es una fila que esta en el DS
                        int intLastIndex = vg_dsLineaVenta.DTLineaVenta.Rows.Count - 1;
                        if (e.RowIndex <= intLastIndex) {
                            if (ValidarCamposLineaVentaDS(ref strMensaje, e.RowIndex, e.ColumnIndex)) {
                                vg_dsLineaVenta.DTLineaVenta.AcceptChanges();
                            } else {
                                MostrarMensaje(strMensaje, MessageBoxIcon.Exclamation);
                            }
                        } else {
                            if (!ValidarCamposLineaVentaGridView(ref strMensaje, e.RowIndex, e.ColumnIndex)) {
                                MostrarMensaje(strMensaje, MessageBoxIcon.Exclamation);
                            }
                        }
                        dgrvLineaVentaDS.RefreshEdit();
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void btnAceptarLineaVenta_Click(object sender, EventArgs e) {
                try {
                    int intResultado = 0;
                    string strMensaje = string.Empty;
                    // Falta la Validacion de las lineas de venta
                    BEVenta oBEVenta = ObtenerVenta_LineaVenta();

                    
                    
                    //** INICIO **//
                    oBEVenta.Precio = this.nudPrecioVenta.Value;
                    
                    int intCantRows = dgrvLineaVentaDS.Rows.Count - 1;
                    int intCantFilas = vg_dsLineaVenta.DTLineaVenta.Rows.Count;
                    if (intCantFilas < intCantRows) {
                        object objPesoJava = dgrvLineaVentaDS[ePosicionLineaDS.PesoJava.GetHashCode(), intCantRows-1].Value;
                        object objPesoTara = dgrvLineaVentaDS[ePosicionLineaDS.PesoTara.GetHashCode(), intCantRows - 1].Value;
                        object objPesoBruto = dgrvLineaVentaDS[ePosicionLineaDS.PesoBruto.GetHashCode(), intCantRows - 1].Value;
                        object objPesoNeto = dgrvLineaVentaDS[ePosicionLineaDS.PesoNeto.GetHashCode(), intCantRows - 1].Value;
                        object objCantidad = dgrvLineaVentaDS[ePosicionLineaDS.CantidadJavas.GetHashCode(), intCantRows - 1].Value;
                        string strEsDevolucion = "N";
                        object objFlagPesoTara = dgrvLineaVentaDS[ePosicionLineaDS.FlagPesoTara.GetHashCode(), intCantRows - 1].Value;
                        object objFlagTara = dgrvLineaVentaDS[ePosicionLineaDS.FlagJava.GetHashCode(), intCantRows - 1].Value;
                        object objTaraEditada = dgrvLineaVentaDS[ePosicionLineaDS.TaraEditada.GetHashCode(), intCantRows - 1].Value;
                        object objObservacion = dgrvLineaVentaDS[ePosicionLineaDS.Observacion.GetHashCode(), intCantRows - 1].Value;
                        object objUnidades = dgrvLineaVentaDS[ePosicionLineaDS.Unidades.GetHashCode(), intCantRows - 1].Value;
                        string strIdEstado = BEVenta.REGISTRADO;
                        vg_dsLineaVenta.DTLineaVenta.AddDTLineaVentaRow(0, objCantidad.ToString()
                                                                        , objFlagTara.ToString()
                                                                        , objTaraEditada.ToString()
                                                                        , objPesoJava.ToString()
                                                                        , objPesoBruto.ToString()
                                                                        , objPesoTara.ToString()
                                                                        , objPesoNeto.ToString()
                                                                        , objFlagPesoTara.ToString()
                                                                        , objObservacion.ToString()
                                                                        , vg_intIdVenta
                                                                        , eAccion.Agregar.GetHashCode()
                                                                        , strIdEstado
                                                                        , strEsDevolucion
                                                                        ,int.Parse(objUnidades.ToString())
                                                                        
                                                                        );
                        vg_dsLineaVenta.DTLineaVenta.AcceptChanges();
                    }
                    //** FIN **//
                    intResultado = new BLLineaVenta().RegistrarLineaVentaMantenimientoDependiente(oBEVenta, vg_dsLineaVenta.DTLineaVenta, vg_dsLineaVentaEliminados.DTLineaVenta , (this.PrecioInicial != this.nudPrecioVenta.Value) );
                    if (intResultado == 3) {
                        InicializarVenta();
                        InicializarLineaVenta();
                        MostrarMensaje("Se registró la(s) línea de venta(s) correctamente", MessageBoxIcon.Information);
                    } else {
                        MostrarMensaje("No se pudo registrar la(s) línea de venta(s), intentelo de nuevo", MessageBoxIcon.Exclamation);
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }



            private void btnAplicarMonto_Click(object sender, EventArgs e) {
                try {

                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void dgrvAmortizacion_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
                string strMensaje = string.Empty;
                if (!ValidarCamposAmortizacion(ref strMensaje, e.RowIndex, e.ColumnIndex)) {
                    MostrarMensaje(strMensaje, MessageBoxIcon.Exclamation);
                }
            }

            private void btnAceptarAmortizacionVenta_Click(object sender, EventArgs e) {
                string strMensaje = string.Empty;
                try {
                    if (ValidarFormularioAmortizacion(ref strMensaje)) {
                        // Obtener las Amortizaciones
                        List<BEAmortizacionVenta> vLista = ObtenerAmortizaciones();
                        bool  bOk ;

                        BEDocumento documento = new BEDocumento();
                        documento.BEUsuarioLogin = VariablesSession.BEUsuarioSession;

                        documento.Fecha = VariablesSession.BECaja.Fecha; 
                        documento.IdTipoDocumento = BEDocumento.TIPO_AMORTIZACION_AMR;
                        documento.delleAmortizacion = vLista;
                        documento.Cliente.IdCliente = vg_BEVenta.IdCliente;
                        documento.Personal.IdPersonal = VariablesSession.BEUsuarioSession.IdPersonal;

                        bOk = new BLAmortizacionVenta().Insertar(documento);


                        if (bOk)
                        {
                            MostrarMensaje("Se registró la amortización correctamente", MessageBoxIcon.Information);
                            InicializarAmortizacionVenta();
                        } else {
                            MostrarMensaje("No se pudo registrar la venta, intentelo de nuevo", MessageBoxIcon.Exclamation);                        
                        }
                    } else {
                        MostrarMensaje(strMensaje, MessageBoxIcon.Warning);
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }



            private void dgrvDevolucion_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
                // Validar que sea solo para algunas celdas
                if (e.ColumnIndex != ePosicionDevolucion.BotonEliminar.GetHashCode()) {
                    Point oPoint = dgrvDevolucion.CurrentCellAddress;
                    if (oPoint.X == e.ColumnIndex && oPoint.Y == e.RowIndex && e.Button == MouseButtons.Left && dgrvDevolucion.EditMode != DataGridViewEditMode.EditProgrammatically) {
                        if (!dgrvDevolucion.IsCurrentCellInEditMode) {
                            dgrvDevolucion.BeginEdit(true);
                        }
                    }
                }
            }

            private void dgrvDevolucion_CellContentClick(object sender, DataGridViewCellEventArgs e) {
                if (e.ColumnIndex == ePosicionDevolucion.BotonEliminar.GetHashCode() && e.RowIndex >= 0 && !string.IsNullOrEmpty(dgrvDevolucion[ePosicionDevolucion.BotonEliminar.GetHashCode(), e.RowIndex].FormattedValue.ToString())) {
                    if (vg_dsDevolucionVenta.DTLineaVenta.Rows.Count > 0) {
                        if (vg_dsDevolucionVenta.DTLineaVenta[e.RowIndex].EsLineaVentaBD()) {
                            // Agregar la fila eliminada
                            object[] obj = vg_dsDevolucionVenta.DTLineaVenta[e.RowIndex].ItemArray;
                            dsLineaVenta.DTLineaVentaRow oDevolucionVenta = vg_dsDevolucionVentaEliminados.DTLineaVenta.NewDTLineaVentaRow();
                            oDevolucionVenta.ItemArray = obj;
                            vg_dsDevolucionVentaEliminados.DTLineaVenta.AddDTLineaVentaRow(oDevolucionVenta);
                            vg_dsDevolucionVentaEliminados.DTLineaVenta.AcceptChanges();
                        }
                        // Eliminar la fila de la tabla
                        vg_dsDevolucionVenta.DTLineaVenta.RemoveDTLineaVentaRow(vg_dsDevolucionVenta.DTLineaVenta[e.RowIndex]);
                        //ActualizarLineaVenta();
                        dgrvDevolucion.Refresh();
                        //Calculas Suma de montos
                        CalcularSumaMontosDevolucion(true, true, true);
                    }
                }
            }

            private void dgrvDevolucion_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
                try
                {
                    switch ((ePosicionDevolucion)e.ColumnIndex)
                    {
                        case ePosicionDevolucion.CantidadJavas:
                            // Validar si existe valor
                            object oCantidad = dgrvDevolucion[ePosicionDevolucion.CantidadJavas.GetHashCode(), e.RowIndex].Value;
                            if (oCantidad == null || string.IsNullOrEmpty(oCantidad.ToString()))
                            {
                                vg_strCantidad = string.Empty;
                            }
                            else
                            {
                                vg_strCantidad = oCantidad.ToString();
                            }
                            break;
                        case ePosicionDevolucion.PesoJava:
                            // Validar si existe valor
                            object oPesoJava1 = dgrvDevolucion[ePosicionDevolucion.PesoJava.GetHashCode(), e.RowIndex].Value;
                            if (oPesoJava1 == null || string.IsNullOrEmpty(oPesoJava1.ToString()))
                            {
                                vg_strPesoJava = string.Empty;
                            }
                            else
                            {
                                vg_strPesoJava = oPesoJava1.ToString();
                            }
                            break;
                        case ePosicionDevolucion.PesoBruto:
                            // Validar si existe valor
                            object oPesoBruto = dgrvDevolucion[ePosicionDevolucion.PesoBruto.GetHashCode(), e.RowIndex].Value;
                            if (oPesoBruto == null || string.IsNullOrEmpty(oPesoBruto.ToString()))
                            {
                                vg_strPesoBruto = string.Empty;
                            }
                            else
                            {
                                vg_strPesoBruto = oPesoBruto.ToString();
                            }
                            break;
                        case ePosicionDevolucion.PesoTara:
                            // Validar si existe valor
                            object oPesoTara = dgrvDevolucion[ePosicionDevolucion.PesoTara.GetHashCode(), e.RowIndex].Value;
                            if (oPesoTara == null || string.IsNullOrEmpty(oPesoTara.ToString()))
                            {
                                vg_strPesoTara = string.Empty;
                            }
                            else
                            {
                                // Calcular Peso tara
                                object oCantJavas = dgrvDevolucion[ePosicionDevolucion.CantidadJavas.GetHashCode(), e.RowIndex].Value;
                                object oPesoJava = dgrvDevolucion[ePosicionDevolucion.PesoJava.GetHashCode(), e.RowIndex].Value;
                                if (!string.IsNullOrEmpty(oCantJavas.ToString()) && !string.IsNullOrEmpty(oPesoJava.ToString()))
                                {
                                    vg_strPesoTara = (int.Parse(oCantJavas.ToString()) * decimal.Parse(oPesoJava.ToString())).ToString();
                                }
                                else
                                {
                                    vg_strPesoTara = oPesoTara.ToString();
                                }
                            }
                            break;
                    }

                }
                catch (Exception ex)
                {

                    MostrarMensaje(ex.Message, MessageBoxIcon.Error); ;
                }
                
            }

            private void dgrvDevolucion_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
                try {
                    string strMensaje = string.Empty;
                    if (!dgrvDevolucion.Rows[e.RowIndex].IsNewRow) {
                        // Validar si es una fila que esta en el DS
                        int intLastIndex = vg_dsDevolucionVenta.DTLineaVenta.Rows.Count - 1;
                        if (e.RowIndex <= intLastIndex) {
                            if (ValidarCamposDevolucionVentaDS(ref strMensaje, e.RowIndex, e.ColumnIndex)) {
                                vg_dsDevolucionVenta.DTLineaVenta.AcceptChanges();
                            } else {
                                MostrarMensaje(strMensaje, MessageBoxIcon.Exclamation);
                            }
                        } else {
                            if (!ValidarCamposDevolucionVentaGridView(ref strMensaje, e.RowIndex, e.ColumnIndex)) {
                                MostrarMensaje(strMensaje, MessageBoxIcon.Exclamation);
                            }
                        }
                        dgrvDevolucion.RefreshEdit();
                        // Calcular suma de montos
                        CalcularSumaMontosDevolucion(true, true, true);
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void btnAceptarDevolucionVenta_Click(object sender, EventArgs e) {
                try {
                    int intResultado = 0;
                    string strMensaje = string.Empty;
                    // Validacion de las lineas de venta
                    if (ValidarDevolucionVenta(ref strMensaje)) {
                        BEVenta oBEVenta = ObtenerVenta_DevolucionVenta();
                        //** INICIO **//
                        int intCantRows = dgrvDevolucion.Rows.Count - 1;
                        int intCantFilas = vg_dsDevolucionVenta.DTLineaVenta.Rows.Count;
                        if (intCantFilas < intCantRows) {
                            object objPesoJava = dgrvDevolucion[ePosicionDevolucion.PesoJava.GetHashCode(), intCantRows-1].Value;
                            object objPesoTara = dgrvDevolucion[ePosicionDevolucion.PesoTara.GetHashCode(), intCantRows - 1].Value;
                            object objPesoBruto = dgrvDevolucion[ePosicionDevolucion.PesoBruto.GetHashCode(), intCantRows - 1].Value;
                            object objPesoNeto = dgrvDevolucion[ePosicionDevolucion.PesoNeto.GetHashCode(), intCantRows - 1].Value;
                            object objCantidad = dgrvDevolucion[ePosicionDevolucion.CantidadJavas.GetHashCode(), intCantRows - 1].Value;
                            string strEsDevolucion = "S";
                            object objFlagPesoTara = dgrvDevolucion[ePosicionDevolucion.FlagPesoTara.GetHashCode(), intCantRows - 1].Value;
                            object objFlagTara = dgrvDevolucion[ePosicionDevolucion.FlagJava.GetHashCode(), intCantRows - 1].Value;
                            object objTaraEditada = dgrvDevolucion[ePosicionDevolucion.PesoJavaDefecto.GetHashCode(), intCantRows - 1].Value;
                            object objObservacion = dgrvDevolucion[ePosicionDevolucion.Observaciones.GetHashCode(), intCantRows - 1].Value;
                            string strIdEstado = BEVenta.REGISTRADO;
                            object objUnidades = dgrvDevolucion[ePosicionDevolucion.Unidades.GetHashCode(), intCantRows - 1].Value;
                            
                            vg_dsDevolucionVenta.DTLineaVenta.AddDTLineaVentaRow(0, objCantidad.ToString()
                                                                            , objFlagTara.ToString()
                                                                            , objTaraEditada.ToString()
                                                                            , objPesoJava.ToString()
                                                                            , objPesoBruto.ToString()
                                                                            , objPesoTara.ToString()
                                                                            , objPesoNeto.ToString()
                                                                            , objFlagPesoTara == null ? "N" : objFlagPesoTara.ToString()
                                                                            , objObservacion == null ? "": objObservacion.ToString()
                                                                            , vg_intIdVenta
                                                                            , eAccion.Agregar.GetHashCode()
                                                                            , strIdEstado
                                                                            , strEsDevolucion
                                                                            , int.Parse(objUnidades.ToString())
                                                                            
                                                                            );
                            vg_dsDevolucionVenta.DTLineaVenta.AcceptChanges();
                        }
                        //** FIN **//
                        intResultado = new BLLineaVenta().RegistrarLineaVentaMantenimientoDependiente(oBEVenta, vg_dsDevolucionVenta.DTLineaVenta, vg_dsDevolucionVentaEliminados.DTLineaVenta, (this.PrecioInicial != this.nudPrecioVenta.Value));
                        if (intResultado == 3) {
                            InicializarVenta();
                            tcVenta.SelectedIndex = eTabDetalleVenta.TabDevolucionVenta.GetHashCode();
                            MostrarMensaje("Se registró la(s) devoluciones de venta(s) correctamente", MessageBoxIcon.Information);
                        } else {
                            MostrarMensaje("No se pudo registrar la(s) devoluciones de venta(s), inténtelo de nuevo", MessageBoxIcon.Exclamation);
                        }                     
                    } else {
                        MostrarMensaje(strMensaje, MessageBoxIcon.Exclamation);
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }


            private void cbEstadoVentaG_SelectedIndexChanged(object sender, EventArgs e) {
                string strIdEstado = string.Empty;
                strIdEstado = cbEstadoVentaG.SelectedValue.ToString();
                //CAG 20100807
                //DGP_Util.EnableControl(txtObservaciones, (cbEstadoVentaG.SelectedIndex > 0 && strIdEstado != vg_BEVenta.IdEstado));
                //DGP_Util.EnableControl(btnCancelarVenta, (cbEstadoVentaG.SelectedIndex > 0 && strIdEstado != vg_BEVenta.IdEstado));
            }

            private void btnCancelarVenta_Click(object sender, EventArgs e) {

                try {
                    string strMensaje = string.Empty;
                    if (ValidarEstadoVenta(ref strMensaje)) {
                        int intResultado = 0;
                        intResultado = new BLVenta().ActualizarEstado(vg_intIdVenta, cbEstadoVentaG.SelectedValue.ToString(), txtObservaciones.Text);
                        if (intResultado == 1) {
                            MostrarMensaje("La venta se canceló correctamente", MessageBoxIcon.Exclamation);
                            //DGP_Util.EnableControl(tabPage1, false);
                            //DGP_Util.EnableControl(tabPage2, false);
                            //DGP_Util.EnableControl(tabPage3, false);
                            //DGP_Util.EnableControl(cbEstadoVentaG, false);
                            //DGP_Util.EnableControl(txtObservaciones, false);
                            //DGP_Util.EnableControl(btnCancelarVenta, false);
                        } else {
                            MostrarMensaje("No se pudo cancelar la venta, intentelo de nuevo", MessageBoxIcon.Exclamation);
                        }
                    } else {
                        MostrarMensaje(strMensaje, MessageBoxIcon.Exclamation);
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }


        #endregion

        #region "Métodos de frmDetalleVenta.aspx"

            private void MostrarMensaje(string pMensaje, MessageBoxIcon pMsgBoxicon) {
                MessageBox.Show(pMensaje, "DGP", MessageBoxButtons.OK, pMsgBoxicon);
            }

            private void InicializarVenta() { 
                try {
                    CargarEstadoVenta();
                    EstablecerVentaBD();
                    tcVenta.SelectedIndex = eTabDetalleVenta.TabLineaVenta.GetHashCode();
                    //CAG 20100807
                    //if (vg_BEVenta.IdEstado == BEVenta.CANCELADO)
                    //{
                    //    DGP_Util.EnableControl(tabPage1, false);
                    //    DGP_Util.EnableControl(tabPage2, false);
                    //    DGP_Util.EnableControl(tabPage3, false);
                    //    DGP_Util.EnableControl(cbEstadoVentaG, false);
                    //    DGP_Util.EnableControl(txtObservaciones, false);
                    //    DGP_Util.EnableControl(btnCancelarVenta, false);
                    //} else if (vg_BEVenta.EsSobrante == eVentaEsSobrante.Si) {
                    //    DGP_Util.EnableControl(tabPage2, false);
                    //    DGP_Util.EnableControl(tabPage3, false);
                    //    DGP_Util.EnableControl(cbEstadoVentaG, false);
                    //    DGP_Util.EnableControl(txtObservaciones, false);
                    //    DGP_Util.EnableControl(btnCancelarVenta, false);                        
                    //}
	            } catch (Exception ex) {
		            MostrarMensaje(ex.Message, MessageBoxIcon.Error);
	            }
            }

            private void CargarEstadoVenta() {
                BEParametroDetalle oBEParametroDetalle = new BEParametroDetalle();
                oBEParametroDetalle.IdParametro = eParametro.Estado_Venta.GetHashCode();
                List<BEParametroDetalle> vLista = new BLParametroDetalle().Listar(oBEParametroDetalle);
                vLista.Insert(0, new BEParametroDetalle("0", "Todos"));
                cbEstadoVentaG.DataSource = vLista;
                cbEstadoVentaG.DisplayMember = "Texto";
                cbEstadoVentaG.ValueMember = "Valor";

            }

            private void EstablecerVentaBD() {
                List<BEVenta> vLista = new BLVenta().ListarVenta(vg_intIdVenta, 0);
                if (vLista != null && vLista.Count <= 0) {
                    throw new Exception("No es posible mostrar la Linea de Venta, intentelo más tarde");
                }
                vg_BEVenta = vLista[0];
                vg_BEVenta.ListaLineaVenta = null;
                vg_BEVenta.BEUsuarioLogin = VariablesSession.BEUsuarioSession;
                vg_decPrecioVenta = vg_BEVenta.Precio;
                //
                lblIDVenta.Text = vg_BEVenta.IdVenta.ToString();
                lblClienteVenta.Text = vg_BEVenta.Cliente;
                lblProductoVenta.Text = vg_BEVenta.Producto;
                nudPrecioVenta.Value = vg_BEVenta.Precio;
                PrecioInicial = vg_BEVenta.Precio;
                lblDevoluciones.Text = vg_BEVenta.TotalDevolucion.ToString();
                lblEmpresaVenta.Text = vg_BEVenta.Empresa;
                lblUnidades.Text = vg_BEVenta.TotalUnidades.ToString();
                //
                lblCabTotalBruto.Text = vg_BEVenta.TotalPesoBruto.ToString();
                lblCabTotalTara.Text = vg_BEVenta.TotalPesoTara.ToString();
                lblCabTotalNeto.Text = vg_BEVenta.TotalPesoNeto.ToString();
                lblImporte.Text = vg_BEVenta.MontoTotal.ToString();
                //
                
                
                
                
                
                cbEstadoVentaG.SelectedValue = vg_BEVenta.IdEstado;
                txtObservaciones.Text = vg_BEVenta.Observacion;
                vg_intIdProducto = vg_BEVenta.IdProducto;
                vg_intIdCliente = vg_BEVenta.IdCliente;
                vg_decTara = new BLProductoCliente().ObtenerTara(new BEProductoCliente(vg_BEVenta.IdProducto, vg_BEVenta.IdCliente));
            }


            private void InicializarLineaVenta() { 
                try {
                    HabilitarLineaVenta(false);
                    CargarLineaVenta();
                    ActualizarLineaVenta();
                    HabilitarLineaVenta(true);
	            } catch (Exception ex) {
		            MostrarMensaje(ex.Message, MessageBoxIcon.Error);
	            }
            }

            private void HabilitarLineaVenta(bool pEnable) {
                DGP_Util.EnableControl(dgrvLineaVentaDS, pEnable);
            }

            private void CargarLineaVenta() {
                BELineaVenta oBELineaVenta = new BELineaVenta();
                oBELineaVenta.IdVenta = vg_intIdVenta;
                oBELineaVenta.EsDevolucion = "N";
                oBELineaVenta.IdEstado = BEVenta.REGISTRADO;
                //
                vg_dsLineaVenta = new BLLineaVenta().ListarDS(oBELineaVenta);
                vg_dsLineaVentaEliminados = new dsLineaVenta();
                // Valores por defecto
                vg_dsLineaVenta.DTLineaVenta.TaraEditadaColumn.DefaultValue = (object)vg_decTara;
                vg_dsLineaVenta.DTLineaVenta.PesoJavaColumn.DefaultValue = (object)vg_decTara;
                vg_dsLineaVenta.DTLineaVenta.IdEstadoColumn.DefaultValue = (object)BEVenta.REGISTRADO;
                vg_dsLineaVenta.DTLineaVenta.EsDevolucionColumn.DefaultValue = (object)"N";
                vg_dsLineaVenta.DTLineaVenta.IdVentaColumn.DefaultValue = (object)vg_intIdVenta;
            }

            private void ActualizarLineaVenta() {
                dgrvLineaVentaDS.AutoGenerateColumns = false;
                dgrvLineaVentaDS.DataSource = vg_dsLineaVenta.DTLineaVenta;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            private BEVenta ObtenerVenta_LineaVenta() {
                //vg_BEVenta.ListaLineaVenta = null;
                //vg_BEVenta.ListaLineaVenta = vg_ListaLineaVenta;
                //vg_BEVenta.ListaLineaVenta.ForEach(delegate(BELineaVenta oEntidad) { 
                //    //Flag Tara Editada
                //    if (oEntidad.FlagJava.Equals("N")) {
                //        oEntidad.TaraEditada = decimal.MinValue;
                //    }
                //    oEntidad.BEUsuarioLogin = VariablesSession.BEUsuarioSession;
                //});
                //foreach (DataGridViewRow vRow in dgrvLineaVentaDS.Rows) {
                //    vRow.Selected = true;
                //}
                vg_BEVenta.BEUsuarioLogin = VariablesSession.BEUsuarioSession;
                return vg_BEVenta;
            }


            private void InicializarAmortizacionVenta() {
                try {
                    HabilitarAmortizacionVenta(false);
                    ActualizarAmortizacionVenta();
                    CargarAmortizacionVenta();
                    HabilitarAmortizacionVenta(true);
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void HabilitarAmortizacionVenta(bool pEnable) {
                DGP_Util.EnableControl(dgrvAmortizacion, pEnable);
            }

            private void ActualizarAmortizacionVenta() {
                VistaAmortizacion oEntidad = new VistaAmortizacion();
                oEntidad.IdVenta = vg_intIdVenta;
                oEntidad.IdCliente = vg_BEVenta.IdCliente;
                oEntidad.IdProducto = vg_BEVenta.IdProducto;
                vg_ListaAmortizacionVenta = new BLAmortizacionVenta().Listar(oEntidad);
            }

            private void CargarAmortizacionVenta() {
                dgrvAmortizacion.AutoGenerateColumns = false;
                dgrvAmortizacion.DataSource = vg_ListaAmortizacionVenta;
                //
                // Habilitar solamente las Ventas
                oCeldaPagoCuenta = new DataGridViewCellStyle();
                oCeldaPagoCuenta.SelectionBackColor = Color.Silver;
                oCeldaPagoCuenta.BackColor = Color.Silver;
                foreach (DataGridViewRow vRow in dgrvAmortizacion.Rows) {
                    // Obtener Indicador
                    object oIndicador = vRow.Cells[ePosicionAmortizacionVenta.Indicador.GetHashCode()].Value;
                    if (oIndicador.ToString() == "0") {
                        vRow.Cells[ePosicionAmortizacionVenta.Cantidad.GetHashCode()].Value = "";
                        vRow.Cells[ePosicionAmortizacionVenta.PesoNeto.GetHashCode()].Value = "";
                        vRow.Cells[ePosicionAmortizacionVenta.Saldo.GetHashCode()].Value = "";
                        vRow.Cells[ePosicionAmortizacionVenta.Pago.GetHashCode()].Value = "";
                        vRow.Cells[ePosicionAmortizacionVenta.Pago.GetHashCode()].ReadOnly = true;
                        vRow.Cells[ePosicionAmortizacionVenta.Pago.GetHashCode()].Style = oCeldaPagoCuenta;
                    }
                    // Para los Cancelados
                    object oSaldo = vRow.Cells[ePosicionAmortizacionVenta.Saldo.GetHashCode()].Value;
                    decimal decSaldo = decimal.Zero;
                    if (oSaldo != null && !string.IsNullOrEmpty(oSaldo.ToString())) {
                        decSaldo = Convert.ToDecimal(oSaldo);
                        if (decSaldo <= 0) {
                            vRow.Cells[ePosicionAmortizacionVenta.Pago.GetHashCode()].Value = "";
                            vRow.Cells[ePosicionAmortizacionVenta.Pago.GetHashCode()].ReadOnly = true;
                            vRow.Cells[ePosicionAmortizacionVenta.Pago.GetHashCode()].Style = oCeldaPagoCuenta;
                        }
                    }
                }
            }

            private bool ValidarFormularioAmortizacion(ref string pMensaje) {
                bool boValor = true;
                return boValor;
            }

            private List<BEAmortizacionVenta> ObtenerAmortizaciones() {
                List<BEAmortizacionVenta> vLista = new List<BEAmortizacionVenta>();
                BEAmortizacionVenta oBEAmortizacionVenta = null;
                foreach (DataGridViewRow vRow in dgrvAmortizacion.Rows) {
                    // Obtener el indicador
                    object oIndicador = vRow.Cells[ePosicionAmortizacionVenta.Indicador.GetHashCode()].Value;
                    if (oIndicador.ToString() == "1") {
                        // Obtener el Pago a Cuenta
                        decimal decPagoCuenta = decimal.Zero;
                        object oPagoCuenta = vRow.Cells[ePosicionAmortizacionVenta.Pago.GetHashCode()].Value;
                        if (oPagoCuenta != null && !string.IsNullOrEmpty(oPagoCuenta.ToString())) {
                            decPagoCuenta = Convert.ToDecimal(oPagoCuenta);
                            // Obtener los demas Valores de la fila
                            int intIdVenta = 0;
                            int intIdProducto = 0;
                            intIdVenta = Convert.ToInt32(vRow.Cells[ePosicionAmortizacionVenta.IdVenta.GetHashCode()].Value);
                            intIdProducto = Convert.ToInt32(vRow.Cells[ePosicionAmortizacionVenta.IdProducto.GetHashCode()].Value);
                            oBEAmortizacionVenta = new BEAmortizacionVenta();
                            oBEAmortizacionVenta.Monto = decPagoCuenta;
                            oBEAmortizacionVenta.FechaPago = VariablesSession.BECaja.Fecha;
                            oBEAmortizacionVenta.IdPersonal = VariablesSession.BEUsuarioSession.IdPersonal;
                            oBEAmortizacionVenta.NroDocumento = string.Empty;
                            oBEAmortizacionVenta.IdFormaPago = BEAmortizacionVenta.FORMAPAGO_EFECTIVO;
                            oBEAmortizacionVenta.IdTipoAmortizacion = BEAmortizacionVenta.TIPOAMORTIZACION_AMORTIZACION;
                            oBEAmortizacionVenta.Observacion = string.Empty;
                            oBEAmortizacionVenta.IdEstado = BEAmortizacionVenta.ESTADO_REGISTRADO;
                            oBEAmortizacionVenta.IdVenta = intIdVenta;
                            oBEAmortizacionVenta.IdCliente = vg_BEVenta.IdCliente;
                            oBEAmortizacionVenta.BEUsuarioLogin = VariablesSession.BEUsuarioSession;
                            vLista.Add(oBEAmortizacionVenta);
                        }
                    }
                }
                return vLista;
            }


            private void InicializarDevolucionVenta() {
                try {
                    //HabilitarDevolucionVenta(false);
                    DGP_Util.LiberarGridView(dgrvDevolucion);
                    BEVenta oBEVenta = new BLVenta().ObtenerVenta(vg_intIdVenta);
                    if (oBEVenta != null) {
                        BEProductoCliente oBEProductoCliente = new BEProductoCliente();
                        oBEProductoCliente.IdCliente = oBEVenta.IdCliente;
                        oBEProductoCliente.IdProducto = oBEVenta.IdProducto;
                        vg_decTara = new BLProductoCliente().ObtenerTara(oBEProductoCliente);
                        // Establecer datos al grid
                        CargarDevolucionVenta();
                        ActualizarDevolucionVenta();
                        // Calcular los montos
                        CalcularSumaMontosDevolucion(true, true, true);
                        HabilitarDevolucionVenta(true);
                    }
                } catch (Exception ex) {
                    MostrarMensaje(ex.Message, MessageBoxIcon.Error);
                }
            }

            private void HabilitarDevolucionVenta(bool pEnable) {
                DGP_Util.EnableControl(dgrvDevolucion, pEnable);
            }

            private void CargarDevolucionVenta() {
                BELineaVenta oBELineaVenta = new BELineaVenta();
                oBELineaVenta.IdVenta = vg_intIdVenta;
                oBELineaVenta.EsDevolucion = "S";
                oBELineaVenta.IdEstado = BEVenta.REGISTRADO;
                //
                vg_dsDevolucionVenta = new BLLineaVenta().ListarDS(oBELineaVenta);
                vg_dsDevolucionVentaEliminados = new dsLineaVenta();
                // Valores por defecto
                vg_dsDevolucionVenta.DTLineaVenta.TaraEditadaColumn.DefaultValue = (object)vg_decTara;
                vg_dsDevolucionVenta.DTLineaVenta.PesoJavaColumn.DefaultValue = (object)vg_decTara;
                vg_dsDevolucionVenta.DTLineaVenta.IdEstadoColumn.DefaultValue = (object)BEVenta.REGISTRADO;
                vg_dsDevolucionVenta.DTLineaVenta.EsDevolucionColumn.DefaultValue = (object)"S";
                vg_dsDevolucionVenta.DTLineaVenta.IdVentaColumn.DefaultValue = (object)vg_intIdVenta;
            }

            private void ActualizarDevolucionVenta() {
                dgrvDevolucion.AutoGenerateColumns = false;
                dgrvDevolucion.DataSource = vg_dsDevolucionVenta.DTLineaVenta;
            }

            private bool ValidarDevolucionVenta(ref string pMensaje) {
                bool boValor = true;
                decimal decPesoNetoCab = decimal.Zero;
                decimal decPesoNetoDet = decimal.Zero;
                decimal.TryParse(lblCabTotalNeto.Text, out decPesoNetoCab);
                decimal.TryParse(lblTotalNetoD.Text, out decPesoNetoDet);
                if (decPesoNetoDet > decPesoNetoCab) {
                    pMensaje = "La devolución debe ser menor o igual al peso neto de la venta";
                    boValor = false;
                }
                return boValor;
            }

            private BEVenta ObtenerVenta_DevolucionVenta() {
                //BEVenta oBEVenta = new BEVenta();
                //oBEVenta.IdVenta = vg_intIdVenta;
                //oBEVenta.IdProducto = vg_intIdProducto;
                //oBEVenta.IdCliente = vg_intIdCliente;
                //oBEVenta.BEUsuarioLogin = VariablesSession.BEUsuarioSession;
                //oBEVenta.ListaAmortizacion = ObtenerDevoluciones();
                //return oBEVenta;
                vg_BEVenta.BEUsuarioLogin = VariablesSession.BEUsuarioSession;
                return vg_BEVenta;
            }

            private void CalcularSumaMontosDevolucion(bool pCalculoPesoBruto, bool pCalculoPesoTara, bool pCalculoPesoNeto) {
                decimal decPesoBruto = decimal.Zero;
                decimal decPesoTara = decimal.Zero;
                decimal decPesoNeto = decimal.Zero;
                decimal decMonto = decimal.Zero;
                int intRowIndex = 0;
                foreach (DataGridViewRow oRow in dgrvDevolucion.Rows) {
                    if (intRowIndex < dgrvDevolucion.Rows.Count - 1) {
                        foreach (DataGridViewCell oCell in oRow.Cells) {
                            if (pCalculoPesoBruto && oCell.ColumnIndex == ePosicionDevolucion.PesoBruto.GetHashCode()) { // Peso Bruto
                                decPesoBruto += (oCell.Value == null || string.IsNullOrEmpty(oCell.Value.ToString())) ? decimal.Zero : decimal.Parse(oCell.Value.ToString());
                            }
                            if (pCalculoPesoTara && oCell.ColumnIndex == ePosicionDevolucion.PesoTara.GetHashCode()) { // Peso Tara
                                decPesoTara += (oCell.Value == null || string.IsNullOrEmpty(oCell.Value.ToString())) ? decimal.Zero : decimal.Parse(oCell.Value.ToString());
                            }
                            if (pCalculoPesoNeto && oCell.ColumnIndex == ePosicionDevolucion.PesoNeto.GetHashCode()) { // Peso Neto
                                decPesoNeto += (oCell.Value == null || string.IsNullOrEmpty(oCell.Value.ToString())) ? decimal.Zero : decimal.Parse(oCell.Value.ToString());
                            }
                        }
                    }
                    intRowIndex++;
                }
                // Calcular el Monto
                decMonto = decPesoNeto * vg_BEVenta.Precio;
                // Mostrar el calculo
                lblTotalBrutoD.Text = decPesoBruto.ToString();
                lblTotalTaraD.Text = decPesoTara.ToString();
                lblTotalNetoD.Text = decPesoNeto.ToString();
            }


            private bool ValidarEstadoVenta(ref string pMensaje) {
                bool boResultado = true;

                if (cbEstadoVentaG.SelectedIndex > 0 && string.IsNullOrEmpty(txtObservaciones.Text)) {
                    boResultado = false;
                    pMensaje = "Ingresar observación";
                }

                return boResultado;
            }

        #endregion

        #region "Métodos de Validacìón de frmDetalleVenta.aspx"

            private bool ValidarCamposLineaVentaDS(ref string pMensaje, int pRowIndex, int pColumnIndex) {
                bool boResultado = true;
                try {
                    switch ((ePosicionLineaDS)pColumnIndex) {
                        case ePosicionLineaDS.CantidadJavas: // Para las Cantidades de Java
                            // Validar Campo vacio y valor
                            if (vg_dsLineaVenta.DTLineaVenta[pRowIndex].ValidarCantidadJavas(ref pMensaje, vg_strCantidad)) {
                                // Calcular Cantidades de Javas
                                vg_dsLineaVenta.DTLineaVenta[pRowIndex].CalcularCantidadJavas();
                                vg_dsLineaVenta.DTLineaVenta[pRowIndex].CalcularCantidadUnidades();
                                // Reestablecer Style de la Columna de Observacion
                                oCellStyleObservaciones = new DataGridViewCellStyle();
                                oCellStyleObservaciones.SelectionBackColor = Color.Gainsboro;
                                oCellStyleObservaciones.BackColor = Color.White;
                                dgrvLineaVentaDS[ePosicionLineaDS.Observacion.GetHashCode(), pRowIndex].ReadOnly = true;
                                dgrvLineaVentaDS[ePosicionLineaDS.Observacion.GetHashCode(), pRowIndex].Style = oCellStyleObservaciones;
                            } else {
                                boResultado = false;
                                dgrvLineaVentaDS.CancelEdit();
                            }
                            break;
                        case ePosicionLineaDS.PesoJava: // Para el Peso Java
                            // Validar campo vacio y valor
                            if (vg_dsLineaVenta.DTLineaVenta[pRowIndex].ValidarPesoJava(ref pMensaje, vg_strPesoJava)) {
                                // Recalcular Peso Java
                                vg_dsLineaVenta.DTLineaVenta[pRowIndex].RecalcularPesoJava();
                                // Validar si es Editado
                                object oPesoJava = dgrvLineaVentaDS[pColumnIndex, pRowIndex].Value;
                                string strResultadoFlag = string.Empty;
                                string strPesoFinal = string.Empty;
                                if (vg_decTara.Equals(decimal.Parse(oPesoJava.ToString()))) {
                                    // Reestablecer el Flag y el PesoJavaDefecto (Tara Editada)
                                    strResultadoFlag = "N";
                                    strPesoFinal = vg_decTara.ToString();
                                } else if (decimal.Parse(vg_strPesoJava).Equals(decimal.Parse(oPesoJava.ToString()))) {
                                    strResultadoFlag = "N";
                                    strPesoFinal = vg_decTara.ToString();
                                    // Cambiar el Flag y el PesoJavaDefecto (Tara Editada)
                                } else {
                                    strResultadoFlag = "S";
                                    strPesoFinal = oPesoJava.ToString();
                                }
                                dgrvLineaVentaDS[ePosicionLineaDS.FlagJava.GetHashCode(), pRowIndex].Value = strResultadoFlag;
                                dgrvLineaVentaDS[ePosicionLineaDS.TaraEditada.GetHashCode(), pRowIndex].Value = decimal.Parse(strPesoFinal);
                            } else {
                                boResultado = false;
                                dgrvLineaVentaDS.CancelEdit();
                            }
                            break;
                        case ePosicionLineaDS.PesoBruto: // Para el Peso Bruto
                            // Validar campo vacio y valor
                            if (vg_dsLineaVenta.DTLineaVenta[pRowIndex].ValidarPesoBruto(ref pMensaje, vg_strPesoBruto)) {
                                // Calcular Peso Bruto
                                vg_dsLineaVenta.DTLineaVenta[pRowIndex].CalcularPesoBruto();
                            } else {
                                boResultado = false;
                                dgrvLineaVentaDS.CancelEdit();
                            }
                            break;
                        case ePosicionLineaDS.PesoTara: // Para el Peso Tara
                            // Validar campo vacio y valor
                            if (vg_dsLineaVenta.DTLineaVenta[pRowIndex].ValidarPesoTara(ref pMensaje, vg_strPesoTara)) {
                                bool boLectura = true;
                                oCellStyleObservaciones = new DataGridViewCellStyle();
                                // Validar si es Editado
                                object oPesoTara = dgrvLineaVentaDS[pColumnIndex, pRowIndex].Value;
                                if (vg_strPesoTara.Equals(oPesoTara.ToString())) {
                                    dgrvLineaVentaDS[ePosicionLineaDS.FlagPesoTara.GetHashCode(), pRowIndex].Value = "N";
                                    // Reestablecer Style de la Columna de Observacion
                                    oCellStyleObservaciones.SelectionBackColor = Color.White;
                                    oCellStyleObservaciones.BackColor = Color.White;
                                } else {
                                    dgrvLineaVentaDS[ePosicionLineaDS.FlagPesoTara.GetHashCode(), pRowIndex].Value = "S";
                                    // Recalcular Peso Tara
                                    vg_dsLineaVenta.DTLineaVenta[pRowIndex].RecalcularPesoTara();
                                    // Establecer Style de la Columna de Observacion
                                    oCellStyleObservaciones.SelectionBackColor = Color.LightSalmon;
                                    oCellStyleObservaciones.BackColor = Color.LightSalmon;
                                    boLectura = false;
                                }
                                dgrvLineaVentaDS[ePosicionLineaDS.Observacion.GetHashCode(), pRowIndex].ReadOnly = boLectura;
                                dgrvLineaVentaDS[ePosicionLineaDS.Observacion.GetHashCode(), pRowIndex].Style = oCellStyleObservaciones;
                            } else {
                                boResultado = false;
                                dgrvLineaVentaDS.CancelEdit();
                            }
                            break;
                        case ePosicionLineaDS.Unidades:
                            vg_dsLineaVenta.DTLineaVenta[pRowIndex].IdAccion = eAccion.Modificar.GetHashCode();
                            break;
                            //if (vg_dsLineaVenta.DTLineaVenta[pRowIndex].ValidarPesoTara(ref pMensaje, vg_strPesoTara)) {
                            
                    }
                } catch (Exception ex) {
                    pMensaje = ex.Message;
                    boResultado = false;
                }
                return boResultado;
            }

            private bool ValidarCamposLineaVentaGridView(ref string pMensaje, int pRowIndex, int pColumnIndex) {
                bool boResultado = true;
                try {
                    switch ((ePosicionLineaDS)pColumnIndex) {
                        case ePosicionLineaDS.CantidadJavas: // Para las Cantidades de Java
                            // Validar Campo vacio y valor
                            if (ValidarCantidadJavasLineaVenta(ref pMensaje, pRowIndex)) {
                                // Calcular Cantidades de Javas
                                CalcularCantidadJavasLineaVenta(pRowIndex);
                                // Reestablecer Style de la Columna de Observacion
                                oCellStyleObservaciones = new DataGridViewCellStyle();
                                oCellStyleObservaciones.SelectionBackColor = Color.Gainsboro;
                                oCellStyleObservaciones.BackColor = Color.White;
                                dgrvLineaVentaDS[ePosicionLineaDS.Observacion.GetHashCode(), pRowIndex].ReadOnly = true;
                                dgrvLineaVentaDS[ePosicionLineaDS.Observacion.GetHashCode(), pRowIndex].Style = oCellStyleObservaciones;
                            } else {
                                boResultado = false;
                                dgrvLineaVentaDS.CancelEdit();
                            }
                            break;
                        case ePosicionLineaDS.PesoJava: // Para el Peso Java
                            // Validar campo vacio y valor
                            if (ValidarPesoJavaLineaVenta(ref pMensaje, pRowIndex)) {
                                // Recalcular Peso Java
                                RecalcularPesoJavaLineaVenta(pRowIndex);
                                // Validar si es Editado
                                object oPesoJava = dgrvLineaVentaDS[pColumnIndex, pRowIndex].Value;
                                if (vg_decTara.Equals(decimal.Parse(oPesoJava.ToString()))) {
                                    // Reestablecer el Flag y el PesoJavaDefecto (Tara Editada)
                                    GridViewEstablecerValorLineaVenta("N", pRowIndex, ePosicionLineaDS.FlagJava.GetHashCode());
                                    GridViewEstablecerValorLineaVenta(vg_decTara, pRowIndex, ePosicionLineaDS.TaraEditada.GetHashCode());
                                } else {
                                    // Cambiar el Flag y el PesoJavaDefecto (Tara Editada)
                                    GridViewEstablecerValorLineaVenta("S", pRowIndex, ePosicionLineaDS.FlagJava.GetHashCode());
                                    GridViewEstablecerValorLineaVenta(decimal.Parse(oPesoJava.ToString()), pRowIndex, ePosicionLineaDS.TaraEditada.GetHashCode());
                                }
                            } else {
                                boResultado = false;
                                dgrvLineaVentaDS.CancelEdit();
                            }
                            break;
                        case ePosicionLineaDS.PesoBruto: // Para el Peso Bruto
                            // Validar campo vacio y valor
                            if (ValidarPesoBrutoLineaVenta(ref pMensaje, pRowIndex)) {
                                // Calcular Peso Bruto
                                CalcularPesoBrutoLineaVenta(pRowIndex);
                            } else {
                                boResultado = false;
                                dgrvLineaVentaDS.CancelEdit();
                            }
                            break;
                        case ePosicionLineaDS.PesoTara: // Para el Peso Tara
                            // Validar campo vacio y valor
                            if (ValidarPesoTaraLineaVenta(ref pMensaje, pRowIndex)) {
                                bool boLectura = true;
                                oCellStyleObservaciones = new DataGridViewCellStyle();
                                // Validar si es Editado
                                object oPesoTara = dgrvLineaVentaDS[pColumnIndex, pRowIndex].Value;
                                if (vg_strPesoTara.Equals(oPesoTara.ToString())) {
                                    GridViewEstablecerValorLineaVenta("N", pRowIndex, ePosicionLineaDS.FlagPesoTara.GetHashCode());
                                    // Reestablecer Style de la Columna de Observacion
                                    oCellStyleObservaciones.SelectionBackColor = Color.White;
                                    oCellStyleObservaciones.BackColor = Color.White;
                                } else {
                                    GridViewEstablecerValorLineaVenta("S", pRowIndex, ePosicionLineaDS.FlagPesoTara.GetHashCode());
                                    // Recalcular Peso Tara
                                    RecalcularPesoTaraLineaVenta(pRowIndex);
                                    // Establecer Style de la Columna de Observacion
                                    oCellStyleObservaciones.SelectionBackColor = Color.LightSalmon;
                                    oCellStyleObservaciones.BackColor = Color.LightSalmon;
                                    boLectura = false;
                                }
                                dgrvLineaVentaDS[ePosicionLineaDS.Observacion.GetHashCode(), pRowIndex].ReadOnly = boLectura;
                                dgrvLineaVentaDS[ePosicionLineaDS.Observacion.GetHashCode(), pRowIndex].Style = oCellStyleObservaciones;
                            } else {
                                boResultado = false;
                                dgrvLineaVentaDS.CancelEdit();
                            }
                            break;
                    }
                } catch (Exception ex) {
                    pMensaje = ex.Message;
                    boResultado = false;
                }
                return boResultado;
            }

            private bool ValidarCantidadJavasLineaVenta(ref string pMensaje, int pRowIndex) {
                bool boIndicadorCJ = true;
                object oCantidad = dgrvLineaVentaDS[ePosicionLineaDS.CantidadJavas.GetHashCode(), pRowIndex].Value;
                if (oCantidad == null || string.IsNullOrEmpty(oCantidad.ToString())) {
                    if (!string.IsNullOrEmpty(vg_strCantidad)) {
                        GridViewEstablecerValorLineaVenta(vg_strCantidad, pRowIndex, ePosicionLineaDS.CantidadJavas.GetHashCode());
                    } else {
                        boIndicadorCJ = false;
                        pMensaje = "Ingresar cantidad javas";
                    }
                } else {
                    // Validar que sea de tipo Int
                    int intCantidadJavas = 0;
                    bool flagValido = int.TryParse(oCantidad.ToString(), out intCantidadJavas);
                    if (!flagValido || intCantidadJavas < 0)
                    {
                        boIndicadorCJ = false;
                        pMensaje = "Ingresar cantidad javas válida";
                        GridViewEstablecerValorLineaVenta(vg_strCantidad, pRowIndex, ePosicionLineaDS.CantidadJavas.GetHashCode());
                    }
                }
                return boIndicadorCJ;
            }

            private bool ValidarPesoJavaLineaVenta(ref string pMensaje, int pRowIndex) {
                bool boIndicadorPJ = true;
                object oPesoJava = dgrvLineaVentaDS[ePosicionLineaDS.PesoJava.GetHashCode(), pRowIndex].Value;
                if (oPesoJava == null || string.IsNullOrEmpty(oPesoJava.ToString())) {
                    GridViewEstablecerValorLineaVenta(vg_decTara, pRowIndex, ePosicionLineaDS.PesoJava.GetHashCode());
                } else {
                    // Validar que sea de tipo decimal
                    decimal decPesoJava = decimal.Zero;
                    bool flagValido = decimal.TryParse(oPesoJava.ToString(), out decPesoJava);
                    if (! flagValido || decPesoJava < decimal.Zero)
                    {
                        boIndicadorPJ = false;
                        pMensaje = "Ingresar peso javas válido";
                        GridViewEstablecerValorLineaVenta(vg_decTara, pRowIndex, ePosicionLineaDS.PesoJava.GetHashCode());
                    }
                }
                return boIndicadorPJ;
            }

            private bool ValidarPesoBrutoLineaVenta(ref string pMensaje, int pRowIndex) {
                bool boIndicadorPB = true;
                object oPesoBruto = dgrvLineaVentaDS[ePosicionLineaDS.PesoBruto.GetHashCode(), pRowIndex].Value;
                if (oPesoBruto == null || string.IsNullOrEmpty(oPesoBruto.ToString())) {
                    if (!string.IsNullOrEmpty(vg_strPesoBruto)) {
                        GridViewEstablecerValorLineaVenta(vg_strPesoBruto, pRowIndex, ePosicionLineaDS.PesoBruto.GetHashCode());
                    } else {
                        boIndicadorPB = false;
                        pMensaje = "Ingresar peso bruto";
                    }
                } else {
                    // Validar que sea de tipo decimal
                    decimal decPesoBruto = decimal.Zero;
                    bool flagValido = decimal.TryParse(oPesoBruto.ToString(), out decPesoBruto);
                    if (!flagValido || decPesoBruto <= decimal.Zero)
                    {
                        boIndicadorPB = false;
                        pMensaje = "Ingresar peso bruto válido";
                        GridViewEstablecerValorLineaVenta(string.Empty, pRowIndex, ePosicionLineaDS.PesoBruto.GetHashCode());
                    }
                }
                return boIndicadorPB;
            }

            private bool ValidarPesoTaraLineaVenta(ref string pMensaje, int pRowIndex) {
                bool boIndicadorPT = true;
                object oPesoTara = dgrvLineaVentaDS[ePosicionLineaDS.PesoTara.GetHashCode(), pRowIndex].Value;
                if (oPesoTara == null || string.IsNullOrEmpty(oPesoTara.ToString())) {
                    if (!string.IsNullOrEmpty(vg_strPesoTara)) {
                        GridViewEstablecerValorLineaVenta(vg_strPesoTara, pRowIndex, ePosicionLineaDS.PesoTara.GetHashCode());
                        RecalcularPesoTaraLineaVenta(pRowIndex);
                    } else {
                        boIndicadorPT = false;
                        pMensaje = "Ingresar peso tara";
                    }
                } else {
                    // Validar que sea de tipo decimal
                    decimal decPesoTara = decimal.Zero;
                    bool flagValido = decimal.TryParse(oPesoTara.ToString(), out decPesoTara);
                    if (decPesoTara < decimal.Zero || !flagValido ) {
                        boIndicadorPT = false;
                        pMensaje = "Ingresar peso tara válido";
                        GridViewEstablecerValorLineaVenta(vg_strPesoTara, pRowIndex, ePosicionLineaDS.PesoTara.GetHashCode());
                    }
                }
                return boIndicadorPT;
            }

            private void CalcularCantidadJavasLineaVenta(int pRowIndex) {
                object oCantidad = dgrvLineaVentaDS[ePosicionLineaDS.CantidadJavas.GetHashCode(), pRowIndex].Value;
                object oPesoJava = dgrvLineaVentaDS[ePosicionLineaDS.PesoJava.GetHashCode(), pRowIndex].Value;
                // Calcular Peso Tara
                int intCantidad = int.Parse(oCantidad.ToString());
                decimal decPesoJava = decimal.Parse(oPesoJava.ToString());
                decimal decPesoTara = (intCantidad * decPesoJava);
                GridViewEstablecerValorLineaVenta(decPesoTara, pRowIndex, ePosicionLineaDS.PesoTara.GetHashCode());
                // Recalcular Peso Neto
                object oPesoBruto = dgrvLineaVentaDS[ePosicionLineaDS.PesoBruto.GetHashCode(), pRowIndex].Value;
                if (!string.IsNullOrEmpty(oPesoBruto.ToString())) {
                    decimal decPesoBruto = decimal.Parse(oPesoBruto.ToString());
                    decimal decPesoNeto = (decPesoBruto - decPesoTara);
                    GridViewEstablecerValorLineaVenta(decPesoNeto, pRowIndex, ePosicionLineaDS.PesoNeto.GetHashCode());
                }
            }

            private void RecalcularPesoJavaLineaVenta(int pRowIndex) {
                object oCantidad = dgrvLineaVentaDS[ePosicionLineaDS.CantidadJavas.GetHashCode(), pRowIndex].Value;
                // Recalcular Peso Tara
                object oPesoJava = dgrvLineaVentaDS[ePosicionLineaDS.PesoJava.GetHashCode(), pRowIndex].Value;
                if (!string.IsNullOrEmpty(oCantidad.ToString())) {
                    int intCantidad = int.Parse(oCantidad.ToString());
                    decimal decPesoJava = decimal.Parse(oPesoJava.ToString());
                    decimal decPesoTara = (intCantidad * decPesoJava);
                    GridViewEstablecerValorLineaVenta(decPesoTara, pRowIndex, ePosicionLineaDS.PesoTara.GetHashCode());
                    // Recalcular Peso Neto
                    object oPesoBruto = dgrvLineaVentaDS[ePosicionLineaDS.PesoBruto.GetHashCode(), pRowIndex].Value;
                    if (!string.IsNullOrEmpty(oPesoBruto.ToString())) {
                        decimal decPesoBruto = decimal.Parse(oPesoBruto.ToString());
                        decimal decPesoNeto = (decPesoBruto - decPesoTara);
                        GridViewEstablecerValorLineaVenta(decPesoNeto, pRowIndex, ePosicionLineaDS.PesoNeto.GetHashCode());
                    }
                }
            }

            private void CalcularPesoBrutoLineaVenta(int pRowIndex) {
                object oPesoTara = dgrvLineaVentaDS[ePosicionLineaDS.PesoTara.GetHashCode(), pRowIndex].Value;
                object oPesoBruto = dgrvLineaVentaDS[ePosicionLineaDS.PesoBruto.GetHashCode(), pRowIndex].Value;
                // Recalcular Peso Neto
                if (!string.IsNullOrEmpty(oPesoTara.ToString())) {
                    decimal decPesoTara = decimal.Parse(oPesoTara.ToString());
                    decimal decPesoBruto = decimal.Parse(oPesoBruto.ToString());
                    decimal decPesoNeto = (decPesoBruto - decPesoTara);
                    GridViewEstablecerValorLineaVenta(decPesoNeto, pRowIndex, ePosicionLineaDS.PesoNeto.GetHashCode());
                }
            }

            private void RecalcularPesoTaraLineaVenta(int pRowIndex) {
                object oPesoBruto = dgrvLineaVentaDS[ePosicionLineaDS.PesoBruto.GetHashCode(), pRowIndex].Value;
                object oPesoTara = dgrvLineaVentaDS[ePosicionLineaDS.PesoTara.GetHashCode(), pRowIndex].Value;
                // Recalcular Peso Neto
                if (!string.IsNullOrEmpty(oPesoBruto.ToString())) {
                    decimal decPesoBruto = decimal.Parse(oPesoBruto.ToString());
                    decimal decPesoTara = decimal.Parse(oPesoTara.ToString());
                    decimal decPesoNeto = (decPesoBruto - decPesoTara);
                    GridViewEstablecerValorLineaVenta(decPesoNeto, pRowIndex, ePosicionLineaDS.PesoNeto.GetHashCode());
                }
            }

            private void GridViewEstablecerValorLineaVenta(object pValor, int pRowIndex, int pColumnIndex) {
                dgrvLineaVentaDS[pColumnIndex, pRowIndex].Value = pValor;
            }



            private bool ValidarCamposAmortizacion(ref string pMensaje, int pRowIndex, int pColumnIndex) {
                bool boResultado = true;
                try {
                    switch ((ePosicionAmortizacionVenta)pColumnIndex) {
                        case ePosicionAmortizacionVenta.Pago:
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
                object oPagoCuenta = dgrvAmortizacion[ePosicionAmortizacionVenta.Pago.GetHashCode(), pRowIndex].Value;
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



            private bool ValidarCamposDevolucionVentaDS(ref string pMensaje, int pRowIndex, int pColumnIndex) {
                bool boResultado = true;
                try {
                    switch ((ePosicionDevolucion)pColumnIndex) {
                        case ePosicionDevolucion.CantidadJavas: // Para las Cantidades de Java
                            // Validar Campo vacio y valor
                            if (vg_dsDevolucionVenta.DTLineaVenta[pRowIndex].ValidarCantidadJavas(ref pMensaje, vg_strCantidad)) {
                                // Calcular Cantidades de Javas
                                vg_dsDevolucionVenta.DTLineaVenta[pRowIndex].CalcularCantidadJavas();
                                vg_dsDevolucionVenta.DTLineaVenta[pRowIndex].CalcularCantidadUnidades();
                                // Reestablecer Style de la Columna de Observacion
                                oCellStyleObservaciones = new DataGridViewCellStyle();
                                oCellStyleObservaciones.SelectionBackColor = Color.White;
                                oCellStyleObservaciones.BackColor = Color.White;
                                dgrvDevolucion[ePosicionDevolucion.Observaciones.GetHashCode(), pRowIndex].ReadOnly = true;
                                dgrvDevolucion[ePosicionDevolucion.Observaciones.GetHashCode(), pRowIndex].Style = oCellStyleObservaciones;
                            } else {
                                boResultado = false;
                                dgrvDevolucion.CancelEdit();
                            }
                            break;
                        case ePosicionDevolucion.PesoJava: // Para el Peso Java
                            // Validar campo vacio y valor
                            if (vg_dsDevolucionVenta.DTLineaVenta[pRowIndex].ValidarPesoJava(ref pMensaje, vg_strPesoJava)) {
                                // Recalcular Peso Java
                                vg_dsDevolucionVenta.DTLineaVenta[pRowIndex].RecalcularPesoJava();
                                // Validar si es Editado
                                object oPesoJava = dgrvDevolucion[pColumnIndex, pRowIndex].Value;
                                string strResultadoFlag = string.Empty;
                                string strPesoFinal = string.Empty;
                                if (vg_decTara.Equals(decimal.Parse(oPesoJava.ToString()))) {
                                    // Reestablecer el Flag y el PesoJavaDefecto
                                    strResultadoFlag = "N";
                                    strPesoFinal = vg_decTara.ToString();
                                } else if (decimal.Parse(vg_strPesoJava).Equals(decimal.Parse(oPesoJava.ToString()))) {
                                    strResultadoFlag = "N";
                                    strPesoFinal = vg_decTara.ToString();
                                    // Cambiar el Flag y el PesoJavaDefecto (Tara Editada)
                                } else {
                                    strResultadoFlag = "S";
                                    strPesoFinal = oPesoJava.ToString();
                                }
                                dgrvDevolucion[ePosicionDevolucion.FlagJava.GetHashCode(), pRowIndex].Value = strResultadoFlag;
                                dgrvDevolucion[ePosicionDevolucion.PesoJavaDefecto.GetHashCode(), pRowIndex].Value = decimal.Parse(strPesoFinal);
                            } else {
                                boResultado = false;
                                dgrvDevolucion.CancelEdit();
                            }
                            break;
                        case ePosicionDevolucion.PesoBruto: // Para el Peso Bruto
                            // Validar campo vacio y valor
                            if (vg_dsDevolucionVenta.DTLineaVenta[pRowIndex].ValidarPesoBruto(ref pMensaje, vg_strPesoBruto)) {
                                // Calcular Peso Bruto
                                vg_dsDevolucionVenta.DTLineaVenta[pRowIndex].CalcularPesoBruto();
                            } else {
                                boResultado = false;
                                dgrvDevolucion.CancelEdit();
                            }
                            break;
                        case ePosicionDevolucion.PesoTara: // Para el Peso tara
                            // Validar campo vacio y valor
                            if (vg_dsDevolucionVenta.DTLineaVenta[pRowIndex].ValidarPesoTara(ref pMensaje, vg_strPesoTara)) {
                                bool boLectura = true;
                                oCellStyleObservaciones = new DataGridViewCellStyle();
                                // Validar si es Editado
                                object oPesoTara = dgrvDevolucion[pColumnIndex, pRowIndex].Value;
                                if (vg_strPesoTara.Equals(oPesoTara.ToString())) {
                                    dgrvDevolucion[ePosicionDevolucion.FlagPesoTara.GetHashCode(), pRowIndex].Value = "N";
                                    // Reestablecer Style de la Columna de Observacion
                                    oCellStyleObservaciones.SelectionBackColor = Color.White;
                                    oCellStyleObservaciones.BackColor = Color.White;
                                } else {
                                    dgrvDevolucion[ePosicionDevolucion.FlagPesoTara.GetHashCode(), pRowIndex].Value = "S";
                                    // Recalcular Peso Tara
                                    vg_dsDevolucionVenta.DTLineaVenta[pRowIndex].RecalcularPesoTara();
                                    // Establecer Style de la Columna de Observacion
                                    oCellStyleObservaciones.SelectionBackColor = Color.LightSalmon;
                                    oCellStyleObservaciones.BackColor = Color.LightSalmon;
                                    boLectura = false;
                                }
                                dgrvDevolucion[ePosicionDevolucion.Observaciones.GetHashCode(), pRowIndex].ReadOnly = boLectura;
                                dgrvDevolucion[ePosicionDevolucion.Observaciones.GetHashCode(), pRowIndex].Style = oCellStyleObservaciones;
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

            private bool ValidarCamposDevolucionVentaGridView(ref string pMensaje, int pRowIndex, int pColumnIndex) {
                bool boResultado = true;
                try {
                    switch ((ePosicionDevolucion)pColumnIndex) {
                        case ePosicionDevolucion.CantidadJavas: // Para las Cantidades de Java
                            // Validar Campo vacio y valor
                            if (ValidarCantidadJavasDevolucion(ref pMensaje, pRowIndex)) {
                                // Calcular Cantidades de Javas
                                CalcularCantidadJavasDevolucion(pRowIndex);
                                // Reestablecer Style de la Columna de Observacion
                                oCellStyleObservaciones = new DataGridViewCellStyle();
                                oCellStyleObservaciones.SelectionBackColor = Color.Gainsboro;
                                oCellStyleObservaciones.BackColor = Color.White;
                                dgrvDevolucion[ePosicionDevolucion.Observaciones.GetHashCode(), pRowIndex].ReadOnly = true;
                                dgrvDevolucion[ePosicionDevolucion.Observaciones.GetHashCode(), pRowIndex].Style = oCellStyleObservaciones;
                            } else {
                                boResultado = false;
                                dgrvDevolucion.CancelEdit();
                            }
                            break;
                        case ePosicionDevolucion.PesoJava: // Para el Peso Java
                            // Validar campo vacio y valor
                            if (ValidarPesoJavaDevolucion(ref pMensaje, pRowIndex)) {
                                // Recalcular Peso Java
                                RecalcularPesoJavaDevolucion(pRowIndex);
                                // Validar si es Editado
                                object oPesoJava = dgrvDevolucion[pColumnIndex, pRowIndex].Value;
                                if (vg_decTara.Equals(decimal.Parse(oPesoJava.ToString()))) {
                                    // Reestablecer el Flag y el PesoJavaDefecto (Tara Editada)
                                    GridViewEstablecerValorDevolucion("N", pRowIndex, ePosicionDevolucion.FlagJava.GetHashCode());
                                    GridViewEstablecerValorDevolucion(vg_decTara, pRowIndex, ePosicionDevolucion.PesoJavaDefecto.GetHashCode());
                                } else {
                                    // Cambiar el Flag y el PesoJavaDefecto (Tara Editada)
                                    GridViewEstablecerValorDevolucion("S", pRowIndex, ePosicionDevolucion.FlagJava.GetHashCode());
                                    GridViewEstablecerValorDevolucion(decimal.Parse(oPesoJava.ToString()), pRowIndex, ePosicionDevolucion.PesoJavaDefecto.GetHashCode());
                                }
                            } else {
                                boResultado = false;
                                dgrvDevolucion.CancelEdit();
                            }
                            break;
                        case ePosicionDevolucion.PesoBruto: // Para el Peso Bruto
                            // Validar campo vacio y valor
                            if (ValidarPesoBrutoDevolucion(ref pMensaje, pRowIndex)) {
                                // Calcular Peso Bruto
                                CalcularPesoBrutoDevolucion(pRowIndex);
                            } else {
                                boResultado = false;
                                dgrvDevolucion.CancelEdit();
                            }
                            break;
                        case ePosicionDevolucion.PesoTara: // Para el Peso Tara
                            // Validar campo vacio y valor
                            if (ValidarPesoTaraDevolucion(ref pMensaje, pRowIndex)) {
                                bool boLectura = true;
                                oCellStyleObservaciones = new DataGridViewCellStyle();
                                // Validar si es Editado
                                object oPesoTara = dgrvDevolucion[pColumnIndex, pRowIndex].Value;
                                if (vg_strPesoTara.Equals(oPesoTara.ToString())) {
                                    GridViewEstablecerValorDevolucion("N", pRowIndex, ePosicionDevolucion.FlagPesoTara.GetHashCode());
                                    // Reestablecer Style de la Columna de Observacion
                                    oCellStyleObservaciones.SelectionBackColor = Color.White;
                                    oCellStyleObservaciones.BackColor = Color.White;
                                } else {
                                    GridViewEstablecerValorDevolucion("S", pRowIndex, ePosicionDevolucion.FlagPesoTara.GetHashCode());
                                    // Recalcular Peso Tara
                                    RecalcularPesoTaraDevolucion(pRowIndex);
                                    // Establecer Style de la Columna de Observacion
                                    oCellStyleObservaciones.SelectionBackColor = Color.LightSalmon;
                                    oCellStyleObservaciones.BackColor = Color.LightSalmon;
                                    boLectura = false;
                                }
                                dgrvDevolucion[ePosicionDevolucion.Observaciones.GetHashCode(), pRowIndex].ReadOnly = boLectura;
                                dgrvDevolucion[ePosicionDevolucion.Observaciones.GetHashCode(), pRowIndex].Style = oCellStyleObservaciones;
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

            private bool ValidarCantidadJavasDevolucion(ref string pMensaje, int pRowIndex) {
                bool boIndicadorCJ = true;
                object oCantidad = dgrvDevolucion[ePosicionDevolucion.CantidadJavas.GetHashCode(), pRowIndex].Value;
                if (oCantidad == null || string.IsNullOrEmpty(oCantidad.ToString())) {
                    if (!string.IsNullOrEmpty(vg_strCantidad)) {
                        GridViewEstablecerValorDevolucion(vg_strCantidad, pRowIndex, ePosicionDevolucion.CantidadJavas.GetHashCode());
                    } else {
                        GridViewEstablecerValorDevolucion("0", pRowIndex, ePosicionDevolucion.CantidadJavas.GetHashCode());
                        //boIndicadorCJ = false;
                        //pMensaje = "Ingresar cantidad javas";
                    }
                } else {
                    // Validar que sea de tipo Int
                    int intCantidadJavas = 0;
                    bool bEnteroValido = int.TryParse(oCantidad.ToString(), out intCantidadJavas);
                    if (!bEnteroValido || intCantidadJavas < 0)
                    {
                        boIndicadorCJ = false;
                        pMensaje = "Ingresar cantidad javas válida";
                        GridViewEstablecerValorDevolucion(vg_strCantidad, pRowIndex, ePosicionDevolucion.CantidadJavas.GetHashCode());
                    }
                }
                return boIndicadorCJ;
            }

            private bool ValidarPesoJavaDevolucion(ref string pMensaje, int pRowIndex) {
                bool boIndicadorPJ = true;
                object oPesoJava = dgrvDevolucion[ePosicionDevolucion.PesoJava.GetHashCode(), pRowIndex].Value;
                if (oPesoJava == null || string.IsNullOrEmpty(oPesoJava.ToString())) {
                    GridViewEstablecerValorDevolucion(vg_decTara, pRowIndex, ePosicionDevolucion.PesoJava.GetHashCode());
                } else {
                    // Validar que sea de tipo decimal
                    decimal decPesoJava = decimal.Zero;

                    bool bNumeroValido = decimal.TryParse(oPesoJava.ToString(), out decPesoJava);
                    if (!bNumeroValido || decPesoJava < decimal.Zero)
                    {
                        boIndicadorPJ = false;
                        pMensaje = "Ingresar peso javas válido";
                        GridViewEstablecerValorDevolucion(vg_decTara, pRowIndex, ePosicionDevolucion.PesoJava.GetHashCode());
                    }
                }
                return boIndicadorPJ;
            }

            private bool ValidarPesoBrutoDevolucion(ref string pMensaje, int pRowIndex) {
                bool boIndicadorPB = true;
                object oPesoBruto = dgrvDevolucion[ePosicionDevolucion.PesoBruto.GetHashCode(), pRowIndex].Value;
                if (oPesoBruto == null || string.IsNullOrEmpty(oPesoBruto.ToString())) {
                    if (!string.IsNullOrEmpty(vg_strPesoBruto)) {
                        GridViewEstablecerValorDevolucion(vg_strPesoBruto, pRowIndex, ePosicionDevolucion.PesoBruto.GetHashCode());
                    } else {
                        boIndicadorPB = false;
                        pMensaje = "Ingresar peso bruto";
                    }
                } else {
                    // Validar que sea de tipo decimal
                    decimal decPesoBruto = decimal.Zero;
                    bool bNumeroValido =  decimal.TryParse(oPesoBruto.ToString(), out decPesoBruto);
                    if (!bNumeroValido || decPesoBruto < decimal.Zero)
                    {
                        boIndicadorPB = false;
                        pMensaje = "Ingresar peso bruto válido";
                        GridViewEstablecerValorDevolucion(string.Empty, pRowIndex, ePosicionDevolucion.PesoBruto.GetHashCode());
                    }
                }
                return boIndicadorPB;
            }

            private bool ValidarPesoTaraDevolucion(ref string pMensaje, int pRowIndex) {
                bool boIndicadorPT = true;
                object oPesoTara = dgrvDevolucion[ePosicionDevolucion.PesoTara.GetHashCode(), pRowIndex].Value;
                if (oPesoTara == null || string.IsNullOrEmpty(oPesoTara.ToString())) {
                    if (!string.IsNullOrEmpty(vg_strPesoTara)) {
                        GridViewEstablecerValorDevolucion(vg_strPesoTara, pRowIndex, ePosicionDevolucion.PesoTara.GetHashCode());
                        RecalcularPesoTaraDevolucion(pRowIndex);
                    } else {
                        boIndicadorPT = false;
                        pMensaje = "Ingresar peso tara";
                    }
                } else {
                    // Validar que sea de tipo decimal
                    decimal decPesoTara = decimal.Zero;
                    bool bNumeroValido =  decimal.TryParse(oPesoTara.ToString(), out decPesoTara);
                    if (!bNumeroValido || decPesoTara < decimal.Zero)
                    {
                        boIndicadorPT = false;
                        pMensaje = "Ingresar peso tara válido";
                        GridViewEstablecerValorDevolucion(vg_strPesoTara, pRowIndex, ePosicionDevolucion.PesoTara.GetHashCode());
                    }
                }
                return boIndicadorPT;
            }

            private void CalcularCantidadJavasDevolucion(int pRowIndex) {
                object oCantidad = dgrvDevolucion[ePosicionDevolucion.CantidadJavas.GetHashCode(), pRowIndex].Value;
                object oPesoJava = dgrvDevolucion[ePosicionDevolucion.PesoJava.GetHashCode(), pRowIndex].Value;
                // Calcular Peso Tara
                int intCantidad = 0;
                int.TryParse(oCantidad == null ? "0" : oCantidad.ToString() , out intCantidad);
                decimal decPesoJava = 0;
                decimal.TryParse(oPesoJava == null ? "0" : oPesoJava.ToString(), out decPesoJava);
                decimal decPesoTara = (intCantidad * decPesoJava);
                GridViewEstablecerValorDevolucion(decPesoTara, pRowIndex, ePosicionDevolucion.PesoTara.GetHashCode());
                // Recalcular Peso Neto
                object oPesoBruto = dgrvDevolucion[ePosicionDevolucion.PesoBruto.GetHashCode(), pRowIndex].Value;
                decimal decPesoBruto = 0;
                decimal.TryParse(oPesoBruto == null ? "0" : oPesoBruto.ToString(),out  decPesoBruto);
                decimal decPesoNeto = (decPesoBruto - decPesoTara);
                GridViewEstablecerValorDevolucion(decPesoNeto, pRowIndex, ePosicionDevolucion.PesoNeto.GetHashCode());
                
            }

            private void RecalcularPesoJavaDevolucion(int pRowIndex) {
                object oCantidad = dgrvDevolucion[ePosicionDevolucion.CantidadJavas.GetHashCode(), pRowIndex].Value;
                // Recalcular Peso Tara
                object oPesoJava = dgrvDevolucion[ePosicionDevolucion.PesoJava.GetHashCode(), pRowIndex].Value;
                if (!string.IsNullOrEmpty(oCantidad.ToString())) {
                    int intCantidad = 0; 
                    int.TryParse(oCantidad == null ? "0" : oCantidad.ToString() , out intCantidad);
                //
                    decimal decPesoJava = 0;
                    decimal.TryParse(oPesoJava == null ? "0" : oPesoJava.ToString(), out decPesoJava);
                    decimal decPesoTara = (intCantidad * decPesoJava);
                    GridViewEstablecerValorDevolucion(decPesoTara, pRowIndex, ePosicionDevolucion.PesoTara.GetHashCode());
                    // Recalcular Peso Neto
                    object oPesoBruto = dgrvDevolucion[ePosicionDevolucion.PesoBruto.GetHashCode(), pRowIndex].Value;
                    decimal decPesoBruto = 0;
                    decimal.TryParse(oPesoBruto == null ? "0" : oPesoBruto.ToString(), out  decPesoBruto);
                    decimal decPesoNeto = (decPesoBruto - decPesoTara);
                    GridViewEstablecerValorDevolucion(decPesoNeto, pRowIndex, ePosicionDevolucion.PesoNeto.GetHashCode());
                
                //
                    //decimal decPesoJava = decimal.Parse(oPesoJava.ToString());
                    //decimal decPesoTara = (intCantidad * decPesoJava);
                    //GridViewEstablecerValorDevolucion(decPesoTara, pRowIndex, ePosicionDevolucion.PesoTara.GetHashCode());
                    //// Recalcular Peso Neto
                    //object oPesoBruto = dgrvDevolucion[ePosicionDevolucion.PesoBruto.GetHashCode(), pRowIndex].Value;
                    //if (!string.IsNullOrEmpty(oPesoBruto.ToString())) {
                    //    decimal decPesoBruto = decimal.Parse(oPesoBruto.ToString());
                    //    decimal decPesoNeto = (decPesoBruto - decPesoTara);
                    //    GridViewEstablecerValorDevolucion(decPesoNeto, pRowIndex, ePosicionDevolucion.PesoNeto.GetHashCode());
                    //}
                }
            }

            private void CalcularPesoBrutoDevolucion(int pRowIndex) {
                object oPesoTara = dgrvDevolucion[ePosicionDevolucion.PesoTara.GetHashCode(), pRowIndex].Value;
                object oPesoBruto = dgrvDevolucion[ePosicionDevolucion.PesoBruto.GetHashCode(), pRowIndex].Value;
                // Recalcular Peso Neto
                if (!string.IsNullOrEmpty(oPesoTara.ToString())) {

                    //decimal decPesoTara = decimal.Parse(oPesoTara.ToString());
                    decimal decPesoTara = 0;
                    decimal.TryParse(oPesoTara == null ? "0" : oPesoTara.ToString(), out  decPesoTara);
                   
                    //decimal decPesoBruto = decimal.Parse(oPesoBruto.ToString());
                    decimal decPesoBruto = 0;
                    decimal.TryParse(oPesoBruto == null ? "0" : oPesoBruto.ToString(), out  decPesoBruto);
                   
                    decimal decPesoNeto = (decPesoBruto - decPesoTara);
                    GridViewEstablecerValorDevolucion(decPesoNeto, pRowIndex, ePosicionDevolucion.PesoNeto.GetHashCode());
                }
            }

            private void RecalcularPesoTaraDevolucion(int pRowIndex) {
                object oPesoBruto = dgrvDevolucion[ePosicionDevolucion.PesoBruto.GetHashCode(), pRowIndex].Value;
                object oPesoTara = dgrvDevolucion[ePosicionDevolucion.PesoTara.GetHashCode(), pRowIndex].Value;
                // Recalcular Peso Neto
                if (!string.IsNullOrEmpty(oPesoBruto.ToString())) {
                    //decimal decPesoTara = decimal.Parse(oPesoTara.ToString());
                    decimal decPesoTara = 0;
                    decimal.TryParse(oPesoTara == null ? "0" : oPesoTara.ToString(), out  decPesoTara);

                    //decimal decPesoBruto = decimal.Parse(oPesoBruto.ToString());
                    decimal decPesoBruto = 0;
                    decimal.TryParse(oPesoBruto == null ? "0" : oPesoBruto.ToString(), out  decPesoBruto);
                   
                    decimal decPesoNeto = (decPesoBruto - decPesoTara);
                    GridViewEstablecerValorDevolucion(decPesoNeto, pRowIndex, ePosicionDevolucion.PesoNeto.GetHashCode());
                }
            }

            private void GridViewEstablecerValorDevolucion(object pValor, int pRowIndex, int pColumnIndex) {
                dgrvDevolucion[pColumnIndex, pRowIndex].Value = pValor;
            }

        #endregion

        /// <summary>
        /// APP.- Utilizado para las devoluciones y líneas de Venta
        /// </summary>
        private enum ePosicionLineaDS {
            IdLinea = 0
            ,FlagJava = 1
            ,TaraEditada = 2
            ,FlagPesoTara = 3
            ,CantidadJavas = 4
            ,PesoJava = 5
            ,PesoBruto = 6
            ,PesoTara = 7
            ,PesoNeto = 8
            ,Unidades = 9
            ,Observacion = 10
            ,BotonEliminar = 11
        }

        private enum ePosicionAmortizacionVenta {
            Indicador = 0
            ,IdVenta = 1
            ,IdProducto = 2
            ,Cantidad = 6
            ,PesoNeto = 7
            ,Importe = 8
            ,Saldo = 9
            ,Pago = 10
        }

        private enum ePosicionDevolucion {
            IdDevolucion = 0
            ,FlagJava = 1
            ,PesoJavaDefecto = 2
            ,FlagPesoTara = 3
            ,CantidadJavas = 4
            ,PesoJava = 5
            ,PesoBruto = 6
            ,PesoTara = 7
            ,PesoNeto = 8
            ,Unidades = 9
            ,Observaciones = 10
            , BotonEliminar = 11
        }

        private enum eTabDetalleVenta { 
            TabLineaVenta = 0
            ,TabAmortizacionVenta = 1
            ,TabDevolucionVenta = 2
        }

        private void TxtTABToENTER_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }   
        }

        

    }
}