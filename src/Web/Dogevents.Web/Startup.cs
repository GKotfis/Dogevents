﻿using System.IO;
using Dogevents.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Dogevents.Web
{
    public class Startup
    {
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //DI configuration
            services.AddScoped<IEventsService, EventsService>();
            services.AddScoped<IFacebookClient, FacebookClient>(provider => new FacebookClient("EAACEdEose0cBAD9ZAsmFCuowYsv0HoZB07oMkMVPtLwLVlpdBMnzRkNSv7CHB6S06j4s0VRgaJNHyZAf0HF2V90JROZAnyqUW1Jc8WxaHzURcNWtDgWdAQQU3RCatKnQAa9zQIZBTh45kaCwPzoA7ZAhJRlpohE0sgHjWcotlaVMdOMDZArZCY20a0QgocjVegsZD"));
            services.AddScoped<IFacebookService, FacebookService>();

            services.AddSingleton(provider => new MongoClient("mongodb://localhost:27017"));
            services.AddScoped(provider => provider.GetService<MongoClient>().GetDatabase("dogevents"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}