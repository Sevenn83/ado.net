using System;
using System.Linq;

namespace ReaderObject
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                using (var oracleContexte = new OracleEntities())
                {
                    var requeteEmployes = from EMPLOYE in oracleContexte.EMPLOYE
                                            select EMPLOYE;

                    var lesEmployes = requeteEmployes.ToList();

                    foreach (var unEmploye in lesEmployes)
                    {
                        Console.WriteLine(unEmploye.NUMEMP + " - " + unEmploye.NOMEMP);
                    }
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
