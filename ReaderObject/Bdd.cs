using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace ReaderObject
{
    internal class Bdd
    {
        public OracleConnection CnOracle { get; set; }

        public Bdd ()
        {
            var ch = string.Format(ConfigurationManager.ConnectionStrings["oracledb"].ConnectionString,
                ConfigurationManager.AppSettings["SERVEUR"],
                ConfigurationManager.AppSettings["PORT"],
                ConfigurationManager.AppSettings["SID"],
                ConfigurationManager.AppSettings["USERID"],
                ConfigurationManager.AppSettings["PWD"]);

            CnOracle = new OracleConnection(ch);
        }
    }
}
