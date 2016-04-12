namespace TouchInjection.Services
{
    public interface ILocationProvider
    {
        int X { get; }
        int Y { get; }

        void Start();
        void Stop();
    }
}
