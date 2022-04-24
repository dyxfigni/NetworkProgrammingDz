namespace dzTmaSvet.Units.FractionsAndUnits.DarkUnits;

internal class Zombie : BaseUnit
{
    public Zombie()
    {
        hp = 100;
        minAtack = 12;
        maxAtack = 17;
        name = "Zombie";
        tage = Tage.avarage;
    }

    public override int Attack()
    {
        Console.WriteLine("Бью!!");
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