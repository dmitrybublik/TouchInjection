using System;
using TouchInjection.GlobalHook;

namespace TouchInjection.Services
{
    public class TouchInjectionProvider : ITouchInjectionProvider
    {
        private readonly ILocationProvider _locationProvider;
        private readonly IActionProvider _actionProvider;
        private readonly IUserActivityHook _hook;       

        public TouchInjectionProvider(
            ILocationProvider locationProvider,
            IActionProvider actionProvider,
            IUserActivityHook hook)
        {
            _locationProvider = locationProvider;
            _actionProvider = actionProvider;
            _hook = hook;            
        }

        public void Start()
        {
            _hook.Start();
            _actionProvider.PinchZoomInitiated += ActionProviderOnPinchZoomInitiated;
            _actionProvider.Start();            
            _locationProvider.Start();                        
        }

        public void Stop()
        {
            _hook.Stop();
            _actionProvider.Stop();
            _actionProvider.PinchZoomInitiated -= ActionProviderOnPinchZoomInitiated;
            _locationProvider.Stop();                        
        }

        public event EventHandler<PinchZoomWithLocationEventArgs> PinchZoomInitiated;

        private void ActionProviderOnPinchZoomInitiated(object sender, PinchZoomEventArgs pinchZoomEventArgs)
        {
            RaiseSafely(pinchZoomEventArgs);
        }

        private void RaiseSafely(PinchZoomEventArgs pinchZoomEventArgs)
        {
            PinchZoomInitiated?.Invoke(this,
                new PinchZoomWithLocationEventArgs(_locationProvider.X, _locationProvider.Y, pinchZoomEventArgs.Distance,
                    pinchZoomEventArgs.Speed, pinchZoomEventArgs.IsPinchZoomIn));
        }
    }
}