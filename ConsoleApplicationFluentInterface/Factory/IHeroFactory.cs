using ConsoleApplicationFluentInterface.Entity;

namespace ConsoleApplicationFluentInterface.Factory
{
    public interface IHeroFactory
    {
        Hero TakeHero();

        IHeroFactory SetForceTo(int forceValue);

        IHeroFactory SetNickName(string nickName);

        IHeroFactory SetGravatar(string filePath);

        IHeroFactory SetColor(string color);
    }
}
