using ConsoleApplicationFluentInterface.Entity;
using ConsoleApplicationFluentInterface.Helper;

namespace ConsoleApplicationFluentInterface.Factory
{
    class ClassicHeroFactory
    {
        public static Hero CreateHero(string nick, string color, string gravatarAddress, int forceValue)
        {
            return new Hero
            {
                Color = color,
                Gravatar = Tools.GetGravatarPic(gravatarAddress),
                NickName = nick,
                InitialForce = forceValue
            };
        }
    }
}
