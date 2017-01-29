using AccountingSystem.Repositories.Implementation;
using AccountingSystem.Repositories.Interfaces;
using Autofac;

namespace AccountingSystem.Repositories.Modules
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CurrencyRepository>().As<ICurrencyRepository>().InstancePerRequest();
            builder.RegisterType<ClientRepository>().As<IClientRepository>().InstancePerRequest();
            builder.RegisterType<BalanceRepository>().As<IBalanceRepository>().InstancePerRequest();
            builder.RegisterType<RateRepository>().As<IRateRepository>().InstancePerRequest();
            builder.RegisterType<TransactionRepository>().As<ITransactionRepository>().InstancePerRequest();
        }
    }
}
