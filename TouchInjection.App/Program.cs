using System;
using TouchInjection.Services;

namespace TouchInjection.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var executor = new TouchInjectionExecutor();
            ITouchInjectionListener listener = new TouchInjectionListener(new KeyboardAndMouseProvider(), executor);
            listener.Start();
            Console.ReadLine();
        }
    }
}
