using System.Windows.Forms;

namespace TouchInjection.Services
{
    public struct KeyInfo
    {
        public Keys KeyCode { get; set; }
        public bool IsShiftPressed { get; set; }
        public bool IsCtrlPressed { get; set; }
        public bool IsAltPressed { get; set; }
    }
}