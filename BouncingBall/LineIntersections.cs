using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    class LineIntersections
    {
        //predstavlja glavnu liniju koja opisuje početnu i traži prejeke sa linijama koje su sa strane zadane

        public LineIntersections(Line main)
        {
            this.main = main;
        }
        //želim naći presjecište sa nekom drugom linijom
        public PointD GetIntersection(Line l)
        {
            double det = main.A * l.B - l.A * main.B;
            if (det == 0)
                return null;
            double x = (l.B * main.C - main.B * l.C) / det;
            double y = (main.A * l.C - l.A * main.C) / det;
            return new PointD(x, y);
        }



        private Line main;
    }
}
