namespace dzTmaSvet.Units.FractionsAndUnits.LightUnits;

internal class Knight : BaseUnit
{
    public Knight()
    {
        hp = 100;
        minAtack = 12;
        maxAtack = 17;
        name = "Knight";
        tage = Tage.spy;
    }

    public override int Attack()
    {
        Console.WriteLine("Бью!!");
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