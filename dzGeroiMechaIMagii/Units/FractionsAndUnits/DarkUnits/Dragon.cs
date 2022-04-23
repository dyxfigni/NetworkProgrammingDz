using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzTmaSvet.Units.FractionsAndUnits.DarkUnits
{
    internal class Dragon : BaseUnit
    {
        public Dragon()
        {
            hp = 150;
            minAtack = 10;
            maxAtack = 40;
            name = "Dragon";
            tage = Tage.powerfull;
        }
        public int Attack()
        {
            Console.WriteLine("Испепеляю!!");
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
