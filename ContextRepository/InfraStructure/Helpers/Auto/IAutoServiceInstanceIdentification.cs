using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextRepository.Enums;

namespace ContextRepository.InfraStructure.Helpers.Auto
{
    public interface IAutoServiceInstanceIdentification : IInstanceIdentification
    {
        bool IsRegisteredFor<TRequestedService>(LifeTimeEnum lifeTime = LifeTimeEnum.New)
            where TRequestedService : class;
    }
}
