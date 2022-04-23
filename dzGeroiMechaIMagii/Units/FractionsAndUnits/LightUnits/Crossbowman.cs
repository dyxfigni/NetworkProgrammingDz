using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzTmaSvet.Units.FractionsAndUnits.LightUnits
{
    internal class Crossbowman : BaseUnit
    {
        public Crossbowman()
        {
            hp = 100;
            minAtack = 12;
            maxAtack = 17;
            name = "Crossbowman";
            tage = Tage.avarage;
        }
        public int Attack()
        {
            Console.WriteLine("Стерляю!!");
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
