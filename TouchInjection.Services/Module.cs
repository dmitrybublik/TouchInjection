using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace TouchInjection.Services
{
    class Module : ICompositionModule<IIocContainer>
    {
        public void RegisterModule(IIocContainer iocContainer)
        {
            iocContainer.RegisterSingleton<ILocationProvider, MouseLocationProvider>();
            iocContainer.RegisterSingleton<IActionProvider, KeyboardActionProvider>();
            iocContainer.RegisterSingleton<ITouchInjectionProvider, TouchInjectionProvider>();
            iocContainer.RegisterSingleton<ITouchInjectionExecutor, TouchInjectionExecutor>();
            iocContainer.RegisterSingleton<ITouchInjectionListener, TouchInjectionListener>();

            iocContainer.RegisterSingleton<IScrollProvider, ScrollProvider>();
        }
    }
}
