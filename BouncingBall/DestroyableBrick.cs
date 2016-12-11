using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    class DestroyableBrick : ICollisionObject
    {
        public DestroyableBrick(PointD leftTop, PointD rightBottom, double ballRadius)
        {
            LeftTop = leftTop;
            RightBottom = rightBottom;
            double yTop = leftTop.Y - ballRadius;
            double xLeft = leftTop.X - ballRadius;
            double yBottom = rightBottom.Y + ballRadius;
            double xRight = rightBottom.X + ballRadius;
            outerPlanes = CreateOuterPlanes(xLeft, yTop, xRight, yBottom);
        }
        public Velocity ChangeVelocity(Velocity vel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PointD> GetIntersections(Line line)
        {
            List<PointD> points = new List<PointD>();
            foreach (CollisionPlane plane in outerPlanes)
            {
                points.AddRange(plane.GetIntersections(line));
            }
            return points;
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

        private List<CollisionPlane> outerPlanes;
        public readonly PointD LeftTop;
        public readonly PointD RightBottom;
    }
}
