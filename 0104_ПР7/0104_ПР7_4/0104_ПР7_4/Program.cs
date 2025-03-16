//4. Дан файл вещественных чисел.
//Определить количество нулевых элементов в этом файле
//и дописать в конец данного файла это число.

using System;
using System.IO;

namespace _0104_ПР7_4
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                string filePath = "FDoubles.dat";
                int zeroCount = 0;

                #region Чтение и подсчёт нулей
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    while (true)
                    {
                        try
                        {
                            double num = reader.ReadDouble();
                            if (num == 0.0) zeroCount++;
                        }
                        catch (EndOfStreamException)
                        {
                            break; // Корректный выход при достижении конца
                        }
                    }
                }
                #endregion

                #region Запись результата в конец файла
                using (FileStream fs = new FileStream(filePath, FileMode.Append))
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    writer.Write(zeroCount);
                }
                
                Console.WriteLine($"Найдено нулевых элементов: {zeroCount}");
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}