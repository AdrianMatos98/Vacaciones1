using System;
using System.Collections.Generic;
using System.Text;
using DGP.DataAccess.Seguridad;
using DGP.Entities.Seguridad;

namespace DGP.BusinessLogic.Seguridad
{
    public class BLPerfil
    {
        public List<BEPerfil> ListarPerfil(BEPerfil pBEPerfil)
        {
            try
            {
                return new DAPerfil().ListarPerfil(pBEPerfil);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
