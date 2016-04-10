using System.Threading.Tasks;
using System.Windows.Forms;
using TouchInjection.GlobalHook;
using TouchInjection.Services.Interop;

namespace TouchInjection.Services
{
    public struct KeyInfo
    {
        public Keys KeyCode { get; set; }
        public bool IsShiftPressed { get; set; }
        public bool IsCtrlPressed { get; set; }
        public bool IsAltPressed { get; set; }
    }

    public interface ITouchInjectionService
    {
        Task PinchZoomInAsync(int centerX, int centerY, int distance);
        Task PinchZoomOutAsync(int centerX, int centerY, int distance);
        bool RegisterPinchZoomHotKeys(KeyInfo pinchZoomInKey, KeyInfo pinchZoomOutKey);        
    }

    public sealed class TouchInjectionService : ITouchInjectionService
    {
        private readonly UserActivityHook _hook = new UserActivityHook();
        private KeyInfo _pinchZoomInKeyInfo;
        private KeyInfo _pinchZoomOutKeyInfo;
        private int _mouseX = 500;
        private int _mouseY = 500;
        private int _distance = 100;

        public TouchInjectionService()
        {
            TouchInjector.InitializeTouchInjection();
            _hook.KeyUp += HookOnKeyUp;
            _hook.OnMouseActivity += HookOnOnMouseActivity;               
            _hook.Start();            
        }

        private void HookOnOnMouseActivity(object sender, MouseEventArgs mouseEventArgs)
        {
            _mouseX = mouseEventArgs.X;
            _mouseY = mouseEventArgs.Y;
        }

        private async void HookOnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            if (MatchKey(keyEventArgs, _pinchZoomInKeyInfo))
            {
                await PinchZoomOutAsync(_mouseX, _mouseY, _distance);
            }

            if (MatchKey(keyEventArgs, _pinchZoomOutKeyInfo))
            {
                await PinchZoomInAsync(_mouseX, _mouseY, _distance);
            }
        }

        private static bool MatchKey(KeyEventArgs keyEventArgs, KeyInfo keyInfo)
        {
            return keyEventArgs.KeyCode == keyInfo.KeyCode && keyEventArgs.Alt == keyInfo.IsAltPressed
                   && keyEventArgs.Control == keyInfo.IsCtrlPressed &&
                   keyEventArgs.Shift == keyInfo.IsShiftPressed;
        }

        public async Task PinchZoomOutAsync(int centerX, int centerY, int distance)
        {
            PointerTouchInfo[] contacts = new PointerTouchInfo[2];
            contacts[0] = MakePointerTouchInfo(centerX - distance, centerY, 2, 1);
            contacts[1] = MakePointerTouchInfo(centerX + distance, centerY, 2, 2);

            TouchInjector.InjectTouchInput(2, contacts);

            contacts[0].PointerInfo.PointerFlags = PointerFlags.UPDATE | PointerFlags.INRANGE | PointerFlags.INCONTACT;
            contacts[1].PointerInfo.PointerFlags = PointerFlags.UPDATE | PointerFlags.INRANGE | PointerFlags.INCONTACT;

            //drag them from/to each other
            for (int i = 0; i < distance; i++)
            {
                contacts[0].Move(+1, 0);
                contacts[1].Move(-1, 0);
                TouchInjector.InjectTouchInput(2, contacts);
                await Task.Delay(3);
            }

            //release them
            contacts[0].PointerInfo.PointerFlags = PointerFlags.UP;
            contacts[1].PointerInfo.PointerFlags = PointerFlags.UP;

            TouchInjector.InjectTouchInput(2, contacts);
        }

        public async Task PinchZoomInAsync(int centerX, int centerY, int distance)
        {
            PointerTouchInfo[] contacts = new PointerTouchInfo[2];
            contacts[0] = MakePointerTouchInfo(centerX - distance, centerY, 2, 1);
            contacts[1] = MakePointerTouchInfo(centerX + distance, centerY, 2, 2);

            TouchInjector.InjectTouchInput(2, contacts);

            contacts[0].PointerInfo.PointerFlags = PointerFlags.UPDATE | PointerFlags.INRANGE | PointerFlags.INCONTACT;
            contacts[1].PointerInfo.PointerFlags = PointerFlags.UPDATE | PointerFlags.INRANGE | PointerFlags.INCONTACT;

            //drag them from/to each other
            for (int i = 0; i < distance; i++)
            {
                contacts[0].Move(-1, 0);
                contacts[1].Move(+1, 0);
                bool s = TouchInjector.InjectTouchInput(2, contacts);
                await Task.Delay(3);
            }

            //release them
            contacts[0].PointerInfo.PointerFlags = PointerFlags.UP;
            contacts[1].PointerInfo.PointerFlags = PointerFlags.UP;

            TouchInjector.InjectTouchInput(2, contacts);
        }

        public bool RegisterPinchZoomHotKeys(KeyInfo pinchZoomInKey, KeyInfo pinchZoomOutKey)
        {
            _pinchZoomInKeyInfo = pinchZoomInKey;
            _pinchZoomOutKeyInfo = pinchZoomOutKey;
            return true;
        }

        private PointerTouchInfo MakePointerTouchInfo(int x, int y, int radius, uint id, uint orientation = 90, uint pressure = 32000)
        {
            PointerTouchInfo contact = new PointerTouchInfo
            {
                PointerInfo = {pointerType = PointerInputType.TOUCH},
                TouchFlags = TouchFlags.NONE,
                Orientation = orientation,
                Pressure = pressure
            };

            contact.PointerInfo.PointerFlags = PointerFlags.DOWN | PointerFlags.INRANGE | PointerFlags.INCONTACT;
            contact.TouchMasks = TouchMask.CONTACTAREA | TouchMask.ORIENTATION | TouchMask.PRESSURE;
            contact.PointerInfo.PtPixelLocation.X = x;
            contact.PointerInfo.PtPixelLocation.Y = y;
            contact.PointerInfo.PointerId = id;
            contact.ContactArea.left = x - radius;
            contact.ContactArea.right = x + radius;
            contact.ContactArea.top = y - radius;
            contact.ContactArea.bottom = y + radius;
            return contact;
        }
    }
}