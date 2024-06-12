using HHVacancy.Models.API.Vacancy;
using HHVacancy.Models.API.VacancySearch;
using HHVacancy.Models.DB.Entities;
using HHVacancy.Storage.Services.Abstractions;
using Mapster;

namespace HHVacancy.Storage.Services.Implementations;

public class VacancyMappingService : IVacancyMappingService
{
    public VacancyDetailsEntity MapFromFullVacancy(Vacancy fullVacancy)
    {
        var vacancyDetail = fullVacancy.Adapt<VacancyDetailsEntity>();
        vacancyDetail.VacancyId = fullVacancy.Id;

        return vacancyDetail;
    }

    public VacancyEntity MapFromVacancyItem(VacancySearchItem vacancyItem)
    {
        return vacancyItem.Adapt<VacancyEntity>();
    }
}

