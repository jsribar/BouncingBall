using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    class LineIntersections
    {
        public LineIntersections(Line line)
        {
            this.line0 = line;
        }

        public PointD GetIntersection(Line line1)
        {
            double det = line0.A * line1.B - line1.A * line0.B;
            if (det == 0)
                return null;
            double x = (line0.B * line1.C - line1.B * line0.C) / det;
            double y = (line1.A * line0.C - line0.A * line1.C) / det;
            return new PointD(x, y);
        }

        private Line line0;
    }
}
