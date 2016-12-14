﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    interface ICollisionObject
    {
        IEnumerable<CollisionPoint> GetCollisionPoints(Line line);

        Velocity ChangeVelocity(Velocity vel);
    }
}
