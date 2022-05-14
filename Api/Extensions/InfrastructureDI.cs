using Application.Contracts;
using Infrastructure.Configuration;
using Infrastructure.Repositories;
using Infrastructure.TheDogApi;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var httpClientSettings = configuration
               .GetSection(nameof(HttpClientSettings))
               .Get<HttpClientSettings>();

            services.AddHttpClients(httpClientSettings);

            services.AddTransient<IDogRepository, InMemoryDogRepository>();
            services.AddTransient<IBreadDetailsContract, TheDogApiBreedsApiService>();

            return services;
        }

        private static IServiceCollection AddHttpClients(
            this IServiceCollection services,
            HttpClientSettings settings)
        {
            services.AddHttpClient(nameof(HttpClientSettings.TheDogApiV1BreedsUrl), httpClient =>
            {
                httpClient.BaseAddress = new Uri(settings.TheDogApiV1BreedsUrl);
                httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

            return services;
        }
    }
}