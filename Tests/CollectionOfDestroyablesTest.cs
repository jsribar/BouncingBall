using System;
using Vsite.Pood.BouncingBall;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vsite.Pood.BouncingBallTests
{
    class Destroyable : IDestroyNotifier
    {
        public event EventHandler Destroy;

        public void Hit()
        {
            Destroy?.Invoke(this, EventArgs.Empty);
        }
    }

    [TestClass]
    public class CollectionOfDestroyablesTest
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
