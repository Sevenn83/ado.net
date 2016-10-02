using System;

namespace ReaderObject
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                var serviceEmploye = new EmployeServices();

                var employes = serviceEmploye.FindAllEmployes();

                foreach (var employe in employes)
                {
                    Console.WriteLine(employe.ToString());
                }

                /*var employefinded = EmployeServices.FindEmployeById(1);
                Console.WriteLine(employefinded.ToString());*/

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
