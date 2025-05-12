using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ПР11
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                const int NUMBEROFANIMALS = 7;
                Animal[] animals = new Animal[NUMBEROFANIMALS];

                for (int i = 0; i < NUMBEROFANIMALS; i++)
                {
                    animals[i] = new Animal(i + 1);
                }
                foreach (Animal animal in animals)
                {
                    animal.MyThread.Join();
                }

                Console.WriteLine("\nВсе животные наелись!");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: ", e.Message);
            }
        }
    }
}