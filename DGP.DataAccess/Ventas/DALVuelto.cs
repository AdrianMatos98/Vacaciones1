using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DGP.Entities;
using DGP.Entities.DataSet;
using DGP.DataAccess;
using DBHelper;
namespace DGP.DataAccess.Ventas
{
    public class DALVuelto
    {
        public DSVueltos ListarVueltos(BEClienteProveedor beClienteProveedor)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            DSVueltos oDSVueltos = new DSVueltos();

            try
            {
                oDatabaseHelper.ClearParameter();
                oDatabaseHelper.AddParameter("@idCliente", beClienteProveedor.IdCliente);
                
                DataSet ds = oDatabaseHelper.ExecuteDataSet("DGP_List_Vueltos", CommandType.StoredProcedure);

                oDSVueltos.DTVuelto.Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                oDSVueltos.DTSaldos.Merge(ds.Tables[1], true, MissingSchemaAction.Ignore);

                return oDSVueltos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDatabaseHelper.Dispose();
            }
        }

        public bool AplicarVueltos(List<int> idVueltos, List<int> idSaldos, bool AplicarVuelto, int IdUsuario , int IdCaja)
        {

            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            string[] arrayVueltos = idVueltos.ConvertAll( x => x.ToString() ).ToArray();
            string[] arraySaldos = idSaldos.ConvertAll(x => x.ToString()).ToArray();
            
            try
            {
                oDatabaseHelper.ClearParameter();

                oDatabaseHelper.AddParameter("@idVentasVueltos", string.Join(",", arrayVueltos) );//string.Join(",", idVueltos.ConvertAll(i => i.ToString()).ToArray());
                oDatabaseHelper.AddParameter("@aplicarVuelto", AplicarVuelto);
                oDatabaseHelper.AddParameter("@idUsuario", IdUsuario);
                oDatabaseHelper.AddParameter("@IdCaja", IdCaja);
                oDatabaseHelper.AddParameter("@idVentaSaldos", string.Join(",", arraySaldos));

                int  result = oDatabaseHelper.ExecuteNonQuery("DGP_Aplicar_Vueltos", CommandType.StoredProcedure);

                return (result>0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDatabaseHelper.Dispose();
            }
 
        
        
        
        }

    }
}
