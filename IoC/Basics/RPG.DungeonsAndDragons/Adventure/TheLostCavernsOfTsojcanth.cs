using System;
using System.Collections.Generic;
using RPG.Core;
using RPG.DungeonsAndDragons.Characters;

namespace RPG.DungeonsAndDragons.Adventure
{
    public class TheLostCavernsOfTsojcanth : IMap
    {
        public IList<string> Quest = new List<string>
                                         {
                                             "An Orc attacks you",
                                             "You find a door",
                                             "A dragon rises",
                                             "The Demon of Tsojcanth attacks you"
                                         };

        public TheLostCavernsOfTsojcanth()
        {
            Dificulty = 10000;
        }

        public bool Completed { get; set; }
        public int Dificulty { get; set; }

        public void Load()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("_|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|");
            Console.WriteLine("___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|__");
            Console.WriteLine("There is a treasure in the Yatil Mountains south of the Greyhawk realm of Perrenland.");
            Console.WriteLine("You brave warriors must investigate the rumors of a lost treasure that scores of adventurers have perished attempting to find.");
            Console.WriteLine("_|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|");
            Console.WriteLine("___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|___|__");
            Console.ResetColor();
        }

        public void Execute(ICharacter player)
        {
            var random = new Random();
            var index = random.Next(0, Quest.Count);
            Console.WriteLine();
            Console.WriteLine(Quest[index]);
            Console.WriteLine("What do you want to do?\n\tA) Move\t\t B) Attack with {0}", player.Weapon.Name);

            var action = Choose(player);

            Completed = player.Blood > 70 && action == 1980;
        }

        private int Choose(ICharacter player)
        {
            ICharacter target = new Enemy();

            var random = new Random();

            ConsoleKeyInfo option = Console.ReadKey(true);

            switch (option.Key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;

                case ConsoleKey.A:
                    player.Move(Direction.Up);
                    break;

                case ConsoleKey.B:
                    player.Atack(target);
                    break;
                
            }

            return random.Next(0, 1980);
        }
    }
}
