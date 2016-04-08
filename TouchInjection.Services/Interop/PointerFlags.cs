using System;

namespace TouchInjection.Services.Interop
{
    /// <summary>
    /// Values that can appear in the PointerFlags field of the PointerInfo structure.
    /// </summary>
    [Flags]
    public enum PointerFlags
    {
        /// <summary>
        /// Default
        /// </summary>
        NONE = 0x00000000,
        /// <summary>
        /// Indicates the arrival of a new pointer
        /// </summary>
        NEW = 0x00000001,
        /// <summary>
        /// Indicates that this pointer continues to exist. When this flag is not set, it indicates the pointer has left detection range. 
        /// This flag is typically not set only when a hovering pointer leaves detection range (PointerFlag.UPDATE is set) or when a pointer in contact with a window surface leaves detection range (PointerFlag.UP is set). 
        /// </summary>
        INRANGE = 0x00000002,
        /// <summary>
        /// Indicates that this pointer is in contact with the digitizer surface. When this flag is not set, it indicates a hovering pointer.
        /// </summary>
        INCONTACT = 0x00000004,
        /// <summary>
        /// Indicates a primary action, analogous to a mouse left button down.
        ///A touch pointer has this flag set when it is in contact with the digitizer surface.
        ///A pen pointer has this flag set when it is in contact with the digitizer surface with no buttons pressed.
        ///A mouse pointer has this flag set when the mouse left button is down.
        /// </summary>
        FIRSTBUTTON = 0x00000010,
        /// <summary>
        /// Indicates a secondary action, analogous to a mouse right button down.
        /// A touch pointer does not use this flag.
        /// A pen pointer has this flag set when it is in contact with the digitizer surface with the pen barrel button pressed.
        /// A mouse pointer has this flag set when the mouse right button is down.
        /// </summary>
        SECONDBUTTON = 0x00000020,
        /// <summary>
        /// Indicates a secondary action, analogous to a mouse right button down. 
        /// A touch pointer does not use this flag. 
        /// A pen pointer does not use this flag. 
        /// A mouse pointer has this flag set when the mouse middle button is down.
        /// </summary>
        THIRDBUTTON = 0x00000040,
        /// <summary>
        /// Indicates actions of one or more buttons beyond those listed above, dependent on the pointer type. Applications that wish to respond to these actions must retrieve information specific to the pointer type to determine which buttons are pressed. For example, an application can determine the buttons states of a pen by calling GetPointerPenInfo and examining the flags that specify button states.
        /// </summary>
        OTHERBUTTON = 0x00000080,
        /// <summary>
        /// Indicates that this pointer has been designated as primary. A primary pointer may perform actions beyond those available to non-primary pointers. For example, when a primary pointer makes contact with a window’s surface, it may provide the window an opportunity to activate by sending it a WM_POINTERACTIVATE message.
        /// </summary>
        PRIMARY = 0x00000100,
        /// <summary>
        /// Confidence is a suggestion from the source device about whether the pointer represents an intended or accidental interaction, which is especially relevant for PT_TOUCH pointers where an accidental interaction (such as with the palm of the hand) can trigger input. The presence of this flag indicates that the source device has high confidence that this input is part of an intended interaction.
        /// </summary>
        CONFIDENCE = 0x00000200,
        /// <summary>
        /// Indicates that the pointer is departing in an abnormal manner, such as when the system receives invalid input for the pointer or when a device with active pointers departs abruptly. If the application receiving the input is in a position to do so, it should treat the interaction as not completed and reverse any effects of the concerned pointer.
        /// </summary>
        CANCELLED = 0x00000400,
        /// <summary>
        /// Indicates that this pointer just transitioned to a “down” state; that is, it made contact with the window surface.
        /// </summary>
        DOWN = 0x00010000,
        /// <summary>
        /// Indicates that this information provides a simple update that does not include pointer state changes.
        /// </summary>
        UPDATE = 0x00020000,
        /// <summary>
        /// Indicates that this pointer just transitioned to an “up” state; that is, it broke contact with the window surface.
        /// </summary>
        UP = 0x00040000,
        /// <summary>
        /// Indicates input associated with a pointer wheel. For mouse pointers, this is equivalent to the action of the mouse scroll wheel (WM_MOUSEWHEEL).
        /// </summary>
        WHEEL = 0x00080000,
        /// <summary>
        /// Indicates input associated with a pointer h-wheel. For mouse pointers, this is equivalent to the action of the mouse horizontal scroll wheel (WM_MOUSEHWHEEL).
        /// </summary>
        HWHEEL = 0x00100000
    }
}