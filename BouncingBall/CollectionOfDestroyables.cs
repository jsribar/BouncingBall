using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    class CollectionOfDestroyables
    {
        public void Add(IDestroyNotifier item)
        {
            items.Add(item);
            item.Destroy += ItemDestroy;
        }

        public int Count
        {
            get { return items.Count; }
        }

        public event EventHandler ItemDestroyed;

        private void ItemDestroy(object sender, EventArgs e)
        {
            IDestroyNotifier item = (IDestroyNotifier)sender;
            item.Destroy -= ItemDestroy;
            items.Remove(item);
            ItemDestroyed?.Invoke(this, EventArgs.Empty);
        }

        public IEnumerable<ICollisionObject> Items
        {
            get { return (IEnumerable<ICollisionObject>)items; }
        }

        private List<IDestroyNotifier> items = new List<IDestroyNotifier>();
    }
}
