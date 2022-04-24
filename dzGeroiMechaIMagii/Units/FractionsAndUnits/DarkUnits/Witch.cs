namespace dzTmaSvet.Units.FractionsAndUnits.DarkUnits;

internal class Witch : BaseUnit
{
    public Witch()
    {
        hp = 70;
        minAtack = 20;
        maxAtack = 25;
        name = "Witch";
        tage = Tage.healer;
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
        return new Random().Next(500) % 10;
    }
}