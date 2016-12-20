using System;

namespace Vsite.Pood.BouncingBall
{
    class DestroyableBrick : CrashBrick, IDestroyNotifier
    {
        public DestroyableBrick(PointD leftTop, PointD rightBottom, double ballRadius) 
            : base(leftTop, rightBottom, ballRadius)
        {
            foreach (IHittable plane in CollisionPlanes)
                plane.Hit +=  OnPlaneHit;
        }

        private void OnPlaneHit(object sender, EventArgs ea)
        {
            Destroy?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Destroy;
    }
}
