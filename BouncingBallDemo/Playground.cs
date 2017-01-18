using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
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
            CreateDestroyableBricks();
        }

        private void CreateDestroyableBricks()
        {
            Random rand = new Random();
            int levelIdx = rand.Next(0, stageLoader.levels.Count);

            List<Line> rectangleDiagonals = stageLoader.GetLevelData(stageLoader.levels[levelIdx]);

            bricks.Clear();
            bricks.ItemDestroyed -= OnObstacleDestroyed;
            foreach(var line in rectangleDiagonals)
                bricks.Add(new VisibleDestroyableBrick(line.P1, line.P2, ballRadius));

            bricks.ItemDestroyed += OnObstacleDestroyed;
        }

        public void InitTrajectory()
        {
            if(ballTrajectory == null)
            {
                Velocity vel = new Velocity(ballVelocity, Math.PI / 3);
                PointD p0 = new PointD(10, 10);
                DateTime now = DateTime.Now;
                ballTrajectory = new Trajectory(vel, p0, now);
                timerRefresh.Start();
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            foreach (VisibleDestroyableBrick b in bricks.Items)
                b.Draw(pe.Graphics);
            playerPaddle.Draw(pe.Graphics);
            if (ballTrajectory == null)
                return;
            PointD newPosition = ballTrajectory.GetNewPosition(DateTime.Now, obstacles);
            pe.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            using (Brush b = MoveBrush(newPosition))
                pe.Graphics.FillEllipse(b, GetBallBounds(newPosition));
            if (IsOutOfBounds(newPosition))
                RestartStage();
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
                //new CollisionPlane(new PointD(0, ClientRectangle.Bottom - distance),
                //                   new PointD(ClientRectangle.Right, ClientRectangle.Bottom - distance)),
                new CollisionPlane(new PointD(distance, 0),
                                   new PointD(distance, ClientRectangle.Bottom))
            };
            playerPaddle = CreatePaddle();
            obstacles.Clear();
            obstacles.AddRange(walls);
            obstacles.AddRange(bricks.Items);
            obstacles.Add(playerPaddle);
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
            if(heldKey == (int)Arrows.Right)
            {
                PointD newLeftTop = new PointD(
                    playerPaddle.LeftTop.X + 5, playerPaddle.LeftTop.Y);
                PointD newRightBottom = new PointD(
                    playerPaddle.RightBottom.X + 5, playerPaddle.RightBottom.Y);
                MovePaddle(newLeftTop, newRightBottom);
            }
            else if (heldKey == (int)Arrows.Left)
            {
                PointD newLeftTop = new PointD(
                    playerPaddle.LeftTop.X - 1, playerPaddle.LeftTop.Y);
                PointD newRightBottom = new PointD(
                    playerPaddle.RightBottom.X - 1, playerPaddle.RightBottom.Y);
                MovePaddle(newLeftTop, newRightBottom);
            }
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

        private void OnObstacleDestroyed(object sender, CollectionOfDestroyables.DestroyedItemEventArgs args)
        {
            obstacles.Remove(args.DestroyedItem);
            dingSound.Stop();
            dingSound.Play();
        }

        private bool IsOutOfBounds(PointD point)
        {
            //Line line = new Line(point, new PointD(point.X + 10000, point.Y));
            //LineIntersections li = new LineIntersections(line);
            //var cpoints = li.GetCollisionPoints(walls);

            //if (cpoints.Count() % 2 != 1)
            //    return true;
            //else
            //    return false;

            if (point.X < ClientRectangle.Left || point.X > ClientRectangle.Right
                || point.Y < ClientRectangle.Top || point.Y > ClientRectangle.Bottom)
                return true;
            return false;
        }

        private void RestartStage()
        {
            ballTrajectory = null;
            CreateDestroyableBricks();
            obstacles.Clear();
            obstacles.AddRange(walls);
            obstacles.AddRange(bricks.Items);
            playerPaddle = CreatePaddle();
        }

        private Paddle CreatePaddle()
        {
            int rectangleCenter = (ClientRectangle.Right - ClientRectangle.Left) / 2;
            Paddle p = new Paddle(
                new PointD(rectangleCenter - 50, ClientRectangle.Bottom - 40),
                new PointD(rectangleCenter + 50, ClientRectangle.Bottom - 20),
                ballRadius);

            return p;
        }

        private void MovePaddle(PointD newLeftTop, PointD newRightBottom)
        {
            if (newLeftTop.X < ClientRectangle.X)
                newLeftTop.X = ClientRectangle.Left;
            if (newRightBottom.X > ClientRectangle.X)
                newRightBottom.X = ClientRectangle.Right;
            playerPaddle.DoMove(newLeftTop, newRightBottom);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                    return true;
                case Keys.Shift | Keys.Right:
                case Keys.Shift | Keys.Left:
                case Keys.Shift | Keys.Up:
                case Keys.Shift | Keys.Down:
                    return true;
            }
            return base.IsInputKey(keyData);
        }

        private void Playground_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right)
                heldKey = (int)Arrows.Right;
            else if(e.KeyCode == Keys.Left)
                heldKey = (int)Arrows.Left;
        }

        private void Playground_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && heldKey == (int)Arrows.Right)
                heldKey = (int)Arrows.None;
            else if (e.KeyCode == Keys.Left && heldKey == (int)Arrows.Left)
                heldKey = (int)Arrows.None;
        }

        private Trajectory ballTrajectory = null;
        private float ballRadius = 10;
        private double ballVelocity = 300;

        PathGradientBrush ballBrush;
        private List<CollisionPlane> walls;
        private CollectionOfDestroyables bricks = new CollectionOfDestroyables();
        private List<ICollisionObject> obstacles = new List<ICollisionObject>();

        SoundPlayer dingSound = new SoundPlayer(Vsite.Pood.BouncingBallDemo.Resource.Windows_Ding);

        private StageLoader stageLoader = new StageLoader();
        private int heldKey = (int)Arrows.None;
        private enum Arrows {  None, Right, Left};
        Paddle playerPaddle;

        
    }
}
