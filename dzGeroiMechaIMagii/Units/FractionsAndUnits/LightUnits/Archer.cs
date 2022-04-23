using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzTmaSvet.Units.FractionsAndUnits.LightUnits
{
    internal class Archer : BaseUnit
    {
        public Archer()
        {
            hp = 80;
            minAtack = 16;
            maxAtack = 23;
            name = "Archer";
            tage = Tage.avarage;
        }

        public int Attack()
        {
            Console.WriteLine("Стреляю!!");
            return rndAttack();
        }

        public int Heal()
        {
            return 0;
        }

        public bool takeDamage(int damage)
        {
            hp -= damage;
            return hp > 0;
        }
    }
}
