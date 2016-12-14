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

        private void ItemDestroy(object sender, EventArgs e)
        {
            IDestroyNotifier item = (IDestroyNotifier) sender;
            item.Destroy -= ItemDestroy;
            items.Remove(item);
        }

        public int Count
        {
            get { return items.Count; }
            
        }

        public IEnumerable<ICollisionObject> Items
        {
            get { return (IEnumerable < ICollisionObject > )items; }
        }
        private List<IDestroyNotifier> items = new List<IDestroyNotifier>();

    }
}
