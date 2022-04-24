namespace dzTmaSvet.Units.FractionsAndUnits.LightUnits;

internal class Angel : BaseUnit
{
    /// <inheritdoc />
    private Angel()
    {
        Hp = 100;
        MinAtack = 12;
        MaxAtack = 17;
        Name = "Angel";
        Tage = Tage.Tricker;
    }

    public static Angel Instance { get; } = new Angel();


    public override int Attack()
    {
        Console.WriteLine("Колдую!!");
        return RndAttack();
    }

    public override bool TakeDamage(int damage)
    {
        Hp -= damage;
        return Hp > 0;
    }

    public override int Heal() => new Random().Next() % 0;
}