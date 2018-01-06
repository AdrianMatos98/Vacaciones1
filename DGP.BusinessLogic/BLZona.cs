using System;
using System.Collections.Generic;
using System.Text;

using DGP.Entities.Seguridad;
using DGP.Entities;
using DGP.DataAccess;

namespace DGP.BusinessLogic {

    public class BLZona {

        #region "Métodos de BLZona"
        
            public List<BEZona> Listar(BEZona pBEZona) {
                try {
                    return new DAZona().Listar(pBEZona);
                } catch (Exception ex) {
                    throw ex;
                }
            }

        #endregion

    }
}