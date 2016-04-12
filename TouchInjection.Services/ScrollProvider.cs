using System;
using TouchInjection.Services.Interop;

namespace TouchInjection.Services
{
    public class ScrollProvider : IScrollProvider
    {
        public int GetVerticalScrollPosition(IntPtr handle)
        {
            return ScrollInterop.GetVScrollPos(handle);
        }

        public int GetHorizontalScrollPosition(IntPtr handle)
        {
            return ScrollInterop.GetHScrollPos(handle);
        }

        public IntPtr GetWindowHandleWithScroll(IntPtr mainWindowHandle)
        {
            ScrollInterop.GetHandlesWithScroll(mainWindowHandle);
            return mainWindowHandle;
        }
    }
}