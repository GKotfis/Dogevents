using System.IO;
using Dogevents.Core.Services;
using Dogevents.Core.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
                options.AddPolicy("AllowAnyOrigin",
                    builder => builder.AllowAnyOrigin());
            });

            services.AddMvc();
            //services.Configure<MvcOptions>(options =>
            //{
            //    options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
            //});

            //DI configuration
            services.AddSingleton(provider => GetConfigurationValue<DatabaseSettings>("db"));
            services.AddScoped<IEventsService, EventsService>();
            services.AddScoped<IViewEventsService, ViewEventsService>();
            services.AddScoped<IFacebookClient, FacebookClient>(provider => new FacebookClient("429398007407936|eZyoBi3ESSBJ8Vz3uJZPVcGBJ6A"));
            services.AddScoped<IFacebookService, FacebookService>();

            var dbSettings = GetConfigurationValue<DatabaseSettings>("db");
            var mongoUrl = new MongoUrl(dbSettings.ConnectionString);
            services.AddSingleton(provider => new MongoClient(mongoUrl));
            services.AddScoped(provider => provider.GetService<MongoClient>().GetDatabase(mongoUrl.DatabaseName));
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
        }

        private T GetConfigurationValue<T>(string section) where T : new()
        {
            T val = new T();
            Configuration.GetSection(section).Bind(val);
            return val;
        }
    }
}