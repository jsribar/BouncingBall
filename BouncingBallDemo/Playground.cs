using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vsite.Pood.BouncingBall;

namespace Vsite.Pood.BouncingBallDemo
{
    public partial class Playground : Control
    {
        public Playground()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (trajectory == null)
                return;
            PointD newP = trajectory.GetNewPosition(DateTime.Now);
            RectangleF rect = new RectangleF((float)(newP.X - 5), (float)(newP.Y - 5), 10f, 10f);
            pe.Graphics.FillEllipse(Brushes.Blue, rect);
            //base.OnPaint(pe);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        public void InitTrajectory()
        {
            Velocity vel = new Velocity(10, Math.PI / 4);
            PointD p0 = new PointD(0, 0);
            DateTime now = DateTime.Now;
            trajectory = new Trajectory(vel, p0, now);
            timer1.Start();
        }

        Trajectory trajectory = null;

        private void Playground_Click(object sender, EventArgs e)
        {
            InitTrajectory();
        }
    }
}
