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
            ballBrush = CreateBallBrush();
            CreateBricks();
        }

        private void CreateBricks()
        {
            bricks.Add(new DestroyableBrick(new BouncingBall.PointD(100, 100), new PointD(200,200),ballRadius));
            bricks.Add(new DestroyableBrick(new BouncingBall.PointD(300, 200), new PointD(400, 300), ballRadius));
            bricks.Add(new DestroyableBrick(new BouncingBall.PointD(100, 400), new PointD(200, 500), ballRadius));
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
            PointD newPosition = trajectory.GetNewPosition(DateTime.Now, obstacles);
            pe.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            using (Brush b = MoveBrush(newPosition))
                pe.Graphics.FillEllipse(b, GetBallBounds(newPosition));
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            float distance = ballRadius - 1;
            walls = new List<CollisionPlane> {
                new CollisionPlane(new PointD(0, distance), 
                                   new PointD(ClientRectangle.Right, distance)),
                new CollisionPlane(new PointD(ClientRectangle.Right - distance, 0), 
                                   new PointD(ClientRectangle.Right - distance, ClientRectangle.Bottom)),
                new CollisionPlane(new PointD(0, ClientRectangle.Bottom - distance), 
                                   new PointD(ClientRectangle.Right, ClientRectangle.Bottom - distance)),
                new CollisionPlane(new PointD(distance, 0), 
                                   new PointD(distance, ClientRectangle.Bottom))
            };
            obstacles.Clear();
            obstacles.AddRange(walls);
            obstacles.AddRange(bricks.Items);
        }

        private PathGradientBrush CreateBallBrush()
        {
            GraphicsPath path = new GraphicsPath();
            RectangleF rect = new RectangleF(-ballRadius, -ballRadius, 2 * ballRadius, 2 * ballRadius);
            rect.Inflate(4, 4);
            path.AddEllipse(rect);
            ballBrush = new PathGradientBrush(path);
            Color[] colors =
            {
                Color.FromArgb(255, 0, 0, 127),
                Color.FromArgb(255, 0, 0, 200),
                Color.FromArgb(255, 255, 255, 255)
            };
            float[] relativePosition = { 0f, 0.4f, 1.0f };
            ColorBlend cb = new ColorBlend();
            cb.Colors = colors;
            cb.Positions = relativePosition;
            ballBrush.CenterPoint = new Point(-2, -2);
            ballBrush.InterpolationColors = cb;
            return ballBrush;
        }

        private Brush MoveBrush(PointD point)
        {
            PathGradientBrush b = (PathGradientBrush)ballBrush.Clone();
            b.TranslateTransform((float)point.X, (float)point.Y);
            return b;
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

        PathGradientBrush ballBrush;
        private List<CollisionPlane> walls;
        private CollectionOfDestroyables bricks = new CollectionOfDestroyables();
        private List<ICollisionObject> obstacles = new List<ICollisionObject>();

    }
}
