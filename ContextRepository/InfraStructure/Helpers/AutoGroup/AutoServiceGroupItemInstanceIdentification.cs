using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextRepository.Enums;

namespace ContextRepository.InfraStructure.Helpers.AutoGroup
{
    internal class AutoServiceGroupItemInstanceIdentification<TServiceGroup, TServiceGroupItem, TImp> : IAutoServiceGroupItemInstanceIdentification
        where TServiceGroup : class
        where TServiceGroupItem : class, TServiceGroup
        where TImp : class, TServiceGroupItem
    {
        private readonly string _typeId;

        private readonly Type _serviceGroupType;
        private readonly Type _serviceGroupItemType;
        private readonly Type _implementationType;

        private readonly LifeTimeEnum _lifeTime;

        public string GetTypeId()
        {
            return this._typeId;
        }

        public InstanceIdenfiticationTypeEnum IdentificationType
        {
            get
            {
                return InstanceIdenfiticationTypeEnum.AutoServiceGroup;
            }
        }

        public bool IsRegisteredFor<TRequestedServiceGroup>(LifeTimeEnum? lifeTime = null) where TRequestedServiceGroup : class
        {
            return lifeTime == null || (this._serviceGroupType == typeof(TRequestedServiceGroup) && this._lifeTime == lifeTime);
        }

        public bool IsRegisteredFor<TRequestedServiceGroup, TRequestedServiceGroupItem>(LifeTimeEnum lifeTime = LifeTimeEnum.New)
            where TRequestedServiceGroup : class
            where TRequestedServiceGroupItem : class, TRequestedServiceGroup
        {
            return this._serviceGroupType == typeof(TRequestedServiceGroup) &&
                this._serviceGroupItemType == typeof(TRequestedServiceGroupItem) &&
                this._lifeTime == lifeTime;
        }

        public Type GetServiceGroupItemType()
        {
            return _serviceGroupItemType;
        }

        public Type GetImplementationType()
        {
            return _implementationType;
        }

        public AutoServiceGroupItemInstanceIdentification(LifeTimeEnum lifeTime = LifeTimeEnum.New)
        {
            this._serviceGroupType = typeof(TServiceGroup);
            this._serviceGroupItemType = typeof(TServiceGroupItem);
            this._implementationType = typeof(TImp);

            this._lifeTime = lifeTime;

            StringBuilder typeIdBuilder = new StringBuilder();

#if DEBUG     
            typeIdBuilder.AppendFormat("{0}||{1}||{2}", _serviceGroupType.AssemblyQualifiedName, _serviceGroupItemType.AssemblyQualifiedName, lifeTime);
            //typeIdBuilder.AppendFormat("{0}||{1}||{2}", _serviceGroupType.Name, _serviceGroupItemType.Name, lifeTime);
#endif

#if !DEBUG
            typeIdBuilder.AppendFormat("{0}||{1}||{2}", _serviceGroupType.AssemblyQualifiedName, _serviceGroupItemType.AssemblyQualifiedName, lifeTime);
#endif

            this._typeId = typeIdBuilder.ToString();
        }
    }
}
