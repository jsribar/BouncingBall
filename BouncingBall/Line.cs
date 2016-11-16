using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    class Line
    {
        //linia je opisana koeficijentima a b c
        //zanimaju nas koef smjera za duljinu zadanu sa 2 točke početnom ik rajnjomm
        public Line(PointD p1, PointD p2)
        {
            P1 = p1;
            P2 = p2; 

            A = p2.Y - p1.Y;
            B = p1.X - p2.X;
            C = -A * p1.X - B * p1.Y;

            //zanimaju nas presjeci između 2 linija pa ću definirati,

        }

        public readonly double A;
        public readonly double B;
        public readonly double C;
        public readonly PointD P1;
        public readonly PointD P2;
    }
}
