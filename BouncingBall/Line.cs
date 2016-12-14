using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    class Line
    {
        // Line through two points is defined as: Ax + By + C = 0
        public Line(PointD p1, PointD p2)
        {
            P1 = p1;
            P2 = p2;
            A = p2.Y - p1.Y;
            B = p1.X - p2.X;
            C = -A * p1.X - B * p1.Y;
        }

        public IEnumerable<PointD> GetIntersections(Line line)
        {
            List<PointD> points = new List<PointD>();
            double det = B * line.A - line.B * A;
            if (det == 0)
                return points;

            double s = C + A * line.P1.X + B * line.P1.Y;
            // s = 0 means that line1 crosses starting point of line0
            if (s.IsAllmostEqual(0) || !IsFirstWithinRangeOfSecond(-s, det))
                return points;

            double t = line.C + line.A * P1.X + line.B * P1.Y;
            if (!IsFirstWithinRangeOfSecond(t, det))
                return points;

            s /= det;
            double x = line.P1.X + (s * line.B);
            double y = line.P1.Y - (s * line.A);
            points.Add(new PointD(x, y));
            return points;
        }

        private bool IsFirstWithinRangeOfSecond(double a, double b)
        {
            if (a >= 0 && b > 0)
                return a < b || a.IsAllmostEqual(b);
            if (a <= 0 && b < 0)
                return a > b || a.IsAllmostEqual(b);
            return false;
        }

        public readonly double A;
        public readonly double B;
        public readonly double C;
        public readonly PointD P1;
        public readonly PointD P2;
    }
}