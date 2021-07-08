using System.Net.Http;
using System.Reflection;
using BuildingManager.Business.Abstract;
using BuildingManager.Business.Abstract.APIService;
using BuildingManager.Business.Concrete;
using BuildingManager.Business.Concrete.PaymentApiServices;
using BuildingManager.DataAccess.Abstract;
using BuildingManager.DataAccess.Concrete.EntityFramework.Contexts;
using BuildingManager.DataAccess.Concrete.EntityFramework.Repositories;
using BuildingManager.DataAccess.Concrete.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingManager.Business.Extensions
{
    public static class StartupExtension
    {
        public static IServiceCollection DependencyExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BuildingManagerDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            
            services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IExpenseTypeRepository, ExpenseTypeRepository>();
            services.AddScoped<IFlatRepository, FlatRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<IExpenseTypeService, ExpenseTypeService>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IFlatService, FlatService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IPaymentApiService, PaymentApiService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}