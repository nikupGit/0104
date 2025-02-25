using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public struct Point : IEquatable<Point>
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point other)
        {
            return Math.Abs(X - other.X) < 1e-9 &&
                   Math.Abs(Y - other.Y) < 1e-9;
        }

        public override bool Equals(object obj)
        {
            return obj is Point point && Equals(point);
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
    }

    public abstract class ConvexQuadrilateral
    {
        public Point A { get; }
        public Point B { get; }
        public Point C { get; }
        public Point D { get; }

        protected ConvexQuadrilateral(Point a, Point b, Point c, Point d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        protected static double CalculateDistance(Point a, Point b)
        {
            double dx = b.X - a.X;
            double dy = b.Y - a.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

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

        public virtual double GetPerimeter()
        {
            return CalculateDistance(A, B) + CalculateDistance(B, C) +
                   CalculateDistance(C, D) + CalculateDistance(D, A);
        }

        public abstract double GetArea();

        public virtual double[] GetDiagonals()
        {
            return new[]
            {
                CalculateDistance(A, C),
                CalculateDistance(B, D)
            };
        }

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

        

        protected static double CalculateAngle(Point vertex, Point end1, Point end2)
        {
            var v1 = (end1.X - vertex.X, end1.Y - vertex.Y);
            var v2 = (end2.X - vertex.X, end2.Y - vertex.Y);

            double dot = v1.Item1 * v2.Item1 + v1.Item2 * v2.Item2;
            double mag1 = Math.Sqrt(v1.Item1 * v1.Item1 + v1.Item2 * v1.Item2);
            double mag2 = Math.Sqrt(v2.Item1 * v2.Item1 + v2.Item2 * v2.Item2);

            if (mag1 == 0 || mag2 == 0) return 0;

            double cosTheta = dot / (mag1 * mag2);
            cosTheta = cosTheta < -1.0 ? -1.0 : (cosTheta > 1.0 ? 1.0 : cosTheta);

            return Math.Acos(cosTheta) * (180.0 / Math.PI);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            ConvexQuadrilateral other = (ConvexQuadrilateral)obj;
            return A.Equals(other.A) && B.Equals(other.B) &&
                   C.Equals(other.C) && D.Equals(other.D);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = hash * 23 + A.GetHashCode();
                hash = hash * 23 + B.GetHashCode();
                hash = hash * 23 + C.GetHashCode();
                hash = hash * 23 + D.GetHashCode();
                return hash;
            }
        }
    }

    public class Parallelogram : ConvexQuadrilateral
    {
        public Parallelogram(Point a, Point b, Point c, Point d) : base(a, b, c, d)
        {
            if (!IsParallelogram())
                throw new ArgumentException("Некорректные точки параллелограмма");
        }

        private bool IsParallelogram()
        {
            var ab = (B.X - A.X, B.Y - A.Y);
            var dc = (C.X - D.X, C.Y - D.Y);
            var bc = (C.X - B.X, C.Y - B.Y);
            var ad = (D.X - A.X, D.Y - A.Y);

            return Math.Abs(ab.Item1 - dc.Item1) < 1e-9 &&
                   Math.Abs(ab.Item2 - dc.Item2) < 1e-9 &&
                   Math.Abs(bc.Item1 - ad.Item1) < 1e-9 &&
                   Math.Abs(bc.Item2 - ad.Item2) < 1e-9;
        }

        public override double GetArea()
        {
            double baseLength = CalculateDistance(A, B);
            Point adVector = new Point(D.X - A.X, D.Y - A.Y);
            double height = Math.Abs((B.X - A.X) * adVector.Y - (B.Y - A.Y) * adVector.X) / baseLength;
            return baseLength * height;
        }

        public override double[] GetAngles()
        {
            double angle = CalculateAngle(A, B, D);
            return new[] { angle, 180 - angle, angle, 180 - angle };
        }
    }

    public class Rhombus : Parallelogram
    {
        public Rhombus(Point a, Point b, Point c, Point d) : base(a, b, c, d)
        {
            if (!IsRhombus())
                throw new ArgumentException("Некорректные точки ромба");
        }

        private bool IsRhombus()
        {
            double ab = CalculateDistance(A, B);
            double bc = CalculateDistance(B, C);
            double cd = CalculateDistance(C, D);
            double da = CalculateDistance(D, A);

            return Math.Abs(ab - bc) < 1e-9 &&
                   Math.Abs(bc - cd) < 1e-9 &&
                   Math.Abs(cd - da) < 1e-9;
        }

        public override double GetArea()
        {
            return (CalculateDistance(A, C) * CalculateDistance(B, D)) / 2;
        }
    }

    public class Square : Rhombus
    {
        public Square(Point a, Point b, Point c, Point d) : base(a, b, c, d)
        {
            if (!IsSquare())
                throw new ArgumentException("Некорректные точки квадрата");
        }

        private bool IsSquare()
        {
            double angle = CalculateAngle(A, B, D);
            return Math.Abs(angle - 90) < 1e-9;
        }

        public override double GetArea()
        {
            return Math.Pow(CalculateDistance(A, B), 2);
        }

        public override double[] GetAngles()
        {
            return new[] { 90.0, 90.0, 90.0, 90.0 };
        }
    }
}