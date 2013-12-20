using System;
using Ninject;
using RPG.Core;

namespace RPG.IoC.Ninject
{
    public class EvilNinja : ICharacter
    {
        [Inject]
        public IWeapon Weapon { get; set; }
        public string Name { get; set; }
        public int Blood { get; set; }

        public void Move(Direction direction)
        {
            Console.WriteLine(direction);
        }

        public void Atack(ICharacter target)
        {
           Weapon.Use();
            target.Blood -= Weapon.Damage;
        }
    }
}