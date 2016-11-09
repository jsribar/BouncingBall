using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Pood.BouncingBall;

namespace Vsite.Pood.BouncingBallTests
{
    [TestClass]
    public class LineIntersectionsTest
    {
        [TestMethod]   //za nesjekuće linije
        public void LineIntersections_GetIntersectionForTwoOrtogonalLines()
        {
            Line horizontal = new BouncingBall.Line(new PointD(5, 3), new PointD(9, 3));
            LineIntersections li = new LineIntersections(horizontal);
            Line vertical = new BouncingBall.Line(new PointD(6, 2), new PointD(6, 7));
            PointD p = li.GetIntersection(vertical);
            Assert.AreEqual(6, p.X, 1e-5); //presjecište
            Assert.AreEqual(3, p.Y, 1e-5); //presjecište
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionForTwoNonIntersectingLines() //za nesjekuće linije
        {
            Line horizontal = new BouncingBall.Line(new PointD(5, 3), new PointD(9, 3));
            LineIntersections li = new LineIntersections(horizontal);
            Line vertical = new BouncingBall.Line(new PointD(6, 4), new PointD(6, 7));
            Assert.IsNull(li.GetIntersection(vertical));
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionForTwoParallelHorizontalLines() 
        {
            Line horizontal1 = new BouncingBall.Line(new PointD(5, 3), new PointD(9, 3));
            LineIntersections li = new LineIntersections(horizontal1);
            Line horizontal2 = new BouncingBall.Line(new PointD(5, 4), new PointD(9, 4));
            Assert.IsNull(li.GetIntersection(horizontal2));
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionForTwoTouchingHorizontalLines() 
        {
            Line horizontal = new BouncingBall.Line(new PointD(5, 3), new PointD(9, 3));
            LineIntersections li = new LineIntersections(horizontal);
            Line vertical = new BouncingBall.Line(new PointD(9, 3), new PointD(9, 7));
            PointD p = li.GetIntersection(vertical);
            Assert.AreEqual(9, p.X, 1e-5); 
            Assert.AreEqual(3, p.Y, 1e-5); 
        }


        [TestMethod]
        public void LineIntersections_GetIntersectionForTwoInclinedLines()
        {
            Line line1 = new BouncingBall.Line(new PointD(0, 0), new PointD(4, 4));
            LineIntersections li = new LineIntersections(line1);
            Line line2 = new BouncingBall.Line(new PointD(0, 4), new PointD(4, 0));
            PointD p = li.GetIntersection(line2);
            Assert.AreEqual(2, p.X, 1e-5);
            Assert.AreEqual(2, p.Y, 1e-5);
        }



    }
}
