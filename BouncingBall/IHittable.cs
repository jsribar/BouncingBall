using System;

namespace Vsite.Pood.BouncingBall
{
    interface IHittable
    {
        event EventHandler Hit;

        Velocity DoHit(Velocity velocity, CollisionPoint collisionPoint);
    }
}
