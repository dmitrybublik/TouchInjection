using System;
using System.Windows.Forms;
using TouchInjection.GlobalHook;

namespace TouchInjection.Services
{
    public class KeyboardAndMouseProvider : ITouchInjectionProvider
    {
        private readonly UserActivityHook _hook = new UserActivityHook();
        private KeyInfo _pinchZoomInKeyInfo;
        private KeyInfo _pinchZoomOutKeyInfo;
        private int _mouseX = 500;
        private int _mouseY = 500;
        private int _distance = 100;
        private int _speed = 1;

        public KeyboardAndMouseProvider()
        {
            //TODO: read from config file
            RegisterPinchZoomHotKeys(new KeyInfo
            {
                IsAltPressed = false,
                IsShiftPressed = false,
                IsCtrlPressed = false,
                KeyCode = Keys.F11
            }, new KeyInfo
            {
                IsAltPressed = false,
                IsShiftPressed = false,
                IsCtrlPressed = false,
                KeyCode = Keys.F12
            });
        }

        public void Start()
        {
            _hook.KeyUp += HookOnKeyUp;
            _hook.OnMouseActivity += HookOnOnMouseActivity;
            _hook.Start();
        }

        public void Stop()
        {
            _hook.KeyUp -= HookOnKeyUp;
            _hook.OnMouseActivity -= HookOnOnMouseActivity;
            _hook.Stop();
        }

        public event EventHandler<PinchZoomEventArgs> PinchZoomInitiated;

        private void HookOnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            if (MatchKey(keyEventArgs, _pinchZoomInKeyInfo))
            {
                RaiseSafely(isPinchZoomIn:true);
            }

            if (MatchKey(keyEventArgs, _pinchZoomOutKeyInfo))
            {
                RaiseSafely(isPinchZoomIn: false);
            }
        }

        private void RaiseSafely(bool isPinchZoomIn)
        {
            PinchZoomInitiated?.Invoke(this, new PinchZoomEventArgs(_mouseX, _mouseY, _distance, _speed, isPinchZoomIn));
        }

        private static bool MatchKey(KeyEventArgs keyEventArgs, KeyInfo keyInfo)
        {
            return keyEventArgs.KeyCode == keyInfo.KeyCode && keyEventArgs.Alt == keyInfo.IsAltPressed
                   && keyEventArgs.Control == keyInfo.IsCtrlPressed &&
                   keyEventArgs.Shift == keyInfo.IsShiftPressed;
        }

        private void HookOnOnMouseActivity(object sender, MouseEventArgs mouseEventArgs)
        {
            _mouseX = mouseEventArgs.X;
            _mouseY = mouseEventArgs.Y;
        }

        private bool RegisterPinchZoomHotKeys(KeyInfo pinchZoomInKey, KeyInfo pinchZoomOutKey)
        {
            _pinchZoomInKeyInfo = pinchZoomInKey;
            _pinchZoomOutKeyInfo = pinchZoomOutKey;
            return true;
        }
    }
}