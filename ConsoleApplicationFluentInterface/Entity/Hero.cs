using System.Collections.Generic;

namespace ConsoleApplicationFluentInterface.Entity
{
    public class Hero
    {
        public string NickName { get; set; }

        public string Color { get; set; }

        public byte[] Gravatar { get; set; }

        public int InitialForce { get; set; }

        //public List<Weapon> Weapons { get; set; }
    }
}
