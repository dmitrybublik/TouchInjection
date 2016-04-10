using System;

namespace TouchInjection.Services
{
    public class PinchZoomWithLocationEventArgs : EventArgs
    {
        public PinchZoomWithLocationEventArgs(int x, int y, int distance, int speed, bool isPinchZoomIn)
        {
            X = x;
            Y = y;
            Distance = distance;
            Speed = speed;
            IsPinchZoomIn = isPinchZoomIn;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public int Distance { get; private set; }
        public int Speed { get; private set; }
        public bool IsPinchZoomIn { get; set; }
    }

    public class PinchZoomEventArgs : EventArgs
    {
        public PinchZoomEventArgs(int distance, int speed, bool isPinchZoomIn)
        {           
            Distance = distance;
            Speed = speed;
            IsPinchZoomIn = isPinchZoomIn;
        }

        
        public int Distance { get; private set; }
        public int Speed { get; private set; }
        public bool IsPinchZoomIn { get; set; }
    }
}