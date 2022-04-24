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

    public int Attack()
    {
        Console.WriteLine("Кричу!!");
        return rndAttack();
    }

    public bool takeDamage(int damage)
    {
        hp -= damage;
        return hp > 0;
    }

    public int Heal()
    {
        return 0;
    }
}