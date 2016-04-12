using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TouchInjection.Services.Interop
{
    public static class ScrollInterop
    {
        // ScrollBar types
        private const int SB_HORZ = 0;
        private const int SB_VERT = 1;

        private const int SIF_TRACKPOS = 0x10;
        private const int SIF_RANGE = 0x1;
        private const int SIF_POS = 0x4;
        private const int SIF_PAGE = 0x2;
        private const int SIF_ALL = SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi);

        public delegate bool Win32Callback(IntPtr hwnd, IntPtr lParam);
        [DllImport("user32.Dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr parentHandle, Win32Callback callback, IntPtr lParam);

        public static int GetVScrollPos(IntPtr hWnd)
        {
            return GetScrollPos(hWnd, SB_VERT);
        }

        public static int GetHScrollPos(IntPtr hWnd)
        {
            return GetScrollPos(hWnd, SB_HORZ);
        }


        /// <summary>
        /// Returns a list of child windows
        /// </summary>
        /// <param name="parent">Parent of the windows to return</param>
        /// <returns>List of child windows</returns>
        public static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                Win32Callback childProc = EnumWindow;
                EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                {
                    listHandle.Free();
                }
            }
            return result;
        }

        /// <summary>
        /// Callback method to be used when enumerating windows.
        /// </summary>
        /// <param name="handle">Handle of the next window</param>
        /// <param name="pointer">Pointer to a GCHandle that holds a reference to the list to fill</param>
        /// <returns>True to continue the enumeration, false to bail</returns>
        private static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            GCHandle gch = GCHandle.FromIntPtr(pointer);
            List<IntPtr> list = gch.Target as List<IntPtr>;
            if (list == null)
            {
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
            }
            list.Add(handle);
            //  You can modify this to check to see if you want to cancel the operation, then return a null here
            return true;
        }

        private static SCROLLINFO GetScrollInfo(IntPtr hWnd)
        {
            SCROLLINFO si = new SCROLLINFO();
            si.fMask = SIF_ALL;
            si.cbSize = (uint)Marshal.SizeOf(si);
            GetScrollInfo(hWnd, SB_VERT, ref si);
            return si;
        }

        private static IEnumerable<IntPtr> GetAllChildrenWindows(IntPtr hWnd)
        {
            List<IntPtr> result = new List<IntPtr>();
            result.Add(hWnd);
            var childrenWnd = GetChildWindows(hWnd);
            foreach (var childWnd in childrenWnd)
            {
                result.AddRange(GetAllChildrenWindows(childWnd));
            }

            return result;
        }

        public static IEnumerable<Tuple<IntPtr, SCROLLINFO>> GetHandlesWithScroll(IntPtr hWnd)
        {
            GetScrollInfo(hWnd);
            var childrenWnd = GetAllChildrenWindows(hWnd);
            foreach (var childWnd in childrenWnd)
            {
                var si = GetScrollInfo(childWnd);
            }
            return null;
        }
    }
}