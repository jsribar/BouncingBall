using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    class Line
    {
        public Line(PointD p1, PointD p2)
        {
            A = p2.Y - p1.Y;
            B = p2.X - p1.X;
            C = A * p1.X + B * p1.Y;
        }

        public readonly double A;
        public readonly double B;
        public readonly double C;
    }
}
