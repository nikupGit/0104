//Обеспечьте перенаправление ввода на файл F,
//а вывода на файл G, и решите следующую задачу:
//в файле F хранятся средние температуры за каждый месяц года.
//В файле G для каждого месяца сохраните отклонение среднемесячной температуры от среднегодовой.
using System;
using System.IO;
using System.Linq;


namespace ПР7__2_
{
    internal class Program
    {
        static void Main()
        {
            using (StreamReader inFile = new StreamReader("F.txt"))
            using (StreamWriter outFile = new StreamWriter("G.txt"))
            {
                Console.SetIn(inFile);
                Console.SetOut(outFile);

                try
                {
                    #region Чтение файла и проверка
                    string input = Console.In.ReadToEnd();
                    double[] temps = input
                        .Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(double.Parse)
                        .ToArray();

                    if (temps.Length != 12)
                    {
                        Console.WriteLine("Ошибка: требуется ровно 12 значений температур");
                        return;
                    }
                    #endregion

                    #region Расчет и вывод данных в файл G.txt
                    Console.WriteLine("Средняя температура по месяцам за 2024 год: ");
                    for (int i = 0; i < temps.Length; i++) 
                        {
                            Console.Write(temps[i] + " ");
                        }
                    Console.WriteLine();

                    double avg = temps.Average();
                    Console.WriteLine($"Среднегодовая температура: {avg:F1}");

                    Console.WriteLine("Отклонение среднемесячной температуры от среднегодовой: ");
                    foreach (double temp in temps)
                    {
                        double deviation = temp - avg;
                        Console.Write($"{deviation:F1} ");
                    }
                    #endregion
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: некорректный формат числа в файле");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}
