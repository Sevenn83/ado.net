using System.Collections.ObjectModel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;

namespace ReaderObject
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                var connection = new OracleConnection
                {
                    ConnectionString = ConfigurationManager.ConnectionStrings["oracledb"].ConnectionString
                };
                connection.Open();
                Console.WriteLine("Connection établie");
                connection.Close();
                connection.Dispose();
                Console.WriteLine("Appuyez sur une touche pour continuer ...");
                Console.ReadKey();

                var Employes = new Collection<Employe>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Appuyez sur une touche pour continuer ...");
                Console.ReadKey();
            }
        }
    }
}
