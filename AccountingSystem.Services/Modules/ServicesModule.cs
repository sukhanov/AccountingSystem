using AccountingSystem.Services.Implementation;
using AccountingSystem.Services.Interfaces;
using Autofac;

namespace AccountingSystem.Services.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TransactionService>().As<ITransactionService>().InstancePerRequest();
            builder.RegisterType<CurrencyService>().As<ICurrencyService>().InstancePerRequest();
            builder.RegisterType<ClientService>().As<IClientService>().InstancePerRequest();
            builder.RegisterType<BalanceService>().As<IBalanceService>().InstancePerRequest();
        }
    }
}
