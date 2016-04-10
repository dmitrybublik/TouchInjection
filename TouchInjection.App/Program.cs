using System;
using TouchInjection.GlobalHook;
using TouchInjection.Services;

namespace TouchInjection.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var executor = new TouchInjectionExecutor();
            var hook = new UserActivityHook();
            ITouchInjectionListener listener =
                new TouchInjectionListener(
                    new TouchInjectionProvider(
                        new MouseLocationProvider(hook), 
                        new KeyboardActionProvider(hook), 
                        hook),
                    executor);
            listener.Start();
            Console.ReadLine();
        }
    }
}
