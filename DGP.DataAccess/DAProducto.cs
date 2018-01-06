using System;
using System.Collections.Generic;
using System.Text;

using DGP.Entities;
using DBHelper;
using System.Data;

namespace DGP.DataAccess {

    public class DAProducto {

        #region "Métodos de DAProducto"

            public List<BEProducto> Listar(BEProducto pBEProducto) {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                List<BEProducto> vLista = new List<BEProducto>();
                IDataReader oIDataReader = null;
                BEProducto oBEProducto = null;
                try {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@intIdProducto", (pBEProducto.IdProducto <= 0) ? (object)DBNull.Value : pBEProducto.IdProducto);
                    oDatabaseHelper.AddParameter("@varNombre", string.IsNullOrEmpty(pBEProducto.Nombre) ? (object)DBNull.Value : pBEProducto.Nombre);

                    oIDataReader = oDatabaseHelper.ExecuteReader("DGP_Listar_Producto", CommandType.StoredProcedure);

                    while (oIDataReader.Read()) {
                        oBEProducto = new BEProducto();
                        oBEProducto.IdProducto =int.Parse( oIDataReader["Id_Producto"].ToString()); //.GetInt32(0);
                        oBEProducto.Nombre =(string) oIDataReader["Nombre"];//.GetString(1);
                        oBEProducto.Tara = decimal.Parse(oIDataReader["tara"].ToString());//oIDataReader.GetDecimal(2);
                        oBEProducto.PrecioVenta = decimal.Parse(oIDataReader["PrecioVenta"].ToString());
                        oBEProducto.PrecioCompra = decimal.Parse(oIDataReader["PrecioCompra"].ToString());
                        oBEProducto.Margen = decimal.Parse(oIDataReader["Margen"].ToString());

                       vLista.Add(oBEProducto);
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