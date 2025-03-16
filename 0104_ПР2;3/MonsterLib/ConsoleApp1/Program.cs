using System;

namespace ConsoleApplication1
{
    using MonsterLib;
    class Classl
    {
        static void Main()
        {
            const int n = 3;
            Monster[] stado = new Monster[n];
            stado[0] = new Monster("Monia");
            stado[1] = new Monster("Monk");
            stado[2] = new Daemon("Dimon", 3);
            foreach (Monster elem in stado) elem.Passport();
            for (int i = 0; i < n; ++i) stado[i].Ammo = 0;
            Console.WriteLine();
            foreach (Monster elem in stado) elem.Passport();
        }
    }
}
