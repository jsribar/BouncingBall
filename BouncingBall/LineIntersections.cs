using System.Collections.Generic;
using System.Linq;

namespace Vsite.Pood.BouncingBall
{
    class LineIntersections
    {
        public LineIntersections(Line line)
        {
            this.line = line;
        }

        public IEnumerable<CollisionPoint> GetCollisionPoints(IEnumerable<ICollisionObject> collisionObjects)
        {
            List<CollisionPoint> collisionPoints = new List<CollisionPoint>();
            foreach (ICollisionObject collisionObject in collisionObjects)
                collisionPoints.AddRange(collisionObject.GetCollisionPoints(line));
            return collisionPoints;
        }

        public IEnumerable<CollisionPoint> GetClosestCollisionPoints(IEnumerable<ICollisionObject> planes)
        {
            IEnumerable<CollisionPoint> allCollisionPoints = GetCollisionPoints(planes);
            if (allCollisionPoints.Count() == 0)
                return allCollisionPoints;
            double minimalDistance = allCollisionPoints.Min(cp => cp.Point.Distance(line.P1));
            return allCollisionPoints.Where(cp => cp.Point.Distance(line.P1).IsAllmostEqual(minimalDistance));
        }

        public readonly Line line;
    }
}
