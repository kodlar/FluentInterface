using ContextRepository.Enums;

namespace ContextRepository.DomainEntity
{
    public interface IDomainEntity
    {
        TypeEnumPool Type { get; }
    }
}
