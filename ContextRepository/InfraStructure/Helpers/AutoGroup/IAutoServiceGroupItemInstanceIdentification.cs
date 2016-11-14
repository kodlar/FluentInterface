using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextRepository.Enums;

namespace ContextRepository.InfraStructure.Helpers.AutoGroup
{
    public interface IAutoServiceGroupItemInstanceIdentification : IInstanceIdentification
    {
        bool IsRegisteredFor<TRequestedServiceGroup>(LifeTimeEnum? lifeTime = null) where TRequestedServiceGroup : class;

        bool IsRegisteredFor<TRequestedServiceGroup, TRequestedServiceGroupItem>(
            LifeTimeEnum lifeTime)
            where TRequestedServiceGroup : class
            where TRequestedServiceGroupItem : class, TRequestedServiceGroup;

        Type GetImplementationType();
    }
}
