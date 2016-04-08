using System.Runtime.InteropServices;

namespace TouchInjection.Services.Interop
{
    /// <summary>
    /// Contains information about a 'contact' (coordinates, size, pressure...)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PointerTouchInfo
    {
        ///<summary>
        /// Contains basic pointer information common to all pointer types.
        ///</summary>
        public PointerInfo PointerInfo;

        ///<summary>
        /// Lists the touch flags.
        ///</summary>
        public TouchFlags TouchFlags;

        /// <summary>
        /// Indicates which of the optional fields contain valid values. The member can be zero or any combination of the values from the Touch Mask constants.
        /// </summary>
        public TouchMask TouchMasks;

        ///<summary>
        /// Pointer contact area in pixel screen coordinates. 
        /// By default, if the device does not report a contact area, 
        /// this field defaults to a 0-by-0 rectangle centered around the pointer location.
        ///</summary>
        public ContactArea ContactArea;

        /// <summary>
        /// A raw pointer contact area.
        /// </summary>
        public ContactArea ContactAreaRaw;

        ///<summary>
        /// A pointer orientation, with a value between 0 and 359, where 0 indicates a touch pointer 
        /// aligned with the x-axis and pointing from left to right; increasing values indicate degrees
        /// of rotation in the clockwise direction.
        /// This field defaults to 0 if the device does not report orientation.
        ///</summary>
        public uint Orientation;

        ///<summary>
        /// Pointer pressure normalized in a range of 0 to 256.
        ///</summary>
        public uint Pressure;

        /// <summary>
        /// Move the touch point, together with its ContactArea
        /// </summary>
        /// <param name="deltaX">the change in the x-value</param>
        /// <param name="deltaY">the change in the y-value</param>
        public void Move(int deltaX, int deltaY)
        {
            PointerInfo.PtPixelLocation.X += deltaX;
            PointerInfo.PtPixelLocation.Y += deltaY;
            ContactArea.left += deltaX;
            ContactArea.right += deltaX;
            ContactArea.top += deltaY;
            ContactArea.bottom += deltaY;
        }
    }
}