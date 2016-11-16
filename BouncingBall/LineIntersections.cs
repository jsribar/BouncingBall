using System;
using System.Linq;
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
        
        public IEnumerable<ColisionPoint> GetColisionPoints(IEnumerable<ColisionPlane> planes)
        {
            List<ColisionPoint> colisionPoints = new List<ColisionPoint>();
            foreach(ColisionPlane plane in planes)
            {
                PointD intersection = GetIntersection(plane);
                if (intersection!=null)
                    colisionPoints.Add(new ColisionPoint(plane, intersection));
            }
            return colisionPoints;
        }

        public IEnumerable<ColisionPoint> GetClosestColisionPoints(IEnumerable<ColisionPlane> planes)
        {
            IEnumerable<ColisionPoint> allColisionPoints = GetColisionPoints(planes);
            double minimalDistance = allColisionPoints.Min(cp => cp.Point.distance(line0.P1));
            return allColisionPoints.Where(cp => cp.Point.distance(line0.P1) == minimalDistance);

            throw new NotImplementedException();
        }

        private Line line0;
    }
}
