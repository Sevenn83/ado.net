using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace ReaderObject
{
    internal abstract class Bdd
    {

        public static OracleConnection GetOracleConnection()
        {
            return new OracleConnection
            {
                ConnectionString = string.Format(ConfigurationManager.ConnectionStrings["oracledb"].ConnectionString, ConfigurationManager.AppSettings["SERVEUR"],
                ConfigurationManager.AppSettings["PORT"],
                ConfigurationManager.AppSettings["SID"],
                ConfigurationManager.AppSettings["USERID"],
                ConfigurationManager.AppSettings["PWD"])
            };
        }

    }
}
