using System;
using Asp.Net_React_Redux_app.Data;
using Asp.Net_React_Redux_app.Data.Repositories.CompanyRepo;
using Asp.Net_React_Redux_app.Data.Repositories.OrderRepo;
using Asp.Net_React_Redux_app.Data.Repositories.PostRepo;
using Asp.Net_React_Redux_app.Data.Repositories.UserRepo;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Asp.Net_React_Redux_app {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<DataContext>(options => {
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection"));
                options.UseLoggerFactory(MyLoggerProvider);
            });
            
            services.AddControllersWithViews().AddFluentValidation();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IOrderRepo, OrderRepo>();

            services.AddSpaStaticFiles(configuration => {
                configuration.RootPath = "ClientApp/build";
            });
        }

        public static readonly ILoggerFactory
            MyLoggerProvider = LoggerFactory.Create(builder => {
                builder.AddProvider(new MyLoggerProvider());
            });
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            
            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa => {
                spa.Options.SourcePath = "ClientApp";
            
                if (env.IsDevelopment()) {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}