using ContextRepository.DomainEntity;
using LightInject;

namespace ContextRepository.InfraStructure.Factories
{
    public interface IEntityModelFactory
    {
        TDomainModelService Create<TDomainModelService, TDomainModelImp>(IServiceFactory registry)
           where TDomainModelService : class, IDomainEntity
           where TDomainModelImp : class, TDomainModelService, new();
    }
}
