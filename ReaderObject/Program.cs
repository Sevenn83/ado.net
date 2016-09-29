using System.Collections.ObjectModel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data.SqlClient;

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

                var command = new OracleCommand("SELECT * FROM EMPLOYE", connection);
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                    }
                } else 
                    Console.WriteLine("no rows found.");

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
