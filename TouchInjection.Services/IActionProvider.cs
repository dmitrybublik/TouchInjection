using System;

namespace TouchInjection.Services
{
    public interface IActionProvider
    {
        void Start();
        void Stop();

        event EventHandler<PinchZoomEventArgs> PinchZoomInitiated;
    }
}