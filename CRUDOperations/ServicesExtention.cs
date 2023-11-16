using CRUDOperation.Application.Repository;
using CRUDOperations.Infrastructure.Persistence;
using FluentValidation;
using System.Reflection;

namespace CRUDOperations.Api
{
    public static class ServicesExtention
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies
                (AppDomain.CurrentDomain.GetAssemblies()));
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;

        }
         
        
    }
}
