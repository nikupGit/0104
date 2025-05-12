using System;


namespace ClassLibrary1
{
    public class Square : Rhombus
    {
        public Square(Point a, Point b, Point c, Point d) : base(a, b, c, d)
        {
            // Проверка, что углы равны 90 градусам (условие квадрата)
            if (!IsSquare())
                throw new ArgumentException("Некорректные точки для квадрата");
        }

        private bool IsSquare()
        {
            double angle = CalculateAngle(A, B, D);
            return Math.Abs(angle - 90) < 1e-9;
        }
        public override double[] GetDiagonals()
        {
            return new[]
            {
                CalculateDistance(A, C)
            };
        }
        public override double GetArea()
        {
            double[] sides = GetSideLengths();
            return Math.Pow(sides[0], 2);
        }
        public override double[] GetAngles()
        {
            return new[] { 90.0, 90.0, 90.0, 90.0 };
        } 
    }
}
