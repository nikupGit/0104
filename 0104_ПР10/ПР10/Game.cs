using System;


namespace ПР10
{
    public class Game
    {
        private GameEvent events = new GameEvent();

        private int x = 15;
        private int y = 15;

        public event EventHandler<OutOfBoundsEventArgs> OutOfBounds
        {
            add { events.OutOfBounds += value; }
            remove { events.OutOfBounds -= value; }
        }

        public void Start()
        {
            bool up, left, right, down;
            while (true)
            {
                Console.WriteLine("Игра лабиринт. Для завершения нажмите Esc.");
                Console.WriteLine($"Позиция на карте: X {x} Y {y}");
                up = true; left = true; right = true; down = true;
                Draw(x, y, ref up, ref left, ref right, ref down);
                Console.SetCursorPosition(x, y);
                Console.Write("*");

                var key = Console.ReadKey().Key;
                int newX = x;
                int newY = y;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        newY--;
                        if (newY < 5)
                        {
                            events.OnOutOfBounds(this, x, newY + 1);
                        }
                        else if (up)
                        {
                            y = newY;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        newY++;
                        if (newY > 20)
                        {
                            events.OnOutOfBounds(this, x, newY - 1);
                        }
                        else if (down)
                        {
                            y = newY;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        newX--;
                        if (newX < 10)
                        {
                            events.OnOutOfBounds(this, newX + 1, y);
                        }
                        else if (left)
                        {
                            x = newX;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        newX++;
                        if (newX > 45)
                        {
                            events.OnOutOfBounds(this, newX - 1, y);
                        }
                        else if (right)
                        {
                            x = newX;
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        return;
                    default:
                        break;
                }
                Console.Clear();
            }
        }

        private void Draw(int x, int y, ref bool up, ref bool left, ref bool right, ref bool down)
        {
            DrawHLine(x, y, 10, 30, 5, ref up, ref down);
            DrawVLine(x, y, 5, 10, 30, ref left, ref right);
            DrawHLine(x, y, 30, 43, 10, ref up, ref down);
            DrawVLine(x, y, 5, 10, 40, ref left, ref right);
            DrawHLine(x, y, 40, 45, 5, ref up, ref down);
            DrawVLine(x, y, 5, 16, 45, ref left, ref right);
            DrawVLine(x, y, 18, 20, 45, ref left, ref right);
            DrawHLine(x, y, 10, 45, 20, ref up, ref down);
            DrawVLine(x, y, 5, 15, 10, ref left, ref right);
            DrawVLine(x, y, 17, 20, 10, ref left, ref right);
        }

        private void DrawHLine(int x, int y, int from, int to, int yLine, ref bool up, ref bool down)
        {
            for (int i = from; i <= to; i++)
            {
                if ((y - yLine == -1) && (x >= from) && (x <= to)) down = false;
                if ((y - yLine == 1) && (x >= from) && (x <= to)) up = false;
                Console.SetCursorPosition(i, yLine);
                Console.Write("#");
            }
        }

        private void DrawVLine(int x, int y, int from, int to, int xLine, ref bool left, ref bool right)
        {
            for (int i = from; i <= to; i++)
            {
                if ((x - xLine == -1) && (y >= from) && (y <= to)) right = false;
                if ((x - xLine == 1) && (y >= from) && (y <= to)) left = false;
                Console.SetCursorPosition(xLine, i);
                Console.Write("#");
            }
        }
    }
}