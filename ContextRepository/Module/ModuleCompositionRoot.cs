using System;
using System.Runtime.Remoting.Messaging;
using ContextRepository.DomainEntity;
using ContextRepository.DomainEntity.Common;
using ContextRepository.DomainEntity.Post;
using ContextRepository.Enums;
using ContextRepository.InfraStructure.Factories;
using ContextRepository.InfraStructure.Helpers;
using ContextRepository.InfraStructure.Helpers.Auto;
using ContextRepository.InfraStructure.Helpers.AutoGroup;
using LightInject;
using IOCH = ContextRepository.InfraStructure.LightInjectIocHelper;
namespace ContextRepository.Module
{
    public class ModuleCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            //Abstracts
            serviceRegistry.Register<IInstanceIdentificationFactory, InstanceIdentificationFactory>(new PerContainerLifetime());

            serviceRegistry.Register<IDomainEntity, DomainEntity.DomainEntity>();
            serviceRegistry.Register<IEntityModelFactory, EntityModelFactory>(new PerContainerLifetime());
            //Defaults
            serviceRegistry.Register<ICommonDomainEntity, CommonDomainEntity>(new PerContainerLifetime());
            //Composits
            //Resolved type 1
            //serviceRegistry.Register<IPostDomainEntity>(factory => new PostDomainEntity(factory.GetInstance<ICommonDomainEntity>()));
            //Resolved type 2
            DomainEntityRegistry.Reg<ICommonDomainEntity, IPostDomainEntity, PostDomainEntity>(serviceRegistry);


            

            

            
            
            

            
            


        }

        public static class DomainEntityRegistry
        {
            public static void Reg<TDomainModelServiceFamily, TDomainModelService, TDomainModelImp>(IServiceRegistry registry, LifeTimeEnum lifeTime = LifeTimeEnum.New)
                where TDomainModelServiceFamily : class, IDomainEntity
                where TDomainModelService : class, TDomainModelServiceFamily
                where TDomainModelImp : class, TDomainModelService, new()
            {
                IServiceContainer iocc = registry as IServiceContainer;

                IOCH.Reg<TDomainModelServiceFamily, TDomainModelService, TDomainModelImp>(iocc,
                    () => iocc.GetInstance<IEntityModelFactory>().Create<TDomainModelImp, TDomainModelImp>(iocc), lifeTime: lifeTime);
            }
        }
    }
}
