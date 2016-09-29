﻿using System;

namespace ReaderObject
{
    internal class Program
    {
        private static void Main()
        {
            try
            {

                /*var Employes = EmployeServices.FindAllEmployes();

                foreach (var employe in Employes)
                {
                    Console.WriteLine(employe.ToString());
                }*/

                var employefinded = EmployeServices.FindEmployeById(1);
                Console.WriteLine(employefinded.ToString());

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
