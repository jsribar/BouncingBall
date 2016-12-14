using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    interface ICollisionObject
    {
        IEnumerable<PointD> GetIntersections(Line line);
    }
}
