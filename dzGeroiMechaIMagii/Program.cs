// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Net.Sockets;
using dzTmaSvet;


class Programm
{
    static void Main(string[] args)
    {
        var Game = new Gameplay();

        Console.Title = "Client";
        Console.Write("Адрес: ");
        string ip = Console.ReadLine();
        Console.Write("Порт: ");
        int port = int.Parse(Console.ReadLine());
        Socket client = new Socket(AddressFamily.InterNetwork, 
            SocketType.Stream, ProtocolType.Tcp);
        client.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
        
        if (!client.Connected)
        {
            Console.WriteLine("Ошибка подключения!!!");
            Console.ReadKey();
            return;
        }



        Console.WriteLine("\"+---------------------------------Правила!!!------------------------------------+\" " +
                          "\"|Вампиры и рыцари - вербуют, ангелы и духи - дурачат, архиангел и ведьма - лечат|\"" +
                          " \"+-------------------------------------------------------------------------------+\"");
        Console.WriteLine();
        Console.WriteLine("Выберете команду: Свет - 1, Тьма - 2. ");
        Game.CommandChoice = int.Parse(Console.ReadLine());

        while (Game.CommandChoice < 1 || Game.CommandChoice > 2)
        {
            Console.WriteLine("Выберете команду из данных: ");
            Game.CommandChoice = int.Parse(Console.ReadLine());
        }

        Game.BuildCommand();
        Game.PrintCommand();
        Game.Fight();
    }
}