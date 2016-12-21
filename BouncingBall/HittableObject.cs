using System;

namespace Vsite.Pood.BouncingBall
{
    abstract class HittableObject : IHittable
    {
        public event EventHandler Hit;

        protected virtual void OnHit()
        {
            Hit?.Invoke(this, EventArgs.Empty);
        }

        public Velocity DoHit(Velocity velocity, CollisionPoint collisionPoint)
        {
            OnHit();
            return ChangeVelocity(velocity, collisionPoint);
        }

        protected abstract Velocity ChangeVelocity(Velocity velocity, CollisionPoint collisionPoint);
    }
}
