using System.ServiceProcess;

namespace TouchInjection.WindowsService
{
    public partial class TouchInjectionService : ServiceBase
    {
        //private readonly ITouchInjectionListener _listener;

        public TouchInjectionService()
        {
            InitializeComponent();

            //var executor = new TouchInjectionExecutor();
            //var hook = new UserActivityHook();

            //_listener = new TouchInjectionListener(
            //    new TouchInjectionProvider(
            //        new MouseLocationProvider(hook),
            //        new KeyboardActionProvider(hook),
            //        hook),
            //    executor);
        }

        protected override void OnStart(string[] args)
        {
            //_listener.Start();
        }

        protected override void OnStop()
        {
            //_listener.Stop();
            //Application.Current.Shutdown();
        }
    }
}
