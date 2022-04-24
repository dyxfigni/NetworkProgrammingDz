namespace dzTmaSvet.Units.FractionsAndUnits.LightUnits;

internal class ArchAngel : BaseUnit
{
    /// <inheritdoc />
    private ArchAngel()
    {
        Hp = 100;
        MinAtack = 12;
        MaxAtack = 17;
        Name = "ArchAngel";
        Tage = Tage.Healer;
    }

    public static BaseUnit Instance { get; } = new ArchAngel();

    public override int Attack()
    {
        Console.WriteLine("Освещаю!!");
        return RndAttack();
    }

    public override bool TakeDamage(int damage)
    {
        Hp -= damage;
        return Hp > 0;
    }

    public override int Heal() => new Random().Next(1000) % 30;
}