using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    class PointD // pointD kao point sa double tipom podataka poćšto već postoji sa floatom
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
