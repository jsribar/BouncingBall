using System;
using System.Linq;
using System.Collections.Generic;

namespace Vsite.Pood.BouncingBall
{
    class CrashBrick : ICollisionObject
    {
        public CrashBrick(PointD leftTop, PointD rightBottom, double ballRadius)
        {
            LeftTop = leftTop;
            RightBottom = rightBottom;
            double yTop = leftTop.Y - ballRadius;
            double xLeft = leftTop.X - ballRadius;
            double yBottom = rightBottom.Y + ballRadius;
            double xRight = rightBottom.X + ballRadius;
            collisionPlanes = CreateOuterPlanes(xLeft, yTop, xRight, yBottom);
        }

        private List<CollisionPlane> CreateOuterPlanes(double xLeft, double yTop, double xRight, double yBottom)
        {
            List<CollisionPlane> planes = new List<CollisionPlane>();
            planes.Add(new CollisionPlane(new PointD(xLeft, yTop), new PointD(xRight, yTop)));
            planes.Add(new CollisionPlane(new PointD(xRight, yTop), new PointD(xRight, yBottom)));
            planes.Add(new CollisionPlane(new PointD(xLeft, yBottom), new PointD(xRight, yBottom)));
            planes.Add(new CollisionPlane(new PointD(xLeft, yTop), new PointD(xLeft, yBottom)));
            return planes;
        }

        public IEnumerable<CollisionPoint> GetCollisionPoints(Line line)
        {
            List<CollisionPoint> points = new List<CollisionPoint>();
            foreach (CollisionPlane plane in collisionPlanes)
            {
                points.AddRange(plane.GetCollisionPoints(line));
            }
            return points;
        }

        protected IEnumerable<CollisionPlane> CollisionPlanes
        {
            get { return collisionPlanes; }
        }

        private List<CollisionPlane> collisionPlanes;
        public readonly PointD LeftTop;
        public readonly PointD RightBottom;
    }
}
