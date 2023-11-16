using CRUDOperation.Application.Dtos;
using CRUDOperation.Application.Validation;
using CRUDOperations.Infrastructure.Dtos;
using FluentValidation;
using System.Runtime.CompilerServices;

namespace CRUDOperations.Api
{
    public static class ValidatorExtention 
    {
        public static IServiceCollection  AddValidators(this IServiceCollection services) 
        {
            services.AddScoped<IValidator<BrandCreateDto>, AddBrandValidator>();
            services.AddScoped<IValidator<BrandUpdateDto>, UpdateBrandValidator>();
            return services;
        }
    }
}
