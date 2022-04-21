using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Method
    {
        public static int ChoixMultiple(int low, int high)
        {
            int choix = low - 1;
            while (choix < low || choix > high)
            {
                while (!int.TryParse(Console.ReadLine(), out choix))
                {
                    Console.WriteLine("Entrez un choix valide");
                    Console.Write("Choix :");
                }
                if (choix < low || choix > high)
                {
                    Console.WriteLine("Entrez un choix valide");
                    Console.Write("Choix :");
                }
            }
            return choix;
        }    
    }
}
