namespace dzTmaSvet.Units;

internal enum Level
{
    LevelEasy,
    LevelMedium,
    LevelHard
}

internal enum Tage
{
    Avarage,
    Healer,
    Spy,
    Tricker,
    Powerfull
}

internal interface IUnit
{
    public int Attack();
    public bool TakeDamage(int damage);
    public int Heal();
}

internal abstract class BaseUnit : IUnit
{
    private protected int MinAtack { get; set; }
    private protected int MaxAtack { get; set; }
    private protected int Hp { get; set; }
    private protected Tage Tage { get; set; } // ноль - мечник, 1 - стрелок, 2 - маг, 3 - дракон
    private protected string? Name { get; set; }
     
    public int GetHp => Hp;
    public Tage GetTage => Tage;
    public string? GetName => Name;

    public abstract int Attack();
    public abstract int Heal();
    public abstract bool TakeDamage(int damage);

    private protected int RndAttack()
    {
        return new Random().Next(100) % (MaxAtack - MinAtack) + MinAtack;
    }

    public int CommandSize(Level level)
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

    public void SetHp(int hp)
    {
        this.Hp += hp;
    }

    public string ToString()
    {
        return Name +
               ": hp= " + Hp +
               ", attack= " + MinAtack +
               "/" + MaxAtack;
    }
}