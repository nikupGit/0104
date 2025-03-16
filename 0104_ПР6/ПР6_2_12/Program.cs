// 12. Занести в файл F 10 символов.
// Подсчитать количество символов до символа '*'.
using System;
using System.IO;
using System.Text;
namespace ПР6_2_12
{
    class Program
    {
        static void Main()
        {
            try
            {
                #region Ввод символов и запись в файл
                FileStream fchar = new FileStream("F.txt", FileMode.Create, FileAccess.ReadWrite);

                char[] x = new char[10];

                Console.WriteLine("Введите 10 символов");
                for (int i = 0; i < 10; ++i)
                {
                    x[i] = (char)Console.Read();
                    fchar.WriteByte((byte)x[i]);   // записывается элемент массива 
                }
                Console.ReadLine();
                #endregion

                #region Поиск '*' и вывод информации
                int a, count = 0;
                fchar.Seek(0, SeekOrigin.Begin);    // текущий указатель - на начало 
                bool starFound = false;
                for (int i = 0; i < 10; i++)
                {
                    a = fchar.ReadByte();
                    if (a == '*')
                    {
                        starFound = true;
                        break;
                    }
                    count++;
                }
                Console.WriteLine();

                Console.WriteLine("Текущая позиция в потоке " + fchar.Position);

                if (starFound) Console.WriteLine("Количесвто символов до \'*\': " + count);
                else Console.WriteLine("Символа \'*\' не найдено.");

                fchar.Close();
                #endregion
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка работы с файлом: " + e.Message);
            }
        }
    }
}
