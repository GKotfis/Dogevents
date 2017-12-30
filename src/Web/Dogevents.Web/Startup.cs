using System.IO;
using System.Security.Authentication;
using Dogevents.Core.Domain;
using Dogevents.Core.Mongo;
using Dogevents.Core.Services;
using Dogevents.Core.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Dogevents.Web
{
    public class Startup
    {
        private IConfigurationRoot Configuration { get; }

        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                                    .SetBasePath(env.ContentRootPath)
                                    .AddJsonFile("config.json", false, true)
                                    .AddJsonFile($"config.{env.EnvironmentName}.json", true, true)
                                    .AddEnvironmentVariables()
                                    .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.Configure<DatabaseSettings>(Configuration.GetSection("db"));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://dogevents.pl", "http://localhost:8081"));
            });

            services.AddMvc();
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
            });

            //DI configuration
            services.AddSingleton(provider => Configuration.GetConfigurationValue<DatabaseSettings>("db"));
            services.AddScoped<IEventsService, EventsService>();
            services.AddScoped<IViewEventsService, ViewEventsService>();
            services.AddScoped<IFacebookClient, FacebookClient>(provider => new FacebookClient("429398007407936|eZyoBi3ESSBJ8Vz3uJZPVcGBJ6A"));
            services.AddScoped<IFacebookService, FacebookService>();
            services.AddScoped<IEventValidator, EventValidator>();

            var dbSettings = Configuration.GetConfigurationValue<DatabaseSettings>("db"); 
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(dbSettings.ConnectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            services.AddSingleton(provider => new MongoClient(settings));
            services.AddScoped(provider => provider.GetService<MongoClient>().GetDatabase("dogeventsdb"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
            }

            app.UseCors("AllowSpecificOrigin");
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            MongoConfigurator.Initialize();
        }
    }
}