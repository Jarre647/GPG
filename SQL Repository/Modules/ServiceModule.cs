using Autofac;
using SQL_Repository.Repositories;
using SQL_Repository.Services;
using SQL_Repository.Services.Contracts;
using SQL_Repository.Settings;

namespace SQL_Repository.Modules
{
    public class ServiceModule : Module
    {
        private readonly AppSettings _appSettings;

        public ServiceModule(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(
                new AutofacModule(_appSettings.ConnectionsStrings.SQL_RepositoryContext));
            builder.RegisterType<AbuserApi>().As<IAbusersApi>();
        }
    }
}
