using System;
using System.Collections.Generic;
using System.Text;

using DGP.Entities;
using DGP.DataAccess;

namespace DGP.BusinessLogic {

    public class BLParametroDetalle {

        #region "Métodos de BLParametroDetalle"

            public List<BEParametroDetalle> Listar(BEParametroDetalle pBEParametroDetalle) {
                try {
                    return new DAParametroDetalle().Listar(pBEParametroDetalle);
                } catch (Exception ex) {
                    throw ex;
                }
            }

        #endregion

    }
}