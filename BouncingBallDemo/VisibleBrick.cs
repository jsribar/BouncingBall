using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vsite.Pood.BouncingBall;

namespace Vsite.Pood.BouncingBallDemo
{
    class VisibleDestroyableBrick : DestroyableBrick
    {
        public VisibleDestroyableBrick(PointD LeftTop, PointD RightBottom, double ballRadius) : base(LeftTop, RightBottom, ballRadius)
        {

        }

        public void Draw(Graphics g)
        {
            double width = RightBottom.X - LeftTop.X;
            double height = LeftTop.Y - RightBottom.Y;
            RectangleF rec = new RectangleF((float)LeftTop.X, (float)LeftTop.Y, (float)width, -(float)height);
            g.FillRectangle(Brushes.IndianRed, rec);
        }
    }
}
