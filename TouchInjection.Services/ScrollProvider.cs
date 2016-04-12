using System;
using System.Collections.Generic;
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

        public IEnumerable<Tuple<IntPtr, SCROLLINFO>> GetWindowHandleWithScroll(IntPtr mainWindowHandle)
        {
            var result = ScrollInterop.GetHandlesWithScroll(mainWindowHandle);
            return result;
        }
    }
}