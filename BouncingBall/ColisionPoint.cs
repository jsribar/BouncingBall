using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    class ColisionPoint
    {
        public ColisionPoint(ColisionPlane plane, PointD point)
        {
            Plane = plane;
            Point = point;
        }

        public readonly ColisionPlane Plane;
        public readonly PointD Point;
    }
}
