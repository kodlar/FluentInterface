namespace ContextRepository.DomainEntity.Common
{
    public interface ICommonDomainEntity :IDomainEntity
    {
        long? Id  { get; set; }
    }
}
