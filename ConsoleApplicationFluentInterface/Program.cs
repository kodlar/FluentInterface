using System;
using ConsoleApplicationFluentInterface.Entity;
using ConsoleApplicationFluentInterface.Factory;
using ConsoleApplicationFluentInterface.Helper;
using LightInject;

namespace ConsoleApplicationFluentInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.yöntem nesne başlatıcı ile nesnenin özelliklerini doldurmak
            
            Hero boromir = new Hero()
                           {
                               Color = "Red",
                               Gravatar = Tools.GetGravatarPic("C:\\avatar.jpg"),
                               InitialForce = 50,
                               NickName = "best"
                           };
            
            //2.yöntem klasik nesne yaratmak için factory kullanmak
            Hero vladamir = ClassicHeroFactory.CreateHero("best2", "yellow", "C:\\avatar.png", 29);

            //3.yöntem fluentinterface tasarımı kullanarak nesneyi oluşturmak
            IServiceContainer container = new ServiceContainer();
            Hero myHero = FluentHeroFactory.Init(container)
                                 .SetColor("blue")
                                 .SetForceTo(100)
                                 .SetGravatar("C:\\avatar.png")
                                 .SetNickName("WildAnimal")
                                 .TakeHero();
            

        }
    }
 


   



    
   
}
