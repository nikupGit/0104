using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ПР12
{
    class Program
    {
        static async Task Main()
        {
            try
            {
                string filePath = "data.txt";

                File.WriteAllText(filePath, string.Empty);
                SyncAsync.FileWriter(filePath, 2000);

                Console.OutputEncoding = Encoding.Unicode;
                Console.InputEncoding = Encoding.Unicode;

                Console.Write("Введите ваше имя: ");
                string firstName = Console.ReadLine();

                Console.Write("Введите вашу фамилию: ");
                string lastName = Console.ReadLine();

                Console.WriteLine($"Здравствуйте, {firstName} {lastName}!");

                Console.Write("Вы хотите считать файл синхронно или асинхронно? (sync/async): ");
                string mode = Console.ReadLine();

                Console.WriteLine("Считывание файла началось...");
                string[] lines;

                if (mode.Equals("sync", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Синхронное чтение");
                    lines = SyncAsync.ReadFileSync(filePath);
                }
                else
                {
                    Console.WriteLine("Асинхронное чтение");
                    lines = await SyncAsync.ReadFileAsync(filePath);
                }

                Console.Write("Хотите вывести содержимое файла на экран? (да/нет): ");
                string choice = Console.ReadLine();

                if (choice.Equals("да", StringComparison.OrdinalIgnoreCase))
                {
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                    Console.WriteLine("Конец вывода.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }
    }
}
