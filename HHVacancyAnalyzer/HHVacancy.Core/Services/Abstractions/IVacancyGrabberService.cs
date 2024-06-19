using HHVacancy.Models.API.VacancySearch;

namespace HHVacancy.Core.Services.Abstractions
{
    public interface IVacancyGrabberService
    {
        /// <summary>
        /// Получить все данные по запросу вакансий и сохранить их в хранилище
        /// </summary>
        /// <param name="request">Запрос для поиска вакансий</param>
        /// <returns>Кол-во найденных и сохраненных записей</returns>
        Task<int> GrabVacancySearchResults(VacancySearchRequest request, IProgress<double> progress);
    }
}
