using System.Net.Sockets;
using dzTmaSvet.Units;
using dzTmaSvet.Units.FractionsAndUnits;

namespace dzTmaSvet;

//[DllImport(@"E:\kod\NetworkProgramming\NetworkProgramming\x64\Debug\LibraryOfGame.dll")] 
//static extern double chance(ref IntPtr thisPtr);

internal class Gameplay
{
    private List<BaseUnit> _command1;
    private List<BaseUnit> _command2;

    public string ip;
    public int port;
    public Socket client;

    private BaseUnit _unit1;
    private BaseUnit _unit2;

    public int CommandChoice { get; set; }

    private double Chance()
    {
        return new Random().Next(0, 100) / (double)new Random().Next(0, 100);
    }

    public void BuildCommand()
    {
        var level = Level.LevelEasy;
        _command1 = new List<BaseUnit>();
        _command2 = new List<BaseUnit>();
        switch (CommandChoice)
        {
            case 1:
                _command1 = LightFraction.CreateCommand(_command1, level);
                _command2 = DarkFraction.CreateCommand(_command2, level);
                break;
            case 2:
                _command1 = DarkFraction.CreateCommand(_command1, level);
                _command2 = LightFraction.CreateCommand(_command2, level);
                break;
            default:
                _command1 = DarkFraction.CreateCommand(_command1, level);
                _command2 = LightFraction.CreateCommand(_command2, level);
                break;
        }
    }

    public void PrintCommand()
    {
        Console.WriteLine("Ваша команда:          ");

        foreach (BaseUnit unit in _command1) Console.WriteLine(unit.GetName);

        Console.WriteLine("\n\nКоманда противника!!!!!");

        foreach (BaseUnit unit in _command2) Console.WriteLine(unit.GetName);
    }

    public void Fight()
    {
        Console.WriteLine();
        while (_command1.Count > 0 && _command2.Count > 0)
        {
            _unit1 = _command1.First();
            _command1.Remove(_command1.First());

            _unit2 = _command2.First();
            _command2.Remove(_command2.First());


            Console.WriteLine($"Вы {_unit1.GetName} " +
                              $"Здоровье {_unit1.GetHp}");

            Console.WriteLine("Атаковать(1) пропустить(2)" +
                              "одурачить(3)" +
                              "завербовать(4)" +
                              "вылечить(5)");


            Console.WriteLine($"{_unit1.GetName} против {_unit2.GetName}");
            double skipChance = Chance();
            Console.WriteLine($"Шанс на пропуск: {skipChance}");
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
                        _command1.Add(_unit1);
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
                    if (_unit1.GetTage == Tage.Tricker)
                    {
                        var chanceTrick = Chance();
                        Console.WriteLine($"Шанс: {chanceTrick}");
                        if (chanceTrick > Chance())
                        {
                            Thread.Sleep(400);
                            Console.WriteLine("Успех! Вы одурачили противника");

                            _command2.Add(_unit2);
                            _unit2 = _command2.First();
                            _command2.Remove(_command2.First());

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
                    if (_unit1.GetTage == Tage.Spy)
                    {
                        double recruitChance = Chance();
                        Console.WriteLine("Шанс: " + recruitChance);
                        if (recruitChance > Chance())
                        {
                            Thread.Sleep(400);
                            Console.WriteLine("Успех!!! Вы завербовали в свои ряды: "
                                              + _unit2.GetName);
                            _command1.Add(_unit2);
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
                                _command1.Add(_unit1);
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
                                    _command2.Add(_unit1);
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                    else
                        Attack();
                    break;

                case 5:
                    if (_unit1.GetTage == Tage.Healer)
                    {
                        double healChance = Chance();
                        Console.WriteLine("Шанс на лечение: " + healChance);
                        if (healChance > Chance())
                        {
                            Thread.Sleep(400);
                            var healer = _unit1;
                            var countHeal = healer.Heal();
                            _unit1 = _command1.First();
                            _command1.Remove(_command1.First());
                            _unit1.SetHp(countHeal);
                            Console.WriteLine($" Вы вылечили {_unit1.GetName} на {countHeal} единиц!!!");
                            _command1.Add(healer);
                            _command1.Add(_unit1);
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

        if (_command1.Count > 0)
            Console.WriteLine("Вы проиграли");
        else
            Console.WriteLine("Противник проиграл!");
    }

    public void Attack()
    {
        int damageFromU1 = _unit1.Attack();
        int damageFromU2 = _unit2.Attack();
        if (_unit1.TakeDamage(damageFromU2))
        {
            _command1.Add(_unit1);
            if (_unit2.TakeDamage(damageFromU1))
            {
                _command1.Add(_unit1);
                _command2.Add(_unit2);
            }
            else
            {
                _command1.Add(_unit1);
                Console.WriteLine($"{_unit2.GetName} умер!!!");
            }
        }
        else
        {
            _command2.Add(_unit2);
            Console.WriteLine($" Ваш герой {_unit1.GetName} умер...");
        }

        Console.WriteLine($"{_unit1.GetName} отнял {damageFromU1}" +
                          $", a {_unit2.GetName} {damageFromU2}");
        Console.WriteLine();
    }
}