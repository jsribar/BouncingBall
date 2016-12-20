using System.Collections.Generic;

namespace Vsite.Pood.BouncingBall
{
    interface ICollisionObject
    {
        IEnumerable<CollisionPoint> GetCollisionPoints(Line line);

    }
}
