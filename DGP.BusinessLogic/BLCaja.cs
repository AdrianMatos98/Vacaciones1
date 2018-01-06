using System;
using System.Collections.Generic;
using System.Text;

using DGP.DataAccess;
using DGP.Entities;

namespace DGP.BusinessLogic {
    
    public class BLCaja {

        #region "Métodos de BLCaja"
        public BECaja CrearCaja(BECaja pBECaja)
        {
            try
            {
                return new DACaja().CrearCaja(pBECaja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public BECaja ObtenerCajaAbierta(BECaja pBECaja)
        {
            try
            {
                return new DACaja().ObtenerCajaAbierta(pBECaja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            public List<BECaja> Listar(BECaja pBECaja) {
                try {
                    return new DACaja().Listar(pBECaja);
                } catch (Exception ex) {
                    throw ex;
                }
            }

            public int Insertar(BECaja pBECaja) {
                try {
                    return new DACaja().Insertar(pBECaja);
                } catch (Exception ex) {
                    throw ex;
                }
            }

        #endregion

    }
}