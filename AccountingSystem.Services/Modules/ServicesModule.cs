using AccountingSystem.Services.Implementation;
using AccountingSystem.Services.Interfaces;
using Ninject.Modules;
using Ninject.Web.Common;

namespace AccountingSystem.Services.Modules
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITransactionService>().To<TransactionService>().InRequestScope();
            Bind<ICurrencyService>().To<CurrencyService>().InRequestScope();
            Bind<IClientService>().To<ClientService>().InRequestScope();
        }
    }
}
