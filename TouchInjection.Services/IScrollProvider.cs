using System;
using System.Collections.Generic;

namespace TouchInjection.Services
{
    public interface IScrollProvider
    {
        int GetVerticalScrollPosition(IntPtr handle);

        int GetHorizontalScrollPosition(IntPtr handle);

        IntPtr GetWindowHandleWithScroll(IntPtr mainWindowHandle);
    }
}