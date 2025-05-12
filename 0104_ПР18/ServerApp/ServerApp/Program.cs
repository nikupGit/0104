using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ConsoleAppServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(866);
            Console.WriteLine("Сервер запущен");

            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 8890);

            using (var listener = new Socket(ipEndPoint.AddressFamily,
                                           SocketType.Stream,
                                           ProtocolType.Tcp))
            {
                try
                {
                    listener.SetSocketOption(SocketOptionLevel.Socket,
                                           SocketOptionName.ReuseAddress,
                                           true);
                    listener.Bind(ipEndPoint);
                    listener.Listen(10);

                    while (true)
                    {
                        Console.WriteLine($"Ожидаем подключение на порту {ipEndPoint.Port}");

                        using (var handler = listener.Accept())
                        {
                            Console.WriteLine("Клиент подключен");

                            var buffer = new byte[1024];
                            int received = handler.Receive(buffer);
                            string data = Encoding.UTF8.GetString(buffer, 0, received);
                            Console.WriteLine($"Получено: {data}");

                            string reply = $"Размер запроса: {data.Length} символов";
                            byte[] msg = Encoding.UTF8.GetBytes(reply);
                            handler.Send(msg);

                            if (data.Contains("<TheEnd>"))
                            {
                                Console.WriteLine("Получена команда завершения");
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Сервер остановлен. Нажмите Enter для выхода...");
                    Console.ReadLine();
                }
            }
        }
    }
}