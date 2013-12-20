using System;
using System.Collections.Generic;
using RPG.Core;

namespace RPG.DungeonsAndDragons.Weapons
{
    public class Bow : IWeapon
    {
        public IList<string> target = new List<string>
                                      {
                                          "el corazón",
                                          "la cabeza",
                                          "el hombro",
                                          "la pierna"
                                      };
        public Bow()
        {
            Name = "Arco";
            Damage = 5;
        }

        public int Damage { get; private set; }
        public string Name { get; set; }

        public void Use()
        {
            var random = new Random();
            var index = random.Next(0, target.Count);
            Console.Write("Ha acertado en {0} del enemigo", target[index]);
        }
    }
}