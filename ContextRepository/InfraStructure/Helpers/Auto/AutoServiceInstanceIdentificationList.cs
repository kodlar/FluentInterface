using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextRepository.Enums;

namespace ContextRepository.InfraStructure.Helpers.Auto
{
    public class AutoServiceInstanceIdentificationList : List<IAutoServiceInstanceIdentification>
    {
        public AutoServiceInstanceIdentificationList()
        {
        }

        public AutoServiceInstanceIdentificationList(IEnumerable<IAutoServiceInstanceIdentification> existingIdentifications)
            : base(existingIdentifications)
        {

        }

        public AutoServiceInstanceIdentificationList(IEnumerable<IInstanceIdentification> existingIdentifications)
        {
            IEnumerator<IInstanceIdentification> iterator = existingIdentifications.GetEnumerator();

            IInstanceIdentification currentIdentification = null;

            using (iterator)
            {
                while (iterator.MoveNext())
                {
                    currentIdentification = iterator.Current;

                    if (currentIdentification.IdentificationType == InstanceIdenfiticationTypeEnum.Auto)
                    {
                        this.Add(currentIdentification as IAutoServiceInstanceIdentification);
                    }
                }
            }
        }

        public AutoServiceInstanceIdentificationList(int capacity)
            : base(capacity)
        {
        }

        public IAutoServiceInstanceIdentification FindByService<TService>(LifeTimeEnum lifeTime)
            where TService : class
        {
            int index;
            int count = this.Count;

            IAutoServiceInstanceIdentification current = null;

            for (index = 0; index < count; index++)
            {
                current = this[index];

                if (current.IsRegisteredFor<TService>(lifeTime))
                {
                    return current;
                }
            }

            return null;
        }
    }
}
