using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzTmaSvet.Units.FractionsAndUnits.DarkUnits
{
    internal class Vampire : BaseUnit
    {
        public Vampire()
        {
            hp = 50;
            minAtack = 28;
            maxAtack = 32;
            name = "Vampire";
            tage = Tage.spy;
        }
        public int Attack()
        {
            Console.WriteLine("Кусаю!!");
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
