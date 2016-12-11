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

        public Velocity ChangeVelocity(Velocity vel)
        {
            return Plane.ChangeVelocity(vel);
        }

        public readonly ICollisionObject Plane;
        public readonly PointD Point;
    }
}
