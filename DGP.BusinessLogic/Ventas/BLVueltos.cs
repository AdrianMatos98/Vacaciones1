using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DGP.Entities;
using DGP.DataAccess.Ventas;
using DGP.Entities.DataSet;

namespace DGP.BusinessLogic.Ventas
{
    public class BLVueltos
    {
        public DSVueltos ListarVueltos(BEClienteProveedor beClienteProveedor)
        {
            return new DALVuelto().ListarVueltos(beClienteProveedor);
        }
        public bool AplicarVueltos(List<int> idVueltos, List<int> idSaldos, bool AplicarVuelto, int IdUsuario, int IdCaja)
        {
            return new DALVuelto().AplicarVueltos(idVueltos, idSaldos, AplicarVuelto, IdUsuario , IdCaja);
        }
    }
}
