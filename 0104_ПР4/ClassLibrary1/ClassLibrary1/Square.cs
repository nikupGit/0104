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

        // Переопределение метода вычисления углов (все углы 90 градусов)
        public override double[] GetAngles()
        {
            return new[] { 90.0, 90.0, 90.0, 90.0 };
        }

        /*
        #region Переопределение Equals и GetHashCode
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        */
    }
}
