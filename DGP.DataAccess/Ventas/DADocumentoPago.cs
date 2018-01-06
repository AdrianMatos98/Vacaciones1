using System;
using System.Collections.Generic;
using System.Text;

using DGP.Entities.Ventas;
using System.Data;
using DBHelper;

namespace DGP.DataAccess.Ventas
{
    public class DADocumentoPago
    {
        #region "Métodos de Documentos"

        public List<BEDocumento> ListarDocumento(BEDocumento beDocumento)
        {
            return this.ListarDocumento(beDocumento , null,null);

        }

        public List<BEDocumento> ListarDocumento(BEDocumento beDocumento, DateTime? FechaInicio, DateTime? FechaFinal)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();

            List<BEDocumento> vLista = new List<BEDocumento>();
            IDataReader oIDataReader = null;
            try
            {
                oDatabaseHelper.ClearParameter();
                oDatabaseHelper.AddParameter("@IdDocumento", (beDocumento.IdDocumento == 0) ? DBNull.Value : (object)beDocumento.IdDocumento );

                oDatabaseHelper.AddParameter("@IdTipoDocumento", (string.IsNullOrEmpty(beDocumento.IdTipoDocumento)) ? DBNull.Value :(object) beDocumento.IdTipoDocumento);
                oDatabaseHelper.AddParameter("@FechaInicio", FechaInicio);
                oDatabaseHelper.AddParameter("@FechaFinal", FechaFinal );
                oDatabaseHelper.AddParameter("@IdCliente", (beDocumento.Cliente.IdCliente == 0) ? DBNull.Value : (object)beDocumento.Cliente.IdCliente);

                oIDataReader = oDatabaseHelper.ExecuteReader("ListarDocumento", CommandType.StoredProcedure);
                while (oIDataReader.Read())
                {
                    vLista.Add(new BEDocumento()
                    {
                        IdDocumento = (int)oIDataReader["IdDocumento"],
                        Fecha = Convert.ToDateTime(oIDataReader["Fecha"]),
                        Cliente = new DGP.Entities.BEClienteProveedor((int)oIDataReader["IdCliente"], oIDataReader["NombreCliente"].ToString()),
                        IdTipoDocumento = oIDataReader["IdTipoDocumento"].ToString(),
                        Monto = decimal.Parse( oIDataReader["Monto"].ToString()),

                    });
                    
                  }
                return (vLista);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<BEDocumento> ListarDocumentoPago(int codCliProv, DateTime? FechaInicio, DateTime? FechaFinal)
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();

            List<BEDocumento> vLista = new List<BEDocumento>();
            IDataReader oIDataReader = null;
            try
            {
                oDatabaseHelper.ClearParameter();
                oDatabaseHelper.AddParameter("@FechaInicio", FechaInicio);
                oDatabaseHelper.AddParameter("@FechaFinal", FechaFinal);
                oDatabaseHelper.AddParameter("@IdCliente", codCliProv);

                oIDataReader = oDatabaseHelper.ExecuteReader("ListarDocumentosPago", CommandType.StoredProcedure);
                while (oIDataReader.Read())
                {
                    vLista.Add(new BEDocumento()
                    {
                        IdDocumento = (int)oIDataReader["IdDocumento"],
                        Fecha = Convert.ToDateTime(oIDataReader["Fecha"]),
                        IdTipoDocumento = oIDataReader["IdTipoDocumento"].ToString(),
                        Monto = decimal.Parse(oIDataReader["Monto"].ToString()),
                        Estado = (int)oIDataReader["estado"],
                    });

                }
                return (vLista);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool InsertarCabeceraDocumento(BEDocumento beDocumento)
        {
            return this.InsertarCabeceraDocumento(beDocumento, null);

        }

        public bool InsertarCabeceraDocumento(BEDocumento beDocumento, DatabaseHelper pDatabaseHelper)
        {
            DatabaseHelper oDatabaseHelper = (pDatabaseHelper == null) ? new DatabaseHelper() : pDatabaseHelper;

            try
            {
                oDatabaseHelper.ClearParameter();
                oDatabaseHelper.AddParameter("@IdTipoDocumento", beDocumento.IdTipoDocumento);
                oDatabaseHelper.AddParameter("@Fecha", beDocumento.Fecha.Date);
                oDatabaseHelper.AddParameter("@Monto", beDocumento.Monto);
                oDatabaseHelper.AddParameter("@Usuario", beDocumento.BEUsuarioLogin.IdPersonal);
                oDatabaseHelper.AddParameter("@IdCaja", beDocumento.BEUsuarioLogin.IdCaja);
                oDatabaseHelper.AddParameter("@IdCliente", beDocumento.Cliente.IdCliente);
                oDatabaseHelper.AddParameter("@IdPersonal", beDocumento.Personal.IdPersonal);

                object vResultado = oDatabaseHelper.ExecuteScalar("InsertarDocumento", CommandType.StoredProcedure, (pDatabaseHelper == null) ? DBHelper.ConnectionState.CloseOnExit : DBHelper.ConnectionState.KeepOpen);
                beDocumento.IdDocumento = int.Parse(vResultado.ToString());
                return (vResultado != null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                if (pDatabaseHelper == null) oDatabaseHelper.Dispose();
            }

        }


        public bool ActualizarCabeceraDocumento(BEDocumento beDocumento)
        {
            return this.InsertarCabeceraDocumento(beDocumento, null);

        }

        public bool ActualizarCabeceraDocumento(BEDocumento beDocumento, DatabaseHelper pDatabaseHelper)
        {
            DatabaseHelper oDatabaseHelper = (pDatabaseHelper == null) ? new DatabaseHelper() : pDatabaseHelper;

            try
            {
                oDatabaseHelper.ClearParameter();
                oDatabaseHelper.AddParameter("@IdTipoDocumento", beDocumento.IdTipoDocumento);
                oDatabaseHelper.AddParameter("@Fecha", beDocumento.Fecha.Date);
                oDatabaseHelper.AddParameter("@Monto", beDocumento.Monto);
                oDatabaseHelper.AddParameter("@Usuario", beDocumento.BEUsuarioLogin.IdPersonal);
                oDatabaseHelper.AddParameter("@IdCaja", beDocumento.BEUsuarioLogin.IdCaja);
                oDatabaseHelper.AddParameter("@IdCliente", beDocumento.Cliente.IdCliente);
                oDatabaseHelper.AddParameter("@IdPersonal", beDocumento.Personal.IdPersonal);

                object vResultado = oDatabaseHelper.ExecuteScalar("InsertarDocumento", CommandType.StoredProcedure, (pDatabaseHelper == null) ? DBHelper.ConnectionState.CloseOnExit : DBHelper.ConnectionState.KeepOpen);
                beDocumento.IdDocumento = int.Parse(vResultado.ToString());
                return (vResultado != null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                if (pDatabaseHelper == null) oDatabaseHelper.Dispose();
            }

        }

        public bool EliminarCabeceraDocumento(BEDocumento beDocumento)
        {
            return this.InsertarCabeceraDocumento(beDocumento, null);

        }

        public bool EliminarCabeceraDocumento(BEDocumento beDocumento, DatabaseHelper pDatabaseHelper)
        {
            DatabaseHelper oDatabaseHelper = (pDatabaseHelper == null) ? new DatabaseHelper() : pDatabaseHelper;

            try
            {
                oDatabaseHelper.ClearParameter();
                oDatabaseHelper.AddParameter("@IdTipoDocumento", beDocumento.IdTipoDocumento);
                oDatabaseHelper.AddParameter("@Fecha", beDocumento.Fecha.Date);
                oDatabaseHelper.AddParameter("@Monto", beDocumento.Monto);
                oDatabaseHelper.AddParameter("@Usuario", beDocumento.BEUsuarioLogin.IdPersonal);
                oDatabaseHelper.AddParameter("@IdCaja", beDocumento.BEUsuarioLogin.IdCaja);
                oDatabaseHelper.AddParameter("@IdCliente", beDocumento.Cliente.IdCliente);
                oDatabaseHelper.AddParameter("@IdPersonal", beDocumento.Personal.IdPersonal);

                object vResultado = oDatabaseHelper.ExecuteScalar("InsertarDocumento", CommandType.StoredProcedure, (pDatabaseHelper == null) ? DBHelper.ConnectionState.CloseOnExit : DBHelper.ConnectionState.KeepOpen);
                beDocumento.IdDocumento = int.Parse(vResultado.ToString());
                return (vResultado != null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                if (pDatabaseHelper == null) oDatabaseHelper.Dispose();
            }

        }

        #endregion
    }
}
