using System;
using System.Collections.Generic;
using System.Text;

using DBHelper;
using DGP.Entities.Seguridad;
using DGP.Entities;
using System.Data;

namespace DGP.DataAccess {

    public class DAZona {

        #region "Métodos de DAZona"
        
            public List<BEZona> Listar(BEZona pBEZona) {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                List<BEZona> vLista = new List<BEZona>();
                IDataReader oIDataReader = null;
                BEZona oBEZona = null;
                try {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@intIdZona", (pBEZona.IdZona <= 0) ? (object)DBNull.Value : pBEZona.IdZona );
                    oDatabaseHelper.AddParameter("@varDescripcion", string.IsNullOrEmpty(pBEZona.Descripcion) ? (object)DBNull.Value : pBEZona.Descripcion);

                    oIDataReader = oDatabaseHelper.ExecuteReader("DGP_Listar_Zona", CommandType.StoredProcedure);

                    while (oIDataReader.Read()) {
                        oBEZona = new BEZona();
                        oBEZona.IdZona = oIDataReader.GetInt32(0);
                        oBEZona.Descripcion = oIDataReader.GetString(1);
                        vLista.Add(oBEZona);
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