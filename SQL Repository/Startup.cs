using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SQL_Repository.Middleware;
using SQL_Repository.Modules;
using SQL_Repository.Repositories;
using SQL_Repository.Data;

namespace SQL_Repository
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.RegisterServices();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<SqlRepositoryContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SqlRepositoryContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            UpdateDatabase(app);

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<SqlRepositoryContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}