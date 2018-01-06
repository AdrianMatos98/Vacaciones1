using System;
using System.Collections.Generic;
using System.Text;

using DBHelper;
using DGP.Entities;
using System.Data;

namespace DGP.DataAccess {
    
    public class DACaja {

        #region "Métodos de DACaja"
        public BECaja CrearCaja(BECaja pBECaja)
        {
            List<BECaja> vLista = new List<BECaja>();
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            IDataReader oIDataReader = null;
            BECaja oBECaja = null;
            try
            {
                oDatabaseHelper.ClearParameter();
                oDatabaseHelper.AddParameter("@intIdCaja", pBECaja.IdCaja );
                oDatabaseHelper.AddParameter("@intIdPersonal", pBECaja.IdPersonal );
                oDatabaseHelper.AddParameter("@datFecha", pBECaja.Fecha );

                oIDataReader = oDatabaseHelper.ExecuteReader("DGP_Crear_Caja", CommandType.StoredProcedure);

                while (oIDataReader.Read())
                {
                    oBECaja = new BECaja();
                    oBECaja.IdCaja = int.Parse(oIDataReader["Id_Caja"].ToString());
                    oBECaja.Fecha = Convert.ToDateTime(oIDataReader["Fecha"]);
                    oBECaja.FechaInicio = Convert.ToDateTime(oIDataReader["FechaInicio"]);
                    //oBECaja.FechaFin = (oIDataReader["FechaFin"] == (object)DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(oIDataReader["FechaFin"]);
                    oBECaja.FechaFin = (oIDataReader["FechaFin"] == (object)DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(oIDataReader["FechaFin"]);

                    oBECaja.IdPersonal = int.Parse(oIDataReader["Id_Personal"].ToString());
                    vLista.Add(oBECaja);
                }
                if (vLista.Count > 1) throw new Exception("Existe mas de una caja abierta");

                return vLista[0];
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

        public BECaja ObtenerCajaAbierta(BECaja pBECaja)
        {
            List<BECaja> vLista = new List<BECaja>();
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            IDataReader oIDataReader = null;
            BECaja oBECaja = null;
            try
            {
                oDatabaseHelper.ClearParameter();
                //oDatabaseHelper.AddParameter("@intIdCaja", (pBECaja.IdCaja <= 0) ? (object)DBNull.Value : pBECaja.IdCaja);
                oDatabaseHelper.AddParameter("@intIdPersonal",  pBECaja.IdPersonal);
                //oDatabaseHelper.AddParameter("@datFecha", pBECaja.Fecha);

                oIDataReader = oDatabaseHelper.ExecuteReader("DGP_Listar_Caja_Abierta", CommandType.StoredProcedure);

                while (oIDataReader.Read())
                {
                    oBECaja = new BECaja();
                    oBECaja.IdCaja = int.Parse(oIDataReader["Id_Caja"].ToString());
                    oBECaja.Fecha = Convert.ToDateTime(oIDataReader["Fecha"]);
                    oBECaja.FechaInicio = Convert.ToDateTime(oIDataReader["FechaInicio"]);
                    //oBECaja.FechaFin = (oIDataReader["FechaFin"] == (object)DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(oIDataReader["FechaFin"]);
                    oBECaja.FechaFin = (oIDataReader["FechaFin"] == (object)DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(oIDataReader["FechaFin"]);

                    oBECaja.IdPersonal = int.Parse(oIDataReader["Id_Personal"].ToString());
                    vLista.Add(oBECaja);
                }
                if (vLista.Count > 1) throw new Exception("Existe mas de una caja abierta");

                return (vLista.Count>0) ? vLista[0] : null;
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

        public List<BECaja> Listar(BECaja pBECaja) {
                List<BECaja> vLista = new List<BECaja>();
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                IDataReader oIDataReader = null;
                BECaja oBECaja = null;
                try {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@intIdCaja", (pBECaja.IdCaja <= 0) ? (object)DBNull.Value : pBECaja.IdCaja);
                    oDatabaseHelper.AddParameter("@intIdPersonal", (pBECaja.IdPersonal <= 0) ? (object)DBNull.Value : pBECaja.IdPersonal);
                    oDatabaseHelper.AddParameter("@datFecha", (pBECaja.Fecha == DateTime.MinValue) ? (object)DBNull.Value : pBECaja.Fecha);

                    oIDataReader = oDatabaseHelper.ExecuteReader("DGP_Listar_Caja", CommandType.StoredProcedure);

                    while (oIDataReader.Read()) {
                        oBECaja = new BECaja();
                        oBECaja.IdCaja = int.Parse(oIDataReader["Id_Caja"].ToString());
                        oBECaja.Fecha = Convert.ToDateTime(oIDataReader["Fecha"]);
                        oBECaja.FechaInicio = Convert.ToDateTime(oIDataReader["FechaInicio"]);
                        //oBECaja.FechaFin = (oIDataReader["FechaFin"] == (object)DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(oIDataReader["FechaFin"]);
                        oBECaja.FechaFin = (oIDataReader["FechaFin"] == (object)DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(oIDataReader["FechaFin"]);
                        
                        oBECaja.IdPersonal = int.Parse(oIDataReader["Id_Personal"].ToString());
                        vLista.Add(oBECaja);
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

        public int Insertar(BECaja pBECaja) {
                DatabaseHelper pDatabaseHelper = new DatabaseHelper();
                int vResultado = 0;
                try {
                    pDatabaseHelper.ClearParameter();
                    pDatabaseHelper.AddParameter("@datFechaInicio", pBECaja.FechaInicio);
                    pDatabaseHelper.AddParameter("@datFechaFin", (pBECaja.FechaFin == DateTime.MinValue) ? (object)DBNull.Value : pBECaja.FechaFin);
                    pDatabaseHelper.AddParameter("@datFecha", pBECaja.Fecha);
                    pDatabaseHelper.AddParameter("@intIdPersonal", pBECaja.IdPersonal);
                    vResultado = pDatabaseHelper.ExecuteNonQuery("DGP_Insertar_Caja", CommandType.StoredProcedure, DBHelper.ConnectionState.CloseOnExit);
                    return vResultado;
                } catch (Exception ex) {
                    throw ex;
                } finally {
                    pDatabaseHelper.Dispose();
                }  
            }

        #endregion

    }
}