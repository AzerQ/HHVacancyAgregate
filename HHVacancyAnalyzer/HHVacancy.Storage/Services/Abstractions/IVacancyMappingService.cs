using HHVacancy.Models.API;
using HHVacancy.Models.API.VacancySearch;
using HHVacancy.Models.DB.Entities;
using HHVacancy.Models.DTO;

namespace HHVacancy.Storage.Services.Abstractions;

public interface IVacancyMappingService
{
    VacancyEntity MapVacancyEntityFromVacancyItem(VacancySearchItem vacancyItem);

    VacancyDetailDTO MapVacancyDetailDTOFromVacancyDetail(IVacancyDetail vacancyDetailItem);

}

