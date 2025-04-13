using System;
using System.Collections.Generic;
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
                Async.FileWriter(filePath, 300000);

                Console.OutputEncoding = Encoding.Unicode;
                Console.InputEncoding = Encoding.Unicode;

                Task<string[]> readTask = null;

                Console.WriteLine("Запуск асинхронного чтения...");
                readTask = Async.ReadFileAsync(filePath);

                Console.Write("Введите ваше имя: ");
                string firstName = Console.ReadLine();

                Console.Write("Введите вашу фамилию: ");
                string lastName = Console.ReadLine();

                Console.WriteLine($"Здравствуйте, {firstName} {lastName}!");

                string[] lines;
                Console.WriteLine("Ожидание завершения асинхронного чтения...");
                lines = await readTask;

                Console.Write("Показать содержимое файла? (да/нет): ");
                if (Console.ReadLine().Trim().Equals("да", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nСодержимое файла:");
                    foreach (var line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}