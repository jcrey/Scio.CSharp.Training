using System;
using RPG.Core;

namespace RPG.DungeonsAndDragons.Characters
{
    public class Enemy : ICharacter
    {
        public IWeapon Weapon { get; set; }
        public string Name { get; set; }
        public int Blood { get; set; }

        public void Move(Direction direction)
        {
            throw new NotImplementedException();
        }

        public void Atack(ICharacter target)
        {
            var random = new Random();
            target.Blood -= random.Next(0, 5);
        }
    }
}
