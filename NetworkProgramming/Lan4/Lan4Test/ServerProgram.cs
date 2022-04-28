﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using MessageLibrary;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lan4Test
{
    class ServerProgram
    {
        private static TcpListener listener;
        static void Main(string[] args)
        {
            listener = null;
            Console.Title = "Server";
            Console.Write("ВВедите порт для прослушивания: ");
            int port = int.Parse(Console.ReadLine());
            
            Task.Run(()=> StartServer(port));

            Console.WriteLine("Press ENTER...");
            Console.ReadLine();
            ShutDownServer();
        }
        private static void StartServer(int port)
        {
            if (listener != null)
                return;

            listener = new TcpListener(new IPEndPoint(IPAddress.Any, port));
            listener.Start(10);
            do
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine($"Connection " + client.Client.RemoteEndPoint);
                BinaryFormatter bf = new BinaryFormatter();
                using (NetworkStream ns = client.GetStream())
                {
                    // read-write
                    #region v1 method
                    // v1 send string
                    // byte[] buf = Encoding.UTF8.GetBytes("Hello User!");
                    // ns.Write(buf, 0, buf.Length);

                    // v1 read message
                    //StringBuilder sb = new StringBuilder();
                    //byte[] buf = new byte[1024];
                    //int len;
                    //do
                    //{
                    //    len = ns.Read(buf, 0, buf.Length);
                    //    sb.Append(Encoding.UTF8.GetString(buf, 0, len));
                    //} while (ns.DataAvailable);
                    //Console.WriteLine(sb.ToString());
                    #endregion

                    // v2 send object
                    LanMessage message = new LanMessage("Hello User!");
                    bf.Serialize(ns, message);
                    
                    // v2 read message
                    message = (LanMessage)bf.Deserialize(ns);
                    Console.WriteLine(message);
                }
                client.Close();

            } while (true);
        }
        private static void ShutDownServer()
        {
            if (listener != null)
            {
                listener.Stop();
            }
        }
    }
}
