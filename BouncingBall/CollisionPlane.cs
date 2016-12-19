using System;
using System.Collections.Generic;

namespace Vsite.Pood.BouncingBall
{
    class CollisionPlane : HittableObject, ICollisionObject
    {
        public CollisionPlane(PointD p1, PointD p2)
        {
            Line = new Line(p1, p2);
            Angle = Math.Atan2(p2.Y - p1.Y, p2.X - p1.X);
        }

        #region ICollisionObject implementation

        public IEnumerable<CollisionPoint> GetCollisionPoints(Line line)
        {
            List<CollisionPoint> collisionPoints = new List<CollisionPoint>();
            foreach (PointD point in Line.GetIntersections(line))
                collisionPoints.Add(new CollisionPoint(this, point));
            return collisionPoints;
        }

        #endregion ICollisionObject implementation

        #region HittableObject override

        protected override Velocity ChangeVelocity(Velocity velocity, CollisionPoint collisionPoint)
        {
            velocity.Bounce(Angle);
            return velocity;
        }

        #endregion HittableObject override

        public readonly double Angle;
        public readonly Line Line;
    }
}
