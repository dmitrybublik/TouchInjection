using System.Drawing;

namespace TouchInjection.Services
{
    public interface IMouseController
    {
        Point Location { get; set; }

        void Wheel(int delta);

        void HorizontalWheel(int delta);
    }
}