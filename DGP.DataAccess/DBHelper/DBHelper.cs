using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Configuration.Assemblies;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;

namespace DBHelper {

    public class DatabaseHelper : IDisposable {
        private const string STRCONNECTION_KEY = "DGP.Entities.Properties.Settings.dgpConnectionString";
        public const bool PARAMETROS_OUT = true;
        public const int MENSAJE_SIZE = 2000;
        public const int INDEX_PARAMETROS_OUT = 0;
        private string strConnectionString;
        private SqlConnection objConnection;
        private SqlCommand objCommand; 
        private SqlClientFactory objFactory = null;
        private bool boolHandleErrors;
        private string strLastError;
        private bool boolLogError;
        private string strLogFile;
        /**/
        private bool mensajeError =true;

        public bool MensajeError {
            get { return mensajeError; }
            set { mensajeError = value; }
        }

        /**/
        public DatabaseHelper(string connectionstring, Providers provider) {
            strConnectionString = connectionstring;
            switch (provider) {
                case Providers.SqlServer:
                    objFactory = SqlClientFactory.Instance;
                    break;
                case Providers.ConfigDefined:

                    string providername = ConfigurationManager.ConnectionStrings[STRCONNECTION_KEY].ProviderName;
                    switch (providername) {
                        case "System.Data.SqlClient":
                            objFactory = SqlClientFactory.Instance;
                            break;
                    }
                    break;
            }
            objConnection = (SqlConnection)objFactory.CreateConnection();
            objCommand = (SqlCommand)objFactory.CreateCommand();

            objConnection.ConnectionString = strConnectionString;
            objCommand.Connection = objConnection;
        }
        public DatabaseHelper(Providers provider) : this(ConfigurationManager.ConnectionStrings[STRCONNECTION_KEY].ConnectionString, provider) { }
        public DatabaseHelper(string connectionstring) : this(connectionstring, Providers.SqlServer) { }
        public DatabaseHelper() : this(ConfigurationManager.ConnectionStrings[STRCONNECTION_KEY].ConnectionString, Providers.SqlServer) { }
        public bool HandleErrors {
            get { return boolHandleErrors; }
            set { boolHandleErrors = value; }
        }
        public string LastError {
            get { return strLastError; }
        }
        public bool LogErrors {
            get { return boolLogError; }
            set { boolLogError = value; }
        }
        public string LogFile {
            get { return strLogFile; }
            set { strLogFile = value; }
        }
        public SqlParameter AddParameter(string name, object value) {
            SqlParameter p = new SqlParameter();
            p.ParameterName = name;
            p.Value = value;
            return objCommand.Parameters.Add(p);
        }

        public void ClearParameter() {           
            objCommand.Parameters.Clear ();
        }
        public SqlParameter AddParameter(string name, object value, ParameterDirection Direccion, SqlDbType tipo) {
            SqlParameter p = new SqlParameter();
            p.ParameterName = name;
            p.Value = value;
            p.Direction = Direccion;
            p.SqlDbType = tipo;
            return objCommand.Parameters.Add (p);
        }
        public SqlParameter AddParameter(string name, object value, ParameterDirection Direccion, SqlDbType tipo, int size){
            SqlParameter p = new SqlParameter();
            p.ParameterName = name;
            p.Value = value;
            p.Direction = Direccion;
            p.SqlDbType = tipo;
            p.Size = size;
            if (tipo == SqlDbType.VarChar) {
                //p.Size = 2000;
            }
            //***********************************
            return objCommand.Parameters.Add(p);
        }
        public SqlParameter AddParameter(string name, object value, ParameterDirection Direccion) {
            SqlParameter p = new SqlParameter();
            p.ParameterName = name;
            p.Value = value;
            p.Direction = Direccion;
            return objCommand.Parameters.Add(p);
        }
        public SqlParameter AddParameter(SqlParameter parameter) {
            return objCommand.Parameters.Add(parameter);
        }
        public DbParameter GetParameter(string parameter) {
            return objCommand.Parameters[parameter];
        }
        public SqlCommand Command {
            get {
                return objCommand;
            }
        }
        public void BeginTransaction() {
            if (objConnection.State == System.Data.ConnectionState.Closed) {
                objConnection.Open();
            }
            objCommand.Transaction = objConnection.BeginTransaction();
        }
        public void CommitTransaction() {
            objCommand.Transaction.Commit();
            objConnection.Close();
        }
        public void RollbackTransaction() {
            objCommand.Transaction.Rollback();
            objConnection.Close();
        }
        public int ExecuteNonQuery(string query) {
            return ExecuteNonQuery(query, CommandType.Text, ConnectionState.CloseOnExit);
        }
        public int ExecuteNonQuery(string query, CommandType commandtype) {
            return ExecuteNonQuery(query, commandtype, ConnectionState.CloseOnExit);
        }
        public int ExecuteNonQuery(string query, ConnectionState connectionstate) {
            return ExecuteNonQuery(query, CommandType.Text, connectionstate);
        }
        public int ExecuteNonQuery(string query, CommandType commandtype, ConnectionState connectionstate) {
            return ExecuteNonQuery(query , commandtype , connectionstate , false);
        }

        public int ExecuteNonQuery(string query, CommandType commandtype, ConnectionState connectionstate , bool ParametrosSalida) {
            objCommand.CommandText = query;
            objCommand.CommandType = commandtype;
            int i = -1;
            try {
                if (objConnection.State == System.Data.ConnectionState.Closed) {
                    objConnection.Open();

                }
                i = objCommand.ExecuteNonQuery();

            } catch (Exception ex) {
                HandleExceptions(ex);
            } finally {
                if (!ParametrosSalida) objCommand.Parameters.Clear();
                
                if (connectionstate == ConnectionState.CloseOnExit) {
                    objConnection.Close();
                }
            }
            return i;
        }
        public object ExecuteScalar(string query) {
            return ExecuteScalar(query, CommandType.Text, ConnectionState.CloseOnExit);
        }
        public object ExecuteScalar(string query, CommandType commandtype) {
            return ExecuteScalar(query, commandtype, ConnectionState.CloseOnExit);
        }
        public object ExecuteScalar(string query, ConnectionState connectionstate) {
            return ExecuteScalar(query, CommandType.Text, connectionstate);
        }
        public object ExecuteScalar(string query, CommandType commandtype, ConnectionState connectionstate) {
            return ExecuteScalar(query, commandtype, connectionstate, false);
        }
   
        public object ExecuteScalar(string query, CommandType commandtype, ConnectionState connectionstate , bool tieneParametrosSalida) {
            objCommand.CommandText = query;
            objCommand.CommandType = commandtype;
            object o = null;
            try {
                if (objConnection.State == System.Data.ConnectionState.Closed) {
                    objConnection.Open();
                }
                o = objCommand.ExecuteScalar();
            } catch (Exception ex) {
                HandleExceptions(ex);
            } finally {
                objCommand.Parameters.Clear();
                if (connectionstate == ConnectionState.CloseOnExit) {
                    objConnection.Close();
                }
            }
            return o;
        }
        public DbDataReader ExecuteReader(string query) {
            return ExecuteReader(query, CommandType.Text, ConnectionState.CloseOnExit);
        }
        public DbDataReader ExecuteReader(string query, CommandType commandtype) {
            return ExecuteReader(query, commandtype, ConnectionState.CloseOnExit);
        }
        public DbDataReader ExecuteReader(string query, ConnectionState connectionstate) {
            return ExecuteReader(query, CommandType.Text, connectionstate);
        }
        public DbDataReader ExecuteReader(string query, CommandType commandtype, ConnectionState connectionstate) {
            return ExecuteReader(query, commandtype , connectionstate, false);
        }
        public DbDataReader ExecuteReader(string query, CommandType commandtype, ConnectionState connectionstate , bool tieneParametroOut) {
            objCommand.CommandText = query;
            objCommand.CommandType = commandtype;
            DbDataReader reader = null;
            try {
                if (objConnection.State == System.Data.ConnectionState.Closed) {
                    objConnection.Open();
                }
                if (connectionstate == ConnectionState.CloseOnExit) {
                    reader = objCommand.ExecuteReader(CommandBehavior.CloseConnection);
                } else {
                    reader = objCommand.ExecuteReader();
                }
            } catch (Exception ex) {
                HandleExceptions(ex);
            } finally {
                if (!tieneParametroOut ) objCommand.Parameters.Clear();
            }
            return reader;
        }
        public DataSet ExecuteDataSet(string query) {
            return ExecuteDataSet(query, CommandType.Text, ConnectionState.CloseOnExit);
        }
        public DataSet ExecuteDataSet(string query, CommandType commandtype) {
            return ExecuteDataSet(query, commandtype, ConnectionState.CloseOnExit);
        }
        public DataSet ExecuteDataSet(string query, ConnectionState connectionstate) {
            return ExecuteDataSet(query, CommandType.Text, connectionstate);
        }
        public DataSet ExecuteDataSet(string query, CommandType commandtype, ConnectionState connectionstate) {
            return ExecuteDataSet(query ,commandtype ,connectionstate ,false );
        }

        public DataSet ExecuteDataSet(string query, CommandType commandtype, ConnectionState connectionstate , bool parametroSalida) {
            SqlDataAdapter adapter = (SqlDataAdapter)objFactory.CreateDataAdapter();
            objCommand.CommandText = query;
            objCommand.CommandType = commandtype;
            adapter.SelectCommand = objCommand;
            DataSet ds = new DataSet();
            try {
                adapter.Fill(ds);
            } catch (Exception ex) {
                this.ClearParameter();
                HandleExceptions(ex);
            } finally {
                if (!parametroSalida) objCommand.Parameters.Clear();
                //else 
                if (connectionstate == ConnectionState.CloseOnExit) {
                    if (objConnection.State == System.Data.ConnectionState.Open) {
                        objConnection.Close();
                    }
                }
            }
            return ds;
        }
        private void HandleExceptions(Exception ex)
        {
            if (LogErrors)
            {
                WriteToLog(ex.Message);
            }
            if (HandleErrors)
            {
                strLastError = ex.Message;
            }
            else
            {
                throw ex;
            }
        }
        private void WriteToLog(string msg)
        {
            StreamWriter writer = File.AppendText(LogFile);
            writer.WriteLine(DateTime.Now.ToString() + " - " + msg);
            writer.Close();
        }
        public void Dispose()
        {
            objConnection.Close();
            objConnection.Dispose();
            objCommand.Dispose();
        }
    }

    public enum Providers { SqlServer, OleDb, Oracle, ODBC, ConfigDefined }

    public enum ConnectionState { KeepOpen, CloseOnExit }

}