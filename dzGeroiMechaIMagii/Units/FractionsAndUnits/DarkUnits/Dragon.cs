namespace dzTmaSvet.Units.FractionsAndUnits.DarkUnits;

internal class Dragon : BaseUnit
{
    public Dragon()
    {
        hp = 150;
        minAtack = 10;
        maxAtack = 40;
        name = "Dragon";
        tage = Tage.powerfull;
    }

    public override int Attack()
    {
        Console.WriteLine("Испепеляю!!");
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