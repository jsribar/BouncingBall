using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Pood.BouncingBall;

namespace Vsite.Pood.BouncingBallTests
{
    [TestClass]
    public class PointDTest
    {
        [TestMethod]
        public void PointD_DistanceReturns1ForTwoPointsPlacedHorizontally()
        {
            PointD p1 = new PointD(3, 4);
            PointD p2 = new PointD(4, 4);
            Assert.AreEqual(1, p1.distance(p2));
        }

        [TestMethod]
        public void PointD_DistanceReturns2ForTwoPointsPlacedVertically()
        {
            PointD p1 = new PointD(3, 4);
            PointD p2 = new PointD(4, 6);
            Assert.AreEqual(2, p1.distance(p2));
        }

        [TestMethod]
        public void PointD_DistanceReturns5ForTwoInclinedPoints()
        {
            PointD p1 = new PointD(0, 0);
            PointD p2 = new PointD(4, 3);
            Assert.AreEqual(5, p1.distance(p2));
        }
    }
}
