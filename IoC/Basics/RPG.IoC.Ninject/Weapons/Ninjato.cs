using System;
using RPG.Core;

namespace RPG.IoC.Ninject
{
    public class Ninjato : IWeapon
    {
        public Ninjato()
        {
            Damage = 10;
            Name = "Ninjato";
        }

        public int Damage { get; private set; }
        public string Name { get; set; }

        public void Use()
        {
            Console.WriteLine(" Slice // ");
        }
    }
}