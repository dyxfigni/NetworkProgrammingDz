// See https://aka.ms/new-console-template for more information

using dzTmaSvet;

var game = new Gameplay();
Console.WriteLine("\"+---------------------------------Правила!!!------------------------------------+\" " +
                  "\"|Вампиры и рыцари - вербуют, ангелы и духи - дурачат, архиангел и ведьма - лечат|\"" +
                  " \"+-------------------------------------------------------------------------------+\"");
Console.WriteLine();
Console.WriteLine("Выберете команду: Свет - 1, Тьма - 2. ");
game.CommandChoice = int.Parse(Console.ReadLine());

while (game.CommandChoice < 1 || game.CommandChoice > 2)
{
    Console.WriteLine("Выберете команду из данных: ");
    game.CommandChoice = int.Parse(Console.ReadLine());
}

game.buildCommand();
game.printCommand();
game.Fight();