using System;
using System.Text;

using System.Collections.Generic;
using DGP.DataAccess.Seguridad;
using DGP.Entities.Seguridad;

namespace DGP.BusinessLogic.Seguridad {

    public class BLPersonal {

        #region "Métodos de BLPersonal"

            public BEPersonal ObtenerPersonal(string pLogin, string pClave) {
                try {
                    return new DAPersonal().ObtenerPersonal(pLogin, pClave);
                } catch (Exception ex) {
                    throw ex;
                }
            }

            public List<BEPersonal> ListarPersonal(BEPersonal pBEPersonal) {
                try {
                    return new DAPersonal().ListarPersonal(pBEPersonal);
                } catch (Exception ex) {
                    throw ex;
                }
            }


        #endregion

    }
}