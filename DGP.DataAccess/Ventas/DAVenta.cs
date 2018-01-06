using System;   
using System.Collections.Generic;
using System.Text;
using DGP.Entities.DataSet;
using DGP.Entities.Ventas;
using DGP.Entities;
using DBHelper;
using System.Data;

namespace DGP.DataAccess.Ventas {

    public class DAVenta {

        #region "Métodos de DAVenta"

            public List<BEVenta> ListarVentaCliente(BEVenta pBEVenta) {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                List<BEVenta> vLista = new List<BEVenta>();
                IDataReader oIDataReader = null;
                BEVenta oBEVenta = null;
                try {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@intIdCliente", pBEVenta.IdCliente);
                    oDatabaseHelper.AddParameter("@intIdProducto", pBEVenta.IdProducto);
                    oDatabaseHelper.AddParameter("@intIdCaja", pBEVenta.IdCaja);
                    oIDataReader = oDatabaseHelper.ExecuteReader("DGP_Listar_VentaCliente", CommandType.StoredProcedure);
                    while (oIDataReader.Read()) {
                        oBEVenta = new BEVenta();
                        oBEVenta.IdVenta = oIDataReader.GetInt32(0);
                        oBEVenta.NombreVenta = oIDataReader.GetString(1);
                        vLista.Add(oBEVenta);
                    }

                    return vLista;

                } catch (Exception ex) {
                    throw ex;
                } finally {
                    if (!oIDataReader.IsClosed) oIDataReader.Close();
                    oIDataReader.Dispose();
                    oDatabaseHelper.Dispose();
                }
            }

            public BEVenta ObtenerVenta(int pIdVenta) {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                BEVenta oBEVenta = null;
                IDataReader oIDataReader = null;
                try {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@intIdVenta", pIdVenta);
                    oIDataReader = oDatabaseHelper.ExecuteReader("DGP_Obtener_Venta", CommandType.StoredProcedure);

                    if (oIDataReader.Read()) {
                        oBEVenta = new BEVenta();
                        oBEVenta.IdVenta = int.Parse(oIDataReader["Id_Venta"].ToString());
                        oBEVenta.IdTipoDocumentoVenta = (oIDataReader["IdTipoDocumentoVenta"] == (object)DBNull.Value) ? string.Empty : oIDataReader["IdTipoDocumentoVenta"].ToString();
                        oBEVenta.NumeroDocumento = (oIDataReader["NumeroDocumento"] == (object)DBNull.Value) ? string.Empty : oIDataReader["NumeroDocumento"].ToString();
                        oBEVenta.TotalPesoBruto = decimal.Parse(oIDataReader["Total_Peso_Bruto"].ToString());
                        oBEVenta.TotalPesoTara = decimal.Parse(oIDataReader["Total_Peso_Tara"].ToString());
                        oBEVenta.TotalPesoNeto = decimal.Parse(oIDataReader["Total_Peso_Neto"].ToString());
                        oBEVenta.Precio = decimal.Parse(oIDataReader["Precio"].ToString());
                        oBEVenta.MontoSubTotal = decimal.Parse(oIDataReader["Monto_SubTotal"].ToString());
                        oBEVenta.MontoIGV = decimal.Parse(oIDataReader["Monto_Igv"].ToString());
                        oBEVenta.MontoTotal = decimal.Parse(oIDataReader["Monto_Total"].ToString());
                        oBEVenta.EsSobrante = (eVentaEsSobrante)int.Parse(oIDataReader["EsSobrante"].ToString());
                        oBEVenta.TieneDevolucion = oIDataReader["TieneDevolucion"].ToString();
                        oBEVenta.TotalDevolucion = (oIDataReader["Total_Devolucion"] == (object)DBNull.Value) ? decimal.Zero : decimal.Parse(oIDataReader["Total_Devolucion"].ToString());
                        oBEVenta.TotalAmortizacion = (oIDataReader["Total_Amortizacion"] == (object)DBNull.Value) ? decimal.Zero : decimal.Parse(oIDataReader["Total_Amortizacion"].ToString());
                        oBEVenta.TotalSaldo = decimal.Parse(oIDataReader["Total_Saldo"].ToString());
                        oBEVenta.Observacion = oIDataReader["Observacion"].ToString();
                        oBEVenta.IdEstado = oIDataReader["IdEstado"].ToString();
                        oBEVenta.IdCaja = int.Parse(oIDataReader["Id_Caja"].ToString());
                        oBEVenta.IdEmpresa = int.Parse(oIDataReader["Id_Empresa"].ToString());
                        oBEVenta.IdProducto = int.Parse(oIDataReader["Id_Producto"].ToString());
                        oBEVenta.Producto = oIDataReader["Producto"].ToString();
                        //oBEVenta.TotalUnidades = int.Parse(oIDataReader["TotalUnidades"].ToString());
                        oBEVenta.TotalUnidades = (oIDataReader["TotalUnidades"] == (object)DBNull.Value) ? 0 : int.Parse(oIDataReader["TotalUnidades"].ToString());
                        
                        oBEVenta.IdCliente = (oIDataReader["Id_Cliente"] == (object)DBNull.Value) ? 0 : int.Parse(oIDataReader["Id_Cliente"].ToString());
                    }

                    return oBEVenta;
                } catch (Exception ex) {  
                    throw ex;
                } finally {
                    if (!oIDataReader.IsClosed) oIDataReader.Close();
                    oIDataReader.Dispose();
                    oDatabaseHelper.Dispose();
                }
            }

        public List<BEVenta> ListarVenta(int pIdVenta, int pIdCaja, DatabaseHelper pDatabaseHelper)
        {

                DatabaseHelper oDatabaseHelper = (pDatabaseHelper == null) ? new DatabaseHelper() : pDatabaseHelper;
                List<BEVenta> vLista = new List<BEVenta>();
                BEVenta oBEVenta = null;
                IDataReader oIDataReader = null;
                try {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@intIdVenta", (pIdVenta <= 0) ? (object)DBNull.Value : pIdVenta);
                    oDatabaseHelper.AddParameter("@intIdCaja", (pIdCaja <= 0) ? (object)DBNull.Value : pIdCaja);
                    oIDataReader = oDatabaseHelper.ExecuteReader("DGP_Listar_Venta", CommandType.StoredProcedure , DBHelper.ConnectionState.KeepOpen);

                    while (oIDataReader.Read()) {
                        oBEVenta = new BEVenta();
                        oBEVenta.IdVenta = int.Parse(oIDataReader["Id_Venta"].ToString());
                        oBEVenta.IdTipoDocumentoVenta = (oIDataReader["IdTipoDocumentoVenta"] == (object)DBNull.Value) ? string.Empty : oIDataReader["IdTipoDocumentoVenta"].ToString();
                        oBEVenta.TipoDocumentoVenta = (oIDataReader["TipoDocumentoVenta"] == (object)DBNull.Value) ? string.Empty : oIDataReader["TipoDocumentoVenta"].ToString();
                        oBEVenta.NumeroDocumento = (oIDataReader["NumeroDocumento"] == (object)DBNull.Value) ? string.Empty : oIDataReader["NumeroDocumento"].ToString();
                        oBEVenta.TotalPesoBruto = decimal.Parse(oIDataReader["Total_Peso_Bruto"].ToString());
                        oBEVenta.TotalPesoTara = decimal.Parse(oIDataReader["Total_Peso_Tara"].ToString());
                        oBEVenta.TotalPesoNeto = decimal.Parse(oIDataReader["Total_Peso_Neto"].ToString());
                        oBEVenta.Precio = decimal.Parse(oIDataReader["Precio"].ToString());
                        oBEVenta.MontoSubTotal = decimal.Parse(oIDataReader["Monto_SubTotal"].ToString());
                        oBEVenta.MontoIGV = decimal.Parse(oIDataReader["Monto_Igv"].ToString());
                        oBEVenta.MontoTotal = decimal.Parse(oIDataReader["Monto_Total"].ToString());
                        oBEVenta.EsSobrante = (eVentaEsSobrante)int.Parse(oIDataReader["EsSobrante"].ToString());
                        oBEVenta.TieneDevolucion = oIDataReader["TieneDevolucion"].ToString();
                        oBEVenta.TotalDevolucion = (oIDataReader["Total_Devolucion"] == (object)DBNull.Value) ? decimal.Zero : decimal.Parse(oIDataReader["Total_Devolucion"].ToString());
                        oBEVenta.TotalAmortizacion = (oIDataReader["Total_Amortizacion"] == (object)DBNull.Value) ? decimal.Zero : decimal.Parse(oIDataReader["Total_Amortizacion"].ToString());
                        oBEVenta.TotalSaldo = decimal.Parse(oIDataReader["Total_Saldo"].ToString());
                        oBEVenta.Observacion = oIDataReader["Observacion"].ToString();
                        oBEVenta.IdEstado = oIDataReader["IdEstado"].ToString();
                        oBEVenta.IdCaja = int.Parse(oIDataReader["Id_Caja"].ToString());
                        oBEVenta.IdEmpresa = int.Parse(oIDataReader["Id_Empresa"].ToString());
                        oBEVenta.Empresa = oIDataReader["Empresa"].ToString();
                        oBEVenta.IdProducto = int.Parse(oIDataReader["Id_Producto"].ToString());
                        oBEVenta.Producto = oIDataReader["Producto"].ToString();
                        oBEVenta.IdCliente = (oIDataReader["Id_Cliente"] == (object)DBNull.Value) ? 0 : int.Parse(oIDataReader["Id_Cliente"].ToString());
                        oBEVenta.Cliente = oIDataReader["Cliente"].ToString();
                        oBEVenta.FechaCreacion = Convert.ToDateTime(oIDataReader["FechaCreacion"]).ToShortDateString();
                        oBEVenta.TotalUnidades = (oIDataReader["TotalUnidades"] == (object)DBNull.Value) ? 0 : int.Parse(oIDataReader["TotalUnidades"].ToString());
                        
                        vLista.Add(oBEVenta);
                    }
                    return vLista;
                } catch (Exception ex) {
                    if (pDatabaseHelper == null) oDatabaseHelper.Dispose();
                    throw ex;
                } finally {
                    if (!oIDataReader.IsClosed) oIDataReader.Close();
                    oIDataReader.Dispose();
                    if (pDatabaseHelper == null) oDatabaseHelper.Dispose();
                }
            }

            public List<BEVenta> ListarVenta(int pIdVenta, int pIdCaja, int pIdZona, int pIdProducto, int pIdCliente) {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                List<BEVenta> vLista = new List<BEVenta>();
                BEVenta oBEVenta = null;
                IDataReader oIDataReader = null;
                try {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@intIdVenta", (pIdVenta <= 0) ? (object)DBNull.Value : pIdVenta);
                    oDatabaseHelper.AddParameter("@intIdCaja", (pIdCaja <= 0) ? (object)DBNull.Value : pIdCaja);
                    oDatabaseHelper.AddParameter("@intIdZona", (pIdZona <= 0) ? (object)DBNull.Value : pIdZona);
                    oDatabaseHelper.AddParameter("@intIdProducto", (pIdProducto <= 0) ? (object)DBNull.Value : pIdProducto);
                    oDatabaseHelper.AddParameter("@intIdCliente", (pIdCliente <= 0) ? (object)DBNull.Value : pIdCliente);
                    oIDataReader = oDatabaseHelper.ExecuteReader("DGP_Listar_VentaBusqueda", CommandType.StoredProcedure);

                    while (oIDataReader.Read()) {
                        oBEVenta = new BEVenta();
                        oBEVenta.IdVenta = int.Parse(oIDataReader["Id_Venta"].ToString());
                        oBEVenta.IdTipoDocumentoVenta = (oIDataReader["IdTipoDocumentoVenta"] == (object)DBNull.Value) ? string.Empty : oIDataReader["IdTipoDocumentoVenta"].ToString();
                        oBEVenta.TipoDocumentoVenta = (oIDataReader["TipoDocumentoVenta"] == (object)DBNull.Value) ? string.Empty : oIDataReader["TipoDocumentoVenta"].ToString();
                        oBEVenta.NumeroDocumento = (oIDataReader["NumeroDocumento"] == (object)DBNull.Value) ? string.Empty : oIDataReader["NumeroDocumento"].ToString();
                        oBEVenta.TotalPesoBruto = decimal.Parse(oIDataReader["Total_Peso_Bruto"].ToString());
                        oBEVenta.TotalPesoTara = decimal.Parse(oIDataReader["Total_Peso_Tara"].ToString());
                        oBEVenta.TotalPesoNeto = decimal.Parse(oIDataReader["Total_Peso_Neto"].ToString());
                        oBEVenta.Precio = decimal.Parse(oIDataReader["Precio"].ToString());
                        oBEVenta.MontoSubTotal = decimal.Parse(oIDataReader["Monto_SubTotal"].ToString());
                        oBEVenta.MontoIGV = decimal.Parse(oIDataReader["Monto_Igv"].ToString());
                        oBEVenta.MontoTotal = decimal.Parse(oIDataReader["Monto_Total"].ToString());
                        oBEVenta.EsSobrante = (eVentaEsSobrante)int.Parse(oIDataReader["EsSobrante"].ToString());
                        oBEVenta.TieneDevolucion = oIDataReader["TieneDevolucion"].ToString();
                        oBEVenta.TotalDevolucion = (oIDataReader["Total_Devolucion"] == (object)DBNull.Value) ? decimal.Zero : decimal.Parse(oIDataReader["Total_Devolucion"].ToString());
                        oBEVenta.TotalAmortizacion = (oIDataReader["Total_Amortizacion"] == (object)DBNull.Value) ? decimal.Zero : decimal.Parse(oIDataReader["Total_Amortizacion"].ToString());
                        oBEVenta.TotalSaldo = decimal.Parse(oIDataReader["Total_Saldo"].ToString());
                        oBEVenta.Observacion = oIDataReader["Observacion"].ToString();
                        oBEVenta.IdEstado = oIDataReader["IdEstado"].ToString();
                        oBEVenta.IdCaja = int.Parse(oIDataReader["Id_Caja"].ToString());
                        oBEVenta.IdEmpresa = int.Parse(oIDataReader["Id_Empresa"].ToString());
                        oBEVenta.Empresa = oIDataReader["Empresa"].ToString();
                        oBEVenta.IdProducto = int.Parse(oIDataReader["Id_Producto"].ToString());
                        oBEVenta.Producto = oIDataReader["Producto"].ToString();
                        oBEVenta.IdCliente = (oIDataReader["Id_Cliente"] == (object)DBNull.Value) ? 0 : int.Parse(oIDataReader["Id_Cliente"].ToString());
                        oBEVenta.Cliente = oIDataReader["Cliente"].ToString();
                        oBEVenta.FechaCreacion = Convert.ToDateTime(oIDataReader["Fecha"]).ToShortDateString();
                        //oBEVenta.TotalUnidades = int.Parse(oIDataReader["TotalUnidades"].ToString());
                        oBEVenta.TotalUnidades = (oIDataReader["TotalUnidades"] == (object)DBNull.Value) ? 0 : int.Parse(oIDataReader["TotalUnidades"].ToString());
                        
                        vLista.Add(oBEVenta);
                    }
                    return vLista;
                } catch (Exception ex) {  
                    throw ex;
                } finally {
                    if (!oIDataReader.IsClosed) oIDataReader.Close();
                    oIDataReader.Dispose();
                    oDatabaseHelper.Dispose();
                }
            }

            public List<BEProducto> ListarProductoCliente(int pIdCliente) {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                List<BEProducto> vLista = new List<BEProducto>();
                BEProducto oBEProducto = null;
                IDataReader oIDataReader = null;
                try {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@intIdCliente", pIdCliente);
                    oIDataReader = oDatabaseHelper.ExecuteReader("DGP_Listar_ProductoClienteVenta", CommandType.StoredProcedure);

                    while (oIDataReader.Read()) {
                        oBEProducto = new BEProducto();
                        oBEProducto.IdProducto = int.Parse(oIDataReader["Id_Producto"].ToString());
                        oBEProducto.Nombre = oIDataReader["Producto"].ToString();
                        vLista.Add(oBEProducto);
                    }
                    return vLista;
                } catch (Exception ex) {  
                    throw ex;
                } finally {
                    if (!oIDataReader.IsClosed) oIDataReader.Close();
                    oIDataReader.Dispose();
                    oDatabaseHelper.Dispose();
                }
            }

            public int InsertarVentaInicial(ref BEVenta pBEVenta, DatabaseHelper pDatabaseHelper) {
                int vResultado = 0;
                try {
                    pDatabaseHelper.ClearParameter();
                    pDatabaseHelper.AddParameter("@intIdVenta", pBEVenta.IdVenta, ParameterDirection.InputOutput);
                    pDatabaseHelper.AddParameter("@varIdTipoDocumentoVenta", string.IsNullOrEmpty(pBEVenta.IdTipoDocumentoVenta) ? (object)DBNull.Value : pBEVenta.IdTipoDocumentoVenta);
                    pDatabaseHelper.AddParameter("@varNumeroDocumento", string.IsNullOrEmpty(pBEVenta.NumeroDocumento) ? (object)DBNull.Value : pBEVenta.NumeroDocumento);
                    pDatabaseHelper.AddParameter("@decPrecio", pBEVenta.Precio);
                    pDatabaseHelper.AddParameter("@intEsSobrante", pBEVenta.EsSobrante.GetHashCode());
                    pDatabaseHelper.AddParameter("@varObservacion", pBEVenta.Observacion);
                    pDatabaseHelper.AddParameter("@varClienteEventual", string.IsNullOrEmpty(pBEVenta.ClienteEventual) ? (object)DBNull.Value : pBEVenta.ClienteEventual);
                    pDatabaseHelper.AddParameter("@varIdEstado", pBEVenta.IdEstado);
                    pDatabaseHelper.AddParameter("@intIdCaja", pBEVenta.IdCaja);
                    pDatabaseHelper.AddParameter("@intIdEmpresa", pBEVenta.IdEmpresa);
                    pDatabaseHelper.AddParameter("@intIdProducto", pBEVenta.IdProducto);
                    pDatabaseHelper.AddParameter("@intIdCliente", (pBEVenta.IdCliente <= 0) ? (object)DBNull.Value : pBEVenta.IdCliente);
                    pDatabaseHelper.AddParameter("@intIdPersonal", pBEVenta.BEUsuarioLogin.IdPersonal);
                    //pDatabaseHelper.AddParameter("@intUnidades", pBEVenta.BEUsuarioLogin.IdPersonal);
                    
                    vResultado = pDatabaseHelper.ExecuteNonQuery("DGP_Insertar_Venta_Inicial", CommandType.StoredProcedure, DBHelper.ConnectionState.KeepOpen, true);
                    pBEVenta.IdVenta = Convert.ToInt32(pDatabaseHelper.GetParameter("@intIdVenta").Value.ToString());
                    return vResultado;
                } catch (Exception ex) {
                    throw ex;
                }
            }

            public int InsertarVentaFinal(BEVenta pBEVenta, DatabaseHelper pDatabaseHelper) {
                int vResultado = 0;
                try {
                    pDatabaseHelper.ClearParameter();
                    pDatabaseHelper.AddParameter("@intIdVenta", pBEVenta.IdVenta);
                    pDatabaseHelper.AddParameter("@decPrecioVenta", (pBEVenta.Precio <= 0) ? (Object)DBNull.Value : pBEVenta.Precio);
                    vResultado = pDatabaseHelper.ExecuteNonQuery("DGP_Insertar_Venta_Final", CommandType.StoredProcedure, DBHelper.ConnectionState.KeepOpen);


                    return vResultado;
                } catch (Exception ex) {
                    throw ex;
                }
            }

            public int ActualizarEstado(int pIdVenta, DatabaseHelper pDatabaseHelper)
            {
                return ActualizarEstado(pIdVenta, pDatabaseHelper , false);
            }
            public int ActualizarEstado(int pIdVenta, DatabaseHelper pDatabaseHelper , bool pbCancelar) {
                int vResultado = 0;
                try {
                    pDatabaseHelper.ClearParameter();
                    pDatabaseHelper.AddParameter("@intIdVenta", pIdVenta);
                    pDatabaseHelper.AddParameter("@intCancelarVenta", pbCancelar.GetHashCode());
                    vResultado = pDatabaseHelper.ExecuteNonQuery("DGP_Actualizar_EstadoVenta", CommandType.StoredProcedure, DBHelper.ConnectionState.KeepOpen);
                    return 1;
                } catch (Exception ex) {
                    throw ex;
                }
            }

            public List<VistaVenta> ListarVentaMantenimiento(BEVenta pBEVenta) {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                List<VistaVenta> vLista = new List<VistaVenta>();
                VistaVenta oVistaVenta = null;
                IDataReader oIDataReader = null;
                try {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@intIdVenta", (pBEVenta.IdVenta <= 0) ? (object)DBNull.Value : pBEVenta.IdVenta);
                    oDatabaseHelper.AddParameter("@varIdTipoDocumentoVenta", string.IsNullOrEmpty(pBEVenta.IdTipoDocumentoVenta) ? (object)DBNull.Value : pBEVenta.IdTipoDocumentoVenta);
                    oDatabaseHelper.AddParameter("@varNumeroDocumento", string.IsNullOrEmpty(pBEVenta.NumeroDocumento) ? (object)DBNull.Value : pBEVenta.NumeroDocumento);
                    oDatabaseHelper.AddParameter("@intIdCliente", (pBEVenta.IdCliente <= 0) ? (object)DBNull.Value : pBEVenta.IdCliente);
                    oDatabaseHelper.AddParameter("@intIdProducto", (pBEVenta.IdProducto <= 0) ? (object)DBNull.Value : pBEVenta.IdProducto);
                    oDatabaseHelper.AddParameter("@intIdEmpresa", (pBEVenta.IdEmpresa <= 0) ? (object)DBNull.Value : pBEVenta.IdEmpresa);
                    oDatabaseHelper.AddParameter("@datFechaInicial", pBEVenta.FechaInicio);
                    oDatabaseHelper.AddParameter("@datFechaFinal", pBEVenta.FechaFin);
                    oDatabaseHelper.AddParameter("@varFilterIdVentas", string.IsNullOrEmpty(pBEVenta.strFilterIds) ? (object)DBNull.Value : pBEVenta.strFilterIds);
                    oDatabaseHelper.AddParameter("@TienePrecioVariable", (!pBEVenta.TienePrecioVariable) ? (object)DBNull.Value : pBEVenta.TienePrecioVariable );
                    
                    
                    oIDataReader = oDatabaseHelper.ExecuteReader("DGP_Listar_Venta_Cabecera", CommandType.StoredProcedure);
                    
                    while (oIDataReader.Read()) {
                        oVistaVenta = new VistaVenta();
                        oVistaVenta.IdVenta = int.Parse(oIDataReader["Id_Venta"].ToString());
                        oVistaVenta.IdCliente = (oIDataReader["Id_Cliente"] == (object)DBNull.Value) ? 0 : int.Parse(oIDataReader["Id_Cliente"].ToString());
                        oVistaVenta.Cliente = oIDataReader["Cliente"].ToString();
                        oVistaVenta.IdProducto = int.Parse(oIDataReader["Id_Producto"].ToString());
                        oVistaVenta.Producto = oIDataReader["Producto"].ToString();
                        oVistaVenta.IdTipoDocumento = (oIDataReader["IdTipoDocumentoVenta"] == (object)DBNull.Value) ? string.Empty : oIDataReader["IdTipoDocumentoVenta"].ToString();
                        oVistaVenta.TipoDocumento = (oIDataReader["TipoDocumentoVenta"] == (object)DBNull.Value) ? string.Empty : oIDataReader["TipoDocumentoVenta"].ToString();
                        oVistaVenta.Fecha = Convert.ToDateTime(oIDataReader["FechaCreacion"]);
                        oVistaVenta.CantidadJavas = Convert.ToInt32(oIDataReader["CantidadJavas"]);
                        oVistaVenta.TotalPesoBruto = decimal.Parse(oIDataReader["Total_Peso_Bruto"].ToString());
                        oVistaVenta.TotalPesoTara = decimal.Parse(oIDataReader["Total_Peso_Tara"].ToString());
                        oVistaVenta.TotalPesoNeto = decimal.Parse(oIDataReader["Total_Peso_Neto"].ToString());
                        oVistaVenta.Precio = decimal.Parse(oIDataReader["Precio"].ToString());
                        oVistaVenta.MontoSubTotal = decimal.Parse(oIDataReader["Monto_SubTotal"].ToString());
                        oVistaVenta.MontoIGV = decimal.Parse(oIDataReader["Monto_Igv"].ToString());
                        oVistaVenta.MontoTotal = decimal.Parse(oIDataReader["Monto_Total"].ToString());
                        oVistaVenta.TotalDevolucion = (oIDataReader["Total_Devolucion"] == (object)DBNull.Value) ? decimal.Zero : decimal.Parse(oIDataReader["Total_Devolucion"].ToString());
                        oVistaVenta.TotalAmortizacion = (oIDataReader["Total_Amortizacion"] == (object)DBNull.Value) ? decimal.Zero : decimal.Parse(oIDataReader["Total_Amortizacion"].ToString());
                        oVistaVenta.TotalSaldo = decimal.Parse(oIDataReader["Total_Saldo"].ToString());
                        oVistaVenta.Estado = (oIDataReader["Estado"] == (object)DBNull.Value) ? string.Empty : oIDataReader["Estado"].ToString();
                        oVistaVenta.TotalUnidades = (oIDataReader["TotalUnidades"] == (object)DBNull.Value) ? 0 : Convert.ToInt32(oIDataReader["TotalUnidades"].ToString());
                        oVistaVenta.Margen = (oIDataReader["Margen"] == (object)DBNull.Value) ? (decimal)0.3 : decimal.Parse(oIDataReader["Margen"].ToString());

                        oVistaVenta.TienePrecioVariable = (oIDataReader["TienePrecioVariable"] == (object)DBNull.Value) ? false : bool.Parse( oIDataReader["TienePrecioVariable"].ToString());
                        
                        vLista.Add(oVistaVenta);
                    }
                    return vLista;
                } catch (Exception ex) {  
                    throw ex;
                } finally {
                    if (!oIDataReader.IsClosed) oIDataReader.Close();
                    oIDataReader.Dispose();
                    oDatabaseHelper.Dispose();
                }
            }

            public bool ValidarVentaSobranteDia(int pIdCaja) { 
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                bool boIndicador = false;
                IDataReader oIDataReader = null;
                try {
                    oDatabaseHelper.ClearParameter();
                    string strFormat = "SELECT dbo.DGP_Validar_SobranteDia({0})";
                    oIDataReader = oDatabaseHelper.ExecuteReader(string.Format(strFormat, pIdCaja), CommandType.Text);
                    if (oIDataReader.Read()) {
                        int intResultado = oIDataReader.GetInt32(0);
                        boIndicador = (intResultado == 1);
                    }
                    return boIndicador;
                } catch (Exception ex) {
                    throw ex;
                } finally {
                    if (!oIDataReader.IsClosed) oIDataReader.Close();
                    oIDataReader.Dispose();
                    oDatabaseHelper.Dispose();
                }
            }

            public int ActualizarEstado(int pIdVenta, string pEstado, string pObservacion) { 
                DatabaseHelper pDatabaseHelper = new DatabaseHelper();
                int vResultado = 0;
                try {
                    pDatabaseHelper.ClearParameter();
                    pDatabaseHelper.AddParameter("@intIdVenta", pIdVenta);
                    pDatabaseHelper.AddParameter("@varEstado", pEstado);
                    pDatabaseHelper.AddParameter("@varObservacion", pObservacion);
                    vResultado = pDatabaseHelper.ExecuteNonQuery("DGP_Actualizar_EstadoVentaRegistrada", CommandType.StoredProcedure, DBHelper.ConnectionState.CloseOnExit);
                    return vResultado;
                } catch (Exception ex) {
                    throw ex;
                } finally {
                    pDatabaseHelper.Dispose();
                }
            }

         

        #endregion

        #region Metodos del reporte
            public DSHojaCobranza ReporteCobranza(VistaVenta pVistaVenta)
            {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                DSHojaCobranza oDSHojaCobranza = new DSHojaCobranza();
                IDataReader oIDataReader = null;
                try
                {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@intIdVenta", (pVistaVenta.IdVenta <= 0) ? (object)DBNull.Value : pVistaVenta.IdVenta);
                    oDatabaseHelper.AddParameter("@datFecha", (pVistaVenta.Fecha == DateTime.MinValue) ? (object)DBNull.Value : pVistaVenta.Fecha);
                    oDatabaseHelper.AddParameter("@intIdCliente", (pVistaVenta.IdCliente <= 0) ? (object)DBNull.Value : pVistaVenta.IdCliente);
                    oDatabaseHelper.AddParameter("@intIdZona", (pVistaVenta.IdZona <= 0) ? (object)DBNull.Value : pVistaVenta.IdZona);
                    oIDataReader = oDatabaseHelper.ExecuteReader("DGP_Listar_ReporteVenta_Cobranza", CommandType.StoredProcedure);

                    while (oIDataReader.Read())
                    {
                        oDSHojaCobranza.COBRANZA.AddCOBRANZARow(
                                            oIDataReader["Id_Venta"].ToString()
                                            , Convert.ToDecimal(oIDataReader["Total_Saldo"])
                                            , oIDataReader["Tipo_Cobranza"].ToString()
                                            , Convert.ToDateTime(oIDataReader["FECHA"])
                                            , oIDataReader["Zona"].ToString()
                                            , oIDataReader["Cliente"].ToString()
                                            , oIDataReader["TIPO_CLIENTE"].ToString()
                                            , oIDataReader["PRODUCTO"].ToString()
                                            ,string.Empty
                                            , (oIDataReader["PesoNeto"] == DBNull.Value)? 0 : Convert.ToDecimal(oIDataReader["PesoNeto"])
                                            , oIDataReader["EsSaldo"].ToString()
                                            );
                    }
                    oDSHojaCobranza.COBRANZA.AcceptChanges();
                    return oDSHojaCobranza;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    oDatabaseHelper.Dispose();
                }
            }

        public DSRptTablero ReporteTablero(DGP.Entities.Reportes.BEFiltroTablero pFiltroTablero)
            {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                DSRptTablero oDSTablero = new DSRptTablero();
                
                try
                {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@dtFechaInicial", (pFiltroTablero.dtFechaInicio == null) ? (object)DBNull.Value : pFiltroTablero.dtFechaInicio);
                    oDatabaseHelper.AddParameter("@dtFechaFinal", (pFiltroTablero.dtFechaInicio == null) ? (object)DBNull.Value : pFiltroTablero.dtFechaInicio);
                    oDatabaseHelper.AddParameter("@vcListProductos", (pFiltroTablero.strListProductos == null) ? (object)DBNull.Value : pFiltroTablero.strListProductos);
                    oDatabaseHelper.AddParameter("@vcListZonas", (pFiltroTablero.strListZonas == null) ? (object)DBNull.Value : pFiltroTablero.strListZonas);
                    
                    DataSet ds = oDatabaseHelper.ExecuteDataSet("DGP_Reporte_Tablero2", CommandType.StoredProcedure);

                    oDSTablero.TABLERO.Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                    return oDSTablero;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    oDatabaseHelper.Dispose();
                }
            }
        public DSRptTablero ReporteDatosClientes(DGP.Entities.Reportes.BEFiltroTablero pFiltroTablero)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            DSRptTablero oDSTablero = new DSRptTablero();
            //            @dtFechaInicial	DATETIME = NULL , 
            //@dtFechaFinal	DATETIME = NULL ,
            //@vcListProductos varchar(200),
            //@vcListZonas	varchar(200)
            try
            {
                oDatabaseHelper.ClearParameter();
                oDatabaseHelper.AddParameter("@dtFechaInicial", (pFiltroTablero.dtFechaInicio == null) ? (object)DBNull.Value : pFiltroTablero.dtFechaInicio);
                oDatabaseHelper.AddParameter("@dtFechaFinal", (pFiltroTablero.dtFechaInicio == null) ? (object)DBNull.Value : pFiltroTablero.dtFechaInicio);
                oDatabaseHelper.AddParameter("@vcListProductos", (pFiltroTablero.strListProductos == null) ? (object)DBNull.Value : pFiltroTablero.strListProductos);
                oDatabaseHelper.AddParameter("@vcListZonas", (pFiltroTablero.strListZonas == null) ? (object)DBNull.Value : pFiltroTablero.strListZonas);
                DataSet ds = oDatabaseHelper.ExecuteDataSet("DGP_Rpt_Datos_clientes", CommandType.StoredProcedure);
                oDSTablero.TABLERO.Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                return oDSTablero;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDatabaseHelper.Dispose();
            }
        }
        public DSRptClientes ReporteEstadoCuentaClientes(DateTime? fechaInicio , string clientes )
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            DSRptClientes dSRptClientes = new DSRptClientes();
            
            try
            {
                oDatabaseHelper.ClearParameter();
                oDatabaseHelper.AddParameter("@fechaInicio", (fechaInicio == null) ? (object)DBNull.Value : fechaInicio);
                oDatabaseHelper.AddParameter("@clientes", (string.IsNullOrEmpty(clientes)) ? (object)DBNull.Value : clientes);
                DataSet ds = oDatabaseHelper.ExecuteDataSet("DGP_Rpt_Estado_CuentaCliente_v3", CommandType.StoredProcedure);
                dSRptClientes.DGP_Rpt_Estado_CuentaCliente.Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                dSRptClientes.DGP_Rpt_Estado_CuentaCliente.GenerarAcumulado();

          return dSRptClientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDatabaseHelper.Dispose();
            }
        }

        public DSRptTablero ReporteCobranzaCobrador(DGP.Entities.Reportes.BEFiltroTablero pFiltroTablero)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            DSRptTablero oDSTablero = new DSRptTablero();
            
            try
            {
                oDatabaseHelper.ClearParameter();
                oDatabaseHelper.AddParameter("@dtFechaInicial", pFiltroTablero.dtFechaInicio);
                oDatabaseHelper.AddParameter("@dtFechaFinal", pFiltroTablero.dtFechaFinal);
                oDatabaseHelper.AddParameter("@sPersonal", (pFiltroTablero.strListPersonal == null) ? (object)DBNull.Value : pFiltroTablero.strListPersonal);
                oDatabaseHelper.AddParameter("@intIdCaja", (pFiltroTablero.IdCaja == 0) ? (object)DBNull.Value : pFiltroTablero.IdCaja );
                oDatabaseHelper.AddParameter("@intIdModoReporte", (pFiltroTablero.IdModoReporte == 0) ? (object)decimal.Zero : pFiltroTablero.IdModoReporte);
               
                DataSet ds = oDatabaseHelper.ExecuteDataSet("DGP_Rpt_cobranza_cobrador", CommandType.StoredProcedure);
                oDSTablero.MOVIMIENTOS.Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                return oDSTablero;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDatabaseHelper.Dispose();
            }
        }

        public DSRptTablero ReporteHojaTablero(DGP.Entities.Reportes.BEFiltroTablero pFiltroTablero)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            DSRptTablero oDSTablero = new DSRptTablero();
            
            try
            {
                oDatabaseHelper.ClearParameter();
                oDatabaseHelper.AddParameter("@dtFechaInicial", (pFiltroTablero.dtFechaInicio == null) ? (object)DBNull.Value : pFiltroTablero.dtFechaInicio);
                oDatabaseHelper.AddParameter("@dtFechaFinal", (pFiltroTablero.dtFechaFinal == null) ? (object)DBNull.Value : pFiltroTablero.dtFechaFinal);
                oDatabaseHelper.AddParameter("@vcListProductos", (pFiltroTablero.strListProductos == null) ? (object)DBNull.Value : pFiltroTablero.strListProductos);
                oDatabaseHelper.AddParameter("@vcListZonas", (pFiltroTablero.strListZonas == null) ? (object)DBNull.Value : pFiltroTablero.strListZonas);

                DataSet ds = oDatabaseHelper.ExecuteDataSet("DGP_Reporte_Tablero", CommandType.StoredProcedure);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int filas = (int)row["lineas"];

                    for (int i = 0; i < filas; i++)
                    {
                        bool primerafila = (filas == 0);
                        oDSTablero.TABLERO.AddTABLERORow(string.Empty
                                                            , new DateTime()
                                                            , row["zona"].ToString()
                                                            , row["cliente"].ToString()
                                                            , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, string.Empty, row["producto"].ToString(), primerafila);

                        
                    }
                
                
                }

                //

                //oDSTablero.TABLERO.Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                return oDSTablero;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDatabaseHelper.Dispose();
            }
        }

        public DSRptClientes ReporteHojaPrecios(DGP.Entities.Reportes.BEFiltroTablero pFiltroTablero)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            DSRptClientes oDSTablero = new DSRptClientes();
            //            @dtFechaInicial	DATETIME = NULL , 
            //@dtFechaFinal	DATETIME = NULL ,
            //@vcListProductos varchar(200),
            //@vcListZonas	varchar(200)
            try
            {
                oDatabaseHelper.ClearParameter();
                oDatabaseHelper.AddParameter("@dtFechaInicial", (pFiltroTablero.dtFechaInicio == null) ? (object)DBNull.Value : pFiltroTablero.dtFechaInicio);
                oDatabaseHelper.AddParameter("@dtFechaFinal", (pFiltroTablero.dtFechaFinal == null) ? (object)DBNull.Value : pFiltroTablero.dtFechaFinal);
                oDatabaseHelper.AddParameter("@vcListProductos", (pFiltroTablero.strListProductos == null) ? (object)DBNull.Value : pFiltroTablero.strListProductos);
                oDatabaseHelper.AddParameter("@vcListZonas", (pFiltroTablero.strListZonas == null) ? (object)DBNull.Value : pFiltroTablero.strListZonas);

                DataSet ds = oDatabaseHelper.ExecuteDataSet("DGP_Reporte_precios", CommandType.StoredProcedure);

                oDSTablero.DT_LISTA_PRECIOS.Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                return oDSTablero;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDatabaseHelper.Dispose();
            }
        
        
        }
        #endregion

    }
}