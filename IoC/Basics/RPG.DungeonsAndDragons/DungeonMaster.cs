using Ninject.Modules;
using RPG.Core;
using RPG.DungeonsAndDragons.Characters;
using RPG.DungeonsAndDragons.Weapons;

namespace RPG.DungeonsAndDragons
{
    public class DungeonMaster : NinjectModule 
    {
        public override void Load()
        {
            Bind<IWeapon>().To<Sword>().WhenInjectedInto<Warrior>();
            Bind<IWeapon>().To<Bow>().WhenInjectedInto<Elf>();
            Bind<IWeapon>().To<Spell>().WhenInjectedInto<Wizard>();
        }
    }
}
