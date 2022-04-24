namespace dzTmaSvet.Units.FractionsAndUnits.LightUnits;

internal class ArchAngel : BaseUnit
{
    public ArchAngel()
    {
        hp = 100;
        minAtack = 12;
        maxAtack = 17;
        name = "ArchAngel";
        tage = Tage.healer;
    }

    public override int Attack()
    {
        Console.WriteLine("Освещаю!!");
        return rndAttack();
    }

    public override bool takeDamage(int damage)
    {
        hp -= damage;
        return hp > 0;
    }

    public override int Heal()
    {
        return new Random().Next(1000) % 30;
    }
}