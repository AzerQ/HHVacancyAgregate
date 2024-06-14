using HHVacancy.Models.API.Vacancy;
using HHVacancy.Models.API.VacancySearch;
using HHVacancy.Models.DB.Entities;
using HHVacancy.Models.DB.Entities.Links;
using HHVacancy.Models.DTO;

namespace HHVacancy.Storage.Services.Abstractions;

public interface IVacancyMappingService
{
    VacancyEntity MapVacancyEntityFromVacancyItem(VacancySearchItem vacancyItem);

    VacancyFullInfoDTO MapVacancyInfoDTOFromFullVacancy(Vacancy fullVacancy);

    (ProfessionalRoleEntity[] profRoles, ProfessionalRoleVacancyLinkEntity[] profRoleVacancies) 
        MapProfessionalRolesFromVacancyItem(VacancySearchItem vacancyItem);
}

