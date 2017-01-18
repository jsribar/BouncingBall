using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    interface IMovable
    {
        //event EventHandler Move;
        void DoMove(PointD leftTop, PointD rightBottom);
    }
}
