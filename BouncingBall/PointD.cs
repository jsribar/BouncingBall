using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    class PointD
    {
        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double distance(PointD other)
        {
            return Math.Sqrt(X - other.X) * Math.Sqrt(X - other.X) + (Y - other.Y) * (Y - other.Y);
        }

        public double X;
        public double Y;
    }
}
