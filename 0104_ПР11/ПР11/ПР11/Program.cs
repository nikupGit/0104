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
            int totalAnimals = 7;
            int maxAnimalsOnField = 4;
            int satietyLevel = 3;

            // Создаём семафор с заданным количеством слотов
            Semaphore sem = new Semaphore(maxAnimalsOnField, maxAnimalsOnField);
            int animalsFed = 0; // Счётчик наевшихся животных

            // Создаём животных
            for (int i = 1; i <= totalAnimals; i++)
            {
                Animal animal = new Animal(i, sem, satietyLevel, ref animalsFed, totalAnimals);
            }
            Console.ReadLine();
        }
    }
}