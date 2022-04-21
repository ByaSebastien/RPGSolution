using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Models;

internal class Hero : Entity
{
    public string Nom { get; set; }
    public string Race { get; set; }
    public Hero(int choix, string nom)
    {
        if (nom == "Dante")
        {
            Force *= 100;
            Endurance *= 100;
            PointDeVie *= 100;
        }
        this.Nom = nom;
        switch (choix)
        {
            case 1:
                this.Race = "Humain";
                this.Force += 1;
                this.Endurance += 1;
                break;
            case 2:
                this.Race = "Nain";
                this.Endurance += 2;
                break;
        }
        this.Avatar = "☻";
    }
    public override void Afficher()
    {
        Console.WriteLine($"Nom : {Nom}");
        Console.WriteLine($"Race : {Race}");
        Console.WriteLine($"Point de vie : {PointDeVie}");
        Console.WriteLine($"Force : {Force}");
        Console.WriteLine($"Endurence : {Endurance}");
    }
}
