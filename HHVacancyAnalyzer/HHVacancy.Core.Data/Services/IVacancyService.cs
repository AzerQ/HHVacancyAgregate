using HHVacancy.Core.Data.Models.Vacancy;
using HHVacancy.Core.Data.Models.VacancySearch;
using System.Threading.Tasks;

namespace HHVacancy.Core.Data.Services
{
    public interface IVacancyService
    {
        Task<Vacancy> GetVacancyById(int id);

        Task<VacancySearchResult> SearchVacancies (VacancySearchRequest vacancySearchRequest);
    }
}
