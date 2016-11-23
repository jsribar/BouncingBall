using System;
using System.Drawing;
using System.Windows.Forms;
using Vsite.Pood.BouncingBall;
using System.Collections.Generic;

namespace Vsite.Pood.BouncingBallDemo
{
    public partial class Playground : Control
    {
        public Playground()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public void InitTrajectory()
        {
            Velocity vel = new Velocity(ballVelocity, Math.PI / 4);
            PointD p0 = new PointD(0, 0);
            DateTime now = DateTime.Now;
            trajectory = new Trajectory(vel, p0, now);
            timerRefresh.Start();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (trajectory == null)
                return;
            PointD newPosition = trajectory.GetNewPosition(DateTime.Now, planes);
            pe.Graphics.FillEllipse(Brushes.Blue, GetBallBounds(newPosition));
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private RectangleF GetBallBounds(PointD center)
        {
            return new RectangleF((float)(center.X - ballRadius), (float)(center.Y - ballRadius), 2 * ballRadius, 2 * ballRadius);
        }

        private void Playground_Click(object sender, EventArgs e)
        {
            InitTrajectory();
        }

        private Trajectory trajectory = null;
        private float ballRadius = 5;
        private double ballVelocity = 300;

        private List<CollisionPlane> planes = new List<CollisionPlane>
        {
            new CollisionPlane(new PointD(200, 0), new PointD(200, 300)),
            new CollisionPlane(new PointD(0, 300), new PointD(300, 300))
        };
    }
}
