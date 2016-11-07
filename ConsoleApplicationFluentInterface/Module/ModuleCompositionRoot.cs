using ConsoleApplicationFluentInterface.Entity;
using ConsoleApplicationFluentInterface.Factory;
using ConsoleApplicationFluentInterface.Factory.Imp;
using LightInject;

namespace ConsoleApplicationFluentInterface.Module
{
    public class ModuleCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
           serviceRegistry.Register<IHeroFactory>(factory => new HeroFactory(new Hero()), new PerContainerLifetime());
        }
    }
}
