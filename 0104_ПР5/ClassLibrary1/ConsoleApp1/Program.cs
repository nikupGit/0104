using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ClassLibrary1;


namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            try
            {
                #region Объявление объектов
                Daemon[] daemons = null;

                try
                {
                    daemons = new Daemon[]
                    {
                    new Daemon("Azazel", 2),
                    new Daemon("Beelzebub", 3),
                    new Daemon("Mephisto", 5),
                    new Daemon("Lucifer", 1),
                    new Daemon(-10, 50, "InvalidHealth", 4) // Пример некорректного объекта
                    };
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Ошибка при создании объектов Daemon", ex);
                }
                #endregion

                #region Проверка на допустимость
                Daemon[] validDaemons = null;

                try
                {
                    if (daemons == null)
                        throw new InvalidOperationException("Массив демонов не инициализирован");

                    validDaemons = daemons.Where(d => d != null && d.IsValid).ToArray();

                    if (!validDaemons.Any())
                        throw new InvalidOperationException("Нет допустимых объектов Daemon");
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Ошибка при проверке объектов", ex);
                }
                #endregion

                #region Вывод результатов
                try
                {
                    Console.WriteLine("Допустимые демоны:");
                    foreach (var daemon in validDaemons)
                    {
                        Console.WriteLine(daemon.Name);
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Ошибка при выводе результатов", ex);
                }
                #endregion
            }
            catch (ApplicationException appEx)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Критическая ошибка: {appEx.Message}");
                Console.WriteLine($"Подробности: {appEx.InnerException?.Message}");
                Console.ResetColor();
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
                Console.ResetColor();
                Environment.Exit(1);
            }
        }
    }
}