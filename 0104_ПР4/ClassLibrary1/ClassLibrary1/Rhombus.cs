using System;


namespace ClassLibrary1
{
    public class Rhombus : Parallelogram
    {
        public Rhombus(Point a, Point b, Point c, Point d) : base(a, b, c, d)
        {
            // Проверка, что все стороны равны (условие ромба)
            if (!IsRhombus())
                throw new ArgumentException("Некорректные точки для ромба");
        }

        private bool IsRhombus()
        {
            double[] sides = GetSideLengths();
            return Math.Abs(sides[0] - sides[1]) < 1e-9 &&
                   Math.Abs(sides[1] - sides[2]) < 1e-9 &&
                   Math.Abs(sides[2] - sides[3]) < 1e-9;
        }

        // Переопределение метода вычисления площади (половина произведения диагоналей)
        public override double GetArea()
        {
            double[] diagonals = GetDiagonals();
            return (diagonals[0] * diagonals[1]) / 2;
        }
        
    }
}
