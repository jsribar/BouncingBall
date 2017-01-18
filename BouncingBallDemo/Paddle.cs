﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vsite.Pood.BouncingBall;
using System.Drawing;

namespace Vsite.Pood.BouncingBallDemo
{
    class Paddle : CrashBrick
    {
        public Paddle(PointD leftTop, PointD rightBottom, double ballRadius) 
            : base(leftTop, rightBottom, ballRadius)
        {
        }

        public void Draw(Graphics g)
        {
            double width = RightBottom.X - LeftTop.X;
            double height = RightBottom.Y - LeftTop.Y;
            RectangleF rec = new RectangleF((float)LeftTop.X, (float)LeftTop.Y, (float)width, (float)height);
            g.FillRectangle(Brushes.Green, rec);
        }
    }
}
