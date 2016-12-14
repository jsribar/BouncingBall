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
            List<CollisionPlane> collisionPlanes = new List<CollisionPlane> { plane1 };
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
            var collisionPoints = li.GetCollisionPoints(new List<CollisionPlane> { plane1 });
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
            Assert.AreEqual(plane2, collisionPoints.First().CollisionObject);
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
            Assert.IsNotNull(collisionPoints.FirstOrDefault(cp => cp.CollisionObject == plane1));
            Assert.IsNotNull(collisionPoints.FirstOrDefault(cp => cp.CollisionObject == plane2));
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
