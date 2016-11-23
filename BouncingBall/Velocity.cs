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

        public void ChangeAngle(double planeAngle)
        {
            if(angle<0)
                angle = -angle - 2* planeAngle;
            else
                angle = -angle + 2* planeAngle;
            while (angle > Math.PI)
                angle -= Math.PI;
            while (angle < -Math.PI)
                angle += Math.PI;

        }

        public double TimeInSeconds(double distance)
        {
            return distance / speed;
        }

        public double Angle
        {
            get { return angle; }
        }

        private double speed;
        private double angle;

    }
}
