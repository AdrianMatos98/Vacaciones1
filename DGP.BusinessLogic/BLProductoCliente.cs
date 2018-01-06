using System;
using System.Text;

using System.Collections.Generic;
using DGP.DataAccess;
using DGP.Entities;

namespace DGP.BusinessLogic {

    public class BLProductoCliente {

        #region "Métodos de BLProductoCliente"

        public int cambioPrecioMasivo(BEProductoCliente pBEProductoCliente, bool bAplicaClientes)
        {

            return new DAProductoCliente().cambioPrecioMasivo(pBEProductoCliente, bAplicaClientes);
        }
        public int cambioPrecioProveedor(BEProductoCliente pBEProductoCliente)
        {

            return new DAProductoCliente().cambioPrecioProveedor(pBEProductoCliente);
        }
        public decimal ObtenerTara(BEProductoCliente pBEProductoCliente) {
                try {
                    return new DAProductoCliente().ObtenerTara(pBEProductoCliente);
                } catch (Exception ex) {
                    throw ex;
                }
       }

       public decimal ObtenerPrecioVenta(BEProductoCliente pBEProductoCliente) {
                try {
                    return new DAProductoCliente().ObtenerPrecioVenta(pBEProductoCliente);
                } catch (Exception ex) {
                    throw ex;
                }
            }

            //public List<BEProductoCliente> Listar(BEProductoCliente pBEProductoCliente) {
            //    try {
            //        return new DAProductoCliente().Listar(pBEProductoCliente);
            //    } catch (Exception ex) {
            //        throw ex;
            //    }
            //}

        #endregion

    }
}