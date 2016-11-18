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
            double det = line0.A * line1.B - line1.A * line0.B;
            if (det == 0)
                return null;
            double x = (line0.B * line1.C - line1.B * line0.C) / det;
            double y = (line1.A * line0.C - line0.A * line1.C) / det;
            return new PointD(x, y);
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
