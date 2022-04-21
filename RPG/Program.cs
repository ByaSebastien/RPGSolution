using RPG;
using RPG.Models;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Hero hero;
string nom;
int choix;
const int HAUTEUR = 20;
const int LARGEUR = 50;
bool choixValide = false;
bool enCours = true;
WorldMap plateau = new WorldMap();
ConsoleKeyInfo cki = new ConsoleKeyInfo();

Console.Write("Entre le nom de ton hero! : ");
nom = Console.ReadLine();
Console.WriteLine("Quelle race?");
Console.WriteLine("1 : Humain\t\t\t2 : Nain");
choix = Method.ChoixMultiple(1, 2);
Console.Clear();
hero = new Hero(choix, nom);
plateau.AjouterPersonnage(50);
plateau.AjouterAvatar(hero);
while (enCours)
{
    plateau.AfficherPlateau();
    hero.Afficher();
    do
    {
        choixValide = false;
        cki = Console.ReadKey();
        switch (cki.Key)
        {
            case ConsoleKey.UpArrow:
            case ConsoleKey.DownArrow:
            case ConsoleKey.LeftArrow:
            case ConsoleKey.RightArrow:
                choixValide = true;
                plateau.Deplacement(hero, cki);
                plateau.AfficherPlateau();
                plateau.Deplacement();
                plateau.AfficherPlateau();
                break;
        }
        Console.Clear();
    } while (!choixValide);
}