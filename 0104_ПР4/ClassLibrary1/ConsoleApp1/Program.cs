using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibrary1;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvexQuadrilateral[] shapes =
            {
                new Parallelogram(
                    new Point(0, 0),
                    new Point(2, 0),
                    new Point(3, 2),
                    new Point(1, 2)),

                new Rhombus(
                    new Point(0, 0),
                    new Point(1, 1),
                    new Point(0, 2),
                    new Point(-1, 1)),

                new Square(
                    new Point(0, 0),
                    new Point(1, 0),
                    new Point(1, 1),
                    new Point(0, 1))
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine($"Type: {shape.GetType().Name}");
                Console.WriteLine($"Sides: [{string.Join(", ", shape.GetSideLengths()):F2}]");
                Console.WriteLine($"Angles: [{string.Join(", ", shape.GetAngles()):F2}]");
                Console.WriteLine($"Diagonals: [{string.Join(", ", shape.GetDiagonals()):F2}]");
                Console.WriteLine($"Perimeter: {shape.GetPerimeter():F2}");
                Console.WriteLine($"Area: {shape.GetArea():F2}\n");
            }

            // Пример сравнения
            var square1 = new Square(
                new Point(0, 0),
                new Point(1, 0),
                new Point(1, 1),
                new Point(0, 1));

            var square2 = new Square(
                new Point(0, 0),
                new Point(1, 0),
                new Point(1, 1),
                new Point(0, 1));

            Console.WriteLine($"Square1 equals Square2: {square1.Equals(square2)}");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
