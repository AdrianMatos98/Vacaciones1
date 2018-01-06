using System;
using System.Collections.Generic;
using System.Text;

using DGP.Entities;
using DBHelper;
using System.Data;

namespace DGP.DataAccess {

    public class DAProductoCliente {

        #region "Métodos de DAProductoCliente"

        public int cambioPrecioMasivo(BEProductoCliente pBEProductoCliente , bool bAplicaClientes )
        {
            DatabaseHelper pDatabaseHelper = new DatabaseHelper();
            int vResultado = 0;
            try
            {
                pDatabaseHelper.ClearParameter();
                pDatabaseHelper.AddParameter("@intProducto", pBEProductoCliente.IdProducto);
                pDatabaseHelper.AddParameter("@decPrecioCompra", pBEProductoCliente.PrecioCompra);
                pDatabaseHelper.AddParameter("@decMargendefault", pBEProductoCliente.Margen);
                pDatabaseHelper.AddParameter("@bolAplicaMasivo", bAplicaClientes.GetHashCode() );
                pDatabaseHelper.AddParameter("@intUsuario", pBEProductoCliente.BEUsuarioLogin.IdPersonal);
                vResultado = pDatabaseHelper.ExecuteNonQuery("DGP_ActualizacionMAsivoCliente", CommandType.StoredProcedure, DBHelper.ConnectionState.CloseOnExit);
                return vResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pDatabaseHelper.Dispose();
            }  
        
        
        }
        public int cambioPrecioProveedor(BEProductoCliente pBEProductoCliente)
        {
            DatabaseHelper pDatabaseHelper = new DatabaseHelper();
            int vResultado = 0;
            try
            {
                pDatabaseHelper.ClearParameter();
                pDatabaseHelper.AddParameter("@Id_Producto", pBEProductoCliente.IdProducto);
                pDatabaseHelper.AddParameter("@Id_Cliente", pBEProductoCliente.IdCliente);
                pDatabaseHelper.AddParameter("@PrecioVenta", pBEProductoCliente.PrecioVenta);
                pDatabaseHelper.AddParameter("@UsuarioModificacion", pBEProductoCliente.BEUsuarioLogin.IdPersonal);
                vResultado = pDatabaseHelper.ExecuteNonQuery("DGP_ActualizaProductoCliente", CommandType.StoredProcedure, DBHelper.ConnectionState.CloseOnExit);
                return vResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pDatabaseHelper.Dispose();
            }


        }

            public decimal ObtenerTara(BEProductoCliente pBEProductoCliente) {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                decimal decTara = decimal.Zero;
                IDataReader oIDataReader = null;
                try {
                    oDatabaseHelper.ClearParameter();
                    string strFormat = "SELECT dbo.DGP_Obtener_TaraCliente({0}, {1})";
                    oIDataReader = oDatabaseHelper.ExecuteReader(string.Format(strFormat, pBEProductoCliente.IdCliente, pBEProductoCliente.IdProducto), CommandType.Text);
                    if (oIDataReader.Read()) {
                        decTara = oIDataReader.GetDecimal(0);
                    }
                    return decTara;
                } catch (Exception ex) {
                    throw ex;
                } finally {
                    if (!oIDataReader.IsClosed) oIDataReader.Close();
                    oIDataReader.Dispose();
                    oDatabaseHelper.Dispose();
                }
            }

            public decimal ObtenerPrecioVenta(BEProductoCliente pBEProductoCliente) {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                decimal decTara = decimal.Zero;
                IDataReader oIDataReader = null;
                try {
                    oDatabaseHelper.ClearParameter();
                    string strFormat = "SELECT dbo.DGP_Obtener_PrecioVentaCliente({0}, {1})";
                    oIDataReader = oDatabaseHelper.ExecuteReader(string.Format(strFormat, pBEProductoCliente.IdCliente, pBEProductoCliente.IdProducto), CommandType.Text);
                    if (oIDataReader.Read()) {
                        decTara = oIDataReader.GetDecimal(0);
                    }
                    return decTara;
                } catch (Exception ex) {
                    throw ex;
                } finally {
                    if (!oIDataReader.IsClosed) oIDataReader.Close();
                    oIDataReader.Dispose();
                    oDatabaseHelper.Dispose();
                }
            }

            //public List<BEProductoCliente> Listar(BEProductoCliente pBEProductoCliente) {
            //    DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            //    IDataReader oIDataReader = null;
            //    List<BEProductoCliente> vLista = new List<BEProductoCliente>();
            //    BEProductoCliente oBEProductoCliente = null;
            //    try {
            //        oDatabaseHelper.ClearParameter();
            //        oDatabaseHelper.AddParameter("@intIdProductoCliente", (pBEProductoCliente.IdProductoCliente <= 0) ? (object)DBNull.Value : pBEProductoCliente.IdProductoCliente);
            //        oDatabaseHelper.AddParameter("@intIdCliente", (pBEProductoCliente.IdCliente <= 0) ? (object)DBNull.Value : pBEProductoCliente.IdCliente);
            //        oDatabaseHelper.AddParameter("@intIdProducto", (pBEProductoCliente.IdProducto <= 0) ? (object)DBNull.Value : pBEProductoCliente.IdProducto);
            //        oIDataReader = oDatabaseHelper.ExecuteReader("DGP_Listar_ClienteProducto", CommandType.StoredProcedure);

            //        while (oIDataReader.Read()) {
            //            oBEProductoCliente = new BEProductoCliente();
            //            oBEProductoCliente.IdProductoCliente = Convert.ToInt32(oIDataReader["Id_ProductoCliente"]);
            //            oBEProductoCliente.Tara = Convert.ToDecimal(oIDataReader["Tara"]);
            //            oBEProductoCliente.Margen = Convert.ToDecimal(oIDataReader["Margen"]);
            //            oBEProductoCliente.PrecioVenta = Convert.ToDecimal(oIDataReader["PrecioVenta"]);
            //            oBEProductoCliente.PrecioCompra = Convert.ToDecimal(oIDataReader["PrecioCompra"]);
            //            oBEProductoCliente.IdCliente = Convert.ToInt32(oIDataReader["Id_Cliente"]);
            //            oBEProductoCliente.IdProducto = Convert.ToInt32(oIDataReader["Id_Producto"]);
            //            oBEProductoCliente.Producto = oIDataReader["Producto"].ToString();
            //            vLista.Add(oBEProductoCliente);
            //        }
            //        return vLista;
            //    }catch (Exception ex) {
            //        throw ex;
            //    } finally {
            //        if (!oIDataReader.IsClosed) oIDataReader.Close();
            //        oIDataReader.Dispose();
            //        oDatabaseHelper.Dispose();
            //    }
            //}

        #endregion

    }
}