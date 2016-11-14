using System;
using ContextRepository.DomainEntity.Common;
using ContextRepository.DomainEntity.Post;
using LightInject;

namespace ContextRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceContainer container = new ServiceContainer();

            //ICommonDomainEntity commonEntity = container.GetInstance<ICommonDomainEntity>();
            //commonEntity.Id = 987654321;

            IPostDomainEntity postEntity = container.GetInstance<IPostDomainEntity>();
            postEntity.SeoKeys = "deneme,bilgi";
            postEntity.Title = "biliş";

            Console.WriteLine(postEntity.Title);


            Console.ReadKey();
        }
    }
}
