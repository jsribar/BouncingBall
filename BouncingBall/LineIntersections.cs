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

        public IEnumerable<CollisionPoint> GetCollisionPoints(IEnumerable<ICollisionObject> planes)
        {
            List<CollisionPoint> collisionPoints = new List<CollisionPoint>();
            foreach (ICollisionObject plane in planes)
            {
                IEnumerable<PointD> intersections = plane.GetIntersections(line0);
                foreach(PointD intersection in intersections)
                    collisionPoints.Add(new CollisionPoint(plane, intersection));
            }
            return collisionPoints;
        }

        public IEnumerable<CollisionPoint> GetClosestCollisionPoints(IEnumerable<ICollisionObject> planes)
        {
            IEnumerable<CollisionPoint> allCollisionPoints = GetCollisionPoints(planes);
            if (allCollisionPoints.Count() == 0)
                return allCollisionPoints;
            double minimalDistance = allCollisionPoints.Min(cp => cp.Point.Distance(line0.P1));
            return allCollisionPoints.Where(cp => cp.Point.Distance(line0.P1).IsAllmostEqual(minimalDistance));
        }

        public readonly Line line0;
    }
}
