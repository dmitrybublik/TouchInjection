using System.ServiceProcess;

namespace TouchInjection.WindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new TouchInjectionService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
