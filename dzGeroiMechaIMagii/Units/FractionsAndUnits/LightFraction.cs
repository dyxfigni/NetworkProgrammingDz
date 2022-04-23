using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dzTmaSvet.Units.FractionsAndUnits.LightUnits;

namespace dzTmaSvet.Units.FractionsAndUnits
{
    internal class LightFraction
    {
        static void createCommand(List<BaseUnit> command, Level level)
        {
            int commandSize = CommandSize(level);
            for (int i = 0; i < commandSize; i++)
            {
                switch ((new Random().Next(10)) % 6)
                {
                    case 3:
                        switch ((new Random().Next(10)) % 2)
                        {
                            case 0:
                                command.Add(new Archer());
                                break;
                            case 1:
                                command.Add(new Crossbowman());
                                break;
                        }
                        break;
                    case 4:
                        switch ((new Random().Next(10)) % 2)
                        {
                            case 0:
                                command.Add(new Knight());
                                break;
                            case 1: 
                                command.Add(new Griphon());
                                break;
                        }
                        break;
                    case 5:
                        switch ((new Random().Next(10)) % 2)
                        {
                            case 0:
                                command.Add(new Angel());
                                break;
                            case 1:
                                command.Add(new ArchAngel());
                                break;
                        }
                        break;
                }
            }
        }

        static int CommandSize(Level level)
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
    }
}
