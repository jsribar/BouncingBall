namespace Vsite.Pood.BouncingBall
{
    class CollisionPoint
    {
        public CollisionPoint(IHittable hittableObject, PointD point)
        {
            HittableObject = hittableObject;
            Point = point;
        }

        public Velocity DoHit(Velocity vel)
        {
            return HittableObject.DoHit(vel, this);
        }

        public readonly IHittable HittableObject;
        public readonly PointD Point;
    }
}
