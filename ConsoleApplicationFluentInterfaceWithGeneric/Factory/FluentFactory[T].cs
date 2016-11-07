using LightInject;
namespace ConsoleApplicationFluentInterfaceWithGeneric.Factory
{
    static class FluentFactory<T> where T : class, new()
    {
        public static IFactory<T> Init(IServiceContainer container)
        {
            container.RegisterInstance(new T());
            return container.GetInstance<IFactory<T>>();
            //return new Factory<T>(new T());
        }
    }
}

