using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;

namespace TouchInjection.WindowsService
{
    public partial class TouchInjectionService : ServiceBase
    {
        private object _sync;
        private Process _process;
        private Timer _timer;

        public TouchInjectionService()
        {            
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            StartShell();
        }

        private void StartShell()
        {
            var shellName = @"TouchInjection.Presentation.Shell.exe";
            _process = ProcessExtensions.StartProcessAsCurrentUser(shellName);
        }

        private async void WaitForProcessExited()
        {
            await Task.Run(() =>
            {
                _process.WaitForExit();
            });
        }

        protected override void OnStop()
        {
            Process p;

            lock (_process)
            {
                if (_process == null || _process.HasExited)
                {
                    return;
                }

                p = _process;
                _process = null;
            }

            if (!p.CloseMainWindow())
            {
                p.Kill();
            }
        }
    }
}
