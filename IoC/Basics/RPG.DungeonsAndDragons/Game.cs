using System;
using Ninject;
using RPG.Core;
using RPG.DungeonsAndDragons.Adventure;
using RPG.DungeonsAndDragons.Characters;

namespace RPG.DungeonsAndDragons
{
    public class Game
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel(new DungeonMaster());

            WelcomePlayer();

            ICharacter adventurer = SetupCharacter(kernel);

            if (adventurer == null) return;

            var adventure = kernel.Get<TheLostCavernsOfTsojcanth>();

            var game = new Engine(adventurer) { Points = 0 };

            game.Run(adventure);
        }

        private static ICharacter SetupCharacter(IKernel kernel)
        {
            ICharacter adventurer = null;
            do
            {
                ConsoleKeyInfo option = Console.ReadKey();
                switch (option.Key)
                {
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.A:
                        adventurer = kernel.Get<Warrior>();
                        Console.WriteLine("You are a Warrior");
                        break;
                    case ConsoleKey.B:
                        adventurer = kernel.Get<Elf>();
                        Console.WriteLine("You are a Elf");
                        break;
                    case ConsoleKey.C:
                        adventurer = kernel.Get<Wizard>();
                        Console.WriteLine("You are a Wizard");
                        break;
                }
            } while (adventurer == null);

            Console.WriteLine("Give a new name to your character\nName:");
            adventurer.Name = Console.ReadLine();

            return adventurer;
        }

        private static void WelcomePlayer()
        {
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@**^^\"\"~~~\"^@@^*@*@@**@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@*^^'\"~   , - ' '; ,@@b. '  -e@@@@@@@@@");
            Console.WriteLine("@@@@@@@@*^\"~      . '     . ' ,@@@@(  e@*@@@@@@@@@@");
            Console.WriteLine("@@@@@^~         .       .   ' @@@@@@, ~^@@@@@@@@@@@");
            Console.WriteLine("@@@~ ,e**@@*e,  ,e**e, .    ' '@@@@@@e,  \"*@@@@@'^@");
            Console.WriteLine("@',e@@@@@@@@@@ e@@@@@@       ' '*@@@@@@    @@@'   0");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@',e,     ;  ~^*^'    ;^~   ' 0");
            Console.WriteLine("@@@@@@@@@@@@@@@^\"\"^@@e@@@   .'           ,'   .'  @");
            Console.WriteLine("@@@@@@@@@@@@@@'    '@@@@@ '         ,  ,e'  .    ;@");
            Console.WriteLine("@@@@@@@@@@@@@' ,&&,  ^@*'     ,  .  i^\"@e, ,e@e  @@");
            Console.WriteLine("@@@@@@@@@@@@' ,@@@@,          ;  ,& !,,@@@e@@@@ e@@");
            Console.WriteLine("@@@@@,~*@@*' ,@@@@@@e,   ',   e^~^@,   ~'@@@@@@,@@@");
            Console.WriteLine("@@@@@@, ~\" ,e@@@@@@@@@*e*@*  ,@e  @@\"\"@e,,@@@@@@@@@");
            Console.WriteLine("@@@@@@@@ee@@@@@@@@@@@@@@@\" ,e@' ,e@' e@@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@\" ,@\" ,e@@e,,@@@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@~ ,@@@,,0@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@,,@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("\n\n");
            Console.WriteLine("Choose a Character and choose wisely:\n");
            Console.WriteLine("[A] Warrior\t[B] Elf\t[C] Wizard");
        }
    }
}
