namespace dzTmaSvet.Units.FractionsAndUnits.LightUnits;

internal class Knight : BaseUnit
{
    /// <inheritdoc />
    private Knight()
    {
        Hp = 100;
        MinAtack = 12;
        MaxAtack = 17;
        Name = "Knight";
        Tage = Tage.Spy;
    }
    public static Knight Instance { get; } = new Knight();

    public override int Attack()
    {
        Console.WriteLine("Бью!!");
        return RndAttack();
    }

    public override int Heal() => 0;

    public override bool TakeDamage(int damage)
    {
        Hp -= damage;
        return Hp > 0;
    }
}