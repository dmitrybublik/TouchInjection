using System.Drawing;
using JetBrains.Annotations;

namespace TouchInjection.Services
{
    [UsedImplicitly]
    public sealed class MouseController : IMouseController
    {
        public Point Location
        {
            get { return MouseSimulator.Position; }
            set { MouseSimulator.Position = value; }
        }
        public void Wheel(int delta)
        {
            MouseSimulator.MouseWheel(delta);
        }

        public void HorizontalWheel(int delta)
        {
            MouseSimulator.MouseHWheel(delta);
        }
    }
}