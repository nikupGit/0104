using System;


namespace ПР10
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.OutOfBounds += (sender, e) =>
            {
                Console.SetCursorPosition(0, 24);
                Console.WriteLine($"Попытка выйти за пределы лабиринта на координатах ({e.X}, {e.Y})");
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
            };
            game.Start();
        }
    }
}