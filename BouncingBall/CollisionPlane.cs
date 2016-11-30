using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    class CollisionPlane : Line
    {
        public CollisionPlane(PointD p1, PointD p2) : base(p1, p2)
        {
            Angle = Math.Atan2(p2.Y - p1.Y, p2.X - p1.X);
        }

        public readonly double Angle;
    }
}