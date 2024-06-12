using HHVacancy.Models.DB.Entities;

namespace HHVacancy.Storage.Services.Abstractions;

public interface IVacancyDbService : IDisposable
{
    Task InsertAreas(params AreaEntity[] areas);

    Task InsertEmployers(params EmployerEntity[] employers);

    Task InsertEmployments(params EmploymentEntity[] employments);

    Task InsertExperienceItems(params ExperienceEntity[] experienceItems);

    Task InsertProfessionalRoles(params ProfessionalRoleEntity[] professionalRoles);

    Task InsertSchedules(params ScheduleEntity[] schedules);

    Task InsertVacancyTypes(params VacancyTypeEntity[] vacacncyTypeEntitities);

    Task InsertVacancies(params VacancyEntity[] vacancies);

    Task InsertVacancyDetails(params VacancyDetailsEntity[] vacancyDetails);

}
