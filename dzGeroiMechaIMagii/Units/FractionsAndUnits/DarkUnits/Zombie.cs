namespace dzTmaSvet.Units.FractionsAndUnits.DarkUnits;

internal class Zombie : BaseUnit
{
    private Zombie()
    {
        Hp = 100;
        MinAtack = 12;
        MaxAtack = 17;
        Name = "Zombie";
        Tage = Tage.Avarage;
    }

    public static Zombie Instance { get; } = new Zombie();

    public override int Attack()
    {
        Console.WriteLine("Бью!!");
        return RndAttack();
    }

    public override bool TakeDamage(int damage)
    {
        Hp -= damage;
        return Hp > 0;
    }

    public override int Heal() => 0;
}