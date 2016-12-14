using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    class CollisionPoint
    {
        public CollisionPoint(ICollisionObject plane, PointD point)
        {
            Plane = plane;
            Point = point;
        }
        public readonly ICollisionObject Plane;
        public readonly PointD Point;
    }

}

