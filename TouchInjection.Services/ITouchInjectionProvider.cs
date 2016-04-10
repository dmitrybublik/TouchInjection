using System;

namespace TouchInjection.Services
{
    public interface ITouchInjectionProvider
    {
        void Start();
        void Stop();
        event EventHandler<PinchZoomEventArgs> PinchZoomInitiated;
    }
}