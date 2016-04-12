using System;
using System.ServiceProcess;

namespace TouchInjection.App
{
    class Program
    {
        //private const string ShellName =
        //    @"c:\Projects\Logismika\TouchInjection\TouchInjection.Panel.Shell\bin\Debug\TouchInjection.Presentation.Shell.exe";


        static void Main(string[] args)
        {
            //var executor = new TouchInjectionExecutor();
            //var hook = new UserActivityHook();
            //ITouchInjectionListener listener =
            //    new TouchInjectionListener(
            //        new TouchInjectionProvider(
            //            new MouseLocationProvider(hook), 
            //            new KeyboardActionProvider(hook), 
            //            hook),
            //        executor);
            //listener.Start();

            bool interactive = Environment.UserInteractive;
            //interactive = false;

            if (!interactive)
            {
                // running as service
                using (var service = new TestService())
                {
                    ServiceBase.Run(service);
                }
            }
            else
            {
                // running as console app
                Start(args);

                Console.WriteLine("Press any key to stop...");
                Console.ReadKey(true);

                Stop();
            }
        }

        private static void Start(string[] args)
        {
            var shellName = args[0];
            var info = ProcessExtensions.StartProcessAsCurrentUser(shellName);
        }

        private static void Stop()
        {
            
        }

        public class TestService : ServiceBase
        {
            public TestService()
            {
                ServiceName = "Test Service";
            }

            protected override void OnStart(string[] args)
            {
                Program.Start(args);
            }

            protected override void OnStop()
            {
                Program.Stop();
            }
        }
    }
}
