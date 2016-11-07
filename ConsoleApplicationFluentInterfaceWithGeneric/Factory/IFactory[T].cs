using System;
using System.Linq.Expressions;

namespace ConsoleApplicationFluentInterfaceWithGeneric.Factory
{
    public interface IFactory<T>
    {
        IFactory<T> SetPropertyValue(string propertyName, object propertyValue);
        IFactory<T> SetProperty(Expression<Func<T,object>>  property, object propertyValue);
        T Take();
    }
}
