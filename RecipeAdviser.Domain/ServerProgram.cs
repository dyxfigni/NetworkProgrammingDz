using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MessageLibrary;
using UserConnectionLib;

namespace RecipeAdviser.Domain
{
    internal class ServerProgram
    {
        private static TcpListener listener;
        private static void Main(string[] args)
        {
            listener = null;
            Console.Title = "Server";
            
            //порт сервера
            Console.Write("Введите порт для прослушивания: ");
            var port = int.Parse(Console.ReadLine());

            Task.Run(() =>
            {
                //var lines = File.ReadAllLines(@"c:\temp\dictionary.txt");
                //dict = new Dictionary<string, string>();
                //foreach (string s in lines)
                //{
                //    var l = s.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                //    dict.Add(l[0].Trim('"'), l[l.Length - 1].Trim('"'));
                //}
                //Console.WriteLine("\nСловарь загружен!");
            });

            var serverTask = Task.Run(() => StartServer(port));
            Console.WriteLine("Нажмите ESC для " +
                              "остановки сервера...");
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Escape);

            ShutDownServer();
        }

        private static void StartServer(int port)
        {
            if (listener != null)
                return;

            // сокет
            listener = new TcpListener(new IPEndPoint(IPAddress.Any, port));

            //включение сокета
            listener.Start(10);
            do
            {
                //принимает подключение от клиента
                var client = listener.AcceptTcpClient();

                // вывод на экран айпи адрес клиента
                Console.WriteLine($"Connection " + client.Client.RemoteEndPoint);
                
                // ожидание от клиента данных
                Task.Run(() => UserMessaging(client));
            } while (true);
        }

        private static void UserMessaging(TcpClient client)
        {
            var user = new UserConnection(client);
            do
            {
                var message = user.ReceiveMessage();
                if (message != null)
                {
                    if (message.MessageText.ToLower().Equals("/exit"))
                        break;
                    else
                        Console.WriteLine($"{user.ClientConnection.Client.RemoteEndPoint}>>> {message.MessageText}");
                }
                else
                {
                    break;
                }
                var answer = string.Empty;
                try
                {
                    //Todo выборку сделать 
                    answer = "Сервер принял и отдает";
                }
                catch
                {
                }

                user.SendMessage(new LanMessage(answer));
            } while (true);
            user.CloseConnection();
        }

        private static void ShutDownServer()
        {
            if (listener != null) listener.Stop();
        }
    }
}