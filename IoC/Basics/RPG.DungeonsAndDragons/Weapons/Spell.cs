using System;
using System.Collections.Generic;
using RPG.Core;

namespace RPG.DungeonsAndDragons.Weapons
{
    public class Spell : IWeapon
    {
        public IList<string> target = new List<string>
                                      {
                                          "Mono",
                                          "Rana",
                                          "Piedra",
                                          "Rata",
                                          "Mosca",
                                          "Burro",
                                          "Flamas"
                                      };

        public Spell()
        {
            Name = "Hechizo";
            Damage = 100;
        }

        public int Damage { get; private set; }
        public string Name { get; set; }

        public void Use()
        {
            var random = new Random();
            var index = random.Next(0, target.Count);
            Console.Write(" ha convertido en {0} al enemigo", target[index]);
        }
    }
}