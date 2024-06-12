using Flurl.Http.Configuration;
using HHVacancy.ApiClient.Services.Abstractions;
using HHVacancy.ApiClient.Services.Implementations;
using HHVacancy.Core.Services.Abstractions;
using HHVacancy.Core.Services.Implementations;
using HHVacancy.Storage;
using HHVacancy.Storage.Services.Abstractions;
using HHVacancy.Storage.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace HHVacancy.Core
{
    /// <summary>
    /// Глобальная коннфигурация сервисов приложения
    /// </summary>
    public static class ServicesContainer
    {
        private static IServiceCollection _services;

        private static readonly ServiceProvider _serviceProvider;

        static ServicesContainer()
        {
            _services = new ServiceCollection();

            BuildApiServicesConfiguration(_services);

            BuildStorageServicesConfiguration(_services);

            BuildCoreServiceConfiguration(_services);

            _serviceProvider = _services.BuildServiceProvider();

        }

        private static void BuildApiServicesConfiguration(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISerializer, CorrectDateSerializer>()
                             .AddSingleton<IVacancyApiService, VacancyApiService>();
        }

        private static void BuildStorageServicesConfiguration(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IJsonDbSerializer, JsonDbSerializer>()
                             .AddTransient<IVacancyMappingService, VacancyMappingService>()
                             .AddDbContext<HHVacancyDbContext>()
                             .AddTransient<IVacancyDbService, VacancyDbService>();
        }

        private static void BuildCoreServiceConfiguration(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IVacancyGrabberService, VacancyGrabberService>();
        }

        /// <summary>
        /// Получить необходимый сервис приложения
        /// </summary>
        /// <typeparam name="TService">Тип сервиса (интерфейс)</typeparam>
        /// <returns>Реализация сервиса</returns>
        public static TService GetService<TService>() where TService : class
        {
            return _serviceProvider.GetRequiredService<TService>();
        }

    }
}