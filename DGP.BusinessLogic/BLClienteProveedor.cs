using System;
using System.Collections.Generic;
using System.Text;

using DGP.DataAccess;
using DGP.Entities;

namespace DGP.BusinessLogic {

    public class BLClienteProveedor {

        #region "Métodos de BLClienteProveedor"

            public List<BEClienteProveedor> Listar(BEClienteProveedor pBEClienteProveedor) {
                try {
                    return new DAClienteProveedor().Listar(pBEClienteProveedor);
                } catch (Exception ex) {
                    throw ex;
                }
            }
        public bool obtenerMontos(int idCaja, int IdCliente, out double montoCongelado , out double montoAnterior, out double montoDia)
        {
            montoCongelado = 0;
            montoAnterior = 0;
            montoDia = 0;
            try
            {

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        
        
        }

        #endregion

    }
}