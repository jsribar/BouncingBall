using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    interface IHittable
    {
        event EventHandler Hit;

        Velocity DoHit(Velocity velocity, CollisionPoint collisionPoint);
    }
}
