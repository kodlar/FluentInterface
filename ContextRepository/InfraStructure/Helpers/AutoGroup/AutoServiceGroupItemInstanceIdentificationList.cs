using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextRepository.Enums;

namespace ContextRepository.InfraStructure.Helpers.AutoGroup
{
    internal class AutoServiceGroupItemInstanceIdentificationList : List<IAutoServiceGroupItemInstanceIdentification>
    {
        public AutoServiceGroupItemInstanceIdentificationList()
        {
        }

        public AutoServiceGroupItemInstanceIdentificationList(
            IEnumerable<IAutoServiceGroupItemInstanceIdentification> existingIdentifications)
            : base(existingIdentifications)
        {

        }

        public AutoServiceGroupItemInstanceIdentificationList(
            IEnumerable<IInstanceIdentification> existingIdentifications)
        {
            IEnumerator<IInstanceIdentification> iterator = existingIdentifications.GetEnumerator();

            IInstanceIdentification currentIdentification = null;

            using (iterator)
            {
                while (iterator.MoveNext())
                {
                    currentIdentification = iterator.Current;

                    if (currentIdentification.IdentificationType == InstanceIdenfiticationTypeEnum.AutoServiceGroup)
                    {
                        this.Add(currentIdentification as IAutoServiceGroupItemInstanceIdentification);
                    }
                }
            }
        }

        public AutoServiceGroupItemInstanceIdentificationList(int capacity)
            : base(capacity)
        {
        }

        public IAutoServiceGroupItemInstanceIdentification FindByService<TServiceGroup, TServiceGroupItem>(
            LifeTimeEnum lifeTime) where TServiceGroup : class where TServiceGroupItem : class, TServiceGroup
        {
            int index;
            int count = this.Count;

            IAutoServiceGroupItemInstanceIdentification current = null;

            for (index = 0; index < count; index++)
            {
                current = this[index];

                if (current.IsRegisteredFor<TServiceGroup, TServiceGroupItem>(lifeTime))
                {
                    return current;
                }
            }

            return null;
        }
    }
}
