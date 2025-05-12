using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace MultiThreadServer
{
    class ExampleTcpListener
    {
        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                int MaxThreadsCount = Environment.ProcessorCount * 4;
                ThreadPool.SetMaxThreads(MaxThreadsCount, MaxThreadsCount);
                ThreadPool.SetMinThreads(2, 2);
                Int32 port = 9595;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                int counter = 0;
                server = new TcpListener(localAddr, port);
                Console.OutputEncoding = Encoding.GetEncoding(866);
                Console.WriteLine("Конфигурация многопоточного сервера:");
                Console.WriteLine("IP-адрес: 127.0.0.1");
                Console.WriteLine("Порт: " + port.ToString());
                Console.WriteLine("Потоки: " + MaxThreadsCount.ToString());
                Console.WriteLine("\nСервер запущен\n");
                server.Start();
                while (true)
                {
                    Console.Write("\nОжидание соединения...");
                    ThreadPool.QueueUserWorkItem(ClientProcessing, server.AcceptTcpClient());
                    counter++;
                    Console.Write("\nСоединение №" + counter.ToString() + "!");
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server.Stop();
            }
            Console.WriteLine("\nНажмите Enter...");
            Console.Read();
        }
        static void ClientProcessing(object client_obj)
        {
            Byte[] bytes = new Byte[256];
            String data = null;
            TcpClient client = client_obj as TcpClient;
            NetworkStream stream = client.GetStream();
            int i;
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                data = data.ToUpper();
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                stream.Write(msg, 0, msg.Length);
            }
            client.Close();
        }
    }
}