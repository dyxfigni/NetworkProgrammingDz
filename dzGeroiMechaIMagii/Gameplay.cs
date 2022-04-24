using dzTmaSvet.Units;
using dzTmaSvet.Units.FractionsAndUnits;

namespace dzTmaSvet;

//[DllImport(@"E:\kod\NetworkProgramming\NetworkProgramming\x64\Debug\LibraryOfGame.dll")] 
//static extern double chance(ref IntPtr thisPtr);

internal class Gameplay
{
    private List<BaseUnit> command1;
    private List<BaseUnit> command2;

    private BaseUnit unit1;
    private BaseUnit unit2;

    public int CommandChoice { get; set; }

    private double Chance()
    {
        return new Random().Next(0, 100) / (double)new Random().Next(0, 100);
    }

    public void buildCommand()
    {
        var level = Level.LEVEL_EASY;
        command1 = new List<BaseUnit>();
        command2 = new List<BaseUnit>();
        switch (CommandChoice)
        {
            case 1:
                command1 = DarkFraction.createCommand(command1, level);
                command2 = LightFraction.createCommand(command2, level);
                break;
            case 2:
                command1 = DarkFraction.createCommand(command1, level);
                command2 = LightFraction.createCommand(command2, level);
                break;
            default:
                command1 = DarkFraction.createCommand(command1, level);
                command2 = LightFraction.createCommand(command2, level);
                break;
        }
    }

    public void printCommand()
    {
        Console.WriteLine("Ваша команда:          ");

        foreach (BaseUnit unit in command1) Console.WriteLine(unit.getName);

        Console.WriteLine("\n\nКоманда противника!!!!!");

        foreach (BaseUnit unit in command2) Console.WriteLine(unit.getName);
    }

    public void Fight()
    {
        Console.WriteLine();
        while (command1.Count > 0 && command2.Count > 0)
        {
            Console.WriteLine("Атаковать(1) пропустить(2)" +
                              "одурачить(3)" +
                              "завербовать(4)" +
                              "вылечить(5)");
            unit1 = command1.First();
            command1.Remove(command1.First());

            unit2 = command2.First();
            command2.Remove(command2.First());

            Console.WriteLine($"{unit1.getName} против {unit2.getName}");
            double skipChance = Chance();
            Console.WriteLine($"Шанс на пропуск: {(int)skipChance*100}%");
            int choice = int.Parse(Console.ReadLine());
            while (choice < 0 || choice > 5)
            {
                Console.WriteLine("Введите из данных: ");
                choice = int.Parse(Console.ReadLine());
            }

            switch (choice)
            {
                case 1:
                    Thread.Sleep(400);
                    Attack();
                    break;
                case 2:
                    if (skipChance > Chance())
                    {
                        Thread.Sleep(400);
                        Console.WriteLine("Успех!");
                        command1.Add(unit1);
                        Console.WriteLine();
                    }
                    else
                    {
                        Thread.Sleep(400);
                        Console.WriteLine("Вы проспали и вас заметил противник!!!");
                        Console.WriteLine();
                        Attack();
                    }
                    break;

                case 3:
                    if (unit1.getTage == Tage.tricker)
                    {
                        var chanceTrick = Chance();
                        Console.WriteLine($"Шанс: {chanceTrick}");
                        if (chanceTrick > Chance())
                        {
                            Thread.Sleep(400);
                            Console.WriteLine("Успех! Вы одурачили противника");

                            command2.Add(unit2);
                            unit2 = command2.First();
                            command2.Remove(command2.First());

                            Console.WriteLine();
                        }
                        else
                        {
                            Thread.Sleep(400);
                            Console.WriteLine("Вы не смогли одурачить противника...");
                            Console.WriteLine();
                            Attack();
                        }
                    }
                    else 
                        Attack();
                    break;

                case 4:
                    if (unit1.getTage == Tage.spy)
                    {
                        double recruitChance = Chance();
                        Console.WriteLine("Шанс: " + recruitChance);
                        if (recruitChance > Chance())
                        {
                            Thread.Sleep(400);
                            Console.WriteLine("Успех!!! Вы завербовали в свои ряды: "
                                              + unit2.getName);
                            command1.Add(unit2);
                            Console.WriteLine();
                        }
                        else
                        {
                            Thread.Sleep(400);
                            recruitChance = Chance();
                            Console.WriteLine("Вас расскрыли, шанс на побег: " + recruitChance);
                            if (recruitChance > Chance())
                            {
                                Thread.Sleep(400);
                                Console.WriteLine("Вы сбежали!!!");
                                command1.Add(unit1);
                                Console.WriteLine();
                            }
                            else
                            {
                                Thread.Sleep(400);
                                Console.WriteLine("Провал... Вам придется попасть в плен или атаковать ");
                                recruitChance = Chance();
                                if (recruitChance > Chance())
                                {
                                    Thread.Sleep(400);
                                    Console.WriteLine(" Вы смогли выхватиться из рук противника!! Атакуйте!!!");
                                    Console.WriteLine();
                                    Attack();
                                }
                                else
                                {
                                    Thread.Sleep(400);
                                    Console.WriteLine(" Вы не смогли дать отпор противнику и попали в плен ");
                                    command2.Add(unit1);
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                    else
                        Attack();
                    break;

                case 5:
                    if (unit1.getTage == Tage.healer)
                    {
                        double healChance = Chance();
                        Console.WriteLine("Шанс на лечение: " + healChance);
                        if (healChance > Chance())
                        {
                            Thread.Sleep(400);
                            var healer = unit1;
                            var countHeal = healer.Heal();
                            unit1 = command1.First();
                            command1.Remove(command1.First());
                            unit1.setHp(countHeal);
                            Console.WriteLine($" Вы вылечили {unit1.getName} на {countHeal} единиц!!!");
                            command1.Add(healer);
                            command1.Add(unit1);
                            Console.WriteLine();
                        }
                        else
                        {
                            Thread.Sleep(400);
                            Console.WriteLine("Вы запутались в заклинаниях и вдруг " +
                                              "замечаете как противник застал вас в расплох!!!");
                            Console.WriteLine();
                            Attack();
                        }
                    }
                    else
                        Attack();
                    break;
            }
        }

        if (command1.Count > 0)
            Console.WriteLine("Вы проиграли");
        else
            Console.WriteLine("Противник проиграл!");
    }

    public void Attack()
    {
        int damageFromU1 = unit1.Attack();
        int damageFromU2 = unit2.Attack();
        if (unit1.takeDamage(damageFromU2))
        {
            command1.Add(unit1);
            if (unit2.takeDamage(damageFromU1))
            {
                command1.Add(unit1);
                command2.Add(unit2);
            }
            else
            {
                command1.Add(unit1);
                Console.WriteLine($"{unit2.getName} умер!!!");
            }
        }
        else
        {
            command2.Add(unit2);
            Console.WriteLine($" Ваш герой {unit1.getName} умер...");
        }

        Console.WriteLine($"{unit1.getName} отнял {damageFromU1}" +
                          $", a {unit2.getName} {damageFromU2}");
        Console.WriteLine();
    }
}