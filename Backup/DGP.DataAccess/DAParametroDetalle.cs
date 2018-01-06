using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using DGP.Entities;
using DBHelper;

namespace DGP.DataAccess {

    public class DAParametroDetalle {

        #region "Métodos de DAParametroDetalle"

            public List<BEParametroDetalle> Listar(BEParametroDetalle pBEParametroDetalle) {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                List<BEParametroDetalle> vLista = new List<BEParametroDetalle>();
                IDataReader oIDataReader = null;
                BEParametroDetalle oBEParametroDetalle = null;
                try {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@intIdParametro", (pBEParametroDetalle.IdParametro <= 0) ? (object)DBNull.Value : pBEParametroDetalle.IdParametro);
                    
                    oIDataReader = oDatabaseHelper.ExecuteReader("DGP_Listar_DetalleMaestra", CommandType.StoredProcedure);

                    while (oIDataReader.Read()) {
                        oBEParametroDetalle = new BEParametroDetalle();
                        oBEParametroDetalle.IdItem = Convert.ToInt32(oIDataReader["Id_Item"]);
                        oBEParametroDetalle.IdParametro = Convert.ToInt32(oIDataReader["Id_Parametro"]);
                        oBEParametroDetalle.Valor = oIDataReader["Valor"].ToString();
                        oBEParametroDetalle.Texto = oIDataReader["Texto"].ToString();
                        vLista.Add(oBEParametroDetalle);
                    }

                    return vLista;

                } catch (Exception ex) {
                    throw ex;
                } finally {
                    if (!oIDataReader.IsClosed) oIDataReader.Close();
                    oIDataReader.Dispose();
                    oDatabaseHelper.Dispose();
                }
            }

        #endregion
    }
}
