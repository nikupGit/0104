//24. Дан файл F, содержащий текст на русском и английском языках.
//Подсчитать, каких букв в тексте больше – русских или английских.
//Результат сохранить в файле F1.
using System;
using System.IO;


namespace ПР6_3_24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int russianCount = 0;
            int englishCount = 0;

            try
            {
                #region Считавание и подсчет
                using (StreamReader reader = new StreamReader("F.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        foreach (char c in line)
                        {
                            if (IsRussianLetter(c))
                                russianCount++;
                            else if (IsEnglishLetter(c))
                                englishCount++;
                        }
                    }
                }
                #endregion

                #region Сравнение и запись
                string result;
                if (russianCount > englishCount)
                    result = $"Русских букв больше: {russianCount} против {englishCount}";
                else if (englishCount > russianCount)
                    result = $"Английских букв больше: {englishCount} против {russianCount}";
                else
                    result = $"Количество русских и английских букв одинаково: {russianCount}";

                File.WriteAllText("F1.txt", result);
                Console.WriteLine("Результат записан в F1.txt");
                #endregion
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл F.txt не найден.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        #region Функция определения русских и английских букв
        static bool IsRussianLetter(char c)
        {
            return (c >= 'А' && c <= 'Я') || (c >= 'а' && c <= 'я') || c == 'Ё' || c == 'ё';
        }

        static bool IsEnglishLetter(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        }
        #endregion
    }
}
