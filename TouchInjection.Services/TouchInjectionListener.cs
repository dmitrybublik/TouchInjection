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

        private async void TouchInjectionProviderOnPinchZoomInitiated(object sender, PinchZoomWithLocationEventArgs pinchZoomWithLocationEventArgs)
        {
            if (pinchZoomWithLocationEventArgs.IsPinchZoomIn)
            {
                await _touchInjectionExecutor.PinchZoomInAsync(pinchZoomWithLocationEventArgs.X, pinchZoomWithLocationEventArgs.Y,
                    pinchZoomWithLocationEventArgs.Distance, pinchZoomWithLocationEventArgs.Speed);
            }
            else
            {
                await _touchInjectionExecutor.PinchZoomOutAsync(pinchZoomWithLocationEventArgs.X, pinchZoomWithLocationEventArgs.Y,
                   pinchZoomWithLocationEventArgs.Distance, pinchZoomWithLocationEventArgs.Speed);
            }            
        }
    }
}