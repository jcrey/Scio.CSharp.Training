using System;
using RPG.Core;

namespace RPG.IoC.Ninject
{
    public class Shuriken : IWeapon
    {
        public Shuriken()
        {
            Damage = 1;
            Name = "Shuriken";
        }

        public int Damage { get; private set; }
        public string Name { get; set; }

        public void Use()
        {
            Console.WriteLine(" throw >|< ");
        }
    }
}