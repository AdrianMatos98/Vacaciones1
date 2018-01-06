using System;
using System.Text;

using DGP.Entities.Seguridad;
using System.Collections.Generic;
using DBHelper;
using System.Data;

namespace DGP.DataAccess.Seguridad {

    public class DAPersonal {

        #region "Métodos de DAPersonal"

            public BEPersonal ObtenerPersonal(string pLogin, string pClave) {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                IDataReader oIDataReader = null;
                BEPersonal oBEPersonal = null;
                try {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@varLogin", pLogin);
                    oDatabaseHelper.AddParameter("@varClave", pClave);

                    oIDataReader = oDatabaseHelper.ExecuteReader("DGP_Obtener_Personal", CommandType.StoredProcedure);

                    if (oIDataReader.Read()) {
                        oBEPersonal = new BEPersonal();
                        oBEPersonal.IdPersonal = int.Parse(oIDataReader["Id_Personal"].ToString());
                        oBEPersonal.Nombre = oIDataReader["Nombre"].ToString();
                        oBEPersonal.Direccion = oIDataReader["Direccion"].ToString();
                        oBEPersonal.DNI = oIDataReader["Dni"].ToString();
                    }
                    return oBEPersonal;
                } catch (Exception ex) {
                    throw ex;
                } finally {
                    if (!oIDataReader.IsClosed) oIDataReader.Close();
                    oIDataReader.Dispose();
                    oDatabaseHelper.Dispose();
                }
            }

            public List<BEPersonal> ListarPersonal(BEPersonal pBEPersonal ) {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                List<BEPersonal> vLista = new List<BEPersonal>();
                IDataReader oIDataReader = null;
                BEPersonal oBEPersonal = null;
                try {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@intIdPersonal", (pBEPersonal.IdPersonal <= 0) ? (object)DBNull.Value : pBEPersonal.IdPersonal);
                    oDatabaseHelper.AddParameter("@varNombre", string.IsNullOrEmpty(pBEPersonal.Nombre) ? (object)DBNull.Value : pBEPersonal.Nombre);
                    oDatabaseHelper.AddParameter("@chrDNI", string.IsNullOrEmpty(pBEPersonal.DNI) ? (object)DBNull.Value : pBEPersonal.DNI);
                    oDatabaseHelper.AddParameter("@varLogin", string.IsNullOrEmpty(pBEPersonal.Login) ? (object)DBNull.Value : pBEPersonal.Login);

                    oIDataReader = oDatabaseHelper.ExecuteReader("DGP_Listar_Personal", CommandType.StoredProcedure);

                    while (oIDataReader.Read()) {
                        oBEPersonal = new BEPersonal();
                        oBEPersonal.IdPersonal = int.Parse(oIDataReader["Id_Personal"].ToString());
                        oBEPersonal.Nombre = oIDataReader["Nombre"].ToString();
                        oBEPersonal.Direccion = oIDataReader["Direccion"].ToString();
                        oBEPersonal.DNI = oIDataReader["Dni"].ToString();
                        oBEPersonal.Login = oIDataReader["Login"].ToString();
                        vLista.Add(oBEPersonal);
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