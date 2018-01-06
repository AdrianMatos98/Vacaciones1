using System;
using System.Collections.Generic;
using System.Text;
using DBHelper;
using System.Data;
using DGP.Entities.Seguridad;

namespace DGP.DataAccess.Seguridad
{
    public class DAPrivilegio
    {
        public List<BEPrivilegio> ObtenerPrivilegios(string pLogin)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            IDataReader oIDataReader = null;
            BEPrivilegio oBEPrivilegio = null;
            List<BEPrivilegio> result = new List<BEPrivilegio>();
            try
            {
                oDatabaseHelper.ClearParameter();
                oDatabaseHelper.AddParameter("@LoginUsuario", pLogin);

                oIDataReader = oDatabaseHelper.ExecuteReader("obtener_Privilegios_usuario", CommandType.StoredProcedure);

                while (oIDataReader.Read())
                {
                    oBEPrivilegio = new BEPrivilegio();
                    oBEPrivilegio.IdPrivilegio = int.Parse(oIDataReader["Id"].ToString());
                    oBEPrivilegio.Descripcion = oIDataReader["Descripcion"].ToString();
                    oBEPrivilegio.Padre = (oIDataReader["id_privilegio_padre"] == DBNull.Value) ? null : new BEPrivilegio(int.Parse(oIDataReader["id_privilegio_padre"].ToString()), oIDataReader["descripcion_padre"].ToString());

                    result.Add(oBEPrivilegio);
                }
                return result;
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
