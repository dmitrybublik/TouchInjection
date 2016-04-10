using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using TouchInjection.Presentation.Shell.ViewModels;

namespace TouchInjection.Presentation.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            var bootstrapper =
                new BootstrapperContainerBase<ShellViewModel, ExtendedSimpleContainerAdapter>(
                    new ExtendedSimpleContainerAdapter());
            bootstrapper.Initialize();
        }
    }
}
