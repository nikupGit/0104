using System;

namespace ClassLibrary1
{
    public class Parallelogram : ConvexQuadrilateral
    {
        public Parallelogram(Point a, Point b, Point c, Point d) : base(a, b, c, d)
        {
            // Проверка, что точки образуют параллелограмм
            if (!IsParallelogram())
                throw new ArgumentException("Некорректные точки для параллелограмма");
        }

        // Проверка условия параллелограмма: противоположные стороны равны и параллельны
        private bool IsParallelogram()
        {
            var ab = (B.X - A.X, B.Y - A.Y);
            var dc = (C.X - D.X, C.Y - D.Y);

            return Math.Abs(ab.Item1 - dc.Item1) < 1e-9 &&
                   Math.Abs(ab.Item2 - dc.Item2) < 1e-9;
        }

        // Переопледеление метода вычисления площади
        public override double GetArea()
        {
            double baseLength = CalculateDistance(A, B);
            Point adVector = new Point(D.X - A.X, D.Y - A.Y);

            // Высота через векторное произведение
            double height = Math.Abs((B.X - A.X) * adVector.Y - (B.Y - A.Y) * adVector.X) / baseLength;
            return baseLength * height;
        }

        // Переопределение метода вычисления углов (в параллелограмме противоположные углы равны)
        public override double[] GetAngles()
        {
            double angle = CalculateAngle(A, B, D);
            return new[] { angle, 180 - angle, angle, 180 - angle };
        }
    }
}
