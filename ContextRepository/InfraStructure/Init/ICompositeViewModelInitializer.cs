using ContextRepository.DomainEntity;

namespace ContextRepository.InfraStructure.Init
{
    public interface ICompositeViewModelInitializer
    {
        void Initialize(IDomainEntity compositeViewModel);
    }
}
