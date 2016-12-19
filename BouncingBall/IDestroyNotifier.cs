using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    interface IDestroyNotifier : ICollisionObject
    {
        event EventHandler Destroy;
    }
}
