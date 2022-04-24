namespace dzTmaSvet.Units.FractionsAndUnits.LightUnits;

internal class Archer : BaseUnit
{
    private Archer()
    {
        Hp = 80;
        MinAtack = 16;
        MaxAtack = 23;
        Name = "Archer";
        Tage = Tage.Avarage;
    }
    
    public static Archer Instance { get; } = new Archer();

    public override int Attack()
    {
        Console.WriteLine("Стреляю!!");
        return RndAttack();
    }

    public override int Heal() => 0;

    public override bool TakeDamage(int damage)
    {
        Hp -= damage;
        return Hp > 0;
    }
}