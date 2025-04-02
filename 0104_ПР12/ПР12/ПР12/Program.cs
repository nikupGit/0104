using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ПР12;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Работа с файлом
            string filePath = "data.txt";
            var writer = new StringsToFile();
            writer.WriteLinesToFile(filePath, 1000000);
            string[] lines = await ReadFileAsync(filePath);

            #region Диалог с пользователем
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.Write("Введите ваше имя: ");
            string firstName = Console.ReadLine();

            Console.Write("Введите вашу фамилию: ");
            string lastName = Console.ReadLine();

            Console.WriteLine($"Здравствуйте, {firstName} {lastName}!");

            Console.Write("Хотите вывести содержимое файла на экран? (да/нет): ");
            string choice = Console.ReadLine();

            if (choice.Equals("да", StringComparison.OrdinalIgnoreCase))
            {
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            #endregion
        }
        catch(Exception e)
        {
            Console.WriteLine($"Ошибка: {e}");
        }
    }
     

    static async Task<string[]> ReadFileAsync(string path)
    {
        if (File.Exists(path))
        {
            // Оборачиваем синхронное чтение в Task.Run для имитации асинхронности
            return await Task.Run(() => File.ReadAllLines(path));
        }
        else
        {
            Console.WriteLine("Файл не найден.");
            return Array.Empty<string>();
        }
    }
}
