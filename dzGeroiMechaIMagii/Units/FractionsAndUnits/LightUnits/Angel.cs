namespace dzTmaSvet.Units.FractionsAndUnits.LightUnits;

internal class Angel : BaseUnit
{
    private Angel()
    {
        hp = 100;
        minAtack = 12;
        maxAtack = 17;
        name = "Angel";
        tage = Tage.tricker;
    }

    public override int Attack()
    {
        Console.WriteLine("Колдую!!");
        return rndAttack();
    }

    public override bool takeDamage(int damage)
    {
        hp -= damage;
        return hp > 0;
    }

    public override int Heal()
    {
        return new Random().Next() % 0;
    }
}