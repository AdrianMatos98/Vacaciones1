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
                    
                    oDatabaseHelper.AddParameter("@id", (pBEPersonal.IdPersonal <= 0) ? (object)DBNull.Value : pBEPersonal.IdPersonal);
                    oDatabaseHelper.AddParameter("@nombre", string.IsNullOrEmpty(pBEPersonal.Nombre) ? (object)DBNull.Value : pBEPersonal.Nombre);
                    oDatabaseHelper.AddParameter("@Direccion", string.IsNullOrEmpty(pBEPersonal.Nombre) ? (object)DBNull.Value : pBEPersonal.Nombre);
                    oDatabaseHelper.AddParameter("@DNI", string.IsNullOrEmpty(pBEPersonal.DNI) ? (object)DBNull.Value : pBEPersonal.DNI);
                    oDatabaseHelper.AddParameter("@Login", string.IsNullOrEmpty(pBEPersonal.Login) ? (object)DBNull.Value : pBEPersonal.Login);

                    oIDataReader = oDatabaseHelper.ExecuteReader("Usuario_List", CommandType.StoredProcedure);


                    while (oIDataReader.Read()) {
                        oBEPersonal = new BEPersonal();
                        oBEPersonal.IdPersonal = int.Parse(oIDataReader["Id_Personal"].ToString());
                        oBEPersonal.Nombre = oIDataReader["Nombre"].ToString();
                        oBEPersonal.Direccion = oIDataReader["Direccion"].ToString();
                        oBEPersonal.DNI = oIDataReader["Dni"].ToString();
                        oBEPersonal.Login = oIDataReader["Login"].ToString();
                        oBEPersonal.Clave = oIDataReader["Clave"].ToString(); ;
                        oBEPersonal.correo = oIDataReader["correo"].ToString(); ;
                        oBEPersonal.Estado = int.Parse(oIDataReader["Estado"].ToString());
                        oBEPersonal.idPerfil =(DBNull.Value== oIDataReader["idPerfil"])?0:int.Parse(oIDataReader["idPerfil"].ToString());
                        
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

            public bool InsertarPersonal(ref string  pmensaje , BEPersonal pBEPersonal)
            {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                try
                {
                    oDatabaseHelper.ClearParameter();
                    oDatabaseHelper.AddParameter("@id", (pBEPersonal.IdPersonal <= 0) ? (object)DBNull.Value : pBEPersonal.IdPersonal,ParameterDirection.Output,SqlDbType.Int,4);
                    oDatabaseHelper.AddParameter("@nombre", string.IsNullOrEmpty(pBEPersonal.Nombre) ? (object)DBNull.Value : pBEPersonal.Nombre);
                    oDatabaseHelper.AddParameter("@Direccion", string.IsNullOrEmpty(pBEPersonal.Direccion) ? (object)DBNull.Value : pBEPersonal.Direccion);
                    oDatabaseHelper.AddParameter("@DNI", string.IsNullOrEmpty(pBEPersonal.DNI) ? (object)DBNull.Value : pBEPersonal.DNI);
                    oDatabaseHelper.AddParameter("@Login", string.IsNullOrEmpty(pBEPersonal.Login) ? (object)DBNull.Value : pBEPersonal.Login);

                    oDatabaseHelper.AddParameter("@Clave", string.IsNullOrEmpty(pBEPersonal.Clave) ? (object)DBNull.Value : pBEPersonal.Clave);
                    oDatabaseHelper.AddParameter("@correo", string.IsNullOrEmpty(pBEPersonal.correo) ? (object)DBNull.Value : pBEPersonal.correo);
                    oDatabaseHelper.AddParameter("@perfilid", (pBEPersonal.idPerfil <= 0) ? (object)DBNull.Value : pBEPersonal.idPerfil);
                    oDatabaseHelper.AddParameter("@estado", (pBEPersonal.Estado <= 0) ? (object)DBNull.Value : pBEPersonal.Estado);

                    oDatabaseHelper.AddParameter("@usuarioModificacion", (pBEPersonal.Auditoria == null) ? (object)DBNull.Value : pBEPersonal.Auditoria.IdPersonal);

                    int filasAfectadas = oDatabaseHelper.ExecuteNonQuery("Usuario_insert", CommandType.StoredProcedure, DBHelper.ConnectionState.KeepOpen,true);

                    pBEPersonal.IdPersonal = Convert.ToInt32(oDatabaseHelper.GetParameter("@id").Value.ToString());
                    return (filasAfectadas>0);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    oDatabaseHelper.Dispose();
                }
                
            
            }
            public bool ActualizarPersonal(ref string pmensaje, BEPersonal pBEPersonal)
            {
                DatabaseHelper oDatabaseHelper = new DatabaseHelper();
                IDataReader oIDataReader = null;
                try
                {
                    oDatabaseHelper.ClearParameter();
                    //@id int  out  
                    //,@nombre varchar(255) =  NULL
                    //,@Direccion varchar(150) = null
                    //,@DNI varchar(8) = null
                    //,@Login varchar(30) =  NULL
                    //,@Clave varchar(20) =  NULL
                    //,@correo varchar(30) =  NULL
                    //,@perfilid int  = NULL 
                    //,@estado int  = NULL
                    //,@usuarioModificacion int = NULL

                    oDatabaseHelper.AddParameter("@id", (pBEPersonal.IdPersonal <= 0) ? (object)DBNull.Value : pBEPersonal.IdPersonal);
                    oDatabaseHelper.AddParameter("@nombre", string.IsNullOrEmpty(pBEPersonal.Nombre) ? (object)DBNull.Value : pBEPersonal.Nombre);
                    oDatabaseHelper.AddParameter("@Direccion", string.IsNullOrEmpty(pBEPersonal.Direccion) ? (object)DBNull.Value : pBEPersonal.Direccion);
                    oDatabaseHelper.AddParameter("@DNI", string.IsNullOrEmpty(pBEPersonal.DNI) ? (object)DBNull.Value : pBEPersonal.DNI);
                    oDatabaseHelper.AddParameter("@Login", string.IsNullOrEmpty(pBEPersonal.Login) ? (object)DBNull.Value : pBEPersonal.Login);

                    oDatabaseHelper.AddParameter("@Clave", string.IsNullOrEmpty(pBEPersonal.Clave) ? (object)DBNull.Value : pBEPersonal.Clave);
                    oDatabaseHelper.AddParameter("@correo", string.IsNullOrEmpty(pBEPersonal.correo) ? (object)DBNull.Value : pBEPersonal.correo);
                    oDatabaseHelper.AddParameter("@perfilid", (pBEPersonal.idPerfil <= 0) ? (object)DBNull.Value : pBEPersonal.idPerfil);
                    oDatabaseHelper.AddParameter("@estado", (pBEPersonal.Estado <= 0) ? (object)DBNull.Value : pBEPersonal.Estado);
                    oDatabaseHelper.AddParameter("@usuarioModificacion", (pBEPersonal.Auditoria == null) ? (object)DBNull.Value : pBEPersonal.Auditoria.IdPersonal);

                    int filasAfectadas = oDatabaseHelper.ExecuteNonQuery("Usuario_Update", CommandType.StoredProcedure);

                    return (filasAfectadas > 0);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    oDatabaseHelper.Dispose();
                }
                
            }
        #endregion

    }
}