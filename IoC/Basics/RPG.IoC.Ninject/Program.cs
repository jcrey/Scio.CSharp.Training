using System;
using Ninject;
using RPG.Core;
using RPG.IoC.Ninject.Stages;

namespace RPG.IoC.Ninject
{
    public class Program
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel(new NinjaGaiden());

            var player1 = kernel.Get<AmericanNinja>();
            var stage1 = kernel.Get<TheKidnapLevel>();
            var game = new Engine(player1) { Points = 10000 };

            game.Run(stage1);

            Console.WriteLine(player1.Blood == 0 ? " GAME OVER " : " YOU WIN ");
            Console.WriteLine("Points: " + game.Points);
        }
    }
}
