using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Models;

abstract class Entity
{
    private int _DeRef;
    private int _De;
    private double _Modificateur = 1;
    public int Force { get; set; }
    public int Endurance { get; set; }
    public int PointDeVie { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public string Avatar { get; set; }
    Random rnd = new Random();

    public Entity()
    {
        _DeRef = rnd.Next(1, 7);
        for (int i = 0; i < 3; i++)
        {
            _De = rnd.Next(1, 7);
            if (_De > _DeRef)
                Force = Force + _De;
            else
            {
                Force = Force + _DeRef;
                _DeRef = _De;
            }
        }
        _DeRef = rnd.Next(1, 7);
        for (int i = 0; i < 3; i++)
        {
            _De = rnd.Next(1, 7);
            if (_De > _DeRef)
                Endurance = Endurance + _De;
            else
            {
                Endurance = Endurance + _DeRef;
                _DeRef = _De;
            }
        }
        if (Force >= 15)
        {
            Force += 2;
            _Modificateur = 2;
        }
        else if (Force >= 10)
        {
            Force += 1;
            _Modificateur = 1.5;
        }
        else if (Force >= 5)
        {
            _Modificateur = 1.25;
        }
        else if (Force < 5)
            Force -= 1;
        if (Endurance >= 15)
            Endurance += 2;
        else if (Endurance >= 10)
            Endurance += 1;
        else if (Endurance < 5)
            Endurance -= 1;
        PointDeVie = (int)(Endurance * _Modificateur);
    }
    public abstract void Afficher();
}
