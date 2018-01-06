using System;
using System.Collections.Generic;
using System.Text;

using DGP.Entities;
using DGP.DataAccess;

namespace DGP.BusinessLogic {

    public class BLEmpresa {

        #region "Métodos de BLEmpresa"

            public List<BEEmpresa> Listar(BEEmpresa pBEEmpresa) {
                try {
                    return new DAEmpresa().Listar(pBEEmpresa);
                } catch (Exception ex) {
                    throw ex;
                }
            }

        #endregion

    }
}