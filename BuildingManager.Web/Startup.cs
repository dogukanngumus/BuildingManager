using System;
using BuildingManager.Business.Extensions;
using BuildingManager.DataAccess.Concrete.EntityFramework.Contexts;
using BuildingManager.Entities.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BuildingManager.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddDbContext<BuildingManagerDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<BuildingManagerDbContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options => {
                //password
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;

                //lockout
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = false;

                //options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

            });
            services.ConfigureApplicationCookie(options => {
                options.LoginPath = "/auth/login";
                options.LogoutPath = "/auth/logout";
                options.AccessDeniedPath = "/auth/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(60);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".BuildingManager.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });
            services.DependencyExtension(Configuration);
            services.AddControllersWithViews().AddFluentValidation(f=>f.RegisterValidatorsFromAssemblyContaining<Startup>());
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/ResponseHandling/NotFoundPage";
                    await next();
                }
            });
            
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 403)
                {
                    context.Request.Path = "/ResponseHandling/ForbiddenPage";
                    await next();
                }
            });
            
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 500)
                {
                    context.Request.Path = "/ResponseHandling/InternalServerErrorPage";
                    await next();
                }
            });

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}