namespace dzTmaSvet.Units.FractionsAndUnits.DarkUnits;

internal class Vampire : BaseUnit
{
    public Vampire()
    {
        hp = 50;
        minAtack = 28;
        maxAtack = 32;
        name = "Vampire";
        tage = Tage.spy;
    }

    public override int Attack()
    {
        Console.WriteLine("Кусаю!!");
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