using ContextRepository.DomainEntity;
using ContextRepository.DomainEntity.Common;
using ContextRepository.DomainEntity.Post;
using ContextRepository.Enums;
using ContextRepository.InfraStructure.Helpers;
using ContextRepository.InfraStructure.Init;
using LightInject;

namespace ContextRepository.InfraStructure.Factories
{
    internal class EntityModelFactory :IEntityModelFactory
    {
        public TDomainModelService Create<TDomainModelService, TDomainModelImp>(IServiceFactory registry) where TDomainModelService : class, IDomainEntity where TDomainModelImp : class, TDomainModelService, new()
        {
            TDomainModelService result = new TDomainModelImp();

            ICompositeViewModelInitializer initializer = result as ICompositeViewModelInitializer;

            switch (result.Type)
            {
                    case TypeEnumPool.Common:
                    initializer.Initialize(registry.GetInstance<ICommonDomainEntity>());
                    break;

                    case TypeEnumPool.Post:
                    initializer.Initialize(registry.GetInstance<IPostDomainEntity>());
                    break;
                default:
                    throw ExceptionHelper.SwitchCaseValueNotSupportedException("EntityModelFactory", result.Type);
            }

            return result;
        }
    }
}
