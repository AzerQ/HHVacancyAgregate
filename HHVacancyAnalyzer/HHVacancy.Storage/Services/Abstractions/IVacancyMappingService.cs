using HHVacancy.Models.API.VacancySearch;
using HHVacancy.Models.DB.Entities;

namespace HHVacancy.Storage.Services.Abstractions;

public interface IVacancyMappingService
{
    VacancyEntity MapFromVacancyItem(VacancyItem vacancyItem);
}

