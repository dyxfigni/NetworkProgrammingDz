using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MessageLibrary;
using RecipeAdviser.Domain;
using UserConnectionLib;

namespace RecipeAdviser.Domain
{
    public class ServerProgram
    {
        private static TcpListener _listener;
        private static List<string> Answer;
        public static int Port { get; set; }
        public ServerProgram(int port)
        {
            _listener = null;
            ServerProgram.Port = port;
        }

        public void StartServer()
        {
            if (_listener != null)
                return;

            // сокет
            _listener = new TcpListener(new IPEndPoint(IPAddress.Any, Port));

            //включение сокета
            _listener.Start(10);
            do
            {
                //принимает подключение от клиента
                var client = _listener.AcceptTcpClient();

                // вывод на экран айпи адрес клиента
                Console.WriteLine($"Connection " + client.Client.RemoteEndPoint);
                
                // ожидание от клиента данных
                Task.Run(() => UserMessaging(client));
            } while (true);
        }

        public void UserMessaging(TcpClient client)
        {
            var user = new UserConnection(client);
            do
            {
                var messageWrittenByUser = user.ReceiveMessage();
                if (messageWrittenByUser != null)
                {
                    if (messageWrittenByUser.MessageText.ToLower().Equals("/exit"))
                        break;
                    else
                        Console.WriteLine($"{user.ClientConnection.Client.RemoteEndPoint}>>> {messageWrittenByUser.MessageText}");
                }
                else
                {
                    break;
                }

                Answer = null;
                try
                {
                    //Todo выборку сделать 
                    using (RecepiesEntities db = new RecepiesEntities())
                    {
                        var ingridientsId = db.Ingridients
                            .Where(i => i.Products.NameOfProduct == messageWrittenByUser.ToString())
                            .Select(i => i.IngridientId);


                        IQueryable<string> answerrList = null;
                        answerrList = db.Recepi
                            .Where(r =>
                                r.Ingridients.Any(i => i.IngridientId
                                                       == ingridientsId.FirstOrDefault()))
                            .Select(r => r.RecepisName);

                        List<string> answerList2 = answerrList.ToList();

                        foreach (string s in answerList2)
                        {
                            user.SendMessage(new LanMessage(s));
                        }
                    }
                }
                catch
                {
                }
                finally
                {
                    
                }
                
            } while (true);
            user.CloseConnection();
        }

        public void ShutDownServer()
        {
            if (_listener != null) _listener.Stop();
        }
    }
}