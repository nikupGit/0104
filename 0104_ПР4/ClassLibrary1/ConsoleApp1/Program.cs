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
                Console.WriteLine($"Тип фигуры: {shape.GetType().Name}");
                Console.WriteLine($"Длины сторон: [{string.Join(" | ", shape.GetSideLengths()):F2}]");
                Console.WriteLine($"Размер углов: [{string.Join(" | ", shape.GetAngles()):F2}]");
                Console.WriteLine($"Длины диагоналей: [{string.Join(" | ", shape.GetDiagonals()):F2}]");
                Console.WriteLine($"Длина периметра: {shape.GetPerimeter():F2}");
                Console.WriteLine($"Размер площади: {shape.GetArea():F2}\n");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
