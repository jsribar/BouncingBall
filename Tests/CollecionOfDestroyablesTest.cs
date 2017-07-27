﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Pood.BouncingBall;

namespace Vsite.Pood.BouncingBallTests
{
    class Destroyable : IDestroyNotifier
    {
        public event EventHandler Destroy;

        public IEnumerable<CollisionPoint> GetCollisionPoints(Line line)
        {
            throw new NotImplementedException();
        }

        public void Hit()
        {
            Destroy?.Invoke(this, EventArgs.Empty);
        }

        public Velocity Hit(Velocity vel, CollisionPoint point)
        {
            throw new NotImplementedException();
        }
    }

    [TestClass]
    public class CollecionOfDestroyablesTest
    {
        [TestMethod]
        public void CollectionOfDestroyables_AddIncreasesNumberOfItems()
        {
            CollectionOfDestroyables col = new CollectionOfDestroyables();
            Assert.AreEqual(0, col.Count);
            col.Add(new Destroyable());
            Assert.AreEqual(1, col.Count);
        }

        [TestMethod]
        public void CollectionOfDestroyables_DestroyEventOnItemRemovesItFromCollection()
        {
            CollectionOfDestroyables col = new CollectionOfDestroyables();
            Destroyable d = new Destroyable();
            col.Add(d);
            Assert.AreEqual(1, col.Count);

            d.Hit();
            Assert.AreEqual(0, col.Count);
        }
    }
}
