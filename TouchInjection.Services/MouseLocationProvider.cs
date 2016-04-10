using System.Windows.Forms;
using TouchInjection.GlobalHook;

namespace TouchInjection.Services
{
    public class MouseLocationProvider : ILocationProvider
    {
        private readonly IUserActivityHook _userActivityHook;

        public MouseLocationProvider(IUserActivityHook userActivityHook)
        {
            _userActivityHook = userActivityHook;
        }
       
        public int X { get; private set; }

        public int Y { get; private set; }

        public void Start()
        {
            _userActivityHook.OnMouseActivity += HookOnOnMouseActivity;
        }

        public void Stop()
        {
            _userActivityHook.OnMouseActivity -= HookOnOnMouseActivity;
        }

        private void HookOnOnMouseActivity(object sender, MouseEventArgs mouseEventArgs)
        {
            X = mouseEventArgs.X;
            Y = mouseEventArgs.Y;
        }
    }
}