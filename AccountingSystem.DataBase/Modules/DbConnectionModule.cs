using AccountingSystem.DataBase.Implementation;
using AccountingSystem.DataBase.Interfaces;
using Ninject.Modules;
using Ninject.Web.Common;

namespace AccountingSystem.DataBase.Modules
{
    public class DbConnectionModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICommandExecuter>().To<CommandExecuter>().InRequestScope();
        }
    }
}
