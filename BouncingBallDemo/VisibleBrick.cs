﻿using System.Drawing;
using Vsite.Pood.BouncingBall;

namespace Vsite.Pood.BouncingBallDemo
{
    class VisibleDestroyableBrick : DestroyableBrick
    {
        public VisibleDestroyableBrick(PointD leftTop, PointD rightBottom, double ballRadius) 
            : base(leftTop, rightBottom, ballRadius)
        {
        }

        public void Draw(Graphics g)
        {
            double width = RightBottom.X - LeftTop.X;
            double height = RightBottom.Y - LeftTop.Y;
            RectangleF rec = new RectangleF((float)LeftTop.X, (float)LeftTop.Y, (float)width, (float)height);
            g.FillRectangle(Brushes.Maroon, rec);
        }
    }
}
