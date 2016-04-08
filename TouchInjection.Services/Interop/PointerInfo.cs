using System;
using System.Runtime.InteropServices;

namespace TouchInjection.Services.Interop
{
    /// <summary>
    /// Contains basic pointer information common to all pointer types. Applications can retrieve this information using the GetPointerInfo, GetPointerFrameInfo, GetPointerInfoHistory and GetPointerFrameInfoHistory functions. 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PointerInfo
    {
        /// <summary>
        /// A value from the PointerInputType enumeration that specifies the pointer type.
        /// </summary>
        public PointerInputType pointerType;

        /// <summary>
        /// An identifier that uniquely identifies a pointer during its lifetime. A pointer comes into existence when it is first detected and ends its existence when it goes out of detection range. Note that if a physical entity (finger or pen) goes out of detection range and then returns to be detected again, it is treated as a new pointer and may be assigned a new pointer identifier.
        /// </summary>
        public uint PointerId;

        /// <summary>
        /// An identifier common to multiple pointers for which the source device reported an update in a single input frame. For example, a parallel-mode multi-touch digitizer may report the positions of multiple touch contacts in a single update to the system.
        /// Note that frame identifier is assigned as input is reported to the system for all pointers across all devices. Therefore, this field may not contain strictly sequential values in a single series of messages that a window receives. However, this field will contain the same numerical value for all input updates that were reported in the same input frame by a single device.
        /// </summary>
        public uint FrameId;

        /// <summary>
        /// May be any reasonable combination of flags from the Pointer Flags constants.
        /// </summary>
        public PointerFlags PointerFlags;

        /// <summary>
        /// Handle to the source device that can be used in calls to the raw input device API and the digitizer device API.
        /// </summary>
        public IntPtr SourceDevice;

        /// <summary>
        /// Window to which this message was targeted. If the pointer is captured, either implicitly by virtue of having made contact over this window or explicitly using the pointer capture API, this is the capture window. If the pointer is uncaptured, this is the window over which the pointer was when this message was generated.
        /// </summary>
        public IntPtr WindowTarget;

        /// <summary>
        /// Location in screen coordinates.
        /// </summary>
        public TouchPoint PtPixelLocation;

        /// <summary>
        /// Location in device coordinates.
        /// </summary>
        public TouchPoint PtPixelLocationRaw;

        /// <summary>
        /// Location in HIMETRIC units.
        /// </summary>
        public TouchPoint PtHimetricLocation;

        /// <summary>
        /// Location in device coordinates in HIMETRIC units.
        /// </summary>
        public TouchPoint PtHimetricLocationRaw;

        /// <summary>
        /// A message time stamp assigned by the system when this input was received.
        /// </summary>
        public uint Time;

        /// <summary>
        /// Count of inputs that were coalesced into this message. This count matches the total count of entries that can be returned by a call to GetPointerInfoHistory. If no coalescing occurred, this count is 1 for the single input represented by the message.
        /// </summary>
        public uint HistoryCount;

        /// <summary>
        /// A value whose meaning depends on the nature of input. 
        /// When flags indicate PointerFlag.WHEEL, this value indicates the distance the wheel is rotated, expressed in multiples or factors of WHEEL_DELTA. A positive value indicates that the wheel was rotated forward and a negative value indicates that the wheel was rotated backward. 
        /// When flags indicate PointerFlag.HWHEEL, this value indicates the distance the wheel is rotated, expressed in multiples or factors of WHEEL_DELTA. A positive value indicates that the wheel was rotated to the right and a negative value indicates that the wheel was rotated to the left. 
        /// </summary>
        public uint InputData;

        /// <summary>
        /// Indicates which keyboard modifier keys were pressed at the time the input was generated. May be zero or a combination of the following values. 
        /// POINTER_MOD_SHIFT – A SHIFT key was pressed. 
        /// POINTER_MOD_CTRL – A CTRL key was pressed. 
        /// </summary>
        public uint KeyStates;

        /// <summary>
        /// TBD
        /// </summary>
        public ulong PerformanceCount;

        /// <summary>
        /// ???
        /// </summary>
        public PointerButtonChangeType ButtonChangeType;
    }
}