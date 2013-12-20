using System;

namespace RPG.Core.Test
{
    public class TestCharacter : ICharacter
    {
        public IPosition Position { get; set; }
        public IWeapon Weapon { get; set; }
        public string Name { get; set; }
        public int Blood { get; set; }

        public void Move(Direction direction)
        {
            Console.WriteLine("move to " + direction);
        }

        public void Atack(ICharacter target)
        {
            Console.WriteLine("attack " + target.Name);
        }
    }
}