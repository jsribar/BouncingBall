using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Pood.BouncingBall;

namespace Tests
{
	[TestClass]
	public class VelocityTest
	{
		[TestMethod]
		public void Velocity_GetNewPositionReturnsNewPointForVerticalMovement()
		{
			Velocity v = new Velocity(1, Math.PI / 2);
            PointD p1 = new Vsite.Pood.BouncingBall.PointD(1, 0);
            PointD p2 = v.GetNewPosition(p1, 5);
            Assert.AreEqual(1, p2.X, 1e-5);
            Assert.AreEqual(5, p2.Y, 1e-5);
        }

        [TestMethod]
        public void Velocity_GetNewPositionReturnsNewPointForVerticalMovementDown()
        {
            Velocity v = new Velocity(1, -Math.PI / 2);
            PointD p1 = new Vsite.Pood.BouncingBall.PointD(3, 8);
            PointD p2 = v.GetNewPosition(p1, 5);
            Assert.AreEqual(3, p2.X, 1e-5);
            Assert.AreEqual(3, p2.Y, 1e-5);
        }

        [TestMethod]
        public void Velocity_GetNewPositionReturnsNewPointForHorizontalMovement()
        {
            Velocity v = new Velocity(2, 0);
            PointD p1 = new Vsite.Pood.BouncingBall.PointD(1, 1);
            PointD p2 = v.GetNewPosition(p1, 2);
            Assert.AreEqual(5, p2.X, 1e-5);
            Assert.AreEqual(1, p2.Y, 1e-5);
        }

        [TestMethod]
        public void Velocity_GetNewPositionReturnsNewPointForHorizontalMovementLeft()
        {
            Velocity v = new Velocity(2, Math.PI);
            PointD p1 = new Vsite.Pood.BouncingBall.PointD(10, 2);
            PointD p2 = v.GetNewPosition(p1, 4);
            Assert.AreEqual(2, p2.X, 1e-5);
            Assert.AreEqual(2, p2.Y, 1e-5);
        }


        [TestMethod]
        public void Velocity_GetNewPositionReturnsNewPointForInclinedMovementAt45Deg()
        {
            Velocity v = new Velocity(1, Math.PI / 4);
            PointD p1 = new Vsite.Pood.BouncingBall.PointD(0, 0);
            PointD p2 = v.GetNewPosition(p1, 2);
            Assert.AreEqual(Math.Sqrt(2), p2.X, 1e-5);
            Assert.AreEqual(Math.Sqrt(2), p2.Y, 1e-5);
        }

        [TestMethod]
        public void Velocity_GetNewPositionReturnsNewPointForInclinedMovementAtSomeAngle()
        {
            Velocity v = new Velocity(1, Math.Atan(3.0 / 4.0));
            PointD p1 = new Vsite.Pood.BouncingBall.PointD(0, 0);
            PointD p2 = v.GetNewPosition(p1, 5);
            Assert.AreEqual(4, p2.X, 1e-5);
            Assert.AreEqual(3, p2.Y, 1e-5);
        }
    }
}
