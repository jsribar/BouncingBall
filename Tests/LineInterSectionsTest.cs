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
            Line vertical = new Line(new PointD(6, 2), new PointD(6, 7));
            PointD p = li.GetIntersection(vertical);
            Assert.AreEqual(6, p.X, 1e-5);
            Assert.AreEqual(3, p.Y, 1e-5);
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsNullForTwoInclinedLineSections()
        {
            Line horizontal = new Line(new PointD(5, 3), new PointD(5, 7));
            LineIntersections li = new LineIntersections(horizontal);
            Line vertical = new Line(new PointD(6, 4), new PointD(6, 7));
            Assert.IsNull(li.GetIntersection(vertical));
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsNullForTwoParallelHorizontalLines()
        {
            Line horizontal1 = new Line(new PointD(5, 3), new PointD(9, 3));
            LineIntersections li = new LineIntersections(horizontal1);
            Line horizontal2 = new Line(new PointD(5, 4), new PointD(9, 4));
            Assert.IsNull(li.GetIntersection(horizontal2));
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsCommonPointForTwoLineSectionsThatStartInThatPoint()
        {
            Line horizontal = new Line(new PointD(9, 3), new PointD(5, 3));
            LineIntersections li = new LineIntersections(horizontal);
            Line vertical = new Line(new PointD(9, 3), new PointD(9, 7));
            PointD p = li.GetIntersection(vertical);
            Assert.AreEqual(9, p.X, 1e-5);
            Assert.AreEqual(3, p.Y, 1e-5);
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionReturnsCommonPointForTwoLineSectionsThatEndInThatPoint()
        {
            Line horizontal = new Line(new PointD(5, 3), new PointD(9, 3));
            LineIntersections li = new LineIntersections(horizontal);
            Line vertical = new Line(new PointD(9, 7), new PointD(9, 3));
            PointD p = li.GetIntersection(vertical);
            Assert.AreEqual(9, p.X, 1e-5);
            Assert.AreEqual(3, p.Y, 1e-5);
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

    }
}
