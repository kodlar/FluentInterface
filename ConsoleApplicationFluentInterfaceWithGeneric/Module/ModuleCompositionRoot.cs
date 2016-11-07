using System.Reflection;
using ConsoleApplicationFluentInterfaceWithGeneric.Factory;
using LightInject;
using ConsoleApplicationFluentInterfaceWithGeneric.Factory.Imp;

namespace ConsoleApplicationFluentInterfaceWithGeneric.Module
{
    public class ModuleCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            
            serviceRegistry.Register(typeof(IFactory<>), typeof(Factory<>), new PerContainerLifetime());
        }
    }
}
