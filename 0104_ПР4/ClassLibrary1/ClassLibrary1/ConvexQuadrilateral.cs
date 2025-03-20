using System;
using System.Linq;


namespace ClassLibrary1
{
    // Базовый класс для выпуклых четырехугольников
    public class ConvexQuadrilateral
    {
        #region Поля для хранения координат вершин в порядке обхода
        public Point A { get; }
        public Point B { get; }
        public Point C { get; }
        public Point D { get; }

        // Конструктор с передачей координат вершин
        protected ConvexQuadrilateral(Point a, Point b, Point c, Point d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }
        #endregion

        #region Основные методы
        // Метод вычисления углов в градусах
        public virtual double[] GetAngles()
        {
            return new[]
            {
                CalculateAngle(A, B, D),
                CalculateAngle(B, C, A),
                CalculateAngle(C, D, B),
                CalculateAngle(D, A, C)
            };
        }

        // Метод вычисления длин диагоналей
        public virtual double[] GetDiagonals()
        {
            return new[]
            {
                CalculateDistance(A, C),
                CalculateDistance(B, D)
            };
        }

        // Метод вычисления длин сторон
        public virtual double[] GetSideLengths()
        {
            return new[]
            {
                CalculateDistance(A, B),
                CalculateDistance(B, C),
                CalculateDistance(C, D),
                CalculateDistance(D, A)
            };
        }

        // Метод вычисления периметра
        public virtual double GetPerimeter()
        {
            return GetSideLengths().Sum();
        }

        // Метод вычисления площади
        public virtual double GetArea()
        {
            // Вычисляем площадь по формуле шнурования для четырехугольника
            double term1 = A.X * B.Y - B.X * A.Y;
            double term2 = B.X * C.Y - C.X * B.Y;
            double term3 = C.X * D.Y - D.X * C.Y;
            double term4 = D.X * A.Y - A.X * D.Y;

            double area = 0.5 * Math.Abs(term1 + term2 + term3 + term4);
            return area;
        }
        #endregion

        #region Вспомогательные методы
        // Вспомогательный метод для вычисления расстояния между точками
        protected static double CalculateDistance(Point a, Point b)
        {
            double dx = b.X - a.X;
            double dy = b.Y - a.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        // Вспомогательный метод для вычисления угла между векторами
        protected static double CalculateAngle(Point vertex, Point end1, Point end2)
        {
            var v1 = (end1.X - vertex.X, end1.Y - vertex.Y);
            var v2 = (end2.X - vertex.X, end2.Y - vertex.Y);

            double dot = v1.Item1 * v2.Item1 + v1.Item2 * v2.Item2;
            double mag1 = Math.Sqrt(v1.Item1 * v1.Item1 + v1.Item2 * v1.Item2);
            double mag2 = Math.Sqrt(v2.Item1 * v2.Item1 + v2.Item2 * v2.Item2);

            if (mag1 == 0 || mag2 == 0) return 0;

            double cosTheta = dot / (mag1 * mag2);
            cosTheta = Math.Max(-1.0, Math.Min(1.0, cosTheta)); // Ограничение значения

            return Math.Acos(cosTheta) * (180.0 / Math.PI);
        }
        #endregion

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            ConvexQuadrilateral other = (ConvexQuadrilateral)obj;
            return A.Equals(other.A) &&
                   B.Equals(other.B) &&
                   C.Equals(other.C) &&
                   D.Equals(other.D);
        }
    }
}
