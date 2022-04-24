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

    public int Attack()
    {
        Console.WriteLine("Бью!!");
        return rndAttack();
    }

    public int Heal()
    {
        return 0;
    }

    public bool takeDamage(int damage)
    {
        hp -= damage;
        return hp > 0;
    }
}