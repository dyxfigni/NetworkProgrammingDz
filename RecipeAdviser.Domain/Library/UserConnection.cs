using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using MessageLibrary;

namespace UserConnectionLib
{
    public class UserConnection
    {
        private IPEndPoint endPoint;
        private TcpClient client;
        private BinaryFormatter formatter;
        public TcpClient ClientConnection
        {
            get => client;
            private set
            {
                client = value;
            }
        }
        public event Action<LanMessage> IncomingMessage;
        public event Action<string, object> SystemMessage;

        public UserConnection(IPAddress ip, int port)
        {
            endPoint = new IPEndPoint(ip, port);
            client = null;
        }
        public UserConnection(TcpClient tcpClient)
        {
            if (tcpClient == null)
                throw new ArgumentException("Подключение не может быть пустым");

            client = tcpClient;
            formatter = new BinaryFormatter();
        }
        public bool StartConnection()
        {
            if (client != null)
                return client.Connected;

            client = new TcpClient();
            try
            {
                client.Connect(endPoint);
                if (!client.Connected)
                {
                    SystemMessage?.Invoke("Не подключен!!!", null);
                }
                else
                {
                    formatter = new BinaryFormatter();
                    SystemMessage?.Invoke("Подключение установлено!", null);
                }
                return client.Connected;
            }
            catch (SocketException e)
            {
                SystemMessage?.Invoke("SocketException: " + e.Message, e);
                return false;
            }
            catch (Exception e)
            {
                SystemMessage?.Invoke("System exception: " + e.Message, e);
                return false;
            }
        }
        public void CloseConnection()
        {
            client?.Close();
            client = null;
            SystemMessage?.Invoke("Подключение закрыто!", null);
        }

        public void SendMessage(LanMessage message)
        {
            if (client != null & client.Connected)
            {
                formatter.Serialize(client.GetStream(), message);
                SystemMessage?.Invoke("Отправлено сообщение", message);
            }
        }

        public void SendMessage(IQueryable<string> message)
        {
            if (client != null & client.Connected)
            {
                foreach (string s in message)
                {
                    formatter.Serialize(client.GetStream(), s);
                    SystemMessage?.Invoke("Отправлено сообщение", s);
                }
            }
        }

        public Task SendMessageTask(LanMessage message)
        {
            return Task.Run(() =>
            {
                SendMessage(message);
            });
        }

        public LanMessage ReceiveMessage()
        {
            LanMessage message = null;
            try
            {
                if (client != null & client.Connected)
                {
                    message = formatter.Deserialize(client.GetStream()) as LanMessage;
                    IncomingMessage?.Invoke(message);
                }
            }
            catch (Exception e)
            {
                SystemMessage?.Invoke("Ошибка отправки", e);
            }

            return message;
        }
        public Task ReceiveMessageTask()
        {
            return Task.Run(ReceiveMessage);
        }
        //public Task<LanMessage> ReceiveMessageTask()
        //{
        //    Task<LanMessage> task = new Task<LanMessage>(() =>
        //      {
        //          return formatter.Deserialize(client.GetStream()) as LanMessage;
        //      });
        //    task.Start();
        //    return task;
        //}
    }
}
