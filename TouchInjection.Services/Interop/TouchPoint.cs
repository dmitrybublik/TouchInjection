using System.Runtime.InteropServices;

namespace TouchInjection.Services.Interop
{
    /// <summary>
    /// The TouchPoint structure defines the x- and y- coordinates of a point.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TouchPoint
    {
        /// <summary>
        /// The x-coordinate of the point.
        /// </summary>
        public int X;
        /// <summary>
        /// The y-coordinate of the point.
        /// </summary>
        public int Y;
    }
}