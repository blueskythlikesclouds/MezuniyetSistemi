using MezuniyetSistemi.Business.Abstract;
using MezuniyetSistemi.Business.Concrete;
using MezuniyetSistemi.DataAccess.Abstract;
using MezuniyetSistemi.DataAccess.Concrete;
using MezuniyetSistemi.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace MezuniyetSistemi.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection services)
        {
            services.AddDbContext<MezuniyetSistemiContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserProfileService, UserProfileManager>();

            services.AddSingleton<ILoggerService, LoggerManager>();

            services.AddScoped<IEmailService, EMailManager>();

            services.AddScoped<ISpecialtyService, SpecialtyManager>();

            return services;
        }
    }
}
