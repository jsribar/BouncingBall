using System;

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
            double lenght = speed * seconds;
            double deltaX = lenght * Math.Cos(angle);
            double deltaY = lenght * Math.Sin(angle);
            return new PointD(starting.X + deltaX, starting.Y + deltaY);
        }

        private double speed;
        private double angle;
    }
}
