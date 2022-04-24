namespace dzTmaSvet.Units.FractionsAndUnits.LightUnits;

internal class Griphon : BaseUnit
{
    private Griphon()
    {
        Hp = 100;
        MinAtack = 12;
        MaxAtack = 17;
        Name = "Griphon";
        Tage = Tage.Powerfull;
    }

    public static Griphon Instance { get; } = new Griphon();

    public override int Attack()
    {
        Console.WriteLine("Кричу!!");
        return RndAttack();
    }
    public override int Heal() => 0;

    public override bool TakeDamage(int damage)
    {
        Hp -= damage;
        return Hp > 0;
    }

}