namespace dzTmaSvet.Units.FractionsAndUnits.DarkUnits;

internal class Skeleton : BaseUnit
{
    private Skeleton()
    {
        Hp = 100;
        MinAtack = 10;
        MaxAtack = 15;
        Name = "Skeleton";
        Tage = Tage.Avarage;
    }

    public static Skeleton Instance { get; } = new Skeleton();

    public override int Attack()
    {
        Console.WriteLine("Стреляю!!");
        return RndAttack();
    }

    public override bool TakeDamage(int damage)
    {
        Hp -= damage;
        return Hp > 0;
    }

    public override int Heal() => 0;
}