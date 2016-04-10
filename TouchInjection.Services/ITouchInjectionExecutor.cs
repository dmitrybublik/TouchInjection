using System.Threading.Tasks;

namespace TouchInjection.Services
{
    public interface ITouchInjectionExecutor
    {
        Task PinchZoomInAsync(int centerX, int centerY, int distance, int speed);
        Task PinchZoomOutAsync(int centerX, int centerY, int distance, int speed);       
    }
}