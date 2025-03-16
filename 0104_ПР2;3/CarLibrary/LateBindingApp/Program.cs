using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("***** Функция с поздним связыванием *****");
        // Попытка загрузить локальную копию CarLibrary.
        Assembly a = null;
        try
        {
            a = Assembly.Load("CarLibrary");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        if (a != null)
        {
            CreateUsingLateBinding(a);
            InvokeMethodWithArgsUsingLateBinding(a);
            Console.ReadLine();
        }
    }

    static void CreateUsingLateBinding(Assembly asm)
    {
        try
        {
            // Получить метаданные для типа Minivan.
            Type miniVan = asm.GetType("CarLibrary.MiniVan");

            // Создание экземпляра типа Minivan динамически.
            object obj = Activator.CreateInstance(miniVan);
            Console.WriteLine("Created a {0} using late binding!", obj);
            // Получение информации о TurboBoost.
            MethodInfo mi = miniVan.GetMethod("TurboBoost");

            // Вызвать метод ('null' означает, что параметров нет).
            mi.Invoke(obj, null);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    static void InvokeMethodWithArgsUsingLateBinding(Assembly asm)
    {
        try
        {
            // Сначала получим метаданные для типа SportsCar.
            Type sport = asm.GetType("CarLibrary.SportsCar");

            // Затем создадим экземпляр типа SportsCar динамически.
            object obj = Activator.CreateInstance(sport);
            // Вызов метода TurnOnRadio() с аргументами.
            MethodInfo mi = sport.GetMethod("TurnOnRadio");
            mi.Invoke(obj, new object[] { true, 2 });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}