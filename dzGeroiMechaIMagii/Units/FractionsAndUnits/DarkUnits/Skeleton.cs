using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzTmaSvet.Units.FractionsAndUnits.DarkUnits
{
    internal class Skeleton : BaseUnit
    {
        public Skeleton()
        {
            hp = 100;
            minAtack = 10;
            maxAtack = 15;
            name = "Skeleton";
            tage = Tage.avarage;
        }
        public int Attack()
        {
            Console.WriteLine("Стреляю!!");
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
