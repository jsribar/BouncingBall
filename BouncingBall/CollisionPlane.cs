using System;
using System.Collections.Generic;

namespace Vsite.Pood.BouncingBall
{
    class CollisionPlane : Line, ICollisionObject
    {
        public CollisionPlane(PointD p1, PointD p2) : base(p1, p2)
        {
            Angle = Math.Atan2(p2.Y - p1.Y, p2.X - p1.X);
        }

        #region ICollisionObject implementation

        public IEnumerable<CollisionPoint> GetCollisionPoints(Line line)
        {
            List<CollisionPoint> collisionPoints = new List<CollisionPoint>();
            foreach (PointD point in GetIntersections(line))
                collisionPoints.Add(new CollisionPoint(this, point));
            return collisionPoints;
        }

        public Velocity ChangeVelocity(Velocity vel)
        {
            double angle = vel.Angle;
            if (angle < 0)
                angle = -vel.Angle - 2 * Angle;
            else
                angle = -angle + 2 * Angle;
            while (angle > Math.PI)
                angle -= Math.PI;
            while (angle < -Math.PI)
                angle += Math.PI;
            return new Velocity(vel.Speed, angle);
        }

        #endregion ICollisionObject implementation

        public readonly double Angle;
    }
}
