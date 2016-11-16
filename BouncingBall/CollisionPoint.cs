using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    class CollisionPoint
    {
        public CollisionPoint(CollisionPlane plane, PointD point)
        {
            Plane = plane;
            Point = point;
        }

        public readonly CollisionPlane Plane;
        public readonly PointD Point;
    }
}
