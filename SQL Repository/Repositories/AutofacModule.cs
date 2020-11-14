using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SQL_Repository.Data;

namespace SQL_Repository.Repositories
{
    public class AutofacModule : Module
    {
        private readonly string _connectionString;

        public AutofacModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
                {
                    var config = c.Resolve<IConfiguration>();
                    var options = new DbContextOptionsBuilder<SqlRepositoryContext>();
                    options.UseSqlServer(config.GetValue<string>("ConnectionString"));

                    return new SqlRepositoryContext(options.Options);
                })
                .AsSelf();

            builder.RegisterGeneric(typeof(EntityRepository<>));

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
        }
    }
}
