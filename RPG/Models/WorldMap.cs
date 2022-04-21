using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Models;

internal class WorldMap
{
    private const int _HAUTEUR = 20;
    private const int _LARGEUR = 50;
    private int _PositionX;
    private int _PositionY;
    public string[,] Map = new string[_HAUTEUR, _LARGEUR];
    public List<Entity> Personnages = new List<Entity>();
    Random rnd = new Random();

    public WorldMap()
    {
        {
            for (int hauteur = 0; hauteur < Map.GetLength(0); hauteur++)
            {
                for (int largeur = 0; largeur < Map.GetLength(1); largeur++)
                {
                    if (hauteur == 0 && largeur == 0)
                    {
                        Map[hauteur, largeur] = "╔";
                    }
                    else if (hauteur == 0 && largeur == Map.GetLength(1) - 1)
                    {
                        Map[hauteur, largeur] = "╗";
                    }
                    else if (hauteur == Map.GetLength(0) - 1 && largeur == 0)
                    {
                        Map[hauteur, largeur] = "╚";
                    }
                    else if (hauteur == Map.GetLength(0) - 1 && largeur == Map.GetLength(1) - 1)
                    {
                        Map[hauteur, largeur] = "╝";
                    }
                    else if (hauteur == 0 || hauteur == Map.GetLength(0) - 1)
                    {
                        Map[hauteur, largeur] = "═";
                    }
                    else if (largeur == 0 || largeur == Map.GetLength(1) - 1)
                    {
                        Map[hauteur, largeur] = "║";
                    }
                    else
                        Map[hauteur, largeur] = " ";
                }
            }
        }
    }
    public void AfficherPlateau()
    {
        for (int hauteur = 0; hauteur < Map.GetLength(0); hauteur++)
        {
            for (int largeur = 0; largeur < Map.GetLength(1); largeur++)
            {
                Console.Write(Map[hauteur, largeur]);
            }
            Console.WriteLine();
        }
    }
    public void AjouterPersonnage(int nombre)
    {
        for (int compteur = 0; compteur < nombre; compteur++)
        {
            Monstre monstre = new Monstre();
            Personnages.Add(monstre);
            AjouterAvatar(monstre);
        }
    }
    public void AjouterAvatar(Entity personnage)
    {
        do
        {
            _PositionY = rnd.Next(1, Map.GetLength(0) - 1);
            _PositionX = rnd.Next(1, Map.GetLength(1) - 1);
        } while (Map[_PositionY, _PositionX] != " ");
        personnage.PositionY = _PositionY;
        personnage.PositionX = _PositionX;
        Map[personnage.PositionY, personnage.PositionX] = personnage.Avatar;
    }
    public void Deplacement(Entity personnage, ConsoleKeyInfo cki)
    {
        switch (cki.Key)
        {
            case ConsoleKey.UpArrow:
                if (personnage.PositionY > 1)
                {
                    Map[personnage.PositionY, personnage.PositionX] = " ";
                    Map[personnage.PositionY - 1, personnage.PositionX] = personnage.Avatar;
                    personnage.PositionY -= 1;
                }
                break;
            case ConsoleKey.DownArrow:
                if (personnage.PositionY < Map.GetLength(0) - 2)
                {
                    Map[personnage.PositionY, personnage.PositionX] = " ";
                    Map[personnage.PositionY + 1, personnage.PositionX] = personnage.Avatar;
                    personnage.PositionY += 1;
                }
                break;
            case ConsoleKey.LeftArrow:
                if (personnage.PositionX > 1)
                {
                    Map[personnage.PositionY, personnage.PositionX] = " ";
                    Map[personnage.PositionY, personnage.PositionX - 1] = personnage.Avatar;
                    personnage.PositionX -= 1;
                }
                break;
            case ConsoleKey.RightArrow:
                if (personnage.PositionX < Map.GetLength(1) - 2)
                {
                    Map[personnage.PositionY, personnage.PositionX] = " ";
                    Map[personnage.PositionY, personnage.PositionX + 1] = personnage.Avatar;
                    personnage.PositionX += 1;
                }
                break;
        }
    }
    public void Deplacement()
    {
        int direction;
        foreach (Monstre monstre in Personnages)
        {
            direction = rnd.Next(1, 5);
            switch (direction)
            {
                case 1:
                    if (monstre.PositionY > 1)
                    {
                        Map[monstre.PositionY, monstre.PositionX] = " ";
                        Map[monstre.PositionY - 1, monstre.PositionX] = monstre.Avatar;
                        monstre.PositionY -= 1;
                    }
                    break;
                case 2:
                    if (monstre.PositionY < Map.GetLength(0) - 2)
                    {
                        Map[monstre.PositionY, monstre.PositionX] = " ";
                        Map[monstre.PositionY + 1, monstre.PositionX] = monstre.Avatar;
                        monstre.PositionY += 1;
                    }
                    break;
                case 3:
                    if (monstre.PositionX > 1)
                    {
                        Map[monstre.PositionY, monstre.PositionX] = " ";
                        Map[monstre.PositionY, monstre.PositionX - 1] = monstre.Avatar;
                        monstre.PositionX -= 1;
                    }
                    break;
                case 4:
                    if (monstre.PositionX < Map.GetLength(1) - 2)
                    {
                        Map[monstre.PositionY, monstre.PositionX] = " ";
                        Map[monstre.PositionY, monstre.PositionX + 1] = monstre.Avatar;
                        monstre.PositionX += 1;
                    }
                    break;
            }
        }
    }
}
