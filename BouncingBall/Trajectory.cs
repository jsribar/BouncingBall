using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    class Trajectory
    {
        public Trajectory(Velocity velocity, PointD startingPoint, DateTime startingTime)
        {
            this.velocity = velocity;
            this.startingPoint = startingPoint;
            this.startingTime = startingTime;
        }

        public PointD GetNewPosition(DateTime endTime)
        {
            var seconds = (endTime - startingTime).TotalSeconds;
            return velocity.GetNewPosition(startingPoint, seconds);
        }

        private Velocity velocity;
        private PointD startingPoint;
        private DateTime startingTime;
    }
}
