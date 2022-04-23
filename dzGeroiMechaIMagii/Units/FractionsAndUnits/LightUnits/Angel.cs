using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzTmaSvet.Units.FractionsAndUnits.LightUnits
{
    internal class Angel : BaseUnit
    {
        public Angel()
        {
            hp = 100;
            minAtack = 12;
            maxAtack = 17;
            name = "Angel";
            tage = Tage.tricker;
        }

        public int Attack()
        {
            Console.WriteLine("Колдую!!");
            return rndAttack();
        }

        public bool takeDamage(int damage)
        {
            hp -= damage;
            return hp > 0;
        }

        private int Heal()
        {
            return (new Random().Next()) % 0;
        }
    }
}
