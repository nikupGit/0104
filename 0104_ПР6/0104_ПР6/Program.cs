// 12. Даны файлы F и G целых чисел, не превышающих 255.
// Занести в третий файл максимальные числа из стоящих на одинаковых позициях в файлах F и G.


using System;
using System.IO;
namespace ConsoleApplication1
{
    class Class1
    {
        static void Main()
        {
            try
            {
                #region Структуры для работы с файлами
                FileStream f = new FileStream("F.txt", FileMode.Open, FileAccess.Read);
                FileStream g = new FileStream("G.txt", FileMode.Open, FileAccess.Read);
                FileStream h = new FileStream("H.txt", FileMode.Create, FileAccess.Write);
                #endregion

                #region Определение длины файлов. Определение минимальной.
                long f_len = f.Length;
                long g_len = g.Length;
                long min_lenFG = Math.Min(g_len, f_len);
                #endregion

                #region Цикл чтения и сравнения байтов
                byte[] x = new byte[min_lenFG];
                int a_f, a_g;
                for (byte i = 0; i < min_lenFG; ++i)
                {
                    a_f = f.ReadByte();
                    a_g = g.ReadByte();

                    x[i] = (byte)(Math.Max(a_f, a_g));
                }
                h.Write(x, 0, (int)min_lenFG); // Запись результатов

                Console.WriteLine("Данные занечены в файл \'H.txt\'");
                f.Close();
                g.Close();
                h.Close();
                #endregion
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Оба или один из файлов не найден: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка работы с файлом: " + e.Message);
            }
        }
    }
}
