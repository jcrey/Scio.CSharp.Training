using Ninject.Modules;
using RPG.Core;

namespace RPG.IoC.Ninject
{
    public class NinjaGaiden : NinjectModule
    {
        public override void Load()
        {
            Bind<IWeapon>().To<Ninjato>().WhenInjectedInto<AmericanNinja>();
            Bind<IWeapon>().To<Shuriken>().WhenInjectedInto<EvilNinja>();
        }
    }
}