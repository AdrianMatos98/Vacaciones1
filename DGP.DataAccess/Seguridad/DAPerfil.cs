using System;
using System.Collections.Generic;
using System.Text;

using DBHelper;
using System.Data;
using DGP.Entities.Seguridad;

namespace DGP.DataAccess.Seguridad
{
    public class DAPerfil
    {
        public List<BEPerfil> ListarPerfil(BEPerfil pBEPerfil)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            List<BEPerfil> vLista = new List<BEPerfil>();
            IDataReader oIDataReader = null;
            BEPerfil oBEPerfil = null;
            try
            {
                oDatabaseHelper.ClearParameter();

                oDatabaseHelper.AddParameter("@id", (pBEPerfil.Id <= 0) ? (object)DBNull.Value : pBEPerfil.Id);
                oDatabaseHelper.AddParameter("@descripcion", string.IsNullOrEmpty(pBEPerfil.Descripcion) ? (object)DBNull.Value : pBEPerfil.Descripcion);

                oIDataReader = oDatabaseHelper.ExecuteReader("Perfil_List", CommandType.StoredProcedure);


                while (oIDataReader.Read())
                {
                    oBEPerfil = new BEPerfil();
                    oBEPerfil.Id = int.Parse(oIDataReader["Id"].ToString());
                    oBEPerfil.Descripcion = oIDataReader["descripcion"].ToString();
                    
                    vLista.Add(oBEPerfil);
                }
                return vLista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!oIDataReader.IsClosed) oIDataReader.Close();
                oIDataReader.Dispose();
                oDatabaseHelper.Dispose();
            }
        }

    }
}
