namespace dzTmaSvet.Units.FractionsAndUnits.LightUnits;

internal class Crossbowman : BaseUnit
{
    public Crossbowman()
    {
        hp = 100;
        minAtack = 12;
        maxAtack = 17;
        name = "Crossbowman";
        tage = Tage.avarage;
    }

    public override int Attack()
    {
        Console.WriteLine("Стерляю!!");
        return rndAttack();
    }

    public override int Heal()
    {
        return 0;
    }

    public override bool takeDamage(int damage)
    {
        hp -= damage;
        return hp > 0;
    }
}