using Ninject;

namespace AccountingSystem.Shared.IoC
{
    public static class IoC
    {
        private static StandardKernel _instance;

        public static IKernel Instance => _instance ?? (_instance = new StandardKernel(new NinjectSettings() { LoadExtensions = false }));
    }
}
