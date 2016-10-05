using System;
using System.Linq;
using EntityFrameworkOracle;

namespace ReaderObject
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                using (var oracleContexte = new EFOracleEntities())
                {
                    var requeteEmployes = from e in oracleContexte.EMPLOYEs
                                          select e;

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
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Appuyez sur une touche pour continuer ...");
                Console.ReadKey();
            }
        }
    }
}