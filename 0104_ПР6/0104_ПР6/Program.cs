// 12. Даны файлы F и G целых чисел, не превышающих 255.
// Занести в третий файл максимальные числа из стоящих на одинаковых позициях в файлах F и G.

using System;
using System.IO;
using System.Linq;


namespace _0104_ПР6
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                #region Чтение чисел из файлов
                int[] numbersF = ReadNumbersFromFile("F.txt");
                int[] numbersG = ReadNumbersFromFile("G.txt");
                #endregion

                #region Обработка чисел и запись результата
                using (StreamWriter writer = new StreamWriter("H.txt"))
                {
                    int maxLength = Math.Max(numbersF.Length, numbersG.Length);
                    for (int i = 0; i < maxLength; i++)
                    {
                        int valueF = (i < numbersF.Length) ? numbersF[i] : 0;
                        int valueG = (i < numbersG.Length) ? numbersG[i] : 0;

                        if (valueF < 0 || valueF > 255 || valueG < 0 || valueG > 255)
                            throw new InvalidDataException($"Некорректное значение на позиции {i + 1}");

                        int max = Math.Max(valueF, valueG);
                        writer.Write(max + " ");
                    }
                }

                Console.WriteLine("Файл H успешно создан.");
                #endregion
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Ошибка: Файл не найден - {ex.FileName}");
            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine($"Ошибка данных: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        #region Метод чтения чисел из файла
        static int[] ReadNumbersFromFile(string filename)
        {
            string content = File.ReadAllText(filename);
            return content.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                         .Select(s =>
                         {
                             if (!int.TryParse(s, out int num))
                                 throw new InvalidDataException($"Некорректное число: '{s}'");
                             return num;
                         })
                         .ToArray();
        }
        #endregion
    }
}