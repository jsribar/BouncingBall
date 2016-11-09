using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Pood.BouncingBall
{
    class Velocity
    {
        public Velocity(double speed, double angle)
        {
            this.speed = speed;
            this.angle = angle;
        }

        public PointD GetNewPosition(PointD starting, double seconds)
        {
            double length = speed * seconds;
            double deltaX = length * Math.Cos(angle);
            double deltaY = length * Math.Sin(angle);
            return new PointD(starting.X + deltaX, starting.Y + deltaY);
        }

        private double speed;
        private double angle;

    }
}
