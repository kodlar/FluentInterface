using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextRepository.Enums;

namespace ContextRepository.InfraStructure.Helpers.Auto
{
    internal class AutoServiceInstanceIdentification<TService> : IAutoServiceInstanceIdentification
        where TService : class
    {
        private readonly string _typeId;

        private readonly Type _serviceType;
        private readonly LifeTimeEnum _lifeTime;

        public string GetTypeId()
        {
            return this._typeId;
        }

        public InstanceIdenfiticationTypeEnum IdentificationType
        {
            get
            {
                return InstanceIdenfiticationTypeEnum.Auto;
            }
        }

        public bool IsRegisteredFor<TRequestedService>(LifeTimeEnum lifeTime = LifeTimeEnum.New) where TRequestedService : class
        {
            return _serviceType == typeof(TRequestedService) && _lifeTime == lifeTime;
        }

        public AutoServiceInstanceIdentification(LifeTimeEnum lifeTime = LifeTimeEnum.New)
        {
            _serviceType = typeof(TService);

            _lifeTime = lifeTime;

            StringBuilder typeIdBuilder = new StringBuilder();

            typeIdBuilder.AppendFormat("{0}||{1}", _serviceType.Name, lifeTime);

            this._typeId = typeIdBuilder.ToString();
        }
    }
}
