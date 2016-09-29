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
                // Configuration de connexion
                var connection = new OracleConnection
                {
                    ConnectionString = ConfigurationManager.ConnectionStrings["oracledb"].ConnectionString
                };

                connection.Open();

                // Commande sql
                var command = new OracleCommand("SELECT * FROM EMPLOYE", connection);
                var reader = command.ExecuteReader();

                // Création de la collexion
                var Employes = new Collection<Employe>();

                // Remplisage de la collection
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employes.Add(EmployeServices.HydrateEmploye(reader));
                    }
                } else 
                    Console.WriteLine("no rows found.");

                connection.Close();
                connection.Dispose();

                foreach (var employe in Employes)
                {
                    Console.WriteLine(employe.ToString());
                }

                Console.WriteLine("Appuyez sur une touche pour continuer ...");
                Console.ReadKey();
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
