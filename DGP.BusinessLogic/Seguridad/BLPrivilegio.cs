using System;
using System.Collections.Generic;
using System.Text;


using System.Collections.Generic;
using DGP.DataAccess.Seguridad;
using DGP.Entities.Seguridad;

namespace DGP.BusinessLogic.Seguridad
{
    public class BLPrivilegio
    {
        public List<BEPrivilegio> ObtenerPrivilegios(string pLogin)
        {
            try
            {
                return new DAPrivilegio().ObtenerPrivilegios(pLogin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
