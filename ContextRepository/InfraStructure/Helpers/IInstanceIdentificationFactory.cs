using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextRepository.Enums;

namespace ContextRepository.InfraStructure.Helpers
{
    public interface IInstanceIdentificationFactory
    {
        IInstanceIdentification CreateAutoServiceIdentification<TService>(LifeTimeEnum lifeTime = LifeTimeEnum.New) where TService : class;

        IInstanceIdentification CreateAutoServiceGroupIdentification<TServiceGroup, TServiceGroupItem, TImp>(
            LifeTimeEnum lifeTime = LifeTimeEnum.New)
            where TServiceGroup : class
            where TServiceGroupItem : class, TServiceGroup
            where TImp : class, TServiceGroupItem;
    }
}
