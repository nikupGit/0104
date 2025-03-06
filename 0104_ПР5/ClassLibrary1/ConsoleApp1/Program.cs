using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using ClassLibrary1;


namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            try
            {
                #region 5.2 Создание объектов
                var demons = new List<Daemon>
                {
                    new Daemon("Azazel_Demon", 4),
                    new Daemon("Smaug_Dragon", 3),
                    new Daemon("LichKing_Undead", 5),
                    new Daemon("Grendel_Beast", 3),
                    new Daemon(120, 90, "Ifrit_Elemental", 2)
                };
                #endregion

                #region 5.3 Проверка допустимости
                var validDemons = new List<Daemon>();
                var validationResults = new List<ValidationResult>();

                foreach (var demon in demons)
                {
                    var context = new ValidationContext(demon);
                    bool isValid = Validator.TryValidateObject(demon, context, validationResults, true)
                                   && demon.IsValidBrain;

                    if (isValid)
                    {
                        validDemons.Add(demon);
                    }
                    validationResults.Clear();
                }
                #endregion

                #region 5.4 Вывод результатов
                Console.WriteLine("\nДопустимые демоны:");
                foreach (var demon in validDemons)
                {
                    Console.WriteLine($"- {demon.Name}");
                    demon.Passport();
                }
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
}