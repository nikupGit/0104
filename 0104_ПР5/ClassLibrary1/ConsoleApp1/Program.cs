using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using SpiritLibrary;

namespace SpiritApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region Создание объектов Daemon
                List<Daemon> daemons = new List<Daemon>();
                CreateDaemon(daemons, "Lucifer_Demon", 3);
                CreateDaemon(daemons, "Azmodan_Demon", 2);
                CreateDaemon(daemons, "GoblinKing_Goblin", 4);
                CreateDaemon(daemons, "OrcLeader_Orc", 5);
                CreateDaemon(daemons, "Unknown", 3);
                #endregion

                #region Проверка уровня brain
                var validByBrain = ValidateBrain(daemons.ToArray());
                Console.WriteLine("Допустимые по brain:");
                validByBrain.ForEach(d => Console.WriteLine(d.Name));
                #endregion

                #region Проверка имени
                var validByName = ValidateNames(validByBrain);
                Console.WriteLine("\nДопустимые по имени:");
                validByName.ForEach(d => Console.WriteLine(d.Name));
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();

        }

        static void CreateDaemon(List<Daemon> list, string name, int brain)
        {
            try
            {
                list.Add(new Daemon(name, brain));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка создания {name}: {ex.Message}");
            }
        }

        static List<Daemon> ValidateBrain(Daemon[] daemons)
        {
            var valid = new List<Daemon>();
            foreach (var d in daemons)
            {
                var prop = typeof(Daemon).GetProperty("Brain");
                var attr = prop.GetCustomAttribute<MinBrainAttribute>();
                if (d.Brain >= attr.MinValue) valid.Add(d);
            }
            return valid;
        }

        static List<Daemon> ValidateNames(List<Daemon> daemons)
        {
            var valid = new List<Daemon>();
            var allowedTypes = ((AllowedMonsterTypesAttribute)Attribute.GetCustomAttribute(
                typeof(Monster).GetProperty("Name"), typeof(AllowedMonsterTypesAttribute))).AllowedTypes;

            foreach (var d in daemons)
            {
                var typeStr = d.Name.Split('_').Last();
                if (Enum.TryParse(typeStr, out MonsterType type) && allowedTypes.Contains(type))
                    valid.Add(d);
            }
            return valid;
        }
    }
}