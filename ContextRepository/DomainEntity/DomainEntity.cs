using ContextRepository.Enums;

namespace ContextRepository.DomainEntity
{
    internal class DomainEntity :IDomainEntity
    {
        public TypeEnumPool Type => TypeEnumPool.None;
    }
}
