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
        public void LineIntersections_GetIntersectionReturnsIntersectionPointForTwoOrtogonalLineSections()
        {
            Line horizontal = new Line(new PointD(5, 3), new PointD(9, 3));
            LineIntersections li = new LineIntersections(horizontal);
            CollisionPlane cp = new CollisionPlane(new PointD(6, 2), new PointD(6, 7));
            IEnumerable<PointD> points = cp.GetIntersections(li.line0);
            Assert.AreEqual(1, points.Count());
            PointD point = points.First();
            Assert.AreEqual(6, point.X, 1e-5);
            Assert.AreEqual(3, point.Y, 1e-5);
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsNullForTwoInclinedLineSections()
        {
            Line horizontal = new Line(new PointD(5, 3), new PointD(5, 7));
            LineIntersections li = new LineIntersections(horizontal);
            Line vertical = new Line(new PointD(6, 4), new PointD(6, 7));
            Assert.IsNull(li.GetIntersections(vertical));
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsNullForTwoParallelHorizontalLines()
        {
            Line horizontal1 = new Line(new PointD(5, 3), new PointD(9, 3));
            LineIntersections li = new LineIntersections(horizontal1);
            Line horizontal2 = new Line(new PointD(5, 4), new PointD(9, 4));
            CollisionPlane cp = new CollisionPlane(new PointD(6, 2), new PointD(6, 7));
            IEnumerable<PointD> points = cp.GetIntersections(li.line0);
            Assert.AreEqual(1, points.Count());
            PointD point = points.First();
            Assert.IsNull(li.GetIntersection(horizontal2));
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsNullForTwoParallelVerticalLines()
        {
            Line horizontal1 = new Line(new PointD(3, 5), new PointD(3, 9));
            LineIntersections li = new LineIntersections(horizontal1);
            Line horizontal2 = new Line(new PointD(4, 9), new PointD(4, 5));
            Assert.IsNull(li.GetIntersection(horizontal2));
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsNullForLeftToRightHorizontalLineThatIsIntersectedByVerticalLineInInStartingPoint()
        {
            Line horizontal = new Line(new PointD(5, 3), new PointD(9, 3));
            LineIntersections li = new LineIntersections(horizontal);
            Line vertical = new Line(new PointD(5, 3), new PointD(5, 7));
            Assert.IsNull(li.GetIntersection(vertical));
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsEndingPointForLeftToRightHorizontalLineThatIsIntersectedByVerticalLineInInEndingPoint()
        {
            Line horizontal = new Line(new PointD(5, 3), new PointD(9, 3));
            LineIntersections li = new LineIntersections(horizontal);
            Line vertical = new Line(new PointD(9, 7), new PointD(9, 3));
            PointD p = li.GetIntersection(vertical);
            Assert.AreEqual(9, p.X, 1e-5);
            Assert.AreEqual(3, p.Y, 1e-5);
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsNullForRightToLeftHorizontalLineThatIsIntersectedByVerticalLineInInStartingPoint()
        {
            Line horizontal = new Line(new PointD(9, 3), new PointD(5, 3));
            LineIntersections li = new LineIntersections(horizontal);
            Line vertical = new Line(new PointD(9, 3), new PointD(9, 7));
            Assert.IsNull(li.GetIntersection(vertical));
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsEndingPointForRightToLeftHorizontalLineThatIsIntersectedByVerticalLineInInEndingPoint()
        {
            Line horizontal = new Line(new PointD(9, 3), new PointD(5, 3));
            LineIntersections li = new LineIntersections(horizontal);
            Line vertical = new Line(new PointD(5, 7), new PointD(5, 0));
            PointD p = li.GetIntersection(vertical);
            Assert.AreEqual(5, p.X, 1e-5);
            Assert.AreEqual(3, p.Y, 1e-5);
        }


        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsNullForUpwardHorizontalLineThatIsIntersectedByHorizontalLineInInStartingPoint()
        {
            Line vertical = new Line(new PointD(3, 5), new PointD(3, 9));
            LineIntersections li = new LineIntersections(vertical);
            Line horizontal = new Line(new PointD(2, 5), new PointD(7, 5));
            Assert.IsNull(li.GetIntersection(horizontal));
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsEndingPointForUpwardVerticalLineThatIsIntersectedByHorizontalLineInInEndingPoint()
        {
            Line vertical = new Line(new PointD(3, 5), new PointD(3, 9));
            LineIntersections li = new LineIntersections(vertical);
            Line horizontal = new Line(new PointD(3, 9), new PointD(4, 9));
            PointD p = li.GetIntersection(horizontal);
            Assert.AreEqual(3, p.X, 1e-5);
            Assert.AreEqual(9, p.Y, 1e-5);
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsNullForDownwardVerticalLineThatIsIntersectedByHorizontalLineInInStartingPoint()
        {
            Line vertical = new Line(new PointD(3, 9), new PointD(3, 5));
            LineIntersections li = new LineIntersections(vertical);
            Line horizontal = new Line(new PointD(2, 9), new PointD(5, 9));
            Assert.IsNull(li.GetIntersection(horizontal));
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsEndingPointForDownwardVerticalLineThatIsIntersectedByHorizontalLineInInEndingPoint()
        {
            Line vertical = new Line(new PointD(3, 9), new PointD(3, 5));
            LineIntersections li = new LineIntersections(vertical);
            Line horizontal = new Line(new PointD(3, 5), new PointD(5, 5));
            PointD p = li.GetIntersection(horizontal);
            Assert.AreEqual(3, p.X, 1e-5);
            Assert.AreEqual(5, p.Y, 1e-5);
        }


        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsIntersectionPointForTwoInclinedLineSections()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(4, 4));
            LineIntersections li = new LineIntersections(line1);
            Line line2 = new Line(new PointD(0, 4), new PointD(4, 0));
            PointD p = li.GetIntersection(line2);
            Assert.AreEqual(2, p.X, 1e-5);
            Assert.AreEqual(2, p.Y, 1e-5);
        }


        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsIntersectionPointForTwoInclinedLineSectionsFirstGivenInOpositeOrder()
        {
            Line line1 = new Line(new PointD(4, 4), new PointD(0, 0));
            LineIntersections li = new LineIntersections(line1);
            Line line2 = new Line(new PointD(0, 4), new PointD(4, 0));
            PointD p = li.GetIntersection(line2);
            Assert.AreEqual(2, p.X, 1e-5);
            Assert.AreEqual(2, p.Y, 1e-5);
        }


        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsIntersectionPointForTwoInclinedLineSectionsSecondGivenInOpositeOrder()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(4, 4));
            LineIntersections li = new LineIntersections(line1);
            Line line2 = new Line(new PointD(4, 0), new PointD(0, 4));
            PointD p = li.GetIntersection(line2);
            Assert.AreEqual(2, p.X, 1e-5);
            Assert.AreEqual(2, p.Y, 1e-5);
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsIntersectionPointForTwoInclinedLineSectionsBothGivenInOpositeOrder()
        {
            Line line1 = new Line(new PointD(4, 4), new PointD(0, 0));
            LineIntersections li = new LineIntersections(line1);
            Line line2 = new Line(new PointD(4, 0), new PointD(0, 4));
            PointD p = li.GetIntersection(line2);
            Assert.AreEqual(2, p.X, 1e-5);
            Assert.AreEqual(2, p.Y, 1e-5);
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsIntersectionPointOnCollisionPlaneForLineEndingOnIt()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(200, 200));
            LineIntersections li = new LineIntersections(line1);
            Line line2 = new Line(new PointD(200, 0), new PointD(200, 400));
            PointD p = li.GetIntersection(line2);
            Assert.AreEqual(200, p.X, 1e-5);
            Assert.AreEqual(200, p.Y, 1e-5);
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsNullForTwoLineSectionsThatHaveNoIntersection()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(4, 4));
            LineIntersections li = new LineIntersections(line1);
            Line line2 = new Line(new PointD(0, 5), new PointD(10, 5));
            Assert.IsNull(li.GetIntersection(line2));
        }

        [TestMethod]
        public void LineIntersection_GetCollisionPointsReturnsEmptyCollectionForNoCollisionPlanes()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(4, 4));
            LineIntersections li = new LineIntersections(line1);
            List<CollisionPlane> collisionPlanes = new List<CollisionPlane>();
            Assert.AreEqual(0, li.GetCollisionPoints(collisionPlanes).Count());
        }

        [TestMethod]
        public void LineIntersection_GetCollisionPointsReturnsOneCollisionPointForProperCollisionPlane()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(4, 4));
            LineIntersections li = new LineIntersections(line1);
            CollisionPlane plane1 = new CollisionPlane(new PointD(3, 0), new PointD(3, 4));
            List <CollisionPlane> collisionPlanes = new List<CollisionPlane>{ plane1 };
            var collisionPoints = li.GetCollisionPoints(collisionPlanes);
            Assert.AreEqual(1, collisionPoints.Count());
            Assert.AreEqual(3, collisionPoints.First().Point.X, 1e-5);
            Assert.AreEqual(3, collisionPoints.First().Point.Y, 1e-5);
        }

        [TestMethod]
        public void LineIntersection_GetCollisionPointsReturnsTwoCollisionPointsForTwoPlaneColliding()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(4, 4));
            LineIntersections li = new LineIntersections(line1);
            CollisionPlane plane1 = new CollisionPlane(new PointD(3, 0), new PointD(3, 4));
            CollisionPlane plane2 = new CollisionPlane(new PointD(0, 2), new PointD(4, 2));
            List<CollisionPlane> collisionPlanes = new List<CollisionPlane> { plane1, plane2 };
            var collisionPoints = li.GetCollisionPoints(collisionPlanes);
            Assert.AreEqual(2, collisionPoints.Count());
        }

        [TestMethod]
        public void LineIntersection_GetCollisionPointsReturnsEmptyListWhenThereIsNoCollidingPlane()
        {
            Line line1 = new Line(new PointD(0, 3), new PointD(4, 7));
            LineIntersections li = new LineIntersections(line1);
            CollisionPlane plane1 = new CollisionPlane(new PointD(3, 0), new PointD(3, 4));
            CollisionPlane plane2 = new CollisionPlane(new PointD(0, 2), new PointD(4, 2));
            List<CollisionPlane> collisionPlanes = new List<CollisionPlane> { plane1, plane2 };
            var collisionPoints = li.GetCollisionPoints(collisionPlanes);
            Assert.AreEqual(0, collisionPoints.Count());
        }

        [TestMethod]
        public void LineIntersections_GetCollisionPointsReturnsIntersectionPointOnCollisionPlaneForLineEndingOnIt()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(200, 200));
            LineIntersections li = new LineIntersections(line1);
            CollisionPlane plane1 = new CollisionPlane(new PointD(200, 0), new PointD(200, 400));
            var collisionPoints = li.GetCollisionPoints(new List<CollisionPlane> { plane1 } );
            Assert.AreEqual(1, collisionPoints.Count());
            Assert.AreEqual(200, collisionPoints.First().Point.X, 1e-5);
            Assert.AreEqual(200, collisionPoints.First().Point.Y, 1e-5);
        }

        [TestMethod]
        public void LineIntersection_GetClosestCollisionPointsReturnsEmptyListWhenThereIsNoCollidingPlane()
        {
            Line line1 = new Line(new PointD(0, 3), new PointD(4, 7));
            LineIntersections li = new LineIntersections(line1);
            CollisionPlane plane1 = new CollisionPlane(new PointD(3, 0), new PointD(3, 4));
            CollisionPlane plane2 = new CollisionPlane(new PointD(0, 2), new PointD(4, 2));
            List<CollisionPlane> collisionPlanes = new List<CollisionPlane> { plane1, plane2 };
            var collisionPoints = li.GetClosestCollisionPoints(collisionPlanes);
            Assert.AreEqual(0, collisionPoints.Count());
        }

        [TestMethod]
        public void LineIntersection_GetClosestCollisionPointsReturnsOneCollisionPointsForTwoPlanesWithDifferentPointsOfCollision()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(4, 4));
            LineIntersections li = new LineIntersections(line1);
            CollisionPlane plane1 = new CollisionPlane(new PointD(3, 0), new PointD(3, 4));
            CollisionPlane plane2 = new CollisionPlane(new PointD(0, 2), new PointD(4, 2));
            List<CollisionPlane> collisionPlanes = new List<CollisionPlane> { plane1, plane2 };
            var collisionPoints = li.GetClosestCollisionPoints(collisionPlanes);
            Assert.AreEqual(1, collisionPoints.Count());
            Assert.AreEqual(plane2, collisionPoints.First().Plane);
            Assert.AreEqual(2, collisionPoints.First().Point.X);
            Assert.AreEqual(2, collisionPoints.First().Point.Y);
        }

        [TestMethod]
        public void LineIntersection_GetClosestCollisionPointsReturnsTwoCollisionPointsForTwoPlanesIntersectingInThePointOfCollision()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(4, 4));
            LineIntersections li = new LineIntersections(line1);
            CollisionPlane plane1 = new CollisionPlane(new PointD(3, 0), new PointD(3, 4));
            CollisionPlane plane2 = new CollisionPlane(new PointD(0, 3), new PointD(4, 3));
            List<CollisionPlane> collisionPlanes = new List<CollisionPlane> { plane1, plane2 };
            var collisionPoints = li.GetClosestCollisionPoints(collisionPlanes);
            Assert.AreEqual(2, collisionPoints.Count());
            Assert.IsNotNull(collisionPoints.FirstOrDefault(cp => cp.Plane == plane1));
            Assert.IsNotNull(collisionPoints.FirstOrDefault(cp => cp.Plane == plane2));
        }

        [TestMethod]
        public void LineIntersections_GetClosestCollisionPointsReturnsIntersectionPointOnCollisionPlaneForLineEndingOnIt()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(200, 200));
            LineIntersections li = new LineIntersections(line1);
            CollisionPlane plane1 = new CollisionPlane(new PointD(200, 0), new PointD(200, 400));
            var collisionPoints = li.GetClosestCollisionPoints(new List<CollisionPlane> { plane1 });
            Assert.AreEqual(1, collisionPoints.Count());
            Assert.AreEqual(200, collisionPoints.First().Point.X, 1e-5);
            Assert.AreEqual(200, collisionPoints.First().Point.Y, 1e-5);
        }

    }
}
