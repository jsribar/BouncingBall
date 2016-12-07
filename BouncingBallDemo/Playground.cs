using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Vsite.Pood.BouncingBall;

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
            Velocity vel = new Velocity(ballVelocity, Math.PI / 3);
            PointD p0 = new PointD(10, 10);
            DateTime now = DateTime.Now;
            trajectory = new Trajectory(vel, p0, now);
            timerRefresh.Start();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (trajectory == null)
                return;
            PointD newPosition = trajectory.GetNewPosition(DateTime.Now, planes);

            GraphicsPath path = new GraphicsPath();
            RectangleF rect = new RectangleF((float)(newPosition.X - ballRadius),
                                             (float)(newPosition.Y - ballRadius),
                                             2 * ballRadius,
                                             2 * ballRadius);
            rect.Inflate(4, 4);
            path.AddEllipse(rect);
            using (PathGradientBrush pgb = new PathGradientBrush(path))
            {
                Color[] colors =
                {
                    Color.FromArgb(255, 127, 0, 0),
                    Color.FromArgb(255, 200, 0, 0),
                    Color.FromArgb(255, 255, 255, 255)
                };
                float[] relativePosition = { 0f, 0.4f, 1.0f };
                ColorBlend cb = new ColorBlend();
                cb.Colors = colors;
                cb.Positions = relativePosition;
                pgb.CenterPoint = new Point((int)(newPosition.X - 2), (int)(newPosition.Y - 2));
                pgb.InterpolationColors = cb;
                pe.Graphics.FillEllipse(pgb, GetBallBounds(newPosition));
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            float distance = ballRadius - 1;
            planes = new List<CollisionPlane> {
                new CollisionPlane(new PointD(0, distance), 
                                   new PointD(ClientRectangle.Right, distance)),
                new CollisionPlane(new PointD(ClientRectangle.Right - distance, 0), 
                                   new PointD(ClientRectangle.Right - distance, ClientRectangle.Bottom)),
                new CollisionPlane(new PointD(0, ClientRectangle.Bottom - distance), 
                                   new PointD(ClientRectangle.Right, ClientRectangle.Bottom - distance)),
                new CollisionPlane(new PointD(distance, 0), 
                                   new PointD(distance, ClientRectangle.Bottom))
        };
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
        private float ballRadius = 10;
        private double ballVelocity = 300;

        private List<CollisionPlane> walls;
        private List<ICollisionObject> destroyableObstacles = new List<ICollisionObject>();

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Playground
            // 
            this.Click += new System.EventHandler(this.Playground_Click_1);
            this.ResumeLayout(false);

        }

        private Timer timerRefresh;
        private System.ComponentModel.IContainer components;

        private void Playground_Click_1(object sender, EventArgs e)
        {

        }
    }
}
