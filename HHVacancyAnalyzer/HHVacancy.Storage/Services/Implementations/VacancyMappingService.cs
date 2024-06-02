using HHVacancy.Models.API.VacancySearch;
using HHVacancy.Models.DB.Entities;
using HHVacancy.Storage.Services.Abstractions;
using Mapster;

namespace HHVacancy.Storage.Services.Implementations;

public class VacancyMappingService : IVacancyMappingService
{
    public VacancyEntity MapFromVacancyItem(VacancyItem vacancyItem)
    {
        return vacancyItem.Adapt<VacancyEntity>();
    }
}

