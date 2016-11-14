using System;
using ContextRepository.Enums;
using ContextRepository.InfraStructure.Helpers;
using ContextRepository.InfraStructure.Helpers.AutoGroup;
using ContextRepository.InfraStructure.Helpers.FunctionWrappers;
using LightInject;

namespace ContextRepository.InfraStructure
{
    public static class LightInjectIocHelper
    {
        #region Service Group Registry (For items that should be in a context)

        #region Registry

        public static void Reg<TServiceGroup, TServiceGroupItem, TImp>(
            IServiceFactory factory, Func<TServiceGroupItem> serviceFactory = null, string serviceName = null, LifeTimeEnum lifeTime = LifeTimeEnum.New)
            where TServiceGroup : class
            where TServiceGroupItem : class, TServiceGroup
            where TImp : class, TServiceGroupItem
        {
            Reg<TServiceGroup, TServiceGroupItem, TImp>((IServiceContainer)factory, serviceFactory, serviceName, lifeTime);
        }

        public static void Reg<TServiceGroup, TServiceGroupItem, TImp>(IServiceRegistry registry,
            Func<TServiceGroupItem> serviceFactory = null, string serviceName = null, LifeTimeEnum lifeTime = LifeTimeEnum.New)
            where TServiceGroup : class
            where TServiceGroupItem : class, TServiceGroup
            where TImp : class, TServiceGroupItem
        {
            Reg<TServiceGroup, TServiceGroupItem, TImp>((IServiceContainer)registry, serviceFactory, serviceName, lifeTime);
        }

        public static void Reg<TServiceGroup, TServiceGroupItem, TImp>(IServiceContainer container,
            Func<TServiceGroupItem> serviceFactory = null, string serviceName = null, LifeTimeEnum lifeTime = LifeTimeEnum.New)

            where TServiceGroup : class
            where TServiceGroupItem : class, TServiceGroup
            where TImp : class, TServiceGroupItem
        {
            if (serviceName == null)
            {
                IAutoServiceGroupItemInstanceIdentification identifier = container.GetInstance<IInstanceIdentificationFactory>()
                    .CreateAutoServiceGroupIdentification<TServiceGroup, TServiceGroupItem, TImp>(lifeTime) as IAutoServiceGroupItemInstanceIdentification;

                string autoName = identifier.GetTypeId();

                System.Diagnostics.Debug.WriteLine(autoName);

                if (serviceFactory == null)
                {
                    if (lifeTime == LifeTimeEnum.New)
                    {
                        container.Register<TServiceGroup, TImp>(autoName);
                    }
                    else
                    {
                        container.Register<TServiceGroup, TImp>(autoName, GetLifeTime(lifeTime));
                    }
                }
                else
                {
                    if (lifeTime == LifeTimeEnum.New)
                    {
                        container.Register<TServiceGroup>(factory => serviceFactory(), autoName);
                    }
                    else
                    {
                        container.Register<TServiceGroup>(factory => serviceFactory(), autoName, GetLifeTime(lifeTime));
                    }
                }

                container.Register<ILFW<TServiceGroup>>(
                    factory => new LFW<TServiceGroupItem>(
                        () => factory.GetInstance<TServiceGroup>(autoName) as TServiceGroupItem, identifier), autoName, new PerContainerLifetime());
            }
            else
            {
                if (lifeTime == LifeTimeEnum.New)
                {
                    container.Register<TServiceGroup, TImp>(serviceName);
                }
                else
                {
                    container.Register<TServiceGroup, TImp>(serviceName, GetLifeTime(lifeTime));
                }
            }
        }

        #endregion

        #region Resolution

        public static TServiceGroupItem Get<TServiceGroup, TServiceGroupItem>(IServiceRegistry container,
                                                                              LifeTimeEnum lifetime = LifeTimeEnum.New)
            where TServiceGroup : class
            where TServiceGroupItem : class, TServiceGroup
        {
            return Get<TServiceGroup, TServiceGroupItem>((IServiceContainer)container, lifetime);
        }

        public static TServiceGroupItem Get<TServiceGroup, TServiceGroupItem>(IServiceFactory container,
                                                                              LifeTimeEnum lifetime = LifeTimeEnum.New)
            where TServiceGroup : class
            where TServiceGroupItem : class, TServiceGroup
        {
            return Get<TServiceGroup, TServiceGroupItem>((IServiceContainer)container, lifetime);
        }

        public static TServiceGroupItem Get<TServiceGroup, TServiceGroupItem>(IServiceContainer container, LifeTimeEnum lifetime = LifeTimeEnum.New)
            where TServiceGroup : class
            where TServiceGroupItem : class, TServiceGroup
        {
            AutoServiceGroupItemInstanceIdentificationList foundIdentifiers =
                new AutoServiceGroupItemInstanceIdentificationList(container.GetAllInstances<IInstanceIdentification>());

            if (foundIdentifiers.Count == 0)
            {
                return null;
            }

            IInstanceIdentification foundIdentifier = foundIdentifiers.FindByService<TServiceGroup, TServiceGroupItem>(lifetime);

            if (foundIdentifier != null)
            {
                return container.GetInstance<TServiceGroup>(foundIdentifier.GetTypeId()) as TServiceGroupItem;
            }

            return null;
        }

        #endregion

        #endregion

        private static ILifetime GetLifeTime(LifeTimeEnum lifeTime)
        {
            switch (lifeTime)
            {
                case LifeTimeEnum.Scoped:
                    return new PerScopeLifetime();

                case LifeTimeEnum.Singleton:
                    return new PerContainerLifetime();

                case LifeTimeEnum.New:
                    return new PerRequestLifeTime();

                default:
                    throw ExceptionHelper.SwitchCaseValueNotSupportedException("Lifetime type does not supported.", lifeTime);
            }
        }
    }
}
