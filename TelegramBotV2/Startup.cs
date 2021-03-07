using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SQLRepository.Client;
using TelegramBotV2.Services;
using TelegramBotV2.Settings;
using VkNet;
using VkNet.Abstractions;
using VkNet.Model;


namespace TelegramBotV2
{
    public class Startup
    {
        public static AppSettings AppSettings { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var settings = Configuration.Get<AppSettings>();
            AppSettings = settings;
            services.AddTransient(provider => settings);
            services.RegisterSQLRepositoryClient(settings.SQLRepositoryClientSettings, builder => builder);
            services.AddSingleton<IVkApi>(sp => {
                var api = new VkApi();
                api.Authorize(new ApiAuthParams { AccessToken = Configuration["VKBotConfig:AccessToken"] });
                return api;
            });
            services.AddScoped<IUpdateService, UpdateService>();
            services.AddSingleton<IBotService, BotService>();
            services.Configure<BotConfiguration>(Configuration.GetSection("BotConfiguration"));
            services
                .AddControllers()
                .AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
