namespace dzTmaSvet.Units.FractionsAndUnits.LightUnits;

internal class Crossbowman : BaseUnit
{
    private Crossbowman()
    {
        Hp = 100;
        MinAtack = 12;
        MaxAtack = 17;
        Name = "Crossbowman";
        Tage = Tage.Avarage;
    }

    public static Crossbowman Instance { get; } = new Crossbowman();

    public override int Attack()
    {
        Console.WriteLine("Стерляю!!");
        return RndAttack();
    }

    public override int Heal() => 0;

    public override bool TakeDamage(int damage)
    {
        Hp -= damage;
        return Hp > 0;
    }
}