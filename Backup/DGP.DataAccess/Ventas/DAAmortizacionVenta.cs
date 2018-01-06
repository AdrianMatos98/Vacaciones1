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

            public int InsertarDependiente(BEAmortizacionVenta pBEAmortizacionVenta, DatabaseHelper pDatabaseHelper) {
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
                    
                    vResultado = pDatabaseHelper.ExecuteNonQuery("DGP_Insertar_AmortizacionVenta", CommandType.StoredProcedure, DBHelper.ConnectionState.KeepOpen);
                    return vResultado;
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

    }
}