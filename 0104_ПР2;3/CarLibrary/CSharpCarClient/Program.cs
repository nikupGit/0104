using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLibrary; // Не забудьте импортировать пространство имен CarLibrary!
namespace CSharpCarClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** C# CarLibrary Client App *****");
            // Создание объекта спортивной машины.
            SportsCar viper = new SportsCar("Viper", 240, 40);
            viper.TurboBoost();
            // Создание объекта минивена.
            MiniVan mv = new MiniVan();
            mv.TurboBoost();
            Console.WriteLine("Done. Press any key to terminate");
            Console.ReadKey();
        }
    }
}
