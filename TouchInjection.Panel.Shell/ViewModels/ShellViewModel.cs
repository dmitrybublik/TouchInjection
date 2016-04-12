using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Caliburn.Micro;
using JetBrains.Annotations;
using LogoFX.Client.Mvvm.Commanding;
using TouchInjection.Services;

namespace TouchInjection.Presentation.Shell.ViewModels
{
    [UsedImplicitly]
    public sealed class ShellViewModel : PropertyChangedBase
    {
        private readonly ObservableCollection<string> _logItems = 
            new ObservableCollection<string>();

        private readonly ITouchInjectionExecutor _executor;
        private readonly IMouseController _mouseController;

        public ShellViewModel(
            ITouchInjectionListener listener,
            ITouchInjectionExecutor executor,
            IMouseController mouseController)
        {
            listener.Start();
            _executor = executor;
            _mouseController = mouseController;
        }

        private ICommand _zoomInCommand;
        public ICommand ZoomInCommand
        {
            get { return _zoomInCommand ?? (_zoomInCommand = ActionCommand.Do(ZoomInAsync)); }
        }

        private ICommand _zoomOutCommand;
        public ICommand ZoomOutCommand
        {
            get { return _zoomOutCommand ?? (_zoomOutCommand = ActionCommand.Do(ZoomOutAsync)); }
        }

        private ICommand _testScrollCommand;

        public ICommand TestScrollCommand
        {
            get
            {
                return _testScrollCommand ??
                       (_testScrollCommand = ActionCommand
                           .When(() => true)
                           .Do(TestScroll));
            }
        }

        private async void TestScroll()
        {
            const string subPath = @"Google\Chrome\Application";
            const string exeName = "chrome.exe";

            //Start Chrome
            var root = Environment.Is64BitOperatingSystem
                ? Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)
                : Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            var fullPath = Path.Combine(root, subPath);
            var fullName = Path.Combine(fullPath, exeName);

            var chromeProcess = Process.Start(fullName);
            Debug.Assert(chromeProcess != null, "chromeProcess != null");

            await Task.Run(() =>
            {
                chromeProcess.WaitForExit();
            });

            await Task.Delay(2000);

            //search chrome
            var chromApps = Process.GetProcessesByName("chrome")
                .Where(x => !x.HasExited)
                .Where(x => !string.IsNullOrEmpty(x.MainWindowTitle));
            var chromeApp = chromApps.FirstOrDefault();
            if (chromeApp == null)
            {
                return;
            }

            _mouseController.Location = new Point(200, 200);

            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(50);
                var p = _mouseController.Location;
                p.Offset(2, 1);
                _mouseController.Location = p;
            }

            Random rnd = new Random();

            for (int i = 0; i < 5; ++i)
            {
                await Task.Delay(50);
                _mouseController.HorizontalWheel(120*rnd.Next(-1, 2));
            }

            await Task.Delay(500);

            for (int i = 0; i < 5; ++i)
            {
                await Task.Delay(50);
                _mouseController.Wheel(120 * rnd.Next(-1, 2));
            }
        }

        private async void ZoomInAsync()
        {
            await Task.Delay(1000);
            await _executor.PinchZoomInAsync(500, 500, 100, 1);
        }

        private async void ZoomOutAsync()
        {
            await Task.Delay(1000);
            await _executor.PinchZoomOutAsync(500, 500, 100, 1);
        }

        public IEnumerable<string> LogItems
        {
            get { return _logItems; }
        }
    }
}
