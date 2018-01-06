using System;
using System.Text;

using System.Collections.Generic;
using DGP.Entities.Ventas;
using System.Data;
using DBHelper;

namespace DGP.DataAccess.Ventas {

    public class DAAmortizacionVenta {

        #region "Métodos de DAAmortizacionVenta"

            public int InsertarAdelantoVenta(BEAmortizacionVenta pBEAmortizacionVenta) {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                int vResultado = 0;
                try {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@decMonto", pBEAmortizacionVenta.Monto);
                    oDatabaseHelper.AddParameter("@varIdFormaPago", pBEAmortizacionVenta.IdFormaPago);
                    oDatabaseHelper.AddParameter("@varIdTipoAmortizacion", pBEAmortizacionVenta.IdTipoAmortizacion);
                    oDatabaseHelper.AddParameter("@varObservacion", pBEAmortizacionVenta.Observacion);
                    oDatabaseHelper.AddParameter("@varIdEstado", pBEAmortizacionVenta.IdEstado);
                    oDatabaseHelper.AddParameter("@intIdCliente", pBEAmortizacionVenta.IdCliente);
                    oDatabaseHelper.AddParameter("@intIdPersonal", pBEAmortizacionVenta.BEUsuarioLogin.IdPersonal);
                    vResultado = oDatabaseHelper.ExecuteNonQuery("DGP_Insertar_AdelantoVenta", CommandType.StoredProcedure, DBHelper.ConnectionState.CloseOnExit);
                    return vResultado;
                } catch (Exception ex) {
                    throw ex;
                } finally {
                    oDatabaseHelper.Dispose();
                }
            }

            public List<VistaAmortizacion> Listar(VistaAmortizacion pVistaAmortizacion) {
                DatabaseHelper oDBH = new DatabaseHelper();
                List<VistaAmortizacion> vLista = new List<VistaAmortizacion>();
                VistaAmortizacion oVistaAmortizacion = null;
                IDataReader oIDataReader = null;
                try {
                    oDBH.ClearParameter();
                    oDBH.AddParameter("@intIdVenta", (pVistaAmortizacion.IdVenta <= 0) ? (object)DBNull.Value : pVistaAmortizacion.IdVenta);
                    oDBH.AddParameter("@intIdCliente", (pVistaAmortizacion.IdCliente <= 0) ? (object)DBNull.Value : pVistaAmortizacion.IdCliente);
                    oDBH.AddParameter("@intIdProducto", (pVistaAmortizacion.IdProducto == 0) ? (object)DBNull.Value : pVistaAmortizacion.IdProducto);
                    oDBH.AddParameter("@intIncluCanceldos", (pVistaAmortizacion.IncluyeCancelados) ? (object)1 : (object)0);
                    oIDataReader = oDBH.ExecuteReader("DGP_Listar_Amortizacion", CommandType.StoredProcedure);

                    while (oIDataReader.Read()) {
                        oVistaAmortizacion = new VistaAmortizacion();
                        oVistaAmortizacion.IdAmortizacion = Convert.ToInt32(oIDataReader["intIdAmortizacion"]);
                        oVistaAmortizacion.IdVenta = Convert.ToInt32(oIDataReader["intIdVenta"]);
                        oVistaAmortizacion.TipoDocumento = oIDataReader["varTipoDocumento"].ToString();
                        oVistaAmortizacion.Producto = oIDataReader["varProducto"].ToString();
                        oVistaAmortizacion.Fecha = (oIDataReader["datFecha"] == (object)DBNull.Value) ? string.Empty : Convert.ToDateTime(oIDataReader["datFecha"]).Date.ToShortDateString();
                        oVistaAmortizacion.CantidadJavas = (oIDataReader["intCantidadJavas"] == (object)DBNull.Value) ? 0 : Convert.ToInt32(oIDataReader["intCantidadJavas"]);
                        oVistaAmortizacion.PesoNeto = (oIDataReader["decPesoNeto"] == (object)DBNull.Value) ? decimal.Zero : Convert.ToDecimal(oIDataReader["decPesoNeto"]);
                        oVistaAmortizacion.Importe = Convert.ToDecimal(oIDataReader["decImporte"]);
                        oVistaAmortizacion.Saldo = (oIDataReader["decSaldo"] == (object)DBNull.Value) ? decimal.Zero : Convert.ToDecimal(oIDataReader["decSaldo"]);
                        oVistaAmortizacion.Indicador = Convert.ToInt32(oIDataReader["intIndicador"]);

                        oVistaAmortizacion.IdPersonal = (oIDataReader["intIdPersonal"] == (object)DBNull.Value) ? 0 : Convert.ToInt32(oIDataReader["intIdPersonal"].ToString() ); ;
                        oVistaAmortizacion.Personal = (oIDataReader["varPesonal"] == (object)DBNull.Value) ? string.Empty : oIDataReader["varPesonal"].ToString();
                        oVistaAmortizacion.IdEstado = (oIDataReader["varEstado"] == (object)DBNull.Value) ? string.Empty : oIDataReader["varEstado"].ToString();
                        
                        oVistaAmortizacion.IncluyeCancelados = false;
                        
                        vLista.Add(oVistaAmortizacion);
                        
                    }
                    return vLista;
                } catch (Exception ex) {
                    throw ex;
                } finally {
                    oDBH.Dispose();
                }
            }

            public bool InsertarDependiente(BEDocumento pBEDocumento, BEAmortizacionVenta pBEAmortizacionVenta, DatabaseHelper pDatabaseHelper)
            {
                int vResultado = 0;
                try {
                    pDatabaseHelper.ClearParameter();
                    pDatabaseHelper.AddParameter("@decMonto", pBEAmortizacionVenta.Monto);
                    pDatabaseHelper.AddParameter("@varNumeroDocumento", pBEAmortizacionVenta.NroDocumento);
                    pDatabaseHelper.AddParameter("@varIdFormaPago", pBEAmortizacionVenta.IdFormaPago);
                    pDatabaseHelper.AddParameter("@datFechaPago", pBEAmortizacionVenta.FechaPago.Date);
                    pDatabaseHelper.AddParameter("@varIdTipoAmortizacion", pBEAmortizacionVenta.IdTipoAmortizacion);
                    pDatabaseHelper.AddParameter("@varObservacion", pBEAmortizacionVenta.Observacion);
                    pDatabaseHelper.AddParameter("@varIdEstado", pBEAmortizacionVenta.IdEstado);
                    pDatabaseHelper.AddParameter("@intIdVenta", pBEAmortizacionVenta.IdVenta);
                    pDatabaseHelper.AddParameter("@intIdCliente", (pBEAmortizacionVenta.IdCliente <= 0) ? (object)DBNull.Value : pBEAmortizacionVenta.IdCliente);
                    pDatabaseHelper.AddParameter("@intIdPersonal", pBEAmortizacionVenta.IdPersonal);
                    pDatabaseHelper.AddParameter("@intIdUsuarioCreacion", pBEAmortizacionVenta.BEUsuarioLogin.IdPersonal);
                    pDatabaseHelper.AddParameter("@intIdCaja", pBEAmortizacionVenta.BEUsuarioLogin.IdCaja);
                    pDatabaseHelper.AddParameter("@intIdDocumento", pBEDocumento.IdDocumento);
                    
                    vResultado = pDatabaseHelper.ExecuteNonQuery("DGP_Insertar_AmortizacionVenta", CommandType.StoredProcedure, DBHelper.ConnectionState.KeepOpen);
                    return (vResultado>0);
                } catch (Exception ex) {
                    throw ex;
                }
            }

            public int EliminarAdelantoVenta(BEAmortizacionVenta pBEAmortizacionVenta)
            {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                int vResultado = 0;
                try
                {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@intIdAmortizacion", pBEAmortizacionVenta.IdAmortizacionVenta);
                    oDatabaseHelper.AddParameter("@intIdUsuario", pBEAmortizacionVenta.BEUsuarioLogin.IdPersonal);
                    vResultado = oDatabaseHelper.ExecuteNonQuery("DGP_EliminarAmortizacion", CommandType.StoredProcedure, DBHelper.ConnectionState.CloseOnExit);
                    return vResultado;
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
        #region "Métodos de Documentos"
            public bool InsertarCabeceraDocumento(BEDocumento beDocumento)
            {
                return this.InsertarCabeceraDocumento(beDocumento, null);
            
            }

            public bool InsertarCabeceraDocumento(BEDocumento beDocumento, DatabaseHelper pDatabaseHelper)
            {
                DatabaseHelper oDatabaseHelper = (pDatabaseHelper == null) ? new DatabaseHelper() : pDatabaseHelper;
                
                try
                {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@IdTipoDocumento", beDocumento.IdTipoDocumento);
                    oDatabaseHelper.AddParameter("@Fecha", beDocumento.Fecha.Date);
                    oDatabaseHelper.AddParameter("@Monto", beDocumento.Monto);
                    //oDatabaseHelper.AddParameter("@Estado", beDocumento.Estado);
                    //oDatabaseHelper.AddParameter("@EsEliminado", beDocumento.EsEliminado);
                    oDatabaseHelper.AddParameter("@Usuario", beDocumento.BEUsuarioLogin.IdPersonal);
                    oDatabaseHelper.AddParameter("@IdCaja", beDocumento.BEUsuarioLogin.IdCaja);
                    oDatabaseHelper.AddParameter("@IdCliente", beDocumento.Cliente.IdCliente);
                    oDatabaseHelper.AddParameter("@IdPersonal", beDocumento.Personal.IdPersonal);

                    object vResultado = oDatabaseHelper.ExecuteScalar("InsertarDocumento", CommandType.StoredProcedure, (pDatabaseHelper == null) ? DBHelper.ConnectionState.CloseOnExit : DBHelper.ConnectionState.KeepOpen);
                    beDocumento.IdDocumento = int.Parse(vResultado.ToString());
                    return (vResultado != null);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally {

                    if (pDatabaseHelper== null) oDatabaseHelper.Dispose();
                }
            
            }

            public bool ReaplicarAmortizacion(BEVenta beVenta)
            {

                return this.ReaplicarAmortizacion(beVenta, null);
            
            }
            public bool ReaplicarAmortizacion(BEVenta beVenta, DatabaseHelper pDatabaseHelper)
            {

                DatabaseHelper oDatabaseHelper = (pDatabaseHelper == null) ? new DatabaseHelper() : pDatabaseHelper;

                try
                {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@IdCliente", beVenta.IdCliente);
                    oDatabaseHelper.AddParameter("@idUsuario", beVenta.BEUsuarioLogin.IdPersonal);
                    oDatabaseHelper.AddParameter("@IdCaja", beVenta.BEUsuarioLogin.IdCaja);

                    int vResultado = oDatabaseHelper.ExecuteNonQuery("DGP_ReAplicar Amortizaciones", CommandType.StoredProcedure, (pDatabaseHelper == null) ? DBHelper.ConnectionState.CloseOnExit : DBHelper.ConnectionState.KeepOpen);
                 
                    return (vResultado >0);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {

                    if (pDatabaseHelper == null) oDatabaseHelper.Dispose();
                }
            
            
            }

            public bool AnularAmortizacionVenta(BEVenta beVenta, DatabaseHelper pDatabaseHelper)
            {

                DatabaseHelper oDatabaseHelper = (pDatabaseHelper == null) ? new DatabaseHelper() : pDatabaseHelper;

                try
                {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@idVenta", beVenta.IdVenta);
                    oDatabaseHelper.AddParameter("@idUsuario", beVenta.BEUsuarioLogin.IdPersonal);
                    
                    int vResultado = oDatabaseHelper.ExecuteNonQuery("DGP_AnularAmortizacionesVenta", CommandType.StoredProcedure, (pDatabaseHelper == null) ? DBHelper.ConnectionState.CloseOnExit : DBHelper.ConnectionState.KeepOpen);

                    return (true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {

                    if (pDatabaseHelper == null) oDatabaseHelper.Dispose();
                }


            }
            
            public decimal ObtenerAmortizacionSinAplicar(int IdCliente)
            {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                object vResultado ;
                try
                {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@IdCliente", IdCliente);
                    vResultado = oDatabaseHelper.ExecuteScalar("DGP_ObtenerAmortizacionSinAplicar", CommandType.StoredProcedure, DBHelper.ConnectionState.CloseOnExit);
                    decimal result = 0;
                    decimal.TryParse(vResultado.ToString(), out result);

                    return result;
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