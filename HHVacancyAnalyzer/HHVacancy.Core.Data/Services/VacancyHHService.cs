using Flurl;
using Flurl.Http;
using HHVacancy.Core.Data.Models.Vacancy;
using HHVacancy.Core.Data.Models.VacancySearch;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HHVacancy.Core.Data.Services
{
    /// <summary>
    /// Сервис для работы с данными вакансий сайта hh.ru
    /// </summary>
    public class VacancyHHService : IVacancyHHService
    {
        /// <summary>
        /// Базовый адрес api HH.RU
        /// </summary>
        private readonly string _baseUrl;

        /// <summary>
        /// Максимальное кол-во записей при поиске (Ограничение API)
        /// </summary>
        private readonly int _maxItemsSize = 2000;

        /// <summary>
        /// Максимальное кол-во элементов на странице при запросе
        /// </summary>
        private readonly int _maxPageSize = 100;

        /// <summary>
        /// Имя приложения, Header: HH-User-Agent
        /// </summary>
        private readonly string _appName = @"HHWorkTagsAgregate/1.0 xxxvorobej71@gmail.com";

        /// <summary>
        /// Клиент для отправки HTTP запросов
        /// </summary>
        private readonly FlurlClient _flurlClient;

        /// <summary>
        /// Конфигурация библиотеки Flurl для отправки Http запросов
        /// </summary>
        private FlurlClient GetFlurlClient(string baseUrl, string apiToken, string appName)
        {

            var flurlClient = new FlurlClient(baseUrl)
                        .WithSettings(settings =>
                            {
                                settings.JsonSerializer = new CorrectDateSerializer();
                            })
                        .WithOAuthBearerToken(apiToken)
                        .WithHeader("HH-User-Agent", appName)
                        .OnError(async call =>
                        {
                            var contentBody = await call.HttpResponseMessage.Content.ReadAsStringAsync();
                            Console.WriteLine("HTTP Error body content: {0}", contentBody);
                        });


            return flurlClient;
        }

        /// <summary>
        /// Получить токен авторизации приложения
        /// </summary>
        /// <returns>OAuth Bearer token</returns>
        private string GetApiToken() => 
            Environment.GetEnvironmentVariable("HHAPITOKEN");

        /// <summary>
        /// Новый сервис для работы с данными вакансий сайта hh.ru
        /// </summary>
        public VacancyHHService(string? baseUrl = default)
        {
            _baseUrl = baseUrl ?? "https://api.hh.ru";

            _flurlClient = GetFlurlClient(_baseUrl, GetApiToken(), _appName);
        }

        public async Task<Vacancy> GetVacancyById(int id)
        {
            var queryParams = new
            {
                locale = "RU",
                host = "hh.ru"
            };

            var serverResponse = await _flurlClient
                                .Request("vacancies", id)
                                .SetQueryParams(queryParams)
                                .SendAsync(HttpMethod.Get);

            return await serverResponse.GetJsonAsync<Vacancy>();

        }

        private async Task<VacancySearchResult> GetVacancySearchPage(Dictionary<string, object> queryParams)
        {
            var serverResponse = await _flurlClient.Request("vacancies")
                                      .SetQueryParams(queryParams)
                                      .SendAsync(HttpMethod.Get);

            return await serverResponse.GetJsonAsync<VacancySearchResult>();
        }

        public async Task<VacancySearchResult> GetVacancySearchPage(VacancySearchRequest vacancySearchRequest)
        {
            var queryParams = vacancySearchRequest.ToDictionary();
            return await GetVacancySearchPage(queryParams);
        }



        private async Task<Pagination> GetRequestPagination(VacancySearchRequest vacancySearchRequest)
        {
            var requestParams = vacancySearchRequest.ToDictionary(pageNumber: 0, pageSize: 0);
            int totalSize = (await GetVacancySearchPage(requestParams)).Found;

            return new Pagination
            {
                TotalSize = Math.Min(totalSize, _maxItemsSize),
                PageSize = _maxPageSize
            };

        }

        public async IAsyncEnumerable<VacancySearchResult> SearchVacancies(VacancySearchRequest vacancySearchRequest)
        {
            Pagination requestPagination = await GetRequestPagination(vacancySearchRequest);

            for (int i = 0; i < requestPagination.PagesCount; i++)
            {
                var vacancySearchParams = vacancySearchRequest
                    .ToDictionary(pageNumber: i, pageSize: requestPagination.PageSize);
                yield return await GetVacancySearchPage(vacancySearchParams);
            }
        }
    }
}
