// 12. Занести в файл F 10 символов.
// Подсчитать количество символов до символа '*'.
using System;
using System.IO;


namespace ПР6_2_12
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                #region Ввод и проверка
                Console.WriteLine("Введите 10 символов (подряд, без пробелов):");
                string input = Console.ReadLine();

                // Проверка длины ввода
                if (input.Length != 10)
                {
                    Console.WriteLine("Ошибка: нужно ввести ровно 10 символов!");
                    return;
                }
                #endregion

                #region Запись, чтение и подсчет до *
                File.WriteAllText("F.txt", input);

                int count = 0;
                bool starFound = false;
                string content = File.ReadAllText("F.txt");

                foreach (char c in content)
                {
                    if (c == '*')
                    {
                        starFound = true;
                        break;
                    }
                    count++;
                }
                #endregion

                #region Вывод результата
                Console.WriteLine(starFound
                    ? $"Количество символов до '*': {count}"
                    : $"Символ '*' не найден. Всего символов: {count}");
                #endregion
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }
    }
}
