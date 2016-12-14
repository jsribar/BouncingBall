namespace Vsite.Pood.BouncingBall
{
    class CollisionPoint
    {
        public CollisionPoint(ICollisionObject collisionObject, PointD point)
        {
            CollisionObject = collisionObject;
            Point = point;
        }

        public Velocity ChangeVelocity(Velocity vel)
        {
            return CollisionObject.ChangeVelocity(vel, this);
        }

        public readonly ICollisionObject CollisionObject;
        public readonly PointD Point;
    }
}
