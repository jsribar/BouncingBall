using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    class PointD // pointD kao point sa double tipom podataka poćšto već postoji sa floatom
    {
        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X;
        public double Y;
    }
}
