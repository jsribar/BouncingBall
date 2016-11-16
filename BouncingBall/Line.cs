﻿using System;
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
            C = - A * p1.X - B * p1.Y;
        }

        public readonly double A;
        public readonly double B;
        public readonly double C;
        public readonly PointD P1;
        public readonly PointD P2;
    }
}
