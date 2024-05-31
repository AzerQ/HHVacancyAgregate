using System.Threading.Tasks;
using HHVacancy.Core.Data.Models.Entities;

namespace HHVacancy.Core.Data;

public interface IVacancyDbService
{
    Task AddOrUpdateAreas(params AreaEntity[] areas);

    Task AddOrUpdateEmployers(params EmployerEntity[] employers);

    Task AddOrUpdateEmployments(params EmploymentEntity[] employments);

    Task AddOrUpdateExperienceItems(params ExperienceEntity[] experienceItems);

    Task AddOrUpdateProfessionalRoles(params ProfessionalRoleEntity[] professionalRoles);

    Task AddOrUpdateSchedules(params ScheduleEntity[] schedules);

    Task AddOrUpdateVacancyTypes(params VacancyTypeEntity[] vacacncyTypeEntity);

    Task AddOrUpdateVacancies(params VacancyEntity[] vacancies);
}
