namespace dzTmaSvet.Units.FractionsAndUnits.LightUnits;

internal class Griphon : BaseUnit
{
    public Griphon()
    {
        hp = 100;
        minAtack = 12;
        maxAtack = 17;
        name = "Griphon";
        tage = Tage.powerfull;
    }

    public override int Attack()
    {
        Console.WriteLine("Кричу!!");
        return rndAttack();
    }

    public override bool takeDamage(int damage)
    {
        hp -= damage;
        return hp > 0;
    }

    public override int Heal()
    {
        return 0;
    }
}