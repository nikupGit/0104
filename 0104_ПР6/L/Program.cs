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
                FileStream f = new FileStream("F.txt", FileMode.Create, FileAccess.Read);
                FileStream g = new FileStream("G.txt", FileMode.Create, FileAccess.Read);
                FileStream h = new FileStream("H.txt", FileMode.Create, FileAccess.Read);

                #region Определение длины файлов. Определение минимальной.
                long f_len = f.Length;
                long g_len = g.Length;
                long min_lenFG = Math.Min(g_len, f_len);
                #endregion

                byte[] x = new byte[min_lenFG];

                int a_f, a_g;
                for (byte i = 0; i < min_lenFG; ++i)
                {
                    a_f = f.ReadByte();
                    a_g = g.ReadByte();

                    x[i] = (byte)(Math.Max(a_f, a_g));
                }
                h.Write(x, 0, (int)min_lenFG);
                
                Console.WriteLine("Данные занечены в файл \'H.txt\'");
                f.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка работы с файлом: " + e.Message);
            }
        }
    }
}
