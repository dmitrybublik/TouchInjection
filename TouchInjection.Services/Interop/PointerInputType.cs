namespace TouchInjection.Services.Interop
{
    /// <summary>
    /// Identifies the pointer input types.
    /// </summary>
    public enum PointerInputType
    {
        /// <summary>
        /// Generic pointer type. This type never appears in pointer messages or pointer data. Some data query functions allow the caller to restrict the query to specific pointer type. The PT_POINTER type can be used in these functions to specify that the query is to include pointers of all types
        /// </summary>
        POINTER = 0x00000001,
        /// <summary>
        /// Touch pointer type.
        /// </summary>
        TOUCH = 0x00000002,
        /// <summary>
        /// Pen pointer type.
        /// </summary>
        PEN = 0x00000003,
        /// <summary>
        /// Mouse pointer type
        /// </summary>
        MOUSE = 0x00000004
    };
}