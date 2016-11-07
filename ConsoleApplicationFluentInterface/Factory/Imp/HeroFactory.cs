using ConsoleApplicationFluentInterface.Entity;
using ConsoleApplicationFluentInterface.Helper;

namespace ConsoleApplicationFluentInterface.Factory.Imp
{
    class HeroFactory : IHeroFactory
    {
        private Hero _hero = null;

        public HeroFactory(Hero hero)
        {
            this._hero = hero;
        }

        public Hero TakeHero()
        {
            return this._hero;
        }

        public IHeroFactory SetForceTo(int forceValue)
        {
            this._hero.InitialForce = forceValue;
            return this;
        }

        public IHeroFactory SetNickName(string nickName)
        {
            this._hero.NickName = nickName;
            return this;
        }

        public IHeroFactory SetGravatar(string filePath)
        {
            this._hero.Gravatar = Tools.GetGravatarPic(filePath);
            return this;
        }

        public IHeroFactory SetColor(string color)
        {
            this._hero.Color = color;
            return this;
        }
    }
}
