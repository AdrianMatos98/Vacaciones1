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

        
        public bool Insertar( BEDocumento beDocumento  )
        {
            try
            {
                return Insertar(beDocumento, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(BEDocumento beDocumento , DBHelper.DatabaseHelper pDatabaseHelper )
        {
                DatabaseHelper oDatabaseHelper = (pDatabaseHelper == null) ? new DatabaseHelper() : pDatabaseHelper;
                DAAmortizacionVenta DAVenta = new DAAmortizacionVenta();
                bool bOk = true;
                try {
                    if (pDatabaseHelper == null) oDatabaseHelper.BeginTransaction();

                    bOk = DAVenta.InsertarCabeceraDocumento(beDocumento, oDatabaseHelper);
                    
                    foreach (BEAmortizacionVenta oEntidad in beDocumento.delleAmortizacion)
                    {

                        bOk = bOk && new DAAmortizacionVenta().InsertarDependiente(beDocumento , oEntidad, oDatabaseHelper);
                        BEVenta oBEVenta = new BEVenta(){
                                                            IdVenta=oEntidad.IdVenta,
                                                            BEUsuarioLogin=oEntidad.BEUsuarioLogin
                                                        };

                        bOk = bOk && (new DAVenta().InsertarVentaFinal(oBEVenta, oDatabaseHelper)> 0 );

                        // Opcional
                        bOk = bOk &&(   new DAVenta().ActualizarEstado(oBEVenta.IdVenta, oDatabaseHelper, oEntidad.CancelarVenta)>0);
                    }
                    //
                    if (bOk)
                    {
                        if (pDatabaseHelper == null) oDatabaseHelper.CommitTransaction();
                    }
                    else
                    {
                        if (pDatabaseHelper == null) oDatabaseHelper.RollbackTransaction();
                        throw new Exception("Error al registrar Amortización");

                    }


                    return bOk;
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

        public bool ReaplicarAmortizacion(BEVenta beVenta)
        {
            return this.ReaplicarAmortizacion(beVenta, null);


        }
        public bool ReaplicarAmortizacion(BEVenta beVenta, DatabaseHelper pDatabaseHelper) {

            DatabaseHelper oDatabaseHelper = (pDatabaseHelper == null) ? new DatabaseHelper() : pDatabaseHelper;
            DAAmortizacionVenta DAVenta = new DAAmortizacionVenta();
            bool bOk = true;
            try
            {
                if (pDatabaseHelper == null) oDatabaseHelper.BeginTransaction();

                bOk = DAVenta.ReaplicarAmortizacion(beVenta, pDatabaseHelper);

                if (bOk)
                {
                    if (pDatabaseHelper == null) oDatabaseHelper.CommitTransaction();
                }
                else
                {
                    if (pDatabaseHelper == null) oDatabaseHelper.RollbackTransaction();
                    throw new Exception("Error al registrar Amortización");
                }


                return bOk;
            }
            catch (Exception ex)
            {
                if (pDatabaseHelper == null) oDatabaseHelper.RollbackTransaction();
                throw ex;
            }
            finally
            {
                if (pDatabaseHelper == null) oDatabaseHelper.Dispose();
            }
        
        
        
        }
        #endregion


        public decimal ObtenerAmortizacionSinAplicar(int IdCliente)
        {
            return new DAAmortizacionVenta().ObtenerAmortizacionSinAplicar(IdCliente);
        }
    }
}