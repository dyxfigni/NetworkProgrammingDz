namespace dzTmaSvet.Units.FractionsAndUnits.DarkUnits;

internal class Witch : BaseUnit
{
    private Witch()
    {
        Hp = 70;
        MinAtack = 20;
        MaxAtack = 25;
        Name = "Witch";
        Tage = Tage.Healer;
    }

    public static Witch Instance { get; } = new Witch();

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

    public override int Heal() => new Random().Next(500) % 10;
}