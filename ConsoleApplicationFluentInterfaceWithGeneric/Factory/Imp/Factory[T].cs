using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ConsoleApplicationFluentInterfaceWithGeneric.Factory.Imp
{
    internal class Factory<T> : IFactory<T>
    {
        private T _instance;

        public Factory(T instance)
        {
            this._instance = instance;
        }

        public IFactory<T> SetPropertyValue(string propertyName, object propertyValue)
        {
            var pInfo = this._instance.GetType().GetProperty(propertyName);

            pInfo?.SetValue(this._instance, propertyValue);

            return this;
        }

        public IFactory<T> SetProperty(Expression<Func<T, object>> property, object propertyValue)
        {
            PropertyInfo pInfo = null;

            if (property.Body is MemberExpression)
            {
                pInfo = (property.Body as MemberExpression).Member as PropertyInfo;
            }
            else
            {
                pInfo = (((UnaryExpression)property.Body).Operand as MemberExpression).Member as PropertyInfo;
            }

            pInfo.SetValue(this._instance, propertyValue);

            return this;
        }

        public T Take()
        {
            return this._instance;
        }
    }
}


