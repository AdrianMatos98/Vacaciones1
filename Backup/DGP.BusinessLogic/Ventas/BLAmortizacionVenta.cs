using System;
using System.Text;

using System.Collections.Generic;
using DGP.DataAccess.Ventas;
using DBHelper;
using DGP.Entities.Ventas;

namespace DGP.BusinessLogic.Ventas {

    public class BLAmortizacionVenta {

        #region "Métodos de BLAmortizacionVenta"

            public int InsertarAdelantoVenta(BEAmortizacionVenta pBEAmortizacionVenta) {
                try {
                    return new DAAmortizacionVenta().InsertarAdelantoVenta(pBEAmortizacionVenta);
	            } catch (Exception ex) {
		            throw ex;
	            }
            }

            public List<VistaAmortizacion> Listar(VistaAmortizacion pVistaAmortizacion) {
                try {
                    return new DAAmortizacionVenta().Listar(pVistaAmortizacion);
                } catch (Exception ex) {
                    throw ex;
                }
            }

        
        public int Insertar(List<BEAmortizacionVenta> pLista )
        {
            try
            {
                return Insertar(pLista, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insertar(List<BEAmortizacionVenta> pLista, DBHelper.DatabaseHelper pDatabaseHelper )
        {
                int intResultado = 0;
                DatabaseHelper oDatabaseHelper = (pDatabaseHelper == null) ? new DatabaseHelper() : pDatabaseHelper;
                try {
                    int intCantidad = 0;
                    int intTotal = pLista.Count * 2;
                    if (pDatabaseHelper == null) oDatabaseHelper.BeginTransaction();
                    foreach (BEAmortizacionVenta oEntidad in pLista) {
                        intCantidad += new DAAmortizacionVenta().InsertarDependiente(oEntidad, oDatabaseHelper);
                        BEVenta oBEVenta = new BEVenta();
                        oBEVenta.IdVenta = oEntidad.IdVenta;
                        oBEVenta.BEUsuarioLogin = oEntidad.BEUsuarioLogin;
                        intCantidad += new DAVenta().InsertarVentaFinal(oBEVenta, oDatabaseHelper);
                        // Opcional
                        int intTemporal = new DAVenta().ActualizarEstado(oBEVenta.IdVenta, oDatabaseHelper, oEntidad.CancelarVenta);
                    }
                    intResultado += (intCantidad == intTotal) ? 1 : 0;
                    //
                    if (intResultado == 1) {
                        if (pDatabaseHelper == null)  oDatabaseHelper.CommitTransaction();
                    } else {
                        if (pDatabaseHelper == null) oDatabaseHelper.RollbackTransaction();
                        else throw new Exception("Error al registrar Amortización");
                    }
                    return intResultado;
                } catch (Exception ex) {
                    if (pDatabaseHelper == null)  oDatabaseHelper.RollbackTransaction();
                    throw ex;
                } finally {
                    if (pDatabaseHelper == null) oDatabaseHelper.Dispose();
                }
            }

        public int EliminarAdelantoVenta(BEAmortizacionVenta pBEAmortizacionVenta)
        {

            return new DAAmortizacionVenta().EliminarAdelantoVenta(pBEAmortizacionVenta);
        
        }

        #endregion

    }
}