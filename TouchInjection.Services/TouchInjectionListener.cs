namespace TouchInjection.Services
{
    public class TouchInjectionListener : ITouchInjectionListener
    {
        private readonly ITouchInjectionProvider _touchInjectionProvider;
        private readonly ITouchInjectionExecutor _touchInjectionExecutor;

        public TouchInjectionListener(
            ITouchInjectionProvider touchInjectionProvider,
            ITouchInjectionExecutor touchInjectionExecutor)
        {
            _touchInjectionProvider = touchInjectionProvider;
            _touchInjectionExecutor = touchInjectionExecutor;
            _touchInjectionProvider.PinchZoomInitiated += TouchInjectionProviderOnPinchZoomInitiated;            
        }

        public void Start()
        {
            _touchInjectionProvider.Start();
        }

        public void Stop()
        {
            _touchInjectionProvider.Stop();
        }

        private async void TouchInjectionProviderOnPinchZoomInitiated(object sender, PinchZoomEventArgs pinchZoomEventArgs)
        {
            if (pinchZoomEventArgs.IsPinchZoomIn)
            {
                await _touchInjectionExecutor.PinchZoomInAsync(pinchZoomEventArgs.X, pinchZoomEventArgs.Y,
                    pinchZoomEventArgs.Distance, pinchZoomEventArgs.Speed);
            }
            else
            {
                await _touchInjectionExecutor.PinchZoomOutAsync(pinchZoomEventArgs.X, pinchZoomEventArgs.Y,
                   pinchZoomEventArgs.Distance, pinchZoomEventArgs.Speed);
            }            
        }
    }
}