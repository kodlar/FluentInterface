using ContextRepository.Enums;

namespace ContextRepository.DomainEntity.Common
{
    internal class CommonDomainEntity : ICommonDomainEntity
    {
        public long? Id { get; set; }

        public TypeEnumPool Type => TypeEnumPool.Common;
        
    }
}
