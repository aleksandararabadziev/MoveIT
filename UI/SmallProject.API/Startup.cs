using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmallProject.AutoMapper;
using SmallProject.Data;
using SmallProject.Logging;
using SmallProject.Settings;
using System;
using System.Collections.Generic;

namespace SmallProject.API
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(_configuration.GetSection("Settings"));
            var settings = _configuration.GetSection("Settings").Get<AppSettings>();

            services.AddSingleton(AutoMapperConfiguration.Initialize());
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            RegisterDependencies(services, DependenciesRegistration.DependenciesRegistration.Services());
            RegisterDependencies(services, DependenciesRegistration.DependenciesRegistration.Data());

            services.AddDbContext<DataContext>(options => options.UseSqlServer(settings.DbConnectionString));

            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.WithOrigins(settings.WebUrl)
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                }));

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseStatusCodePagesWithReExecute("/");

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=OpenApi}/{action=VerifyConnection}");
            });
        }

        private static void RegisterDependencies(IServiceCollection services, Dictionary<Type, Type> components)
        {
            foreach (var item in components)
            {
                services.AddTransient(item.Key, item.Value);
            }
        }
    }
}
