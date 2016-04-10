using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace TouchInjection.GlobalHook
{
    class Module : ICompositionModule<IIocContainer>
    {
        public void RegisterModule(IIocContainer iocContainer)
        {
            iocContainer.RegisterSingleton<IUserActivityHook, UserActivityHook>();
        }
    }
}
