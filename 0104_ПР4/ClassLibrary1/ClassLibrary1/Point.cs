using System;


namespace ClassLibrary1
{
    // Структура для представления точки в двумерном пространстве
    public readonly struct Point : IEquatable<Point>
    {
        public double X { get; } // Координата X
        public double Y { get; } // Координата Y

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point other)
        {
            return Math.Abs(X - other.X) < 1e-9 && Math.Abs(Y - other.Y) < 1e-9;
        }

        /*
        public override bool Equals(object obj)
        {
            return obj is Point other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }
        */
    }
}
