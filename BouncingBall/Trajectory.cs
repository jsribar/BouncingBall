﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public PointD GetNewPosition(DateTime endTime, IEnumerable<CollisionPlane> collisionPlanes)
        {
            while (true)
            {
                PointD newPosition = GetNewPosition(endTime);
                LineIntersections li = new LineIntersections(new Line(startingPoint, newPosition));
                IEnumerable<CollisionPoint> collisionPoints = li.GetClosestCollisionPoints(collisionPlanes);
                if (collisionPoints.Count() == 0)
                    return newPosition;
                double distance = startingPoint.Distance(collisionPoints.First().Point);
                double time = velocity.TimeInSeconds(distance);
                startingPoint = collisionPoints.First().Point;
                startingTime = startingTime.AddSeconds(time);
                foreach (CollisionPoint cp in collisionPoints)
                    velocity.ChangeAngle(cp.Plane.Angle);
            }
        }

        private Velocity velocity;
        private PointD startingPoint;
        private DateTime startingTime;
    }
}
