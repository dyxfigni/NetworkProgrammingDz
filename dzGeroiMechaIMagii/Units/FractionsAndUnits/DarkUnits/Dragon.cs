namespace dzTmaSvet.Units.FractionsAndUnits.DarkUnits;

internal class Dragon : BaseUnit
{
    private Dragon()
    {
        Hp = 150;
        MinAtack = 10;
        MaxAtack = 40;
        Name = "Dragon";
        Tage = Tage.Powerfull;
    }
    public static Dragon Instance { get; } = new Dragon();

    public override int Attack()
    {
        Console.WriteLine("Испепеляю!!");
        return RndAttack();
    }

    public override bool TakeDamage(int damage)
    {
        Hp -= damage;
        return Hp > 0;
    }

    public override int Heal() => 0;
}