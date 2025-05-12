using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ConsoleAppClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8890);

                using (var sender = new Socket(ipEndPoint.AddressFamily,
                                             SocketType.Stream,
                                             ProtocolType.Tcp))
                {
                    sender.Connect(ipEndPoint);

                    Console.Write("Введите сообщение: ");
                    string message = Console.ReadLine();

                    byte[] msgBytes = Encoding.UTF8.GetBytes(message);
                    sender.Send(msgBytes);

                    var buffer = new byte[1024];
                    int received = sender.Receive(buffer);
                    Console.WriteLine($"Ответ сервера: {Encoding.UTF8.GetString(buffer, 0, received)}");

                    sender.Shutdown(SocketShutdown.Both);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.ReadLine();
        }
    }
}