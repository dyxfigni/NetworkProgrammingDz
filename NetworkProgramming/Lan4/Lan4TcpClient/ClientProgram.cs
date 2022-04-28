using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using MessageLibrary;

namespace Lan4TcpClient
{
    class ClientProgram
    {
        static void Main(string[] args)
        {
            Console.Title = "Client";
            Console.Write("Введите адрес для подключения: ");
            string address = Console.ReadLine();
            Console.Write("Введите порт для подключения: ");
            int port = int.Parse(Console.ReadLine());
            StartClient(new IPEndPoint(IPAddress.Parse(address), port));
        }

        private static void StartClient(IPEndPoint endPoint)
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(endPoint);
                if (!client.Connected)
                {
                    Console.WriteLine("Не подключен!!!");
                    Console.ReadLine();
                    return;
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: " + e.Message);
                Console.ReadLine();
                return;
            }
            catch(Exception e)
            {
                Console.WriteLine("System exception: " + e.Message);
                Console.ReadLine();
                return;
            }

            BinaryFormatter bf = new BinaryFormatter();

           

            using (NetworkStream ns=client.GetStream())
            {
                LanMessage message = (LanMessage)bf.Deserialize(ns);
                Console.WriteLine(">> " + message);
                Console.Write("Введите сообщение: ");
                message = new LanMessage(Console.ReadLine());
                bf.Serialize(ns, message);
            }

            client.Close();
        }
    }
}
