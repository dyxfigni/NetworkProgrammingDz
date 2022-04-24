namespace dzTmaSvet.Units.FractionsAndUnits.DarkUnits;

internal class Ghost : BaseUnit
{
    private Ghost()
    {
        Hp = 20;
        MinAtack = 14;
        MaxAtack = 35;
        Name = "Ghost";
        Tage = Tage.Tricker;
    }

    public static Ghost Instance { get; } = new Ghost();

    public override int Attack()
    {
        Console.WriteLine("Пугаю!!");
        return RndAttack();
    }

    public override bool TakeDamage(int damage)
    {
        Hp -= damage;
        return Hp > 0;
    }

    public override int Heal() => 0;
}