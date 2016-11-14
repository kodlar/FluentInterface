using ContextRepository.DomainEntity.Common;

namespace ContextRepository.DomainEntity.Post
{
    public interface IPostDomainEntity : ICommonDomainEntity
    {
        string Title { get; set; }

        string SeoKeys { get; set; }
    }
}
