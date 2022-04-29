using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MessageLibrary;

namespace RecipeAdviserClientTest
{
    internal class ClientTestProgram
    {
        static void Main(string[] args)
        {
            Console.Title = "Client";
            Console.Write("Введите адрес для подключения: ");
            string address = Console.ReadLine();
            Console.Write("Введите порт для подключения: ");
            int port = int.Parse(Console.ReadLine());

            UserConnection connection = new UserConnection(IPAddress.Parse(address), port);
            connection.SystemMessage += Connection_SystemMessage;
            connection.IncomingMessage += Connection_IncomingMessage;

            if (connection.StartConnection())
            {
                string text;
                try
                {
                    do
                    {
                        Console.Write(">>> ");
                        text = Console.ReadLine();
                        if (text.ToLower().Equals("/exit"))
                            break;

                        connection.SendMessage(new LanMessage(text));
                        connection.ReceiveMessage();
                    } while (true);
                }
                catch (Exception e)
                {
                    Connection_SystemMessage("Error", e);
                }
                connection.CloseConnection();
            }
            else
            {
                Console.WriteLine("\nPress ENTER...");
                Console.ReadLine();
                return;
            }
        }

        private static void Connection_IncomingMessage(LanMessage message)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(">>> ");
            Console.ForegroundColor = old;
            Console.WriteLine(message.MessageText);
        }
        private static void Connection_SystemMessage(string arg1, object arg2)
        {
            var old = Console.ForegroundColor;
            if (arg2 is Exception)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Yellow;

            if (arg2 != null)
                Console.WriteLine(arg1 + ", " + arg2.ToString());
            else
                Console.WriteLine(arg1);

            Console.ForegroundColor = old;
        }
    }
}
