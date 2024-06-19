using HHVacancy.Models.API.Vacancy;
using HHVacancy.Models.API.VacancySearch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HHVacancy.ApiClient.Services.Abstractions;

/// <summary>
/// Сервис для работы с вакансиями сайта HH.RU
/// </summary>
public interface IVacancyApiService : IDisposable
{
    /// <summary>
    /// Максимальное ограничение при поиске вакансий
    /// </summary>
    int MaxSearchResults { get; }

    /// <summary>
    /// Получить полные данные вакансии по ее идентификатору
    /// </summary>
    /// <remarks>GET {{baseUrl}}/vacancies/:vacancy_id</remarks>
    /// <param name="id">Идинтификатор вакансии в системе</param>
    /// <returns>Полную модель данных вакансии</returns>
    Task<Vacancy> GetVacancyById(int id);

    /// <summary>
    /// Получить страничку поиска вакансии
    /// </summary>
    /// <param name="vacancySearchRequest">Поисковые фильтры</param>
    /// <remarks>GET {{baseUrl}}/vacancies</remarks>
    /// <returns>Модель данных страницы поиска вакансии</returns>
    Task<VacancySearchResult> GetVacancySearchPage(VacancySearchRequest vacancySearchRequest);


    /// <summary>
    /// Получить все данные о вакансии по поисковому запросу
    /// </summary>
    /// <param name="searchVacancySearchRequest">Поисковые фильтры</param>
    /// <returns>Асинхронный поток данных поисковых страниц вакансий</returns>
    IAsyncEnumerable<VacancySearchResult> SearchVacancies(VacancySearchRequest searchVacancySearchRequest);

    /// <summary>
    /// Поучить полные данные по вакансиям по их идентификаторам
    /// </summary>
    /// <param name="vacancyIds">Идентификаторы вакансий</param>
    /// <returns>Асинхронный поток данных вакансий</returns>
    IAsyncEnumerable<Vacancy> GetVacanciesByIds(IEnumerable<int> vacancyIds);

    /// <summary>
    /// Получить ключевые навыки и подробное описаине вакансий по идентификаторам
    /// </summary>
    /// <param name="vacancyIds">Идентификаторы вакансий</param>
    /// <returns>Асинхронный потое данных о ключевых навыках и описание вакансий</returns>
    Task<IEnumerable<VacancyDetail>> GetVacancyDetails(IEnumerable<int> vacancyIds);

    /// <summary>
    /// Получить ключевые навыки и описание конкретной вакансии
    /// </summary>
    /// <param name="id">Идентификатор вакансии</param>
    /// <returns>Расширенные данные вакансии</returns>
    Task<VacancyDetail> GetVacancyDetail(int id);
    
    /// <summary>
    /// Получить предварительное количество результатов по поисковому запросу
    /// </summary>
    /// <param name="vacancySearchRequest">Поисковый запрос</param>
    /// <returns>Кол-во найденных по поисковым фильтрам записей</returns>
    Task<int> GetSearchQueryResultsCount(VacancySearchRequest vacancySearchRequest);
}
