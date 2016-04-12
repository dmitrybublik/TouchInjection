using System;
using System.Collections.Generic;
using TouchInjection.Services.Interop;

namespace TouchInjection.Services
{
    public interface IScrollProvider
    {
        int GetVerticalScrollPosition(IntPtr handle);

        int GetHorizontalScrollPosition(IntPtr handle);

        IEnumerable<Tuple<IntPtr, SCROLLINFO>> GetWindowHandleWithScroll(IntPtr mainWindowHandle);
    }
}