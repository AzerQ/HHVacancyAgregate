using HHVacancy.Core.Data.Models.Vacancy;
using HHVacancy.Core.Data.Models.VacancySearch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HHVacancy.Core.Data.Services
{
    /// <summary>
    /// Сервис для работы с вакансиями сайта HH.RU
    /// </summary>
    public interface IVacancyService
    {
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
        Task<VacancySearchResult> GetVacancySearchPage (VacancySearchRequest vacancySearchRequest);


        /// <summary>
        /// Получить все данные о вакансии по поисковому запросу
        /// </summary>
        /// <param name="searchVacancySearchRequest">Поисковые фильтры</param>
        /// <returns>Асинхронный поток данных поисковых страниц вакансий</returns>
        IAsyncEnumerable<VacancySearchResult> SearchVacancies (VacancySearchRequest searchVacancySearchRequest);
    }
}
