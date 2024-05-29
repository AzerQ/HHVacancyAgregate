using HHVacancy.Core.Data.Models.Entities;
using HHVacancy.Core.Data.Models.VacancySearch;

namespace HHVacancy.Core.Data.Services
{
    public interface IVacancyMappingService
    {
        VacancyEntity MapFromVacancyItem(VacancyItem vacancyItem);
    }
}
