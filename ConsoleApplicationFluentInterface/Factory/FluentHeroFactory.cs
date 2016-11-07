using LightInject;

namespace ConsoleApplicationFluentInterface.Factory
{
    static class FluentHeroFactory
    {
        public static IHeroFactory Init(IServiceContainer container)
        {         
            return container.GetInstance<IHeroFactory>();
            //return new HeroFactory(new Hero());
        }
    }
}
