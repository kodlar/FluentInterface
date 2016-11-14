using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextRepository.Enums;
using ContextRepository.InfraStructure.Helpers.Auto;
using ContextRepository.InfraStructure.Helpers.AutoGroup;

namespace ContextRepository.InfraStructure.Helpers
{
    internal class InstanceIdentificationFactory : IInstanceIdentificationFactory
    {
        public IInstanceIdentification CreateAutoServiceIdentification<TService>(LifeTimeEnum lifeTime = LifeTimeEnum.New) where TService : class
        {
            return new AutoServiceInstanceIdentification<TService>(lifeTime);
        }

        public IInstanceIdentification CreateAutoServiceGroupIdentification<TServiceGroup, TServiceGroupItem, TImp>(
            LifeTimeEnum lifeTime = LifeTimeEnum.New)
            where TServiceGroup : class
            where TServiceGroupItem : class, TServiceGroup
            where TImp : class, TServiceGroupItem
        {
            return new AutoServiceGroupItemInstanceIdentification<TServiceGroup, TServiceGroupItem, TImp>(lifeTime);
        }
    }
}
