using System;
using System.Collections.Generic;
using System.Linq;
using RPG.Core;

namespace RPG.IoC.Ninject.Stages
{
    public class TheKidnapLevel : IMap
    {
        public bool Completed { get; set; }
        public int Dificulty { get; set; }
        private readonly IList<EvilNinja> Enemies = new List<EvilNinja>();

        public TheKidnapLevel()
        {
            for (int i = 0; i < 4; i++)
            {
                Enemies.Add(new EvilNinja { Blood = 30, Name = "Ninja-" + i, Weapon = new Shuriken()});
            }
        }

        public void Load()
        {
            Dificulty = 1000;
            Console.WriteLine("Your girlfriend was kidnapped by evil ninjas...");
        }

        public void Execute(ICharacter player)
        {
            Console.WriteLine("Blood: {0}", player.Blood);

            Input(player);

            foreach (var enemy in Enemies)
            {
                enemy.Atack(player);
            }

            Completed = Enemies.Count == 0;
        }

        private void Input(ICharacter player)
        {
            var info = Console.ReadKey();

            switch (info.Key)
            {
                case ConsoleKey.Spacebar:
                    var ninja = Enemies.FirstOrDefault();

                    player.Atack(ninja);

                    if (ninja != null && ninja.Blood == 0)
                    {
                        Enemies.Remove(ninja);
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    player.Move(Direction.Left);
                    break;

                case ConsoleKey.UpArrow:
                    player.Move(Direction.Up);
                    break;

                case ConsoleKey.RightArrow:
                    player.Move(Direction.Right);
                    break;

                case ConsoleKey.DownArrow:
                    player.Move(Direction.Down);
                    break;
            }
        }
    }
}
