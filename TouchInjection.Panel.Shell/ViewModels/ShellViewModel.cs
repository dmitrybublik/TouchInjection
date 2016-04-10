using System.Threading.Tasks;
using System.Windows.Input;
using Caliburn.Micro;
using LogoFX.Client.Mvvm.Commanding;
using TouchInjection.Services;

namespace TouchInjection.Presentation.Shell.ViewModels
{
    class ShellViewModel : PropertyChangedBase
    {
        private readonly ITouchInjectionExecutor _executor;

        public ShellViewModel(
            ITouchInjectionListener listener,
            ITouchInjectionExecutor executor)
        {
            listener.Start();
            _executor = executor;
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
    }
}
