using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingManager.API.Configurations;
using BuildingManager.API.Entities;
using BuildingManager.API.Services.Abstract;
using BuildingManager.API.Services.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BuildingManager.API
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
           
            services.Configure<BuildingManagerPaymentConfiguration>(Configuration.GetSection("MongoDbConfiguration"));
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<ICreditCardInfoService, CreditCardInfoService>();
            //services.AddMvc(setup => {}).AddFluentValidation();
            services.AddControllers(setup => {}).AddFluentValidation();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "BuildingManager.API", Version = "v1"});
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BuildingManager.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}