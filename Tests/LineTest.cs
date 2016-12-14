using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
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
        
        [TestMethod]
        public void Line_GetIntersectionReturnsIntersectionPointForTwoOrtogonalLineSections()
        {
            Line line1 = new Line(new PointD(5, 3), new PointD(9, 3));
            Line line2 = new Line(new PointD(6, 2), new PointD(6, 7));
            IEnumerable<PointD> points = line2.GetIntersections(line1);
            Assert.AreEqual(1, points.Count());
            PointD point = points.First();
            Assert.AreEqual(6, point.X, 1e-5);
            Assert.AreEqual(3, point.Y, 1e-5);
        }

        [TestMethod]
        public void Line_GetIntersectionReturnsNullForTwoInclinedLineSections()
        {
            Line line1 = new Line(new PointD(5, 3), new PointD(5, 7));
            Line line2 = new Line(new PointD(6, 4), new PointD(6, 7));
            IEnumerable<PointD> points = line2.GetIntersections(line1);
            Assert.AreEqual(0, points.Count());
        }

        [TestMethod]
        public void Line_GetIntersectionReturnsNullForTwoParallelHorizontalLines()
        {
            Line line1 = new Line(new PointD(5, 3), new PointD(9, 3));
            Line line2 = new Line(new PointD(5, 4), new PointD(9, 4));
            IEnumerable<PointD> points = line2.GetIntersections(line1);
            Assert.AreEqual(0, points.Count());
        }

        [TestMethod]
        public void Line_GetIntersectionReturnsNullForTwoParallelVerticalLines()
        {
            Line line1 = new Line(new PointD(3, 5), new PointD(3, 9));
            Line line2 = new Line(new PointD(4, 9), new PointD(4, 5));
            IEnumerable<PointD> points = line2.GetIntersections(line1);
            Assert.AreEqual(0, points.Count());
        }

        [TestMethod]
        public void Line_GetIntersectionReturnsNullForLeftToRightHorizontalLineThatIsIntersectedByVerticalLineInInStartingPoint()
        {
            Line line1 = new Line(new PointD(5, 3), new PointD(9, 3));
            Line line2 = new Line(new PointD(5, 3), new PointD(5, 7));
            IEnumerable<PointD> points = line2.GetIntersections(line1);
            Assert.AreEqual(0, points.Count());
        }

        [TestMethod]
        public void Line_GetIntersectionReturnsEndingPointForLeftToRightHorizontalLineThatIsIntersectedByVerticalLineInInEndingPoint()
        {
            Line line1 = new Line(new PointD(5, 3), new PointD(9, 3));
            Line line2 = new Line(new PointD(9, 7), new PointD(9, 3));
            IEnumerable<PointD> points = line2.GetIntersections(line1);
            Assert.AreEqual(1, points.Count());
            PointD point = points.First();
            Assert.AreEqual(9, point.X, 1e-5);
            Assert.AreEqual(3, point.Y, 1e-5);
        }

        [TestMethod]
        public void Line_GetIntersectionReturnsNullForRightToLeftHorizontalLineThatIsIntersectedByVerticalLineInInStartingPoint()
        {
            Line line1 = new Line(new PointD(9, 3), new PointD(5, 3));
            Line line2 = new Line(new PointD(9, 3), new PointD(9, 7));
            IEnumerable<PointD> points = line2.GetIntersections(line1);
            Assert.AreEqual(0, points.Count());
        }

        [TestMethod]
        public void Line_GetIntersectionReturnsEndingPointForRightToLeftHorizontalLineThatIsIntersectedByVerticalLineInInEndingPoint()
        {
            Line line1 = new Line(new PointD(9, 3), new PointD(5, 3));
            Line line2 = new Line(new PointD(5, 7), new PointD(5, 0));
            IEnumerable<PointD> points = line2.GetIntersections(line1);
            Assert.AreEqual(1, points.Count());
            PointD point = points.First();
            Assert.AreEqual(5, point.X, 1e-5);
            Assert.AreEqual(3, point.Y, 1e-5);
        }
        
        [TestMethod]
        public void Line_GetIntersectionReturnsNullForUpwardHorizontalLineThatIsIntersectedByHorizontalLineInInStartingPoint()
        {
            Line line1 = new Line(new PointD(3, 5), new PointD(3, 9));
            Line line2 = new Line(new PointD(2, 5), new PointD(7, 5));
            IEnumerable<PointD> points = line2.GetIntersections(line1);
            Assert.AreEqual(0, points.Count());
        }

        [TestMethod]
        public void Line_GetIntersectionReturnsEndingPointForUpwardVerticalLineThatIsIntersectedByHorizontalLineInInEndingPoint()
        {
            Line vertical = new Line(new PointD(3, 5), new PointD(3, 9));
            Line horizontal = new Line(new PointD(3, 9), new PointD(4, 9));
            IEnumerable<PointD> points = horizontal.GetIntersections(vertical);
            Assert.AreEqual(1, points.Count());
            PointD point = points.First();
            Assert.AreEqual(3, point.X, 1e-5);
            Assert.AreEqual(9, point.Y, 1e-5);
        }

        [TestMethod]
        public void Line_GetIntersectionReturnsNullForDownwardVerticalLineThatIsIntersectedByHorizontalLineInInStartingPoint()
        {
            Line vertical = new Line(new PointD(3, 9), new PointD(3, 5));
            Line horizontal = new Line(new PointD(2, 9), new PointD(5, 9));
            IEnumerable<PointD> points = horizontal.GetIntersections(vertical);
            Assert.AreEqual(0, points.Count());
            points = horizontal.GetIntersections(vertical);
            Assert.AreEqual(0, points.Count());
        }

        [TestMethod]
        public void Line_GetIntersectionReturnsEndingPointForDownwardVerticalLineThatIsIntersectedByHorizontalLineInInEndingPoint()
        {
            Line vertical = new Line(new PointD(3, 9), new PointD(3, 5));
            Line horizontal = new Line(new PointD(3, 5), new PointD(5, 5));
            IEnumerable<PointD> points = horizontal.GetIntersections(vertical);
            Assert.AreEqual(1, points.Count());
            PointD point = points.First();
            Assert.AreEqual(3, point.X, 1e-5);
            Assert.AreEqual(5, point.Y, 1e-5);
        }
        
        [TestMethod]
        public void Line_GetIntersectionReturnsIntersectionPointForTwoInclinedLineSections()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(4, 4));
            Line line2 = new Line(new PointD(0, 4), new PointD(4, 0));
            IEnumerable<PointD> points = line1.GetIntersections(line2);
            Assert.AreEqual(1, points.Count());
            PointD point = points.First();
            Assert.AreEqual(2, point.X, 1e-5);
            Assert.AreEqual(2, point.Y, 1e-5);
        }
        
        [TestMethod]
        public void Line_GetIntersectionReturnsIntersectionPointForTwoInclinedLineSectionsFirstGivenInOpositeOrder()
        {
            Line line1 = new Line(new PointD(4, 4), new PointD(0, 0));
            Line line2 = new Line(new PointD(0, 4), new PointD(4, 0));
            IEnumerable<PointD> points = line1.GetIntersections(line2);
            Assert.AreEqual(1, points.Count());
            PointD point = points.First();
            Assert.AreEqual(2, point.X, 1e-5);
            Assert.AreEqual(2, point.Y, 1e-5);
        }
        
        [TestMethod]
        public void Line_GetIntersectionReturnsIntersectionPointForTwoInclinedLineSectionsSecondGivenInOpositeOrder()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(4, 4));
            Line line2 = new Line(new PointD(4, 0), new PointD(0, 4));
            IEnumerable<PointD> points = line1.GetIntersections(line2);
            Assert.AreEqual(1, points.Count());
            PointD point = points.First();
            Assert.AreEqual(2, point.X, 1e-5);
            Assert.AreEqual(2, point.Y, 1e-5);
        }

        [TestMethod]
        public void Line_GetIntersectionReturnsIntersectionPointForTwoInclinedLineSectionsBothGivenInOpositeOrder()
        {
            Line line1 = new Line(new PointD(4, 4), new PointD(0, 0));
            Line line2 = new Line(new PointD(4, 0), new PointD(0, 4));
            IEnumerable<PointD> points = line1.GetIntersections(line2);
            Assert.AreEqual(1, points.Count());
            PointD point = points.First();
            Assert.AreEqual(2, point.X, 1e-5);
            Assert.AreEqual(2, point.Y, 1e-5);
        }

        [TestMethod]
        public void Line_GetIntersectionReturnsIntersectionPointOnCollisionPlaneForLineEndingOnIt()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(200, 200));
            Line line2 = new Line(new PointD(200, 0), new PointD(200, 400));
            IEnumerable<PointD> points = line1.GetIntersections(line2);
            Assert.AreEqual(1, points.Count());
            PointD point = points.First();
            Assert.AreEqual(200, point.X, 1e-5);
            Assert.AreEqual(200, point.Y, 1e-5);
        }

        [TestMethod]
        public void Line_GetIntersectionReturnsNullForTwoLineSectionsThatHaveNoIntersection()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(4, 4));
            Line line2 = new Line(new PointD(0, 5), new PointD(10, 5));
            Assert.AreEqual(0, line1.GetIntersections(line2).Count());
        }
    }
}
