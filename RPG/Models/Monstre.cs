using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Models
{
    internal class Monstre : Entity
    {
        private static int _compteur;
        private int _Id;
        public Monstre()
        {
            _Id = ++_compteur;
            Force /= 2;
            Endurance /= 2;
            PointDeVie /= 2;
            this.Avatar = "‼";
        }
        public override void Afficher()
        {
            Console.WriteLine($"Monstre : {_Id}");
            Console.WriteLine($"Point de vie : {PointDeVie}");
            Console.WriteLine($"Force : {Force}");
            Console.WriteLine($"Endurence : {Endurance}");
        }
    }
}
