using System;
using System.Collections.Generic;

namespace Vsite.Pood.BouncingBall
{
    class CollectionOfDestroyables
    {
        public class DestroyedItemEventArgs : EventArgs
        {
            public DestroyedItemEventArgs(IDestroyNotifier destroyedItem)
            {
                DestroyedItem = destroyedItem;
            }

            public readonly IDestroyNotifier DestroyedItem;
        }

        public void Add(IDestroyNotifier item)
        {
            items.Add(item);
            item.Destroy += ItemDestroy;
        }

        public int Count
        {
            get { return items.Count; }
        }

        public void Clear()
        {
            items.Clear();
        }

        public event EventHandler<DestroyedItemEventArgs> ItemDestroyed;

        private void ItemDestroy(object sender, EventArgs e)
        {
            IDestroyNotifier item = (IDestroyNotifier)sender;
            item.Destroy -= ItemDestroy;
            items.Remove(item);
            ItemDestroyed?.Invoke(this, new DestroyedItemEventArgs(item));
        }

        public IEnumerable<ICollisionObject> Items
        {
            get { return (IEnumerable<ICollisionObject>)items; }
        }

        private List<IDestroyNotifier> items = new List<IDestroyNotifier>();
    }
}
