using Application.GetDogsByCategory;
using Application.RegisterDog;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DI
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRegisterDogInteractor, RegisterDogInteractor>();
            services.AddTransient<IGetDogsByCategoryInteractor, GetDogsByCategoryInteractor>();
            return services;
        }
    }
}