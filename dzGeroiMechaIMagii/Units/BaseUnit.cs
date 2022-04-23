using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzTmaSvet.Units
{
    enum Level
    {
        LEVEL_EASY,
        LEVEL_MEDIUM,
        LEVEL_HARD
    }

    enum Tage
    {
        avarage,
        healer,
        spy,
        tricker,
        powerfull
    }

    interface IUnit
    {
        public int Attack();
        public bool takeDamage(int damage);
        public int Heal();
    }

	internal abstract class BaseUnit : IUnit
    {
        private protected int minAtack { get; set; }
        private protected int maxAtack { get; set; }
        private protected int hp { get; set; }
        private protected Tage tage { get; set; } // ноль - мечник, 1 - стрелок, 2 - маг, 3 - дракон
        private protected string name { get; set; }
        private protected int rndAttack() => (new Random().Next(100)) % (maxAtack - minAtack) + minAtack;

        public int CommandSize(Level level)
        {
            int random = new Random().Next(5);

            switch (level)
            {
                case Level.LEVEL_EASY:
                    return random % 5 + 5;
                    break;
                case Level.LEVEL_MEDIUM:
                    return random % 5 + 10;
                    break;
                case Level.LEVEL_HARD:
                    return random % 5 + 20;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }
        }

        public void setHp(int hp) => this.hp += hp;

        public int getHp => hp;
        public Tage getTage => tage;
        public string getName => name;
        public string toString() =>
                    name +
                    ": hp= " + this.hp + 
                    ", attack= " + this.minAtack + 
                    "/" + this.maxAtack;

        public int Attack()
        {
            throw new NotImplementedException();
        }

        public bool takeDamage(int damage)
        {
            throw new NotImplementedException();
        }

        public int Heal()
        {
            throw new NotImplementedException();
        }
    }
}
