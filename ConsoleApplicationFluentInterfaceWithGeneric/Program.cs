using System;
using ConsoleApplicationFluentInterfaceWithGeneric.DomainEntity;
using ConsoleApplicationFluentInterfaceWithGeneric.Factory;
using ConsoleApplicationFluentInterfaceWithGeneric.Factory.Imp;
using LightInject;

namespace ConsoleApplicationFluentInterfaceWithGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceContainer container = new ServiceContainer();

            Player player = FluentFactory<Player>.Init(container)
                                     .SetPropertyValue("NickName", "Hasan")
                                     .SetPropertyValue("LastLevel", 1)
                                     .Take();

            Tank superTank = FluentFactory<Tank>.Init(container)
                                   .SetPropertyValue("Type", "T50")
                                   .SetPropertyValue("Range", Convert.ToDecimal(3.5))
                                   .SetPropertyValue("Side", "4x4")
                                   .Take();

            //string olmadan bilakis tipe göre değer vermece
            Tank superStrongTypeTank = FluentFactory<Tank>.Init(container)
                                   .SetProperty(p => p.Type, "T45")
                                   .SetProperty(p => p.Range, Convert.ToDecimal(2.5))
                                   .SetProperty(p => p.Side, "test")
                                   .Take();

        }
    }
}
