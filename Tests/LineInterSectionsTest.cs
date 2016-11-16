using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Pood.BouncingBall;
using System.Collections.Generic;
using System.Linq;

namespace Vsite.Pood.BouncingBallTests
{
    [TestClass]
    public class LineInterSectionsTest
    {
        [TestMethod]
        public void LineIntersections_GetIntersectionForTwoOrtogonalLines()
        {
            Line horizontal = new Line(new PointD(5, 3), new PointD(9, 3));
            LineIntersections li = new LineIntersections(horizontal);
            Line vertical = new Line(new PointD(6, 2), new PointD(6, 7));
            PointD p = li.GetIntersection(vertical);
            Assert.AreEqual(6, p.X, 1e-5);
            Assert.AreEqual(3, p.Y, 1e-5);
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionForTwoNonIntersectingLines()
        {
            Line horizontal = new Line(new PointD(5, 3), new PointD(5, 7));
            LineIntersections li = new LineIntersections(horizontal);
            Line vertical = new Line(new PointD(6, 4), new PointD(6, 7));
            Assert.IsNull(li.GetIntersection(vertical));
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionForTwoParallelHorizontalLines()
        {
            Line horizontal1 = new Line(new PointD(5, 3), new PointD(9, 3));
            LineIntersections li = new LineIntersections(horizontal1);
            Line horizontal2 = new Line(new PointD(5, 4), new PointD(9, 4));
            Assert.IsNull(li.GetIntersection(horizontal2));
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionForTwoTouchingOrtogonalLines()
        {
            Line horizontal = new Line(new PointD(5, 3), new PointD(9, 3));
            LineIntersections li = new LineIntersections(horizontal);
            Line vertical = new Line(new PointD(9, 3), new PointD(9, 7));
            PointD p = li.GetIntersection(vertical);
            Assert.AreEqual(9, p.X, 1e-5);
            Assert.AreEqual(3, p.Y, 1e-5);
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionForTwoInclinedLines()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(4, 4));
            LineIntersections li = new LineIntersections(line1);
            Line line2 = new Line(new PointD(0, 4), new PointD(4, 0));
            PointD p = li.GetIntersection(line2);
            Assert.AreEqual(2, p.X, 1e-5);
            Assert.AreEqual(2, p.Y, 1e-5);
        }

        [TestMethod]
        public void LineIntersections_GetColisionPointsReturnsEmptyCollectionForNoCollisionPlane()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(4, 4));
            LineIntersections li = new LineIntersections(line1);
            List<ColisionPlane> colisionPlanes = new List<ColisionPlane>();
            Assert.AreEqual(0, li.GetColisionPoints(colisionPlanes).Count());
        }

        [TestMethod]
        public void LineIntersections_GetColisionPointsReturnsOneColisionPointForProperCollisionPlane()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(4, 4));
            LineIntersections li = new LineIntersections(line1);
            ColisionPlane plane1 = new ColisionPlane(new PointD(3, 0), new PointD(3, 4));
            List<ColisionPlane> colisionPlanes = new List<ColisionPlane>{ plane1 };
            var colisionPoints = li.GetColisionPoints(colisionPlanes);
            Assert.AreEqual(1, colisionPoints.Count());
            Assert.AreEqual(3, colisionPoints.First().Point.X, 1e-5);
            Assert.AreEqual(3, colisionPoints.First().Point.Y, 1e-5);
        }

        [TestMethod]
        public void LineIntersections_GetColisionPointsReturnsTwoColisionPointsForTwoPlanesColliding()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(4, 4));
            LineIntersections li = new LineIntersections(line1);
            ColisionPlane plane1 = new ColisionPlane(new PointD(3, 0), new PointD(3, 4));
            ColisionPlane plane2 = new ColisionPlane(new PointD(0, 2), new PointD(4, 2));
            List<ColisionPlane> colisionPlanes = new List<ColisionPlane> { plane1, plane2 };
            var colisionPoints = li.GetColisionPoints(colisionPlanes);
            Assert.AreEqual(2, colisionPoints.Count());
        }

        [TestMethod]
        public void LineIntersections_GetColisionPointsReturnsEmptyListWhenThereIsNoCollidingPlane()
        {
            Line line1 = new Line(new PointD(0, 3), new PointD(4, 7));
            LineIntersections li = new LineIntersections(line1);
            ColisionPlane plane1 = new ColisionPlane(new PointD(3, 0), new PointD(3, 4));
            ColisionPlane plane2 = new ColisionPlane(new PointD(0, 2), new PointD(4, 2));
            List<ColisionPlane> colisionPlanes = new List<ColisionPlane> { plane1, plane2 };
            var colisionPoints = li.GetColisionPoints(colisionPlanes);
            Assert.AreEqual(0, colisionPoints.Count());
        }

        [TestMethod]
        public void LineIntersections_GetClosestColisionPointsReturnsOneColisionPointsForTwoPlanesColliding()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(4, 4));
            LineIntersections li = new LineIntersections(line1);
            ColisionPlane plane1 = new ColisionPlane(new PointD(3, 0), new PointD(3, 4));
            ColisionPlane plane2 = new ColisionPlane(new PointD(0, 2), new PointD(4, 2));
            List<ColisionPlane> colisionPlanes = new List<ColisionPlane> { plane1, plane2 };
            var colisionPoints = li.GetClosestColisionPoints(colisionPlanes);
            Assert.AreEqual(1, colisionPoints.Count());
            Assert.AreEqual(plane2, colisionPoints.First().Plane);
            Assert.AreEqual(2, colisionPoints.First().Point.X);
            Assert.AreEqual(2, colisionPoints.First().Point.Y);
        }

    }
}
