using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Pood.BouncingBall;

namespace Vsite.Pood.BouncingBallTests
{
    [TestClass]
    public class PointDTest
    {
        [TestMethod]
        public void PointD_DistanceReturns1ForToPointsPlacedHorizontally()
        {
            PointD p1 = new PointD(3, 4);
            PointD p2 = new PointD(4, 4);
            Assert.AreEqual(1, p1.Distance(p2));
        }

        [TestMethod]
        public void PointD_DistanceReturns2ForToPointsPlacedVertically()
        {
            PointD p1 = new PointD(3, 4);
            PointD p2 = new PointD(3, 6);
            Assert.AreEqual(2, p1.Distance(p2));
        }

        [TestMethod]
        public void PointD_DistanceReturns5ForToInclinedPoints()
        {
            PointD p1 = new PointD(0, 0);
            PointD p2 = new PointD(4, 3);
            Assert.AreEqual(5, p1.Distance(p2));
        }
    }
}
