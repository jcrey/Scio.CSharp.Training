using System;

namespace RPG.Core.Test
{
    public class TestSuccessAdventure : IMap
    {
        public TestSuccessAdventure()
        {
            Dificulty = 100;
        }

        public bool Completed { get; set; }
        public int Dificulty { get; set; }
        public void Load()
        {
            Console.WriteLine("Load Map");
        }

        public void Execute(ICharacter player)
        {
            Console.WriteLine("fun fun fun");
            Completed = true; // you kill the dragon
        }
    }

}