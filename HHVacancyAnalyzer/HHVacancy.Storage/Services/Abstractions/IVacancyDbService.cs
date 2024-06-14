using HHVacancy.Models.API.Vacancy;
using HHVacancy.Models.DB.Entities;
using HHVacancy.Models.DB.Entities.Links;
using HHVacancy.Models.DTO;

namespace HHVacancy.Storage.Services.Abstractions;

public interface IVacancyDbService : IDisposable
{
    Task InsertAreas(params AreaEntity[] areas);

    Task InsertEmployers(params EmployerEntity[] employers);

    Task InsertEmployments(params EmploymentEntity[] employments);

    Task InsertExperienceItems(params ExperienceEntity[] experienceItems);

    Task InsertProfessionalRoles(params ProfessionalRoleEntity[] professionalRoles);

    Task InsertProfessionalRolesLinks(params ProfessionalRoleVacancyLinkEntity[] professionalRoleVacancyLinks);

    Task InsertSchedules(params ScheduleEntity[] schedules);

    Task InsertVacancyTypes(params VacancyTypeEntity[] vacacncyTypeEntitities);

    Task InsertVacancies(params VacancyEntity[] vacancies);

    Task InsertVacancyDetails(params VacancyFullInfoDTO[] vacancyFullInfo);

}
