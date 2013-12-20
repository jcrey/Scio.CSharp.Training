using System;
using RPG.Core;

namespace RPG.DungeonsAndDragons.Weapons
{
    public class Sword : IWeapon
    {
        public Sword()
        {
            Damage = 10;
            Name = "Name";
        }

        public int Damage { get; private set; }
        public string Name { get; set; }

        public void Use()
        {
            Console.Write("Ha partido en dos al enemigo");
        }
    }
}