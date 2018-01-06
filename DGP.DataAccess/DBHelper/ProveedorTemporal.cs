using System;
using System.Data;
using System.Configuration.Assemblies;
using System.Data.OracleClient;
using System.Configuration;
using System.Text;
using System.IO;

namespace Coga.Vuelo.DAL
{
    class ProveedorTemporal
    {
        public class ResultadoEjecucion
        {
            private int filasAfectadas;

            public int FilasAfectadas
            {
                get { return filasAfectadas; }
                set { filasAfectadas = value; }
            }
            public ResultadoEjecucion()
            {
                filasAfectadas = 0;
            }
        }

        public class ProveedorOracle
        {
            private OracleCommand _COMMAND;
            private OracleCommand _SELECT_COMMAND;

            private bool EjecutarComando()
            {
                Resultado = new ResultadoEjecucion();
                string strCon = this.GetStringConection().ConnectionString;

                OracleConnection oCon = new OracleConnection(strCon);
                OracleCommand myCommand = new OracleCommand(this._COMMAND.CommandText, this.GetStringConection());

                try
                {
                    myCommand.Connection.Open();
                    Resultado.FilasAfectadas = myCommand.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + " en comando: " + this._COMMAND.CommandText);
                }
                finally
                {
                    oCon.Close();
                }
            }
            private OracleConnection GetStringConection()
            {
                OracleConnection strCon = new OracleConnection();
                strCon.ConnectionString = ConfigurationManager.ConnectionStrings["CogaFrameworkCS"].ConnectionString;
                return strCon;
            }
            private DataTable EjecutarConsulta()
            {
                Resultado = new ResultadoEjecucion();
                string strCon = this.GetStringConection().ConnectionString;
                DataSet ds = new DataSet();

                OracleConnection oCon = new OracleConnection(strCon);
                OracleDataAdapter da = new OracleDataAdapter(this._SELECT_COMMAND.CommandText, oCon);

                try
                {
                    oCon.Open();
                    Resultado.FilasAfectadas = da.Fill(ds);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + " en consulta: " + this._SELECT_COMMAND.CommandText);
                }
                finally
                {
                    oCon.Close();
                }
                return ds.Tables[0];
            }

            public ResultadoEjecucion Resultado;

            public OracleCommand Consulta
            {
                get { return _SELECT_COMMAND; }
                set { _SELECT_COMMAND = value; }
            }

            public static int EjecutarComando(string comando)
            {
                ProveedorOracle po = new ProveedorOracle();
                po._COMMAND = new OracleCommand(comando);
                po.EjecutarComando();
                return po.Resultado.FilasAfectadas;
            }
            public static int EjecutarConsulta_RetornarNumeroRegistros(string consulta)
            {
                ProveedorOracle po = new ProveedorOracle();
                po.Consulta = new OracleCommand(consulta.ToString());
                return po.EjecutarConsulta().Rows.Count;
            }
            public static bool EjecutarConsulta_TieneRegistros(StringBuilder Consulta)
            {
                if (ProveedorOracle.EjecutarConsulta_RetornarNumeroRegistros(Consulta.ToString()) > 0)
                    return true;
                else
                    return false;
            }
            public static DataTable EjecutarConsulta(string Consulta)
            {
                ProveedorOracle p = new ProveedorOracle();
                p.Consulta = new OracleCommand(Consulta.ToString());
                DataTable dt = p.EjecutarConsulta();
                return dt;
            }
            public static int EjecutarComando_1Archivo(string comando, Stream Parametro1_Archivo)
            {
                ProveedorOracle po = new ProveedorOracle();
                po._COMMAND = new OracleCommand(comando);
                OracleParameter paramImage = new OracleParameter("image", OracleType.Blob);
                paramImage.Value = Parametro1_Archivo;
                paramImage.Direction = ParameterDirection.Input;
                po._COMMAND.Parameters.Add(paramImage);
                po.EjecutarComando();
                return po.Resultado.FilasAfectadas;
            }
        }
    }
}
