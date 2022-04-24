namespace dzTmaSvet.Units.FractionsAndUnits.DarkUnits;

internal class Vampire : BaseUnit
{
    private Vampire()
    {
        Hp = 50;
        MinAtack = 28;
        MaxAtack = 32;
        Name = "Vampire";
        Tage = Tage.Spy;
    }

    public static Vampire Instance { get; } = new Vampire();

    public override int Attack()
    {
        Console.WriteLine("Кусаю!!");
        return RndAttack();
    }

    public override bool TakeDamage(int damage)
    {
        Hp -= damage;
        return Hp > 0;
    }

    public override int Heal() => 0;
}