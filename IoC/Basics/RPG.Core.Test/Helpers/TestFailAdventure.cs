using System;

namespace RPG.Core.Test
{
    public class TestFailAdventure : IMap
    {
        public bool Completed { get; set; }
        public int Dificulty { get; set; }

        public void Load()
        {
            Console.WriteLine("Load Map");
        }

        public void Execute(ICharacter player)
        {
            Console.WriteLine("kill kill kill");
            player.Blood = 0; // you are dead
        }
    }
}