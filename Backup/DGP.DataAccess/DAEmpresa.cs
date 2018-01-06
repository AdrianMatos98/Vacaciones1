using System;
using System.Collections.Generic;
using System.Text;

using DBHelper;
using DGP.Entities.Seguridad;
using DGP.Entities;
using System.Data;

namespace DGP.DataAccess {

    public class DAEmpresa {
      
        #region "Métodos de DAEmpresa"

            public List<BEEmpresa> Listar(BEEmpresa pBEEmpresa) {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                List<BEEmpresa> vLista = new List<BEEmpresa>();
                IDataReader oIDataReader = null;
                BEEmpresa oBEEmpresa = null;
                try {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@intIdEmpresa", (pBEEmpresa.IdEmpresa <= 0) ? (object)DBNull.Value : pBEEmpresa.IdEmpresa);
                    oDatabaseHelper.AddParameter("@varRazonSocial", string.IsNullOrEmpty(pBEEmpresa.RazonSocial) ? (object)DBNull.Value : pBEEmpresa.RazonSocial);

                    oIDataReader = oDatabaseHelper.ExecuteReader("DGP_Listar_Empresa", CommandType.StoredProcedure);

                    while (oIDataReader.Read()) {
                        oBEEmpresa = new BEEmpresa();
                        oBEEmpresa.IdEmpresa = oIDataReader.GetInt32(0);
                        oBEEmpresa.RazonSocial = oIDataReader.GetString(1);
                        oBEEmpresa.RUC = oIDataReader.GetString(2);
                        oBEEmpresa.DireccionFiscal = oIDataReader.GetString(3);
                        vLista.Add(oBEEmpresa);
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