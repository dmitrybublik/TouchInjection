using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using TouchInjection.Services.Interop;

namespace TouchInjection.Services
{
    public sealed class TouchInjectionService
    {
        public TouchInjectionService()
        {
            bool s = TouchInjector.InitializeTouchInjection(); //initialize with default settings        
        }

        public async Task PinchAsync(int centerX, int centerY, int distance)
        {
            PointerTouchInfo[] contacts = new PointerTouchInfo[2];
            contacts[0] = MakePointerTouchInfo(centerX - distance, centerY, 2, 1);
            contacts[1] = MakePointerTouchInfo(centerX + distance, centerY, 2, 2);

            bool success = TouchInjector.InjectTouchInput(2, contacts);

            contacts[0].PointerInfo.PointerFlags = PointerFlags.UPDATE | PointerFlags.INRANGE | PointerFlags.INCONTACT;
            contacts[1].PointerInfo.PointerFlags = PointerFlags.UPDATE | PointerFlags.INRANGE | PointerFlags.INCONTACT;

            //drag them from/to each other
            for (int i = 0; i < distance; i++)
            {
                contacts[0].Move(+1, 0);
                contacts[1].Move(-1, 0);
                bool s = TouchInjector.InjectTouchInput(2, contacts);
                await Task.Delay(3);
            }

            //release them
            contacts[0].PointerInfo.PointerFlags = PointerFlags.UP;
            contacts[1].PointerInfo.PointerFlags = PointerFlags.UP;

            bool success2 = TouchInjector.InjectTouchInput(2, contacts);
        }

        public async Task ZoomAsync(int centerX, int centerY, int distance)
        {
            PointerTouchInfo[] contacts = new PointerTouchInfo[2];
            contacts[0] = MakePointerTouchInfo(centerX - distance, centerY, 2, 1);
            contacts[1] = MakePointerTouchInfo(centerX + distance, centerY, 2, 2);

            bool success = TouchInjector.InjectTouchInput(2, contacts);

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

            bool success2 = TouchInjector.InjectTouchInput(2, contacts);
        }

        public bool RegisterHotkeys(Control control, Keys enterTouchModeKey, Keys exitTouchModeKey)
        {
            var enterTouchModeHotkey = new Hotkey();
            enterTouchModeHotkey.KeyCode = enterTouchModeKey;
            if (!enterTouchModeHotkey.GetCanRegister(control))
            {
                return false;
            }

            enterTouchModeHotkey.Pressed += OnEnterTouchModePressed;
            enterTouchModeHotkey.Register(control);

            return true;
        }

        private void OnEnterTouchModePressed(object sender, HandledEventArgs e)
        {
            
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