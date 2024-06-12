using HHVacancy.Models.API.Vacancy;
using HHVacancy.Models.API.VacancySearch;
using HHVacancy.Models.DB.Entities;

namespace HHVacancy.Storage.Services.Abstractions;

public interface IVacancyMappingService
{
    VacancyEntity MapFromVacancyItem(VacancySearchItem vacancyItem);

    VacancyDetailsEntity MapFromFullVacancy(Vacancy fullVacancy);
}

