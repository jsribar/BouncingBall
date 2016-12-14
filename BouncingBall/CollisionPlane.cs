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

        public Velocity Hit(Velocity vel, CollisionPoint point)
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

        public IEnumerable<PointD> GetIntersections(Line line0)
        {
            List<PointD> points = new List<PointD>();
            double det = B * line0.A - line0.B * A;
            if (det == 0)
                return null;

            double s = C + A * line0.P1.X + B * line0.P1.Y;
            // s = 0 means that line1 crosses starting point of line0
            if (s.IsAllmostEqual(0) || !IsFirstWithinRangeOfSecond(-s, det))
                return null;

            double t = line0.C + line0.A * P1.X + line0.B * P1.Y;
            if (!IsFirstWithinRangeOfSecond(t, det))
                return null;

            s /= det;
            double x = line0.P1.X + (s * line0.B);
            double y = line0.P1.Y - (s * line0.A);
            points.Add(new PointD(x, y));
            return points;
        }

        private bool IsFirstWithinRangeOfSecond(double t, double det)
        {
            throw new NotImplementedException();
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
            return new Velocity(vel.speed, angle);
        }
    }
}