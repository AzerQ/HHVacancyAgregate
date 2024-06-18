using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using HHVacancy.ApiClient.Services.Abstractions;
using HHVacancy.Models.API;
using HHVacancy.Models.API.Vacancy;
using HHVacancy.Models.API.VacancySearch;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HHVacancy.ApiClient.Services.Implementations;

/// <summary>
/// Сервис для работы с данными вакансий сайта hh.ru
/// </summary>
public class VacancyApiService : IVacancyApiService
{
    /// <summary>
    /// Базовый адрес api HH.RU
    /// </summary>
    private readonly string _baseUrl;

    private readonly ISerializer _serializer;

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

    private readonly int _maxClientRps = 30;


    /// <summary>
    /// Конфигурация библиотеки Flurl для отправки Http запросов
    /// </summary>
    private FlurlClient GetFlurlClient(string baseUrl, string apiToken, string appName, ISerializer serializer)
    {

        var flurlClient = new FlurlClient(baseUrl)
                    .WithSettings(settings =>
                        {
                            settings.JsonSerializer = _serializer;
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
    public VacancyApiService(ISerializer serializer)
    {
        _baseUrl = "https://api.hh.ru";

        _serializer = serializer;

        _flurlClient = GetFlurlClient(_baseUrl, GetApiToken(), _appName, _serializer);


    }

    private async Task<IEnumerable<T>> GetVacancyInformation<T>(IEnumerable<int> vacancyIds) where T : IVacancyDetail
    {
        var queryParams = new
        {
            locale = "RU",
            host = "hh.ru"
        };


        var vacacnyReuqests = vacancyIds.Select(async vacancyId =>
        {
            return await _flurlClient
                            .Request("vacancies", vacancyId)
                            .SetQueryParams(queryParams)
                            .SendAsync(HttpMethod.Get);
        });

        var serverResponses = await Task.WhenAll(vacacnyReuqests);

        return await Task
            .WhenAll(serverResponses
            .Select(response => response.GetJsonAsync<T>()));
    }

    public async Task<Vacancy> GetVacancyById(int id)
    {
        IEnumerable<Vacancy> vacancies = await GetVacancyInformation<Vacancy>([id]);
        return vacancies.First();
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

    class RequestResultsCount
    {
        [JsonPropertyName("found")]
        public int Found { get; set; }
    }


    private async Task<Pagination> GetRequestPagination(VacancySearchRequest vacancySearchRequest)
    {

        var requestParams = vacancySearchRequest.ToDictionary(pageNumber: 0, pageSize: 0);

        var serverResponse = await _flurlClient.Request("vacancies")
                                  .SetQueryParams(requestParams)
                                  .GetJsonAsync<RequestResultsCount>();

        int totalSize = serverResponse.Found;

        int resultsCount = new int[] { totalSize, _maxItemsSize, vacancySearchRequest.MaxResults }.Min();

        return new Pagination
        {
            TotalSize = resultsCount,
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


    private async Task<T> ExecuteWithRetry<T>(int rps, int retryCount, Func<Task<T>> action)
    {
        var policy = Policy
            .Handle<FlurlHttpException>()
            .WaitAndRetryAsync(retryCount, retryAttempt => TimeSpan.FromSeconds(1 / rps));

        return await policy.ExecuteAsync(action);
    }

    public async IAsyncEnumerable<Vacancy> GetVacanciesByIds(IEnumerable<int> vacancyIds)
    {
        foreach (var id in vacancyIds)
        {
            yield return await ExecuteWithRetry(_maxClientRps, 3, () => GetVacancyById(id));
        }

    }

    public async Task<IEnumerable<VacancyDetail>> GetVacancyDetails(IEnumerable<int> vacancyIds)
    {
           return await GetVacancyInformation<VacancyDetail>(vacancyIds);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _flurlClient?.Dispose();
        }
    }

    public void Dispose()
    {
        // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public Task<VacancyDetail> GetVacancyDetail(int id)
    {
        throw new NotImplementedException();
    }
}

