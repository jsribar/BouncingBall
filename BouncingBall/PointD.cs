using System;

namespace Vsite.Pood.BouncingBall
{
    class PointD
    {
        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Distance(PointD other)
        {
            return Math.Sqrt((X - other.X) * (X - other.X) + (Y - other.Y) * (Y - other.Y));
        }

        public double X;
        public double Y;
    }
}