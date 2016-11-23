using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Pood.BouncingBall;

namespace Vsite.Pood.BouncingBallTests
{
    [TestClass]
    public class LineTest
    {
        [TestMethod]
        public void Line_CoefficientsForHorizontalLine()
        {
            PointD p1 = new PointD(5, 3);
            PointD p2 = new PointD(9, 3);
            Line line = new Line(p1, p2);
            Assert.AreEqual(0, line.A, 1e-5);
            Assert.AreEqual(-4, line.B, 1e-5);
            Assert.AreEqual(12, line.C, 1e-5);
        }

        [TestMethod]
        public void Line_CoefficientsForVerticalLine()
        {
            PointD p1 = new PointD(3, 5);
            PointD p2 = new PointD(3, 9);
            Line line = new Line(p1, p2);
            Assert.AreEqual(4, line.A, 1e-5);
            Assert.AreEqual(0, line.B, 1e-5);
            Assert.AreEqual(-12, line.C, 1e-5);
        }

        [TestMethod]
        public void Line_CoefficientsForInclinedLineAt45Deg()
        {
            PointD p1 = new PointD(3, 3);
            PointD p2 = new PointD(5, 5);
            Line line = new Line(p1, p2);
            Assert.AreEqual(2, line.A, 1e-5);
            Assert.AreEqual(-2, line.B, 1e-5);
            Assert.AreEqual(0, line.C, 1e-5);
        }

        [TestMethod]
        public void Line_CoefficientsForInclinedLineAt45DegVerticallyOffset()
        {
            PointD p1 = new PointD(3, 5);
            PointD p2 = new PointD(5, 7);
            Line line = new Line(p1, p2);
            Assert.AreEqual(2, line.A, 1e-5);
            Assert.AreEqual(-2, line.B, 1e-5);
            Assert.AreEqual(4, line.C, 1e-5);
        }
    }
}
