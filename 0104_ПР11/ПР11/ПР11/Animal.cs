using System;
using System.Threading;

class Animal
{
    private static readonly Semaphore sem = new Semaphore(4, 4);

    public Thread MyThread;

    int saityCount = 0;
    const int FULLSAITY = 5;

    public Animal(int i)
    {
        MyThread = new Thread(Eat)
        {
            Name = $"Животное {i}"
        };
        MyThread.Start();
    }

    public void Eat()
    {
        try
        {
            while (saityCount < FULLSAITY)
            {
                sem.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name} заходит на поляну.");

                Console.WriteLine($"{Thread.CurrentThread.Name} ест.");
                Thread.Sleep(1000); 

                saityCount++;
                Console.WriteLine($"{Thread.CurrentThread.Name} поело {saityCount} из {FULLSAITY} раз.");

                Console.WriteLine($"{Thread.CurrentThread.Name} покидает поляну.");
                sem.Release();

                Thread.Sleep(1000);
            }
            Console.WriteLine($"{Thread.CurrentThread.Name} наелось и завершило питание.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка у {Thread.CurrentThread.Name}: {ex.Message}");
        }
    }
}