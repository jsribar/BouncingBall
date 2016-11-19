using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    class LineIntersections
    {
        public LineIntersections(Line line)
        {
            this.line0 = line;
        }

        public PointD GetIntersection(Line line1)
        {
            double det = line1.B * line0.A - line0.B * line1.A;
            double s = line0.C + line0.A * line1.P1.X + line0.B * line1.P1.Y;
            double t = -line1.C - line1.B * line0.P1.Y - line1.A * line0.P1.X;

            if (IsFirstWithinRangeOfSecond(s, det) && IsFirstWithinRangeOfSecond(t, det))
            {
                t /= det;
                double x = line0.P1.X - (t * line0.B);
                double y = line0.P1.Y + (t * line0.A);
                return new PointD(x, y);
            }
            return null;
        }

        bool IsFirstWithinRangeOfSecond(double a, double b)
        {
            if (a >= 0 && b > 0)
                return a <= b;
            if (a <= 0 && b < 0)
                return a >= b;
            return false;
        }

        public IEnumerable<CollisionPoint> GetCollisionPoints(IEnumerable<CollisionPlane> planes)
        {
            List<CollisionPoint> collisionPoints = new List<CollisionPoint>();
            foreach (CollisionPlane plane in planes)
            {
                PointD intersection = GetIntersection(plane);
                if (intersection != null)
                    collisionPoints.Add(new CollisionPoint(plane, intersection));
            }
            return collisionPoints;
        }

        public IEnumerable<CollisionPoint> GetClosestCollisionPoints(IEnumerable<CollisionPlane> planes)
        {
            IEnumerable<CollisionPoint> allCollisionPoints = GetCollisionPoints(planes);
            double minimalDistance = allCollisionPoints.Min(cp => cp.Point.Distance(line0.P1));
            return allCollisionPoints.Where(cp => cp.Point.Distance(line0.P1) == minimalDistance);
        }

        private Line line0;
    }
}
