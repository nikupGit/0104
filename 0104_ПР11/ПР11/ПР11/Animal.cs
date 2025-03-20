using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ПР11
{
    class Animal
    {
        private static Semaphore sem; // Семафор для управления доступом
        private Thread myThread; // Поток животного
        private int id; // Идентификатор животного
        private int satiety; // Текущий уровень сытости
        private int satietyLevel; // Требуемый уровень сытости
        private static object lockObj = new object(); // Объект для синхронизации
        private static int animalsFed; // Счётчик наевшихся животных
        private static int totalAnimals; // Общее количество животных

        public Animal(int id, Semaphore semaphore, int satietyLevel, ref int animalsFed, int totalAnimals)
        {
            this.id = id;
            sem = semaphore;
            this.satietyLevel = satietyLevel;
            Animal.animalsFed = animalsFed;
            Animal.totalAnimals = totalAnimals;
            myThread = new Thread(Eat); // Создаём поток для процесса питания
            myThread.Name = $"Животное {id}";
            myThread.Start(); // Запускаем поток
        }

        public void Eat()
        {
            try
            {
                while (satiety < satietyLevel)
                {
                    sem.WaitOne(); // Ожидаем доступ к поляне
                    try
                    {
                        Console.WriteLine($"{Thread.CurrentThread.Name} входит на поляну");
                        Console.WriteLine($"{Thread.CurrentThread.Name} ест");
                        Thread.Sleep(1000); // Имитация времени еды
                        satiety++; Console.WriteLine($"\n{Thread.CurrentThread.Name} Сыто на {satiety} из 3"); // Увеличиваем сытость
                        Console.WriteLine($"{Thread.CurrentThread.Name} покидает поляну");
                    }
                    finally
                    {
                        sem.Release(); // Освобождаем место на поляне
                    }
                    Thread.Sleep(1000); // Имитация отдыха перед следующим приёмом пищи
                }
            }
            catch (ThreadInterruptedException ex)
            {
                Console.WriteLine($"Поток {Thread.CurrentThread.Name} был прерван: {ex.Message}");
            }
            finally
            {
                // Животное наелось
                lock (lockObj) // Синхронизируем доступ к общему счётчику
                {
                    animalsFed++; // Увеличиваем счётчик наевшихся животных
                    Console.WriteLine($"{Thread.CurrentThread.Name} наелось и ушло. Всего наевшихся: {animalsFed}");

                    // Проверяем, все ли животные наелись
                    if (animalsFed == totalAnimals)
                    {
                        Console.WriteLine("Все животные наелись!");
                    }
                }
            }
        }
    }
}