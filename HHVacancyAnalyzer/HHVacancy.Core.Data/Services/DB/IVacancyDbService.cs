using System.Threading.Tasks;
using HHVacancy.Core.Data.Models.Entities;

namespace HHVacancy.Core.Data.Services.DB;

public interface IVacancyDbService
{
    Task InsertAreas(params AreaEntity[] areas);

    Task InsertEmployers(params EmployerEntity[] employers);

    Task InsertEmployments(params EmploymentEntity[] employments);

    Task InsertExperienceItems(params ExperienceEntity[] experienceItems);

    Task InsertProfessionalRoles(params ProfessionalRoleEntity[] professionalRoles);

    Task InsertSchedules(params ScheduleEntity[] schedules);

    Task InsertVacancyTypes(params VacancyTypeEntity[] vacacncyTypeEntitities);

    Task InsertVacancies(params VacancyEntity[] vacancies);

}
