using System;
using System.Collections.Generic;
using System.Text;

using DBHelper;
using DGP.Entities.Seguridad;
using DGP.Entities;
using System.Data;

namespace DGP.DataAccess {

    public class DAClienteProveedor {

        #region "Métodos de DAClienteProveedor"

            public List<BEClienteProveedor> Listar(BEClienteProveedor pBEClienteProveedor) {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                List<BEClienteProveedor> vLista = new List<BEClienteProveedor>();
                IDataReader oIDataReader = null;
                BEClienteProveedor oBEClienteProveedor = null;
                try {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@intIdCliente", (pBEClienteProveedor.IdCliente <= 0) ? (object)DBNull.Value : pBEClienteProveedor.IdCliente);
                    oDatabaseHelper.AddParameter("@varNombres", string.IsNullOrEmpty(pBEClienteProveedor.Nombre) ? (object)DBNull.Value : pBEClienteProveedor.Nombre);
                    oDatabaseHelper.AddParameter("@varTipoCliente", string.IsNullOrEmpty(pBEClienteProveedor.TipoCliente) ? (object)DBNull.Value : pBEClienteProveedor.TipoCliente);
                    oDatabaseHelper.AddParameter("@varRazonSocial", string.IsNullOrEmpty(pBEClienteProveedor.RazonSocial) ? (object)DBNull.Value : pBEClienteProveedor.RazonSocial);
                    oDatabaseHelper.AddParameter("@varTipoDocumento", string.IsNullOrEmpty(pBEClienteProveedor.TipoDocumento) ? (object)DBNull.Value : pBEClienteProveedor.TipoDocumento);
                    oDatabaseHelper.AddParameter("@varNumDocumento", string.IsNullOrEmpty(pBEClienteProveedor.NumDocumento) ? (object)DBNull.Value : pBEClienteProveedor.NumDocumento);
                    oDatabaseHelper.AddParameter("@intIdZona", (pBEClienteProveedor.IdZona <= 0) ? (object)DBNull.Value : pBEClienteProveedor.IdZona);

                    oIDataReader = oDatabaseHelper.ExecuteReader("DGP_Listar_ClienteProveedor", CommandType.StoredProcedure);

                    while (oIDataReader.Read()) {
                        oBEClienteProveedor = new BEClienteProveedor();
                        oBEClienteProveedor.IdCliente = oIDataReader.GetInt32(0);
                        oBEClienteProveedor.Nombre = oIDataReader.GetString(1);
                        oBEClienteProveedor.TipoCliente = oIDataReader.GetString(2);
                        oBEClienteProveedor.RazonSocial = oIDataReader.IsDBNull(3)?string.Empty: oIDataReader.GetString(3);
                        oBEClienteProveedor.TipoDocumento = oIDataReader.GetString(4);
                        oBEClienteProveedor.NumDocumento = oIDataReader.IsDBNull(5) ? string.Empty : oIDataReader.GetString(5);
                        oBEClienteProveedor.Estado = oIDataReader.GetInt32(6);
                        oBEClienteProveedor.IdZona = oIDataReader.GetInt32(7);
                        oBEClienteProveedor.DescripcionZona = oIDataReader.GetString(8);
                        vLista.Add(oBEClienteProveedor);
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

        //public decimal ObtenerMontos(int IdCliente, int idCaja)
        //{
        //    DatabaseHelper oDatabaseHelper = new DatabaseHelper();
        //    decimal decTara = decimal.Zero;
        //    IDataReader oIDataReader = null;
        //    try
        //    {
        //        oDatabaseHelper.ClearParameter();
        //        string strFormat = "SELECT dbo.DGP_Obtener_TaraCliente({0}, {1})";
        //       // oIDataReader = oDatabaseHelper.ExecuteReader(string.Format(strFormat, pBEProductoCliente.IdCliente, pBEProductoCliente.IdProducto), CommandType.Text);
        //        oIDataReader = oDatabaseHelper.ExecuteReader(string.Format(strFormat, IdCliente, IdProducto), CommandType.Text);
            
        //        if (oIDataReader.Read())
        //        {
        //            decTara = oIDataReader.GetDecimal(0);
        //        }
        //        return decTara;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (!oIDataReader.IsClosed) oIDataReader.Close();
        //        oIDataReader.Dispose();
        //        oDatabaseHelper.Dispose();
        //    }
        //}


        #endregion

    }
}