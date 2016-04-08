using System;

namespace TouchInjection.Services.Interop
{
    /// <summary>
    /// Values that can appear in the TouchMask field of the PointerTouchInfo structure.
    /// </summary>
    [Flags]
    public enum TouchMask
    {
        /// <summary>
        /// Default. None of the optional fields are valid.
        /// </summary>
        NONE = 0x00000000,
        /// <summary>
        /// The ContactArea field is valid
        /// </summary>
        CONTACTAREA = 0x00000001,
        /// <summary>
        /// The orientation field is valid
        /// </summary>
        ORIENTATION = 0x00000002,
        /// <summary>
        /// The pressure field is valid
        /// </summary>
        PRESSURE = 0x00000004
    }
}