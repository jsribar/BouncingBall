using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Pood.BouncingBall;
using System.Linq;

namespace Vsite.Pood.BouncingBallTests
{
    [TestClass]
    public class CrashBrickTest
    {
        [TestMethod]
        public void CrashBrick_GetCollisionPointsReturns2PointsForABrickCrossingTheLine()
        {
            Line line = new Line(new PointD(0, 5), new PointD(20, 5));
            CrashBrick brick = new CrashBrick(new PointD(3, 6), new PointD(8, 4), 1);

            var collisionPoints = brick.GetCollisionPoints(line);
            Assert.AreEqual(2, collisionPoints.Count());

            var point1 = collisionPoints.ElementAt(0);
            Assert.IsTrue(point1.Point.X.IsAllmostEqual(2) || point1.Point.X.IsAllmostEqual(9));
            Assert.IsTrue(point1.Point.Y.IsAllmostEqual(5));
            var point2 = collisionPoints.ElementAt(1);
            Assert.IsTrue(point2.Point.X.IsAllmostEqual(2) || point1.Point.X.IsAllmostEqual(9));
            Assert.IsTrue(point2.Point.Y.IsAllmostEqual(5));
        }
    }
}
