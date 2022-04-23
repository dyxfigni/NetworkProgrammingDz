using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzTmaSvet.Units.FractionsAndUnits.DarkUnits
{
    internal class Zombie : BaseUnit
    {
        public Zombie()
        {
            hp = 100;
            minAtack = 12;
            maxAtack = 17;
            name = "Zombie";
            tage = Tage.avarage;
        }

        public int Attack()
        {
            Console.WriteLine("Бью!!");
            return rndAttack();
        }

        public bool takeDamage(int damage)
        {
            hp -= damage;
            return hp > 0;
        }

        public int Heal()
        {
            return 0;
        }
    }
}
