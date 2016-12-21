using System;

namespace Vsite.Pood.BouncingBall
{
    interface IDestroyNotifier : ICollisionObject
    {
        event EventHandler Destroy;
    }
}
