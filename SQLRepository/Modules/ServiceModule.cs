using Autofac;
using SQLRepository.Repositories;
using SQLRepository.Services;
using SQLRepository.Services.Contracts;
using SQLRepository.Settings;

namespace SQLRepository.Modules
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
                new AutofacModule(_appSettings.ConnectionsStrings.SqlRepositoryContext));
            builder.RegisterType<GrudgeApi>().As<IGrudgesApi>();
        }
    }
}
