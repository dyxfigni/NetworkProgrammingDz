﻿namespace dzTmaSvet.Units.FractionsAndUnits.LightUnits;

internal class Archer : BaseUnit
{
    public Archer()
    {
        hp = 80;
        minAtack = 16;
        maxAtack = 23;
        name = "Archer";
        tage = Tage.avarage;
    }

    public override int Attack()
    {
        Console.WriteLine("Стреляю!!");
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