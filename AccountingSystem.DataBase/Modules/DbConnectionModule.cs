using AccountingSystem.DataBase.Implementation;
using AccountingSystem.DataBase.Interfaces;
using Autofac;

namespace AccountingSystem.DataBase.Modules
{
    public class DbConnectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandExecuter>().As<ICommandExecuter>().InstancePerRequest();
        }
    }
}
