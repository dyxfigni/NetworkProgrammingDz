namespace dzTmaSvet.Units.FractionsAndUnits.DarkUnits;

internal class Ghost : BaseUnit
{
    public Ghost()
    {
        hp = 20;
        minAtack = 14;
        maxAtack = 35;
        name = "Ghost";
        tage = Tage.tricker;
    }

    public override int Attack()
    {
        Console.WriteLine("Пугаю!!");
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