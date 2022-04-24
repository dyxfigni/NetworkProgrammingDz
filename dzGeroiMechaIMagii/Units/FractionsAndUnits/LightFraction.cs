using dzTmaSvet.Units.FractionsAndUnits.LightUnits;

namespace dzTmaSvet.Units.FractionsAndUnits;

internal static class LightFraction
{
    public static List<BaseUnit> CreateCommand(List<BaseUnit> command, Level level)
    {
        var commandSize = CommandSize(level);
        for (var i = 0; i < commandSize; i++)
            switch (new Random().Next(10) % 6)
            {
                case 3:
                    switch (new Random().Next(10) % 2)
                    {
                        case 0:
                            command.Add(Archer.Instance);
                            break;
                        case 1:
                            command.Add(Crossbowman.Instance);
                            break;
                    }

                    break;
                case 4:
                    switch (new Random().Next(10) % 2)
                    {
                        case 0:
                            command.Add(Knight.Instance);
                            break;
                        case 1:
                            command.Add(Griphon.Instance);
                            break;
                    }

                    break;
                case 5:
                    switch (new Random().Next(10) % 2)
                    {
                        case 0:
                            command.Add(Angel.Instance);
                            break;
                        case 1:
                            command.Add(ArchAngel.Instance);
                            break;
                    }

                    break;
            }

        return command;
    }

    private static int CommandSize(Level level)
    {
        var random = new Random().Next(5);

        switch (level)
        {
            case Level.LevelEasy:
                return random % 5 + 5;
                break;
            case Level.LevelMedium:
                return random % 5 + 10;
                break;
            case Level.LevelHard:
                return random % 5 + 20;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(level), level, null);
        }
    }
}