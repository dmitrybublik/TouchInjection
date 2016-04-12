using System.Runtime.InteropServices;

namespace TouchInjection.Services.Interop
{
    /// <summary>
    /// Use this Classes static methods to initialize and inject touch input.
    /// </summary>
    public class TouchInjector
    {
        /// <summary>
        /// Call this first to initialize the TouchInjection!
        /// </summary>
        /// <param name="maxCount">The maximum number of touch points to simulate. Must be less than 256!</param>
        /// <param name="feedbackMode">Specifies the visual feedback mode of the generated touch points</param>
        /// <returns>true if success</returns>
        [DllImport("User32.dll")]
        public static extern bool InitializeTouchInjection(uint maxCount = 256, TouchFeedback feedbackMode = TouchFeedback.DEFAULT);

        /// <summary>
        /// Inject an array of POINTER_TUCH_INFO
        /// </summary>
        /// <param name="count">The exact number of entries in the array</param>
        /// <param name="contacts">The POINTER_TOUCH_INFO to inject</param>
        /// <returns>true if success</returns>
        [DllImport("User32.dll")]
        public static extern bool InjectTouchInput(int count, [MarshalAs(UnmanagedType.LPArray), In] PointerTouchInfo[] contacts);
    }
}