using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeAdviser.Domain
{
    internal class ServerUdp
    {
        private static string _remoteAddress; // хост для отправки данных
        private static int _remotePort; // порт для отправки данных
        private static int _localPort; // локальный порт для прослушивания 
        // входящих подключений

        ServerUdp()
        {
            try
            {
                // локальный порт, порт сервера
                Console.Write("Введите порт для прослушивания: ");
                _localPort = Int32.Parse(Console.ReadLine());

                Console.Write("Введите удаленный адрес для подключения: ");
                // адрес, к которому мы подключаемся
                _remoteAddress = Console.ReadLine();

                Console.Write("Введите порт для подключения: ");
                // порт, к которому мы подключаемся
                _remotePort = int.Parse(Console.ReadLine());

                //Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                //receiveThread.IsBackground = true;
                //receiveThread.Start();
                //SendMessage(); // отправляем сообщение
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
